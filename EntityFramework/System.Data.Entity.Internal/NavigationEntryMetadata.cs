namespace System.Data.Entity.Internal;

internal class NavigationEntryMetadata : MemberEntryMetadata
{
	private readonly bool _isCollection;

	/// <summary>
	///     Gets the type of the member for which this is metadata.
	/// </summary>
	/// <value>The type of the member entry.</value>
	public override MemberEntryType MemberEntryType
	{
		get
		{
			if (!_isCollection)
			{
				return MemberEntryType.ReferenceNavigationProperty;
			}
			return MemberEntryType.CollectionNavigationProperty;
		}
	}

	/// <summary>
	///     Gets the type of the member, which for collection properties is the type
	///     of the collection rather than the type in the collection.
	/// </summary>
	/// <value>The type of the member.</value>
	public override Type MemberType
	{
		get
		{
			if (!_isCollection)
			{
				return base.ElementType;
			}
			return DbHelpers.CollectionType(base.ElementType);
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.NavigationEntryMetadata" /> class.
	/// </summary>
	/// <param name="declaringType">The type that the property is declared on.</param>
	/// <param name="propertyType">Type of the property.</param>
	/// <param name="propertyName">The property name.</param>
	/// <param name="isCollection">if set to <c>true</c> this is a collection nav prop.</param>
	public NavigationEntryMetadata(Type declaringType, Type propertyType, string propertyName, bool isCollection)
		: base(declaringType, propertyType, propertyName)
	{
		_isCollection = isCollection;
	}

	/// <summary>
	///     Creates a new <see cref="T:System.Data.Entity.Internal.InternalMemberEntry" /> the runtime type of which will be
	///     determined by the metadata.
	/// </summary>
	/// <param name="internalEntityEntry">The entity entry to which the member belongs.</param>
	/// <param name="parentPropertyEntry">The parent property entry which will always be null for navigation entries.</param>
	/// <returns>The new entry.</returns>
	public override InternalMemberEntry CreateMemberEntry(InternalEntityEntry internalEntityEntry, InternalPropertyEntry parentPropertyEntry)
	{
		if (!_isCollection)
		{
			return new InternalReferenceEntry(internalEntityEntry, this);
		}
		return new InternalCollectionEntry(internalEntityEntry, this);
	}
}
