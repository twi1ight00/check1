using System;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置变更事件参数
/// </summary>
public class ConfigurationSourceChangedEventArgs : EventArgs
{
	/// <summary>
	/// 获取配置源
	/// </summary>
	public IConfigurationSource Source { get; private set; }

	/// <summary>
	/// 获取配置源状态
	/// </summary>
	public ConfigurationSourceStatus Status { get; private set; }

	/// <summary>
	/// 创建配置变更事件参数对象
	/// </summary>
	/// <param name="source">变更的配置源</param>
	/// <param name="status">变更的状态</param>
	public ConfigurationSourceChangedEventArgs(IConfigurationSource source, ConfigurationSourceStatus status)
	{
		Source = source;
		Status = status;
	}
}
