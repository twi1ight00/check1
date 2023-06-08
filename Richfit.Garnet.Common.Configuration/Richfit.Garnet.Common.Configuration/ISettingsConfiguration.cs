using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 设置配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(SettingsConfigurationSource))]
public interface ISettingsConfiguration : IConfiguration, ISettingsConfigurationSource, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
