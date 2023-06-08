namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// This delegate type is passed to each interceptor's Invoke method.
/// Call the delegate to get the next delegate to call to continue
/// the chain.
/// </summary>
/// <returns>Next delegate in the interceptor chain to call.</returns>
public delegate InvokeInterceptionBehaviorDelegate GetNextInterceptionBehaviorDelegate();
