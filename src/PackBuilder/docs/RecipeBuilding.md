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

To get started, lets create a new recipe for the Magic Mirror that uses 5 glass, 1 mana crystal, and 10 "any iron bar" at an anvil.

First, add a file to your mod's folder and rename it to `magicmirror.recipebuilder.json`. The naming for this file doesn't matter to tPackBuilder, only that it ends with `.recipemod.json` - but we're going to call it `magicmirror` to make it clear what this recipe is for.

![image](https://github.com/user-attachments/assets/eab551c8-ba4e-415e-928d-da458df6d916)

Then, open up this file in your preferred text editor. This guide will be using Notepad++, as is recommended in the top section. This file should be empty by default.

Start by adding a set of curly braces to your file. All of your recipe's data will be filled into the braces. This is the default structure for .json objects.

![image](https://github.com/user-attachments/assets/87d2a1c5-2565-4aa3-80c5-5b705c694b92)

Now we're going to begin actually filling in our recipe's contents. Recipes are broken down into 4 components:
- Result
- Ingredient(s)
- Group Ingredient(s)
- Tile(s)

"Result" is the only part of the recipe that is 100% required. The result is... well, the result, that you want the recipe to make in creating.

All other fields are optional and act as requirements for your recipe. Ingredients are item requirements for your recipe, and group ingredients are "item group" requirements. Think like "Any Iron Bar". Tiles are the tiles the player must be nearby in order to craft the recipe.

### Setup

You can begin setting up those parts like so:

![image](https://github.com/user-attachments/assets/12bbe751-73f6-431b-8021-b12fcd2b2caa)

Remember that since all the fields except for Result are optional, you can add and remove them as you please. You can add as many ingredients as you want, as many tiles as you want, or exclude them entirely. Since our recipe has 2 ingredients, 1 group ingredient, and 1 tile requirement, we've set up those as the fields for our json file.

Next, we want to begin filling in these fields. We can start with result. "Result" requires you to enter an item, and optionally allows you to enter an amount of that item to craft. If you do not enter an amount, it defaults to one. You can fill those fields like so:

![image](https://github.com/user-attachments/assets/238733f2-db47-4985-b180-bb86de24fd26)

Whenever you are specifying in-game content in your json files, you always list it as "ModName/ContentName". In this case, the Magic Mirror is actually from vanilla, so our "mod name" is going to just be Terraria.

Also remember that the "Count" field is not actually required. If left out, the recipe will craft 1 of your desired result. We've specified it directly here so you can see how to use the field, but for the rest of this tutorial, it will be ommitted.

Next, let's add our normal ingredients. We want 5 glass and 1 mana crystal. In the same way that you can ommit "Count" from "Result" to default to 1, you can omit "Count" from "Ingredient" to also default to one. Our fields would look like this:

![image](https://github.com/user-attachments/assets/5fb80c51-aaea-4526-8aa4-71e1a5c4d6a5)

Lastly, we want to add our group ingredients. Recipe groups are handled differently from items, as they do not have a "mod source" - they are universally used across mods. So we will not need to add a mod name to the beginning of the content. Additionally, where we used "Item" for our item type before, now we use "Group".

![image](https://github.com/user-attachments/assets/9702b48c-c2b0-4669-ad1d-1aa05f41eee9)

Our last step is going to be adding the tile. Since you don't need to specify a count for tiles, only the tile type, adding them is a lot simpler, and does not require extra braces.

![image](https://github.com/user-attachments/assets/06cf6314-9f5c-4296-90c4-fd875c195f02)

And just like that, we're done! If you head into the game and use the Recipe Browser mod, you should see our new recipe has appeared.

![image](https://github.com/user-attachments/assets/0234709a-dff9-469f-8bab-cbb197f95ff5)

A quick reference for each field type and the info they require can be found below. You can mix and match as many requirements as you like - just make sure to follow the syntax above! Happy modpacking!

***
Fields marked with `*` are required. Otherwise, they are optional. A description of what each field will do will be supplied next to each entry, as well as what a complete and formatted entry should look like.

| Requirement Name | Description | Fields | Example |
| -------------- | ----------- | ------ | ------- |
| `*Result` | The result that this recipe should create. | - `*Item`: The item the recipe creates.<br>- `Count`: How many of the item it creates. If left out, will default to 1 | ![image](https://github.com/user-attachments/assets/fddbe101-28f0-42dd-b12d-45389d3948aa) |
| `Ingredient` | An ingredient requirement for the recipe. | - `*Item`: The item the recipe requires.<br>- `Count`: How many of the item is required. If left out, will default to 1. | ![image](https://github.com/user-attachments/assets/ad5dedc4-3fb1-447e-a996-791ebbdd34b6) |
| `GroupIngredient` | An item group requirement for the recipe. | - `*Group`: The item group the recipe requires.<br>- `Count`: How many items in that group are required. If left out, will default to 1. | ![image](https://github.com/user-attachments/assets/62405299-ed14-45b2-93fb-4276c42d51d3) |
| `Tile` | A tile requirement for the recipe. | *This requirement takes in only 1 value - the tile that is required by this recipe. | ![image](https://github.com/user-attachments/assets/df0f5c7d-734a-45ae-953a-925ccdf5a636) |
