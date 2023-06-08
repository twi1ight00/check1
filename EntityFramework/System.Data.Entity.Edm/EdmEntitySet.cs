using System.Collections.Generic;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of an entity set in an Entity Data Model (EDM) <see cref="T:System.Data.Entity.Edm.EdmEntityContainer" /> .
/// </summary>
internal class EdmEntitySet : EdmEntityContainerItem
{
	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmEntityType" /> that specifies the entity type for the set.
	/// </summary>
	public virtual EdmEntityType ElementType { get; set; }

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.EntitySet;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return Enumerable.Empty<EdmMetadataItem>();
	}
}
