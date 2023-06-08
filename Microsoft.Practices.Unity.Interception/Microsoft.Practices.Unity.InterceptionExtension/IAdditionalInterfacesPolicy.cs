using System;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderPolicy" /> that returns a sequence of <see cref="T:System.Type" /> 
/// instances representing the additional interfaces for an intercepted object.
/// </summary>
public interface IAdditionalInterfacesPolicy : IBuilderPolicy
{
	/// <summary>
	/// Gets the <see cref="T:System.Type" /> instances accumulated by this policy.
	/// </summary>
	IEnumerable<Type> AdditionalInterfaces { get; }
}
