namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// This interface is implemented by all proxy objects, type or instance based.
/// It allows for adding interception behaviors.
/// </summary>
public interface IInterceptingProxy
{
	/// <summary>
	/// Adds a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> to the proxy.
	/// </summary>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> to add.</param>
	void AddInterceptionBehavior(IInterceptionBehavior interceptor);
}
