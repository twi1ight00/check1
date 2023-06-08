using System;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Event argument class for the <see cref="E:Microsoft.Practices.Unity.ExtensionContext.RegisteringInstance" /> event.
/// </summary>
public class RegisterInstanceEventArgs : NamedEventArgs
{
	private Type registeredType;

	private object instance;

	private LifetimeManager lifetimeManager;

	/// <summary>
	/// Type of instance being registered.
	/// </summary>
	/// <value>
	/// Type of instance being registered.
	/// </value>
	public Type RegisteredType
	{
		get
		{
			return registeredType;
		}
		set
		{
			registeredType = value;
		}
	}

	/// <summary>
	/// Instance object being registered.
	/// </summary>
	/// <value>Instance object being registered</value>
	public object Instance
	{
		get
		{
			return instance;
		}
		set
		{
			instance = value;
		}
	}

	/// <summary>
	/// <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls ownership of
	/// this instance.
	/// </summary>
	public LifetimeManager LifetimeManager
	{
		get
		{
			return lifetimeManager;
		}
		set
		{
			lifetimeManager = value;
		}
	}

	/// <summary>
	/// Create a default <see cref="T:Microsoft.Practices.Unity.RegisterInstanceEventArgs" /> instance.
	/// </summary>
	public RegisterInstanceEventArgs()
	{
	}

	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.Unity.RegisterInstanceEventArgs" /> instance initialized with the given arguments.
	/// </summary>
	/// <param name="registeredType">Type of instance being registered.</param>
	/// <param name="instance">The instance object itself.</param>
	/// <param name="name">Name to register under, null if default registration.</param>
	/// <param name="lifetimeManager"><see cref="P:Microsoft.Practices.Unity.RegisterInstanceEventArgs.LifetimeManager" /> object that handles how
	/// the instance will be owned.</param>
	public RegisterInstanceEventArgs(Type registeredType, object instance, string name, LifetimeManager lifetimeManager)
		: base(name)
	{
		this.registeredType = registeredType;
		this.instance = instance;
		this.lifetimeManager = lifetimeManager;
	}
}
