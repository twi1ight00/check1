using System;

namespace Microsoft.Practices.Unity;

/// <summary>
/// Event argument class for the <see cref="E:Microsoft.Practices.Unity.ExtensionContext.Registering" /> event.
/// </summary>
public class RegisterEventArgs : NamedEventArgs
{
	private Type typeFrom;

	private Type typeTo;

	private LifetimeManager lifetimeManager;

	/// <summary>
	/// Type to map from.
	/// </summary>
	public Type TypeFrom
	{
		get
		{
			return typeFrom;
		}
		set
		{
			typeFrom = value;
		}
	}

	/// <summary>
	/// Type to map to.
	/// </summary>
	public Type TypeTo
	{
		get
		{
			return typeTo;
		}
		set
		{
			typeTo = value;
		}
	}

	/// <summary>
	/// <see cref="P:Microsoft.Practices.Unity.RegisterEventArgs.LifetimeManager" /> to manage instances.
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
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.RegisterEventArgs" />.
	/// </summary>
	/// <param name="typeFrom">Type to map from.</param>
	/// <param name="typeTo">Type to map to.</param>
	/// <param name="name">Name for the registration.</param>
	/// <param name="lifetimeManager"><see cref="P:Microsoft.Practices.Unity.RegisterEventArgs.LifetimeManager" /> to manage instances.</param>
	public RegisterEventArgs(Type typeFrom, Type typeTo, string name, LifetimeManager lifetimeManager)
		: base(name)
	{
		this.typeFrom = typeFrom;
		this.typeTo = typeTo;
		this.lifetimeManager = lifetimeManager;
	}
}
