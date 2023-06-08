using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// Unity容器配置组接口
/// </summary>
public interface IUnityGroupConfiguration : IConfiguration, IUnityGroupConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
