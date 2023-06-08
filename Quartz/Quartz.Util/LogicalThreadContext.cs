using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Web;

namespace Quartz.Util;

/// <summary>
/// Wrapper class to access thread local data.
/// Data is either accessed from thread or HTTP Context's 
/// data if HTTP Context is avaiable.
/// </summary>
/// <author>Marko Lahma .NET</author>
[SecurityCritical]
public static class LogicalThreadContext
{
	/// <summary>
	/// Retrieves an object with the specified name.
	/// </summary>
	/// <param name="name">The name of the item.</param>
	/// <returns>The object in the call context associated with the specified name or null if no object has been stored previously</returns>
	public static T GetData<T>(string name)
	{
		if (HttpContext.Current != null)
		{
			return (T)HttpContext.Current.Items[name];
		}
		return (T)CallContext.GetData(name);
	}

	/// <summary>
	/// Stores a given object and associates it with the specified name.
	/// </summary>
	/// <param name="name">The name with which to associate the new item.</param>
	/// <param name="value">The object to store in the call context.</param>
	public static void SetData(string name, object value)
	{
		if (HttpContext.Current != null)
		{
			HttpContext.Current.Items[name] = value;
		}
		else
		{
			CallContext.SetData(name, value);
		}
	}

	/// <summary>
	/// Empties a data slot with the specified name.
	/// </summary>
	/// <param name="name">The name of the data slot to empty.</param>
	public static void FreeNamedDataSlot(string name)
	{
		if (HttpContext.Current != null)
		{
			HttpContext.Current.Items.Remove(name);
		}
		else
		{
			CallContext.FreeNamedDataSlot(name);
		}
	}
}
