namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// This delegate type is passed to each handler's Invoke method.
/// Call the delegate to get the next delegate to call to continue
/// the chain.
/// </summary>
/// <returns>Next delegate in the handler chain to call.</returns>
public delegate InvokeHandlerDelegate GetNextHandlerDelegate();
