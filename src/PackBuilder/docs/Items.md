# Item Modification

tPackBuilder adds support for dynamically modifying aspects of items, such as damage, use time, granted stats for accessories, and more.

All you need to do is add a `.itemmod.json` file to your mod's folder, add the required data, and tPackBuilder handles the rest!

> Quick link to [avilable conditions/changes](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/NPCs.md#available-changes) at the bottom.

## Pre-requisites

While this is not technically required, it is recommended to have a competent text editor to assist you in building your files.

The recommended editor is [Notepad++](https://notepad-plus-plus.org/), as it is lightweight, fast, and relatively simple, while still providing enough useful tools to easily make your syntax nice and readable.

Alternatively, the Visual Studio text editor works fine as well. However, be warned that Visual Studio may try to give you warnings about your file's formatting, even if the file is actually formatted correctly. As long as you're following the documentation specified below, you'll be fine.

If you really wanted to, you could also build all of your recipes from the default Notepad application. This is not recommended, as Notepad does not contain useful features like auto-filling end brackets or quotes, but if you really prefer it, it will work fine.

***

## Building and configuring your modifications
tPackBuilder will search your mod's files for any `.itemmod.json` files. Each of these files acts as a sort of "rule", which defines a set of changes you want to make to a given item.

You can add multiple `.itemmod.json` files to your mod's folder and each one will be applied individually.

***

### Walkthrough
> This section is a step-by-step guide to setting up your first item modification, and a breakdown of how modifications are formatted. If you want to skip straight to see what options are available, jump to the [documentation](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/NPCs.md#available-changes) at the bottom of this file.

To get started, lets create a modification that buffs the cooper shortsword to have 100 damage and a use time of 3 frames..

First, add a file to your mod's folder and rename it to `coppershortsowrd.itemmod.json`. The naming for this file doesn't matter to tPackBuilder, only that it ends with `.itemmod.json` - but we're going to call it `coppershortsword` to make it clear what this modification is for.

![image](https://github.com/user-attachments/assets/d73bb3db-6f70-4820-8d01-c49feab2258c)

Then, open up this file in your preferred text editor. This guide will be using Notepad++, as is recommended in the top section. This file should be empty by default.

Start by adding a set of curly braces to your file. All of your modification's data will be filled into the braces. This is the default structure for .json objects.

![image](https://github.com/user-attachments/assets/d6662f90-45b6-480c-8f3a-e84878212021)

Now we're going to begin actually filling in our modification's data. Item mods are broken down into 2 parts:
- Item
- Changes

"Item" is going to be the item(s) that you want to actually apply your listed changes to, and "Changes" is... the changes.

### Setup

You can begin setting up those parts like so:

![image](https://github.com/user-attachments/assets/2a9119ce-75b7-4e97-b21a-c08a09c06564)

### Item

Filling in the Item portion of the modification is very simple and self-explanatory. Simply enter the internal name of the item you want to modify, prefixed with the mod it is from and a `/`.

In this case, since the item is from vanilla, the mod is simply going to be `Terraria`.

![image](https://github.com/user-attachments/assets/8e8206cd-431e-4e09-aab6-1a2da5966773)

If you want these changes to apply to multiple items, you can add the "Item" field multiple times.

![image](https://github.com/user-attachments/assets/d2bdb308-a99a-4dec-93d2-468b8cf96af6)

### Changes

This section is slightly more complex. There are a number of changes available for you to make to an item. Your first step is going to be figuring out what mod controls the changes you want to implement.

For example: damage, crit chance, use time, and a number of others are all controlled and implemented by vanilla. However, "charge" (Draedon's arsenal weapon charging) is controlled by the Calamity Mod. Most changes you will make will be to vanilla properties, but occasionally you will need to change properties from another mod.

Start by adding a section for the mod controlling the changes you want to change. Since we are only changing damage and use time, we only need a vanilla section. And remember that when something is from vanilla, we denote that by using `Terraria` as the mod name.

![image](https://github.com/user-attachments/assets/f3dc6850-c653-4537-8551-0eff1aa6954f)

From here, we can start listing off our changes. When you want to change a value, you have 3 options:
- Write a new value. This will assign the property to this new value.
- Write a value prefixed with a `+`. This will increase the already in place value by your specified amount.
- Write a value prefixed with a `-`. This will decrease the already in place value by your specified amount.
- Write a value prefixed with a `x`. This will multiply the already in place value by your specified amount.
> Note that some fields expect integers to be given as values. If you use decimals in these instances, whether it be setting the value directly or by performing an operation, the resulting numbers will be rounded towards 0.

![image](https://github.com/user-attachments/assets/952a26ff-6b8d-409e-8893-205938dcf234)

If we wanted to buff the item's damage by 10 points (ie. increase it by 10 points, not set it to 10), we could do this:

![image](https://github.com/user-attachments/assets/a5ed443c-44e2-4cbd-96f8-85829b1a653d)

And lastly, if we wanted to change the item's charge consumption in Calamity, we can do so like this:
> Note this change will only work if the Calamity Mod is enabled.

![image](https://github.com/user-attachments/assets/54ee2e58-fce8-4df5-bf0b-6bb460f41b43)

And just like that, we're done! If you head into the game and spawn a copper shortsword, you should see it has the increased stats.

![image](https://github.com/user-attachments/assets/2965b896-5c08-4930-bb5e-f355861c8a92)

A full list of available changes and what value you should assign them can be found below. You can mix and match as many changes as you like - just make sure to follow the syntax above! Happy modpacking!

***

## Available Changes

### Vanilla (Terraria)
| Change Name | Description | Acceptable Values | Example |
| ----------- | ----------- | ----------------- | ------- |
| `Damage` | The damage this item deals. | Positive integers | IMAGE |
| `CritRate` | The chance for this item to crit. | Positive integers | IMAGE |
| `Defense` | The defense this item gives when equipped | Positive integers | IMAGE |
| `HammerPower` | This item's hammer power. | Positive integers | IMAGE |
| `PickaxePower` | This item's pickaxe power. | Positive integers | IMAGE |
| `AxePower` | This item's axe power. | Positive integers | IMAGE |
| `Healing` | The health this item restores when consumed. | Positive integers | IMAGE |
| `ManaRestoration` | The mana this item restores when consumed. | Positive integers | IMAGE |
| `Knockback` | This item's knockback. | Positive integers | IMAGE |
| `LifeRegen` | The regeneration this item gives when equipped. | Positive integers | IMAGE |
| `ManaCost` | The amount of mana that this item consumes when used. | Positive integers | IMAGE |
| `ShootSpeed` | How fast the projectiles this item shoots will travel. | Positive integers | IMAGE |
| `UseTime` | The number of frames this item takes before it can be used again. | Positive integers | IMAGE |

### Calamity Mod (CalamityMod)
| Change Name | Description | Acceptable Values | Example |
| ----------- | ----------- | ----------------- | ------- |
| MaxCharge | The maximum charge value of this item. | Positive decimals | ![image](https://github.com/user-attachments/assets/5d7e803c-3a44-4e9f-aaf4-75560cc1babe) |
| ChargePerUse | The amount of charge that is consumed every time the item is used. | Positive decimals | ![image](https://github.com/user-attachments/assets/5d7e803c-3a44-4e9f-aaf4-75560cc1babe) |
| ChargePerAltUse | The amount of charge that is consumed every time this item is used with right click.<br/>In most cases this does not need to be set and will default to the value of `ChargePerUse`. | Positive decimals | ![image](https://github.com/user-attachments/assets/5d7e803c-3a44-4e9f-aaf4-75560cc1babe) |

If there are any changes you would like to see support added for, whether it be from Vanilla or other mods, reach out to @nycro on Discord!
