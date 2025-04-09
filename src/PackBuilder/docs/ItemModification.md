# Item Modification

tPackBuilder adds support for dynamically modifying aspects of items, such as damage, use time, granted stats for accessories, and more.

All you need to do is add a `.itemmod.json` file to your mod's folder, add the required data, and tPackBuilder handles the rest!

> Quick link to [avilable conditions/changes](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/ItemModification.md#available-changes) at the bottom.

## Pre-requisites

While this is not technically required, it is recommended to have a competent text editor to assist you in building your files.

The recommended editor is [Notepad++](https://notepad-plus-plus.org/), as it is lightweight, fast, and relatively simple, while still providing enough useful tools to easily make your syntax nice and readable.

Alternatively, the Visual Studio text editor works fine as well. However, be warned that Visual Studio may try to give you warnings about your file's formatting, even if the file is actually formatted correctly. As long as you're following the documentation specified below, you'll be fine.

If you really wanted to, you could also build all of your modifications from the default Notepad application. This is not recommended, as Notepad does not contain useful features like auto-filling end brackets or quotes, but if you really prefer it, it will work fine.

***

## Building and configuring your modifications
tPackBuilder will search your mod's files for any `.itemmod.json` files. Each of these files acts as a sort of "rule", which defines a set of changes you want to make to a given item.

You can add multiple `.itemmod.json` files to your mod's folder and each one will be applied individually.

***

### Walkthrough
> This section is a step-by-step guide to setting up your first item modification, and a breakdown of how modifications are formatted. If you want to skip straight to see what options are available, jump to the [documentation](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/ItemModification.md#available-changes) at the bottom of this file.

To get started, lets create a modification that buffs the Terrablade to have +100 damage and a use time that is 2 frames shorter.

First, add a file to your mod's folder and rename it to `terrablade.itemmod.json`. The naming for this file doesn't matter to tPackBuilder, only that it ends with `.itemmod.json` - but we're going to call it `terrablade` to make it clear what this modification is for.

![image](https://github.com/user-attachments/assets/10d9a0ed-1d37-45c4-9f10-847ac48f7a79)

Then, open up this file in your preferred text editor. This guide will be using Notepad++, as is recommended in the top section. This file should be empty by default.

Start by adding a set of curly braces to your file. All of your modification's data will be filled into the braces. This is the default structure for .json objects.

![image](https://github.com/user-attachments/assets/393ea366-0fbc-4d82-b499-d7cd0917bf02)

Now we're going to begin actually filling in our modification's data. Item mods are broken down into 2 parts:
- Item
- Changes

"Item" is going to be the item(s) that you want to actually apply your listed changes to, and "Changes" is... the changes.

### Setup

You can begin setting up those parts like so:

![image](https://github.com/user-attachments/assets/6ca88a44-10cc-48fa-ac48-92e65a13058a)

### Item

Filling in the Item portion of the modification is very simple and self-explanatory. Simply enter the internal name of the item you want to modify, prefixed with the mod it is from and a `/`.

In this case, since the item is from vanilla, the mod is simply going to be `Terraria`.

![image](https://github.com/user-attachments/assets/4ecb0f41-e8bf-4ff4-b31a-a3e60a8e8a65)

If you want these changes to apply to multiple items, you can add the "Item" field multiple times.

![image](https://github.com/user-attachments/assets/c9fb23dc-7548-4276-a76c-6ec1e76248ca)

### Changes

This section is slightly more complex. There are a number of changes available for you to make to an item. Your first step is going to be figuring out what mod controls the changes you want to implement.

For example: damage, crit chance, use time, and a number of others are all controlled and implemented by vanilla. However, "charge" (Draedon's arsenal weapon charging) is controlled by the Calamity Mod. Most changes you will make will be to vanilla properties, but occasionally you will need to change properties from another mod.

Start by adding a section for the mod controlling the changes you want to change. Since we are only changing damage and use time, we only need a vanilla section. And remember that when something is from vanilla, we denote that by using `Terraria` as the mod name.

![image](https://github.com/user-attachments/assets/8cc58951-6984-433e-ae10-9fda86d6175d)

From here, we can start listing off our changes. When you want to change a value, you have 3 options:
- Write a new value. This will assign the property to this new value.
- Write a value prefixed with a `+`. This will increase the already in place value by your specified amount.
- Write a value prefixed with a `-`. This will decrease the already in place value by your specified amount.
- Write a value prefixed with a `x`. This will multiply the already in place value by your specified amount.
> Note that some fields expect integers to be given as values. If you use decimals in these instances, whether it be setting the value directly or by performing an operation, the resulting numbers will be rounded towards 0.

![image](https://github.com/user-attachments/assets/aade5958-9308-4703-93b2-992efae0ba6f)

If we wanted to set the item's damage to 100 (not add 100 to it, set it to exactly 100), we could do this:

![image](https://github.com/user-attachments/assets/1483339c-8c1e-4e0b-8eb9-741969274958)

And just like that, we're done! If you head into the game and spawn a Terrablade, you should see it has the increased stats.

![image](https://github.com/user-attachments/assets/41d17956-42eb-416b-9ece-b735b5ed9a99) ![image](https://github.com/user-attachments/assets/de221786-f68d-4f77-a06b-e1b1e121cb22)


A full list of available changes and what value you should assign them can be found below. You can mix and match as many changes as you like - just make sure to follow the syntax above! Happy modpacking!

***

## Available Changes

### Vanilla (Terraria)
| Change Name | Description | Acceptable Values | Example |
| ----------- | ----------- | ----------------- | ------- |
| `Damage` | The damage this item deals. | Positive integers | ![image](https://github.com/user-attachments/assets/8bc24131-1eb6-4d71-9223-475e3ba26a00) |
| `CritRate` | The chance for this item to crit. | Positive integers | ![image](https://github.com/user-attachments/assets/7ebffefa-839b-4261-8b76-31e44eaed7ca) |
| `Defense` | The defense this item gives when equipped | Positive integers | ![image](https://github.com/user-attachments/assets/dce23677-8770-4e0a-8c51-873f7f8e17e5) |
| `HammerPower` | This item's hammer power. | Positive integers | ![image](https://github.com/user-attachments/assets/111f7655-4d56-4bd7-8c14-868041a9bbdc) |
| `PickaxePower` | This item's pickaxe power. | Positive integers | ![image](https://github.com/user-attachments/assets/9b6f2828-c46b-4206-9594-1d02cb6c4b64) |
| `AxePower` | This item's axe power. | Positive integers | ![image](https://github.com/user-attachments/assets/dbc92290-db19-48bc-9e88-a98256f53884) |
| `Healing` | The health this item restores when consumed. | Positive integers | ![image](https://github.com/user-attachments/assets/91e78ca9-9759-4001-8677-f189ed9e2b68) |
| `ManaRestoration` | The mana this item restores when consumed. | Positive integers | ![image](https://github.com/user-attachments/assets/7de0eedc-ce1d-4cfd-a28b-0acc71820b69) |
| `Knockback` | This item's knockback. | Positive decimals | ![image](https://github.com/user-attachments/assets/60703a4f-7847-44a8-8247-7df3dd59eb41) |
| `LifeRegen` | The regeneration this item gives when equipped. | Positive integers | ![image](https://github.com/user-attachments/assets/70a13e3f-d9a8-4042-b649-a9dab610e243) |
| `ManaCost` | The amount of mana that this item consumes when used. | Positive integers | ![image](https://github.com/user-attachments/assets/80dc7767-0846-45cb-9653-d824b8637aa6) |
| `ShootSpeed` | How fast the projectiles this item shoots will travel. | Positive integers | ![image](https://github.com/user-attachments/assets/77f97b42-64ce-42da-bbbd-e6789c417c21) |
| `UseTime` | The number of frames this item takes before it can be used again. | Positive integers | ![image](https://github.com/user-attachments/assets/ff08d86c-75d7-45ed-ae79-a08c97dced6e) |

### Calamity Mod (CalamityMod)
| Change Name | Description | Acceptable Values | Example |
| ----------- | ----------- | ----------------- | ------- |
| `MaxCharge` | The maximum charge value of this item. | Positive decimals | ![image](https://github.com/user-attachments/assets/c3e69e05-5e1a-4013-a54e-076885c554ff) |
| `ChargePerUse` | The amount of charge that is consumed every time the item is used. | Positive decimals | ![image](https://github.com/user-attachments/assets/e84df321-7882-4372-a62c-87c3c3164166) |
| `ChargePerAltUse` | The amount of charge that is consumed every time this item is used with right click.<br/>In most cases this does not need to be set and will default to the value of `ChargePerUse`. | Positive decimals | ![image](https://github.com/user-attachments/assets/37cc8362-9ed8-4f7d-a044-567f6260bc17) |

If there are any changes you would like to see support added for, whether it be from Vanilla or other mods, reach out to @nycro on Discord!
