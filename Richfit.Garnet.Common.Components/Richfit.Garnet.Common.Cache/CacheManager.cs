using System;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Cache;

/// <summary>
/// 缓存管理器
/// </summary>
public class CacheManager
{
	/// <summary>
	/// 执行系统二级缓存的操作
	/// </summary>
	/// <param name="readWriteLocker">读写锁</param>
	/// <param name="lockType">锁定类型</param>
	/// <param name="action">锁定时执行的操作</param>
	public static void DoSystemCacheAction(ReadWriteLocker readWriteLocker, LockerType lockType, Action action)
	{
		if (!SystemCacheBus.Instance.IsDistributed)
		{
			switch (lockType)
			{
			case LockerType.Read:
				readWriteLocker.Read(action);
				break;
			case LockerType.Write:
				readWriteLocker.Write(action);
				break;
			}
		}
		else
		{
			action();
		}
	}
}
