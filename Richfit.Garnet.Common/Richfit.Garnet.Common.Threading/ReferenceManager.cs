using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 共享引用管理器
/// 当共享引用计数为零时则清理被管理的对象
/// </summary>
public class ReferenceManager : IReferenceManager, IDisposable
{
	/// <summary>
	/// 引用计数缓存
	/// </summary>
	private Dictionary<object, int> cache;

	/// <summary>
	/// 引用总计数
	/// </summary>
	private int referenceCount;

	/// <summary>
	/// 被管理的对象
	/// </summary>
	private IDisposable handler;

	/// <summary>
	/// 同步读写锁
	/// </summary>
	private ISyncLocker syncLocker;

	/// <summary>
	/// 获取当前对象的引用计数
	/// </summary>
	public int ReferenceCount => syncLocker.Read(() => referenceCount);

	/// <summary>
	/// 指示当前的对象是否可以执行清理
	/// </summary>
	public bool IsDisposable => syncLocker.Read(() => referenceCount <= 0);

	/// <summary>
	/// 初始化独立的引用管理器
	/// </summary>
	/// <param name="locker">同步读写锁</param>
	public ReferenceManager(ISyncLocker locker)
	{
		syncLocker = locker.IfNull(new ReadWriteLocker());
		ISyncLocker obj = syncLocker;
		Action action = delegate
		{
			cache = new Dictionary<object, int>();
			referenceCount = 0;
			handler = null;
		};
		obj.Write(action);
	}

	/// <summary>
	/// 指定被管理的对象初始化引用管理器
	/// </summary>
	/// <param name="obj">被管理的对象</param>
	/// <param name="locker">同步读写锁</param>
	public ReferenceManager(IDisposable obj, ISyncLocker locker)
	{
		ReferenceManager referenceManager = this;
		obj.GuardNotNull("referencable object");
		syncLocker = locker.IfNull(new ReadWriteLocker());
		ISyncLocker obj2 = syncLocker;
		Action action = delegate
		{
			referenceManager.cache = new Dictionary<object, int>();
			referenceManager.referenceCount = 0;
			referenceManager.handler = obj;
		};
		obj2.Write(action);
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
			if (obj.IsNull())
			{
				return referenceCount;
			}
			if (cache.ContainsKey(obj))
			{
				cache[obj]++;
			}
			else
			{
				cache.Add(obj, 1);
			}
			return ++referenceCount;
		});
	}

	/// <summary>
	/// 取消注册对象引用
	/// 如果注册的对象为空则返回当前的引用计数
	/// </summary>
	/// <param name="obj">取消注册当前对象的引用对象</param>
	/// <returns>返回当前对象被引用的数量 </returns>
	public int Unregister(object obj)
	{
		return syncLocker.Write(delegate
		{
			if (obj.IsNotNull() && cache.ContainsKey(obj))
			{
				cache[obj]--;
				if (cache[obj] <= 0)
				{
					cache.Remove(obj);
				}
				referenceCount--;
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
}
