using System;
using System.IO;
using System.Text;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 基于文件的配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(FileConfigurationSource))]
public interface IFileConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置源文件的编码
	/// </summary>
	Encoding Encoding { get; set; }

	/// <summary>
	/// 获取配置文件全名
	/// </summary>
	string FullName { get; }

	/// <summary>
	/// 获取配置文件对象
	/// </summary>
	FileInfo File { get; }

	/// <summary>
	/// 指示配置源文件是否存在
	/// </summary>
	bool Exists { get; }

	/// <summary>
	/// 获取或者设置配置内容
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取或者设置配置内容字节数组
	/// </summary>
	byte[] Bytes { get; set; }

	/// <summary>
	/// 获取文件监控器
	/// </summary>
	IFileWatcher FileWatcher { get; }

	/// <summary>
	/// 获取配置内容字节流，调用者需要关闭该流
	/// </summary>
	/// <returns>配置内容字节流</returns>
	Stream GetStream();
}
