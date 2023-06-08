using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Resources;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
///     The internal class used to implement <see cref="T:System.Data.Entity.Infrastructure.DbPropertyValues" />.
///     This internal class allows for a clean internal factoring without compromising the public API.
/// </summary>
internal abstract class InternalPropertyValues
{
	private const BindingFlags PropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	private static readonly ConcurrentDictionary<Type, Func<object>> NonEntityFactories = new ConcurrentDictionary<Type, Func<object>>();

	private readonly InternalContext _internalContext;

	private readonly Type _type;

	private readonly bool _isEntityValues;

	/// <summary>
	///     Gets the set of names of all properties in this dictionary as a read-only set.
	/// </summary>
	/// <value>The property names.</value>
	public abstract ISet<string> PropertyNames { get; }

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
			return GetItem(propertyName).Value;
		}
		set
		{
			if (value is DbPropertyValues dbPropertyValues)
			{
				value = dbPropertyValues.InternalPropertyValues;
			}
			IPropertyValuesItem item = GetItem(propertyName);
			if (!(item.Value is InternalPropertyValues internalPropertyValues))
			{
				SetValue(item, value);
				return;
			}
			if (!(value is InternalPropertyValues values))
			{
				throw Error.DbPropertyValues_AttemptToSetNonValuesOnComplexProperty();
			}
			internalPropertyValues.SetValues(values);
		}
	}

	/// <summary>
	///     Gets the entity type of complex type that this dictionary is based on.
	/// </summary>
	/// <value>The type of the object underlying this dictionary.</value>
	public Type ObjectType => _type;

	/// <summary>
	///     Gets the internal context with which the underlying entity or complex type is associated.
	/// </summary>
	/// <value>The internal context.</value>
	public InternalContext InternalContext => _internalContext;

	/// <summary>
	///     Gets a value indicating whether the object for this dictionary is an entity or a complex object.
	/// </summary>
	/// <value><c>true</c> if this this is a dictionary for an entity; <c>false</c> if it is a dictionary for a complex object.</value>
	public bool IsEntityValues => _isEntityValues;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalPropertyValues" /> class.
	/// </summary>
	/// <param name="internalContext">The internal context with which the entity of complex object is associated.</param>
	/// <param name="type">The type of the entity or complex object.</param>
	/// <param name="isEntityValues">If set to <c>true</c> this is a dictionary for an entity, otherwise it is a dictionary for a complex object.</param>
	protected InternalPropertyValues(InternalContext internalContext, Type type, bool isEntityValues)
	{
		_internalContext = internalContext;
		_type = type;
		_isEntityValues = isEntityValues;
	}

	/// <summary>
	///     Implemented by subclasses to get the dictionary item for a given property name.
	///     Checking that the name is valid should happen before this method is called such
	///     that subclasses do not need to perform the check.
	/// </summary>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>An item for the given name.</returns>
	protected abstract IPropertyValuesItem GetItemImpl(string propertyName);

	/// <summary>
	///     Creates an object of the underlying type for this dictionary and hydrates it with property
	///     values from this dictionary.
	/// </summary>
	/// <returns>The properties of this dictionary copied into a new object.</returns>
	public object ToObject()
	{
		object obj = CreateObject();
		IDictionary<string, Action<object, object>> propertySetters = DbHelpers.GetPropertySetters(_type);
		foreach (string propertyName in PropertyNames)
		{
			object obj2 = GetItem(propertyName).Value;
			if (obj2 is InternalPropertyValues internalPropertyValues)
			{
				obj2 = internalPropertyValues.ToObject();
			}
			if (propertySetters.TryGetValue(propertyName, out var value))
			{
				value(obj, obj2);
			}
		}
		return obj;
	}

	/// <summary>
	///     Creates an instance of the underlying type for this dictionary, which may either be an entity type (in which
	///     case CreateObject on the context is used) or a non-entity type (in which case the empty constructor is used.)
	///     In either case, app domain cached compiled delegates are used to do the creation.
	/// </summary>
	private object CreateObject()
	{
		if (_isEntityValues)
		{
			return _internalContext.CreateObject(_type);
		}
		if (!NonEntityFactories.TryGetValue(_type, out var value))
		{
			NewExpression body = Expression.New(_type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null));
			value = Expression.Lambda<Func<object>>((Expression)body, (ParameterExpression[])null).Compile();
			NonEntityFactories.TryAdd(_type, value);
		}
		return value();
	}

	/// <summary>
	///     Sets the values of this dictionary by reading values out of the given object.
	///     The given object must be of the type that this dictionary is based on.
	/// </summary>
	/// <param name="value">The object to read values from.</param>
	public void SetValues(object value)
	{
		IDictionary<string, Func<object, object>> propertyGetters = DbHelpers.GetPropertyGetters(value.GetType());
		foreach (string propertyName in PropertyNames)
		{
			if (propertyGetters.TryGetValue(propertyName, out var value2))
			{
				object obj = value2(value);
				IPropertyValuesItem item = GetItem(propertyName);
				if (obj == null && item.IsComplex)
				{
					throw Error.DbPropertyValues_ComplexObjectCannotBeNull(propertyName, _type.Name);
				}
				if (!(item.Value is InternalPropertyValues internalPropertyValues))
				{
					SetValue(item, obj);
				}
				else
				{
					internalPropertyValues.SetValues(obj);
				}
			}
		}
	}

	/// <summary>
	///     Creates a new dictionary containing copies of all the properties in this dictionary.
	///     Changes made to the new dictionary will not be reflected in this dictionary and vice versa.
	/// </summary>
	/// <returns>A clone of this dictionary.</returns>
	public InternalPropertyValues Clone()
	{
		return new ClonedPropertyValues(this);
	}

	/// <summary>
	///     Sets the values of this dictionary by reading values from another dictionary.
	///     The other dictionary must be based on the same type as this dictionary, or a type derived
	///     from the type for this dictionary.
	/// </summary>
	/// <param name="values">The dictionary to read values from.</param>
	public void SetValues(InternalPropertyValues values)
	{
		if (!_type.IsAssignableFrom(values.ObjectType))
		{
			throw Error.DbPropertyValues_AttemptToSetValuesFromWrongType(values.ObjectType.Name, _type.Name);
		}
		foreach (string propertyName in PropertyNames)
		{
			IPropertyValuesItem item = values.GetItem(propertyName);
			if (item.Value == null && item.IsComplex)
			{
				throw Error.DbPropertyValues_NestedPropertyValuesNull(propertyName, _type.Name);
			}
			this[propertyName] = item.Value;
		}
	}

	/// <summary>
	///     Gets the dictionary item for the property with the given name.
	///     This method checks that the given name is valid.
	/// </summary>
	/// <param name="propertyName">The property name.</param>
	/// <returns>The item.</returns>
	public IPropertyValuesItem GetItem(string propertyName)
	{
		if (!PropertyNames.Contains(propertyName))
		{
			throw Error.DbPropertyValues_PropertyDoesNotExist(propertyName, _type.Name);
		}
		return GetItemImpl(propertyName);
	}

	/// <summary>
	///     Sets the value of the property only if it is different from the current value and is not
	///     an invalid attempt to set a complex property.
	/// </summary>
	private void SetValue(IPropertyValuesItem item, object newValue)
	{
		if (!DbHelpers.KeyValuesEqual(item.Value, newValue))
		{
			if (item.Value == null && item.IsComplex)
			{
				throw Error.DbPropertyValues_NestedPropertyValuesNull(item.Name, _type.Name);
			}
			if (newValue != null && !item.Type.IsAssignableFrom(newValue.GetType()))
			{
				throw Error.DbPropertyValues_WrongTypeForAssignment(newValue.GetType().Name, item.Name, item.Type.Name, _type.Name);
			}
			item.Value = newValue;
		}
	}
}
