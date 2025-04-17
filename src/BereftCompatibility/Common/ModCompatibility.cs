using System.Diagnostics.CodeAnalysis;

using Terraria.ModLoader;

namespace BereftCompatibility.Common;

/// <summary>
///     Common mod compatibility helpers.
/// </summary>
internal static class ModCompatibility
{
    // Check if a mod is in Fargo's Souls DLC's ModCompatibility before adding
    // it here!

#region Type system abuse
    public interface IModRef
    {
        static abstract string Name { get; }
    }

    // ReSharper disable StaticMemberInGenericType - Trust me.  Intentional.
    public abstract class ModRef<T> where T : IModRef
    {
        public static bool Loaded { get; }

        [MemberNotNullWhen(true, nameof(Loaded))]
        public static Mod? Mod { get; }

        static ModRef()
        {
            Loaded = ModLoader.TryGetMod(T.Name, out var mod);
            Mod    = mod;
        }
    }
    // ReSharper restore StaticMemberInGenericType
#endregion

    public sealed class Sots : ModRef<Sots>, IModRef
    {
        public static string Name => "SOTS";
    }

    public class BossChecklist : ModSystem
    {
        public override void PostSetupContent()
        {
            // TODO: ?
        }
    }
}