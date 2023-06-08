using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 包配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(PackageConfigurationSource))]
public interface IPackageConfiguration : IConfiguration, IPackageConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
