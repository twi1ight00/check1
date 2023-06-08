using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInstanceInterceptionPolicy" /> that will
/// resolve the interceptor through the container.
/// </summary>
public class ResolvedInstanceInterceptionPolicy : IInstanceInterceptionPolicy, IBuilderPolicy
{
	private readonly NamedTypeBuildKey buildKey;

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ResolvedInstanceInterceptionPolicy" /> that
	/// will resolve the interceptor using the given build key.
	/// </summary>
	/// <param name="buildKey">build key to resolve.</param>
	public ResolvedInstanceInterceptionPolicy(NamedTypeBuildKey buildKey)
	{
		this.buildKey = buildKey;
	}

	/// <summary>
	/// Interceptor to use.
	/// </summary>
	/// <param name="context">Context for current build operation.</param>
	public IInstanceInterceptor GetInterceptor(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		return (IInstanceInterceptor)context.NewBuildUp(buildKey);
	}
}
