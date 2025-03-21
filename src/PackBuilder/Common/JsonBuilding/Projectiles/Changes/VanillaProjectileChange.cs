using PackBuilder.Common.JsonBuilding.Data;
using Terraria;

namespace PackBuilder.Common.JsonBuilding.Projectiles.Changes
{
    internal class VanillaProjectileChange : IProjectileChange
    {
        public ValueModifier Damage { get; set; }
        public ValueModifier Piercing { get; set; }
        public ValueModifier Scale { get; set; }
        public ValueModifier HitCooldown { get; set; }

        public void ApplyTo(Projectile projectile)
        {
            this.Damage.ApplyTo(ref projectile.damage);
            this.Piercing.ApplyTo(ref projectile.maxPenetrate);
            projectile.penetrate = projectile.maxPenetrate;
            this.Scale.ApplyTo(ref projectile.scale);

            if (projectile.usesLocalNPCImmunity)
                this.HitCooldown.ApplyTo(ref projectile.localNPCHitCooldown);

            else if (projectile.usesIDStaticNPCImmunity)
                this.HitCooldown.ApplyTo(ref projectile.idStaticNPCHitCooldown);
        }
    }
}
