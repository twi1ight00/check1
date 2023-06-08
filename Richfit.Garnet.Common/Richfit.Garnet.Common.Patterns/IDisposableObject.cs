using System;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 可清理对象接口
/// </summary>
public interface IDisposableObject : IDisposable
{
	/// <summary>
	/// 指示对象是否已经被清理
	/// </summary>
	bool IsDisposed { get; }
}
