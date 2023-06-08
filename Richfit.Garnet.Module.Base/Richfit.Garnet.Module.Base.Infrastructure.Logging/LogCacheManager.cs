using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 日志缓存管理
/// </summary>
public class LogCacheManager
{
	/// <summary>
	/// 日志缓存主键
	/// </summary>
	public const string LogRecordCacheKey = "LogRecordCacheKey";

	/// <summary>
	/// 同步锁
	/// </summary>
	public static ReadWriteLocker SyncLocker = new ReadWriteLocker();

	/// <summary>
	/// 日志缓存服务
	/// </summary>
	private static ILogCache logCache = ServiceLocator.Instance.GetService<ILogCache>();

	/// <summary>
	/// 获取缓存
	/// </summary>
	/// <returns></returns>
	public static ILogCache GetCache()
	{
		return logCache;
	}

	/// <summary>
	/// 清空缓存
	/// </summary>
	public static void ClearCache()
	{
		logCache.LogCacheHandler.WriteLog();
	}
}
