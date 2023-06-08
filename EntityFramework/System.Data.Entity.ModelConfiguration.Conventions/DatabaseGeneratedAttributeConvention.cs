using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.DatabaseGeneratedAttribute" /> found on properties in the model.
/// </summary>
public sealed class DatabaseGeneratedAttributeConvention : IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>, IConvention
{
	internal sealed class DatabaseGeneratedAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration, DatabaseGeneratedAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, PrimitivePropertyConfiguration primitivePropertyConfiguration, DatabaseGeneratedAttribute databaseGeneratedAttribute)
		{
			if (!primitivePropertyConfiguration.DatabaseGeneratedOption.HasValue)
			{
				primitivePropertyConfiguration.DatabaseGeneratedOption = databaseGeneratedAttribute.DatabaseGeneratedOption;
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration> _impl = new DatabaseGeneratedAttributeConventionImpl();

	internal DatabaseGeneratedAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>.Apply(PropertyInfo memberInfo, Func<PrimitivePropertyConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
