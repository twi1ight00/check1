using System;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.ILifetimeFactoryPolicy" /> that
/// creates instances of the type of the given Lifetime Manager
/// by resolving them through the container.
/// </summary>
public class LifetimeManagerFactory : ILifetimeFactoryPolicy, IBuilderPolicy
{
	private readonly ExtensionContext containerContext;

	/// <summary>
	/// The type of Lifetime manager that will be created by this factory.
	/// </summary>
	public Type LifetimeType { get; private set; }

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.LifetimeManagerFactory" /> that will
	/// return instances of the given type, creating them by
	/// resolving through the container.
	/// </summary>
	/// <param name="containerContext">Container to resolve with.</param>
	/// <param name="lifetimeType">Type of LifetimeManager to create.</param>
	public LifetimeManagerFactory(ExtensionContext containerContext, Type lifetimeType)
	{
		this.containerContext = containerContext;
		LifetimeType = lifetimeType;
	}

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.ObjectBuilder2.ILifetimePolicy" />.
	/// </summary>
	/// <returns>The new instance.</returns>
	public ILifetimePolicy CreateLifetimePolicy()
	{
		LifetimeManager lifetimeManager = (LifetimeManager)containerContext.Container.Resolve(LifetimeType);
		if (lifetimeManager is IDisposable)
		{
			containerContext.Lifetime.Add(lifetimeManager);
		}
		lifetimeManager.InUse = true;
		return lifetimeManager;
	}
}
