#define DEBUG
using System;
using System.Threading;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 线程辅助类
/// </summary>
public static class ThreadHelper
{
	/// <summary>
	/// 使当前锁对象进入读取模式锁定状态，调用指定的方法
	/// </summary>
	/// <param name="locker">当前锁对象</param>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">进入读取锁定超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static void ReadLock(ReaderWriterLock locker, Action action, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.AcquireReaderLock(timeout);
		try
		{
			action();
		}
		finally
		{
			locker.ReleaseReaderLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入读取模式锁定状态，调用指定的函数
	/// </summary>
	/// <typeparam name="R">读取处理方法返回值类型</typeparam>
	/// <param name="locker">当前锁对象</param>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">进入读取锁定超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static R ReadLock<R>(ReaderWriterLock locker, Func<R> func, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(func, "func");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.AcquireReaderLock(timeout);
		try
		{
			return func();
		}
		finally
		{
			locker.ReleaseReaderLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入读取模式锁定状态，执行指定的方法
	/// </summary>
	/// <param name="locker">当前锁对象</param>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">进入读取锁定超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static void ReadLock(ReaderWriterLockSlim locker, Action action, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.TryEnterReadLock(timeout);
		try
		{
			action();
		}
		finally
		{
			locker.ExitReadLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入读取模式锁定状态，执行指定的函数
	/// </summary>
	/// <typeparam name="R">读取方法返回值类型</typeparam>
	/// <param name="locker">当前锁对象</param>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">进入读取锁定超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static R ReadLock<R>(ReaderWriterLockSlim locker, Func<R> func, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(func, "func");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.TryEnterReadLock(timeout);
		try
		{
			return func();
		}
		finally
		{
			locker.ExitReadLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入可升级读取模式锁定状态，执行指定的方法
	/// </summary>
	/// <param name="locker">当前锁对象</param>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">进入读取锁定超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static void UpgradableReadLock(ReaderWriterLockSlim locker, Action action, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.TryEnterUpgradeableReadLock(timeout);
		try
		{
			action();
		}
		finally
		{
			locker.ExitUpgradeableReadLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入可升级读取模式锁定状态，执行指定的函数
	/// </summary>
	/// <param name="locker">当前锁对象</param>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">进入读取锁定超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static R UpgradableReadLock<R>(ReaderWriterLockSlim locker, Func<R> func, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(func, "func");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.TryEnterUpgradeableReadLock(timeout);
		try
		{
			return func();
		}
		finally
		{
			locker.ExitUpgradeableReadLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入写入模式锁定状态，调用指定的方法
	/// </summary>
	/// <param name="locker">当前锁对象</param>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">进入写入锁定超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static void WriteLock(ReaderWriterLock locker, Action action, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		if (locker.IsReaderLockHeld)
		{
			LockCookie cookie = locker.UpgradeToWriterLock(timeout);
			try
			{
				action();
				return;
			}
			finally
			{
				locker.DowngradeFromWriterLock(ref cookie);
			}
		}
		locker.AcquireWriterLock(timeout);
		try
		{
			action();
		}
		finally
		{
			locker.ReleaseWriterLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入写入模式锁定状态，调用指定的函数
	/// </summary>
	/// <typeparam name="R">写入方法返回值类型</typeparam>
	/// <param name="locker">当前锁对象</param>
	/// <param name="func">写入处理方法</param>
	/// <param name="timeout">进入写入锁定超时时间</param>
	/// <returns>写入处理方法返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static R WriteLock<R>(ReaderWriterLock locker, Func<R> func, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(func, "func");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		if (locker.IsReaderLockHeld)
		{
			LockCookie cookie = locker.UpgradeToWriterLock(timeout);
			try
			{
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
			return func();
		}
		finally
		{
			locker.ReleaseWriterLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入写入模式锁定状态，执行指定的方法
	/// </summary>
	/// <param name="locker">当前锁对象</param>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">进入写入锁定超时时间</param>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static void WriteLock(ReaderWriterLockSlim locker, Action action, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(action, "action");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.TryEnterWriteLock(timeout);
		try
		{
			action();
		}
		finally
		{
			locker.ExitWriteLock();
		}
	}

	/// <summary>
	/// 使当前锁对象进入写入模式锁定状态，执行指定的函数
	/// </summary>
	/// <typeparam name="R">写入处理方法返回值</typeparam>
	/// <param name="locker">当前锁对象</param>
	/// <param name="func">写入处理方法</param>
	/// <param name="timeout">进入写入锁定超时时间</param>
	/// <returns>写入处理方法返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前锁对象为空；或者调用的函数 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">读取锁定时间 <paramref name="timeout" /> 小于0且不等于-1。</exception>
	public static R WriteLock<R>(ReaderWriterLockSlim locker, Func<R> func, int timeout = -1)
	{
		Guard.AssertNotNull(locker, "locker");
		Guard.AssertNotNull(func, "func");
		Guard.AssertGreaterThanOrEqualTo(timeout, -1, "timeout");
		locker.TryEnterWriteLock(timeout);
		try
		{
			return func();
		}
		finally
		{
			locker.ExitWriteLock();
		}
	}
}
