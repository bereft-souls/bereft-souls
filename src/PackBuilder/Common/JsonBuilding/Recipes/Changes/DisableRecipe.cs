using Terraria;

namespace PackBuilder.Common.JsonBuilding.Recipes.Changes
{
    internal class DisableRecipe : IRecipeChange
    {
        public required bool Disabled;

        public void ApplyTo(Recipe recipe) => recipe.SetDisabled(Disabled);
    }
}
