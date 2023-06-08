using System.Data.Metadata.Edm;
using System.Data.Objects;

namespace System.Data.Entity.Internal;

/// <summary>
///     An implementation of <see cref="T:System.Data.Entity.Internal.IPropertyValuesItem" /> for an item in a <see cref="T:System.Data.Entity.Internal.DbDataRecordPropertyValues" />.
/// </summary>
internal class DbDataRecordPropertyValuesItem : IPropertyValuesItem
{
	private readonly DbUpdatableDataRecord _dataRecord;

	private readonly int _ordinal;

	private object _value;

	/// <summary>
	///     Gets or sets the value of the property represented by this item.
	/// </summary>
	/// <value>The value.</value>
	public object Value
	{
		get
		{
			return _value;
		}
		set
		{
			_dataRecord.SetValue(_ordinal, value);
			_value = value;
		}
	}

	/// <summary>
	///     Gets the name of the property.
	/// </summary>
	/// <value>The name.</value>
	public string Name => _dataRecord.GetName(_ordinal);

	/// <summary>
	///     Gets a value indicating whether this item represents a complex property.
	/// </summary>
	/// <value>
	///     <c>true</c> If this instance represents a complex property; otherwise, <c>false</c>.
	/// </value>
	public bool IsComplex => _dataRecord.DataRecordInfo.FieldMetadata[_ordinal].FieldType.TypeUsage.EdmType.BuiltInTypeKind == BuiltInTypeKind.ComplexType;

	/// <summary>
	///     Gets the type of the underlying property.
	/// </summary>
	/// <value>The property type.</value>
	public Type Type => _dataRecord.GetFieldType(_ordinal);

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.DbDataRecordPropertyValuesItem" /> class.
	/// </summary>
	/// <param name="dataRecord">The data record.</param>
	/// <param name="ordinal">The ordinal.</param>
	/// <param name="value">The value.</param>
	public DbDataRecordPropertyValuesItem(DbUpdatableDataRecord dataRecord, int ordinal, object value)
	{
		_dataRecord = dataRecord;
		_ordinal = ordinal;
		_value = value;
	}
}
