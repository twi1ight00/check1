using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Interceptor that performs policy injection.
/// </summary>
public class PolicyInjectionBehavior : IInterceptionBehavior
{
	private readonly PipelineManager pipelineManager;

	/// <summary>
	/// Returns a flag indicating if this behavior will actually do anything when invoked.
	/// </summary>
	/// <remarks>This is used to optimize interception. If the behaviors won't actually
	/// do anything (for example, PIAB where no policies match) then the interception
	/// mechanism can be skipped completely.</remarks>
	public bool WillExecute => pipelineManager != null;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyInjectionBehavior" /> with a pipeline manager.
	/// </summary>
	/// <param name="pipelineManager">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PipelineManager" /> for the new instance.</param>
	public PolicyInjectionBehavior(PipelineManager pipelineManager)
	{
		this.pipelineManager = pipelineManager;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyInjectionBehavior" /> with the given information
	/// about what's being intercepted and the current set of injection policies.
	/// </summary>
	/// <param name="interceptionRequest">Information about what will be injected.</param>
	/// <param name="policies">Current injection policies.</param>
	/// <param name="container">Unity container that can be used to resolve call handlers.</param>
	public PolicyInjectionBehavior(CurrentInterceptionRequest interceptionRequest, InjectionPolicy[] policies, IUnityContainer container)
	{
		PolicySet policySet = new PolicySet(policies);
		bool flag = false;
		PipelineManager pipelineManager = new PipelineManager();
		foreach (MethodImplementationInfo interceptableMethod in interceptionRequest.Interceptor.GetInterceptableMethods(interceptionRequest.TypeToIntercept, interceptionRequest.ImplementationType))
		{
			bool flag2 = pipelineManager.InitializePipeline(interceptableMethod, policySet.GetHandlersFor(interceptableMethod, container));
			flag = flag || flag2;
		}
		this.pipelineManager = (flag ? pipelineManager : null);
	}

	/// <summary>
	/// Applies the policy injection handlers configured for the invoked method.
	/// </summary>
	/// <param name="input">Inputs to the current call to the target.</param>
	/// <param name="getNext">Delegate to execute to get the next delegate in the handler
	/// chain.</param>
	/// <returns>Return value from the target.</returns>
	public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
	{
		Guard.ArgumentNotNull(input, "input");
		Guard.ArgumentNotNull(getNext, "getNext");
		HandlerPipeline pipeline = GetPipeline(input.MethodBase);
		return pipeline.Invoke(input, delegate(IMethodInvocation policyInjectionInput, GetNextHandlerDelegate policyInjectionInputGetNext)
		{
			try
			{
				return getNext()(policyInjectionInput, getNext);
			}
			catch (TargetInvocationException ex)
			{
				return policyInjectionInput.CreateExceptionMethodReturn(ex.InnerException);
			}
		});
	}

	private HandlerPipeline GetPipeline(MethodBase method)
	{
		return pipelineManager.GetPipeline(method);
	}

	/// <summary>
	/// Returns the interfaces required by the behavior for the objects it intercepts.
	/// </summary>
	/// <returns>An empty array of interfaces.</returns>
	public IEnumerable<Type> GetRequiredInterfaces()
	{
		return Type.EmptyTypes;
	}
}
