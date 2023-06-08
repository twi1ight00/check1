using System.Collections.Generic;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Allows the construction and modification of a specific use of a type in an Entity Data Model (EDM) item. See <see cref="P:System.Data.Entity.Edm.EdmProperty.PropertyType" /> for examples.
/// </summary>
internal class EdmTypeReference : EdmMetadataItem
{
	private EdmPrimitiveTypeFacets facets;

	/// <summary>
	///     Gets or sets a value indicating the collection rank of the type reference. A collection rank greater than zero indicates that the type reference represents a collection of its referenced <see cref="P:System.Data.Entity.Edm.EdmTypeReference.EdmType" /> .
	/// </summary>
	public virtual int CollectionRank { get; set; }

	/// <summary>
	///     Gets or sets a value indicating the <see cref="T:System.Data.Entity.Edm.EdmDataModelType" /> referenced by this type reference.
	/// </summary>
	public virtual EdmDataModelType EdmType { get; set; }

	/// <summary>
	///     Gets or sets an optional value indicating whether the referenced type should be considered nullable.
	/// </summary>
	public virtual bool? IsNullable { get; set; }

	/// <summary>
	///     Gets or sets an optional <see cref="T:System.Data.Entity.Edm.EdmPrimitiveTypeFacets" /> instance that applies additional constraints to a referenced primitive type.
	/// </summary>
	/// <remarks>
	///     Accessing this property forces the creation of an EdmPrimitiveTypeFacets value if no value has previously been set. Use <see cref="P:System.Data.Entity.Edm.EdmTypeReference.HasFacets" /> to determine whether or not this property currently has a value.
	/// </remarks>
	public virtual EdmPrimitiveTypeFacets PrimitiveTypeFacets
	{
		get
		{
			if (facets == null)
			{
				facets = new EdmPrimitiveTypeFacets();
			}
			return facets;
		}
		set
		{
			facets = value;
		}
	}

	/// <summary>
	///     Gets a value indicating whether the <see cref="P:System.Data.Entity.Edm.EdmTypeReference.PrimitiveTypeFacets" /> property of this type reference has been assigned an <see cref="T:System.Data.Entity.Edm.EdmPrimitiveTypeFacets" /> value with at least one facet value specified.
	/// </summary>
	public bool HasFacets
	{
		get
		{
			if (facets != null)
			{
				return facets.HasValue;
			}
			return false;
		}
	}

	/// <summary>
	///     Indicates whether this type reference represents a collection of its referenced <see cref="P:System.Data.Entity.Edm.EdmTypeReference.EdmType" /> (when <see cref="P:System.Data.Entity.Edm.EdmTypeReference.CollectionRank" /> is greater than zero) or not.
	/// </summary>
	public bool IsCollectionType
	{
		get
		{
			if (IsValid())
			{
				return CollectionRank > 0;
			}
			return false;
		}
	}

	/// <summary>
	///     Indicates whether the <see cref="P:System.Data.Entity.Edm.EdmTypeReference.EdmType" /> property of this type reference currently refers to an <see cref="T:System.Data.Entity.Edm.EdmComplexType" /> , is not a collection type, and does not have primitive facet values specified.
	/// </summary>
	public bool IsComplexType => IsValidNonPrimitive(EdmItemKind.ComplexType);

	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.Edm.EdmComplexType" /> currently referred to by this type reference, or <code>null</code> if the type reference is a collection type or does not refer to a complex type.
	/// </summary>
	public EdmComplexType ComplexType => GetEdmTypeAs<EdmComplexType>(IsValidNonPrimitive(EdmItemKind.ComplexType));

	/// <summary>
	///     Indicates whether the <see cref="P:System.Data.Entity.Edm.EdmTypeReference.EdmType" /> property of this type reference currently refers to an <see cref="T:System.Data.Entity.Edm.EdmPrimitiveType" /> and is not a collection type.
	/// </summary>
	public bool IsPrimitiveType => IsValidPrimitive();

	/// <summary>
	///     Gets the <see cref="T:System.Data.Entity.Edm.EdmPrimitiveType" /> currently referred to by this type reference, or <code>null</code> if the type reference is a collection type or does not refer to a primitive type.
	/// </summary>
	public EdmPrimitiveType PrimitiveType => GetEdmTypeAs<EdmPrimitiveType>(IsValidPrimitive());

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.TypeReference;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return Enumerable.Empty<EdmMetadataItem>();
	}

	private bool IsValid()
	{
		if (EdmType != null && CollectionRank >= 0)
		{
			if (EdmType.ItemKind != EdmItemKind.PrimitiveType)
			{
				return !HasFacets;
			}
			return true;
		}
		return false;
	}

	internal bool IsValidPrimitive()
	{
		if (IsValid() && EdmType.ItemKind == EdmItemKind.PrimitiveType)
		{
			return CollectionRank == 0;
		}
		return false;
	}

	internal bool IsValidNonPrimitive(EdmItemKind kind)
	{
		if (IsValid() && EdmType.ItemKind == kind)
		{
			return CollectionRank == 0;
		}
		return false;
	}

	internal TEdmType GetEdmTypeAs<TEdmType>(bool condition) where TEdmType : EdmDataModelType
	{
		if (!condition)
		{
			return null;
		}
		return EdmType as TEdmType;
	}
}
