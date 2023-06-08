namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// This delegate type is the type that points to the next
/// method to execute in the current pipeline.
/// </summary>
/// <param name="input">Inputs to the current method call.</param>
/// <param name="getNext">Delegate to get the next handler in the chain.</param>
/// <returns>Return from the next method in the chain.</returns>
public delegate IMethodReturn InvokeHandlerDelegate(IMethodInvocation input, GetNextHandlerDelegate getNext);
