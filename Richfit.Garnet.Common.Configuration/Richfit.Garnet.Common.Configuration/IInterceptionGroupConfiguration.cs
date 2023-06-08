using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// Unity容器拦截配置组接口
/// </summary>
public interface IInterceptionGroupConfiguration : IConfiguration, IInterceptionGroupConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
