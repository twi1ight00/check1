using System;
using System.IO;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Quartz定时任务配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(QuartzJobConfigurationSource))]
public interface IQuartzJobConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置内容
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取配置数据
	/// </summary>
	/// <returns>配置数据</returns>
	FileInfo GetConfiguration();
}
