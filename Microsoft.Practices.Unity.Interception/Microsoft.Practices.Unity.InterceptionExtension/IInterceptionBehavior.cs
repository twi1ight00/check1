using System;
using System.Collections.Generic;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Interception behaviors implement this interface and are called for each
/// invocation of the pipelines that they're included in.
/// </summary>
public interface IInterceptionBehavior
{
	/// <summary>
	/// Returns a flag indicating if this behavior will actually do anything when invoked.
	/// </summary>
	/// <remarks>This is used to optimize interception. If the behaviors won't actually
	/// do anything (for example, PIAB where no policies match) then the interception
	/// mechanism can be skipped completely.</remarks>
	bool WillExecute { get; }

	/// <summary>
	/// Implement this method to execute your behavior processing.
	/// </summary>
	/// <param name="input">Inputs to the current call to the target.</param>
	/// <param name="getNext">Delegate to execute to get the next delegate in the behavior chain.</param>
	/// <returns>Return value from the target.</returns>
	IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext);

	/// <summary>
	/// Returns the interfaces required by the behavior for the objects it intercepts.
	/// </summary>
	/// <returns>The required interfaces.</returns>
	IEnumerable<Type> GetRequiredInterfaces();
}
