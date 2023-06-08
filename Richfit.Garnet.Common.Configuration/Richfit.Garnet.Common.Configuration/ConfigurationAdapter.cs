using System;
using System.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 应用程序配置适配器
/// </summary>
public abstract class ConfigurationAdapter : IConfigurationAdapter, IDisposableObject, IDisposable
{
	/// <summary>
	/// 基础配置对象
	/// </summary>
	private System.Configuration.Configuration configuration;

	/// <summary>
	/// 指示对象是否已经被清理
	/// </summary>
	public bool IsDisposed { get; private set; }

	/// <summary>
	/// 获取基础配置对象
	/// </summary>
	protected System.Configuration.Configuration Configuration
	{
		get
		{
			return configuration;
		}
		set
		{
			configuration = value;
		}
	}

	/// <summary>
	/// 获取当前的配置对象
	/// </summary>
	public System.Configuration.Configuration Current
	{
		get
		{
			if (configuration.IsNull())
			{
				configuration = OpenConfiguration();
			}
			return configuration;
		}
	}

	/// <summary>
	/// 初始化
	/// </summary>
	public ConfigurationAdapter()
	{
		IsDisposed = false;
		configuration = OpenConfiguration();
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="location">配置文件位置</param>
	public ConfigurationAdapter(string location)
	{
		IsDisposed = false;
		configuration = OpenConfiguration(location);
	}

	/// <summary>
	/// 清理
	/// </summary>
	public void Dispose()
	{
		IsDisposed = true;
		configuration = null;
	}

	/// <summary>
	/// 获取应用系统的app.config的配置对象
	/// </summary>
	/// <returns>加载的配置对象</returns>
	public abstract System.Configuration.Configuration OpenConfiguration();

	/// <summary>
	/// 获取应用系统的app.config的配置对象
	/// </summary>
	/// <param name="location">配置文件位置</param>
	/// <returns>加载的配置对象</returns>
	public abstract System.Configuration.Configuration OpenConfiguration(string location);

	/// <summary>
	/// 获取当前配置文件中的配置节
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>匹配的配置节</returns>
	public ConfigurationSection GetSection(string sectionName)
	{
		if (sectionName.IsNullOrEmpty() || configuration.IsNull())
		{
			return null;
		}
		return configuration.GetSection(sectionName);
	}
}
