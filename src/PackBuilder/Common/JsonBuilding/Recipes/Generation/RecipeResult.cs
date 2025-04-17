using Terraria;

namespace PackBuilder.Common.JsonBuilding.Recipes.Generation
{
    internal class RecipeResult
    {
        public required string Item;

        public int Count = 1;

        public void AddTo(Recipe recipe)
        {
            recipe.createItem.SetDefaults(GetItem(Item), false);
            recipe.createItem.stack = Count;
        }
    }
}
