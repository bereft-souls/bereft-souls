using CalamityMod;
using SOTS.NPCs.Boss;
using SOTS.NPCs.Boss.Curse;
using SOTS.NPCs.Boss.Glowmoth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
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

            // Calamity boss health boost config compatibility
            if (!Main.gameMenu && CalamityConfig.Instance != null && npc.boss && npc.ModNPC != null && npc.ModNPC.Mod != null && (npc.ModNPC.Mod == ModCompatibility.SOTS.Mod))
            {
                // Boost health according to Calamity boss health boost config
                float HPBoost = CalamityConfig.Instance.BossHealthBoost * 0.01f;
                npc.lifeMax += (int)(npc.lifeMax * HPBoost);
            }
        }
    }
}
