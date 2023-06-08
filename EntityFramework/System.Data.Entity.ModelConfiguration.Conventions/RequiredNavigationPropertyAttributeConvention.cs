using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.RequiredAttribute" /> found on navigation properties in the model.
/// </summary>
public sealed class RequiredNavigationPropertyAttributeConvention : IConfigurationConvention<PropertyInfo, NavigationPropertyConfiguration>, IConvention
{
	internal sealed class RequiredNavigationPropertyAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, NavigationPropertyConfiguration, RequiredAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, NavigationPropertyConfiguration navigationPropertyConfiguration, RequiredAttribute _)
		{
			if (!navigationPropertyConfiguration.EndKind.HasValue && !propertyInfo.PropertyType.IsCollection())
			{
				navigationPropertyConfiguration.EndKind = EdmAssociationEndKind.Required;
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, NavigationPropertyConfiguration> _impl = new RequiredNavigationPropertyAttributeConventionImpl();

	internal RequiredNavigationPropertyAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, NavigationPropertyConfiguration>.Apply(PropertyInfo memberInfo, Func<NavigationPropertyConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
