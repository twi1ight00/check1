using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderStrategy" /> implementation that uses
/// a <see cref="T:Microsoft.Practices.ObjectBuilder2.ILifetimePolicy" /> to figure out if an object
/// has already been created and to update or remove that
/// object from some backing store.
/// </summary>
public class LifetimeStrategy : BuilderStrategy
{
	/// <summary>
	/// Called during the chain of responsibility for a build operation. The
	/// PreBuildUp method is called when the chain is being executed in the
	/// forward direction.
	/// </summary>
	/// <param name="context">Context of the build operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		if (context.Existing == null)
		{
			ILifetimePolicy lifetimePolicy = GetLifetimePolicy(context);
			if (lifetimePolicy is IRequiresRecovery recovery)
			{
				context.RecoveryStack.Add(recovery);
			}
			object value = lifetimePolicy.GetValue();
			if (value != null)
			{
				context.Existing = value;
				context.BuildComplete = true;
			}
		}
	}

	/// <summary>
	/// Called during the chain of responsibility for a build operation. The
	/// PostBuildUp method is called when the chain has finished the PreBuildUp
	/// phase and executes in reverse order from the PreBuildUp calls.
	/// </summary>
	/// <param name="context">Context of the build operation.</param>
	public override void PostBuildUp(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		ILifetimePolicy lifetimePolicy = GetLifetimePolicy(context);
		lifetimePolicy.SetValue(context.Existing);
	}

	private static ILifetimePolicy GetLifetimePolicy(IBuilderContext context)
	{
		ILifetimePolicy lifetimePolicy = context.Policies.GetNoDefault<ILifetimePolicy>(context.BuildKey, localOnly: false);
		if (lifetimePolicy == null && context.BuildKey.Type.IsGenericType)
		{
			lifetimePolicy = GetLifetimePolicyForGenericType(context);
		}
		if (lifetimePolicy == null)
		{
			lifetimePolicy = new TransientLifetimeManager();
			context.PersistentPolicies.Set(lifetimePolicy, context.BuildKey);
		}
		return lifetimePolicy;
	}

	private static ILifetimePolicy GetLifetimePolicyForGenericType(IBuilderContext context)
	{
		Type type = context.BuildKey.Type;
		object buildKey = new NamedTypeBuildKey(type.GetGenericTypeDefinition(), context.BuildKey.Name);
		IPolicyList containingPolicyList;
		ILifetimeFactoryPolicy lifetimeFactoryPolicy = context.Policies.Get<ILifetimeFactoryPolicy>(buildKey, out containingPolicyList);
		if (lifetimeFactoryPolicy != null)
		{
			ILifetimePolicy lifetimePolicy = lifetimeFactoryPolicy.CreateLifetimePolicy();
			containingPolicyList.Set(lifetimePolicy, context.BuildKey);
			return lifetimePolicy;
		}
		return null;
	}
}
