using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// .Net配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(DotNetGroupConfigurationSource))]
public interface IDotNetGroupConfiguration : IConfiguration, IDotNetConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
