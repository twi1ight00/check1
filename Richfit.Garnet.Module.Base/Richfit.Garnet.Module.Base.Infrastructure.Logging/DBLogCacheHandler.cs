using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Base.Infrastructure.Logging;

/// <summary>
/// 日志缓存数据库处理
/// </summary>
public class DBLogCacheHandler : ILogCacheHandler
{
	private SqlRepository sqlRepository = ServiceLocator.Instance.GetService<SqlRepository>();

	private Timer timer;

	/// <summary>
	/// 初始化
	/// </summary>
	public DBLogCacheHandler()
	{
		int timerPeriod = 300000;
		timer = new Timer(_ThreadTimerCallback, this, 0, timerPeriod);
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="timerPeriod">缓存刷新事件间隔</param>
	public DBLogCacheHandler(int timerPeriod)
	{
		if (timerPeriod == 0)
		{
			timerPeriod = 300000;
		}
		timer = new Timer(_ThreadTimerCallback, this, 0, timerPeriod);
	}

	private void _ThreadTimerCallback(object state)
	{
		WriteLog();
	}

	private void WriteLog(BusinessLogEntry[] logEntryArray)
	{
		if (logEntryArray == null)
		{
			return;
		}
		StringBuilder sbSql = new StringBuilder();
		BusinessLogEntry[] array = logEntryArray;
		foreach (BusinessLogEntry entry in array)
		{
			sbSql.Append(entry.ToInsertSql(sqlRepository) + ";");
		}
		if (sbSql.Length <= 1)
		{
			return;
		}
		try
		{
			if (sqlRepository.Database.IsSqlServer())
			{
				sqlRepository.ExecuteCommand(sbSql.ToString());
			}
			else
			{
				sqlRepository.ExecuteCommand("begin " + sbSql.ToString() + " end;");
			}
		}
		catch
		{
			LogCacheManager.SyncLocker.Write(delegate
			{
				LocalCacheBus.Instance.Set("LogRecordCacheKey", delegate(IList<BusinessLogEntry> list)
				{
					if (list != null && list.Any())
					{
						list.AddRange(logEntryArray.ToList());
					}
					else
					{
						list = new List<BusinessLogEntry>();
						list.AddRange(logEntryArray.ToList());
					}
					return list;
				});
			});
		}
	}

	/// <inheritdoc />
	public void WriteLog()
	{
		BusinessLogEntry[] logEntryArray = null;
		LogCacheManager.SyncLocker.Read(delegate
		{
			if (LocalCacheBus.Instance.Get("LogRecordCacheKey") is IList<BusinessLogEntry> source && source.Any())
			{
				logEntryArray = source.ToArray();
				LogCacheManager.SyncLocker.Write(delegate
				{
					LocalCacheBus.Instance.Set("LogRecordCacheKey", delegate(IList<BusinessLogEntry> list)
					{
						if (list != null && list.Any())
						{
							list.Clear();
						}
						return list;
					});
				});
			}
		});
		WriteLog(logEntryArray);
	}
}
