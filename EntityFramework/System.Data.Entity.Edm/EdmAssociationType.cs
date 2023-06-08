using System.Collections.Generic;

namespace System.Data.Entity.Edm;

internal class EdmAssociationType : EdmStructuralType
{
	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmAssociationEnd" /> that defines the source end of the association.
	/// </summary>
	public virtual EdmAssociationEnd SourceEnd { get; set; }

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmAssociationEnd" /> that defines the target end of the association.
	/// </summary>
	public virtual EdmAssociationEnd TargetEnd { get; set; }

	/// <summary>
	///     Gets or sets the optional constraint that indicates whether the relationship is an independent association (no constraint present) or a foreign key relationship ( <see cref="T:System.Data.Entity.Edm.EdmAssociationConstraint" /> specified).
	/// </summary>
	public virtual EdmAssociationConstraint Constraint { get; set; }

	public override EdmStructuralTypeMemberCollection Members => new EdmStructuralTypeMemberCollection(() => new EdmStructuralMember[2] { SourceEnd, TargetEnd });

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.AssociationType;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return EdmMetadataItem.Yield(SourceEnd, TargetEnd, Constraint);
	}
}
