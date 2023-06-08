using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// SQL配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(SqlConfigurationSource))]
public interface ISqlConfiguration : IConfiguration, ISqlConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
