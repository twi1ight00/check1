using System;
using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IPropertySelectorPolicy" /> that looks
/// for properties marked with the <typeparamref name="TResolutionAttribute" />
/// attribute that are also settable and not indexers.
/// </summary>
/// <typeparam name="TResolutionAttribute"></typeparam>
public class PropertySelectorPolicy<TResolutionAttribute> : PropertySelectorBase<TResolutionAttribute> where TResolutionAttribute : Attribute
{
	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> for the given
	/// property.
	/// </summary>
	/// <param name="property">Property to create resolver for.</param>
	/// <returns>The resolver object.</returns>
	protected override IDependencyResolverPolicy CreateResolver(PropertyInfo property)
	{
		return new FixedTypeResolverPolicy(property.PropertyType);
	}
}
