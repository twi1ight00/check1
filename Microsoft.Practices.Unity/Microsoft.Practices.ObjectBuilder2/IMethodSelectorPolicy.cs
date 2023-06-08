using System.Collections.Generic;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that will examine the given
/// types and return a sequence of <see cref="T:System.Reflection.MethodInfo" /> objects
/// that should be called as part of building the object.
/// </summary>
public interface IMethodSelectorPolicy : IBuilderPolicy
{
	/// <summary>
	/// Return the sequence of methods to call while building the target object.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>Sequence of methods to call.</returns>
	IEnumerable<SelectedMethod> SelectMethods(IBuilderContext context, IPolicyList resolverPolicyDestination);
}
