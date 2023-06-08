using System;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehaviorsPolicy" /> that accumulates a sequence of 
/// <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> instances for an intercepted object.
/// </summary>
public class InterceptionBehaviorsPolicy : IInterceptionBehaviorsPolicy, IBuilderPolicy
{
	private readonly List<NamedTypeBuildKey> behaviorKeys = new List<NamedTypeBuildKey>();

	/// <summary>
	/// Get the set of <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> that can be used to resolve the
	/// behaviors.
	/// </summary>
	public IEnumerable<NamedTypeBuildKey> BehaviorKeys => behaviorKeys;

	/// <summary>
	/// Get the set of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> object to be used for the given type and
	/// interceptor.
	/// </summary>
	/// <remarks>
	/// This method will return a sequence of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" />s. These behaviors will
	/// only be included if their <see cref="P:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior.WillExecute" /> properties are true.
	/// </remarks>
	/// <param name="context">Context for the current build operation.</param>
	/// <param name="interceptor">Interceptor that will be used to invoke the behavior.</param>
	/// <param name="typeToIntercept">Type that interception was requested on.</param>
	/// <param name="implementationType">Type that implements the interception.</param>
	/// <returns></returns>
	public IEnumerable<IInterceptionBehavior> GetEffectiveBehaviors(IBuilderContext context, IInterceptor interceptor, Type typeToIntercept, Type implementationType)
	{
		CurrentInterceptionRequest interceptionRequest = new CurrentInterceptionRequest(interceptor, typeToIntercept, implementationType);
		foreach (NamedTypeBuildKey key in BehaviorKeys)
		{
			yield return (IInterceptionBehavior)context.NewBuildUp(key, delegate(IBuilderContext childContext)
			{
				childContext.AddResolverOverrides(new DependencyOverride<CurrentInterceptionRequest>(interceptionRequest));
			});
		}
	}

	internal void AddBehaviorKey(NamedTypeBuildKey key)
	{
		behaviorKeys.Add(key);
	}

	internal static InterceptionBehaviorsPolicy GetOrCreate(IPolicyList policies, Type typeToCreate, string name)
	{
		NamedTypeBuildKey buildKey = new NamedTypeBuildKey(typeToCreate, name);
		IInterceptionBehaviorsPolicy interceptionBehaviorsPolicy = policies.GetNoDefault<IInterceptionBehaviorsPolicy>(buildKey, localOnly: false);
		if (interceptionBehaviorsPolicy == null || !(interceptionBehaviorsPolicy is InterceptionBehaviorsPolicy))
		{
			interceptionBehaviorsPolicy = new InterceptionBehaviorsPolicy();
			policies.Set(interceptionBehaviorsPolicy, buildKey);
		}
		return (InterceptionBehaviorsPolicy)interceptionBehaviorsPolicy;
	}
}
