using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PackBuilder.Common.JsonBuilding.Data;

/// <summary>
/// Type specifier for value modification.
/// </summary>
public enum ValueModifierKind {
	/// <summary>
	/// No operation will be performed.
	/// </summary>
	/// <remarks>
	/// The underlying value of this field is set to 0, this is to ensure that <c>default(ValueModifier)</c> will not perform any operation.
	/// </remarks>
	None = 0,
	/// <summary>
	/// The value provided by the modifier will be added to the base value.
	/// </summary>
	Add = 1,
	/// <summary>
	/// The value provided by the modifier will be multiplied with the base value.
	/// </summary>
	Multiply = 2,
	/// <summary>
	/// The value provided by the modifier will replace the base value.
	/// </summary>
	Replace = 3
}

/// <summary>
/// A modifier that can be applied to a value.
/// </summary>
/// <param name="kind">Type of modification performed by the modifier.</param>
/// <param name="value">Value associated to the modification.</param>
[JsonConverter(typeof(Converter))]
public readonly struct ValueModifier(ValueModifierKind kind, float value) : IEquatable<ValueModifier> {
	public sealed class Converter : JsonConverter<ValueModifier> {
		public override void WriteJson(JsonWriter writer, ValueModifier value, JsonSerializer serializer) => value.ToJToken().WriteTo(writer);
		public override ValueModifier ReadJson(JsonReader reader, Type objectType, ValueModifier existingValue, bool hasExistingValue, JsonSerializer serializer) => FromJson(JToken.ReadFrom(reader));
	}

	public static readonly ValueModifier NoOperation = new(ValueModifierKind.None, 0);

	/// <summary>
	/// Parses a ValueModifier from a json instance.
	/// </summary>
	/// <param name="token">Token to parse.</param>
	/// <returns>A new modifier created from the information described in the json.</returns>
	/// <exception cref="JsonSerializationException">If the given json value couldn't be converted to a <see cref="ValueModifier"/>.</exception>
	public static ValueModifier FromJson(JToken token) {
		switch (token) {
			case { Type: JTokenType.Null }:
				return NoOperation;
			case JValue { Type: JTokenType.Float or JTokenType.Integer } number: {
				float value = (float)number;
				return new ValueModifier(value > 0 ? ValueModifierKind.Replace : ValueModifierKind.Add, value);
			}
			case JValue { Type: JTokenType.String } str: {
				string? value = (string?)str;
				if (string.IsNullOrEmpty(value)) return NoOperation;
				ReadOnlySpan<char> text = value;
				ValueModifierKind kind = ValueModifierKind.Replace;
				switch (text[0]) {
					case '+':
						kind = ValueModifierKind.Add;
						text = text[1..];
						break;
					case '-':
						kind = ValueModifierKind.Add;
						break;
					case 'x':
						kind = ValueModifierKind.Multiply;
						text = text[1..];
						break;
				}
				if (!float.TryParse(text, CultureInfo.InvariantCulture, out float result)) {
					IJsonLineInfo lineInfo = token;
					if (lineInfo.HasLineInfo())
						throw new JsonSerializationException($"Cannot parse \"{new string(text)}\" as a floating point number.", token.Path, lineInfo.LineNumber, lineInfo.LinePosition, null);
					throw new JsonSerializationException($"Cannot parse \"{new string(text)}\" as a floating point number.");
				}
				return new ValueModifier(kind, result);
			}
			default: {
				IJsonLineInfo lineInfo = token;
				if (lineInfo.HasLineInfo())
					throw new JsonSerializationException($"Unsupported value modifier: {token}.", token.Path, lineInfo.LineNumber, lineInfo.LinePosition, null);
				throw new JsonSerializationException($"Unsupported value modifier: {token}.");
			}
		}
	}

	/// <summary>
	/// The type of modification that will be performed by this modifier.
	/// </summary>
	public readonly ValueModifierKind Kind = kind;

	/// <summary>
	/// The value to apply that will be used to perform the modification.
	/// </summary>
	public readonly float Value = value;

	/// <summary>
	/// Applies this modifier to the given value.
	/// </summary>
	/// <param name="baseValue">Original value to modify.</param>
	/// <returns>The modified value.</returns>
	public float Apply(float baseValue) => this.Kind switch {
		ValueModifierKind.None => baseValue,
		ValueModifierKind.Add => baseValue + this.Value,
		ValueModifierKind.Multiply => baseValue * this.Value,
		ValueModifierKind.Replace => this.Value,
		_ => throw new IndexOutOfRangeException($"Invalid ValueModifierKind: {this.Kind}")
	};

	public void ApplyTo(ref float baseValue) => baseValue = this.Apply(baseValue);
	public void ApplyTo(ref int baseValue) => baseValue = (int)this.Apply(baseValue);

	/// <summary>
	/// Checks if this modifier performs an operation or not.
	/// </summary>
	public bool HasOperation => this.Kind switch {
		ValueModifierKind.None => false,
		ValueModifierKind.Add => this.Value != 0,
		ValueModifierKind.Multiply => this.Value != 1,
		ValueModifierKind.Replace => true,
		_ => throw new IndexOutOfRangeException($"Invalid ValueModifierKind: {this.Kind}")
	};

	/// <summary>
	/// Converts this modifier into a json entry.
	/// </summary>
	/// <returns>A JToken representing this modifier.</returns>
	/// <exception cref="IndexOutOfRangeException"></exception>
	public JToken ToJToken() => this.Kind switch {
		ValueModifierKind.None => JValue.CreateNull(),
		ValueModifierKind.Add => this.Value > 0 ? $"+{this.Value}" : $"{this.Value}",
		ValueModifierKind.Multiply => $"x{this.Value}",
		ValueModifierKind.Replace => this.Value,
		_ => throw new IndexOutOfRangeException($"Invalid ValueModifierKind: {this.Kind}")
	};

	public override string ToString() => "ValueModifier[{kind},{value}]";
	public bool Equals(ValueModifier other) => this.Kind == other.Kind && this.Value.Equals(other.Value);
	public override bool Equals(object? obj) => obj is ValueModifier other && this.Equals(other);
	public override int GetHashCode() => HashCode.Combine((int)this.Kind, this.Value);
	public static bool operator ==(ValueModifier left, ValueModifier right) => left.Equals(right);
	public static bool operator !=(ValueModifier left, ValueModifier right) => !left.Equals(right);
}