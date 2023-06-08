using System;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 读写共享锁接口
/// </summary>
public interface ISyncLocker : IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置请求锁定超时时间，单位毫秒
	/// </summary>
	int Timeout { get; set; }

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	void Only(Action action);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	void Only(Action action, int timeout);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	void Only(Action action, TimeSpan timeout);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理返回值类型</typeparam>
	/// <param name="func">独占处理方法</param>
	/// <returns>独占处理返回值</returns>
	T Only<T>(Func<T> func);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理方法返回值类型</typeparam>
	/// <param name="func">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <returns>独占处理方法返回值</returns>
	T Only<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在独占模式锁定状态下执行指定的处理
	/// </summary>
	/// <typeparam name="T">独占处理方法返回值类型</typeparam>
	/// <param name="func">独占处理方法</param>
	/// <param name="timeout">独占等待超时时间</param>
	/// <returns>独占处理方法返回值</returns>
	T Only<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	void Read();

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	void Read(int timeout);

	/// <summary>
	/// 进入读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	void Read(TimeSpan timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	void Read(Action action);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	void Read(Action action, int timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	void Read(Action action, TimeSpan timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <returns>读取处理方法返回值</returns>
	T Read<T>(Func<T> func);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	T Read<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	T Read<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	void UpgradableRead();

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	void UpgradableRead(int timeout);

	/// <summary>
	/// 进入可升级读取模式锁定状态
	/// </summary>
	/// <param name="timeout">读取等待超时时间</param>
	void UpgradableRead(TimeSpan timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	void UpgradableRead(Action action);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	void UpgradableRead(Action action, int timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	void UpgradableRead(Action action, TimeSpan timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <returns>读取处理方法返回值</returns>
	T UpgradableRead<T>(Func<T> func);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	T UpgradableRead<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">读取处理方法返回值类型</typeparam>
	/// <param name="func">读取处理方法</param>
	/// <param name="timeout">读取等待超时时间</param>
	/// <returns>读取处理方法返回值</returns>
	T UpgradableRead<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	void Write();

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	/// <param name="timeout">写入等待超时时间</param>
	void Write(int timeout);

	/// <summary>
	/// 进入写入模式锁定状态
	/// </summary>
	/// <param name="timeout">写入等待超时时间</param>
	void Write(TimeSpan timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	void Write(Action action);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	void Write(Action action, int timeout);

	/// <summary>
	/// 在可升级读取模式锁定状态下执行指定的处理
	/// </summary>
	/// <param name="action">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	void Write(Action action, TimeSpan timeout);

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理方法返回值类型</typeparam>
	/// <param name="func">写入处理方法</param>
	/// <returns>写入处理方法返回值</returns>
	T Write<T>(Func<T> func);

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理方法返回值类型</typeparam>
	/// <param name="func">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <returns>写入处理方法返回值</returns>
	T Write<T>(Func<T> func, int timeout);

	/// <summary>
	/// 在写入模式锁定状态下执行指定的处理并返回处理结果
	/// </summary>
	/// <typeparam name="T">写入处理方法返回值类型</typeparam>
	/// <param name="func">写入处理方法</param>
	/// <param name="timeout">写入等待超时时间</param>
	/// <returns>写入处理方法返回值</returns>
	T Write<T>(Func<T> func, TimeSpan timeout);

	/// <summary>
	/// 释放模式锁定状态
	/// </summary>
	void Release();
}
