using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.ColumnAttribute" /> found on properties in the model
/// </summary>
public sealed class ColumnAttributeConvention : IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>, IConvention
{
	internal sealed class ColumnAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration, ColumnAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, PrimitivePropertyConfiguration primitivePropertyConfiguration, ColumnAttribute columnAttribute)
		{
			if (string.IsNullOrWhiteSpace(primitivePropertyConfiguration.ColumnName) && !string.IsNullOrWhiteSpace(columnAttribute.Name))
			{
				primitivePropertyConfiguration.ColumnName = columnAttribute.Name;
			}
			if (string.IsNullOrWhiteSpace(primitivePropertyConfiguration.ColumnType) && !string.IsNullOrWhiteSpace(columnAttribute.TypeName))
			{
				primitivePropertyConfiguration.ColumnType = columnAttribute.TypeName;
			}
			if (!primitivePropertyConfiguration.ColumnOrder.HasValue && columnAttribute.Order >= 0)
			{
				primitivePropertyConfiguration.ColumnOrder = columnAttribute.Order;
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration> _impl = new ColumnAttributeConventionImpl();

	internal ColumnAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>.Apply(PropertyInfo memberInfo, Func<PrimitivePropertyConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
