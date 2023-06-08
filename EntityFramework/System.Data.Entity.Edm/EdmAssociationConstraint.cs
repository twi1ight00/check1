using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of a constraint applied to an Entity Data Model (EDM) association.
/// </summary>
internal class EdmAssociationConstraint : EdmMetadataItem
{
	private readonly BackingList<EdmProperty> dependentPropertiesList = new BackingList<EdmProperty>();

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmAssociationEnd" /> that represents the 'dependent' end of the constraint; properties from this association end's entity type contribute to the <see cref="P:System.Data.Entity.Edm.EdmAssociationConstraint.DependentProperties" /> collection.
	/// </summary>
	public virtual EdmAssociationEnd DependentEnd { get; set; }

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.EdmProperty" /> instances from the <see cref="P:System.Data.Entity.Edm.EdmAssociationConstraint.DependentEnd" /> of the constraint. The values of these properties are constrained against the primary key values of the remaining, 'principal' association end's entity type.
	/// </summary>
	public virtual IList<EdmProperty> DependentProperties
	{
		get
		{
			return dependentPropertiesList.EnsureValue();
		}
		set
		{
			dependentPropertiesList.SetValue(value);
		}
	}

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.AssociationConstraint;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return Enumerable.Empty<EdmMetadataItem>();
	}
}
