using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.ObjectBuilder;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IPropertySelectorPolicy" /> that is aware of
/// the build keys used by the unity container.
/// </summary>
public class DefaultUnityPropertySelectorPolicy : PropertySelectorBase<DependencyResolutionAttribute>
{
	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> for the given
	/// property.
	/// </summary>
	/// <param name="property">Property to create resolver for.</param>
	/// <returns>The resolver object.</returns>
	protected override IDependencyResolverPolicy CreateResolver(PropertyInfo property)
	{
		List<DependencyResolutionAttribute> list = property.GetCustomAttributes(typeof(DependencyResolutionAttribute), inherit: false).OfType<DependencyResolutionAttribute>().ToList();
		return list[0].CreateResolver(property.PropertyType);
	}
}
