using BereftSouls.Common;
using JetBrains.Annotations;

using Terraria.ModLoader;

namespace BereftSouls;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
public sealed class BsMod : Mod
{
    internal static BsMod Instance;
    public override void Load()
    {
        ModCompatibility.BossChecklist.AdjustValues();
    }
}