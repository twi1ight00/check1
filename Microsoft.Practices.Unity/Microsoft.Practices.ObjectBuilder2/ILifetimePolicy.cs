namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that controls how instances are
/// persisted and recovered from an external store. Used to implement
/// things like singletons and per-http-request lifetime.
/// </summary>
public interface ILifetimePolicy : IBuilderPolicy
{
	/// <summary>
	/// Retrieve a value from the backing store associated with this Lifetime policy.
	/// </summary>
	/// <returns>the object desired, or null if no such object is currently stored.</returns>
	object GetValue();

	/// <summary>
	/// Stores the given value into backing store for retrieval later.
	/// </summary>
	/// <param name="newValue">The object to store.</param>
	void SetValue(object newValue);

	/// <summary>
	/// Remove the value this lifetime policy is managing from backing store.
	/// </summary>
	void RemoveValue();
}
