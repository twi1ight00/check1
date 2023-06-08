namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Represents a strategy for mapping build keys in the build up operation.
/// </summary>
public class BuildKeyMappingStrategy : BuilderStrategy
{
	/// <summary>
	/// Called during the chain of responsibility for a build operation.  Looks for the <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuildKeyMappingPolicy" />
	/// and if found maps the build key for the current operation.
	/// </summary>
	/// <param name="context">The context for the operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		IBuildKeyMappingPolicy buildKeyMappingPolicy = context.Policies.Get<IBuildKeyMappingPolicy>(context.BuildKey);
		if (buildKeyMappingPolicy != null)
		{
			context.BuildKey = buildKeyMappingPolicy.Map(context.BuildKey, context);
		}
	}
}
