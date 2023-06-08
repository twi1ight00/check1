using System;
using Common.Logging;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 通用日志记录器配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(CommonLoggingConfigurationSource))]
public interface ICommonLoggingConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置的文本
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取通用日志配置读取器
	/// </summary>
	/// <returns>读取器</returns>
	IConfigurationReader GetConfiguration();
}
