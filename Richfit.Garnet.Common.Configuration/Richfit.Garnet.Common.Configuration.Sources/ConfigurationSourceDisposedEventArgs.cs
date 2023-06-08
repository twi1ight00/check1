using System;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置清理事件参数
/// </summary>
public class ConfigurationSourceDisposedEventArgs : EventArgs
{
	/// <summary>
	/// 获取变更的配置源信息
	/// </summary>
	public IConfigurationSource Source { get; private set; }

	/// <summary>
	/// 初始化参数对象
	/// </summary>
	/// <param name="source"></param>
	public ConfigurationSourceDisposedEventArgs(IConfigurationSource source)
	{
		Source = source;
	}
}
