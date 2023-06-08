using System;
using System.Collections.Generic;
using System.Threading;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 同步锁基类
/// </summary>
public abstract class SyncLocker : DisposableObject, ISyncLocker, IDisposableObject, IDisposable
{
	/// <summary>
	/// 请求锁定超时时间，单位毫秒
	/// </summary>
	private int timeout;

	/// <summary>
	/// 锁定状态
	/// </summary>
	private ThreadLocal<Stack<LockStatus>> status;

	/// <summary>
	/// 获取或者设置请求锁定超时时间，单位毫秒
	/// </summary>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的超时时间小于0，且不等于-1。</exception>
	public int Timeout
	{
		get
		{
			CheckDisposed();
			return timeout;
		}
		set
		{
			CheckDisposed();
			value.GuardGreaterThanOrEqualTo(-1, "timeout");
			Interlocked.Exchange(ref timeout, value);
		}
	}

	/// <summary>
	/// 获取内部锁对象
	/// </summary>
	protected abstract object Locker { get; }

	/// <summary>
	/// 获取当前线程的锁定状态
	/// </summary>
	protected Stack<LockStatus> Status
	{
		get
		{
			if (!status.IsValueCreated)
			{
				status.Value = new Stack<LockStatus>();
			}
			return status.Value;
		}
	}

	/// <summary>
	/// 创建同步锁对象
	/// </summary>
	/// <returns>默认的同步锁对象</returns>
	public static ISyncLocker Create()
	{
		return new ReadWriteSlimLocker();
	}

	/// <summary>
	/// 创建同步锁对象
	/// </summary>
	/// <param name="timeout">锁定超时时间</param>
	/// <returns>默认的同步锁对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">锁定超时 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public static ISyncLocker Create(int timeout)
	{
		timeout.GuardGreaterThanOrEqualTo(-1, "timeout");
		return new ReadWriteSlimLocker(timeout);
	}

	/// <summary>
	/// 创建同步锁对象
	/// </summary>
	/// <param name="timeout">锁定超时时间</param>
	/// <returns>默认的同步锁对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">锁定超时 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public static ISyncLocker Create(TimeSpan timeout)
	{
		timeout.TotalMilliseconds.As<int>().GuardGreaterThanOrEqualTo(-1, "timeout");
		return new ReadWriteSlimLocker(timeout);
	}

	/// <summary>
	/// 初始化
	/// </summary>
	public SyncLocker()
		: this(-1)
	{
	}

	/// <summary>
	/// 使用指定的超时时间初始化，单位毫秒
	/// </summary>
	/// <param name="timeout">阻塞超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的超时时间 <paramref name="timeout" /> 小于0，且不等于-1。</exception>
	public SyncLocker(int timeout)
	{
		timeout.GuardGreaterThanOrEqualTo(-1, "timeout");
		this.timeout = timeout;
		status = new ThreadLocal<Stack<LockStatus>>();
	}

	/// <summary>
	/// 使用指定的超时时间初始化
	/// </summary>
	/// <param name="timeout">阻塞超时时间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">设置的超时时间 <paramref name="timeout" /> 小于0，且不等于-1毫秒。</exception>
	public SyncLocker(TimeSpan timeout)
		: this((int)timeout.TotalMilliseconds)
	{
	}

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理</param>
	public abstract void Only(Action action);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	public abstract void Only(Action action, int timeout);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	public abstract void Only(Action action, TimeSpan timeout);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理返回值类型</typeparam>
	/// <param name="func">独占处理</param>
	/// <returns>独占处理返回值</returns>
	public abstract T Only<T>(Func<T> func);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理方法返回值类型</typeparam>
	/// <param name="func">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <returns>独占处理方法返回值</returns>
	public abstract T Only<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理方法返回值类型</typeparam>
	/// <param name="func">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <returns>独占处理方法返回值</returns>
	public abstract T Only<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	public abstract void Read();

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void Read(int timeout);

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void Read(TimeSpan timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理</param>
	public abstract void Read(Action action);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void Read(Action action, int timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void Read(Action action, TimeSpan timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理返回值类型</typeparam>
	/// <param name="func">读取处理</param>
	/// <returns>读取处理返回值</returns>
	public abstract T Read<T>(Func<T> func);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	public abstract T Read<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	public abstract T Read<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	public abstract void UpgradableRead();

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void UpgradableRead(int timeout);

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void UpgradableRead(TimeSpan timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理</param>
	public abstract void UpgradableRead(Action action);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void UpgradableRead(Action action, int timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	public abstract void UpgradableRead(Action action, TimeSpan timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理返回值类型</typeparam>
	/// <param name="func">读取处理</param>
	/// <returns>读取处理返回值</returns>
	public abstract T UpgradableRead<T>(Func<T> func);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	public abstract T UpgradableRead<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	public abstract T UpgradableRead<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	public abstract void Write();

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	/// <param name="timeout">写入等待超时时间</param>
	public abstract void Write(int timeout);

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	/// <param name="timeout">写入等待超时时间</param>
	public abstract void Write(TimeSpan timeout);

	/// <summary>
	/// 写入锁定
	/// </summary>
	/// <param name="action"></param>
	public abstract void Write(Action action);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	public abstract void Write(Action action, int timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	public abstract void Write(Action action, TimeSpan timeout);

	/// <summary>
	/// 写入锁定并返回函数值
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="func"></param>
	/// <returns></returns>
	public abstract T Write<T>(Func<T> func);

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理方法返回值类型</typeparam>
	/// <param name="func">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <returns>写入处理方法返回值</returns>
	public abstract T Write<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理方法返回值类型</typeparam>
	/// <param name="func">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <returns>写入处理方法返回值</returns>
	public abstract T Write<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 释放模式锁定状态
	/// </summary>
	public abstract void Release();

	/// <summary>
	/// 执行对象清理
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (status.IsNotNull())
		{
			status.Dispose();
			status = null;
		}
	}
}
