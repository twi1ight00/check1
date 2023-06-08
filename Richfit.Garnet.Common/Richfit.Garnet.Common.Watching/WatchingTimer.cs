using System;
using System.Linq;
using System.Timers;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 监控定时器
/// </summary>
public class WatchingTimer : IWatchingTimer, ISyncableObject, IReferencable, IDisposableObject, IDisposable
{
	/// <summary>
	/// 定时器默认轮询间隔，单位毫秒
	/// </summary>
	private static int defaultPollingInterval = 15000;

	/// <summary>
	/// 是否已经清理
	/// </summary>
	private volatile bool isDisposed = false;

	/// <summary>
	/// 监控共享锁
	/// </summary>
	private ISyncLocker syncLocker;

	/// <summary>
	/// 引用管理器
	/// </summary>
	private IReferenceManager referenceManager;

	/// <summary>
	/// 轮询间隔时间，单位毫秒
	/// 默认15秒进行一次检查
	/// </summary>
	private volatile int pollingInterval;

	/// <summary>
	/// 监控器轮询定时器
	/// </summary>
	private Timer timer;

	/// <summary>
	/// 是否正在轮询的标识
	/// </summary>
	private volatile bool isPolling;

	/// <summary>
	/// 获取设置定时器默认轮询事件间隔, 单位毫秒
	/// </summary>
	public static int DefaultPollingInterval
	{
		get
		{
			return defaultPollingInterval;
		}
		set
		{
			defaultPollingInterval = value;
		}
	}

	/// <summary>
	/// 指示是否已经清理
	/// </summary>
	public bool IsDisposed => syncLocker.Read(() => isDisposed);

	/// <summary>
	/// 获取共享锁
	/// </summary>
	public ISyncLocker SyncRoot => syncLocker;

	/// <summary>
	/// 获取引用管理器
	/// </summary>
	public IReferenceManager ReferenceManager => referenceManager;

	/// <summary>
	/// 获取或者设置轮询时间间隔
	/// 如果设置的轮询时间间隔小于等于0，则恢复默认的时间间隔
	/// </summary>
	public int PollingInterval
	{
		get
		{
			return syncLocker.Read(delegate
			{
				this.GuardNotDisposed();
				return pollingInterval;
			});
		}
		set
		{
			syncLocker.Write(delegate
			{
				this.GuardNotDisposed();
				pollingInterval = ((value <= 0) ? DefaultPollingInterval : value);
			});
		}
	}

	/// <summary>
	/// 定时器定时事件
	/// </summary>
	public event ElapsedEventHandler TimerElapsed;

	/// <summary>
	/// 定时器启动事件
	/// </summary>
	public event EventHandler<WatchingTimerStartingEventArgs> TimerStarting;

	/// <summary>
	/// 定时器停止事件
	/// </summary>
	public event EventHandler<WatchingTimerStoppingEventArgs> TimerStopping;

	/// <summary>
	/// 定时器清理事件
	/// </summary>
	public event EventHandler TimerDisposed;

	/// <summary>
	/// 创建监控定时器实例
	/// </summary>
	public WatchingTimer()
	{
		Initialize(DefaultPollingInterval, null);
	}

	/// <summary>
	/// 创建监控定时器实例
	/// </summary>
	/// <param name="locker">同步共享锁</param>
	public WatchingTimer(ISyncLocker locker)
	{
		Initialize(DefaultPollingInterval, locker);
	}

	/// <summary>
	/// 创建监控定时器实例
	/// </summary>
	/// <param name="pollingInterval">轮询时间间隔</param>
	public WatchingTimer(int pollingInterval)
	{
		Initialize(pollingInterval, null);
	}

	/// <summary>
	/// 创建监控定时器实例
	/// </summary>
	/// <param name="pollingInterval">轮询时间间隔</param>
	/// <param name="locker">同步共享锁</param>
	public WatchingTimer(int pollingInterval, ISyncLocker locker)
	{
		Initialize(pollingInterval, locker);
	}

	/// <summary>
	/// 创建监控定时器实例
	/// </summary>
	/// <param name="pollingInterval">轮询时间间隔</param>
	public WatchingTimer(TimeSpan pollingInterval)
	{
		Initialize((int)pollingInterval.TotalMilliseconds, null);
	}

	/// <summary>
	/// 创建监控定时器实例
	/// </summary>
	/// <param name="pollingInterval">轮询时间间隔</param>
	/// <param name="locker">同步共享锁</param>
	public WatchingTimer(TimeSpan pollingInterval, ISyncLocker locker)
	{
		Initialize((int)pollingInterval.TotalMilliseconds, locker);
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="pollingInterval">轮询时间间隔</param>
	/// <param name="locker">同步共享锁</param>
	private void Initialize(int pollingInterval, ISyncLocker locker)
	{
		syncLocker = locker.IfNull(new ReadWriteLocker());
		syncLocker.Write(delegate
		{
			isDisposed = false;
			referenceManager = new ReferenceManager(this, syncLocker);
			InitializeTimer(pollingInterval);
		});
	}

	/// <summary>
	/// 析构
	/// </summary>
	~WatchingTimer()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象
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
	/// 执行清理
	/// </summary>
	/// <param name="disposing"></param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			DisposeTimer();
			OnTimerDisposed();
			this.TimerElapsed = null;
			this.TimerStarting = null;
			this.TimerStopping = null;
			this.TimerDisposed = null;
		}
	}

	/// <summary>
	/// 初始化定时器
	/// </summary>
	/// <param name="pollingInterval">轮询时间间隔</param>
	protected void InitializeTimer(int pollingInterval = 0)
	{
		timer.GuardNull(() => new InvalidOperationException(Literals.MSG_WatchingTimerInitialized));
		isPolling = false;
		timer = new Timer();
		timer.AutoReset = false;
		timer.Elapsed += DoTimerElapsed;
		PollingInterval = pollingInterval;
	}

	/// <summary>
	/// 清理定时器
	/// </summary>
	protected void DisposeTimer()
	{
		isPolling = false;
		timer.Stop();
		timer.Elapsed -= DoTimerElapsed;
		timer.Dispose();
	}

	/// <summary>
	/// 启动定时器
	/// </summary>
	public void Start()
	{
		syncLocker.Write(delegate
		{
			this.GuardNotDisposed();
			if (!OnTimerStarting())
			{
				timer.Interval = PollingInterval;
				isPolling = true;
				timer.Start();
			}
		});
	}

	/// <summary>
	/// 停止定时器
	/// </summary>
	public void Stop()
	{
		syncLocker.Write(delegate
		{
			this.GuardNotDisposed();
			if (!OnTimerStopping())
			{
				isPolling = false;
				timer.Stop();
			}
		});
	}

	/// <summary>
	/// 定时器定时事件处理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void DoTimerElapsed(object sender, ElapsedEventArgs e)
	{
		syncLocker.Read(delegate
		{
			if (isDisposed)
			{
				return;
			}
			try
			{
				if (isPolling)
				{
					OnTimerElapsed(e);
				}
			}
			finally
			{
				syncLocker.Write(delegate
				{
					if (isPolling)
					{
						timer.Interval = PollingInterval;
						timer.Start();
					}
				});
			}
		});
	}

	/// <summary>
	/// 触发定时器定时事件
	/// </summary>
	/// <param name="args"></param>
	private void OnTimerElapsed(ElapsedEventArgs args)
	{
		ElapsedEventHandler handler = this.TimerElapsed;
		if (handler.IsNotNull())
		{
			handler.GetInvocationList().OfType<ElapsedEventHandler>().All(delegate(ElapsedEventHandler callback)
			{
				callback(this, args);
				return true;
			});
		}
	}

	/// <summary>
	/// 触发定时器启动事件
	/// </summary>
	/// <returns>返回是否放弃启动标识</returns>
	private bool OnTimerStarting()
	{
		EventHandler<WatchingTimerStartingEventArgs> handler = this.TimerStarting;
		if (handler.IsNotNull())
		{
			WatchingTimerStartingEventArgs args = new WatchingTimerStartingEventArgs(DateTime.Now);
			handler.GetInvocationList().OfType<EventHandler<WatchingTimerStartingEventArgs>>().All(delegate(EventHandler<WatchingTimerStartingEventArgs> callback)
			{
				callback(this, args);
				return !args.Cancelled;
			});
			return args.Cancelled;
		}
		return false;
	}

	/// <summary>
	/// 触发定时器停止事件
	/// </summary>
	/// <returns>返回是否放弃停止标识</returns>
	private bool OnTimerStopping()
	{
		EventHandler<WatchingTimerStoppingEventArgs> handler = this.TimerStopping;
		if (handler.IsNotNull())
		{
			WatchingTimerStoppingEventArgs args = new WatchingTimerStoppingEventArgs(DateTime.Now);
			handler.GetInvocationList().OfType<EventHandler<WatchingTimerStoppingEventArgs>>().All(delegate(EventHandler<WatchingTimerStoppingEventArgs> callback)
			{
				callback(this, args);
				return !args.Cancelled;
			});
			return args.Cancelled;
		}
		return false;
	}

	/// <summary>
	/// 触发定时器清理事件
	/// </summary>
	private void OnTimerDisposed()
	{
		EventHandler handler = this.TimerDisposed;
		if (handler.IsNotNull())
		{
			handler.GetInvocationList().OfType<EventHandler>().All(delegate(EventHandler callback)
			{
				callback(this, null);
				return true;
			});
		}
	}
}
