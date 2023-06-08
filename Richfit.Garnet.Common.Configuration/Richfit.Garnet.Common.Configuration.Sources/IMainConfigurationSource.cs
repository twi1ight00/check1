using System;
using System.Reflection;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 主配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(MainConfigurationSource))]
public interface IMainConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置原始配置文本
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取系统配置
	/// </summary>
	ISystemConfiguration Settings { get; }

	/// <summary>
	/// 获取数据库配置
	/// </summary>
	IDatabaseConfiguration Database { get; }

	/// <summary>
	/// 获取组配置
	/// </summary>
	IGroupConfiguration Collection { get; }

	/// <summary>
	/// 获取Quartz定时任务配置
	/// </summary>
	IQuartzConfiguration Quartz { get; }

	/// <summary>
	/// 获取Log4Net配置
	/// </summary>
	ILog4NetConfiguration Log4Net { get; }

	/// <summary>
	/// 获取Common.Logging组件配置
	/// </summary>
	ICommonLoggingConfiguration CommonLogging { get; }

	/// <summary>
	/// 获取容器配置
	/// </summary>
	IUnityGroupConfiguration Unity { get; }

	/// <summary>
	/// 获取拦截配置
	/// </summary>
	IInterceptionGroupConfiguration Interception { get; }

	/// <summary>
	/// 获取所有包的配置对象
	/// </summary>
	IPackageConfiguration[] Packages { get; }

	/// <summary>
	/// 获取当前包的配置对象
	/// </summary>
	IPackageConfiguration CurrentPackage { get; }

	/// <summary>
	/// 获取当前包的配置对象
	/// </summary>
	IPackageConfiguration CurrentWeb { get; }

	/// <summary>
	/// 按照包名称获取包配置对象
	/// </summary>
	/// <param name="packageName">包名称</param>
	/// <returns>包配置对象</returns>
	IPackageConfiguration GetPackage(string packageName);

	/// <summary>
	/// 获取包含指定程序集的包的配置
	/// </summary>
	/// <param name="assembly">包程序集</param>
	/// <returns>包配置对象</returns>
	IPackageConfiguration GetPackage(Assembly assembly);

	/// <summary>
	/// 获取指定类型所在包程序集的包的配置
	/// </summary>
	/// <param name="type">包程序集</param>
	/// <returns>包配置对象</returns>
	IPackageConfiguration GetPackage(Type type);
}
