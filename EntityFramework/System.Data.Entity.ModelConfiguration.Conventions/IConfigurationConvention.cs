using System.Data.Entity.ModelConfiguration.Configuration;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Conventions;

internal interface IConfigurationConvention<TMemberInfo, TConfiguration> : IConvention where TMemberInfo : MemberInfo where TConfiguration : ConfigurationBase
{
	void Apply(TMemberInfo memberInfo, Func<TConfiguration> configuration);
}
internal interface IConfigurationConvention : IConvention
{
	void Apply(System.Data.Entity.ModelConfiguration.Configuration.ModelConfiguration modelConfiguration);
}
