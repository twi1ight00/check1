using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Application.Services;

namespace Richfit.Garnet.Module.ITManagement.HandlerProcess.Handlers;

public class ITAccountHandler : HandlerBase
{
	private ITManagementService itManagementService = ServiceLocator.Instance.GetService<ITManagementService>();

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
				case "ITManagement_QueryAccountList":
					QueryAccountList(handlerResult);
					break;
				case "ITManagement_AddAccount":
					AddAccount(handlerResult);
					break;
				case "ITManagement_UpdateAccount":
					UpdateAccount(handlerResult);
					break;
				case "ITManagement_DeleteAccount":
					DeleteAccount(handlerResult);
					break;
				case "ITManagement_ExportAccountList":
					ExportAccountList(handlerResult);
					break;
				case "ITManagement_QueryAccountSimple":
					QueryAccountSimple(handlerResult);
					break;
				case "ITManagement_QueryAccountAdvance":
					QueryAccountAdvance(handlerResult);
					break;
				case "ITManagement__GetMaterialType":
					GetMaterialType(handlerResult);
					break;
				case "ITManagement_IsNeedPurchase":
					IsNeedPurchase(handlerResult);
					break;
				case "ITManagement_AddMaterialCheckIn":
					AddMaterialCheckIn(handlerResult);
					break;
				case "ITManagement_GetCurrentMaterialList":
					GetCurrentMaterialList(handlerResult);
					break;
				case "ITManagement_GetMaterialCheckInList":
					GetMaterialCheckInList(handlerResult);
					break;
				case "ITManagement_QueryMaterialList":
					QueryMaterialList(handlerResult);
					break;
				case "ITManagement_SaveMaterial":
					SaveMaterial(handlerResult);
					break;
				case "ITManagement_UpdateMaterialList":
					UpdateMaterialList(handlerResult);
					break;
				case "ITManagement_GetMaterialList":
					GetMaterialList(handlerResult);
					break;
				case "ITManagement_GetNoCheckInList":
					GetNoCheckInList(handlerResult);
					break;
				case "ITManagement_AddStockIN":
					AddStockIN(handlerResult);
					break;
				case "ITManagement_GetStockINList":
					GetStockINList(handlerResult);
					break;
				case "ITManagement_GetStockOutList":
					GetStockOutList(handlerResult);
					break;
				case "ITManagement_GetStockInDetailList":
					GetStockInDetailList(handlerResult);
					break;
				case "ITManagement_GetStockINByID":
					GetStockINByID(handlerResult);
					break;
				case "ITManagement_QueryMaterialApplyList":
					QueryMaterialApplyList(handlerResult);
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

	private void QueryMaterialApplyList(ResponseData handlerResult)
	{
		IT_MATERIAL_APPLY_DETAILDTO condition = base.RequestData.Data.JsonDeserialize<IT_MATERIAL_APPLY_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetMaterialApplyList(condition).ToJson();
	}

	private void GetStockINByID(ResponseData handlerResult)
	{
		IT_STOCK_INDTO condition = base.RequestData.Data.JsonDeserialize<IT_STOCK_INDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetStockInByID(condition).ToJson();
	}

	private void GetStockInDetailList(ResponseData handlerResult)
	{
		IT_STOCK_IN_DETAILDTO condition = base.RequestData.Data.JsonDeserialize<IT_STOCK_IN_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetStockINDetailList(condition).ToJson();
	}

	private void GetStockINList(ResponseData handlerResult)
	{
		IT_STOCK_INDTO condition = base.RequestData.Data.JsonDeserialize<IT_STOCK_INDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetStockINList(condition).ToJson();
	}

	private void GetStockOutList(ResponseData handlerResult)
	{
		IT_STOCK_OUT_DETAILDTO condition = base.RequestData.Data.JsonDeserialize<IT_STOCK_OUT_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetStockOutList(condition).ToJson();
	}

	private void AddStockIN(ResponseData handlerResult)
	{
		IT_STOCK_INDTO stockInDTO = base.RequestData.Data.JsonDeserialize<IT_STOCK_INDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.AddStockIn(stockInDTO).ToJson();
	}

	private void GetNoCheckInList(ResponseData handlerResult)
	{
		IT_STOCK_IN_DETAILDTO condition = base.RequestData.Data.JsonDeserialize<IT_STOCK_IN_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetNoCheckInList(condition).ToJson();
	}

	private void GetMaterialList(ResponseData handlerResult)
	{
		IT_MATERIALDTO condition = base.RequestData.Data.JsonDeserialize<IT_MATERIALDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetMaterialList(condition).ToJson();
	}

	private void GetMaterialCheckInList(ResponseData handlerResult)
	{
		IT_MATERIAL_CHECKINDTO condition = base.RequestData.Data.JsonDeserialize<IT_MATERIAL_CHECKINDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetMaterialCheckInList(condition).ToJson();
	}

	private void GetCurrentMaterialList(ResponseData handlerResult)
	{
		IT_MATERIALDTO condition = base.RequestData.Data.JsonDeserialize<IT_MATERIALDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.GetCurrentMaterialList(condition).ToJson();
	}

	private void AddMaterialCheckIn(ResponseData handlerResult)
	{
		IT_MATERIALDTO materialDTO = DTOBase.DeserializeFromJson<IT_MATERIALDTO>(base.RequestData.Data);
		handlerResult.Data = itManagementService.AddMaterialCheckIn(materialDTO).ToJson();
	}

	private void IsNeedPurchase(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string[] materialIdArray = dictionary["IT_MATERIAL_ID"].Split('、');
		string sqlIDs = "(";
		if (materialIdArray != null && materialIdArray.Any())
		{
			materialIdArray.ToList().ForEach(delegate(string mId)
			{
				Guid guid = Guid.Parse(mId);
				object obj = sqlIDs;
				sqlIDs = string.Concat(obj, "f_guidtoraw('", guid, "'),");
			});
		}
		handlerResult.Data = (itManagementService.IsNeedPurchase(sqlIDs) ? "1" : "0");
	}

	private void GetMaterialType(ResponseData handlerResult)
	{
		IT_MATERIALDTO queryCondition = null;
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			queryCondition = base.RequestData.Data.JsonDeserialize<IT_MATERIALDTO>(new JsonConverter[0]);
		}
		if (!SessionContext.UserInfo.BelongToOrgID.ToString().ToLower().Equals("9877e4cf-5e8d-4e6a-ad9d-310bdb393638"))
		{
			queryCondition.IS_AVAILABLE = 1m;
		}
		handlerResult.Data = itManagementService.GetMaterialType(queryCondition).ToJson();
	}

	private void QueryAccountList(ResponseData handlerResult)
	{
		IT_ACCOUNTDTO condition = base.RequestData.Data.JsonDeserialize<IT_ACCOUNTDTO>(new JsonConverter[0]);
		handlerResult.Data = itManagementService.QueryAccountList(condition).ToJson();
	}

	private void QueryAccountAdvance(ResponseData handlerResult)
	{
	}

	private void QueryAccountSimple(ResponseData handlerResult)
	{
	}

	private void ExportAccountList(ResponseData handlerResult)
	{
	}

	private void DeleteAccount(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		itManagementService.DeleteAccountByAccountID(dictionary["IT_ACCOUNT_ID"]);
	}

	private void UpdateAccount(ResponseData handlerResult)
	{
		IT_ACCOUNTDTO deviceDTO = DTOBase.DeserializeFromJson<IT_ACCOUNTDTO>(base.RequestData.Data);
		handlerResult.Data = itManagementService.UpdateAccount(deviceDTO).ToJson();
	}

	private void AddAccount(ResponseData handlerResult)
	{
		IT_ACCOUNTDTO deviceDTO = DTOBase.DeserializeFromJson<IT_ACCOUNTDTO>(base.RequestData.Data);
		handlerResult.Data = itManagementService.AddAccount(deviceDTO).ToJson();
	}

	private void QueryMaterialList(ResponseData handlerResult)
	{
		IT_MATERIALDTO materialDTO = DTOBase.DeserializeFromJson<IT_MATERIALDTO>(base.RequestData.Data);
		handlerResult.Data = itManagementService.QueryMaterialList(materialDTO).ToJson();
	}

	private void SaveMaterial(ResponseData handlerResult)
	{
		IT_MATERIALDTO materialDTO = DTOBase.DeserializeFromJson<IT_MATERIALDTO>(base.RequestData.Data);
		handlerResult.Data = itManagementService.SaveMaterial(materialDTO).ToJson();
	}

	private void UpdateMaterialList(ResponseData handlerResult)
	{
		IT_MATERIALDTO materialDTO = DTOBase.DeserializeFromJson<IT_MATERIALDTO>(base.RequestData.Data);
		handlerResult.Data = itManagementService.UpdateMaterialList(materialDTO).ToJson();
	}
}
