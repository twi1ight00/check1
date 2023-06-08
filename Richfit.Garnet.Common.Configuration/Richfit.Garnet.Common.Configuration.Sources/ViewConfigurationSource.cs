using System;
using System.IO;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 强类型视图化配置
/// </summary>
/// <typeparam name="V">配置视图类型</typeparam>
public class ViewConfigurationSource<V> : ViewsConfigurationSource, IViewConfiguration<V>, IConfiguration, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable where V : IConfigurationView
{
	FileInfo IViewConfiguration<V>.File => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return base.File;
	});

	/// <summary>
	/// 获取默认视图
	/// </summary>
	V IViewConfiguration<V>.View => GetView<V>();

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="owner">父配置组</param>
	/// <param name="name">配置源名称</param>
	/// <param name="file">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public ViewConfigurationSource(IConfigurationSourceGroup owner, string name, string file, IWatcher watcher)
		: base(owner, name, file, watcher)
	{
		Initialize();
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="owner">父配置组</param>
	/// <param name="name">配置源名称</param>
	/// <param name="file">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public ViewConfigurationSource(IConfigurationSourceGroup owner, string name, string file, IWatchingTimer timer)
		: base(owner, name, file, timer)
	{
		Initialize();
	}

	/// <summary>
	/// 析构
	/// </summary>
	~ViewConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private void Initialize()
	{
		base.Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
	}
}
