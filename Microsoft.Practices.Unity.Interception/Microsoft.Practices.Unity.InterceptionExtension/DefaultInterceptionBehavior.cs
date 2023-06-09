using System;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An injection member that lets you specify behaviors that should
/// apply to all instances of a type in the container regardless
/// of what name it's resolved under.
/// </summary>
public class DefaultInterceptionBehavior : InterceptionBehaviorBase
{
	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptionBehavior" /> that will
	/// supply the given interception behavior to the container.
	/// </summary>
	/// <param name="interceptionBehavior">Behavior to apply to this type.</param>
	public DefaultInterceptionBehavior(IInterceptionBehavior interceptionBehavior)
		: base(interceptionBehavior)
	{
	}

	/// <summary>
	///  Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptionBehavior" /> that will
	///  resolve the given type/name pair to get the behavior.
	/// </summary>
	/// <param name="behaviorType">Type of behavior.</param>
	/// <param name="name">Name for behavior registration.</param>
	public DefaultInterceptionBehavior(Type behaviorType, string name)
		: base(behaviorType, name)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptionBehavior" /> that will
	/// resolve the given type to get the behavior.
	/// </summary>
	/// <param name="behaviorType">Type of behavior.</param>
	public DefaultInterceptionBehavior(Type behaviorType)
		: base(behaviorType)
	{
	}

	/// <summary>
	/// Get the list of behaviors for the current type so that it can be added to.
	/// </summary>
	/// <param name="policies">Policy list.</param>
	/// <param name="implementationType">Implementation type to set behaviors for.</param>
	/// <param name="name">Name type is registered under.</param>
	/// <returns>An instance of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.InterceptionBehaviorsPolicy" />.</returns>
	protected override InterceptionBehaviorsPolicy GetBehaviorsPolicy(IPolicyList policies, Type implementationType, string name)
	{
		IInterceptionBehaviorsPolicy interceptionBehaviorsPolicy = policies.GetNoDefault<IInterceptionBehaviorsPolicy>(implementationType, localOnly: false);
		if (interceptionBehaviorsPolicy == null || !(interceptionBehaviorsPolicy is InterceptionBehaviorsPolicy))
		{
			interceptionBehaviorsPolicy = new InterceptionBehaviorsPolicy();
			policies.Set(interceptionBehaviorsPolicy, implementationType);
		}
		return (InterceptionBehaviorsPolicy)interceptionBehaviorsPolicy;
	}
}
/// <summary>
/// A generic version of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptionBehavior" /> so you
/// can give the behavior type using generic syntax.
/// </summary>
/// <typeparam name="TBehavior">Type of the behavior object to apply.</typeparam>
public class DefaultInterceptionBehavior<TBehavior> : DefaultInterceptionBehavior where TBehavior : IInterceptionBehavior
{
	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptionBehavior`1" /> instance
	/// that use the given type and name to resolve the behavior object.
	/// </summary>
	/// <param name="name">Name of the registration.</param>
	public DefaultInterceptionBehavior(string name)
		: base(typeof(TBehavior), name)
	{
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptionBehavior`1" /> instance
	/// that uses the given type to resolve the behavior object.
	/// </summary>
	public DefaultInterceptionBehavior()
		: base(typeof(TBehavior))
	{
	}
}
