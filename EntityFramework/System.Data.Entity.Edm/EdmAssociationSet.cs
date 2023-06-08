using System.Collections.Generic;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of an association set in an Entity Data Model (EDM) <see cref="T:System.Data.Entity.Edm.EdmEntityContainer" /> ).
/// </summary>
internal class EdmAssociationSet : EdmEntityContainerItem
{
	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmAssociationType" /> that specifies the association type for the set.
	/// </summary>
	public virtual EdmAssociationType ElementType { get; set; }

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmEntitySet" /> that specifies the entity set corresponding to the <see cref="P:System.Data.Entity.Edm.EdmAssociationType.SourceEnd" /> association end for this association set.
	/// </summary>
	public virtual EdmEntitySet SourceSet { get; set; }

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmEntitySet" /> that specifies the entity set corresponding to the <see cref="P:System.Data.Entity.Edm.EdmAssociationType.TargetEnd" /> association end for this association set.
	/// </summary>
	public virtual EdmEntitySet TargetSet { get; set; }

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.AssociationSet;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return Enumerable.Empty<EdmMetadataItem>();
	}
}
