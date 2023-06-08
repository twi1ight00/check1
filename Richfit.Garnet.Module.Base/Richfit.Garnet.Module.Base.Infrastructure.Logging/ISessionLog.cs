using System;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// Session添加删除时日志记录
/// </summary>
public interface ISessionLog
{
	/// <summary>
	/// Session添加时记录日志
	/// </summary>
	void SessionAddLog();

	/// <summary>
	/// 当前Session移除时记录日志
	/// </summary>
	void SessionRemoveLog();

	/// <summary>
	/// 移除某Id的Session时记录日志
	/// </summary>
	/// <param name="sessionId"></param>
	void SessionRemoveLog(Guid sessionId);
}
