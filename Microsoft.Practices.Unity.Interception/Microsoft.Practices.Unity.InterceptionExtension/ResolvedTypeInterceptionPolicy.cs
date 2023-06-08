using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptionPolicy" /> that will
/// resolve the interceptor through the container.
/// </summary>
public class ResolvedTypeInterceptionPolicy : ITypeInterceptionPolicy, IBuilderPolicy
{
	private readonly NamedTypeBuildKey buildKey;

	/// <summary>
	/// Cache for proxied type.
	/// </summary>
	public Type ProxyType { get; set; }

	/// <summary>
	/// construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ResolvedTypeInterceptionPolicy" /> that
	/// will resolve the interceptor with the given <paramref name="buildKey" />.
	/// </summary>
	/// <param name="buildKey">The build key to use to resolve.</param>
	public ResolvedTypeInterceptionPolicy(NamedTypeBuildKey buildKey)
	{
		this.buildKey = buildKey;
	}

	/// <summary>
	/// Interceptor to use to create type proxy
	/// </summary>
	/// <param name="context">Context for current build operation.</param>
	public ITypeInterceptor GetInterceptor(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		return (ITypeInterceptor)context.NewBuildUp(buildKey);
	}
}
