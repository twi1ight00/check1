using System;
using System.Globalization;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 系统配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(SystemConfigurationSource))]
public interface ISystemConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	string Url { get; set; }

	/// <summary>
	/// 获取或者设置配置内容
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取默认的区域
	/// </summary>
	CultureInfo DefaultCulture { get; set; }

	/// <summary>
	/// 默认时区偏移，单位小时
	/// </summary>
	double DefaultTimeOffset { get; set; }

	/// <summary>
	/// 获取域验证状态
	/// </summary>
	bool EnableDomain { get; set; }

	/// <summary>
	/// 是否开启超级密码
	/// </summary>
	bool IsOpenSuperpassword { get; set; }

	/// <summary>
	/// 获取多语状态
	/// </summary>
	bool EnableMultiLanguage { get; set; }

	/// <summary>
	/// 获取Quartz定时组件启用状态
	/// </summary>
	bool EnableQuartz { get; set; }

	/// <summary>
	/// 是否启用时区
	/// </summary>
	bool EnableTimeOffset { get; set; }

	/// <summary>
	/// 获取Session过期时间，单位分钟
	/// </summary>
	int SessionTimeout { get; set; }

	/// <summary>
	/// 获取Session过期时间，单位分钟
	/// </summary>
	int SessionTimeoutForMoblie { get; set; }

	/// <summary>
	/// 外部访问控制
	/// </summary>
	string ExternalAccessConfig { get; set; }
}
