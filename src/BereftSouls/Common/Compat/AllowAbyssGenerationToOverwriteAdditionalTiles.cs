/* nope

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using CalamityMod.World;

using JetBrains.Annotations;

using Mono.Cecil.Cil;

using MonoMod.Cil;
using MonoMod.RuntimeDetour;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ThoriumMod.Tiles;

namespace BereftSouls.Common.Compat;

/// <summary>
///     Patches Abyss generation to overwrite additional tiles we want to allow.
///     <br />
///     By default, it only overwrites vanilla tiles.
/// </summary>
[UsedImplicitly(ImplicitUseKindFlags.InstantiatedWithFixedConstructorSignature)]
internal sealed class AllowAbyssGenerationToOverwriteAdditionalTiles : HookSystem
{
    private static readonly Lazy<int[]> tiles = new(
        static () =>
        [
            ModContent.TileType<SmoothCoal>(),
            ModContent.TileType<LifeQuartz>(),
            ModContent.TileType<ThoriumOre>(),
            ModContent.TileType<LodeStone>(),
            ModContent.TileType<ValadiumChunk>(),
            ModContent.TileType<IllumiteChunk>(),
            ModContent.TileType<Aquamarine>(),
            ModContent.TileType<Opal>(),
        ]
    );

    public override void Load()
    {
        base.Load();

        AddHook(
            new ILHook(
                typeof(Abyss).GetMethod(nameof(Abyss.PlaceAbyss), BindingFlags.Public | BindingFlags.Static)!,
                PlaceAyss_ModifyConvertCondition
            )
        );
    }

    private static void PlaceAyss_ModifyConvertCondition(ILContext il)
    {
        var c = new ILCursor(il);

        // Jump into the condition we want to modify.
        c.GotoNext(MoveType.After, x => x.MatchLdsfld<TileID>(nameof(TileID.Count)));

        // Find what local the tile is stored in.
        var tileIndex = -1;
        c.GotoNext(MoveType.After, x => x.MatchLdloca(out tileIndex));
        Debug.Assert(tileIndex is not -1);

        // Find where the flag is then set; since this is computing a condition,
        // no locals should be set before this within the block.
        var flagIndex = -1;
        c.GotoNext(MoveType.After, x => x.MatchStloc(out flagIndex));
        Debug.Assert(flagIndex is not -1);

        // Since we jump to after it's set, we can just emit our own conditions.
        c.Emit(OpCodes.Ldloca, tileIndex); // Push tile to stack.
        c.Emit(OpCodes.Ldloc,  flagIndex); // Push result of condition to stack.
        c.EmitDelegate(
            (ref Tile tile, bool condition) => condition || AllowTileToBeOverwritten(tile)
        );
        c.Emit(OpCodes.Stloc, flagIndex); // Store result of condition.
    }

    private static bool AllowTileToBeOverwritten(Tile tile)
    {
        return tiles.Value.Contains(tile.TileType);
    }
}
*/