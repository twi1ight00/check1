using System;
using System.Collections.Generic;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Interface defining the behavior of the Unity dependency injection container.
/// </summary>
public interface IUnityContainer : IDisposable
{
	/// <summary>
	/// The parent of this container.
	/// </summary>
	/// <value>The parent container, or null if this container doesn't have one.</value>
	IUnityContainer Parent { get; }

	/// <summary>
	/// Get a sequence of <see cref="T:Microsoft.Practices.Unity.ContainerRegistration" /> that describe the current state
	/// of the container.
	/// </summary>
	IEnumerable<ContainerRegistration> Registrations { get; }

	/// <summary>
	/// Register a type mapping with the container, where the created instances will use
	/// the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <param name="from"><see cref="T:System.Type" /> that will be requested.</param>
	/// <param name="to"><see cref="T:System.Type" /> that will actually be returned.</param>
	/// <param name="name">Name to use for registration, null if a default registration.</param>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the returned instance.</param>
	/// <param name="injectionMembers">Injection configuration objects.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.Unity.UnityContainer" /> object that this method was called on (this in C#, Me in Visual Basic).</returns>
	IUnityContainer RegisterType(Type from, Type to, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers);

	/// <summary>
	/// Register an instance with the container.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Instance registration is much like setting a type as a singleton, except that instead
	/// of the container creating the instance the first time it is requested, the user
	/// creates the instance ahead of type and adds that instance to the container.
	/// </para>
	/// </remarks>
	/// <param name="t">Type of instance to register (may be an implemented interface instead of the full type).</param>
	/// <param name="instance">Object to returned.</param>
	/// <param name="name">Name for registration.</param>
	/// <param name="lifetime">
	/// <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> object that controls how this instance will be managed by the container.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.Unity.UnityContainer" /> object that this method was called on (this in C#, Me in Visual Basic).</returns>
	IUnityContainer RegisterInstance(Type t, string name, object instance, LifetimeManager lifetime);

	/// <summary>
	/// Resolve an instance of the requested type with the given name from the container.
	/// </summary>
	/// <param name="t"><see cref="T:System.Type" /> of object to get from the container.</param>
	/// <param name="name">Name of the object to retrieve.</param>
	/// <param name="resolverOverrides">Any overrides for the resolve call.</param>
	/// <returns>The retrieved object.</returns>
	object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides);

	/// <summary>
	/// Return instances of all registered types requested.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This method is useful if you've registered multiple types with the same
	/// <see cref="T:System.Type" /> but different names.
	/// </para>
	/// <para>
	/// Be aware that this method does NOT return an instance for the default (unnamed) registration.
	/// </para>
	/// </remarks>
	/// <param name="t">The type requested.</param>
	/// <param name="resolverOverrides">Any overrides for the resolve calls.</param>
	/// <returns>Set of objects of type <paramref name="t" />.</returns>
	IEnumerable<object> ResolveAll(Type t, params ResolverOverride[] resolverOverrides);

	/// <summary>
	/// Run an existing object through the container and perform injection on it.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This method is useful when you don't control the construction of an
	/// instance (ASP.NET pages or objects created via XAML, for instance)
	/// but you still want properties and other injection performed.
	/// </para></remarks>
	/// <param name="t"><see cref="T:System.Type" /> of object to perform injection on.</param>
	/// <param name="existing">Instance to build up.</param>
	/// <param name="name">name to use when looking up the typemappings and other configurations.</param>
	/// <param name="resolverOverrides">Any overrides for the resolve calls.</param>
	/// <returns>The resulting object. By default, this will be <paramref name="existing" />, but
	/// container extensions may add things like automatic proxy creation which would
	/// cause this to return a different object (but still type compatible with <paramref name="t" />).</returns>
	object BuildUp(Type t, object existing, string name, params ResolverOverride[] resolverOverrides);

	/// <summary>
	/// Run an existing object through the container, and clean it up.
	/// </summary>
	/// <param name="o">The object to tear down.</param>
	void Teardown(object o);

	/// <summary>
	/// Add an extension object to the container.
	/// </summary>
	/// <param name="extension"><see cref="T:Microsoft.Practices.Unity.UnityContainerExtension" /> to add.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.Unity.UnityContainer" /> object that this method was called on (this in C#, Me in Visual Basic).</returns>
	IUnityContainer AddExtension(UnityContainerExtension extension);

	/// <summary>
	/// Resolve access to a configuration interface exposed by an extension.
	/// </summary>
	/// <remarks>Extensions can expose configuration interfaces as well as adding
	/// strategies and policies to the container. This method walks the list of
	/// added extensions and returns the first one that implements the requested type.
	/// </remarks>
	/// <param name="configurationInterface"><see cref="T:System.Type" /> of configuration interface required.</param>
	/// <returns>The requested extension's configuration interface, or null if not found.</returns>
	object Configure(Type configurationInterface);

	/// <summary>
	/// Remove all installed extensions from this container.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This method removes all extensions from the container, including the default ones
	/// that implement the out-of-the-box behavior. After this method, if you want to use
	/// the container again you will need to either readd the default extensions or replace
	/// them with your own.
	/// </para>
	/// <para>
	/// The registered instances and singletons that have already been set up in this container
	/// do not get removed.
	/// </para>
	/// </remarks>
	/// <returns>The <see cref="T:Microsoft.Practices.Unity.UnityContainer" /> object that this method was called on (this in C#, Me in Visual Basic).</returns>
	IUnityContainer RemoveAllExtensions();

	/// <summary>
	/// Create a child container.
	/// </summary>
	/// <remarks>
	/// A child container shares the parent's configuration, but can be configured with different
	/// settings or lifetime.</remarks>
	/// <returns>The new child container.</returns>
	IUnityContainer CreateChildContainer();
}
