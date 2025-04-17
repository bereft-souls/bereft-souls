using PackBuilder.Common.JsonBuilding.Recipes.Generation;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace PackBuilder.Common.JsonBuilding.Recipes
{
    internal class RecipeBuilder
    {
        public List<RecipeIngredient> Ingredients = [];
        public List<RecipeGroupIngredient> Groups = [];
        public List<string> Tiles = [];

        public required RecipeResult Result { get; set; }

        public RecipeIngredient Ingredient { set => Ingredients.Add(value); }

        public string Tile { set => Tiles.Add(value); }

        public RecipeGroupIngredient GroupIngredient { set => Groups.Add(value); }

        public void Build(Mod sourceMod)
        {
            var recipe = NewRecipe(sourceMod);

            Result.AddTo(recipe);

            foreach (var ingredient in Ingredients)
                ingredient.AddTo(recipe);

            foreach (var group in Groups)
                group.AddTo(recipe);

            foreach (var tile in Tiles)
                recipe.AddTile(GetTile(tile));

            recipe.Register();
        }
    }
}
