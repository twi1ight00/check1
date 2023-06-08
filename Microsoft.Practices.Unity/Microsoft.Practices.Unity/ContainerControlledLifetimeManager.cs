using System;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that holds onto the instance given to it.
/// When the <see cref="T:Microsoft.Practices.Unity.ContainerControlledLifetimeManager" /> is disposed,
/// the instance is disposed with it.
/// </summary>
public class ContainerControlledLifetimeManager : SynchronizedLifetimeManager, IDisposable
{
	private object value;

	/// <summary>
	/// Retrieve a value from the backing store associated with this Lifetime policy.
	/// </summary>
	/// <returns>the object desired, or null if no such object is currently stored.</returns>
	protected override object SynchronizedGetValue()
	{
		return value;
	}

	/// <summary>
	/// Stores the given value into backing store for retrieval later.
	/// </summary>
	/// <param name="newValue">The object being stored.</param>
	protected override void SynchronizedSetValue(object newValue)
	{
		value = newValue;
	}

	/// <summary>
	/// Remove the given object from backing store.
	/// </summary>
	public override void RemoveValue()
	{
		Dispose();
	}

	/// <summary>
	/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	/// </summary>
	/// <filterpriority>2</filterpriority>
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Standard Dispose pattern implementation. Not needed, but it keeps FxCop happy.
	/// </summary>
	/// <param name="disposing">Always true, since we don't have a finalizer.</param>
	protected void Dispose(bool disposing)
	{
		if (value != null)
		{
			if (value is IDisposable)
			{
				((IDisposable)value).Dispose();
			}
			value = null;
		}
	}
}
