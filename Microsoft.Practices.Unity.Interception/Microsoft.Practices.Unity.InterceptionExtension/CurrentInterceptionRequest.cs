using System;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A simple data holder class used to store information about the current
/// interception operation that's being set up. Useful for creating behaviors
/// that need to know this stuff (especially the PIAB behavior).
/// </summary>
public class CurrentInterceptionRequest
{
	/// <summary>
	/// <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptor" /> that will be used to
	/// create the intercepting type or proxy.
	/// </summary>
	public IInterceptor Interceptor { get; set; }

	/// <summary>
	/// Type that interception was requested on.
	/// </summary>
	public Type TypeToIntercept { get; set; }

	/// <summary>
	/// Type of the object that will actually be intercepted.
	/// </summary>
	public Type ImplementationType { get; set; }

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.CurrentInterceptionRequest" /> that
	/// stores the given <paramref name="interceptor" />,
	/// <paramref name="typeToIntercept" />, and <paramref name="implementationType" />.
	/// </summary>
	/// <param name="interceptor"><see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptor" /> that will be used to
	/// create the intercepting type or proxy.</param>
	/// <param name="typeToIntercept">Type that interception was requested on.</param>
	/// <param name="implementationType">Type of the object that will actually be intercepted.</param>
	public CurrentInterceptionRequest(IInterceptor interceptor, Type typeToIntercept, Type implementationType)
	{
		Interceptor = interceptor;
		TypeToIntercept = typeToIntercept;
		ImplementationType = implementationType;
	}
}
