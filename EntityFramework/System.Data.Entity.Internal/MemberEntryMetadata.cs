namespace System.Data.Entity.Internal;

/// <summary>
///     Contains metadata about a member of an entity type or complex type.
/// </summary>
internal abstract class MemberEntryMetadata
{
	private readonly Type _declaringType;

	private readonly Type _elementType;

	private readonly string _memberName;

	/// <summary>
	///     Gets the type of the member for which this is metadata.
	/// </summary>
	/// <value>The type of the member entry.</value>
	public abstract MemberEntryType MemberEntryType { get; }

	/// <summary>
	///     Gets the name of the property.
	/// </summary>
	/// <value>The name.</value>
	public string MemberName => _memberName;

	/// <summary>
	///     Gets the type of the entity or complex object that on which the member is declared.
	/// </summary>
	/// <value>The type that the member is declared on.</value>
	public Type DeclaringType => _declaringType;

	/// <summary>
	///     Gets the type of element for the property, which for non-collection properties
	///     is the same as the MemberType and which for collection properties is the type
	///     of element contained in the collection.
	/// </summary>
	/// <value>The type of the element.</value>
	public Type ElementType => _elementType;

	/// <summary>
	///     Gets the type of the member, which for collection properties is the type
	///     of the collection rather than the type in the collection.
	/// </summary>
	/// <value>The type of the member.</value>
	public abstract Type MemberType { get; }

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.MemberEntryMetadata" /> class.
	/// </summary>
	/// <param name="declaringType">The type that the property is declared on.</param>
	/// <param name="elementType">Type of the property.</param>
	/// <param name="memberName">The property name.</param>
	protected MemberEntryMetadata(Type declaringType, Type elementType, string memberName)
	{
		_declaringType = declaringType;
		_elementType = elementType;
		_memberName = memberName;
	}

	/// <summary>
	///     Creates a new <see cref="T:System.Data.Entity.Internal.InternalMemberEntry" /> the runtime type of which will be
	///     determined by the metadata.
	/// </summary>
	/// <param name="internalEntityEntry">The entity entry to which the member belongs.</param>
	/// <param name="parentPropertyEntry">The parent property entry if the new entry is nested, otherwise null.</param>
	/// <returns>The new entry.</returns>
	public abstract InternalMemberEntry CreateMemberEntry(InternalEntityEntry internalEntityEntry, InternalPropertyEntry parentPropertyEntry);
}
