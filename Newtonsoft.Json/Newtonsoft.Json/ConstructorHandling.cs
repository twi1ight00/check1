namespace Newtonsoft.Json;

/// <summary>
///   Specifies how constructors are used when initializing objects during deserialization by the <see cref="T:Newtonsoft.Json.JsonSerializer" />.
/// </summary>
public enum ConstructorHandling
{
	/// <summary>
	///   First attempt to use the public default constructor, then fall back to single parameterized constructor, then the non-public default constructor.
	/// </summary>
	Default,
	/// <summary>
	///   Json.NET will use a non-public default constructor before falling back to a parameterized constructor.
	/// </summary>
	AllowNonPublicDefaultConstructor
}
