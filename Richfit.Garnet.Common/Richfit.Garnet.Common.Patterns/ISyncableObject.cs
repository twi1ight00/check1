using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 可同步对象接口
/// 可同步对象应具有接受ISyncLocker类型参数的构造函数以设置共享锁
/// </summary>
public interface ISyncableObject
{
	/// <summary>
	/// 获取共享锁
	/// </summary>
	ISyncLocker SyncRoot { get; }
}
