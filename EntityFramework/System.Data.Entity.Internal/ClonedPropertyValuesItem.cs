namespace System.Data.Entity.Internal;

/// <summary>
///     An implementation of <see cref="T:System.Data.Entity.Internal.IPropertyValuesItem" /> for an item in a <see cref="T:System.Data.Entity.Internal.ClonedPropertyValues" />.
/// </summary>
internal class ClonedPropertyValuesItem : IPropertyValuesItem
{
	private readonly string _name;

	private readonly bool _isComplex;

	private readonly Type _type;

	/// <summary>
	///     Gets or sets the value of the property represented by this item.
	/// </summary>
	/// <value>The value.</value>
	public object Value { get; set; }

	/// <summary>
	///     Gets the name of the property.
	/// </summary>
	/// <value>The name.</value>
	public string Name => _name;

	/// <summary>
	///     Gets a value indicating whether this item represents a complex property.
	/// </summary>
	/// <value>
	///     <c>true</c> If this instance represents a complex property; otherwise, <c>false</c>.
	/// </value>
	public bool IsComplex => _isComplex;

	/// <summary>
	///     Gets the type of the underlying property.
	/// </summary>
	/// <value>The property type.</value>
	public Type Type => _type;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.ClonedPropertyValuesItem" /> class.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <param name="value">The value.</param>
	/// <param name="type">The type.</param>
	/// <param name="isComplex">If set to <c>true</c> this item represents a complex property.</param>
	public ClonedPropertyValuesItem(string name, object value, Type type, bool isComplex)
	{
		_name = name;
		_type = type;
		_isComplex = isComplex;
		Value = value;
	}
}
