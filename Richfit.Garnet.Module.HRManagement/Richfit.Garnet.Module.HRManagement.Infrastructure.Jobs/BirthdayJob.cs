using System;
using System.Collections.Generic;
using Quartz;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;
using Richfit.Garnet.Module.CMS.Application.DTO;
using Richfit.Garnet.Module.HRManagement.Application.DTO;
using Richfit.Garnet.Module.HRManagement.Application.Services;

namespace Richfit.Garnet.Module.HRManagement.Infrastructure.Jobs;

/// <summary>
/// Template定时任务
/// </summary>
public class BirthdayJob : IJob
{
	private IEmployeeAppService employeeAppService = ServiceLocator.Instance.GetService<IEmployeeAppService>();

	/// <summary>
	/// 执行定时任务
	/// </summary>
	/// <param name="context"></param>
	public void Execute(IJobExecutionContext context)
	{
		string con = "";
		IList<HR_EMPLOYEEDTO> em = employeeAppService.GetBirthdayEmpList();
		if (em.Count == 0)
		{
			return;
		}
		string users = "";
		foreach (HR_EMPLOYEEDTO item in em)
		{
			users = users + item.EMPLOYEE_NAME + "、";
		}
		users = users.Substring(0, users.Length - 1);
		CMS_ARTICLEDTO dto = new CMS_ARTICLEDTO();
		dto.PARENT_ID = new Guid(ConfigurationManager.System.Settings.GetSetting<string>("parentId"));
		dto.CATEGORY_ID = new Guid(ConfigurationManager.System.Settings.GetSetting<string>("categoryId"));
		dto.TITLE = "祝" + users + "生日快乐！";
		con = string.Format("<p style='text-align: center;'><img style='width:100%;height:auto;' title='{0}' alt='{1}' src='{2}'/></p>", dto.TITLE, dto.TITLE, "/cms/birthday/" + DateTime.Now.ToString("yyyyMMdd") + ".gif");
		dto.KEYWORDS = "";
		dto.IS_SHORT_MESSAGE = 1m;
		dto.AUDIT_STATUS = 1m;
		dto.AUDIT_DATE = DateTime.Now;
		dto.IS_COMMENT = 2m;
		dto.IS_BIRTHDAY = 1m;
		dto.BIRTHDAY_USER = users;
		string user = ConfigurationManager.System.Settings.GetSetting<string>("userId");
		string org = ConfigurationManager.System.Settings.GetSetting<string>("orgId");
		dto.USER_ID = new Guid(user);
		dto.ORG_ID = new Guid(org);
		dto.USER_NAME = ConfigurationManager.System.Settings.GetSetting<string>("userName");
		dto.CREATOR = dto.USER_ID.Value;
		dto.MODIFIER = dto.USER_ID.Value;
		dto.CMS_ARTICLE_DATA = new CMS_ARTICLE_DATADTO();
		dto.CMS_ARTICLE_DATA.CONTENT = string.Format(con, users, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));
		IList<HR_EMPLOYEEDTO> allemployee = employeeAppService.GetALLEmployee();
		dto.CMS_VIEW_AUDIT = new List<CMS_VIEW_AUDITDTO>();
		foreach (HR_EMPLOYEEDTO item in allemployee)
		{
			if (item.USER_ID.HasValue)
			{
				dto.CMS_VIEW_AUDIT.Add(new CMS_VIEW_AUDITDTO
				{
					ID = Guid.NewGuid(),
					ARTICLE_ID = dto.CATEGORY_ID,
					VIEW_ID = item.USER_ID.Value,
					VIEW_TYPE = 0m,
					VIEW_NAME = item.EMPLOYEE_NAME
				});
			}
		}
		AccessManager.ServiceAccess("Workflow", "PublishArticle", dto.JsonSerialize());
	}
}
