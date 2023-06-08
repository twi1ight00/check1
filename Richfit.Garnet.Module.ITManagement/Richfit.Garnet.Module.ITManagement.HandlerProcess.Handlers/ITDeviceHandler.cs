using System;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Application.Services;

namespace Richfit.Garnet.Module.ITManagement.HandlerProcess.Handlers;

public class ITDeviceHandler : HandlerBase
{
	private ITDeviceManagementService deviceService = ServiceLocator.Instance.GetService<ITDeviceManagementService>();

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
				case "ITManagement_QueryDeviceList":
					QueryDeviceList(handlerResult);
					break;
				case "ITManagement_QueryDeviceList_Advance":
					QueryDeviceList_Advance(handlerResult);
					break;
				case "ITManagement_CheckInDevice":
					CheckInDevice(handlerResult);
					break;
				case "ITManagement_CheckOutDevice":
					CheckOutDevice(handlerResult);
					break;
				case "ITManagement_UpdateDevice":
					UpdateDevice(handlerResult);
					break;
				case "ITManagement_RemoveDevice":
					RemoveDevice(handlerResult);
					break;
				case "ITManagement_RevertDevice":
					RevertDevice(handlerResult);
					break;
				case "ITManagement_QueryDeviceToScrap":
					QueryDeviceToScrap(handlerResult);
					break;
				case "ITManagement_QueryDeviceInventoryList":
					QueryDeviceInventoryList(handlerResult);
					break;
				case "ITManagement_NewDeviceScrap":
					NewDeviceScrap(handlerResult);
					break;
				case "ITManagement_QueryScrapList":
					QueryScrapList(handlerResult);
					break;
				case "ITManagement_GetAllScrapList":
					GetAllScrapList(handlerResult);
					break;
				case "ITManagement_ChangeScrapDetail":
					ChangeScrapDetail(handlerResult);
					break;
				case "ITManagement_CloseScrap":
					CloseScrap(handlerResult);
					break;
				case "ITManagement_BuyScrapedDevice":
					BuyScrapedDevice(handlerResult);
					break;
				case "ITManagement_ConfirmDevicePayment":
					ConfirmDevicePayment(handlerResult);
					break;
				case "ITManagement_ConfirmScrapPayment":
					ConfirmScrapPayment(handlerResult);
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

	private void ConfirmScrapPayment(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAPDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAPDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.ConfirmScrapPayment(scrap).JsonSerialize();
	}

	private void ConfirmDevicePayment(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAP_DETAILDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAP_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.ConfirmDevicePayment(scrap).JsonSerialize();
	}

	private void BuyScrapedDevice(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAP_DETAILDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAP_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.BuyScrapedDevice(scrap).JsonSerialize();
	}

	private void CloseScrap(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAPDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAPDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.CloseScrap(scrap).JsonSerialize();
	}

	private void ChangeScrapDetail(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAP_DETAILDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAP_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.ChangeScrapDetail(scrap).JsonSerialize();
	}

	private void GetAllScrapList(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAPDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAPDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.GetAllScrapList(scrap).JsonSerialize();
	}

	private void QueryScrapList(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAP_DETAILDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAP_DETAILDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.QueryScrapList(scrap).JsonSerialize();
	}

	private void NewDeviceScrap(ResponseData handlerResult)
	{
		IT_DEVICE_SCRAPDTO scrap = base.RequestData.Data.JsonDeserialize<IT_DEVICE_SCRAPDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.NewDeviceScrap(scrap).ToJson();
	}

	private void QueryDeviceInventoryList(ResponseData handlerResult)
	{
		IT_DEVICEDTO condition = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.QueryDeviceInventoryList(condition).JsonSerialize();
	}

	private void QueryDeviceToScrap(ResponseData handlerResult)
	{
		IT_DEVICEDTO condition = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.QueryDeviceToScrap(condition).JsonSerialize();
	}

	private void RevertDevice(ResponseData handlerResult)
	{
		IT_DEVICEDTO device = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.RevertDevice(device).ToJson();
	}

	private void RemoveDevice(ResponseData handlerResult)
	{
		IT_DEVICEDTO device = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.RemoveDevice(device).ToJson();
	}

	private void UpdateDevice(ResponseData handlerResult)
	{
		IT_DEVICEDTO device = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.UpdateDevice(device).ToJson();
	}

	private void CheckOutDevice(ResponseData handlerResult)
	{
		IT_DEVICEDTO device = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.CheckOutDevice(device).ToJson();
	}

	private void CheckInDevice(ResponseData handlerResult)
	{
		IT_DEVICEDTO device = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.CheckInDevice(device).ToJson();
	}

	private void QueryDeviceList(ResponseData handlerResult)
	{
		IT_DEVICEDTO condition = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.QueryDeviceList(condition).ToJson();
	}

	private void QueryDeviceList_Advance(ResponseData handlerResult)
	{
		IT_DEVICEDTO condition = base.RequestData.Data.JsonDeserialize<IT_DEVICEDTO>(new JsonConverter[0]);
		handlerResult.Data = deviceService.QueryDeviceList_Advance(condition).ToJson();
	}
}
