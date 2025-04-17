global using static BereftCompatibility.Common.Constants;

using System.Reflection;

namespace BereftCompatibility.Common;

internal static class Constants
{
    public const BindingFlags GENERIC_FLAGS = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
}