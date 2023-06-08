using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Mappers;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.InversePropertyAttribute" /> found on properties in the model.
/// </summary>
public sealed class InversePropertyAttributeConvention : IConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>, IConvention
{
	internal sealed class InversePropertyAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration, InversePropertyAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, InversePropertyAttribute inversePropertyAttribute)
		{
			NavigationPropertyConfiguration navigationPropertyConfiguration = modelConfiguration.Entity(propertyInfo.ReflectedType).Navigation(propertyInfo);
			if (!(navigationPropertyConfiguration.InverseNavigationProperty != null))
			{
				Type targetType = propertyInfo.PropertyType.GetTargetType();
				PropertyInfo propertyInfo2 = (from p in new PropertyFilter().GetProperties(targetType, declaredOnly: false)
					where string.Equals(p.Name, inversePropertyAttribute.Property, StringComparison.OrdinalIgnoreCase)
					select p).SingleOrDefault();
				if (propertyInfo2 == null)
				{
					throw Error.InversePropertyAttributeConvention_PropertyNotFound(inversePropertyAttribute.Property, targetType, propertyInfo.Name, propertyInfo.ReflectedType);
				}
				if (propertyInfo == propertyInfo2)
				{
					throw Error.InversePropertyAttributeConvention_SelfInverseDetected(propertyInfo.Name, propertyInfo.ReflectedType);
				}
				navigationPropertyConfiguration.InverseNavigationProperty = propertyInfo2;
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> _impl = new InversePropertyAttributeConventionImpl();

	internal InversePropertyAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>.Apply(PropertyInfo memberInfo, Func<System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
