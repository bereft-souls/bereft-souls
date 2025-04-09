using System.Collections.Generic;

using JetBrains.Annotations;

using SOTS.Items.Celestial;

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace BereftCompatibility.Common.Balance;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
internal sealed class ItemBalance : GlobalItem
{
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        var balanceLine = Language.GetTextValue("Mods.FargowiltasCrossmod.EModeBalance.CrossBalanceGeneric");

        var balanceUpLine   = $"[c/00A36C:{balanceLine}]";
        var balanceDownLine = $"[c/FF0000:{balanceLine}]";

        if (item.type == ItemType<FoggyClairvoyance>())
        {
            NerfTooltip("FoggyClairvoyance");
        }

        return;

        void BuffTooltip(string key)
        {
            tooltips.Add(new TooltipLine(Mod, "BalanceUp", $"{balanceUpLine}" + BalanceTooltips(key)));
        }

        void NerfTooltip(string key)
        {
            tooltips.Add(new TooltipLine(Mod, "BalanceDown", $"{balanceDownLine}" + BalanceTooltips(key)));
        }

        static string BalanceTooltips(string key)
        {
            return Language.GetTextValue($"Mods.BereftCompatibility.ItemBalance.{key}");
        }
    }
}