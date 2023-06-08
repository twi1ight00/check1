using System;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Implementation of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptionPolicy" /> that returns a precreated
/// interceptor object.
/// </summary>
public class FixedTypeInterceptionPolicy : ITypeInterceptionPolicy, IBuilderPolicy
{
	private readonly ITypeInterceptor interceptor;

	/// <summary>
	/// Cache for proxied type.
	/// </summary>
	public Type ProxyType { get; set; }

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.FixedTypeInterceptionPolicy" /> that
	/// uses the given <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptor" />.
	/// </summary>
	/// <param name="interceptor">Interceptor to use.</param>
	public FixedTypeInterceptionPolicy(ITypeInterceptor interceptor)
	{
		this.interceptor = interceptor;
	}

	/// <summary>
	/// Interceptor to use to create type proxy
	/// </summary>
	/// <param name="context">Context for current build operation.</param>
	public ITypeInterceptor GetInterceptor(IBuilderContext context)
	{
		return interceptor;
	}
}
