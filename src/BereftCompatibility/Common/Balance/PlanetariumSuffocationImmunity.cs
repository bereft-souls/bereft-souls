using JetBrains.Annotations;

using SOTS.Biomes;

using Terraria.ID;
using Terraria.ModLoader;

namespace BereftCompatibility.Common.Balance;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class PlanetariumSuffocationImmunity : ModPlayer
{
    public override void PreUpdateBuffs()
    {
        base.PreUpdateBuffs();

        // Pretty simple solution to making players immune to Eternity mode
        // space breath, but this won't apply to NPCs.  Doubt it's necessary.
        if (Player.InModBiome<PlanetariumBiome>())
        {
            Player.buffImmune[BuffID.Suffocation] = true;
        }
    }
}