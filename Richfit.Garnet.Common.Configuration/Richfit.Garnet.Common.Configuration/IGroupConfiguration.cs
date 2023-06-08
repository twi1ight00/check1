using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 组配置接口
/// </summary>
[ConfigurationSourceMapping(typeof(GroupConfigurationSource))]
public interface IGroupConfiguration : IConfiguration, IGroupConfigurationSource, IRefreshableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
