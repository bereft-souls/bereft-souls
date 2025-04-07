using SOTS.Items.Celestial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BereftSouls.Common.Balance
{
    public class BalanceGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string BalanceLine = Language.GetTextValue($"Mods.FargowiltasCrossmod.EModeBalance.CrossBalanceGeneric");

            string BalanceUpLine = $"[c/00A36C:{BalanceLine}]";
            string BalanceDownLine = $"[c/FF0000:{BalanceLine}]";

            static string BalanceTooltips(string key) => Language.GetTextValue($"Mods.BereftSouls.ItemBalance.{key}");
            //void Buff(string key) => tooltips.Add(new TooltipLine(Mod, "BalanceUp", $"{BalanceUpLine}" + BalanceTooltips(key)));
            void NerfTooltip(string key) => tooltips.Add(new TooltipLine(Mod, "BalanceDown", $"{BalanceDownLine}" + BalanceTooltips(key)));

            if (item.type == ItemType<FoggyClairvoyance>())
                NerfTooltip("FoggyClairvoyance");
        }
    }
}
