using PackBuilder.Common.JsonBuilding.DataStructures;
using Terraria;

namespace PackBuilder.Common.JsonBuilding.Items.Changes
{
    internal class VanillaItemChange : IItemChange
    {
        public ValueModifier Damage { get; set; }
        public ValueModifier CritRate { get; set; }
        public ValueModifier Defense { get; set; }
        public ValueModifier HammerPower { get; set; }
        public ValueModifier PickaxePower { get; set; }
        public ValueModifier AxePower { get; set; }
        public ValueModifier Healing { get; set; }
        public ValueModifier ManaRestoration { get; set; }
        public ValueModifier Knockback { get; set; }
        public ValueModifier LifeRegen { get; set; }
        public ValueModifier ManaCost { get; set; }
        public ValueModifier ShootSpeed { get; set; }
        public ValueModifier UseTime { get; set; }
        public ValueModifier UseAnimation { get; set; }

        public void ApplyTo(Item item)
        {
            this.Damage.ApplyTo(ref item.damage);
            this.CritRate.ApplyTo(ref item.crit);
            this.Defense.ApplyTo(ref item.defense);
            this.HammerPower.ApplyTo(ref item.hammer);
            this.PickaxePower.ApplyTo(ref item.pick);
            this.AxePower.ApplyTo(ref item.axe);
            this.Healing.ApplyTo(ref item.healLife);
            this.ManaRestoration.ApplyTo(ref item.healMana);
            this.Knockback.ApplyTo(ref item.knockBack);
            this.LifeRegen.ApplyTo(ref item.lifeRegen);
            this.ManaCost.ApplyTo(ref item.mana);
            this.ShootSpeed.ApplyTo(ref item.shootSpeed);
            this.UseTime.ApplyTo(ref item.useTime);
            this.UseAnimation.ApplyTo(ref item.useAnimation);
        }
    }
}
