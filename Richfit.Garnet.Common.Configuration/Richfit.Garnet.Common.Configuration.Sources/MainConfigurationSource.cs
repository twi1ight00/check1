using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 主配置源
/// App.config或者Web.config
/// </summary>
public class MainConfigurationSource : DotNetGroupConfigurationSource, IMainConfiguration, IConfiguration, IMainConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// Unity容器配置
	/// </summary>
	private IUnityGroupConfiguration unityConfiguration;

	/// <summary>
	/// 拦截配置
	/// </summary>
	private IInterceptionGroupConfiguration interceptionConfiguration;

	/// <summary>
	/// 获取系统配置
	/// </summary>
	public ISystemConfiguration Settings => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSource<ISystemConfiguration>();
	});

	/// <summary>
	/// 获取数据库配置
	/// </summary>
	public IDatabaseConfiguration Database => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSource<IDatabaseConfiguration>();
	});

	/// <summary>
	/// 获取组配置
	/// </summary>
	public IGroupConfiguration Collection => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSource<IGroupConfiguration>();
	});

	/// <summary>
	/// Quartz定时任务配置
	/// </summary>
	public IQuartzConfiguration Quartz => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSource<IQuartzConfiguration>();
	});

	/// <summary>
	/// Log4Net配置
	/// </summary>
	public ILog4NetConfiguration Log4Net => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSource<ILog4NetConfiguration>();
	});

	/// <summary>
	/// Common.Logging组件配置
	/// </summary>
	public ICommonLoggingConfiguration CommonLogging => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSource<ICommonLoggingConfiguration>();
	});

	/// <summary>
	/// 获取容器配置
	/// </summary>
	public IUnityGroupConfiguration Unity => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return unityConfiguration;
	});

	/// <summary>
	/// 获取拦截配置
	/// </summary>
	public IInterceptionGroupConfiguration Interception => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return interceptionConfiguration;
	});

	/// <summary>
	/// 获取所有包的配置对象
	/// </summary>
	public IPackageConfiguration[] Packages => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSources<IPackageConfiguration>();
	});

	/// <summary>
	/// 获取当前包的配置对象
	/// </summary>
	public IPackageConfiguration CurrentPackage
	{
		get
		{
			Assembly currentAssembly = Assembly.GetCallingAssembly();
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return GetPackage(currentAssembly);
			});
		}
	}

	/// <summary>
	/// 获取当前包的配置对象
	/// </summary>
	public IPackageConfiguration CurrentWeb => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return HttpContext.Current.IsNull() ? null : (from source in Group.GetSources<IPackageConfiguration>()
			where HttpContext.Current.Request.PhysicalPath.StartsWith(source.PackageLocation)
			select source).FirstOrDefault();
	});

	/// <summary>
	/// 初始化主配置源
	/// </summary>
	/// <param name="configuration">待加载的主配置源</param>
	/// <param name="watcher">配置源监控器</param>
	public MainConfigurationSource(System.Configuration.Configuration configuration, IWatcher watcher)
		: base(null, Path.GetFileNameWithoutExtension(configuration.FilePath), configuration, watcher)
	{
	}

	/// <summary>
	/// 初始化主配置源
	/// </summary>
	/// <param name="configuration">待加载的主配置源</param>
	/// <param name="timer">配置源监控定时器</param>
	public MainConfigurationSource(System.Configuration.Configuration configuration, IWatchingTimer timer)
		: base(null, Path.GetFileNameWithoutExtension(configuration.FilePath), configuration, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~MainConfigurationSource()
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
			if (unityConfiguration.IsNotNull())
			{
				unityConfiguration.Dispose();
				unityConfiguration = null;
			}
			if (interceptionConfiguration.IsNotNull())
			{
				interceptionConfiguration.Dispose();
				interceptionConfiguration = null;
			}
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
			bool status = base.LoadConfiguration();
			if (unityConfiguration.IsNotNull())
			{
				unityConfiguration.Dispose();
			}
			unityConfiguration = new UnityConfigurationSourceGroup(Group, recursive: true);
			if (interceptionConfiguration.IsNotNull())
			{
				interceptionConfiguration.Dispose();
			}
			interceptionConfiguration = new InterceptionConfigurationSourceGroup(Group, recursive: true);
			return status;
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 按照包名称获取包配置对象
	/// </summary>
	/// <param name="packageName">包名称</param>
	/// <returns>包配置对象</returns>
	public IPackageConfiguration GetPackage(string packageName)
	{
		packageName.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return (from x in Group.GetSources<IPackageConfiguration>()
				where x.PackageID.EqualOrdinal(packageName, ignoreCase: true) || x.PackageName.EqualOrdinal(packageName, ignoreCase: true)
				select x).FirstOrDefault();
		});
	}

	/// <summary>
	/// 获取包含指定程序集的包的配置
	/// </summary>
	/// <param name="assembly">包程序集</param>
	/// <returns>包配置对象</returns>
	public IPackageConfiguration GetPackage(Assembly assembly)
	{
		assembly.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return (from x in Group.GetSources<IPackageConfiguration>()
				where x.Assemblies.Contains(assembly, (Assembly a, Assembly b) => a.FullName.EqualOrdinal(b.FullName))
				select x).FirstOrDefault();
		});
	}

	/// <summary>
	/// 获取指定类型所在包程序集的包的配置
	/// </summary>
	/// <param name="type">包程序集</param>
	/// <returns>包配置对象</returns>
	public IPackageConfiguration GetPackage(Type type)
	{
		type.GuardNotNull();
		return GetPackage(type.Assembly);
	}
}
