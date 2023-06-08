using System;

namespace Newtonsoft.Json;

/// <summary>
///   Specifies type name handling options for the <see cref="T:Newtonsoft.Json.JsonSerializer" />.
/// </summary>
/// <remarks>
///   <see cref="T:Newtonsoft.Json.TypeNameHandling" /> should be used with caution when your application deserializes JSON from an external source.
///   Incoming types should be validated with a custom <see cref="T:System.Runtime.Serialization.SerializationBinder" />
///   when deserializing with a value other than <c>TypeNameHandling.None</c>.
/// </remarks>
[Flags]
public enum TypeNameHandling
{
	/// <summary>
	///   Do not include the .NET type name when serializing types.
	/// </summary>
	None = 0,
	/// <summary>
	///   Include the .NET type name when serializing into a JSON object structure.
	/// </summary>
	Objects = 1,
	/// <summary>
	///   Include the .NET type name when serializing into a JSON array structure.
	/// </summary>
	Arrays = 2,
	/// <summary>
	///   Always include the .NET type name when serializing.
	/// </summary>
	All = 3,
	/// <summary>
	///   Include the .NET type name when the type of the object being serialized is not the same as its declared type.
	/// </summary>
	Auto = 4
}
