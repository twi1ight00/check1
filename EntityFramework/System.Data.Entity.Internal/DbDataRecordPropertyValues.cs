using System.Collections.Generic;
using System.Data.Objects;

namespace System.Data.Entity.Internal;

/// <summary>
///     An implementation of <see cref="T:System.Data.Entity.Internal.InternalPropertyValues" /> that is based on an existing
///     <see cref="T:System.Data.Objects.DbUpdatableDataRecord" /> instance.
/// </summary>
internal class DbDataRecordPropertyValues : InternalPropertyValues
{
	private readonly DbUpdatableDataRecord _dataRecord;

	private ISet<string> _names;

	/// <summary>
	///     Gets the set of names of all properties in this dictionary as a read-only set.
	/// </summary>
	/// <value>The property names.</value>
	public override ISet<string> PropertyNames
	{
		get
		{
			if (_names == null)
			{
				HashSet<string> hashSet = new HashSet<string>();
				for (int i = 0; i < _dataRecord.FieldCount; i++)
				{
					hashSet.Add(_dataRecord.GetName(i));
				}
				_names = new ReadOnlySet<string>(hashSet);
			}
			return _names;
		}
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.DbDataRecordPropertyValues" /> class.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	/// <param name="type">The type.</param>
	/// <param name="dataRecord">The data record.</param>
	/// <param name="isEntityValues">If set to <c>true</c> this is a dictionary for an entity, otherwise it is a dictionary for a complex object.</param>
	internal DbDataRecordPropertyValues(InternalContext internalContext, Type type, DbUpdatableDataRecord dataRecord, bool isEntity)
		: base(internalContext, type, isEntity)
	{
		_dataRecord = dataRecord;
	}

	/// <summary>
	///     Gets the dictionary item for a given property name.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>An item for the given name.</returns>
	protected override IPropertyValuesItem GetItemImpl(string propertyName)
	{
		int ordinal = _dataRecord.GetOrdinal(propertyName);
		object obj = _dataRecord[ordinal];
		if (obj is DbUpdatableDataRecord dataRecord)
		{
			bool isEntity = false;
			obj = new DbDataRecordPropertyValues(base.InternalContext, _dataRecord.GetFieldType(ordinal), dataRecord, isEntity);
		}
		else if (obj == DBNull.Value)
		{
			obj = null;
		}
		return new DbDataRecordPropertyValuesItem(_dataRecord, ordinal, obj);
	}
}
