using System;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置清理前事件参数
/// </summary>
public class ConfigurationSourceDisposingEventArgs : EventArgs
{
	/// <summary>
	/// 是否取消清理
	/// </summary>
	public bool Cancelled { get; set; }

	/// <summary>
	/// 获取配置源
	/// </summary>
	public IConfigurationSource Source { get; private set; }

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="source">将要发生清理的配置源</param>
	public ConfigurationSourceDisposingEventArgs(IConfigurationSource source)
	{
		Cancelled = false;
		Source = source;
	}
}
