using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     A collection of all the properties for an underlying entity or complex object.
/// </summary>
/// <remarks>
///     An instance of this class can be converted to an instance of the generic class
///     using the Cast method.
///     Complex properties in the underlying entity or complex object are represented in
///     the property values as nested instances of this class.
/// </remarks>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbPropertyValues
{
	private readonly InternalPropertyValues _internalValues;

	/// <summary>
	///     Gets the set of names of all properties in this dictionary as a read-only set.
	/// </summary>
	/// <value>The property names.</value>
	public IEnumerable<string> PropertyNames => _internalValues.PropertyNames;

	/// <summary>
	///     Gets or sets the value of the property with the specified property name.
	///     The value may be a nested instance of this class.
	/// </summary>
	/// <param name="propertyName">The property name.</param>
	/// <value>The value of the property.</value>
	public object this[string propertyName]
	{
		get
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
			object obj = _internalValues[propertyName];
			if (obj is InternalPropertyValues internalValues)
			{
				obj = new DbPropertyValues(internalValues);
			}
			return obj;
		}
		set
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(propertyName), null, "!String.IsNullOrWhiteSpace(propertyName)");
			_internalValues[propertyName] = value;
		}
	}

	/// <summary>
	///     Gets the internal dictionary.
	/// </summary>
	/// <value>The internal dictionary.</value>
	internal InternalPropertyValues InternalPropertyValues => _internalValues;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbPropertyValues" /> class.
	/// </summary>
	/// <param name="internalValues">The internal dictionary.</param>
	internal DbPropertyValues(InternalPropertyValues internalValues)
	{
		_internalValues = internalValues;
	}

	/// <summary>
	///     Creates an object of the underlying type for this dictionary and hydrates it with property
	///     values from this dictionary.
	/// </summary>
	/// <returns>The properties of this dictionary copied into a new object.</returns>
	public object ToObject()
	{
		return _internalValues.ToObject();
	}

	/// <summary>
	///     Sets the values of this dictionary by reading values out of the given object.
	///     The given object can be of any type.  Any property on the object with a name that
	///     matches a property name in the dictionary and can be read will be read.  Other
	///     properties will be ignored.  This allows, for example, copying of properties from
	///     simple Data Transfer Objects (DTOs).
	/// </summary>
	/// <param name="obj">The object to read values from.</param>
	[SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "obj", Justification = "Naming is intentional.")]
	public void SetValues(object obj)
	{
		RuntimeFailureMethods.Requires(obj != null, null, "obj != null");
		_internalValues.SetValues(obj);
	}

	/// <summary>
	///     Creates a new dictionary containing copies of all the properties in this dictionary.
	///     Changes made to the new dictionary will not be reflected in this dictionary and vice versa.
	/// </summary>
	/// <returns>A clone of this dictionary.</returns>
	public DbPropertyValues Clone()
	{
		return new DbPropertyValues(_internalValues.Clone());
	}

	/// <summary>
	///     Sets the values of this dictionary by reading values from another dictionary.
	///     The other dictionary must be based on the same type as this dictionary, or a type derived
	///     from the type for this dictionary.
	/// </summary>
	/// <param name="dictionary">The dictionary to read values from.</param>
	public void SetValues(DbPropertyValues propertyValues)
	{
		RuntimeFailureMethods.Requires(propertyValues != null, null, "propertyValues != null");
		_internalValues.SetValues(propertyValues._internalValues);
	}

	/// <summary>
	///     Gets the value of the property just like using the indexed property getter but
	///     typed to the type of the generic parameter.  This is useful especially with
	///     nested dictionaries to avoid writing expressions with lots of casts.
	/// </summary>
	/// <typeparam name="TValue">The type of the property.</typeparam>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>The value of the property.</returns>
	public TValue GetValue<TValue>(string propertyName)
	{
		return (TValue)this[propertyName];
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
