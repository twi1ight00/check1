using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Base class that provides an implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IPropertySelectorPolicy" />
/// which lets you override how the parameter resolvers are created.
/// </summary>
public abstract class PropertySelectorBase<TResolutionAttribute> : IPropertySelectorPolicy, IBuilderPolicy where TResolutionAttribute : Attribute
{
	/// <summary>
	/// Returns sequence of properties on the given type that
	/// should be set as part of building that object.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>Sequence of <see cref="T:System.Reflection.PropertyInfo" /> objects
	/// that contain the properties to set.</returns>
	public virtual IEnumerable<SelectedProperty> SelectProperties(IBuilderContext context, IPolicyList resolverPolicyDestination)
	{
		Type t = context.BuildKey.Type;
		try
		{
			PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
			foreach (PropertyInfo prop in properties)
			{
				if (prop.GetIndexParameters().Length == 0 && prop.CanWrite && prop.IsDefined(typeof(TResolutionAttribute), inherit: false))
				{
					yield return CreateSelectedProperty(context, resolverPolicyDestination, prop);
				}
			}
		}
		finally
		{
		}
	}

	private SelectedProperty CreateSelectedProperty(IBuilderContext context, IPolicyList resolverPolicyDestination, PropertyInfo property)
	{
		string text = Guid.NewGuid().ToString();
		SelectedProperty result = new SelectedProperty(property, text);
		resolverPolicyDestination.Set(CreateResolver(property), text);
		DependencyResolverTrackerPolicy.TrackKey(context.PersistentPolicies, context.BuildKey, text);
		return result;
	}

	/// <summary>
	/// Create a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> for the given
	/// property.
	/// </summary>
	/// <param name="property">Property to create resolver for.</param>
	/// <returns>The resolver object.</returns>
	protected abstract IDependencyResolverPolicy CreateResolver(PropertyInfo property);
}
