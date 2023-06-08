using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace Microsoft.Practices.Unity;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ServiceLocation.IServiceLocator" /> that wraps a Unity container.
/// </summary>
public class UnityServiceLocator : ServiceLocatorImplBase, IDisposable
{
	private IUnityContainer container;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.UnityServiceLocator" /> class for a container.
	/// </summary>
	/// <param name="container">The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> to wrap with the <see cref="T:Microsoft.Practices.ServiceLocation.IServiceLocator" />
	/// interface implementation.</param>
	public UnityServiceLocator(IUnityContainer container)
	{
		this.container = container;
		container.RegisterInstance((IServiceLocator)this, (LifetimeManager)new ExternallyControlledLifetimeManager());
	}

	/// <summary>
	/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	/// </summary>
	/// <filterpriority>2</filterpriority>
	public void Dispose()
	{
		if (container != null)
		{
			container.Dispose();
			container = null;
		}
	}

	/// <summary>
	/// When implemented by inheriting classes, this method will do the actual work of resolving
	///             the requested service instance.
	/// </summary>
	/// <param name="serviceType">Type of instance requested.</param><param name="key">Name of registered service you want. May be null.</param>
	/// <returns>
	/// The requested service instance.
	/// </returns>
	protected override object DoGetInstance(Type serviceType, string key)
	{
		if (container == null)
		{
			throw new ObjectDisposedException("container");
		}
		return container.Resolve(serviceType, key);
	}

	/// <summary>
	/// When implemented by inheriting classes, this method will do the actual work of
	///             resolving all the requested service instances.
	/// </summary>
	/// <param name="serviceType">Type of service requested.</param>
	/// <returns>
	/// Sequence of service instance objects.
	/// </returns>
	protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
	{
		if (container == null)
		{
			throw new ObjectDisposedException("container");
		}
		return container.ResolveAll(serviceType);
	}
}
