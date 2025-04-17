using Mono.Cecil.Cil;
using MonoMod.Cil;
using Newtonsoft.Json;
using PackBuilder.Common.JsonBuilding.NPCs;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace PackBuilder.Core.Systems
{
    internal class PackBuilderNPC : GlobalNPC
    {
        public static FrozenDictionary<int, List<NPCChanges>>? NPCModSets = null;

        public override void SetDefaults(NPC entity)
        {
            if (entity.netID >= 0)
                ApplyChanges(entity, entity.type);
        }

        public static void ApplyChanges(NPC npc, int npcId)
        {
            if (NPCModSets?.TryGetValue(npcId, out var value) ?? false)
                value.ForEach(c => c.ApplyTo(npc));
        }

        public override void Load()
        {
            // Assign npc.netID to it's designated netID during SetDefaults setup.
            IL_NPC.SetDefaultsFromNetId += IL_NPC_SetDefaultsFromNetId;

            // During SetDefaults this value is reset back to 0. Make sure that is undone.
            IL_NPC.SetDefaults += IL_NPC_SetDefaults;
        }

        private static void IL_NPC_SetDefaultsFromNetId(ILContext il)
        {
            try
            {
                var cursor = new ILCursor(il);

                // Navigate to the first SetDefaults call.
                // This method is passed a value of 0 to essentially only act as a field initializer.
                var setDefaultsMethod = typeof(NPC).GetMethod("SetDefaults", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)!;
                cursor.GotoNext(i => i.MatchCall(setDefaultsMethod));

                // After the NPC is initialized, we want to immediately assign netID.
                // This allows us to differentiate between netID specific NPCs for NPC modifications.
                cursor.Index++;
                cursor.Emit(OpCodes.Ldarg_0); // Push the NPC to the stack
                cursor.Emit(OpCodes.Ldarg_1); // Push the designated net ID to the stack

                var netIdField = typeof(NPC).GetField("netID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)!;
                cursor.Emit(OpCodes.Stfld, netIdField); // Assign the NPCs netID field. Pops both of our pushed values.


                // Then we need to make sure that our ApplyChanges method is called before difficulty scaling.
                // This is the entire reason we need this il edit.

                // Navigate to the next instruction that assigns the NPC's netID.
                cursor.GotoNext(i => i.MatchStfld(netIdField));

                // After this assigning, call our apply changes method.
                // This allows users to specify different changes for NPCs that share a 'type' but have difference netID's (ie. slimes)
                cursor.Index++;
                cursor.Emit(OpCodes.Ldarg_0); // Push the NPC to the stack
                cursor.Emit(OpCodes.Ldarg_1); // Push the designated net ID to the stack

                var applyChangesMethod = typeof(PackBuilderNPC).GetMethod("ApplyChanges", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)!;
                cursor.Emit(OpCodes.Call, applyChangesMethod); // Call our ApplyChanges method. Pops both of our pushed values.
            }
            catch
            {
                MonoModHooks.DumpIL(ModContent.GetInstance<PackBuilder>(), il);
            }
        }

        private static void IL_NPC_SetDefaults(ILContext il)
        {
            try
            {
                var cursor = new ILCursor(il);

                // Navigate to the first instance of setting netID.
                var netIdField = typeof(NPC).GetField("netID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)!;
                cursor.GotoNext(i => i.MatchStfld(netIdField));

                // Move back 2 instructions and remove the next 3 instructions.
                // This prevents the method from overriding the netID field with 0.
                // The default value of this field is 0 regardless so it does not matter.
                cursor.Index -= 2;
                cursor.RemoveRange(3);
            }
            catch
            {
                MonoModHooks.DumpIL(ModContent.GetInstance<PackBuilder>(), il);
            }
        }
    }

    internal class NPCModifier : ModSystem
    {

        public override void PostSetupContent()
        {
            // Collects ALL .npcmod.json files from all mods into a list.
            Dictionary<string, byte[]> jsonEntries = [];

            // Collects the loaded NPC mods to pass to the set factory initialization.
            Dictionary<int, List<NPCChanges>> factorySets = [];

            foreach (Mod mod in ModLoader.Mods)
            {
                // An array of all .npcmod.json files from this specific mod.
                var files = (mod.GetFileNames() ?? []).Where(s => s.EndsWith(".npcmod.json", System.StringComparison.OrdinalIgnoreCase));

                // Adds the byte contents of each file to the list.
                foreach (var file in files)
                    jsonEntries.Add(file, mod.GetFileBytes(file));
            }

            foreach (var jsonEntry in jsonEntries)
            {
                PackBuilder.LoadingFile = jsonEntry.Key;

                // Convert the raw bytes into raw text.
                string rawJson = Encoding.UTF8.GetString(jsonEntry.Value);

                // Decode the json into an NPC mod.
                NPCMod npcMod = JsonConvert.DeserializeObject<NPCMod>(rawJson, PackBuilder.JsonSettings)!;

                if (npcMod.NPCs.Count == 0)
                    throw new NoNPCsException();

                // Get the NPC mod ready for factory initialization.
                foreach (string npc in npcMod.NPCs)
                {
                    int npcType = GetNPC(npc);

                    factorySets.TryAdd(npcType, []);
                    factorySets[npcType].Add(npcMod.Changes);
                }

                PackBuilder.LoadingFile = null;
            }

            // Setup the factory for fast access to NPC lookup.
            PackBuilderNPC.NPCModSets = factorySets.ToFrozenDictionary();
        }
    }
}
