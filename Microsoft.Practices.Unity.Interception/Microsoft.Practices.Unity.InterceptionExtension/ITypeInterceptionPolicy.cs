using System;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Interface that controls when and how types get intercepted.
/// </summary>
public interface ITypeInterceptionPolicy : IBuilderPolicy
{
	/// <summary>
	/// Cache for proxied type.
	/// </summary>
	Type ProxyType { get; set; }

	/// <summary>
	/// Interceptor to use to create type proxy
	/// </summary>
	/// <param name="context">Context for current build operation.</param>
	ITypeInterceptor GetInterceptor(IBuilderContext context);
}
