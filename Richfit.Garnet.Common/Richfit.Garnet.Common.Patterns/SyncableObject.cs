using System;
using System.Threading;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 可同步对象基类
/// </summary>
public class SyncableObject : DisposableObject, ISyncableObject
{
	/// <summary>
	/// 同步锁对象
	/// </summary>
	private ISyncLocker locker;

	/// <summary>
	/// 获取同步锁对象
	/// </summary>
	public ISyncLocker SyncRoot
	{
		get
		{
			ISyncLocker locker = this.locker.GuardNotNull(typeof(ObjectDisposedException), "SyncRoot");
			return locker.Read(delegate
			{
				CheckDisposed();
				return locker;
			});
		}
	}

	/// <summary>
	/// 初始化
	/// </summary>
	protected SyncableObject()
	{
		locker = SyncLocker.Create();
	}

	/// <summary>
	/// 执行对象清理
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		ISyncLocker locker = Interlocked.Exchange(ref this.locker, null);
		if (locker.IsNotNull())
		{
			locker.Write(delegate
			{
				DisposeSync(disposing);
				Dispose();
			});
			locker.Dispose();
		}
	}

	/// <summary>
	/// 同步对象清理
	/// </summary>
	protected virtual void DisposeSync(bool disposing)
	{
	}
}
