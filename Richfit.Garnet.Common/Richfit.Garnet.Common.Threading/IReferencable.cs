using System;

namespace Richfit.Garnet.Common.Threading;

/// <summary>
/// 可引用对象接口
/// </summary>
public interface IReferencable : IDisposable
{
	/// <summary>
	/// 获取引用管理器
	/// </summary>
	IReferenceManager ReferenceManager { get; }
}
