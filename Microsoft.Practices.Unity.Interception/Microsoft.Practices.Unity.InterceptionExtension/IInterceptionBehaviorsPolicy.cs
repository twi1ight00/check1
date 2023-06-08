using System;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that returns a sequence of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> 
/// instances for an intercepted object.
/// </summary>
public interface IInterceptionBehaviorsPolicy : IBuilderPolicy
{
	/// <summary>
	/// Get the set of <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> that can be used to resolve the
	/// behaviors.
	/// </summary>
	IEnumerable<NamedTypeBuildKey> BehaviorKeys { get; }

	/// <summary>
	/// Get the set of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> object to be used for the given type and
	/// interceptor.
	/// </summary>
	/// <remarks>
	/// This method will return a sequence of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" />s. These behaviors will
	/// only be included if their <see cref="P:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior.WillExecute" /> properties are true.
	/// </remarks>
	/// <param name="context">Context for the current build operation.</param>
	/// <param name="interceptor">Interceptor that will be used to invoke the behavior.</param>
	/// <param name="typeToIntercept">Type that interception was requested on.</param>
	/// <param name="implementationType">Type that implements the interception.</param>
	/// <returns></returns>
	IEnumerable<IInterceptionBehavior> GetEffectiveBehaviors(IBuilderContext context, IInterceptor interceptor, Type typeToIntercept, Type implementationType);
}
