using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// Json对象配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(JsonObjectConfigurationSource))]
public interface IJsonObjectConfiguration : IConfiguration, IJsonObjectConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
