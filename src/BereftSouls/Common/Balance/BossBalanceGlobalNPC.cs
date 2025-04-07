﻿using CalamityMod;
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
