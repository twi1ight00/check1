using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 通用日志记录器配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(CommonLoggingConfigurationSource))]
public interface ICommonLoggingConfiguration : IConfiguration, ICommonLoggingConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
