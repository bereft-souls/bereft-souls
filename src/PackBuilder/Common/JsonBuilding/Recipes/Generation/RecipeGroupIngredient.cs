using Terraria;

namespace PackBuilder.Common.JsonBuilding.Recipes.Generation
{
    internal class RecipeGroupIngredient
    {
        public required string Group;

        public int Count = 1;

        public void AddTo(Recipe recipe) => recipe.AddRecipeGroup(GetRecipeGroup(Group), Count);
    }
}
