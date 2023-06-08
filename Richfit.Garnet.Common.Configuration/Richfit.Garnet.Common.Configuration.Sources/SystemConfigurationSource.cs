using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 系统配置源
/// </summary>
public class SystemConfigurationSource : SettingsConfigurationSource, ISystemConfiguration, IConfiguration, ISystemConfigurationSource, ISettingsConfigurationSource, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取默认的区域
	/// </summary>
	public CultureInfo DefaultCulture
	{
		get
		{
			return GetSetting("DefaultCulture", CultureInfo.CurrentCulture);
		}
		set
		{
			SetSetting("DefaultCulture", value.IfNull(CultureInfo.CurrentCulture));
		}
	}

	/// <summary>
	/// 默认时区偏移
	/// </summary>
	public double DefaultTimeOffset
	{
		get
		{
			return GetSetting("DefaultTimeOffset", 0.0);
		}
		set
		{
			SetSetting("DefaultTimeOffset", value.GuardBetween(-14.0, 14.0));
		}
	}

	/// <summary>
	/// 获取域验证状态
	/// </summary>
	public bool EnableDomain
	{
		get
		{
			return GetSetting("EnableDomain", defaultValue: false);
		}
		set
		{
			SetSetting("EnableDomain", value);
		}
	}

	/// <summary>
	/// 是否开启超级密码
	/// </summary>
	public bool IsOpenSuperpassword
	{
		get
		{
			return GetSetting("IsOpenSuperpassword", defaultValue: false);
		}
		set
		{
			SetSetting("IsOpenSuperpassword", value);
		}
	}

	/// <summary>
	/// 获取多语状态
	/// </summary>
	public bool EnableMultiLanguage
	{
		get
		{
			return GetSetting("EnableMultiLanguage", defaultValue: false);
		}
		set
		{
			SetSetting("EnableMultiLanguage", value);
		}
	}

	/// <summary>
	/// 获取Quartz定时组件启用状态
	/// </summary>
	public bool EnableQuartz
	{
		get
		{
			return GetSetting("EnableQuartz", defaultValue: false);
		}
		set
		{
			SetSetting("EnableQuartz", value);
		}
	}

	/// <summary>
	/// 是否启用时区
	/// </summary>
	public bool EnableTimeOffset
	{
		get
		{
			return GetSetting("EnableTimeOffset", defaultValue: false);
		}
		set
		{
			SetSetting("EnableTimeOffset", value);
		}
	}

	/// <summary>
	/// 获取Session过期时间
	/// </summary>
	public string Url
	{
		get
		{
			return GetSetting("Url", "");
		}
		set
		{
			SetSetting("Url", value.GuardGreaterThanOrEqualTo("", "Url"));
		}
	}

	/// <summary>
	/// 获取Session过期时间
	/// </summary>
	public int SessionTimeout
	{
		get
		{
			return GetSetting("SessionTimeout", 0);
		}
		set
		{
			SetSetting("SessionTimeout", value.GuardGreaterThanOrEqualTo(0, "Session Timeout"));
		}
	}

	/// <summary>
	/// 获取Session过期时间
	/// </summary>
	public int SessionTimeoutForMoblie
	{
		get
		{
			return GetSetting("SessionTimeoutForMoblie", 0);
		}
		set
		{
			SetSetting("SessionTimeoutForMoblie", value.GuardGreaterThanOrEqualTo(0, "Session Timeout For Moblie"));
		}
	}

	/// <summary>
	/// 外部访问控制
	/// </summary>
	public string ExternalAccessConfig
	{
		get
		{
			return GetSetting("ExternalAccessConfig", string.Empty);
		}
		set
		{
			SetSetting("ExternalAccessConfig", value.IfNull(string.Empty));
		}
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public SystemConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
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
	public SystemConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~SystemConfigurationSource()
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
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 获取配置节
	/// </summary>
	/// <returns></returns>
	protected override ConfigurationSection GetSection()
	{
		return base.Configuration.GetFirstSection<SystemConfigurationSection>();
	}
}
