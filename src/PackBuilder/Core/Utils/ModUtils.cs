using System;
using System.Reflection;
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
                    return (short)(typeof(NPCID).GetField(name)?.GetRawConstantValue() ?? throw new Exception());

                return ModContent.Find<ModNPC>(mod, name).Type;
            }
            catch
            {
                throw new HideStackTraceException($"NPC type \"{npc}\" not found!");
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
                    return (short)(typeof(ItemID).GetField(name)?.GetRawConstantValue() ?? throw new Exception());

                return ModContent.Find<ModItem>(mod, name).Type;
            }
            catch
            {
                throw new HideStackTraceException($"Item type \"{item}\" not found!");
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
                    return (short)(typeof(ProjectileID).GetField(name)?.GetRawConstantValue() ?? throw new Exception());

                return ModContent.Find<ModProjectile>(mod, name).Type;
            }
            catch
            {
                throw new HideStackTraceException($"Projectile type \"{projectile}\" not found!");
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
                    return (ushort)(typeof(TileID).GetField(name)?.GetRawConstantValue() ?? throw new Exception());

                return ModContent.Find<ModTile>(mod, name).Type;
            }
            catch
            {
                throw new HideStackTraceException($"Tyle type \"{tile}\" not found!");
            }
        }

        /// <summary>
        /// Gets the ID for a recipe group based on its specified name.
        /// </summary>
        public static int GetRecipeGroup(string group)
        {
            if (!RecipeGroup.recipeGroupIDs.TryGetValue(group, out int id))
                throw new HideStackTraceException($"Recipe group \"{group}\" not found!");

            return id;
        }

        /// <summary>
        /// Creates a recipe from the specified mod.
        /// </summary>
        public static Recipe NewRecipe(Mod mod) => (Recipe)recipeConstructor.Invoke([mod]);
        private static readonly ConstructorInfo recipeConstructor = typeof(Recipe).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, [typeof(Mod)])!;

        public static void SetDisabled(this Recipe recipe, bool disabled) => disabledProperty.SetValue(recipe, disabled);
        private static readonly PropertyInfo disabledProperty = typeof(Recipe).GetProperty("Disabled", BindingFlags.Public | BindingFlags.Instance)!;
    }
}
