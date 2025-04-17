using System;

using JetBrains.Annotations;

using SOTS.Items.Celestial;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// ReSharper disable InconsistentNaming

namespace BereftCompatibility.Common.Balance;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
internal sealed class FoggyClairvoyanceDebuffs : ModSystem
{
    public override void PostSetupContent()
    {
        MonoModHooks.Add(
            typeof(FoggyClairvoyance).GetMethod(nameof(FoggyClairvoyance.UpdateAccessory), GENERIC_FLAGS)!,
            UpdateAccessory_RemoveImmunityToModdedDebuffs
        );
    }

    private static void UpdateAccessory_RemoveImmunityToModdedDebuffs(Action<FoggyClairvoyance, Player, bool> orig, FoggyClairvoyance self, Player player, bool hideVisual)
    {
        if (player.buffImmune.Clone() is not bool[] wasImmune)
        {
            // Should be unreachable.  If buffImmune is null then we'll get an
            // NRE instead.
            throw new InvalidOperationException("Failed to clone Terraria.Player::buffImmune");
        }

        orig(self, player, hideVisual);

        // Prevent the item from granting immunity to modded, non-SotS buffs.
        for (var i = BuffID.Count; i < player.buffImmune.Length; i++)
        {
            if (!player.buffImmune[i] || wasImmune[i] || !Main.debuff[i])
            {
                continue;
            }

            if (BuffLoader.GetBuff(i)?.Mod.Name != ModCompatibility.Sots.Name)
            {
                player.buffImmune[i] = false;
            }
        }
    }
}