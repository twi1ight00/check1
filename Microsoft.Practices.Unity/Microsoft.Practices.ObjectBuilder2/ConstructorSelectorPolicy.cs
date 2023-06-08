using System;
using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IConstructorSelectorPolicy" /> that chooses
/// constructors based on these criteria: first, pick a constructor marked with the
/// <typeparamref name="TInjectionConstructorMarkerAttribute" /> attribute. If there
/// isn't one, then choose the constructor with the longest parameter list. If that is ambiguous,
/// then throw.
/// </summary>
/// <exception cref="T:System.InvalidOperationException">Thrown when the constructor to choose is ambiguous.</exception>
/// <typeparam name="TInjectionConstructorMarkerAttribute">Attribute used to mark the constructor to call.</typeparam>
public class ConstructorSelectorPolicy<TInjectionConstructorMarkerAttribute> : ConstructorSelectorPolicyBase<TInjectionConstructorMarkerAttribute> where TInjectionConstructorMarkerAttribute : Attribute
{
	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance for the given
	/// <see cref="T:System.Reflection.ParameterInfo" />.
	/// </summary>
	/// <param name="parameter">Parameter to create the resolver for.</param>
	/// <returns>The resolver object.</returns>
	protected override IDependencyResolverPolicy CreateResolver(ParameterInfo parameter)
	{
		return new FixedTypeResolverPolicy(parameter.ParameterType);
	}
}
