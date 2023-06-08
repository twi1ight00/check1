using System.Collections.Generic;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of one end of an Entity Data Model (EDM) association.
/// </summary>
internal class EdmAssociationEnd : EdmStructuralMember
{
	/// <summary>
	///     Gets or sets the entity type referenced by this association end.
	/// </summary>
	public virtual EdmEntityType EntityType { get; set; }

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmAssociationEndKind" /> of this association end, which indicates the multiplicity of the end and whether or not it is required.
	/// </summary>
	public virtual EdmAssociationEndKind EndKind { get; set; }

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmOperationAction" /> to take when a delete operation is attempted.
	/// </summary>
	public virtual EdmOperationAction? DeleteAction { get; set; }

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.AssociationEnd;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return Enumerable.Empty<EdmMetadataItem>();
	}
}
