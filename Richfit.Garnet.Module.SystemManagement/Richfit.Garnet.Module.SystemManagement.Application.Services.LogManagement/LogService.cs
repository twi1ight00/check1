using System;
using System.Linq;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.LogManagement;

public class LogService : ServiceBase, ILogService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<SYS_LOG> logRepository;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryLog">日志仓储对象</param>
	public LogService(IRepository<SYS_LOG> repositoryLog)
	{
		logRepository = repositoryLog;
	}

	public QueryResult<SYS_LOGDTO> QueryLogList(QueryCondition queryCondition)
	{
		QueryItem doTimeQueryItem = queryCondition.QueryItems.Where((QueryItem x) => x.Key.Equals("DO_TIME") && x.Method.Contains("<=")).FirstOrDefault();
		if (doTimeQueryItem != null && !string.IsNullOrEmpty(doTimeQueryItem.Value))
		{
			doTimeQueryItem.Value = DateTime.Parse(doTimeQueryItem.Value).AddDays(1.0).ToShortDateString();
		}
		return SqlQueryResult<SYS_LOGDTO>("QueryLogInfo", queryCondition);
	}
}
