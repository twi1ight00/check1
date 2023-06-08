using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace Microsoft.Practices.Unity;

/// <summary>
/// The <see cref="T:Microsoft.Practices.Unity.ExtensionContext" /> class provides the means for extension objects
/// to manipulate the internal state of the <see cref="T:Microsoft.Practices.Unity.UnityContainer" />.
/// </summary>
public abstract class ExtensionContext
{
	/// <summary>
	/// The container that this context is associated with.
	/// </summary>
	/// <value>The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> object.</value>
	public abstract IUnityContainer Container { get; }

	/// <summary>
	/// The strategies this container uses.
	/// </summary>
	/// <value>The <see cref="T:Microsoft.Practices.ObjectBuilder2.StagedStrategyChain`1" /> that the container uses to build objects.</value>
	public abstract StagedStrategyChain<UnityBuildStage> Strategies { get; }

	/// <summary>
	/// The strategies this container uses to construct build plans.
	/// </summary>
	/// <value>The <see cref="T:Microsoft.Practices.ObjectBuilder2.StagedStrategyChain`1" /> that this container uses when creating
	/// build plans.</value>
	public abstract StagedStrategyChain<UnityBuildStage> BuildPlanStrategies { get; }

	/// <summary>
	/// The policies this container uses.
	/// </summary>
	/// <remarks>The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> the that container uses to build objects.</remarks>
	public abstract IPolicyList Policies { get; }

	/// <summary>
	/// The <see cref="T:Microsoft.Practices.ObjectBuilder2.ILifetimeContainer" /> that this container uses.
	/// </summary>
	/// <value>The <see cref="T:Microsoft.Practices.ObjectBuilder2.ILifetimeContainer" /> is used to manage <see cref="T:System.IDisposable" /> objects that the container is managing.</value>
	public abstract ILifetimeContainer Lifetime { get; }

	/// <summary>
	/// This event is raised when the <see cref="M:Microsoft.Practices.Unity.IUnityContainer.RegisterType(System.Type,System.Type,System.String,Microsoft.Practices.Unity.LifetimeManager,Microsoft.Practices.Unity.InjectionMember[])" /> method,
	/// or one of its overloads, is called.
	/// </summary>
	public abstract event EventHandler<RegisterEventArgs> Registering;

	/// <summary>
	/// This event is raised when the <see cref="M:Microsoft.Practices.Unity.IUnityContainer.RegisterInstance(System.Type,System.String,System.Object,Microsoft.Practices.Unity.LifetimeManager)" /> method,
	/// or one of its overloads, is called.
	/// </summary>
	public abstract event EventHandler<RegisterInstanceEventArgs> RegisteringInstance;

	/// <summary>
	/// This event is raised when the <see cref="M:Microsoft.Practices.Unity.IUnityContainer.CreateChildContainer" /> method is called, providing 
	/// the newly created child container to extensions to act on as they see fit.
	/// </summary>
	public abstract event EventHandler<ChildContainerCreatedEventArgs> ChildContainerCreated;

	/// <summary>
	/// Store a type/name pair for later resolution.
	/// </summary>
	/// <remarks>
	/// <para>
	/// When users register type mappings (or other things) with a named key, this method
	/// allows you to register that name with the container so that when the <see cref="M:Microsoft.Practices.Unity.IUnityContainer.ResolveAll(System.Type,Microsoft.Practices.Unity.ResolverOverride[])" />
	/// method is called, that name is included in the list that is returned.
	/// </para></remarks>
	/// <param name="t"><see cref="T:System.Type" /> to register.</param>
	/// <param name="name">Name assocated with that type.</param>
	public abstract void RegisterNamedType(Type t, string name);
}
