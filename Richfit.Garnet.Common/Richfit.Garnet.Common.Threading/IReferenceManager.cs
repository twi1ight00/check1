using System;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 引用管理器接口
/// </summary>
public interface IReferenceManager : IDisposable
{
	/// <summary>
	/// 获取当前对象的引用计数
	/// </summary>
	int ReferenceCount { get; }

	/// <summary>
	/// 指示当前的对象是否可以执行清理
	/// </summary>
	bool IsDisposable { get; }

	/// <summary>
	/// 清除引用，清理当前对象
	/// 如果当前对象不再被任何对象引用，则执行清理
	/// </summary>
	/// <param name="obj">应用当前对象的对象</param>
	/// <returns>如果对象清理成功返回true，否则返回false</returns>
	bool Dispose(object obj);

	/// <summary>
	/// 注册对象引用
	/// </summary>
	/// <param name="obj">注册当前对象的引用对象</param>
	/// <returns>返回当前对象被引用的数量 </returns>
	int Register(object obj);

	/// <summary>
	/// 取消注册对象引用
	/// </summary>
	/// <param name="obj">取消注册当前对象的引用对象</param>
	/// <returns>返回当前对象被引用的数量</returns>
	int Unregister(object obj);
}
