using System;
using System.Timers;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控基类
/// </summary>
public abstract class Watcher : IWatcher, ISyncableObject, IReferencable, IDisposableObject, IDisposable
{
	/// <summary>
	/// 是否已经清理
	/// </summary>
	private bool isDisposed = false;

	/// <summary>
	/// 共享锁
	/// </summary>
	private ISyncLocker syncLocker;

	/// <summary>
	/// 引用管理器
	/// </summary>
	private IReferenceManager referenceManager;

	/// <summary>
	/// 监控定时器
	/// </summary>
	private IWatchingTimer watchingTimer;

	/// <summary>
	/// 事件处理器列表键对象
	/// </summary>
	private static readonly object AllWatchingHandlerKey = new object();

	/// <summary>
	/// 监控事件处理委托列表
	/// 这个列表中的委托对所有正在被监控的文件有效
	/// </summary>
	private EventHandlerSet watchingHandlers;

	/// <summary>
	/// 指示是否已经清理
	/// </summary>
	public bool IsDisposed
	{
		get
		{
			return syncLocker.Read(() => isDisposed);
		}
		private set
		{
			syncLocker.Write(() => isDisposed = value);
		}
	}

	/// <summary>
	/// 获取共享锁
	/// </summary>
	public ISyncLocker SyncRoot => syncLocker;

	/// <summary>
	/// 获取引用管理器
	/// </summary>
	public IReferenceManager ReferenceManager => referenceManager;

	/// <summary>
	/// 获取监控器定时器
	/// </summary>
	public virtual IWatchingTimer WatchingTimer
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return watchingTimer;
			});
		}
		set
		{
			syncLocker.Write(delegate
			{
				this.GuardNotDisposed();
				DisposeWatchingTimer();
				if (value.IsNotNull())
				{
					InitializeWatchingTimer(value);
					syncLocker = value.SyncRoot;
				}
				else
				{
					watchingTimer = null;
				}
			});
		}
	}

	/// <summary>
	/// 获取或者设置轮询时间间隔
	/// 如果设置的时间间隔小于等于0，则恢复为默认的时间间隔
	/// </summary>
	public virtual int WatchingInterval
	{
		get
		{
			return SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return watchingTimer.GuardNotNull(() => new InvalidOperationException(Literals.MSG_WatchingTimerNull)).PollingInterval;
			});
		}
		set
		{
			SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				watchingTimer.GuardNotNull(() => new InvalidOperationException(Literals.MSG_WatchingTimerNull)).PollingInterval = value;
			});
		}
	}

	/// <summary>
	/// 全局文件变更事件
	/// 对于所有的文件的变更都会触发
	/// </summary>
	public event WatchingEventHandler WatchingNotify
	{
		add
		{
			SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				AddHandler(value);
			});
		}
		remove
		{
			SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				RemoveHandler(value);
			});
		}
	}

	/// <summary>
	/// 创建监控器
	/// </summary>
	public Watcher()
		: this(0)
	{
	}

	/// <summary>
	/// 创建监控器
	/// </summary>
	/// <param name="watchingInterval">检测时间间隔</param>
	public Watcher(int watchingInterval)
		: this(new WatchingTimer(watchingInterval))
	{
	}

	/// <summary>
	/// 创建监控器
	/// 使用给定监控器的配置
	/// </summary>
	/// <param name="timer">监控定时器</param>
	public Watcher(IWatchingTimer timer)
	{
		Watcher watcher = this;
		timer.GuardNotNull("timer");
		syncLocker = timer.SyncRoot;
		ISyncLocker obj = syncLocker;
		Action action = delegate
		{
			watcher.isDisposed = false;
			watcher.watchingHandlers = new EventHandlerSet();
			watcher.InitializeWatchingTimer(timer);
			watcher.referenceManager = new ReferenceManager(watcher, watcher.syncLocker);
		};
		obj.Write(action);
	}

	/// <summary>
	/// 清除配置监控器
	/// </summary>
	~Watcher()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理配置监控器
	/// </summary>
	public void Dispose()
	{
		syncLocker.Write(delegate
		{
			if (!isDisposed && referenceManager.IsDisposable)
			{
				isDisposed = true;
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		});
	}

	/// <summary>
	/// 清理配置监控器
	/// </summary>
	/// <param name="disposing"></param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			DisposeWatchingTimer();
			watchingHandlers.Dispose();
		}
	}

	/// <summary>
	/// 初始化监控定时器
	/// </summary>
	/// <param name="timer"></param>
	private void InitializeWatchingTimer(IWatchingTimer timer)
	{
		if (watchingTimer.IsNotNull())
		{
			throw new InvalidOperationException(Literals.MSG_WatchingTimerInitialized);
		}
		timer.GuardNotNull("timer");
		syncLocker.Write(delegate
		{
			timer.ReferenceManager.Register(this);
			watchingTimer = timer;
			watchingTimer.TimerElapsed += DoWatchingTimerElapsed;
		});
	}

	/// <summary>
	/// 清理监控定时器
	/// </summary>
	protected virtual void DisposeWatchingTimer()
	{
		if (watchingTimer.IsNotNull())
		{
			if (watchingTimer.IsDisposed)
			{
				watchingTimer = null;
				return;
			}
			watchingTimer.TimerElapsed -= DoWatchingTimerElapsed;
			watchingTimer.ReferenceManager.Dispose(this);
			watchingTimer = null;
		}
	}

	/// <summary>
	/// 定时器定时触发事件处理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void DoWatchingTimerElapsed(object sender, ElapsedEventArgs e)
	{
		syncLocker.Read(delegate
		{
			if (!isDisposed)
			{
				OnWatchingNotify(e.SignalTime);
			}
		});
	}

	/// <summary>
	/// 监控事件触发
	/// </summary>
	/// <param name="watchingTime">事件触发时间</param>
	protected abstract void OnWatchingNotify(DateTime watchingTime);

	/// <summary>
	/// 启动监控器
	/// </summary>
	public void Start()
	{
		SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			watchingTimer.GuardNotNull(() => new InvalidOperationException(Literals.MSG_WatchingTimerNull)).Start();
		});
	}

	/// <summary>
	/// 停止监控器
	/// </summary>
	public void Stop()
	{
		SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			watchingTimer.GuardNotNull(() => new InvalidOperationException(Literals.MSG_WatchingTimerNull)).Stop();
		});
	}

	/// <summary>
	/// 刷新监控状态
	/// </summary>
	/// <param name="notify">是否触发通知事件</param>
	public abstract void Refresh(bool notify = true);

	/// <summary>
	/// 添加全局事件处理委托
	/// </summary>
	/// <param name="handler"></param>
	protected void AddHandler(Delegate handler)
	{
		AddHandler(AllWatchingHandlerKey, handler);
	}

	/// <summary>
	/// 添加事件处理委托
	/// </summary>
	/// <param name="key"></param>
	/// <param name="handler"></param>
	protected void AddHandler(object key, Delegate handler)
	{
		this.GuardNotDisposed();
		key.GuardNotNull("handler key");
		watchingHandlers.AddHandler(key, handler);
	}

	/// <summary>
	/// 移除事件处理委托
	/// </summary>
	/// <param name="key"></param>
	protected void RemoveHandler(object key)
	{
		this.GuardNotDisposed();
		key.GuardNotNull("handler key");
		watchingHandlers.RemoveHandler(key);
	}

	/// <summary>
	/// 移除全局事件处理委托
	/// </summary>
	/// <param name="handler"></param>
	protected void RemoveHandler(Delegate handler)
	{
		RemoveHandler(AllWatchingHandlerKey, handler);
	}

	/// <summary>
	/// 移除事件处理委托
	/// </summary>
	/// <param name="key"></param>
	/// <param name="handler"></param>
	protected void RemoveHandler(object key, Delegate handler)
	{
		this.GuardNotDisposed();
		key.GuardNotNull("handler key");
		watchingHandlers.RemoveHandler(key, handler);
	}

	/// <summary>
	/// 获取全局事件处理委托
	/// </summary>
	/// <returns></returns>
	protected Delegate[] GetHandlers()
	{
		this.GuardNotDisposed();
		return watchingHandlers.GetHandlers(AllWatchingHandlerKey);
	}

	/// <summary>
	/// 获取全局事件处理委托数量
	/// </summary>
	/// <returns></returns>
	protected int GetHandlerCount()
	{
		this.GuardNotDisposed();
		return watchingHandlers.GetCount(AllWatchingHandlerKey);
	}

	/// <summary>
	/// 获取指定分类的事件处理委托
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	protected Delegate[] GetHandlers(object key)
	{
		this.GuardNotDisposed();
		key.GuardNotNull("handler key");
		return watchingHandlers.GetHandlers(key);
	}

	/// <summary>
	/// 获取指定分类的事件处理委托数量
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	protected int GetHandlerCount(object key)
	{
		this.GuardNotDisposed();
		key.GuardNotNull("handler key");
		return watchingHandlers.GetCount(key);
	}
}
