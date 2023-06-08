using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// Quartz配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(QuartzConfigurationSource))]
public interface IQuartzConfiguration : IConfiguration, IQuartzConfigurationSource, ISettingsConfigurationSource, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
