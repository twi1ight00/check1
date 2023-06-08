using System.Collections.Generic;
using System.Data.Entity.Edm.Internal;
using System.Diagnostics;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of an entity type in an Entity Data Model (EDM) <see cref="T:System.Data.Entity.Edm.EdmNamespace" /> .
/// </summary>
[DebuggerDisplay("{Name}")]
internal class EdmEntityType : EdmStructuralType
{
	private readonly BackingList<EdmProperty> declaredPropertiesList = new BackingList<EdmProperty>();

	private readonly BackingList<EdmProperty> declaredKeyPropertiesList = new BackingList<EdmProperty>();

	private readonly BackingList<EdmNavigationProperty> declaredNavigationPropertiesList = new BackingList<EdmNavigationProperty>();

	private EdmEntityType baseEntityType;

	private bool isAbstract;

	public override EdmStructuralTypeMemberCollection Members => new EdmStructuralTypeMemberCollection(() => ((IEnumerable<EdmStructuralMember>)Properties).Concat((IEnumerable<EdmStructuralMember>)NavigationProperties), () => ((IEnumerable<EdmStructuralMember>)declaredPropertiesList).Concat((IEnumerable<EdmStructuralMember>)declaredNavigationPropertiesList));

	/// <summary>
	///     Gets or sets the optional <see cref="T:System.Data.Entity.Edm.EdmEntityType" /> that indicates the base entity type of the entity type.
	/// </summary>
	public new virtual EdmEntityType BaseType
	{
		get
		{
			return baseEntityType;
		}
		set
		{
			base.BaseType = value;
			baseEntityType = value;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether the entity type is abstract.
	/// </summary>
	public new virtual bool IsAbstract
	{
		get
		{
			return isAbstract;
		}
		set
		{
			base.IsAbstract = value;
			isAbstract = value;
		}
	}

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.EdmProperty" /> s that specifies the properties declared by the entity type.
	/// </summary>
	public virtual IList<EdmProperty> DeclaredProperties
	{
		get
		{
			return declaredPropertiesList.EnsureValue();
		}
		set
		{
			declaredPropertiesList.SetValue(value);
		}
	}

	internal bool HasDeclaredProperties => declaredPropertiesList.HasValue;

	public IEnumerable<EdmProperty> Properties
	{
		get
		{
			foreach (EdmEntityType declaringType in this.ToHierarchy().Reverse())
			{
				foreach (EdmProperty declaredProperties in declaringType.declaredPropertiesList)
				{
					yield return declaredProperties;
				}
			}
		}
	}

	/// <summary>
	///     Gets or sets the collection of <see cref="T:System.Data.Entity.Edm.EdmProperty" /> s that indicates which properties from the <see cref="P:System.Data.Entity.Edm.EdmEntityType.DeclaredProperties" /> collection are part of the entity key.
	/// </summary>
	public virtual IList<EdmProperty> DeclaredKeyProperties
	{
		get
		{
			return declaredKeyPropertiesList.EnsureValue();
		}
		set
		{
			declaredKeyPropertiesList.SetValue(value);
		}
	}

	internal bool HasDeclaredKeyProperties => declaredKeyPropertiesList.HasValue;

	/// <summary>
	///     Gets or sets the optional collection of <see cref="T:System.Data.Entity.Edm.EdmNavigationProperty" /> s that specifies the navigation properties declared by the entity type.
	/// </summary>
	public virtual IList<EdmNavigationProperty> DeclaredNavigationProperties
	{
		get
		{
			return declaredNavigationPropertiesList.EnsureValue();
		}
		set
		{
			declaredNavigationPropertiesList.SetValue(value);
		}
	}

	internal bool HasDeclaredNavigationProperties => declaredNavigationPropertiesList.HasValue;

	public IEnumerable<EdmNavigationProperty> NavigationProperties
	{
		get
		{
			foreach (EdmEntityType declaringType in this.ToHierarchy().Reverse())
			{
				foreach (EdmNavigationProperty declaredNavigationProperties in declaringType.declaredNavigationPropertiesList)
				{
					yield return declaredNavigationProperties;
				}
			}
		}
	}

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.EntityType;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return ((IEnumerable<EdmMetadataItem>)declaredPropertiesList).Concat((IEnumerable<EdmMetadataItem>)declaredNavigationPropertiesList);
	}
}
