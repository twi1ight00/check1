using System;
using System.Linq;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Threading;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置源的基础实现
/// 表示一个独立的配置来源（文件、数据库、流等）
/// 提供保存、刷新、监控等基础功能
/// </summary>
public abstract class ConfigurationSourceBase : ConfigurationSource
{
	/// <summary>
	/// 是否正在监控配置源,默认是true
	/// </summary>
	private bool isWatching;

	/// <summary>
	/// 配置源监控器
	/// </summary>
	private IWatcher watcher;

	/// <summary>
	/// 容器配置源的子配置源组
	/// </summary>
	private IConfigurationSourceGroup group;

	/// <summary>
	/// 获取或者设置是否正在监控配置源
	/// </summary>
	public bool IsWatching
	{
		get
		{
			return base.SyncRoot.Read(() => isWatching);
		}
		set
		{
			base.SyncRoot.Write(() => isWatching = value);
		}
	}

	/// <summary>
	/// 获取配置监控器
	/// </summary>
	public IWatcher Watcher
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return watcher;
			});
		}
		protected set
		{
			DisposeWatcher();
			value = CreateWatcher(value);
			if (value.IsNotNull())
			{
				base.SyncRoot = value.SyncRoot;
				watcher = value;
				isWatching = true;
			}
		}
	}

	/// <summary>
	/// 获取容器的子配置源组对象
	/// </summary>
	public virtual IConfigurationSourceGroup Group
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return group;
			});
		}
		protected set
		{
			group = value;
		}
	}

	/// <summary>
	/// 获取配置源数组
	/// </summary>
	public IConfigurationSource[] Sources => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetSources();
	});

	/// <summary>
	/// 获取配置源数组及其所有子配置源的数组
	/// </summary>
	public IConfigurationSource[] AllSources => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return Group.GetGroupSources();
	});

	/// <summary>
	/// 配置源变更事件
	/// </summary>
	public event ConfigurationSourceChangedEventHandler SourceChanged;

	/// <summary>
	/// 配置源清理前事件
	/// </summary>
	public event ConfigurationSourceDisposingEventHandler SourceDisposing;

	/// <summary>
	/// 配置源清理事件
	/// </summary>
	public event ConfigurationSourceDisposedEventHandler SourceDisposed;

	/// <summary>
	/// 指定配置源名称和同步锁初始化配置源
	/// </summary>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="locker">同步锁</param>
	protected ConfigurationSourceBase(string sourceName, ISyncLocker locker)
		: base(locker)
	{
		base.SyncRoot = locker;
		isWatching = false;
		base.SourceName = sourceName;
		base.Owner = null;
		group = null;
	}

	/// <summary>
	/// 初始化配置源
	/// </summary>
	/// <param name="ownerGroup">配置源所属的配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="watcher">配置源监控器</param>
	protected ConfigurationSourceBase(IConfigurationSourceGroup ownerGroup, string sourceName, IWatcher watcher)
	{
		watcher = CreateWatcher(watcher);
		if (watcher.IsNotNull())
		{
			base.SyncRoot = watcher.SyncRoot;
			this.watcher = watcher;
			isWatching = true;
		}
		base.SourceName = sourceName;
		base.Owner = ownerGroup;
		group = null;
	}

	/// <summary>
	/// 初始化配置源
	/// </summary>
	/// <param name="ownerGroup">配置源所属的配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="timer">配置源监控定时器</param>
	protected ConfigurationSourceBase(IConfigurationSourceGroup ownerGroup, string sourceName, IWatchingTimer timer)
	{
		IWatcher watcher = CreateWatcher(timer);
		if (watcher.IsNotNull())
		{
			base.SyncRoot = watcher.SyncRoot;
			this.watcher = watcher;
			isWatching = true;
		}
		base.SourceName = sourceName;
		base.Owner = ownerGroup;
		group = null;
	}

	/// <summary>
	/// 析构
	/// </summary>
	~ConfigurationSourceBase()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public sealed override void Dispose()
	{
		base.SyncRoot.Write(delegate
		{
			if (!base.IsDisposed && !OnSourceDisposing())
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
				OnSourceDisposed();
				this.SourceChanged = null;
				this.SourceDisposing = null;
				this.SourceDisposed = null;
			}
		});
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing">是否已经执行了清理</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			DisposeWatcher();
			base.Owner = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 创建配置源监控器
	/// </summary>
	/// <param name="obj">监控器初始化对象，配置监控器或者是配置监控定时器</param>
	/// <returns>创建的配置源监控器</returns>
	protected virtual IWatcher CreateWatcher(object obj)
	{
		if (obj.IsNull())
		{
			return null;
		}
		if (obj is IWatcher)
		{
			IWatcher watcher = (IWatcher)obj;
			watcher.ReferenceManager.Register(this);
			watcher.WatchingNotify += OnWatchingNotify;
			return watcher;
		}
		throw new ArgumentException();
	}

	/// <summary>
	/// 清理监控器
	/// </summary>
	protected virtual void DisposeWatcher()
	{
		if (watcher.IsNotNull())
		{
			watcher.WatchingNotify -= OnWatchingNotify;
			watcher.ReferenceManager.Dispose(this);
			watcher = null;
		}
		isWatching = false;
	}

	/// <summary>
	/// 监控器事件处理器
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	protected virtual void OnWatchingNotify(object sender, WatchingEventArgs args)
	{
		base.SyncRoot.Read(delegate
		{
			if (isWatching && !base.IsDisposed)
			{
			}
		});
	}

	/// <summary>
	/// 刷新配置源
	/// 为IRefreshableConfigurationSource接口提供基础实现
	/// </summary>
	public virtual void Refresh()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (watcher.IsNotNull())
			{
				watcher.Refresh();
			}
		});
	}

	/// <summary>
	/// 保存配置源
	/// 为ISavableConfigurationSource接口提供基础实现
	/// </summary>
	public abstract void Save();

	/// <summary>
	/// 触发配置变更事件
	/// </summary>
	/// <param name="status">配置源变更状态</param>
	protected virtual void OnSourceChanged(ConfigurationSourceStatus status)
	{
		ConfigurationSourceChangedEventHandler handler = this.SourceChanged;
		if (handler.IsNotNull())
		{
			handler(this, new ConfigurationSourceChangedEventArgs(this, status));
		}
	}

	/// <summary>
	/// 触发配置源清理前事件
	/// </summary>
	/// <returns></returns>
	protected virtual bool OnSourceDisposing()
	{
		ConfigurationSourceDisposingEventHandler handler = this.SourceDisposing;
		if (handler.IsNotNull())
		{
			ConfigurationSourceDisposingEventArgs args = new ConfigurationSourceDisposingEventArgs(this);
			handler(this, args);
			return args.Cancelled;
		}
		return false;
	}

	/// <summary>
	/// 触发配置源清理事件
	/// </summary>
	protected virtual void OnSourceDisposed()
	{
		ConfigurationSourceDisposedEventHandler handler = this.SourceDisposed;
		if (handler.IsNotNull())
		{
			handler(this, new ConfigurationSourceDisposedEventArgs(this));
		}
	}

	/// <summary>
	/// 获取指定类型的所有配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的所有配置源</returns>
	public T[] GetAll<T>(bool recursive = false) where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return recursive ? Group.GetGroupSources<T>() : Group.GetSources<T>();
		});
	}

	/// <summary>
	/// 获取指定的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的配置源</returns>
	public T Get<T>(bool recursive = false) where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetAll<T>(recursive).FirstOrDefault();
		});
	}

	/// <summary>
	/// 获取指定的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="name">配置源类型名称</param>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的配置源</returns>
	public T Get<T>(string name, bool recursive = false) where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			name = name.IfNull(string.Empty);
			return (from s in GetAll<T>(recursive)
				where s.SourceName.EqualOrdinal(name, ignoreCase: true)
				select s).FirstOrDefault();
		});
	}
}
