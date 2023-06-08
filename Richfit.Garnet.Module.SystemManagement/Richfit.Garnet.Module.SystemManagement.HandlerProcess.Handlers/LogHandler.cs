using System;
using System.Web;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.SystemManagement.Application.Services.LogManagement;

namespace Richfit.Garnet.Module.SystemManagement.HandlerProcess.Handlers;

public class LogHandler : HandlerBase
{
	/// <summary>
	/// Service locator
	/// </summary>
	private ILogService logService = ServiceLocator.Instance.GetService<ILogService>();

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
				string text = action;
				if (text != null && text == "SystemManagement_QueryLogInfoList")
				{
					QueryLogInfo(handlerResult);
				}
			}
		}
		catch (Exception ex)
		{
			handlerResult = HandleException(ex);
		}
		context.Response.Write(handlerResult.ToJson());
	}

	/// <summary>
	/// 获取日志信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void QueryLogInfo(ResponseData handlerResult)
	{
		QueryCondition condition = GetQueryCondition(base.RequestData.Data);
		handlerResult.Data = logService.QueryLogList(condition).ToJson();
	}
}
