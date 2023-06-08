using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 设置配置接口
/// </summary>
public interface ISettingsGroupConfiguration : IConfiguration, ISettingsGroupConfigurationSource, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IGroupConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
