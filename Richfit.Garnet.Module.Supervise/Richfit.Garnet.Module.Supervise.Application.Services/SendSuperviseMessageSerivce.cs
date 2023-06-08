using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.Supervise.Domain.Models;

namespace Richfit.Garnet.Module.Supervise.Application.Services;

public class SendSuperviseMessageSerivce : ServiceBase
{
	private readonly IRepository<SUP_ASSIGN_TASK> supAssignTaskRepository;

	private readonly IRepository<SYS_USER> userRepository;

	public SendSuperviseMessageSerivce()
	{
		supAssignTaskRepository = ServiceLocator.Instance.GetService<IRepository<SUP_ASSIGN_TASK>>();
		userRepository = ServiceLocator.Instance.GetService<IRepository<SYS_USER>>();
	}

	public void SendTaskMessage(SUP_ASSIGN_TASK assignTask)
	{
		decimal? tASK_STATUS = assignTask.TASK_STATUS;
		if (!(tASK_STATUS.GetValueOrDefault() == 0m) || !tASK_STATUS.HasValue)
		{
			tASK_STATUS = assignTask.TASK_STATUS;
			if (!(tASK_STATUS.GetValueOrDefault() == 4m) || !tASK_STATUS.HasValue)
			{
				tASK_STATUS = assignTask.TASK_STATUS;
				if (!(tASK_STATUS.GetValueOrDefault() == 2m) || !tASK_STATUS.HasValue)
				{
					return;
				}
			}
		}
		SUP_ASSIGN_TASK parentTask = supAssignTaskRepository.Find((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.ASSIGN_TASK_ID == assignTask.PARENT_ASSIGN_TASK_ID);
		string url = "/Packages/Supervise/Views/superviseTask_v2.html?ObjectId={0}&IsDetail=true&TaskStatus={1}&IsApply={2}";
		int iApply = 0;
		tASK_STATUS = assignTask.TASK_STATUS;
		if (!(tASK_STATUS.GetValueOrDefault() == 2m) || !tASK_STATUS.HasValue)
		{
			tASK_STATUS = assignTask.TASK_STATUS;
			if (!(tASK_STATUS.GetValueOrDefault() == 4m) || !tASK_STATUS.HasValue)
			{
				goto IL_01f6;
			}
		}
		iApply = 1;
		goto IL_01f6;
		IL_01f6:
		string msgUrl = string.Format(url, assignTask.ASSIGN_TASK_ID, assignTask.TASK_STATUS, iApply);
		IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
		List<MSG_CENTER_USERDTO> centerUser = new List<MSG_CENTER_USERDTO>();
		MSG_CENTER_USERDTO centerUserDto = new MSG_CENTER_USERDTO();
		centerUserDto.USER_ID = parentTask.SUP_TASK_USER.First().USER_ID;
		centerUserDto.USER_NAME = parentTask.SUP_TASK_USER.First().USER_NAME;
		centerUserDto.ISREAD = 0m;
		centerUserDto.SORT = 0m;
		centerUser.Add(centerUserDto);
		MSG_CENTERDTO centerDto = new MSG_CENTERDTO();
		centerDto.SEND_USER_ID = assignTask.SUP_TASK_USER.First().USER_ID;
		centerDto.MSG_TITLE = assignTask.WORK_TITLE;
		centerDto.SEND_TIME = DateTime.Now;
		centerDto.SEND_USER_NAME = assignTask.SUP_TASK_USER.First().USER_NAME;
		centerDto.SEND_ORG_ID = null;
		centerDto.SEND_ORG_NAME = null;
		centerDto.MSG_TYPE = 4m;
		centerDto.MSG_BUSINESS_ID = null;
		centerDto.MSG_SOURCE = msgUrl;
		centerDto.MSG_CENTER_USER = centerUser.ToList();
		MessageCenterService.AddMessage(centerDto);
	}
}
