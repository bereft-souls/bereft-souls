# Recipe Building
tPackBuilder adds support for creating new recipes utilizing existing items via very simple JSON syntax.

All you need to do is add a `.recipebuilder.json` file to your mod's folder, add the required data, and tPackBuilder handles the rest!

## Pre-requisites

While this is not technically required, it is recommended to have a competent text editor to assist you in building your files.

The recommended editor is [Notepad++](https://notepad-plus-plus.org/), as it is lightweight, fast, and relatively simple, while still providing enough useful tools to easily make your syntax nice and readable.

Alternatively, the Visual Studio text editor works fine as well. However, be warned that Visual Studio may try to give you warnings about your file's formatting, even if the file is actually formatted correctly. As long as you're following the documentation specified below, you'll be fine.

If you really wanted to, you could also build all of your recipes from the default Notepad application. This is not recommended, as Notepad does not contain useful features like auto-filling end brackets or quotes, but if you really prefer it, it will work fine.

***
## Building your recipe

tPackBuilder will search your mod's files for any `.recipebuilder.json` files. Each of these files represents a single recipe addition.

You can add multiple `.recipebuilder.json` files to your mod's folder and each one will be created individually.

***
### Walkthrough

This section will act as a step-by-step guide to building your first recipe via tPackBuilder.

To get started, lets create a new recipe for the Star Wrath that uses the Starfury and 10 luminite bars at a hardmode anvil.

First, add a file to your mod's folder and rename it to `starwrath.recipebuilder.json`. The naming for this file doesn't matter to tPackBuilder, only that it ends with `.recipemod.json` - but we're going to call it `starwrath` to make it clear what this recipe is for.

IMAGEEEEEEEEEEEEEEEEEEEEEEEE

Then, open up this file in your preferred text editor. This guide will be using Notepad++, as is recommended in the top section. This file should be empty by default.

Start by adding a set of curly braces to your file. All of your recipe's data will be filled into the braces. This is the default structure for .json objects.

IMAGEEEEEEEEEEEEEEEEEEEEEEEE

Now we're going to begin actually filling in our recipe's contents. Recipes are broken down into 4 components:
- Result
- Ingredient(s)
- Group Ingredient(s)
- Tile(s)

"Result" is the only part of the recipe that is 100% required. The result is... well, the result, that you want the recipe to result in creating.

All other fields are optional and act as requirements for your recipe. Ingredients are item requirements for your recipe, and group ingredients are "item group" requirements. Think like "Any Iron Bar". Tiles are the tiles the player must be nearby in order to craft the recipe.

### Setup

You can begin setting up those parts like so:

IMAGEEEEEEEEEEEEEEEEEEEEEEEE

