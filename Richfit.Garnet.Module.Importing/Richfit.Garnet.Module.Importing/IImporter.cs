using System;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Module.Importing;

/// <summary>
/// 导入器接口
/// </summary>
public interface IImporter : IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取导出器名称
	/// </summary>
	string Name { get; }

	/// <summary>
	/// 同步对象
	/// </summary>
	ISyncLocker SyncRoot { get; }
}
