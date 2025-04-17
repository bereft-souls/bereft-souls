# tPackBuilder Mod Pack Setup

Getting started setting up your first mod pack is extremely simple, and this guide aims to give you a step-by-step walkthrough if it's your first time!

To get started, open tModLoader, and head on over to the Workshop section. Choose "Develop Mods", and then choose "Create Mod" in the bottom right-hand corner.

![image](https://github.com/user-attachments/assets/a64cf3cd-4e82-43af-a4ca-745e0066adaf)

Fill in the fields with your desired info, and click "Create". You do not need a BasicSword since we are not adding any new content right now.

![image](https://github.com/user-attachments/assets/b9b16089-b141-4f5e-bd02-7fd15a49e97c)

tModLoader may require you to download some additional software or programs before continuing.<br/>
If it does, follow all of tModLoader's steps, and then try again.

You should get a new mod, and the source code folder for that mod should open.

Inside of this folder you should find a file called `build.txt`. This file contains some info about how your mod should be built, such as dependencies, naming, and more.

![image](https://github.com/user-attachments/assets/d5bfa4a6-1aa5-4f28-be90-34cc7f53c1cf)

Add the following line to the end of your `build.txt`:

`ModReferences = PackBuilder`

Then, add the internal names of any mods that you want to include in your mod pack to the end, separated by commas.<br/>
Your file should look something like this:

![image](https://github.com/user-attachments/assets/8b62f787-3175-411d-9bff-da28afb77d33)

After this, you're pretty much good to go! You have a couple other resources you can change inside of this folder, such as your mod icon - but functionally your mod should be ready to start adding content.

Any of your tPackBuilder .json files will go into this folder. Go in game and to the Workshop > Develop Mods tab, then hit "Build + Reload" on your mod to see your changes in game.

Check out the [other docs](https://github.com/bereft-souls/bereft-souls/tree/master/src/PackBuilder/docs) for more info on what you can do with tPackBuilder.

Happy modpacking!
