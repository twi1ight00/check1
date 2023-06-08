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
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.ForeignKeyAttribute" /> found on foreign key properties in the model.
/// </summary>
public sealed class ForeignKeyPrimitivePropertyAttributeConvention : IConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>, IConvention
{
	internal sealed class ForeignKeyAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration, ForeignKeyAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, ForeignKeyAttribute foreignKeyAttribute)
		{
			if (propertyInfo.IsValidEdmPrimitiveProperty())
			{
				ApplyNavigationProperty(propertyInfo, modelConfiguration, foreignKeyAttribute);
			}
		}

		private static void ApplyNavigationProperty(PropertyInfo propertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, ForeignKeyAttribute foreignKeyAttribute)
		{
			PropertyInfo propertyInfo2 = (from pi in new PropertyFilter().GetProperties(propertyInfo.ReflectedType, declaredOnly: false)
				where pi.Name.Equals(foreignKeyAttribute.Name, StringComparison.Ordinal)
				select pi).SingleOrDefault();
			if (propertyInfo2 == null)
			{
				throw Error.ForeignKeyAttributeConvention_InvalidNavigationProperty(propertyInfo.Name, propertyInfo.ReflectedType, foreignKeyAttribute.Name);
			}
			NavigationPropertyConfiguration navigationPropertyConfiguration = modelConfiguration.Entity(propertyInfo.ReflectedType).Navigation(propertyInfo2);
			if (!HasConfiguredConstraint(propertyInfo, modelConfiguration, navigationPropertyConfiguration))
			{
				ForeignKeyConstraintConfiguration foreignKeyConstraintConfiguration = (ForeignKeyConstraintConfiguration)(navigationPropertyConfiguration.Constraint ?? (navigationPropertyConfiguration.Constraint = new ForeignKeyConstraintConfiguration()));
				foreignKeyConstraintConfiguration.AddColumn(propertyInfo);
			}
		}

		private static bool HasConfiguredConstraint(PropertyInfo propertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, NavigationPropertyConfiguration navigationPropertyConfiguration)
		{
			if (navigationPropertyConfiguration.Constraint == null || !navigationPropertyConfiguration.Constraint.IsFullySpecified)
			{
				if (navigationPropertyConfiguration.InverseNavigationProperty != null)
				{
					return modelConfiguration.Entity(propertyInfo.PropertyType.GetTargetType()).Navigation(navigationPropertyConfiguration.InverseNavigationProperty).Constraint != null;
				}
				return false;
			}
			return true;
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> _impl = new ForeignKeyAttributeConventionImpl();

	internal ForeignKeyPrimitivePropertyAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>.Apply(PropertyInfo memberInfo, Func<System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
