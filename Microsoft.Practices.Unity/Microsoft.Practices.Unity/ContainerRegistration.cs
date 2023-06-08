using System;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Class that returns information about the types registered in a container.
/// </summary>
public class ContainerRegistration
{
	private readonly NamedTypeBuildKey buildKey;

	/// <summary>
	/// The type that was passed to the <see cref="M:Microsoft.Practices.Unity.IUnityContainer.RegisterType(System.Type,System.Type,System.String,Microsoft.Practices.Unity.LifetimeManager,Microsoft.Practices.Unity.InjectionMember[])" /> method
	/// as the "from" type, or the only type if type mapping wasn't done.
	/// </summary>
	public Type RegisteredType => buildKey.Type;

	/// <summary>
	/// The type that this registration is mapped to. If no type mapping was done, the
	/// <see cref="P:Microsoft.Practices.Unity.ContainerRegistration.RegisteredType" /> property and this one will have the same value.
	/// </summary>
	public Type MappedToType { get; private set; }

	/// <summary>
	/// Name the type was registered under. Null for default registration.
	/// </summary>
	public string Name => buildKey.Name;

	/// <summary>
	/// The registered lifetime manager instance.
	/// </summary>
	public Type LifetimeManagerType { get; private set; }

	/// <summary>
	/// The lifetime manager for this registration.
	/// </summary>
	/// <remarks>
	/// This property will be null if this registration is for an open generic.</remarks>
	public LifetimeManager LifetimeManager { get; private set; }

	internal ContainerRegistration(Type registeredType, string name, IPolicyList policies)
	{
		buildKey = new NamedTypeBuildKey(registeredType, name);
		MappedToType = GetMappedType(policies);
		LifetimeManagerType = GetLifetimeManagerType(policies);
		LifetimeManager = GetLifetimeManager(policies);
	}

	private Type GetMappedType(IPolicyList policies)
	{
		IBuildKeyMappingPolicy buildKeyMappingPolicy = policies.Get<IBuildKeyMappingPolicy>(buildKey);
		if (buildKeyMappingPolicy != null)
		{
			return buildKeyMappingPolicy.Map(buildKey, null).Type;
		}
		return buildKey.Type;
	}

	private Type GetLifetimeManagerType(IPolicyList policies)
	{
		NamedTypeBuildKey namedTypeBuildKey = new NamedTypeBuildKey(MappedToType, Name);
		ILifetimePolicy lifetimePolicy = policies.Get<ILifetimePolicy>(namedTypeBuildKey);
		if (lifetimePolicy != null)
		{
			return lifetimePolicy.GetType();
		}
		if (MappedToType.IsGenericType)
		{
			NamedTypeBuildKey namedTypeBuildKey2 = new NamedTypeBuildKey(MappedToType.GetGenericTypeDefinition(), Name);
			ILifetimeFactoryPolicy lifetimeFactoryPolicy = policies.Get<ILifetimeFactoryPolicy>(namedTypeBuildKey2);
			if (lifetimeFactoryPolicy != null)
			{
				return lifetimeFactoryPolicy.LifetimeType;
			}
		}
		return typeof(TransientLifetimeManager);
	}

	private LifetimeManager GetLifetimeManager(IPolicyList policies)
	{
		NamedTypeBuildKey namedTypeBuildKey = new NamedTypeBuildKey(MappedToType, Name);
		return (LifetimeManager)policies.Get<ILifetimePolicy>(namedTypeBuildKey);
	}
}
