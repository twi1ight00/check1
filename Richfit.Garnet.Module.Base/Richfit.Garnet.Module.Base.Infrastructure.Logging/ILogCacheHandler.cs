namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 日志缓存处理
/// </summary>
public interface ILogCacheHandler
{
	/// <summary>
	/// 写缓存中的日志
	/// </summary>
	void WriteLog();
}
