using System.Collections.Generic;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// The InterceptionBehaviorPipeline class encapsulates a list of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" />s
/// and manages calling them in the proper order with the right inputs.
/// </summary>
public class InterceptionBehaviorPipeline
{
	private readonly List<IInterceptionBehavior> interceptionBehaviors;

	/// <summary>
	/// Get the number of interceptors in this pipeline.
	/// </summary>
	public int Count => interceptionBehaviors.Count;

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.HandlerPipeline" /> with an empty pipeline.
	/// </summary>
	public InterceptionBehaviorPipeline()
	{
		interceptionBehaviors = new List<IInterceptionBehavior>();
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.HandlerPipeline" /> with the given collection
	/// of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" />s.
	/// </summary>
	/// <param name="interceptionBehaviors">Collection of interception behaviors to add to the pipeline.</param>
	public InterceptionBehaviorPipeline(IEnumerable<IInterceptionBehavior> interceptionBehaviors)
	{
		Guard.ArgumentNotNull(interceptionBehaviors, "interceptionBehaviors");
		this.interceptionBehaviors = new List<IInterceptionBehavior>(interceptionBehaviors);
	}

	/// <summary>
	/// Execute the pipeline with the given input.
	/// </summary>
	/// <param name="input">Input to the method call.</param>
	/// <param name="target">The ultimate target of the call.</param>
	/// <returns>Return value from the pipeline.</returns>
	public IMethodReturn Invoke(IMethodInvocation input, InvokeInterceptionBehaviorDelegate target)
	{
		if (interceptionBehaviors.Count == 0)
		{
			return target(input, null);
		}
		int interceptorIndex = 0;
		return interceptionBehaviors[0].Invoke(input, delegate
		{
			interceptorIndex++;
			return (interceptorIndex < interceptionBehaviors.Count) ? new InvokeInterceptionBehaviorDelegate(interceptionBehaviors[interceptorIndex].Invoke) : target;
		});
	}

	/// <summary>
	/// Adds a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> to the pipeline.
	/// </summary>
	/// <param name="interceptionBehavior">The interception behavior to add.</param>
	public void Add(IInterceptionBehavior interceptionBehavior)
	{
		Guard.ArgumentNotNull(interceptionBehavior, "interceptionBehavior");
		interceptionBehaviors.Add(interceptionBehavior);
	}
}
