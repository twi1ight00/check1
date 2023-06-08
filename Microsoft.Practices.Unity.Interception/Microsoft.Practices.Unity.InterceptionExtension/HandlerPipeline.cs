using System.Collections.Generic;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// The HandlerPipeline class encapsulates a list of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" />s
/// and manages calling them in the proper order with the right inputs.
/// </summary>
public class HandlerPipeline
{
	private readonly List<ICallHandler> handlers;

	/// <summary>
	/// Get the number of handlers in this pipeline.
	/// </summary>
	public int Count => handlers.Count;

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.HandlerPipeline" /> with an empty pipeline.
	/// </summary>
	public HandlerPipeline()
	{
		handlers = new List<ICallHandler>();
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.HandlerPipeline" /> with the given collection
	/// of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" />s.
	/// </summary>
	/// <param name="handlers">Collection of handlers to add to the pipeline.</param>
	public HandlerPipeline(IEnumerable<ICallHandler> handlers)
	{
		this.handlers = new List<ICallHandler>(handlers);
	}

	/// <summary>
	/// Execute the pipeline with the given input.
	/// </summary>
	/// <param name="input">Input to the method call.</param>
	/// <param name="target">The ultimate target of the call.</param>
	/// <returns>Return value from the pipeline.</returns>
	public IMethodReturn Invoke(IMethodInvocation input, InvokeHandlerDelegate target)
	{
		if (handlers.Count == 0)
		{
			return target(input, null);
		}
		int handlerIndex = 0;
		return handlers[0].Invoke(input, delegate
		{
			handlerIndex++;
			return (handlerIndex < handlers.Count) ? new InvokeHandlerDelegate(handlers[handlerIndex].Invoke) : target;
		});
	}
}
