#define TRACE
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Common.Logging.Configuration;

/// <summary>
/// Various utility methods for using during factory and logger instance configuration
/// </summary>
/// <author>Erich Eichinger</author>
public static class ArgUtils
{
	/// <summary>
	/// A delegate converting a string representation into the target type
	/// </summary>
	public delegate T ParseHandler<T>(string strValue);

	/// <summary>
	/// An anonymous action delegate with no arguments and no return value.
	/// </summary>
	/// <seealso cref="M:Common.Logging.Configuration.ArgUtils.Guard(Common.Logging.Configuration.ArgUtils.Action,System.String,System.Object[])" />
	public delegate void Action();

	/// <summary>
	/// An anonymous action delegate with no arguments and no return value.
	/// </summary>
	/// <seealso cref="M:Common.Logging.Configuration.ArgUtils.Guard``1(Common.Logging.Configuration.ArgUtils.Function{``0},System.String,System.Object[])" />
	public delegate T Function<T>();

	private static readonly Hashtable s_parsers;

	/// <summary>
	/// Initialize all members before any of this class' methods can be accessed (avoids beforeFieldInit)
	/// </summary>
	static ArgUtils()
	{
		s_parsers = new Hashtable();
		RegisterTypeParser((string s) => Convert.ToBoolean(s));
		RegisterTypeParser((string s) => Convert.ToInt16(s));
		RegisterTypeParser((string s) => Convert.ToInt32(s));
		RegisterTypeParser((string s) => Convert.ToInt64(s));
		RegisterTypeParser((string s) => Convert.ToSingle(s));
		RegisterTypeParser((string s) => Convert.ToDouble(s));
		RegisterTypeParser((string s) => Convert.ToDecimal(s));
	}

	/// <summary>
	/// Adds the parser to the list of known type parsers.
	/// </summary>
	/// <remarks>
	/// .NET intrinsic types are pre-registerd: short, int, long, float, double, decimal, bool
	/// </remarks>
	public static void RegisterTypeParser<T>(ParseHandler<T> parser)
	{
		s_parsers[typeof(T)] = parser;
	}

	/// <summary>
	/// Retrieves the named value from the specified <see cref="T:System.Collections.Specialized.NameValueCollection" />.
	/// </summary>
	/// <param name="values">may be null</param>
	/// <param name="name">the value's key</param>
	/// <returns>if <paramref name="values" /> is not null, the value returned by values[name]. <c>null</c> otherwise.</returns>
	public static string GetValue(NameValueCollection values, string name)
	{
		return GetValue(values, name, null);
	}

	/// <summary>
	/// Retrieves the named value from the specified <see cref="T:System.Collections.Specialized.NameValueCollection" />.
	/// </summary>
	/// <param name="values">may be null</param>
	/// <param name="name">the value's key</param>
	/// <param name="defaultValue">the default value, if not found</param>
	/// <returns>if <paramref name="values" /> is not null, the value returned by values[name]. <c>null</c> otherwise.</returns>
	public static string GetValue(NameValueCollection values, string name, string defaultValue)
	{
		if (values != null)
		{
			string[] allKeys = values.AllKeys;
			foreach (string key in allKeys)
			{
				if (string.Compare(name, key, ignoreCase: true) == 0)
				{
					return values[name];
				}
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// Returns the first nonnull, nonempty value among its arguments.
	/// </summary>
	/// <remarks>
	/// Returns <c>null</c>, if the initial list was null or empty.
	/// </remarks>
	/// <seealso cref="M:Common.Logging.Configuration.ArgUtils.Coalesce``1(System.Predicate{``0},``0[])" />
	public static string Coalesce(params string[] values)
	{
		return Coalesce((string v) => !string.IsNullOrEmpty(v), values);
	}

	/// <summary>
	/// Returns the first nonnull, nonempty value among its arguments.
	/// </summary>
	/// <remarks>
	/// Also 
	/// </remarks>
	public static T Coalesce<T>(Predicate<T> predicate, params T[] values) where T : class
	{
		if (values == null || values.Length == 0)
		{
			return null;
		}
		if (predicate == null)
		{
			predicate = (T v) => v != null;
		}
		foreach (T val in values)
		{
			if (predicate(val))
			{
				return val;
			}
		}
		return null;
	}

	/// <summary>
	/// Tries parsing <paramref name="stringValue" /> into an enum of the type of <paramref name="defaultValue" />.
	/// </summary>
	/// <param name="defaultValue">the default value to return if parsing fails</param>
	/// <param name="stringValue">the string value to parse</param>
	/// <returns>the successfully parsed value, <paramref name="defaultValue" /> otherwise.</returns>
	public static T TryParseEnum<T>(T defaultValue, string stringValue) where T : struct
	{
		if (!typeof(T).IsEnum)
		{
			throw new ArgumentException($"Type '{typeof(T).FullName}' is not an enum type");
		}
		T result = defaultValue;
		if (string.IsNullOrEmpty(stringValue))
		{
			return defaultValue;
		}
		try
		{
			result = (T)Enum.Parse(typeof(T), stringValue, ignoreCase: true);
		}
		catch
		{
			Trace.WriteLine($"WARN: failed converting value '{stringValue}' to enum type '{defaultValue.GetType().FullName}'");
		}
		return result;
	}

	/// <summary>
	/// Tries parsing <paramref name="stringValue" /> into the specified return type.
	/// </summary>
	/// <param name="defaultValue">the default value to return if parsing fails</param>
	/// <param name="stringValue">the string value to parse</param>
	/// <returns>the successfully parsed value, <paramref name="defaultValue" /> otherwise.</returns>
	public static T TryParse<T>(T defaultValue, string stringValue)
	{
		T result = defaultValue;
		if (string.IsNullOrEmpty(stringValue))
		{
			return defaultValue;
		}
		if (!(s_parsers[typeof(T)] is ParseHandler<T> parser))
		{
			throw new ArgumentException($"There is no parser registered for type {typeof(T).FullName}");
		}
		try
		{
			result = parser(stringValue);
		}
		catch
		{
			Trace.WriteLine($"WARN: failed converting value '{stringValue}' to type '{typeof(T).FullName}' - returning default '{result}'");
		}
		return result;
	}

	/// <summary>
	/// Throws a <see cref="T:System.ArgumentNullException" /> if <paramref name="val" /> is <c>null</c>.
	/// </summary>
	public static T AssertNotNull<T>(string paramName, T val) where T : class
	{
		if (object.ReferenceEquals(val, null))
		{
			throw new ArgumentNullException(paramName);
		}
		return val;
	}

	/// <summary>
	/// Throws a <see cref="T:System.ArgumentNullException" /> if <paramref name="val" /> is <c>null</c>.
	/// </summary>
	public static T AssertNotNull<T>(string paramName, T val, string messageFormat, params object[] args) where T : class
	{
		if (object.ReferenceEquals(val, null))
		{
			throw new ArgumentNullException(paramName, string.Format(messageFormat, args));
		}
		return val;
	}

	/// <summary>
	/// Throws a <see cref="T:System.ArgumentOutOfRangeException" /> if an object of type <paramref name="valType" /> is not
	/// assignable to type <typeparam name="T"></typeparam>.
	/// </summary>
	public static Type AssertIsAssignable<T>(string paramName, Type valType)
	{
		return AssertIsAssignable<T>(paramName, valType, string.Format("Type '{0}' of parameter '{1}' is not assignable to target type '{2}'", (valType == null) ? "<undefined>" : valType.AssemblyQualifiedName, paramName, typeof(T).AssemblyQualifiedName), new object[0]);
	}

	/// <summary>
	/// Throws a <see cref="T:System.ArgumentOutOfRangeException" /> if an object of type <paramref name="valType" /> is not
	/// assignable to type <typeparam name="T"></typeparam>.
	/// </summary>
	public static Type AssertIsAssignable<T>(string paramName, Type valType, string messageFormat, params object[] args)
	{
		if (valType == null)
		{
			throw new ArgumentNullException("valType");
		}
		if (!typeof(T).IsAssignableFrom(valType))
		{
			throw new ArgumentOutOfRangeException(paramName, valType, string.Format(messageFormat, args));
		}
		return valType;
	}

	/// <summary>
	/// Ensures any exception thrown by the given <paramref name="action" /> is wrapped with an
	/// <see cref="T:Common.Logging.ConfigurationException" />. 
	/// </summary>
	/// <remarks>
	/// If <paramref name="action" /> already throws a ConfigurationException, it will not be wrapped.
	/// </remarks>
	/// <param name="action">the action to execute</param>
	/// <param name="messageFormat">the message to be set on the thrown <see cref="T:Common.Logging.ConfigurationException" /></param>
	/// <param name="args">args to be passed to <see cref="M:System.String.Format(System.String,System.Object[])" /> to format the message</param>
	public static void Guard(Action action, string messageFormat, params object[] args)
	{
		Guard(delegate
		{
			action();
			return 0;
		}, messageFormat, args);
	}

	/// <summary>
	/// Ensures any exception thrown by the given <paramref name="function" /> is wrapped with an
	/// <see cref="T:Common.Logging.ConfigurationException" />. 
	/// </summary>
	/// <remarks>
	/// If <paramref name="function" /> already throws a ConfigurationException, it will not be wrapped.
	/// </remarks>
	/// <param name="function">the action to execute</param>
	/// <param name="messageFormat">the message to be set on the thrown <see cref="T:Common.Logging.ConfigurationException" /></param>
	/// <param name="args">args to be passed to <see cref="M:System.String.Format(System.String,System.Object[])" /> to format the message</param>
	public static T Guard<T>(Function<T> function, string messageFormat, params object[] args)
	{
		try
		{
			return function();
		}
		catch (ConfigurationException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new ConfigurationException(string.Format(messageFormat, args), ex);
		}
	}
}
