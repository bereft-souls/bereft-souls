# Projectile Modification

tPackBuilder adds support for dynamically modifying aspects of projectiles, such as damage, piercing, hit cooldown, and more.

All you need to do is add a `.projectilemod.json` file to your mod's folder, add the required data, and tPackBuilder handles the rest!

> Quick link to [avilable conditions/changes](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/ProjectileModification.md#available-changes) at the bottom.

## Pre-requisites

While this is not technically required, it is recommended to have a competent text editor to assist you in building your files.

The recommended editor is [Notepad++](https://notepad-plus-plus.org/), as it is lightweight, fast, and relatively simple, while still providing enough useful tools to easily make your syntax nice and readable.

Alternatively, the Visual Studio text editor works fine as well. However, be warned that Visual Studio may try to give you warnings about your file's formatting, even if the file is actually formatted correctly. As long as you're following the documentation specified below, you'll be fine.

If you really wanted to, you could also build all of your recipes from the default Notepad application. This is not recommended, as Notepad does not contain useful features like auto-filling end brackets or quotes, but if you really prefer it, it will work fine.

***

## Building and configuring your modifications
tPackBuilder will search your mod's files for any `.projectilemod.json` files. Each of these files acts as a sort of "rule", which defines a set of changes you want to make to a given projectile.

You can add multiple `.projectilemod.json` files to your mod's folder and each one will be applied individually.

***

### Walkthrough
> This section is a step-by-step guide to setting up your first projectile modification, and a breakdown of how modifications are formatted. If you want to skip straight to see what options are available, jump to the [documentation](https://github.com/bereft-souls/bereft-souls/blob/master/src/PackBuilder/docs/ProjectileModification.md#available-changes) at the bottom of this file.

To get started, lets create a modification that buffs wooden arrows to pierce 1 extra time and scales to 5x the size.

First, add a file to your mod's folder and rename it to `arrow.projectilemod.json`. The naming for this file doesn't matter to tPackBuilder, only that it ends with `.projectilemod.json` - but we're going to call it `arrow` to make it clear what this modification is for.

![image](https://github.com/user-attachments/assets/d7728231-0c46-41e5-bc25-1f3ccd9e5467)

Then, open up this file in your preferred text editor. This guide will be using Notepad++, as is recommended in the top section. This file should be empty by default.

Start by adding a set of curly braces to your file. All of your modification's data will be filled into the braces. This is the default structure for .json objects.

![image](https://github.com/user-attachments/assets/c907b0f9-a883-4180-b510-8f537c763793)

Now we're going to begin actually filling in our modification's data. Projectile mods are broken down into 2 parts:
- Projectile
- Changes

"Projectile" is going to be the projectile(s) that you want to actually apply your listed changes to, and "Changes" is... the changes.

### Setup

You can begin setting up those parts like so:

![image](https://github.com/user-attachments/assets/5e59a174-ce52-4b4b-93e0-847b9a699091)

### Item

Filling in the Projectile portion of the modification is very simple and self-explanatory. Simply enter the internal name of the projectile you want to modify, prefixed with the mod it is from and a `/`.

In this case, since the item is from vanilla, the mod is simply going to be `Terraria`.

![image](https://github.com/user-attachments/assets/8e8206cd-431e-4e09-aab6-1a2da5966773)

If you want these changes to apply to multiple projectiles, you can add the "Projectile" field multiple times.

![image](https://github.com/user-attachments/assets/dab7eae0-e274-4eda-bedd-3e64d2c393f0)

### Changes

This section is slightly more complex. There are a number of changes available for you to make to an item. Your first step is going to be figuring out what mod controls the changes you want to implement.

> Note that currently, tPackBuilder only has support for changing vanilla properties on projectiles.<br/>If there are any modded properties you want to see support added for in the future, feel free to reach out and request them!

Start by adding a section for the mod controlling the changes you want to change. Since we are only changing piercing and scale, we only need a vanilla section. And remember that when something is from vanilla, we denote that by using `Terraria` as the mod name.

![image](https://github.com/user-attachments/assets/af0913ce-8ac8-4f9a-991e-0b7df29e274f)

From here, we can start listing off our changes. When you want to change a value, you have 3 options:
- Write a new value. This will assign the property to this new value.
- Write a value prefixed with a `+`. This will increase the already in place value by your specified amount.
- Write a value prefixed with a `-`. This will decrease the already in place value by your specified amount.
- Write a value prefixed with a `x`. This will multiply the already in place value by your specified amount.
> Note that some fields expect integers to be given as values. If you use decimals in these instances, whether it be setting the value directly or by performing an operation, the resulting numbers will be rounded towards 0.

![image](https://github.com/user-attachments/assets/e73e2681-e303-4f32-ba2c-960e348aa657)

If we wanted to set the projectile's piercing to exactly 5 (not add 5 to it), we could do this:

![image](https://github.com/user-attachments/assets/005cc83c-1e01-4a12-a494-92541f263efa)

And just like that, we're done! If you head into the game and fire a wooden arrow, you should see it has the modified properties.

![image](https://github.com/user-attachments/assets/d97350c1-360a-41dc-92b3-e1fdb98ccca7)

A full list of available changes and what value you should assign them can be found below. You can mix and match as many changes as you like - just make sure to follow the syntax above! Happy modpacking!

***

## Available Changes

### Vanilla (Terraria)
| Change Name | Description | Acceptable Values | Example |
| ----------- | ----------- | ----------------- | ------- |
| `Damage` | The damage this item deals. | Positive integers | ![image](https://github.com/user-attachments/assets/00229a9c-0f58-4061-93f6-b30f09504f20) |
| `Piercing` | The number of times this projectile can pierce.<br/>Set to -1 for infinite piercing. | Integers | ![image](https://github.com/user-attachments/assets/fc1681cf-149b-4470-943e-4d5f4b564c8c) |
| `Scale` | The scale of the projectile. | Positive decimals | ![image](https://github.com/user-attachments/assets/8bf9edf6-c60c-49af-9f40-7f8919a5e602) |
| `HitCooldown` | The number of i-frames this projectile grants enemies upon hitting them. | Integers | ![image](https://github.com/user-attachments/assets/90077976-b6b4-4135-a880-566e15242d34) |

If there are any changes you would like to see support added for, whether it be from Vanilla or other mods, reach out to @nycro on Discord!
