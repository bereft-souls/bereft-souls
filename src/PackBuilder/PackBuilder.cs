global using static PackBuilder.Core.Utils.ModUtils;
using Mono.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using Terraria.ModLoader;

namespace PackBuilder
{
    public class PackBuilder : Mod
    {
        /// <summary>
        /// The file that is currently being de-serialized and loaded by tPackBuilder.
        /// </summary>
        public static string? LoadingFile { get; set; } = null;

        public static JsonSerializerSettings JsonSettings
        {
            get => new()
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                Error = (object? sender, ErrorEventArgs ex) =>
                {
                    // We change the error that is currently being thrown in order to have
                    // a user-friendly error display message if there are errors in any .json files.
                    if (ex.ErrorContext.Error is JsonReadingException)
                        return;

                    var error = new JsonReadingException(ex.ErrorContext.Error);

                    PropertyInfo property = typeof(ErrorContext).GetProperty("Error", BindingFlags.Public | BindingFlags.Instance)!;
                    FieldInfo field = property.GetBackingField();

                    field.SetValue(ex.ErrorContext, error);
                    throw error;
                }
            };
        }
    }

    // Hides stack trace for exceptions of this type.
    // Experienced developers will know what the issue is without the trace just by reading (if they even need these systems).
    // Hopefully the absense of a wall of text will make this more approachable by those unfamiliar with debugging.
    public class HideStackTraceException(string message) : Exception(message)
    {
        public override string ToString() =>
            "Error encountered when building tPackBuilder changes!" + Environment.NewLine +
            Environment.NewLine +
            Message + Environment.NewLine +
            $"[c/F5BC42:{PackBuilder.LoadingFile ?? ""}]";
    }

    // When the json deserializer throws an error.
    public class JsonReadingException(Exception innerException) :
        HideStackTraceException($"Error deserializing JSON object:{Environment.NewLine}{innerException.Message}")
    { }

    // When an NPC mod specifies no NPCs.
    public class NoNPCsException() :
        HideStackTraceException("Must specify 1 or more NPCs for an NPC modification!")
    { }

    // When an item mod specifies no items.
    public class NoItemsException() :
        HideStackTraceException("Must specify 1 or more items for an item modification!")
    { }

    // When a projectile mod specifies no projectiles.
    public class NoProjectilesException() :
        HideStackTraceException("Must specify 1 or more projectile for a projectile modification!")
    { }

    // When a recipe mod has no conditions.
    public class NoConditionsException() :
        HideStackTraceException("Must specify 1 or more conditions for a recipe modification!")
    { }

    // When a recipe builder has no result.
    public class NoResultException() :
        HideStackTraceException("Must specify a result for a recipe building!")
    { }
}
