namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuildPlanPolicy" /> that runs the
/// given delegate to execute the plan.
/// </summary>
internal class DynamicMethodBuildPlan : IBuildPlanPolicy, IBuilderPolicy
{
	private DynamicBuildPlanMethod planMethod;

	public DynamicMethodBuildPlan(DynamicBuildPlanMethod planMethod)
	{
		this.planMethod = planMethod;
	}

	public void BuildUp(IBuilderContext context)
	{
		planMethod(context);
	}
}
