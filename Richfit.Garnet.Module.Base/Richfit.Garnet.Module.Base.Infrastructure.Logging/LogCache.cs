using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 日志缓存实现
/// </summary>
public class LogCache : ILogCache
{
	private ILogCacheHandler logCacheHandler;

	/// <inheritdoc />
	public ILogCacheHandler LogCacheHandler
	{
		get
		{
			return logCacheHandler;
		}
		set
		{
			logCacheHandler = value;
		}
	}

	/// <inheritdoc />
	public void AddCache(BusinessLogEntry logEntry)
	{
		LogCacheManager.SyncLocker.Write(delegate
		{
			LocalCacheBus.Instance.Set("LogRecordCacheKey", delegate(IList<BusinessLogEntry> list)
			{
				if (list != null && list.Any())
				{
					list.Add(logEntry);
				}
				else
				{
					list = new List<BusinessLogEntry>();
					list.Add(logEntry);
				}
				return list;
			});
		});
	}
}
