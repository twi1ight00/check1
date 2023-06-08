using System;
using System.Collections.Specialized;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Quartz定时任务组件配置源
/// </summary>
[ConfigurationSourceMapping(typeof(QuartzConfigurationSource))]
public interface IQuartzConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置内容
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取配置值集合
	/// </summary>
	/// <returns>配置值集合</returns>
	NameValueCollection GetConfiguration();
}
