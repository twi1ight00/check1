using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// Quartz定时任务配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(QuartzJobConfigurationSource))]
public interface IQuartzJobConfiguration : IConfiguration, IQuartzJobConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
