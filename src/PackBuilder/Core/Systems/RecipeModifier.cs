﻿using Newtonsoft.Json;
using PackBuilder.Common.JsonBuilding.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria.ModLoader;

namespace PackBuilder.Core.Systems
{
    internal class RecipeModifier : ModSystem
    {
        // Changes all of the loaded recipes based on provided criteria from Json files.
        public override void PostAddRecipes()
        {
            // Collects ALL .recipemod.json files from all mods into a list.
            Dictionary<string, byte[]> jsonEntries = [];

            foreach (Mod mod in ModLoader.Mods)
            {
                // An array of all .recipemod.json files from this specific mod.
                var files = (mod.GetFileNames() ?? []).Where(s => s.EndsWith(".recipemod.json", StringComparison.OrdinalIgnoreCase));

                // Adds the byte contents of each file to the list.
                foreach (var file in files)
                    jsonEntries.Add(file, mod.GetFileBytes(file));
            }

            foreach (var jsonEntry in jsonEntries)
            {
                PackBuilder.LoadingFile = jsonEntry.Key;

                // Convert the raw bytes into raw text.
                string rawJson = Encoding.Default.GetString(jsonEntry.Value);

                // Decode the json into a recipe mod.
                RecipeMod recipeMod = JsonConvert.DeserializeObject<RecipeMod>(rawJson, PackBuilder.JsonSettings)!;

                if (recipeMod.Conditions.Conditions.Count == 0)
                    throw new NoConditionsException();

                // Apply the recipe mod.
                recipeMod.Apply();

                PackBuilder.LoadingFile = null;
            }
        }
    }
}
