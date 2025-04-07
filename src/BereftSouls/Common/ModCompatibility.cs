using System;
using Terraria.ModLoader;

namespace BereftSouls.Common;

public static class ModCompatibility
{
    // Check if a mod is in Fargo's Souls DLC's ModCompatibility before adding it here!
    public static class SOTS
    {
        public const string Name = "SOTS";
        public static bool Loaded => ModLoader.HasMod(Name);
        private static Mod? mod = null;
        public static Mod Mod
        {
            get
            {
                mod ??= ModLoader.GetMod(Name);
                return mod;
            }
        }
    }
    public static class BossChecklist
    {
        public static void AdjustValues()
        {
            
        }
    }
}