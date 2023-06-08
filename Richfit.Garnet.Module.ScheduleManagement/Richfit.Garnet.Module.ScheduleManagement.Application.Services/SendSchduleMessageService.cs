using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.ScheduleManagement.Domain.Models;

namespace Richfit.Garnet.Module.ScheduleManagement.Application.Services;

public class SendSchduleMessageService : ServiceBase, IJob
{
	private readonly IRepository<SCH_INFO> schInfoRepository;

	private readonly IRepository<SYS_USER> userRepository;

	public SendSchduleMessageService()
	{
		schInfoRepository = ServiceLocator.Instance.GetService<IRepository<SCH_INFO>>();
		userRepository = ServiceLocator.Instance.GetService<IRepository<SYS_USER>>();
	}

	public void SendScheduleMessage(DateTime currentTime)
	{
		string remindModel = "0,0,1,";
		IList<SCH_INFO> result = schInfoRepository.FindAll((SCH_INFO a) => a.REMIND_TIME != null && a.REMIND_MODE != null && a.REMIND_MODE == remindModel && a.ISSEND == (decimal?)0m && a.REMIND_TIME <= currentTime && a.ISDEL == 0m);
		if (result.Count <= 0)
		{
			return;
		}
		IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
		result.ToList().ForEach(delegate(SCH_INFO info)
		{
			List<MSG_CENTER_USERDTO> centerUser = new List<MSG_CENTER_USERDTO>();
			List<Guid> list = new List<Guid>();
			info.SCH_BELONGER_USER.ToList().ForEach(delegate(SCH_BELONGER_USER user)
			{
				MSG_CENTER_USERDTO item2 = new MSG_CENTER_USERDTO
				{
					USER_ID = user.USER_ID,
					USER_NAME = userRepository.GetByKey(user.USER_ID).DISPLAY_NAME,
					ISREAD = 0m,
					SORT = 0m
				};
				centerUser.Add(item2);
			});
			info.SCH_PARTICIPANTS_USER.ToList().ForEach(delegate(SCH_PARTICIPANTS_USER user)
			{
				MSG_CENTER_USERDTO item = new MSG_CENTER_USERDTO
				{
					USER_ID = user.USER_ID,
					USER_NAME = userRepository.GetByKey(user.USER_ID).DISPLAY_NAME,
					ISREAD = 0m,
					SORT = 0m
				};
				centerUser.Add(item);
			});
			if (centerUser.Count > 0)
			{
				SYS_USER byKey = userRepository.GetByKey(info.CREATOR);
				MSG_CENTERDTO dto = new MSG_CENTERDTO
				{
					SEND_USER_ID = byKey.USER_ID,
					MSG_TITLE = info.SCHEDULE_TITLE,
					SEND_TIME = DateTime.Now,
					SEND_USER_NAME = byKey.DISPLAY_NAME,
					SEND_ORG_ID = null,
					SEND_ORG_NAME = null,
					MSG_TYPE = 2m,
					MSG_OPEN_TYPE = 0m,
					MSG_BUSINESS_ID = null,
					MSG_SOURCE = "/Packages/ScheduleManagement/Views/ScheduleList.html",
					MSG_CENTER_USER = centerUser.ToList()
				};
				MessageCenterService.AddMessage(dto);
			}
			SCH_INFO byKey2 = schInfoRepository.GetByKey(info.SCHEDULE_ID);
			if (byKey2 != null)
			{
				byKey2.ISSEND = 1m;
				schInfoRepository.Update(byKey2);
			}
		});
		schInfoRepository.DbContext.Commit();
	}

	public void Execute(IJobExecutionContext context)
	{
		DateTime dt = DateTime.Now;
		SendScheduleMessage(dt);
	}
}
