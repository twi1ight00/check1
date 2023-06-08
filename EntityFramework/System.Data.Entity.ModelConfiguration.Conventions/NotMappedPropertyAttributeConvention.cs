using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.NotMappedAttribute" /> found on properties in the model.
/// </summary>
public sealed class NotMappedPropertyAttributeConvention : IConfigurationConvention<PropertyInfo, StructuralTypeConfiguration>, IConvention
{
	internal sealed class NotMappedPropertyAttributeConventionImpl : AttributeConfigurationConvention<PropertyInfo, StructuralTypeConfiguration, NotMappedAttribute>
	{
		internal override void Apply(PropertyInfo propertyInfo, StructuralTypeConfiguration structuralTypeConfiguration, NotMappedAttribute _)
		{
			structuralTypeConfiguration.Ignore(propertyInfo);
		}
	}

	private readonly IConfigurationConvention<PropertyInfo, StructuralTypeConfiguration> _impl = new NotMappedPropertyAttributeConventionImpl();

	internal NotMappedPropertyAttributeConvention()
	{
	}

	void IConfigurationConvention<PropertyInfo, StructuralTypeConfiguration>.Apply(PropertyInfo memberInfo, Func<StructuralTypeConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
