using System;
using Microsoft.Practices.Unity.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Unity容器配置源
/// </summary>
public class UnityConfigurationSource : DotNetConfigurationSource, IUnityConfiguration, IConfiguration, IUnityConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// Unity配置节
	/// </summary>
	private UnityConfigurationSection section;

	/// <summary>
	/// 获取或者设置原始配置文本
	/// </summary>
	public override string Text
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return section.IsNull() ? null : section.SectionInformation.GetRawXml();
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				if (section.IsNotNull())
				{
					section.SectionInformation.SetRawXml(value.IfNull(string.Empty));
					Save();
				}
			});
		}
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public UnityConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public UnityConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~UnityConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			section = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载配置源
	/// </summary>
	/// <returns></returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			base.LoadConfiguration();
			section = base.Configuration.GetFirstSection<UnityConfigurationSection>();
			return base.IsValid = section.IsNotNull();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 获取Unity配置节
	/// </summary>
	/// <returns></returns>
	public UnityConfigurationSection GetConfiguration()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return section;
		});
	}
}
