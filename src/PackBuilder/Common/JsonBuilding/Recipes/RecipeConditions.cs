using PackBuilder.Common.JsonBuilding.Recipes.Conditions;
using System.Collections.Generic;
using System.Linq;
using Terraria;

namespace PackBuilder.Common.JsonBuilding.Recipes;

// The condition(s) needing to be met in order for this mod to activate.
// If no conditions are specified, this mod will activate on ALL recipes.

internal class RecipeConditions
{
    public List<IRecipeCondition> Conditions = [];

    // All of these are available as set only properties so that the json parser
    // can continually build a list by specifying the same property multiple times.
    //
    // Although there may be better ways to do this for strictly programming, doing it
    // this way creates the cleaniest, most intuitive, and easiest implementation
    // for creating json files.

    public CreatesResult CreatesResult { set => Conditions.Add(value); }
    public RequiresIngredient RequiresIngredient { set => Conditions.Add(value); }
    public RequiresRecipeGroup RequiresRecipeGroup { set => Conditions.Add(value); }
    public RequiresTile RequiresTile { set => Conditions.Add(value); }

    /// <summary>
    /// Determines whether this <see cref="RecipeConditions"/> set applies to a given recipe.
    /// </summary>
    public bool AppliesTo(Recipe recipe, RecipeCriteria criteria)
    {
        if (criteria == RecipeCriteria.Any)
            return Conditions.Any(c => c.AppliesTo(recipe));

        return Conditions.All(c => c.AppliesTo(recipe));
    }
}
