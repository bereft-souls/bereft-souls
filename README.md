# bereft-souls

> Ultra-modded Terraria mod pack.

---

[!https://img.shields.io/badge/Discord-Brome%20World-black.svg?labelColor=5865F2]][https://discord.com/invite/nYJfz3jgQy]

This is the repository housing the source code for the **Bereft Souls** compatibility mod and any immediately associated add-ons and libraries.
The majority of the project source lies within here, but some projects (such as the separate Mod Pack API) will be moved to a separate repository in the future.

## Building

Our compatibility aide directly references various mods whose assemblies are currently provided in the repository. Our approach may change in the future, but this is currently satisfactory.

Since this servers as a monorepository with multiple embedded projects, we have to take an unorthodox approach to making tModLoader understand our project structure:

```bash
# 1. Clone the repository into a directory within `ModSources`
cd path/to/tModLoader/ModSources/
git clone https://github.com/bereft-souls/bereft-souls # You can keep the name as `bereft-souls`

# 2. Run the generate-symlinks.js script.
cd bereft-souls
node ./generate-symlinks.js # If you are on Windows, do this with administrator privileges; symlinks require elevation on Windows.

# 3. The project should now be buildable.
dotnet build src/BereftSouls/BereftSouls.csproj -c Release

# IDE integration will also work directly if you open the solution or C# project.
# Refrain from opening the projects from their symlink paths as that's only
# intended for allowing tModLoader to write localization files and to publish the mod.
```