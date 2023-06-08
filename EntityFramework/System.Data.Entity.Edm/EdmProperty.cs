using System.Collections.Generic;
using System.Diagnostics;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of a primitive- or complex-valued property of an Entity Data Model (EDM) entity or complex type.
/// </summary>
[DebuggerDisplay("{Name}")]
internal class EdmProperty : EdmStructuralMember
{
	/// <summary>
	///     Gets or sets an <see cref="T:System.Data.Entity.Edm.EdmCollectionKind" /> value that indicates which collection semantics - if any - apply to the property.
	/// </summary>
	public virtual EdmCollectionKind CollectionKind { get; set; }

	/// <summary>
	///     Gets or sets a <see cref="T:System.Data.Entity.Edm.EdmConcurrencyMode" /> value that indicates whether the property is used for concurrency validation.
	/// </summary>
	public virtual EdmConcurrencyMode ConcurrencyMode { get; set; }

	/// <summary>
	///     Gets or sets on optional value that indicates an initial default value for the property.
	/// </summary>
	public virtual object DefaultValue { get; set; }

	/// <summary>
	///     Gets or sets an <see cref="T:System.Data.Entity.Edm.EdmTypeReference" /> that specifies the result type of the property.
	/// </summary>
	public virtual EdmTypeReference PropertyType { get; set; }

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.Property;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return EdmMetadataItem.Yield(PropertyType);
	}
}
