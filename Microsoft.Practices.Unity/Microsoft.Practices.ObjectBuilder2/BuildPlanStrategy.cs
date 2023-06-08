namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.BuilderStrategy" /> that will look for a build plan
/// in the current context. If it exists, it invokes it, otherwise
/// it creates one and stores it for later, and invokes it.
/// </summary>
public class BuildPlanStrategy : BuilderStrategy
{
	/// <summary>
	/// Called during the chain of responsibility for a build operation.
	/// </summary>
	/// <param name="context">The context for the operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		IPolicyList containingPolicyList;
		IBuildPlanPolicy buildPlanPolicy = context.Policies.Get<IBuildPlanPolicy>(context.BuildKey, out containingPolicyList);
		if (buildPlanPolicy == null || buildPlanPolicy is OverriddenBuildPlanMarkerPolicy)
		{
			IPolicyList containingPolicyList2;
			IBuildPlanCreatorPolicy buildPlanCreatorPolicy = context.Policies.Get<IBuildPlanCreatorPolicy>(context.BuildKey, out containingPolicyList2);
			if (buildPlanCreatorPolicy != null)
			{
				buildPlanPolicy = buildPlanCreatorPolicy.CreatePlan(context, context.BuildKey);
				(containingPolicyList ?? containingPolicyList2).Set(buildPlanPolicy, context.BuildKey);
			}
		}
		buildPlanPolicy?.BuildUp(context);
	}
}
