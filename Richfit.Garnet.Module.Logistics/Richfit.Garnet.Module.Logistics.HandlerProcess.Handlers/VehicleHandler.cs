using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Logistics.Application.DTO;
using Richfit.Garnet.Module.Logistics.Application.Services;

namespace Richfit.Garnet.Module.Logistics.HandlerProcess.Handlers;

public class VehicleHandler : HandlerBase
{
	private IVehicleService VehicleAppService = ServiceLocator.Instance.GetService<IVehicleService>();

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
				case "Logistics_AddVehicle":
					AddVehicle(handlerResult);
					break;
				case "Logistics_UpdateVehicle":
					UpdateVehicle(handlerResult);
					break;
				case "Logistics_GetAllVehicleList":
					GetAllVehicleList(handlerResult);
					break;
				case "Logistics_DelVehicle":
					DelVehicle(handlerResult);
					break;
				case "Logistics_ImportVehicle":
					ImportVehicle(handlerResult);
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

	private void ImportVehicle(ResponseData handlerResult)
	{
	}

	private void DelVehicle(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		VehicleAppService.DelVehicle(dictionary["VEHICLE_ID"]);
	}

	private void GetAllVehicleList(ResponseData handlerResult)
	{
		LM_VEHICLE_MANAGEDTO VehicleDTO = DTOBase.DeserializeFromJson<LM_VEHICLE_MANAGEDTO>(base.RequestData.Data);
		handlerResult.Data = VehicleAppService.GetAllVehicleList(VehicleDTO).ToJson();
	}

	private void AddVehicle(ResponseData handlerResult)
	{
		LM_VEHICLE_MANAGEDTO VehicleDTO = DTOBase.DeserializeFromJson<LM_VEHICLE_MANAGEDTO>(base.RequestData.Data);
		handlerResult.Data = VehicleAppService.AddVehicle(VehicleDTO).ToJson();
	}

	private void UpdateVehicle(ResponseData handlerResult)
	{
		LM_VEHICLE_MANAGEDTO VehicleDTO = DTOBase.DeserializeFromJson<LM_VEHICLE_MANAGEDTO>(base.RequestData.Data);
		handlerResult.Data = VehicleAppService.UpdateVehicle(VehicleDTO).ToJson();
	}
}
