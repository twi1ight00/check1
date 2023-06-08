using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderStrategy" /> that intercepts objects
/// in the build chain by creating a proxy object.
/// </summary>
public class InstanceInterceptionStrategy : BuilderStrategy
{
	/// <summary>
	/// Called during the chain of responsibility for a build operation. The
	/// PostBuildUp method is called when the chain has finished the PreBuildUp
	/// phase and executes in reverse order from the PreBuildUp calls.
	/// </summary>
	/// <param name="context">Context of the build operation.</param>
	public override void PostBuildUp(IBuilderContext context)
	{
		if (context.Existing is IInterceptingProxy)
		{
			return;
		}
		IInstanceInterceptionPolicy instanceInterceptionPolicy = FindInterceptionPolicy<IInstanceInterceptionPolicy>(context, probeOriginalKey: true);
		if (instanceInterceptionPolicy == null)
		{
			return;
		}
		IInstanceInterceptor interceptor = instanceInterceptionPolicy.GetInterceptor(context);
		IInterceptionBehaviorsPolicy interceptionBehaviorsPolicy = FindInterceptionPolicy<IInterceptionBehaviorsPolicy>(context, probeOriginalKey: true);
		if (interceptionBehaviorsPolicy != null)
		{
			IAdditionalInterfacesPolicy additionalInterfacesPolicy = FindInterceptionPolicy<IAdditionalInterfacesPolicy>(context, probeOriginalKey: false);
			IEnumerable<Type> additionalInterfaces = ((additionalInterfacesPolicy != null) ? additionalInterfacesPolicy.AdditionalInterfaces : Type.EmptyTypes);
			Type type = context.OriginalBuildKey.Type;
			Type type2 = context.Existing.GetType();
			IInterceptionBehavior[] array = interceptionBehaviorsPolicy.GetEffectiveBehaviors(context, interceptor, type, type2).ToArray();
			if (array.Length > 0)
			{
				context.Existing = Intercept.ThroughProxyWithAdditionalInterfaces(type, context.Existing, interceptor, array, additionalInterfaces);
			}
		}
	}

	private static T FindInterceptionPolicy<T>(IBuilderContext context, bool probeOriginalKey) where T : class, IBuilderPolicy
	{
		Type type = context.BuildKey.Type;
		T val = context.Policies.Get<T>(context.BuildKey, localOnly: false) ?? context.Policies.Get<T>(type, localOnly: false);
		if (val != null)
		{
			return val;
		}
		if (!probeOriginalKey)
		{
			return null;
		}
		Type type2 = context.OriginalBuildKey.Type;
		return context.Policies.Get<T>(context.OriginalBuildKey, localOnly: false) ?? context.Policies.Get<T>(type2, localOnly: false);
	}
}
