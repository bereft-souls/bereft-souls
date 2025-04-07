using Fargowiltas.NPCs;
using MonoMod.RuntimeDetour;
using SOTS.Items.Celestial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BereftSouls.Common.Balance
{
    public class FoggyClairvoyanceDebuffs : ModSystem
    {

        private static readonly MethodInfo? UpdateAccessoryMethod = typeof(FoggyClairvoyance).GetMethod("UpdateAccessory", LumUtils.UniversalBindingFlags);
        public override void PostSetupContent()
        {
            if (UpdateAccessoryMethod == null)
                return;
            MonoModHooks.Add(UpdateAccessoryMethod, UpdateAccessory_Detour);
        }
        public delegate void Orig_UpdateAccessory(FoggyClairvoyance self, Player player, bool hideVisual);
        private static void UpdateAccessory_Detour(Orig_UpdateAccessory orig, FoggyClairvoyance self, Player player, bool hideVisual)
        {
            bool[]? wasImmune = player.buffImmune.Clone() as bool[];
            orig(self, player, hideVisual);
            if (wasImmune == null) // this should be impossible but still
                return;
            // prevent item from granting immunity to non-SotS modded buffs
            for (int i = 0; i < player.buffImmune.Length; i++)
            {
                bool debuff = Main.debuff[i];
                if (player.buffImmune[i] && !wasImmune[i] && debuff)
                {
                    if (i >= BuffID.Count && BuffLoader.GetBuff(i).Mod.Name != ModCompatibility.SOTS.Name)
                        player.buffImmune[i] = false;
                }
            }
        }
    }
}
