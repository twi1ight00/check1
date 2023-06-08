using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.Unity;

/// <summary>
/// This extension supplies the default behavior of the UnityContainer API
/// by handling the context events and setting policies.
/// </summary>
public class UnityDefaultBehaviorExtension : UnityContainerExtension
{
	private class ContainerLifetimeManager : LifetimeManager
	{
		private object value;

		public override object GetValue()
		{
			return value;
		}

		public override void SetValue(object newValue)
		{
			value = newValue;
		}

		public override void RemoveValue()
		{
		}
	}

	/// <summary>
	/// Install the default container behavior into the container.
	/// </summary>
	protected override void Initialize()
	{
		base.Context.Registering += OnRegister;
		base.Context.RegisteringInstance += OnRegisterInstance;
		base.Container.RegisterInstance(base.Container, new ContainerLifetimeManager());
	}

	/// <summary>
	/// Remove the default behavior from the container.
	/// </summary>
	public override void Remove()
	{
		base.Context.Registering -= OnRegister;
		base.Context.RegisteringInstance -= OnRegisterInstance;
	}

	private void OnRegister(object sender, RegisterEventArgs e)
	{
		base.Context.RegisterNamedType(e.TypeFrom ?? e.TypeTo, e.Name);
		if (e.TypeFrom != null)
		{
			if (e.TypeFrom.IsGenericTypeDefinition && e.TypeTo.IsGenericTypeDefinition)
			{
				base.Context.Policies.Set((IBuildKeyMappingPolicy)new GenericTypeBuildKeyMappingPolicy(new NamedTypeBuildKey(e.TypeTo, e.Name)), (object)new NamedTypeBuildKey(e.TypeFrom, e.Name));
			}
			else
			{
				base.Context.Policies.Set((IBuildKeyMappingPolicy)new BuildKeyMappingPolicy(new NamedTypeBuildKey(e.TypeTo, e.Name)), (object)new NamedTypeBuildKey(e.TypeFrom, e.Name));
			}
		}
		if (e.LifetimeManager != null)
		{
			SetLifetimeManager(e.TypeTo, e.Name, e.LifetimeManager);
		}
	}

	private void OnRegisterInstance(object sender, RegisterInstanceEventArgs e)
	{
		base.Context.RegisterNamedType(e.RegisteredType, e.Name);
		SetLifetimeManager(e.RegisteredType, e.Name, e.LifetimeManager);
		NamedTypeBuildKey namedTypeBuildKey = new NamedTypeBuildKey(e.RegisteredType, e.Name);
		base.Context.Policies.Set((IBuildKeyMappingPolicy)new BuildKeyMappingPolicy(namedTypeBuildKey), (object)namedTypeBuildKey);
		if (e.LifetimeManager is SynchronizedLifetimeManager)
		{
			e.LifetimeManager.GetValue();
		}
		e.LifetimeManager.SetValue(e.Instance);
	}

	private void SetLifetimeManager(Type lifetimeType, string name, LifetimeManager lifetimeManager)
	{
		if (lifetimeManager.InUse)
		{
			throw new InvalidOperationException(Resources.LifetimeManagerInUse);
		}
		if (lifetimeType.IsGenericTypeDefinition)
		{
			LifetimeManagerFactory policy = new LifetimeManagerFactory(base.Context, lifetimeManager.GetType());
			base.Context.Policies.Set((ILifetimeFactoryPolicy)policy, (object)new NamedTypeBuildKey(lifetimeType, name));
			return;
		}
		lifetimeManager.InUse = true;
		base.Context.Policies.Set((ILifetimePolicy)lifetimeManager, (object)new NamedTypeBuildKey(lifetimeType, name));
		if (lifetimeManager is IDisposable)
		{
			base.Context.Lifetime.Add(lifetimeManager);
		}
	}
}
