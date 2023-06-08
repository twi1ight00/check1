using System;
using System.Threading;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 可清理对象基类
/// </summary>
public abstract class DisposableObject : IDisposableObject, IDisposable
{
	/// <summary>
	/// 是否已经清理
	/// </summary>
	private int isDisposed;

	/// <summary>
	/// 获取是否已经清理
	/// </summary>
	public virtual bool IsDisposed => isDisposed == 1;

	/// <summary>
	/// 初始化对象实例
	/// </summary>
	protected DisposableObject()
	{
		isDisposed = 0;
	}

	/// <summary>
	/// 析构清理对象实例
	/// </summary>
	~DisposableObject()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象，清理方法应可重入，且不抛出异常
	/// </summary>
	public void Dispose()
	{
		try
		{
			if (isDisposed == 0 && Interlocked.Exchange(ref isDisposed, 1) == 0)
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}
		catch
		{
		}
	}

	/// <summary>
	/// 执行对象清理，清理方法应可重入，且不抛出异常
	/// </summary>
	/// <param name="disposing">从Dispose方法调用设置为true，从析构函数调用设置为false</param>
	protected abstract void Dispose(bool disposing);

	/// <summary>
	/// 检测当前对象的清理状态，如果已经被清理，则抛出ObjectDisposedException
	/// </summary>
	protected virtual void CheckDisposed()
	{
		if (isDisposed == 1)
		{
			throw new ObjectDisposedException(GetType().Name, Literals.MSG_ObjectDisposed);
		}
	}
}
