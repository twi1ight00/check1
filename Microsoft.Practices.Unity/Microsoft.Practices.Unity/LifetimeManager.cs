using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Base class for Lifetime managers - classes that control how
/// and when instances are created by the Unity container.
/// </summary>
public abstract class LifetimeManager : ILifetimePolicy, IBuilderPolicy
{
	private bool inUse;

	internal bool InUse
	{
		get
		{
			return inUse;
		}
		set
		{
			inUse = value;
		}
	}

	/// <summary>
	/// Retrieve a value from the backing store associated with this Lifetime policy.
	/// </summary>
	/// <returns>the object desired, or null if no such object is currently stored.</returns>
	public abstract object GetValue();

	/// <summary>
	/// Stores the given value into backing store for retrieval later.
	/// </summary>
	/// <param name="newValue">The object being stored.</param>
	public abstract void SetValue(object newValue);

	/// <summary>
	/// Remove the given object from backing store.
	/// </summary>
	public abstract void RemoveValue();
}
