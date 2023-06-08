using System;
using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IMethodSelectorPolicy" /> that selects
/// methods by looking for the given <typeparamref name="TMarkerAttribute" />
/// attribute on those methods.
/// </summary>
/// <typeparam name="TMarkerAttribute">Type of attribute used to mark methods
/// to inject.</typeparam>
public class MethodSelectorPolicy<TMarkerAttribute> : MethodSelectorPolicyBase<TMarkerAttribute> where TMarkerAttribute : Attribute
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
