using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of an entity container in an Entity Data Model (EDM) <see cref="T:System.Data.Entity.Edm.EdmModel" /> .
/// </summary>
internal class EdmEntityContainer : EdmNamedMetadataItem
{
	private readonly BackingList<EdmAssociationSet> associationSetsList = new BackingList<EdmAssociationSet>();

	private readonly BackingList<EdmEntitySet> entitySetsList = new BackingList<EdmEntitySet>();

	/// <summary>
	///     Gets all <see cref="T:System.Data.Entity.Edm.EdmEntityContainerItem" /> s declared within the namspace. Includes <see cref="T:System.Data.Entity.Edm.EdmAssociationSet" /> s and <see cref="T:System.Data.Entity.Edm.EdmEntitySet" /> s.
	/// </summary>
	public IEnumerable<EdmEntityContainerItem> ContainerItems => ((IEnumerable<EdmEntityContainerItem>)associationSetsList).Concat((IEnumerable<EdmEntityContainerItem>)entitySetsList);

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.EdmAssociationSet" /> s that specifies the association sets within the container.
	/// </summary>
	public virtual IList<EdmAssociationSet> AssociationSets
	{
		get
		{
			return associationSetsList.EnsureValue();
		}
		set
		{
			associationSetsList.SetValue(value);
		}
	}

	internal bool HasAssociationSets => associationSetsList.HasValue;

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.EdmEntitySet" /> s that specifies the entity sets within the container.
	/// </summary>
	public virtual IList<EdmEntitySet> EntitySets
	{
		get
		{
			return entitySetsList.EnsureValue();
		}
		set
		{
			entitySetsList.SetValue(value);
		}
	}

	internal bool HasEntitySets => entitySetsList.HasValue;

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.EntityContainer;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return ContainerItems;
	}
}
