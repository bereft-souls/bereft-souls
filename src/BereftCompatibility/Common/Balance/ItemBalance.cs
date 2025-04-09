using System.Collections.Generic;

using JetBrains.Annotations;

using SOTS.Items.Celestial;
using SOTS.Items.Earth.Glowmoth;
using SOTS.Items.Slime;

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

using static Terraria.ModLoader.ModContent;

namespace BereftCompatibility.Common.Balance;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
internal sealed class ItemBalance : GlobalItem
{
    private static readonly HashSet<int> summon_items =
    [
        ItemType<SuspiciousLookingCandle>(),
        ItemType<JarOfPeanuts>(),
    ];

    public override void SetDefaults(Item entity)
    {
        base.SetDefaults(entity);

        // Make uncomsumable like Calamity's edits to boss summons.
        if (summon_items.Contains(entity.type))
        {
            entity.maxStack   = 1;
            entity.consumable = false;

            // Calamity additionally makes this change, for some reason.  We
            // won't do this because it causes items to be used multiple times
            // if the useAnimation value is greater than useTime.  Seems
            // pointless.
            // entity.useTime = 10;
        }
    }

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