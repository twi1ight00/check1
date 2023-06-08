using System;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <inheritdoc />
public class SessionLog : ISessionLog
{
	/// <inheritdoc />
	public void SessionAddLog()
	{
		BusinessLogEntry logoutEntry = new BusinessLogEntry("Login");
		LogCacheManager.GetCache().AddCache(logoutEntry);
	}

	/// <inheritdoc />
	public void SessionRemoveLog()
	{
		BusinessLogEntry logoutEntry = new BusinessLogEntry("Logout");
		LogCacheManager.GetCache().AddCache(logoutEntry);
	}

	/// <inheritdoc />
	public void SessionRemoveLog(Guid sessionId)
	{
		BusinessLogEntry logoutEntry = new BusinessLogEntry("Logout", sessionId);
		LogCacheManager.GetCache().AddCache(logoutEntry);
	}
}
