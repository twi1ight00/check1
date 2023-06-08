using System.Collections.Generic;
using System.Data.Common;

namespace System.Data.Entity.Internal;

/// <summary>
///     An implementation of <see cref="T:System.Data.Entity.Internal.InternalPropertyValues" /> that represents a clone of another
///     dictionary.  That is, all the property values have been been copied into this dictionary.
/// </summary>
internal class ClonedPropertyValues : InternalPropertyValues
{
	private readonly ISet<string> _propertyNames;

	private readonly IDictionary<string, ClonedPropertyValuesItem> _propertyValues;

	/// <summary>
	///     Gets the set of names of all properties in this dictionary as a read-only set.
	/// </summary>
	/// <value>The property names.</value>
	public override ISet<string> PropertyNames => _propertyNames;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.ClonedPropertyValues" /> class by copying
	///     values from the given dictionary.
	/// </summary>
	/// <param name="original">The dictionary to clone.</param>
	/// <param name="valuesRecord">If non-null, then the values for the new dictionary are taken from this record rather than from the original dictionary.</param>
	internal ClonedPropertyValues(InternalPropertyValues original, DbDataRecord valuesRecord = null)
		: base(original.InternalContext, original.ObjectType, original.IsEntityValues)
	{
		_propertyNames = original.PropertyNames;
		_propertyValues = new Dictionary<string, ClonedPropertyValuesItem>(_propertyNames.Count);
		foreach (string propertyName in _propertyNames)
		{
			IPropertyValuesItem item = original.GetItem(propertyName);
			object obj = item.Value;
			if (obj is InternalPropertyValues original2)
			{
				DbDataRecord valuesRecord2 = ((valuesRecord == null) ? null : ((DbDataRecord)valuesRecord[propertyName]));
				obj = new ClonedPropertyValues(original2, valuesRecord2);
			}
			else if (valuesRecord != null)
			{
				obj = valuesRecord[propertyName];
				if (obj == DBNull.Value)
				{
					obj = null;
				}
			}
			_propertyValues[propertyName] = new ClonedPropertyValuesItem(propertyName, obj, item.Type, item.IsComplex);
		}
	}

	/// <summary>
	///     Gets the dictionary item for a given property name.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>An item for the given name.</returns>
	protected override IPropertyValuesItem GetItemImpl(string propertyName)
	{
		return _propertyValues[propertyName];
	}
}
