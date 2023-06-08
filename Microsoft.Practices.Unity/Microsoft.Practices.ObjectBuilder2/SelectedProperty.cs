using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Objects of this type are returned from
/// <see cref="M:Microsoft.Practices.ObjectBuilder2.IPropertySelectorPolicy.SelectProperties(Microsoft.Practices.ObjectBuilder2.IBuilderContext,Microsoft.Practices.ObjectBuilder2.IPolicyList)" />.
/// This class combines the <see cref="T:System.Reflection.PropertyInfo" /> about
/// the property with the string key used to look up the resolver
/// for this property's value.
/// </summary>
public class SelectedProperty
{
	private PropertyInfo property;

	private string key;

	/// <summary>
	/// PropertyInfo for this property.
	/// </summary>
	public PropertyInfo Property => property;

	/// <summary>
	/// Key to look up this property's resolver.
	/// </summary>
	public string Key => key;

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.ObjectBuilder2.SelectedProperty" />
	/// with the given <see cref="T:System.Reflection.PropertyInfo" /> and key.
	/// </summary>
	/// <param name="property">The property.</param>
	/// <param name="key">Key to use to look up the resolver.</param>
	public SelectedProperty(PropertyInfo property, string key)
	{
		this.property = property;
		this.key = key;
	}
}
