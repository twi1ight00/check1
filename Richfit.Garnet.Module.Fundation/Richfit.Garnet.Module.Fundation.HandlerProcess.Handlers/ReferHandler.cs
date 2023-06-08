using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.Services.Refer;

namespace Richfit.Garnet.Module.Fundation.HandlerProcess.Handlers;

/// <summary>
/// 引用服务处理
/// </summary>
public class ReferHandler : HandlerBase
{
	private IReferService referAppService = ServiceLocator.Instance.GetService<IReferService>();

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
				case "System_Refer_GetReferData":
					GetSelectReferData(handlerResult);
					break;
				case "System_SelfRefer_GetSelfReferColumn":
					GetSelfReferColumn(handlerResult);
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

	private void GetSelectReferData(ResponseData responseData)
	{
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo != null)
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			string TableName = dictionary["TableName"].ToString();
			string DisplayColumn = dictionary["DisplayColumn"].ToString();
			string ValueColumn = dictionary["ValueColumn"].ToString();
			string Condition = dictionary["Condition"].ToString();
			string OrderBy = "";
			if (dictionary.ContainsKey("Orderby"))
			{
				OrderBy = dictionary["Orderby"].ToString();
			}
			List<QueryItem> Items = Condition.JsonDeserialize<List<QueryItem>>(new JsonConverter[0]);
			QueryCondition Conditions = new QueryCondition();
			Conditions.QueryItems = Items;
			responseData.Data = referAppService.QuerySelectRefer(TableName, DisplayColumn, ValueColumn, Conditions, OrderBy).ToJson();
		}
	}

	private void GetSelfReferColumn(ResponseData responseData)
	{
		UserSessionInfo userSessionInfo = SessionContext.UserInfo;
		if (userSessionInfo != null)
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			string TableName = dictionary["TableName"].ToString();
			string ColumnName = dictionary["ColumnName"].ToString();
			string Condition = dictionary["Condition"].ToString();
			string LikeSQL = GetParameter("query").Trim();
			List<QueryItem> Items = Condition.JsonDeserialize<List<QueryItem>>(new JsonConverter[0]);
			QueryCondition Conditions = new QueryCondition();
			Conditions.QueryItems = Items;
			responseData.Data = referAppService.QuerySelfReferList(TableName, ColumnName, Conditions, LikeSQL).ToJson();
		}
	}
}
