using PackBuilder.Common.JsonBuilding.Data;
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

        public void ApplyTo(Item item)
        {
            this.Damage.ApplyTo(ref item.damage);
            this.Damage.ApplyTo(ref item.crit);
            this.Damage.ApplyTo(ref item.defense);
            this.Damage.ApplyTo(ref item.hammer);
            this.Damage.ApplyTo(ref item.pick);
            this.Damage.ApplyTo(ref item.axe);
            this.Damage.ApplyTo(ref item.healLife);
            this.Damage.ApplyTo(ref item.healMana);
            this.Damage.ApplyTo(ref item.knockBack);
            this.Damage.ApplyTo(ref item.lifeRegen);
            this.Damage.ApplyTo(ref item.mana);
            this.Damage.ApplyTo(ref item.shootSpeed);
            this.Damage.ApplyTo(ref item.useTime);
        }
    }
}
