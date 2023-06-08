using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.KeyAttribute" /> found on properties in the model.
/// </summary>
public sealed class KeyAttributeConvention : IConfigurationConvention<PropertyInfo, EntityTypeConfiguration>, IConvention
{
	internal sealed class KeyAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, EntityTypeConfiguration, KeyAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, EntityTypeConfiguration entityTypeConfiguration, KeyAttribute _)
		{
			if (propertyInfo.IsValidEdmPrimitiveProperty())
			{
				entityTypeConfiguration.Key(propertyInfo);
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, EntityTypeConfiguration> _impl = new KeyAttributeConventionImpl();

	internal KeyAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, EntityTypeConfiguration>.Apply(PropertyInfo memberInfo, Func<EntityTypeConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
