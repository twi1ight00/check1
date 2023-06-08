using System;

namespace Microsoft.Practices.Unity.StaticFactory;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.UnityContainerExtension" /> that lets you register a
/// delegate with the container to create an object, rather than calling
/// the object's constructor.
/// </summary>
[Obsolete("Use RegisterType<TInterface, TImpl>(new InjectionFactory(...)) instead of the extension's methods.")]
public class StaticFactoryExtension : UnityContainerExtension, IStaticFactoryConfiguration, IUnityContainerExtensionConfigurator
{
	/// <summary>
	/// Initialize this extension. This particular extension requires no
	/// initialization work.
	/// </summary>
	protected override void Initialize()
	{
	}

	/// <summary>
	/// Register the given factory delegate to be called when the container is
	/// asked to resolve <typeparamref name="TTypeToBuild" /> and <paramref name="name" />.
	/// </summary>
	/// <typeparam name="TTypeToBuild">Type that will be requested from the container.</typeparam>
	/// <param name="name">The name that will be used when requesting to resolve this type.</param>
	/// <param name="factoryMethod">Delegate to invoke to create the instance.</param>
	/// <returns>The container extension object this method was invoked on.</returns>
	public IStaticFactoryConfiguration RegisterFactory<TTypeToBuild>(string name, Func<IUnityContainer, object> factoryMethod)
	{
		base.Container.RegisterType<TTypeToBuild>(name, new InjectionMember[1]
		{
			new InjectionFactory(factoryMethod)
		});
		return this;
	}

	/// <summary>
	/// Register the given factory delegate to be called when the container is
	/// asked to resolve <typeparamref name="TTypeToBuild" />.
	/// </summary>
	/// <typeparam name="TTypeToBuild">Type that will be requested from the container.</typeparam>
	/// <param name="factoryMethod">Delegate to invoke to create the instance.</param>
	/// <returns>The container extension object this method was invoked on.</returns>
	public IStaticFactoryConfiguration RegisterFactory<TTypeToBuild>(Func<IUnityContainer, object> factoryMethod)
	{
		return RegisterFactory<TTypeToBuild>(null, factoryMethod);
	}
}
