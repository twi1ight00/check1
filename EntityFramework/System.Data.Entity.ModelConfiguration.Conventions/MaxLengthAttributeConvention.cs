using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.Resources;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.MaxLengthAttribute" /> found on properties in the model.
/// </summary>
public sealed class MaxLengthAttributeConvention : IConfigurationConvention<PropertyInfo, LengthPropertyConfiguration>, IConvention
{
	internal sealed class MaxLengthAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, LengthPropertyConfiguration, MaxLengthAttribute>
	{
		private const int MaxLengthIndicator = -1;

		internal override void Apply(PropertyInfo propertyInfo, LengthPropertyConfiguration lengthPropertyConfiguration, MaxLengthAttribute maxLengthAttribute)
		{
			if (maxLengthAttribute.Length == 0 || maxLengthAttribute.Length < -1)
			{
				throw Error.MaxLengthAttributeConvention_InvalidMaxLength(propertyInfo.Name, propertyInfo.ReflectedType);
			}
			if (!lengthPropertyConfiguration.IsMaxLength.HasValue && !lengthPropertyConfiguration.MaxLength.HasValue)
			{
				if (maxLengthAttribute.Length == -1)
				{
					lengthPropertyConfiguration.IsMaxLength = true;
				}
				else
				{
					lengthPropertyConfiguration.MaxLength = maxLengthAttribute.Length;
				}
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, LengthPropertyConfiguration> _impl = new MaxLengthAttributeConventionImpl();

	internal MaxLengthAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, LengthPropertyConfiguration>.Apply(PropertyInfo memberInfo, Func<LengthPropertyConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
