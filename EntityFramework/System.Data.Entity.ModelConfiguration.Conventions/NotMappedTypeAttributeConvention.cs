using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to process instances of <see cref="T:System.ComponentModel.DataAnnotations.NotMappedAttribute" /> found on types in the model.
/// </summary>
public sealed class NotMappedTypeAttributeConvention : IConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>, IConvention
{
	internal sealed class NotMappedTypeAttributeConventionImpl : AttributeConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration, NotMappedAttribute>
	{
		internal override void Apply(Type type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration, NotMappedAttribute _)
		{
			modelConfiguration.Ignore(type);
		}
	}

	private readonly IConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> _impl = new NotMappedTypeAttributeConventionImpl();

	internal NotMappedTypeAttributeConvention()
	{
	}

	void IConfigurationConvention<Type, System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration>.Apply(Type memberInfo, Func<System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration> configuration)
	{
		_impl.Apply(memberInfo, configuration);
	}
}
