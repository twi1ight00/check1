using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 弱引用管理器
/// </summary>
public class WeakReferenceManager : IReferenceManager, IDisposable
{
	/// <summary>
	/// 弱引用计数缓存
	/// </summary>
	private Dictionary<WeakReference, int> cache;

	/// <summary>
	/// 引用计数
	/// </summary>
	private int referenceCount;

	/// <summary>
	/// 被管理的对象引用
	/// </summary>
	private IDisposable handler;

	/// <summary>
	/// 清理定时器
	/// </summary>
	private Timer timer;

	/// <summary>
	/// 同步读写锁
	/// </summary>
	private ISyncLocker syncLocker;

	/// <summary>
	/// 获取当前对象的引用计数
	/// </summary>
	public int ReferenceCount => syncLocker.Read(delegate
	{
		RefreshCache();
		return referenceCount;
	});

	/// <summary>
	/// 指示当前的对象是否可以执行清理
	/// </summary>
	public bool IsDisposable => syncLocker.Read(() => referenceCount <= 0);

	/// <summary>
	/// 初始化独立的弱引用管理器
	/// </summary>
	/// <param name="locker">同步读写锁</param>
	public WeakReferenceManager(ISyncLocker locker)
	{
		syncLocker = locker.IfNull(new ReadWriteLocker());
		ISyncLocker obj = syncLocker;
		Action action = delegate
		{
			cache = new Dictionary<WeakReference, int>();
			referenceCount = 0;
			handler = null;
			timer = new Timer();
			timer.Interval = 3600000.0;
			timer.AutoReset = false;
			timer.Elapsed += DoTimerElapsed;
		};
		obj.Write(action);
	}

	/// <summary>
	/// 指定接受管理的对象，初始化弱引用管理器
	/// </summary>
	/// <param name="handler">接受管理的对象</param>
	/// <param name="locker">同步读写锁</param>
	public WeakReferenceManager(IDisposable handler, ISyncLocker locker)
	{
		WeakReferenceManager weakReferenceManager = this;
		handler.GuardNotNull();
		syncLocker = locker.IfNull(new ReadWriteLocker());
		ISyncLocker obj = syncLocker;
		Action action = delegate
		{
			weakReferenceManager.cache = new Dictionary<WeakReference, int>();
			weakReferenceManager.referenceCount = 0;
			weakReferenceManager.handler = handler;
			weakReferenceManager.timer = new Timer();
			weakReferenceManager.timer.Interval = 3600000.0;
			weakReferenceManager.timer.AutoReset = false;
			weakReferenceManager.timer.Elapsed += weakReferenceManager.DoTimerElapsed;
			weakReferenceManager.timer.Start();
		};
		obj.Write(action);
	}

	/// <summary>
	/// 刷新引用计数
	/// 移除所有无效引用
	/// 更新引用计数
	/// </summary>
	private void RefreshCache()
	{
		syncLocker.Write(delegate
		{
			KeyValuePair<WeakReference, int>[] array = cache.Where((KeyValuePair<WeakReference, int> kvp) => !kvp.Key.IsAlive).ToArray();
			foreach (KeyValuePair<WeakReference, int> keyValuePair in array)
			{
				cache.Remove(keyValuePair.Key);
			}
			referenceCount = cache.Values.Sum();
		});
	}

	/// <summary>
	/// 注册对象引用
	/// 如果注册的对象为空则返回当前的引用计数
	/// </summary>
	/// <param name="obj">注册当前对象的引用对象</param>
	/// <returns>返回当前对象被引用的数量 </returns>
	public int Register(object obj)
	{
		return syncLocker.Write(delegate
		{
			RefreshCache();
			if (obj.IsNull())
			{
				return referenceCount;
			}
			WeakReference weakReference = cache.Keys.FirstOrDefault((WeakReference wf) => wf.IsAlive && wf.Target.IsNotNull() && wf.Target.ReferenceEquals(obj));
			if (weakReference.IsNotNull())
			{
				cache[weakReference]++;
			}
			else
			{
				cache.Add(new WeakReference(obj), 1);
			}
			return ++referenceCount;
		});
	}

	/// <summary>
	/// 取消注册对象引用
	/// 如果取消注册的对象为空则返回当前的引用计数
	/// </summary>
	/// <param name="obj">取消注册当前对象的引用对象</param>
	/// <returns>返回当前对象被引用的数量 </returns>
	public int Unregister(object obj)
	{
		return syncLocker.Write(delegate
		{
			RefreshCache();
			if (obj.IsNull())
			{
				return referenceCount;
			}
			WeakReference weakReference = cache.Keys.FirstOrDefault((WeakReference wf) => wf.IsAlive && wf.Target.IsNotNull() && wf.Target.ReferenceEquals(obj));
			if (weakReference.IsNotNull())
			{
				cache[weakReference]--;
				if (cache[weakReference] <= 0)
				{
					cache.Remove(weakReference);
				}
				return --referenceCount;
			}
			return referenceCount;
		});
	}

	/// <summary>
	/// 清除引用，清理当前对象
	/// 如果当前对象不再被任何对象引用，则执行清理
	/// </summary>
	/// <param name="obj">应用当前对象的对象</param>
	/// <returns>如果对象清理成功返回true，否则返回false</returns>
	public bool Dispose(object obj)
	{
		return syncLocker.Write(delegate
		{
			if (Unregister(obj) <= 0)
			{
				referenceCount = 0;
				if (handler.IsNotNull())
				{
					handler.Dispose();
					return true;
				}
			}
			return false;
		});
	}

	/// <summary>
	/// 清理管理器
	/// </summary>
	public void Dispose()
	{
		syncLocker.Write(delegate
		{
			cache.Clear();
			referenceCount = 0;
		});
	}

	/// <summary>
	/// 定时器定时事件处理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void DoTimerElapsed(object sender, ElapsedEventArgs e)
	{
		syncLocker.Write(delegate
		{
			if (IsDisposable && handler.IsNotNull())
			{
				handler.Dispose();
			}
		});
	}
}
