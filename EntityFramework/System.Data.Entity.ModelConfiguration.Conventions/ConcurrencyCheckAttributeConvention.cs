using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Edm;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.ConcurrencyCheckAttribute" /> found on properties in the model.
/// </summary>
public sealed class ConcurrencyCheckAttributeConvention : IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>, IConvention
{
	internal sealed class ConcurrencyCheckAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration, ConcurrencyCheckAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, PrimitivePropertyConfiguration primitivePropertyConfiguration, ConcurrencyCheckAttribute _)
		{
			if (!primitivePropertyConfiguration.ConcurrencyMode.HasValue)
			{
				primitivePropertyConfiguration.ConcurrencyMode = EdmConcurrencyMode.Fixed;
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration> _impl = new ConcurrencyCheckAttributeConventionImpl();

	internal ConcurrencyCheckAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, PrimitivePropertyConfiguration>.Apply(PropertyInfo memberInfo, Func<PrimitivePropertyConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
