using System.Web;
using System.Web.SessionState;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Web.Extensions;

/// <summary>
/// HttpSession的扩展方法
/// </summary>
public static class SessionExtensions
{
	/// <summary>
	/// Persists an object by key in the session state dictionary.
	/// </summary>
	/// <param name="session">The session state.</param>
	/// <param name="key">The key.</param>
	/// <param name="obj">The object.</param>
	public static void PersistObject(this HttpSessionStateBase session, string key, object obj)
	{
		if (!key.IsNullOrWhiteSpace())
		{
			session[key] = obj;
		}
	}

	/// <summary>
	/// Persists an object by key in the session state dictionary.
	/// </summary>
	/// <param name="session">The session state.</param>
	/// <param name="key">The key.</param>
	/// <param name="obj">The object.</param>
	public static void PersistObject(this HttpSessionState session, string key, object obj)
	{
		if (!key.IsNullOrWhiteSpace())
		{
			session[key] = obj;
		}
	}

	/// <summary>
	/// Gets the previously persisted object from the session state.
	/// </summary>
	/// <typeparam name="T">The type of object to return.</typeparam>
	/// <param name="session">The session state.</param>
	/// <param name="key">The key.</param>
	/// <param name="defaultObj">The default value to return.</param>
	/// <returns>The object as the type T if it found in state dictionary; otherwise default value;</returns>
	public static T RestoreObject<T>(this HttpSessionStateBase session, string key, T defaultObj = default(T))
	{
		if (key.IsNullOrWhiteSpace())
		{
			return defaultObj;
		}
		object value = session[key];
		if (value == null)
		{
			return defaultObj;
		}
		return (T)value;
	}

	/// <summary>
	/// Gets the previously persisted object from the session state.
	/// </summary>
	/// <typeparam name="T">The type of object to return.</typeparam>
	/// <param name="session">The session state.</param>
	/// <param name="key">The key.</param>
	/// <param name="defaultObj">The default value to return.</param>
	/// <returns>The object as the type T if it found in state dictionary; otherwise default value;</returns>
	public static T RestoreObject<T>(this HttpSessionState session, string key, T defaultObj = default(T))
	{
		if (key.IsNullOrWhiteSpace())
		{
			return defaultObj;
		}
		object value = session[key];
		if (value == null)
		{
			return defaultObj;
		}
		return (T)value;
	}

	/// <summary>
	/// Removes the previously persisted object 
	/// from the session state.
	/// </summary>
	/// <param name="session">The session state.</param>
	/// <param name="key">The key.</param>
	public static void RemoveObject(this HttpSessionStateBase session, string key)
	{
		if (!key.IsNullOrWhiteSpace())
		{
			session.Remove(key);
		}
	}

	/// <summary>
	/// Removes the previously persisted object 
	/// from the session state.
	/// </summary>
	/// <param name="session">The session state.</param>
	/// <param name="key">The key.</param>
	public static void RemoveObject(this HttpSessionState session, string key)
	{
		if (!key.IsNullOrWhiteSpace())
		{
			session.Remove(key);
		}
	}
}
