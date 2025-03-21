﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PackBuilder.Core.Utils
{
    internal static partial class ModUtils
    {
        /// <summary>
        /// Splits a path to a given mod content file entry into its respective mod name and content name.
        /// </summary>
        public static void SplitModContent(string modContent, out string mod, out string content)
        {
            var split = modContent.Split('/');
            mod = split[0];
            content = split[1];
        }

        /// <summary>
        /// Gets the ID for an npc based on its content path, accounting for both vanilla and modded entries.
        /// </summary>
        public static int GetNPC(string npc)
        {
            SplitModContent(npc, out var mod, out var name);

            try
            {
                if (mod == "Terraria")
                    return (short)typeof(NPCID).GetField(name).GetRawConstantValue();

                return ModContent.Find<ModNPC>(mod, name).Type;
            }
            catch
            {
                throw new ArgumentException($"NPC type \"{npc}\" not found!", nameof(npc));
            }
        }

        /// <summary>
        /// Gets the ID for an item based on its content path, accounting for both vanilla and modded entries.
        /// </summary>
        public static int GetItem(string item)
        {
            SplitModContent(item, out var mod, out var name);

            try
            {
                if (mod == "Terraria")
                    return (short)typeof(ItemID).GetField(name)!.GetRawConstantValue()!;

                return ModContent.Find<ModItem>(mod, name).Type;
            }
            catch
            {
                throw new ArgumentException($"Item type \"{item}\" not found!", nameof(item));
            }
        }

        /// <summary>
        /// Gets the ID for a projectile based on its content path, accounting for both vanilla and modded entries.
        /// </summary>
        /// <param name="projectile"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetProjectile(string projectile)
        {
            SplitModContent(projectile, out var mod, out var name);

            try
            {
                if (mod == "Terraria")
                    return (short)typeof(ProjectileID).GetField(name)!.GetRawConstantValue()!;

                return ModContent.Find<ModProjectile>(mod, name).Type;
            }
            catch
            {
                throw new ArgumentException($"Projectile type \"{projectile}\" not found!", nameof(projectile));
            }
        }

        /// <summary>
        /// Gets the ID for a tile based on its content path, accounting for both vanilla and modded entries.
        /// </summary>
        public static int GetTile(string tile)
        {
            SplitModContent(tile, out var mod, out var name);

            try
            {
                if (mod == "Terraria")
                    return (ushort)typeof(TileID).GetField(name).GetRawConstantValue();

                return ModContent.Find<ModTile>(mod, name).Type;
            }
            catch
            {
                throw new ArgumentException($"Tyle type \"{tile}\" not found!", nameof(tile));
            }
        }

        /// <summary>
        /// Gets the ID for a recipe group based on its specified name.
        /// </summary>
        public static int GetRecipeGroup(string group)
        {
            if (!RecipeGroup.recipeGroupIDs.TryGetValue(group, out int id))
                throw new ArgumentException($"Recipe group \"{group}\" not found!", nameof(group));

            return id;
        }
    }
}
