using CalamityMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace BereftSouls.Common.Balance
{
    public class BossBalanceGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void SetDefaults(NPC npc)
        {

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
