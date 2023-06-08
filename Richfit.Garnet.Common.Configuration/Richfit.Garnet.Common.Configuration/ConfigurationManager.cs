using System;
using System.Reflection;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Reflection;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 配置管理器
/// </summary>
public static class ConfigurationManager
{
	/// <summary>
	/// 监控时间间隔，单位毫秒
	/// </summary>
	public const int WatchingInterval = 15000;

	/// <summary>
	/// 共享锁
	/// </summary>
	private static ReadWriteLocker locker = new ReadWriteLocker();

	/// <summary>
	/// 监控定时器
	/// </summary>
	private static IWatchingTimer watchingTimer;

	/// <summary>
	/// 主配置源对象
	/// </summary>
	private static IMainConfiguration configuration;

	/// <summary>
	/// 获取主配置源对象
	/// </summary>
	public static IMainConfiguration System => locker.Read(() => configuration);

	/// <summary>
	/// 获取所有包的配置对象
	/// </summary>
	public static IPackageConfiguration[] Packages => locker.Read(() => configuration.Group.GetSources<IPackageConfiguration>());

	/// <summary>
	/// 获取当前包的配置对象
	/// </summary>
	public static IPackageConfiguration CurrentPackage
	{
		get
		{
			Assembly currentAssembly = Assembly.GetCallingAssembly();
			return locker.Read(() => GetPackage(currentAssembly));
		}
	}

	/// <summary>
	/// 获取当前包的配置对象
	/// </summary>
	public static IPackageConfiguration CurrentWeb => locker.Read(() => configuration.CurrentWeb);

	/// <summary>
	/// 初始化配置管理器
	/// </summary>
	public static void Initialize()
	{
		Initialize(new AdaptiveConfigurationAdapter());
	}

	/// <summary>
	/// 初始化配置管理器
	/// </summary>
	/// <param name="adapter">配置适配器</param>
	public static void Initialize(IConfigurationAdapter adapter)
	{
		adapter.GuardNotNull();
		locker.Write(delegate
		{
			Dispose();
			watchingTimer = new WatchingTimer(15000, locker);
			watchingTimer.ReferenceManager.Register(locker);
			configuration = new MainConfigurationSource(adapter.Current, new FileWatcher(watchingTimer));
			watchingTimer.Start();
		});
	}

	/// <summary>
	/// 清理配置管理器
	/// </summary>
	public static void Dispose()
	{
		locker.Write(delegate
		{
			StopWatch();
			if (configuration.IsNotNull() && !configuration.IsDisposed)
			{
				configuration.Dispose();
			}
			if (watchingTimer.IsNotNull() && !watchingTimer.IsDisposed)
			{
				watchingTimer.ReferenceManager.Unregister(locker);
				watchingTimer.Dispose();
			}
			configuration = null;
			watchingTimer = null;
		});
	}

	/// <summary>
	/// 启动监控器
	/// </summary>
	public static void StartWatch()
	{
		locker.Read(delegate
		{
			if (watchingTimer.IsNotNull() && !watchingTimer.IsDisposed)
			{
				watchingTimer.Start();
			}
		});
	}

	/// <summary>
	/// 停止监控器
	/// </summary>
	public static void StopWatch()
	{
		locker.Read(delegate
		{
			if (watchingTimer.IsNotNull() && !watchingTimer.IsDisposed)
			{
				watchingTimer.Stop();
			}
		});
	}

	/// <summary>
	/// 解析配置类型
	/// 如果指定了类型解析器则使用类型解析器解析配置类型，否则使用Type.GetType方法解析类型
	/// 如果无法解析类型，则返回null
	/// </summary>
	/// <param name="typeName">待解析的类型名称</param>
	/// <param name="ignoreCase">是否忽略大小写</param>
	/// <returns>解析的类型对象</returns>
	public static Type ResolveType(string typeName, bool ignoreCase = false)
	{
		if (typeName.IsNullOrEmpty())
		{
			return null;
		}
		return TypeResolver.Resolve(typeName, throwError: false, ignoreCase);
	}

	/// <summary>
	/// 按照包名称获取包配置对象
	/// </summary>
	/// <param name="packageName">包名称</param>
	/// <returns>包配置对象</returns>
	public static IPackageConfiguration GetPackage(string packageName)
	{
		packageName.GuardNotNull();
		return locker.Read(() => configuration.GetPackage(packageName));
	}

	/// <summary>
	/// 获取包含指定程序集的包的配置
	/// </summary>
	/// <param name="assembly">包程序集</param>
	/// <returns>包配置对象</returns>
	public static IPackageConfiguration GetPackage(Assembly assembly)
	{
		assembly.GuardNotNull();
		return locker.Read(() => configuration.GetPackage(assembly));
	}

	/// <summary>
	/// 获取指定类型所在包程序集的包的配置
	/// </summary>
	/// <param name="type">包程序集</param>
	/// <returns>包配置对象</returns>
	public static IPackageConfiguration GetPackage(Type type)
	{
		type.GuardNotNull();
		return configuration.GetPackage(type.Assembly);
	}
}
