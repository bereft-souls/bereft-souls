using CalamityMod;
using PackBuilder.Common.JsonBuilding.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace PackBuilder.Common.JsonBuilding.Items.Changes
{
    internal class CalamityItemChange : IItemChange
    {
        public ValueModifier MaxCharge { get; set; }
        public ValueModifier ChargePerUse { get; set; }
        public ValueModifier ChargePerAltUse { get; set; }

        [JITWhenModsEnabled("CalamityMod")]
        public void ApplyTo(Item item)
        {
            var calItem = item.Calamity();

            this.MaxCharge.ApplyTo(ref calItem.MaxCharge);
            this.ChargePerUse.ApplyTo(ref calItem.ChargePerUse);
            this.ChargePerAltUse.ApplyTo(ref calItem.ChargePerAltUse);
        }
    }
}
