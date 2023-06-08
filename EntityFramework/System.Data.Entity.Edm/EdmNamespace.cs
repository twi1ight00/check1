using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of a namespace in an <see cref="T:System.Data.Entity.Edm.EdmModel" /> .
/// </summary>
internal class EdmNamespace : EdmQualifiedNameMetadataItem
{
	private readonly BackingList<EdmAssociationType> associationTypesList = new BackingList<EdmAssociationType>();

	private readonly BackingList<EdmComplexType> complexTypesList = new BackingList<EdmComplexType>();

	private readonly BackingList<EdmEntityType> entityTypesList = new BackingList<EdmEntityType>();

	/// <summary>
	///     Gets all <see cref="T:System.Data.Entity.Edm.EdmNamespaceItem" /> s declared within the namspace. Includes <see cref="T:System.Data.Entity.Edm.EdmAssociationType" /> s, <see cref="T:System.Data.Entity.Edm.EdmComplexType" /> s, <see cref="T:System.Data.Entity.Edm.EdmEntityType" /> s.
	/// </summary>
	public IEnumerable<EdmNamespaceItem> NamespaceItems => ((IEnumerable<EdmNamespaceItem>)associationTypesList).Concat((IEnumerable<EdmNamespaceItem>)complexTypesList).Concat(entityTypesList);

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmAssociationType" /> s declared within the namespace.
	/// </summary>
	public virtual IList<EdmAssociationType> AssociationTypes
	{
		get
		{
			return associationTypesList.EnsureValue();
		}
		set
		{
			associationTypesList.SetValue(value);
		}
	}

	internal bool HasAssociationTypes => associationTypesList.HasValue;

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmComplexType" /> s declared within the namespace.
	/// </summary>
	public virtual IList<EdmComplexType> ComplexTypes
	{
		get
		{
			return complexTypesList.EnsureValue();
		}
		set
		{
			complexTypesList.SetValue(value);
		}
	}

	internal bool HasComplexTypes => complexTypesList.HasValue;

	/// <summary>
	///     Gets or sets the <see cref="T:System.Data.Entity.Edm.EdmEntityType" /> s declared within the namespace.
	/// </summary>
	public virtual IList<EdmEntityType> EntityTypes
	{
		get
		{
			return entityTypesList.EnsureValue();
		}
		set
		{
			entityTypesList.SetValue(value);
		}
	}

	internal bool HasEntityTypes => entityTypesList.HasValue;

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.Namespace;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return NamespaceItems;
	}
}
