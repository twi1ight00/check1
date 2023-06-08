namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that can create and return an <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuildPlanPolicy" />
/// for the given build key.
/// </summary>
public interface IBuildPlanCreatorPolicy : IBuilderPolicy
{
	/// <summary>
	/// Create a build plan using the given context and build key.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="buildKey">Current build key.</param>
	/// <returns>The build plan.</returns>
	IBuildPlanPolicy CreatePlan(IBuilderContext context, NamedTypeBuildKey buildKey);
}
