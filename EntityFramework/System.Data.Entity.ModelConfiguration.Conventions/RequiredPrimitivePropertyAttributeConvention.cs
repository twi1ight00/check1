using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.RequiredAttribute" /> found on primitive properties in the model.
/// </summary>
public sealed class RequiredPrimitivePropertyAttributeConvention : IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>, IConvention
{
	internal sealed class RequiredPrimitivePropertyAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration, RequiredAttribute>
	{
		internal override void Apply(PropertyInfo memberInfo, PrimitivePropertyConfiguration primitivePropertyConfiguration, RequiredAttribute attribute)
		{
			if (!primitivePropertyConfiguration.IsNullable.HasValue)
			{
				primitivePropertyConfiguration.IsNullable = false;
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration> _impl = new RequiredPrimitivePropertyAttributeConventionImpl();

	internal RequiredPrimitivePropertyAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>.Apply(PropertyInfo memberInfo, Func<PrimitivePropertyConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
