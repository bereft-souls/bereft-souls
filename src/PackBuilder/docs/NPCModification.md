# NPC Modification

tPackBuilder adds support for dynamically modifying aspects of NPCs, such as health, defense, damage, and more.

All you need to do is add a `.npcmod.json` file to your mod's folder, add the required data, and tPackBuilder handles the rest!

> Quick link to [avilable conditions/changes](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/RecipeModification.md) at the bottom.

## Pre-requisites

While this is not technically required, it is recommended to have a competent text editor to assist you in building your files.

The recommended editor is [Notepad++](https://notepad-plus-plus.org/), as it is lightweight, fast, and relatively simple, while still providing enough useful tools to easily make your syntax nice and readable.

Alternatively, the Visual Studio text editor works fine as well. However, be warned that Visual Studio may try to give you warnings about your file's formatting, even if the file is actually formatted correctly. As long as you're following the documentation specified below, you'll be fine.

If you really wanted to, you could also build all of your modifications from the default Notepad application. This is not recommended, as Notepad does not contain useful features like auto-filling end brackets or quotes, but if you really prefer it, it will work fine.

***

## Building and configuring your modifications
tPackBuilder will search your mod's files for any `.npcmod.json` files. Each of these files acts as a sort of "rule", which defines a set of changes you want to make to a given NPC.

You can add multiple `.npcmod.json` files to your mod's folder and each one will be applied individually.

***

### Walkthrough
> This section is a step-by-step guide to setting up your first NPC modification, and a breakdown of how modifications are formatted. If you want to skip straight to see what options are available, jump to the [documentation](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/NPCModification.md#available-changes) at the bottom of this file.

To get started, lets create a modification that buffs basic slimes to have 100 health and 100 defense.

First, add a file to your mod's folder and rename it to `slime.npcmod.json`. The naming for this file doesn't matter to tPackBuilder, only that it ends with `.npcmod.json` - but we're going to call it `slime` to make it clear what this modification is for.

![image](https://github.com/user-attachments/assets/d73bb3db-6f70-4820-8d01-c49feab2258c)

Then, open up this file in your preferred text editor. This guide will be using Notepad++, as is recommended in the top section. This file should be empty by default.

Start by adding a set of curly braces to your file. All of your modification's data will be filled into the braces. This is the default structure for .json objects.

![image](https://github.com/user-attachments/assets/d6662f90-45b6-480c-8f3a-e84878212021)

Now we're going to begin actually filling in our modification's data. NPC mods are broken down into 2 parts:
- NPC
- Changes

"NPC" is going to be the NPC(s) that you want to actually apply your listed changes to, and "Changes" is... the changes.

### Setup

You can begin setting up those parts like so:

![image](https://github.com/user-attachments/assets/2a9119ce-75b7-4e97-b21a-c08a09c06564)

### NPC

Filling in the NPC portion of the modification is very simple and self-explanatory. Simply enter the name of the internal name of the NPC you want to modify, prefixed with the mod it is from and a `/`.

In this case, since the NPC is from vanilla, the mod is simply going to be `Terraria`.

![image](https://github.com/user-attachments/assets/8e8206cd-431e-4e09-aab6-1a2da5966773)

If you want these changes to apply to multiple NPCs, you can add the "NPC" field multiple times.

![image](https://github.com/user-attachments/assets/d2bdb308-a99a-4dec-93d2-468b8cf96af6)

### Changes

This section is slightly more complex. There are a number of changes available for you to make to an NPC. Your first step is going to be figuring out what mod controls the changes you want to implement.

For example: health, defense, damage, and a number of others are all controlled and implemented by vanilla. However, damage reduction (DR) is controlled by the Calamity Mod. Most changes you will make will be to vanilla properties, but occasionally you will need to change properties from another mod.

Start by adding a section for the mod controlling the changes you want to change. Since we are only changing defense and damage, we only need a vanilla section. And remember that when something is from vanilla, we denote that by using `Terraria` as the mod name.

![image](https://github.com/user-attachments/assets/f3dc6850-c653-4537-8551-0eff1aa6954f)

From here, we can start listing off our changes. When you want to change a value, you have 3 options:
- Write a new value. This will assign the property to this new value.
- Write a value prefixed with a `+`. This will increase the already in place value by your specified amount.
- Write a value prefixed with a `-`. This will decrease the already in place value by your specified amount.
- Write a value prefixed with a `x`. This will multiply the already in place value by your specified amount.
> Note that some fields expect integers to be given as values. If you use decimals in these instances, whether it be setting the value directly or by performing an operation, the resulting numbers will be rounded towards 0.

![image](https://github.com/user-attachments/assets/952a26ff-6b8d-409e-8893-205938dcf234)

If we wanted to buff the NPC's damage by 10 points (ie. increase it by 10 points, not set it to 10), we could do this:

![image](https://github.com/user-attachments/assets/a5ed443c-44e2-4cbd-96f8-85829b1a653d)

And lastly, if we wanted to change the NPC's damage reduction in Calamity, we can do so like this:
> Note this change will only work if the Calamity Mod is enabled.

![image](https://github.com/user-attachments/assets/54ee2e58-fce8-4df5-bf0b-6bb460f41b43)

And just like that, we're done! If you head into the game and summon a slime, you should see it has the increased stats.

![image](https://github.com/user-attachments/assets/2965b896-5c08-4930-bb5e-f355861c8a92)

A full list of available changes and what value you should assign them can be found below. You can mix and match as many changes as you like - just make sure to follow the syntax above! Happy modpacking!

***

## Available Changes

### Vanilla (Terraria)
| Change Name | Description | Acceptable Values | Example |
| ----------- | ----------- | ----------------- | ------- |
| `Damage` | The damage this NPC deals. | Positive integers | ![image](https://github.com/user-attachments/assets/6d255d2c-e6a9-4a6c-b1f7-3bb5fa74b4b4) |
| `Defense` | The defense the NPC has. | Positive integers | ![image](https://github.com/user-attachments/assets/2571f6df-e3ab-4ae3-82cb-2e5ea398d0eb) |
| `Health` | `The NPC's maximum health. | Positive integers | ![image](https://github.com/user-attachments/assets/aea09a00-1188-431a-ac9b-94c2519530e9) |
| `KnockbackScaling` | The amount of knockback this NPC takes. | Decimal from 0-1<br/>(0 is no knockback, 1 is full knockback) | ![image](https://github.com/user-attachments/assets/74821aed-a80e-4f2c-af57-81a8229955e1) |
| `NPCSlots` | The number of NPC slots this NPC takes up (for the mob cap). | Positive integers | ![image](https://github.com/user-attachments/assets/2bce356c-8235-429e-8f07-10dd661b43dd) |

### Calamity Mod (CalamityMod)
| Change Name | Description | Acceptable Values | Example |
| ----------- | ----------- | ----------------- | ------- |
| DamageReduction | The amount by which incoming damage is reduced for this NPC. | Positive decimals | ![image](https://github.com/user-attachments/assets/5d7e803c-3a44-4e9f-aaf4-75560cc1babe) |

If there are any changes you would like to see support added for, whether it be from Vanilla or other mods, reach out to @nycro on Discord!
