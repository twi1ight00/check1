using System;
using System.Collections.Generic;
using Quartz;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Supervise.Domain.Models;

namespace Richfit.Garnet.Module.Supervise.Application.Services;

public class CheckTaskExceedService : ServiceBase, IJob
{
	private readonly IRepository<SUP_PORJECT> supPorjectRepository;

	private readonly IRepository<SUP_ASSIGN_TASK> supAssignTaskRepository;

	public CheckTaskExceedService()
	{
		supPorjectRepository = ServiceLocator.Instance.GetService<IRepository<SUP_PORJECT>>();
		supAssignTaskRepository = ServiceLocator.Instance.GetService<IRepository<SUP_ASSIGN_TASK>>();
	}

	public void Execute(IJobExecutionContext context)
	{
		CheckTaskExceed();
	}

	public void CheckTaskExceed()
	{
		IList<SUP_PORJECT> projectList = supPorjectRepository.FindAll((SUP_PORJECT t) => t.ISDEL == 0m && t.FINISH_TIME == null && t.END_TIME <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")) && t.SUPERVISE_STATUS == (decimal?)0m);
		foreach (SUP_PORJECT project in projectList)
		{
			project.IS_EXCEED = 1m;
			supPorjectRepository.UpdateCommit(project);
		}
		IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.FINISH_TIME == null && t.END_TIME <= DateTime.Now);
		foreach (SUP_ASSIGN_TASK task in taskList)
		{
			task.IS_EXCEED = 1m;
			supAssignTaskRepository.UpdateCommit(task);
		}
	}
}
