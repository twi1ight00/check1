using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 数据集配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(DataSetConfigurationSource))]
public interface IDataSetConfiguration : IConfiguration, IDataSetConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
