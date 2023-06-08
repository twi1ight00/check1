using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.ComplexTypeAttribute" /> found on types in the model.
/// </summary>
public sealed class ComplexTypeAttributeConvention : IConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>, IConvention
{
	internal sealed class ComplexTypeAttributeConventionImpl : AttributeConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration, ComplexTypeAttribute>
	{
		internal override void Apply(Type type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, ComplexTypeAttribute _)
		{
			modelConfiguration.ComplexType(type);
		}
	}

	private readonly IConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> _impl = new ComplexTypeAttributeConventionImpl();

	internal ComplexTypeAttributeConvention()
	{
	}

	void IConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>.Apply(Type memberInfo, Func<System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
