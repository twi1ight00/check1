using System;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A builder policy used to create lifetime policy instances.
/// Used by the LifetimeStrategy when instantiating open
/// generic types.
/// </summary>
public interface ILifetimeFactoryPolicy : IBuilderPolicy
{
	/// <summary>
	/// The type of Lifetime manager that will be created by this factory.
	/// </summary>
	Type LifetimeType { get; }

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.ObjectBuilder2.ILifetimePolicy" />.
	/// </summary>
	/// <returns>The new instance.</returns>
	ILifetimePolicy CreateLifetimePolicy();
}
