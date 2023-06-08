using System;
using System.Collections.Generic;
using Quartz;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.RoleManagement;
using Richfit.Garnet.Module.Workflow.Application.Components;

namespace Richfit.Garnet.Module.HRManagement.Infrastructure.Jobs;

internal class TimesheetReminder : IJob
{
	private static readonly ILogger log = LoggerManager.GetLogger();

	public void Execute(IJobExecutionContext context)
	{
		try
		{
			IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
			IList<SYS_USERDTO> userList = roleAppService.GetUserListByRoleId(new Guid("D247CF2F-216A-CA5C-BDDE-08D6D9AA5B2E"));
			if (!ConfigurationManager.System.Settings.GetSetting("EnableSendMail", defaultValue: false))
			{
				return;
			}
			EmailService emailService = new EmailService();
			foreach (SYS_USERDTO user in userList)
			{
				if (!string.IsNullOrEmpty(user.MAIL))
				{
					string strMailServer = ConfigurationManager.System.Settings.GetSetting("SendMail_ServerAddress").ToString();
					string strUserAccount = ConfigurationManager.System.Settings.GetSetting("SendMail_UserAccount").ToString();
					string strUserPassword = ConfigurationManager.System.Settings.GetSetting("SendMail_UserPassword").ToString();
					string strTitle = "考勤填报提醒";
					string strBody = "您好！#br#br请您及时登录审计中心协同办公系统填报当月考勤。#br#br#br此致#br系统管理员";
					emailService.SendToEmail(user.USER_ID, null, strMailServer, user.MAIL, strUserAccount, strUserPassword, strTitle, strBody);
				}
			}
		}
		catch (Exception e)
		{
			log.Error("发送考勤提醒邮件失败！失败原因：" + e.Message);
		}
	}
}
