using System.Collections.Generic;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;

namespace System.Data.Entity.Internal;

/// <summary>
///     Contains metadata for a property of a complex object or entity.
/// </summary>
internal class PropertyEntryMetadata : MemberEntryMetadata
{
	private readonly bool _isMapped;

	private readonly bool _isComplex;

	/// <summary>
	///     Gets a value indicating whether this is a complex property.
	///     That is, not whether or not this is a property on a complex object, but rather if the
	///     property itself is a complex property.
	/// </summary>
	/// <value>
	///     <c>true</c> if this instance is complex; otherwise, <c>false</c>.
	/// </value>
	public bool IsComplex => _isComplex;

	/// <summary>
	///     Gets the type of the member for which this is metadata.
	/// </summary>
	/// <value>The type of the member entry.</value>
	public override MemberEntryType MemberEntryType
	{
		get
		{
			if (!_isComplex)
			{
				return MemberEntryType.ScalarProperty;
			}
			return MemberEntryType.ComplexProperty;
		}
	}

	/// <summary>
	///     Gets a value indicating whether this instance is mapped in the EDM.
	/// </summary>
	/// <value><c>true</c> if this instance is mapped; otherwise, <c>false</c>.</value>
	public bool IsMapped => _isMapped;

	/// <summary>
	///     Gets the type of the member, which for collection properties is the type
	///     of the collection rather than the type in the collection.
	/// </summary>
	/// <value>The type of the member.</value>
	public override Type MemberType => base.ElementType;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.PropertyEntryMetadata" /> class.
	/// </summary>
	/// <param name="declaringType">The type that the property is declared on.</param>
	/// <param name="propertyType">Type of the property.</param>
	/// <param name="propertyName">The property name.</param>
	/// <param name="isMapped">if set to <c>true</c> the property is mapped in the EDM.</param>
	/// <param name="isComplex">if set to <c>true</c> the property is a complex property.</param>
	public PropertyEntryMetadata(Type declaringType, Type propertyType, string propertyName, bool isMapped, bool isComplex)
		: base(declaringType, propertyType, propertyName)
	{
		_isMapped = isMapped;
		_isComplex = isComplex;
	}

	/// <summary>
	///     Validates that the given name is a property of the declaring type (either on the CLR type or in the EDM)
	///     and that it is a complex or scalar property rather than a nav property and then returns metadata about
	///     the property.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	/// <param name="declaringType">The type that the property is declared on.</param>
	/// <param name="requestedType">The type of property requested, which may be 'object' if any type can be accepted.</param>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>Metadata about the property, or null if the property does not exist or is a navigation property.</returns>
	public static PropertyEntryMetadata ValidateNameAndGetMetadata(InternalContext internalContext, Type declaringType, Type requestedType, string propertyName)
	{
		DbHelpers.GetPropertyTypes(declaringType).TryGetValue(propertyName, out var value);
		MetadataWorkspace metadataWorkspace = internalContext.ObjectContext.MetadataWorkspace;
		StructuralType item = metadataWorkspace.GetItem<StructuralType>(declaringType.FullName, DataSpace.OSpace);
		bool isMapped = false;
		bool isComplex = false;
		item.Members.TryGetValue(propertyName, ignoreCase: false, out var item2);
		if (item2 != null)
		{
			if (!(item2 is EdmProperty edmProperty))
			{
				return null;
			}
			if (value == null)
			{
				if (edmProperty.TypeUsage.EdmType is PrimitiveType primitiveType)
				{
					value = primitiveType.ClrEquivalentType;
				}
				else
				{
					ObjectItemCollection objectItemCollection = (ObjectItemCollection)metadataWorkspace.GetItemCollection(DataSpace.OSpace);
					value = objectItemCollection.GetClrType((StructuralType)edmProperty.TypeUsage.EdmType);
				}
			}
			isMapped = true;
			isComplex = edmProperty.TypeUsage.EdmType.BuiltInTypeKind == BuiltInTypeKind.ComplexType;
		}
		else
		{
			IDictionary<string, Func<object, object>> propertyGetters = DbHelpers.GetPropertyGetters(declaringType);
			IDictionary<string, Action<object, object>> propertySetters = DbHelpers.GetPropertySetters(declaringType);
			if (!propertyGetters.ContainsKey(propertyName) && !propertySetters.ContainsKey(propertyName))
			{
				return null;
			}
		}
		if (!requestedType.IsAssignableFrom(value))
		{
			throw Error.DbEntityEntry_WrongGenericForProp(propertyName, declaringType.Name, requestedType.Name, value.Name);
		}
		return new PropertyEntryMetadata(declaringType, value, propertyName, isMapped, isComplex);
	}

	/// <summary>
	///     Creates a new <see cref="T:System.Data.Entity.Internal.InternalMemberEntry" /> the runtime type of which will be
	///     determined by the metadata.
	/// </summary>
	/// <param name="internalEntityEntry">The entity entry to which the member belongs.</param>
	/// <param name="parentPropertyEntry">The parent property entry if the new entry is nested, otherwise null.</param>
	/// <returns>The new entry.</returns>
	public override InternalMemberEntry CreateMemberEntry(InternalEntityEntry internalEntityEntry, InternalPropertyEntry parentPropertyEntry)
	{
		if (parentPropertyEntry != null)
		{
			return new InternalNestedPropertyEntry(parentPropertyEntry, this);
		}
		return new InternalEntityPropertyEntry(internalEntityEntry, this);
	}
}
