using Terraria;

namespace PackBuilder.Common.JsonBuilding.Recipes.Generation
{
    internal class RecipeResult
    {
        public required string Item;

        public int Count = 1;

        public Recipe CreateRecipe() => Recipe.Create(GetItem(Item), Count);
    }
}
