using System;
using System.Threading;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 读写共享锁
/// </summary>
public sealed class ReadWriteLocker : SyncLocker
{
	/// <summary>
	/// 基础锁对象
	/// </summary>
	private ReaderWriterLock locker;

	/// <summary>
	/// 线程锁定状态
	/// </summary>
	private ThreadLocal<LockCookie?> lockCookie;

	/// <summary>
	/// 获取基础锁对象
	/// </summary>
	protected override object Locker => locker;

	/// <summary>
	/// 初始化
	/// </summary>
	public ReadWriteLocker()
		: this(-1)
	{
	}

	/// <summary>
	/// 使用指定的超时时间初始化，单位毫秒
	/// </summary>
	/// <param name="timeout">阻塞超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public ReadWriteLocker(int timeout)
		: base(timeout)
	{
		locker = new ReaderWriterLock();
		lockCookie = new ThreadLocal<LockCookie?>();
	}

	/// <summary>
	/// 使用指定的超时时间间隔，单位毫秒
	/// </summary>
	/// <param name="timeout">阻塞超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public ReadWriteLocker(TimeSpan timeout)
		: this((int)timeout.TotalMilliseconds)
	{
	}

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public override void Only(Action action)
	{
		Only(action, base.Timeout);
	}

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override void Only(Action action, int timeout)
	{
		Write(action, timeout);
	}

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override void Only(Action action, TimeSpan timeout)
	{
		Only(action, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理函数返回值类型</typeparam>
	/// <param name="func">独占处理函数</param>
	/// <returns>独占处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	public override T Only<T>(Func<T> func)
	{
		return Only(func, base.Timeout);
	}

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理函数返回值类型</typeparam>
	/// <param name="func">独占处理函数</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <returns>独占处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override T Only<T>(Func<T> func, int timeout)
	{
		return Write(func, timeout);
	}

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理函数返回值类型</typeparam>
	/// <param name="func">独占处理函数</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <returns>独占处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override T Only<T>(Func<T> func, TimeSpan timeout)
	{
		return Only(func, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	public override void Read()
	{
		Read(base.Timeout);
	}

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override void Read(int timeout)
	{
		timeout.GuardGreaterThanOrEqualTo(-1, "timeout");
		ReaderWriterLock locker = this.locker.GuardNotNull(typeof(ObjectDisposedException), "SyncRoot");
		if (locker.IsReaderLockHeld || locker.IsWriterLockHeld)
		{
			CheckDisposed();
			return;
		}
		CheckDisposed();
		locker.AcquireReaderLock(timeout);
	}

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override void Read(TimeSpan timeout)
	{
		Read((int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">读取处理方法 <paramref name="action" /> 为空。</exception>
	public override void Read(Action action)
	{
		Read(action, base.Timeout);
	}

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">读取处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override void Read(Action action, int timeout)
	{
		action.GuardNotNull("action");
		Read(delegate
		{
			action();
			return 0;
		}, timeout);
	}

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">读取处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override void Read(Action action, TimeSpan timeout)
	{
		Read(action, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理函数并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理函数返回值类型</typeparam>
	/// <param name="func">读取处理函数</param>
	/// <returns>读取处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">读取处理函数 <paramref name="func" /> 为空。</exception>
	public override T Read<T>(Func<T> func)
	{
		return Read(func, base.Timeout);
	}

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理函数并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理函数返回值类型</typeparam>
	/// <param name="func">读取处理函数</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">读取处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override T Read<T>(Func<T> func, int timeout)
	{
		func.GuardNotNull("func");
		timeout.GuardGreaterThanOrEqualTo(-1, "timeout");
		ReaderWriterLock locker = this.locker.GuardNotNull("SyncRoot");
		if (locker.IsReaderLockHeld || locker.IsWriterLockHeld)
		{
			CheckDisposed();
			return func();
		}
		locker.AcquireReaderLock(timeout);
		try
		{
			CheckDisposed();
			return func();
		}
		finally
		{
			locker.ReleaseReaderLock();
		}
	}

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理函数返回值类型</typeparam>
	/// <param name="func">读取处理函数</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">读取处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override T Read<T>(Func<T> func, TimeSpan timeout)
	{
		return Read(func, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	public override void UpgradableRead()
	{
		UpgradableRead(base.Timeout);
	}

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override void UpgradableRead(int timeout)
	{
		Write(timeout);
	}

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override void UpgradableRead(TimeSpan timeout)
	{
		UpgradableRead((int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public override void UpgradableRead(Action action)
	{
		UpgradableRead(action, base.Timeout);
	}

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override void UpgradableRead(Action action, TimeSpan timeout)
	{
		UpgradableRead(action, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override void UpgradableRead(Action action, int timeout)
	{
		Write(action, timeout);
	}

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理函数返回值类型</typeparam>
	/// <param name="func">读取处理函数</param>
	/// <returns>读取函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	public override T UpgradableRead<T>(Func<T> func)
	{
		return UpgradableRead(func, base.Timeout);
	}

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理函数返回值类型</typeparam>
	/// <param name="func">读取处理函数</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override T UpgradableRead<T>(Func<T> func, int timeout)
	{
		return Write(func, timeout);
	}

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理函数返回值类型</typeparam>
	/// <param name="func">读取处理函数</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override T UpgradableRead<T>(Func<T> func, TimeSpan timeout)
	{
		return UpgradableRead(func, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	public override void Write()
	{
		Write(base.Timeout);
	}

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	/// <param name="timeout">写入等待超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override void Write(int timeout)
	{
		timeout.GuardGreaterThanOrEqualTo(-1, "timeout");
		ReaderWriterLock locker = this.locker.GuardNotNull("SyncRoot");
		if (locker.IsWriterLockHeld)
		{
			CheckDisposed();
		}
		else if (locker.IsReaderLockHeld)
		{
			CheckDisposed();
			if (lockCookie.IsValueCreated && lockCookie.Value.IsNotNull())
			{
				throw new InvalidOperationException();
			}
			LockCookie cookie = locker.UpgradeToWriterLock(timeout);
			lockCookie.Value = cookie;
		}
		else
		{
			CheckDisposed();
			locker.AcquireWriterLock(timeout);
		}
	}

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	/// <param name="timeout">写入等待超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override void Write(TimeSpan timeout)
	{
		Write((int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public override void Write(Action action)
	{
		Write(action, base.Timeout);
	}

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override void Write(Action action, int timeout)
	{
		action.GuardNotNull("action");
		Write(delegate
		{
			action();
			return 0;
		}, timeout);
	}

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override void Write(Action action, TimeSpan timeout)
	{
		Write(action, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理函数返回值类型</typeparam>
	/// <param name="func">写入处理函数</param>
	/// <returns>写入处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	public override T Write<T>(Func<T> func)
	{
		return Write(func, base.Timeout);
	}

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理函数返回值类型</typeparam>
	/// <param name="func">写入处理函数</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <returns>写入处理函数返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public override T Write<T>(Func<T> func, int timeout)
	{
		func.GuardNotNull("func");
		timeout.GuardGreaterThanOrEqualTo(-1, "timeout");
		ReaderWriterLock locker = this.locker.GuardNotNull("SyncRoot");
		if (locker.IsWriterLockHeld)
		{
			CheckDisposed();
			return func();
		}
		if (locker.IsReaderLockHeld)
		{
			LockCookie cookie = locker.UpgradeToWriterLock(timeout);
			try
			{
				CheckDisposed();
				return func();
			}
			finally
			{
				locker.DowngradeFromWriterLock(ref cookie);
			}
		}
		locker.AcquireWriterLock(timeout);
		try
		{
			CheckDisposed();
			return func();
		}
		finally
		{
			locker.ReleaseWriterLock();
		}
	}

	/// <summary>
	/// 在写入模式锁定状态下执行指定的函数并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理函数返回值类型</typeparam>
	/// <param name="func">写入处理函数</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <returns>写入处理方法返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">处理函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public override T Write<T>(Func<T> func, TimeSpan timeout)
	{
		return Write(func, (int)timeout.TotalMilliseconds);
	}

	/// <summary>
	/// 释放模式锁定状态
	/// </summary>
	/// <exception cref="T:System.ObjectDisposedException">当前对象已经被清理释放。</exception>
	public override void Release()
	{
		ReaderWriterLock locker = this.locker.GuardNotNull("SyncRoot");
		if (locker.IsWriterLockHeld)
		{
			CheckDisposed();
			if (lockCookie.IsValueCreated && lockCookie.Value.IsNotNull())
			{
				LockCookie cookie = lockCookie.Value.Value;
				locker.DowngradeFromWriterLock(ref cookie);
				lockCookie.Value = null;
			}
			else
			{
				locker.ReleaseWriterLock();
			}
		}
		if (locker.IsReaderLockHeld)
		{
			CheckDisposed();
			locker.ReleaseReaderLock();
		}
		else
		{
			CheckDisposed();
		}
	}

	/// <summary>
	/// 执行对象清理
	/// </summary>
	/// <param name="disposing">从Dispose方法调用设置为true，从析构函数调用设置为false</param>
	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		ReaderWriterLock locker = Interlocked.Exchange(ref this.locker, null);
		if (!locker.IsNotNull())
		{
			return;
		}
		locker.AcquireWriterLock(-1);
		try
		{
			if (lockCookie.IsNotNull())
			{
				lockCookie.Dispose();
				lockCookie = null;
			}
			base.Dispose(disposing);
		}
		finally
		{
			locker.ReleaseWriterLock();
		}
	}
}
