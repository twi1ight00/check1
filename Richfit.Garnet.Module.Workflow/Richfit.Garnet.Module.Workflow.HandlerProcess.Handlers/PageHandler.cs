using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;

namespace Richfit.Garnet.Module.Workflow.HandlerProcess.Handlers;

public class PageHandler : HandlerBase
{
	private IPageService pageServcice = ServiceLocator.Instance.GetService<IPageService>();

	/// <summary>
	/// ProcessRequest
	/// </summary>
	/// <param name="context">context</param>
	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "Page_GetPageByTemplateVersion":
					GetPageByTemplateVersion(handlerResult);
					break;
				case "Page_SavePage":
					SavePage(handlerResult);
					break;
				case "Page_FindById":
					FindById(handlerResult);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			handlerResult = HandleException(ex);
		}
		context.Response.Write(handlerResult.ToJson());
	}

	private void FindById(ResponseData handlerResult)
	{
		Dictionary<string, Guid> template = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = pageServcice.FindById(template["PAGE_ID"]).JsonSerialize();
	}

	private void GetPageByTemplateVersion(ResponseData handlerResult)
	{
		Dictionary<string, Guid> template = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = pageServcice.GetPageByTemplateVersion(template["TEMPLATE_ID"]).JsonSerialize();
	}

	private void SavePage(ResponseData handlerResult)
	{
		WF_PAGEDTO page = base.RequestData.Data.JsonDeserialize<WF_PAGEDTO>(new JsonConverter[0]);
		handlerResult.Data = pageServcice.SavePage(page).AdaptAsDTO<WF_PAGEDTO>().JsonSerialize();
	}
}
