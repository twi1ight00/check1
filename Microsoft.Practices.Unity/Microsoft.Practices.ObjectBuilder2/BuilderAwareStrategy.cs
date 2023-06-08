using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderStrategy" /> which will notify an object about
/// the completion of a BuildUp operation, or start of a TearDown operation.
/// </summary>
/// <remarks>
/// This strategy checks the object that is passing through the builder chain to see if it
/// implements IBuilderAware and if it does, it will call <see cref="M:Microsoft.Practices.ObjectBuilder2.IBuilderAware.OnBuiltUp(Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey)" />
/// and <see cref="M:Microsoft.Practices.ObjectBuilder2.IBuilderAware.OnTearingDown" />. This strategy is meant to be used from the
/// <see cref="F:Microsoft.Practices.ObjectBuilder2.BuilderStage.PostInitialization" /> stage.
/// </remarks>
public class BuilderAwareStrategy : BuilderStrategy
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
		if (context.Existing is IBuilderAware builderAware)
		{
			builderAware.OnBuiltUp(context.BuildKey);
		}
	}

	/// <summary>
	/// Called during the chain of responsibility for a teardown operation. The
	/// PreTearDown method is called when the chain is being executed in the
	/// forward direction.
	/// </summary>
	/// <param name="context">Context of the teardown operation.</param>
	public override void PreTearDown(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		if (context.Existing is IBuilderAware builderAware)
		{
			builderAware.OnTearingDown();
		}
	}
}
