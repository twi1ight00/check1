using System;
using System.IO;
using System.Text;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Log4Net配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(Log4NetConfigurationSource))]
public interface ILog4NetConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置源文件的编码
	/// </summary>
	Encoding Encoding { get; set; }

	/// <summary>
	/// 获取或者设置原始的XML配置
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取配置文件流
	/// </summary>
	/// <returns>配置流</returns>
	Stream GetConfiguration();
}
