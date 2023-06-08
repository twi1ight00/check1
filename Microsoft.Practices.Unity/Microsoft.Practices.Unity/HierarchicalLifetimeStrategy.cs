using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A strategy that handles Hierarchical lifetimes across a set of parent/child
/// containers.
/// </summary>
public class HierarchicalLifetimeStrategy : BuilderStrategy
{
	/// <summary>
	/// Called during the chain of responsibility for a build operation. The
	/// PreBuildUp method is called when the chain is being executed in the
	/// forward direction.
	/// </summary>
	/// <param name="context">Context of the build operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		IPolicyList containingPolicyList;
		ILifetimePolicy lifetimePolicy = context.PersistentPolicies.Get<ILifetimePolicy>(context.BuildKey, out containingPolicyList);
		if (lifetimePolicy is HierarchicalLifetimeManager && !object.ReferenceEquals(containingPolicyList, context.PersistentPolicies))
		{
			HierarchicalLifetimeManager hierarchicalLifetimeManager = new HierarchicalLifetimeManager();
			hierarchicalLifetimeManager.InUse = true;
			HierarchicalLifetimeManager hierarchicalLifetimeManager2 = hierarchicalLifetimeManager;
			context.PersistentPolicies.Set((ILifetimePolicy)hierarchicalLifetimeManager2, (object)context.BuildKey);
			context.Lifetime.Add(hierarchicalLifetimeManager2);
		}
	}
}
