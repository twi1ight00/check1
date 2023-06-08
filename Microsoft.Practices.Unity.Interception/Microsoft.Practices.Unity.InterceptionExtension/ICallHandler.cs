namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Handlers implement this interface and are called for each
/// invocation of the pipelines that they're included in.
/// </summary>
public interface ICallHandler
{
	/// <summary>
	/// Order in which the handler will be executed
	/// </summary>
	int Order { get; set; }

	/// <summary>
	/// Implement this method to execute your handler processing.
	/// </summary>
	/// <param name="input">Inputs to the current call to the target.</param>
	/// <param name="getNext">Delegate to execute to get the next delegate in the handler
	/// chain.</param>
	/// <returns>Return value from the target.</returns>
	IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext);
}
