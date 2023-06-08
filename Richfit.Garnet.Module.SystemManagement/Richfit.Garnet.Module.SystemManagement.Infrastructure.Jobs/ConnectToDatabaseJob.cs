using System;
using Quartz;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Infrastructure.Jobs;

internal class ConnectToDatabaseJob : IJob
{
	private static readonly ILogger log = LoggerManager.GetLogger();

	public void Execute(IJobExecutionContext context)
	{
		try
		{
			SqlRepository repository = new SqlRepository(null);
			string sql = "SELECT COUNT(*) FROM SYS_USER T WHERE T.ISDEL = 0";
			repository.ExecuteCommand(sql);
			log.Info("尝试连接数据库成功！");
		}
		catch (Exception)
		{
			log.Info("尝试连接数据库失败！");
		}
	}
}
