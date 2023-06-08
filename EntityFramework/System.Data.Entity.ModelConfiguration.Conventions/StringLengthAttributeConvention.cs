using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.Resources;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.StringLengthAttribute" /> found on properties in the model.
/// </summary>
public sealed class StringLengthAttributeConvention : IConfigurationConvention<PropertyInfo, StringPropertyConfiguration>, IConvention
{
	internal sealed class StringLengthAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, StringPropertyConfiguration, StringLengthAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, StringPropertyConfiguration stringPropertyConfiguration, StringLengthAttribute stringLengthAttribute)
		{
			if (stringLengthAttribute.MaximumLength < -1 || stringLengthAttribute.MaximumLength == 0)
			{
				throw Error.StringLengthAttributeConvention_InvalidMaximumLength(propertyInfo.Name, propertyInfo.ReflectedType);
			}
			if (!stringPropertyConfiguration.IsMaxLength.HasValue && !stringPropertyConfiguration.MaxLength.HasValue)
			{
				stringPropertyConfiguration.MaxLength = stringLengthAttribute.MaximumLength;
			}
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, StringPropertyConfiguration> _impl = new StringLengthAttributeConventionImpl();

	internal StringLengthAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, StringPropertyConfiguration>.Apply(PropertyInfo memberInfo, Func<StringPropertyConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
