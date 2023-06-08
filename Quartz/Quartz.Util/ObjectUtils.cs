using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Quartz.Util;

/// <summary>
/// Utility methods that are used to convert objects from one type into another.
/// </summary>
/// <author>Aleksandar Seovic</author>
/// <author>Marko Lahma</author>
public static class ObjectUtils
{
	/// <summary>
	/// Convert the value to the required <see cref="T:System.Type" /> (if necessary from a string).
	/// </summary>
	/// <param name="newValue">The proposed change value.</param>
	/// <param name="requiredType">
	/// The <see cref="T:System.Type" /> we must convert to.
	/// </param>
	/// <returns>The new value, possibly the result of type conversion.</returns>
	public static object ConvertValueIfNecessary(Type requiredType, object newValue)
	{
		if (newValue != null)
		{
			if (IsAssignableFrom(newValue, requiredType))
			{
				return newValue;
			}
			TypeConverter typeConverter = TypeDescriptor.GetConverter(requiredType);
			if (typeConverter.CanConvertFrom(newValue.GetType()))
			{
				return typeConverter.ConvertFrom(null, CultureInfo.InvariantCulture, newValue);
			}
			typeConverter = TypeDescriptor.GetConverter(newValue);
			if (typeConverter.CanConvertTo(requiredType))
			{
				return typeConverter.ConvertTo(null, CultureInfo.InvariantCulture, newValue, requiredType);
			}
			if (requiredType == typeof(Type))
			{
				return Type.GetType(newValue.ToString(), throwOnError: true);
			}
			throw new NotSupportedException(string.Concat(newValue, " is no a supported value for a target of type ", requiredType));
		}
		if (requiredType.IsValueType)
		{
			return Activator.CreateInstance(requiredType);
		}
		return null;
	}

	/// <summary>
	/// Determines whether value is assignable to required type.
	/// </summary>
	/// <param name="value">The value to check.</param>
	/// <param name="requiredType">Type of the required.</param>
	/// <returns>
	/// 	<c>true</c> if value can be assigned as given type; otherwise, <c>false</c>.
	/// </returns>
	private static bool IsAssignableFrom(object value, Type requiredType)
	{
		return requiredType.IsInstanceOfType(value);
	}

	/// <summary>
	/// Instantiates an instance of the type specified.
	/// </summary>
	/// <returns></returns>
	public static T InstantiateType<T>(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type", "Cannot instantiate null");
		}
		ConstructorInfo ci = type.GetConstructor(Type.EmptyTypes);
		if (ci == null)
		{
			throw new ArgumentException("Cannot instantiate type which has no empty constructor", type.Name);
		}
		return (T)ci.Invoke(new object[0]);
	}

	/// <summary>
	/// Sets the object properties using reflection.
	/// </summary>
	public static void SetObjectProperties(object obj, string[] propertyNames, object[] propertyValues)
	{
		for (int i = 0; i < propertyNames.Length; i++)
		{
			string name = propertyNames[i];
			string propertyName = name.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture) + name.Substring(1);
			try
			{
				SetPropertyValue(obj, propertyName, propertyValues[i]);
			}
			catch (Exception nfe)
			{
				throw new SchedulerConfigException(string.Format(CultureInfo.InvariantCulture, "Could not parse property '{0}' into correct data type: {1}", new object[2] { name, nfe.Message }), nfe);
			}
		}
	}

	/// <summary>
	/// Sets the object properties using reflection.
	/// </summary>
	/// <param name="obj">The object to set values to.</param>
	/// <param name="props">The properties to set to object.</param>
	public static void SetObjectProperties(object obj, NameValueCollection props)
	{
		props.Remove("type");
		foreach (string name in props.Keys)
		{
			string propertyName = name.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture) + name.Substring(1);
			try
			{
				object value = props[name];
				SetPropertyValue(obj, propertyName, value);
			}
			catch (Exception nfe)
			{
				throw new SchedulerConfigException(string.Format(CultureInfo.InvariantCulture, "Could not parse property '{0}' into correct data type: {1}", new object[2] { name, nfe.Message }), nfe);
			}
		}
	}

	public static void SetPropertyValue(object target, string propertyName, object value)
	{
		Type t = target.GetType();
		PropertyInfo pi = t.GetProperty(propertyName);
		if (pi == null || !pi.CanWrite)
		{
			Type[] interfaces = target.GetType().GetInterfaces();
			foreach (Type interfaceType in interfaces)
			{
				pi = interfaceType.GetProperty(propertyName);
				if (pi != null && pi.CanWrite)
				{
					break;
				}
			}
		}
		if (pi == null)
		{
			throw new MemberAccessException(string.Format(CultureInfo.InvariantCulture, "No writable property '{0}' found", new object[1] { propertyName }));
		}
		MethodInfo mi = pi.GetSetMethod();
		if (mi == null)
		{
			throw new MemberAccessException(string.Format(CultureInfo.InvariantCulture, "Property '{0}' has no setter", new object[1] { propertyName }));
		}
		value = ((!(mi.GetParameters()[0].ParameterType == typeof(TimeSpan))) ? ConvertValueIfNecessary(mi.GetParameters()[0].ParameterType, value) : ((object)GetTimeSpanValueForProperty(pi, value)));
		mi.Invoke(target, new object[1] { value });
	}

	public static TimeSpan GetTimeSpanValueForProperty(PropertyInfo pi, object value)
	{
		object[] attributes = pi.GetCustomAttributes(typeof(TimeSpanParseRuleAttribute), inherit: false);
		if (attributes.Length == 0)
		{
			return (TimeSpan)ConvertValueIfNecessary(typeof(TimeSpan), value);
		}
		TimeSpanParseRuleAttribute attribute = (TimeSpanParseRuleAttribute)attributes[0];
		long longValue = Convert.ToInt64(value);
		return attribute.Rule switch
		{
			TimeSpanParseRule.Milliseconds => TimeSpan.FromMilliseconds(longValue), 
			TimeSpanParseRule.Seconds => TimeSpan.FromSeconds(longValue), 
			TimeSpanParseRule.Minutes => TimeSpan.FromMinutes(longValue), 
			TimeSpanParseRule.Hours => TimeSpan.FromHours(longValue), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static bool IsAttributePresent(Type typeToExamine, Type attributeType)
	{
		return typeToExamine.GetCustomAttributes(attributeType, inherit: true).Length > 0;
	}
}
