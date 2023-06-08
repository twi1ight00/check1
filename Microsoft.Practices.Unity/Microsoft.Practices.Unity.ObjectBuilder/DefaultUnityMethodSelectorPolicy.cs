using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.ObjectBuilder;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IMethodSelectorPolicy" /> that is aware
/// of the build keys used by the Unity container.
/// </summary>
public class DefaultUnityMethodSelectorPolicy : MethodSelectorPolicyBase<InjectionMethodAttribute>
{
	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance for the given
	/// <see cref="T:System.Reflection.ParameterInfo" />.
	/// </summary>
	/// <param name="parameter">Parameter to create the resolver for.</param>
	/// <returns>The resolver object.</returns>
	protected override IDependencyResolverPolicy CreateResolver(ParameterInfo parameter)
	{
		List<DependencyResolutionAttribute> list = parameter.GetCustomAttributes(inherit: false).OfType<DependencyResolutionAttribute>().ToList();
		if (list.Count > 0)
		{
			return list[0].CreateResolver(parameter.ParameterType);
		}
		return new NamedTypeDependencyResolverPolicy(parameter.ParameterType, null);
	}
}
