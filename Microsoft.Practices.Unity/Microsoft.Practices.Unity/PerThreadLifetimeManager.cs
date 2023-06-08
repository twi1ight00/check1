using System;
using System.Collections.Generic;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that holds the instances given to it, 
/// keeping one instance per thread.
/// </summary>
/// <remarks>
/// <para>
/// This LifetimeManager does not dispose the instances it holds.
/// </para>
/// </remarks>
public class PerThreadLifetimeManager : LifetimeManager
{
	[ThreadStatic]
	private static Dictionary<Guid, object> values;

	private readonly Guid key;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.PerThreadLifetimeManager" /> class.
	/// </summary>
	public PerThreadLifetimeManager()
	{
		key = Guid.NewGuid();
	}

	/// <summary>
	/// Retrieve a value from the backing store associated with this Lifetime policy for the 
	/// current thread.
	/// </summary>
	/// <returns>the object desired, or <see langword="null" /> if no such object is currently 
	/// stored for the current thread.</returns>
	public override object GetValue()
	{
		EnsureValues();
		values.TryGetValue(key, out var value);
		return value;
	}

	/// <summary>
	/// Stores the given value into backing store for retrieval later when requested
	/// in the current thread.
	/// </summary>
	/// <param name="newValue">The object being stored.</param>
	public override void SetValue(object newValue)
	{
		EnsureValues();
		values[key] = newValue;
	}

	/// <summary>
	/// Remove the given object from backing store.
	/// </summary>
	/// <remarks>Not implemented for this lifetime manager.</remarks>
	public override void RemoveValue()
	{
	}

	private static void EnsureValues()
	{
		if (values == null)
		{
			values = new Dictionary<Guid, object>();
		}
	}
}
