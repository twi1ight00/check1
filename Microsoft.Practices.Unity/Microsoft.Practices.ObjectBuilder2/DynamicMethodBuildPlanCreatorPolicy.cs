namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuildPlanCreatorPolicy" /> implementation
/// that constructs a build plan via dynamic IL emission.
/// </summary>
public class DynamicMethodBuildPlanCreatorPolicy : IBuildPlanCreatorPolicy, IBuilderPolicy
{
	private IStagedStrategyChain strategies;

	/// <summary>
	/// Construct a <see cref="T:Microsoft.Practices.ObjectBuilder2.DynamicMethodBuildPlanCreatorPolicy" /> that
	/// uses the given strategy chain to construct the build plan.
	/// </summary>
	/// <param name="strategies">The strategy chain.</param>
	public DynamicMethodBuildPlanCreatorPolicy(IStagedStrategyChain strategies)
	{
		this.strategies = strategies;
	}

	/// <summary>
	/// Construct a build plan.
	/// </summary>
	/// <param name="context">The current build context.</param>
	/// <param name="buildKey">The current build key.</param>
	/// <returns>The created build plan.</returns>
	public IBuildPlanPolicy CreatePlan(IBuilderContext context, NamedTypeBuildKey buildKey)
	{
		IDynamicBuilderMethodCreatorPolicy builderMethodCreator = context.Policies.Get<IDynamicBuilderMethodCreatorPolicy>(context.BuildKey);
		DynamicBuildPlanGenerationContext dynamicBuildPlanGenerationContext = new DynamicBuildPlanGenerationContext(buildKey.Type, builderMethodCreator);
		IBuilderContext context2 = GetContext(context, buildKey, dynamicBuildPlanGenerationContext);
		context2.Strategies.ExecuteBuildUp(context2);
		return new DynamicMethodBuildPlan(dynamicBuildPlanGenerationContext.GetBuildMethod());
	}

	private IBuilderContext GetContext(IBuilderContext originalContext, NamedTypeBuildKey buildKey, DynamicBuildPlanGenerationContext ilContext)
	{
		return new BuilderContext(strategies.MakeStrategyChain(), originalContext.Lifetime, originalContext.PersistentPolicies, originalContext.Policies, buildKey, ilContext);
	}
}
