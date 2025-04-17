# Recipe Modification
tPackBuilder adds support for dynamically modifying recipes to add, remove, or change ingredients, results, or tiles for any recipe from any mod (or vanilla!) in the game.

All you need to do is add a `.recipemod.json` file to your mod's folder, add the required data, and tPackBuilder handles the rest!

> Quick link to [avilable conditions/changes](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/Recipes.md#available-conditionschanges) at the bottom.

## Pre-requisites

While this is not technically required, it is recommended to have a competent text editor to assist you in building your files.

The recommended editor is [Notepad++](https://notepad-plus-plus.org/), as it is lightweight, fast, and relatively simple, while still providing enough useful tools to easily make your syntax nice and readable.

Alternatively, the Visual Studio text editor works fine as well. However, be warned that Visual Studio may try to give you warnings about your file's formatting, even if the file is actually formatted correctly. As long as you're following the documentation specified below, you'll be fine.

If you really wanted to, you could also build all of your modifications from the default Notepad application. This is not recommended, as Notepad does not contain useful features like auto-filling end brackets or quotes, but if you really prefer it, it will work fine.

***
## Building and configuring your modifications

tPackBuilder will search your mod's files for any `.recipemod.json` files. Each of these files acts as a sort of "rule", which defines which recipes you want to change, and how you want to change them.

You can add multiple `.recipemod.json` files to your mod's folder and each one will be applied individually.

***
### Walkthrough

> This section is a step-by-step guide to setting up your first recipe modification, and a breakdown of how modifications are formatted. If you want to skip straight to see what options are available, jump to the [documentation](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/Recipes.md#available-conditionschanges) at the bottom of this file.

To get started, lets create a modification that adds 5 gel as a requirement to craft the Zenith.

First, add a file to your mod's folder and rename it to `zenith.recipemod.json`. The naming for this file doesn't matter to tPackBuilder, only that it ends with `.recipemod.json` - but we're going to call it `zenith` to make it clear what this modification is for.
 
![image](https://github.com/user-attachments/assets/c45711bf-2d1f-46d8-b892-b5bee150bd8c)

Then, open up this file in your preferred text editor. This guide will be using Notepad++, as is recommended in the top section. This file should be empty by default.

Start by adding a set of curly braces to your file. All of your modification's data will be filled into the braces. This is the default structure for .json objects.

![image](https://github.com/user-attachments/assets/a3fe704c-3f52-4efc-b2f7-c74fcc24e7f9)

Now we're going to begin actually filling in our modification's data. Recipe mods are broken down into 3 parts:
- Conditions
- Changes
- Criteria

Lets start with conditions. "Conditions" are a set of... well, conditions, that must be met in order for your modification to apply to a recipe. These conditions will be tested against every recipe in the game, and any recipes that meet the specified conditions will have the changes applied to them.

Secondly, "Changes" are... you guessed it, the changes you want to apply. You can supply the modification with multiple changes, and they will be applied in order based on the order you list them in the json file.

Lastly, there's criteria. This one is the most simple. If you have supplied multiple conditions, criteria defines how many of those conditions need to be met in order to apply. Criteria can *only* be either `"All"` or `"Any"`. `"All"` means your modification will only apply if ALL of your listed conditions are met. `"Any"` means your modification will apply if even one of your listed conditions is met. Pretty simple.
> Alternatively, if your modification only contains 1 condition anyways, you can omit the inclusion of "Criteria" as a field, and just include the condition and change(s). This tutorial will still include it for simplicity's sake.

### Setup

You can begin setting up those 3 parts like so:

![image](https://github.com/user-attachments/assets/bceb11ef-780f-427f-8ba5-f8299ca70a60)

### Conditions

Lets fill in our conditions first. We want our modification to apply to every recipe that results in crafting the Zenith. So lets add a condition that specifies the recipe must result in creating the Zenith item.

![image](https://github.com/user-attachments/assets/27f83723-b818-4ca6-adc6-f64427b92cb5)

The first thing you may notice is that we've specified the recipe must result in `"Terraria/Zenith"`. Whenever you are specifying in-game content in your json files, you always list it as `"ModName/ContentName"`. In this case, the Zenith is actually from vanilla, so our "mod name" is going to just be `Terraria`. But if we wanted to instead use, say, the Fabstaff from Calamity, we would use `"CalamityMod/Fabstaff"'`.

There are numerous available conditions you can use when creating recipe modifications, and each one has different data requirements to be filled out. For a full list of conditions and what kind of data they need, check the bottom of this page. If you want to add multiple conditions, you can do that like so:

![image](https://github.com/user-attachments/assets/c84e1f8b-57ee-466f-bc58-e00f77255b67)

> Note that each supplied condition is separated by a comma and uses its own additional set of curly braces.

### Changes

Now that we've filtered our modification to apply to every recipe that results in the Zenith, we can specify what changes we want to make. We want to add 5 gel as a required ingredient, and we can do that like so:

![image](https://github.com/user-attachments/assets/0562f8e9-94ab-496e-9ecc-f35bf54b32bf)

In the same way that you can add multiple conditions, you can also add multiple changes. Lets say we also want to add 5 stone as a requirement in addition to the 5 gel. We can do that like so:

![image](https://github.com/user-attachments/assets/fb4bf46b-4dea-48af-837c-fd32b031e5a6)

### Criteria

Now we have configured our modification to change every recipe that results in the Zenith by adding 5 gel as an item requirement. Congrats! We're almost there. As mentioned before, since this modification only contains one condition, we can technically remove the "Criteria" portion of the modification, and it will still work fine. But we're going to fill it in anyways for demonstration purposes. Even though it doesn't matter, let's just set it to "Any".

![image](https://github.com/user-attachments/assets/1b37fcd0-d27e-470a-97cb-7146f7cfd503)

And just like that, we're done! If you head into the game and check all recipes for the Zenith using the Recipe Browser mod, you should now see that they all have the added requirement of 5 gel.

![image](https://github.com/user-attachments/assets/b362b2df-7d7e-4180-95c9-44f1143664ac)

A full list of available conditions and changes, and what data they require to be filled out to function, can be found below. You can mix and match as many conditions and changes as you like - just make sure to follow the syntax above! Happy modpacking!

***

## Available Conditions/Changes

Fields marked with `*` are required. Otherwise, they are optional. A description of what each field will do will be supplied next to each entry, as well as what a complete and formatted entry should look like.

### Conditions

| Condition Name | Description | Fields | Example |
| -------------- | ----------- | ------ | ------- |
| `CreatesResult` | Filters only to recipes that create the specified result. | - `*Item`: The item the recipe creates.<br>- `Count`: How many of the item it creates. If left out, will apply to all recipes that create the item. | ![image](https://github.com/user-attachments/assets/ff63bb02-10d2-4c35-a145-e976b2b1c782) |
| `RequiresIngredient` | Filters only to recipes that require the specified item as an ingredient. | - `*Item`: The item the recipe requires.<br>- `Count`: How many of the item is required. If left out, will apply to all recipes that require this item. | ![image](https://github.com/user-attachments/assets/087634b5-61f9-4af8-a906-27ea0075fc9d) |
| `RequiresRecipeGroup` | Filters only to recipes that require the specified recipe group as an ingredient. | - `*Group`: The recipe group the recipe requires.<br>- `Count`: How many items in that group are required. If left out, will apply to all recipes that require this group. | ![image](https://github.com/user-attachments/assets/1d1e0ca2-cd57-47eb-b463-20da6a07d2a1) |
| `RequiresTile` | Filters only to recipes that require the being near the specified tile to craft. | - `*Tile`: The tile that is required by this recipe. | ![image](https://github.com/user-attachments/assets/24e6d3f5-e387-45b4-b492-1bb08e69c006) |
> Note: "Recipe Groups" are groups of items in which any are accepted as an ingredient. Think like "Any Iron Bar".

***
### Changes
#### "Add" Changes
| Change Name | Description | Fields | Example |
| ----------- | ----------- | ------ | ------- |
| `AddIngredient` | Adds an item as a required ingredient to all matched recipes. | - `*Item`: The item to add as an ingredient.<br>- `Count`: How many of the item should be required. If left out, will default to 1. | ![image](https://github.com/user-attachments/assets/6ae69970-78f2-426b-b0b9-9210a822e70c) |
| `AddRecipeGroup` | Adds a recipe group as a required ingredient to all matched recipes. | - `*Group`: The group to add as an ingredient<br>- `Count`: How many items from the group should be required. If left out, will default to 1. | ![image](https://github.com/user-attachments/assets/52d5422a-d6f2-4e8c-a260-0eb1c7a20a87) |
| `AddTile` | Adds a tile that is required to be near in order to craft to all matched recipes. | - `*Tile`: The tile to add as a requirement. | ![image](https://github.com/user-attachments/assets/9b5a7685-e8c7-4e26-9ee7-a9774184438d) |

#### "Remove" Changes
| Change Name | Description | Fields | Example |
| ----------- | ----------- | ------ | ------- |
| `RemoveIngredient` | Removes an item from the required ingredients of all matched recipes. | - `*Item`: The item to remove from the ingredients. | ![image](https://github.com/user-attachments/assets/95055686-72a2-444e-91f7-345e3c30e5e9) |
| `RemoveRecipeGroup` | Removes a recipe group from the required ingredients of all matched recipes. | - `*Group`: The recipe group to remove from the ingredients. | ![image](https://github.com/user-attachments/assets/1a067c0b-cf68-4a5d-9dd7-ab5ae8f63fb2) |
| `RemoveTile` | Removes a tile as requirement to be near in order to craft from all matched recipes. | - `*Tile`: The tile to remove as from the requirements. | ![image](https://github.com/user-attachments/assets/d56c47fb-5a62-4c73-915c-e94001855621) |

#### "Change" Changes
All of the below changes are sort of like an "Add" and "Remove" bundled into one. They allows you modify aspects about one given detail of a recipe (one ingredient, one tile, the result, etc.) such as item count or item type without need to remove and re-add the aspect.
| Change Name | Description | Fields | Example |
| ----------- | ----------- | ------ | ------- |
| `ChangeIngredient` | Changes an item ingredient in all matched recipes. | - `*Item`: The ingredient you want to change.<br>- `NewItem`: The item you want to replace the ingredient with. If left out, the ingredient will remain the same type of item.<br>- `NewCount`: The new amount of the item to be required. If left out, the amount of the item required will remain the same. | ![image](https://github.com/user-attachments/assets/a4d56c58-02b0-4943-813b-047e3acdd533) |
| `ChangeRecipeGroup` | Changes a recipe group ingredient in all matched recipes. | - `*Group`: The recipe group ingredient you want to change.<br>- `NewGroup`: The recipe group you want to replace the old recipe group ingredient with. If left out, the ingredient will remain the same group.<br>- `NewCount`: The new amount of the recipe group to be required. If left out, the amount of the group required will remain the same. | ![image](https://github.com/user-attachments/assets/ed26de3d-775f-4d32-8ae9-af089872690c) |
| `ChangeResult` | Changes the result of the recipe. | - `Item`: The new item you want the recipe to result in. If left out, the type of item the recipe creates will remain the same.<br>- `Count`: The new amount of the result you want the recipe to create. If left out, the amount of items the recipe creates will remain the same. | ![image](https://github.com/user-attachments/assets/74e1a834-dea4-4795-bd95-f74e201bafa2) |
| `ChangeTile` | Changes a nearby tile requirement to craft the recipe. | - `Tile`: The tile you want to change. If left out, all previously required tiles will be cleared out, and only the `NewTile` will be required.<br>- `*NewTile`: The new tile you want to recipe to require. | ![image](https://github.com/user-attachments/assets/6f98d81a-beca-46e1-92c1-19eeb017a5d6) |
