namespace System.Data.Entity.Edm;

/// <summary>
///     Collection semantics for properties.
/// </summary>
internal enum EdmCollectionKind
{
	/// <summary>
	///     The property does not have a collection type or does not specify explicit collection semantics.
	/// </summary>
	Default,
	/// <summary>
	///     The property is an unordered collection that may contain duplicates.
	/// </summary>
	Bag,
	/// <summary>
	///     The property is an ordered collection that may contain duplicates.
	/// </summary>
	List
}
