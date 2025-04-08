using CalamityMod;
using SOTS.Items.Celestial;
using SOTS.NPCs;
using SOTS.NPCs.Boss;
using SOTS.NPCs.Boss.Advisor;
using SOTS.NPCs.Boss.Curse;
using SOTS.NPCs.Boss.Glowmoth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BereftSouls.Common.Balance
{
    public class BossBalanceGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(NPC npc)
        {
            var calNPC = npc.Calamity();

            // glowmoth
            if (npc.type == NPCType<Glowmoth>())
            {
                npc.lifeMax = 4200;
                calNPC.VulnerableToSickness = true;
            }
            if (npc.type == NPCType<Glowmoth>() || npc.type == NPCType<GlowmothMinion>())
            {
                // one singular projectile, spawned from glowmoth minion, has explicitly typed damage
                // this applies to the rest of the fight's projectiles
                npc.damage = 45;
            }

            // putrid pinky
            if (npc.type == NPCType<PutridPinkyPhase2>())
            {
                npc.lifeMax = 6875; // base is 5000
            }
            if (npc.type == NPCType<PutridHook>())
            {
                npc.lifeMax = 500; // base is 400
            }
            if (npc.type == NPCType<PutridPinky1>() || npc.type == NPCType<PutridPinkyPhase2>() || npc.type == NPCType<PutridHook>())
            {
                npc.damage = 50;
                calNPC.VulnerableToSickness = false;
                calNPC.VulnerableToHeat = true;
            }
            // pharaoh
            if (npc.type == NPCType<PharaohsCurse>())
            {
                npc.lifeMax = 4200; // base is 4000
                npc.damage = 50;
                CalamityMod.ModCalls.SetDefenseDamageNPC(npc, true);
                calNPC.VulnerableToCold = true;
                calNPC.VulnerableToHeat = false;
                calNPC.VulnerableToSickness = false;
            }

            // advisor
            if (npc.type == NPCType<TheAdvisorHead>())
            {
                // stats also need to be scaled in detour because of how the boss works
                npc.lifeMax = 17000; // base is 12500
                npc.damage = 62; // base is 54
                calNPC.VulnerableToElectricity = true;
                calNPC.VulnerableToSickness = false;
            }
            if (npc.type == NPCType<PhaseEye>())
            {
                npc.lifeMax = 68;
                npc.damage = 58;
                calNPC.VulnerableToElectricity = true;
                calNPC.VulnerableToSickness = false;
            }

            // Calamity boss health boost config compatibility
            if (!Main.gameMenu && CalamityConfig.Instance != null && npc.boss && npc.ModNPC != null && npc.ModNPC.Mod != null && (npc.ModNPC.Mod == ModCompatibility.SOTS.Mod))
            {
                // Boost health according to Calamity boss health boost config
                float HPBoost = CalamityConfig.Instance.BossHealthBoost * 0.01f;
                npc.lifeMax += (int)(npc.lifeMax * HPBoost);
            }
        }

        private static readonly MethodInfo? Advisor_ScaleExpertStatsMethod = typeof(TheAdvisorHead).GetMethod("ScaleExpertStats", LumUtils.UniversalBindingFlags);
        public override void Load()
        {
            if (Advisor_ScaleExpertStatsMethod != null)
                MonoModHooks.Add(Advisor_ScaleExpertStatsMethod, Advisor_ScaleExpertStats_Detour);

        }
        public delegate void Orig_Advisor_ScaleExpertStats(TheAdvisorHead self);
        private static void Advisor_ScaleExpertStats_Detour(Orig_Advisor_ScaleExpertStats orig, TheAdvisorHead self)
        {
            orig(self);
            self.NPC.life = self.NPC.lifeMax = 17000; // base is 12500
            self.NPC.damage = 62; // base is 54
            self.NPC.ScaleStats(null, Main.GameModeInfo, null);
        }
    }
}
