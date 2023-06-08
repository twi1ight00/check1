namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 日志缓存
/// </summary>
public interface ILogCache
{
	/// <summary>
	/// 日志缓存处理器
	/// </summary>
	ILogCacheHandler LogCacheHandler { get; set; }

	/// <summary>
	/// 添加缓存项
	/// </summary>
	/// <param name="logEntry"></param>
	void AddCache(BusinessLogEntry logEntry);
}
