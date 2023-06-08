using System;
using System.Linq;
using System.Reflection;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 包配置对象
/// </summary>
public class PackageConfigurationSource : DotNetGroupConfigurationSource, IPackageConfiguration, IConfiguration, IPackageConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 包配置节
	/// </summary>
	private PackageConfigurationSection section;

	/// <summary>
	/// 包的设置配置组
	/// </summary>
	private ISettingsGroupConfiguration settingsGroup;

	/// <summary>
	/// 包的SQL配置组
	/// </summary>
	private ISqlGroupConfiguration sqlGroup;

	/// <summary>
	/// 获取包ID
	/// </summary>
	public string PackageID
	{
		get
		{
			return base.SourceName;
		}
		protected set
		{
			base.SourceName = value.IfNull(string.Empty);
		}
	}

	/// <summary>
	/// 获取包名称
	/// 包名称既是配置源名称
	/// </summary>
	public string PackageName
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return section.IsNull() ? null : section.Package.Name;
			});
		}
		protected set
		{
			if (section.IsNotNull())
			{
				section.Package.Name = value.IfNull(string.Empty);
			}
		}
	}

	/// <summary>
	/// 获取包的位置
	/// </summary>
	public string PackageLocation => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return base.File.IsNull() ? string.Empty : base.File.Directory.FullName;
	});

	/// <summary>
	/// 获取包程序集列表
	/// </summary>
	public Assembly[] Assemblies => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return section.IsNull() ? null : section.Assemblies.ToArray((PackageConfigurationAssemblyElement x) => x.Assembly);
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
	/// 获取包的设置配置组
	/// </summary>
	public ISettingsGroupConfiguration Settings => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return settingsGroup;
	});

	/// <summary>
	/// 获取包的SQL配置组
	/// </summary>
	/// <returns></returns>
	public ISqlGroupConfiguration Sqls => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return sqlGroup;
	});

	/// <summary>
	/// 使用指定的包配置文件初始化包配置对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="packageID">包ID</param>
	/// <param name="manifestFile">包清单文件</param>
	/// <param name="watcher">配置源监控器</param>
	public PackageConfigurationSource(IConfigurationSourceGroup sourceGroup, string packageID, string manifestFile, IWatcher watcher)
		: base(sourceGroup, packageID, manifestFile, watcher)
	{
	}

	/// <summary>
	/// 使用指定的包配置文件初始化包配置对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="packageID">包ID</param>
	/// <param name="manifestFile">包清单文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public PackageConfigurationSource(IConfigurationSourceGroup sourceGroup, string packageID, string manifestFile, IWatchingTimer timer)
		: base(sourceGroup, packageID, manifestFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~PackageConfigurationSource()
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
			if (settingsGroup.IsNotNull())
			{
				settingsGroup.Dispose();
				settingsGroup = null;
			}
			if (sqlGroup.IsNotNull())
			{
				sqlGroup.Dispose();
				sqlGroup = null;
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
			base.LoadConfiguration();
			section = GetSection<PackageConfigurationSection>();
			section.Assemblies.ForEach(delegate(PackageConfigurationAssemblyElement x)
			{
				x.Assembly.IsNotNull();
			});
			settingsGroup = new SettingsConfigurationSourceGroup(Group);
			sqlGroup = new SqlConfigurationSourceGroup(Group);
			return base.IsValid = section.IsNotNull();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	/// <summary>
	/// 获取指定名称的包程序集，不存在指定名称的包程序集返回null
	/// </summary>
	/// <param name="name">包程序集名称</param>
	/// <returns>包程序集</returns>
	public Assembly GetAssembly(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return section.IsNull() ? null : (section.Assemblies.Contains(name) ? section.Assemblies.Get(name).Assembly : null);
		});
	}

	/// <summary>
	/// 添加包程序集
	/// </summary>
	/// <param name="assembly">添加的包程序集</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	public bool AddAssembly(Assembly assembly)
	{
		assembly.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section.Assemblies.Where((PackageConfigurationAssemblyElement element) => element.Assembly.FullName.EqualOrdinal(assembly.FullName)).Count() > 0)
			{
				return false;
			}
			section.Assemblies.Add(new PackageConfigurationAssemblyElement
			{
				Assembly = assembly
			});
			return true;
		});
	}

	/// <summary>
	/// 添加包程序集
	/// </summary>
	/// <param name="name">包程序集名称</param>
	/// <param name="assembly">添加的包程序集</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	public bool AddAssembly(string name, Assembly assembly)
	{
		name.GuardNotNull();
		assembly.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section.Assemblies.Contains(name))
			{
				return false;
			}
			section.Assemblies.Add(new PackageConfigurationAssemblyElement
			{
				Name = name,
				Assembly = assembly
			});
			return true;
		});
	}

	/// <summary>
	/// 移除包程序集
	/// </summary>
	/// <param name="name">包程序集名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	public bool RemoveAssembly(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section.Assemblies.Contains(name))
			{
				section.Assemblies.Remove(name);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 移除包程序集
	/// </summary>
	/// <param name="assembly">待移除的包程序集</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	public bool RemoveAssembly(Assembly assembly)
	{
		assembly.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			PackageConfigurationAssemblyElement[] array = section.Assemblies.Where((PackageConfigurationAssemblyElement element) => element.Assembly.FullName.EqualOrdinal(assembly.FullName)).ToArray();
			if (array.Length > 0)
			{
				PackageConfigurationAssemblyElement[] array2 = array;
				foreach (PackageConfigurationAssemblyElement element2 in array2)
				{
					section.Assemblies.Remove(element2);
				}
				return true;
			}
			return false;
		});
	}
}
