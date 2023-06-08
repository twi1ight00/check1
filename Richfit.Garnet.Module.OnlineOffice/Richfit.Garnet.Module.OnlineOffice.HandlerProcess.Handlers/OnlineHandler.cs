using System;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.OnlineOffice.Application.DTO;
using Richfit.Garnet.Module.OnlineOffice.Application.Services;

namespace Richfit.Garnet.Module.OnlineOffice.HandlerProcess.Handlers;

public class OnlineHandler : HandlerBase
{
	private IOnlineOfficeService officeService = ServiceLocator.Instance.GetService<IOnlineOfficeService>();

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
				case "OL_GetOnlineOfficeByObjId":
					GetOnlineOfficeByObjId(handlerResult);
					break;
				case "OL_SaveOnlineOffice":
					SaveOnlineOffice(handlerResult);
					break;
				case "OL_GetTempOnlineOfficeByUserId":
					GetTempOnlineOfficeByUserId(handlerResult);
					break;
				case "OL_DelTempOnlineOfficeById":
					DelTempOnlineOfficeById(handlerResult);
					break;
				case "OL_UpdateOnlineOfficeById":
					UpdateOnlineOfficeById(handlerResult);
					break;
				case "OL_GetTemplateFileByObjId":
					GetTemplateFileByObjId(handlerResult);
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

	private void GetTemplateFileByObjId(ResponseData handlerResult)
	{
		OL_TEMPLATE_FILE_MAPPINGDTO dto = base.RequestData.Data.JsonDeserialize<OL_TEMPLATE_FILE_MAPPINGDTO>(new JsonConverter[0]);
		handlerResult.Data = officeService.GetTemplateFileByObjId(dto).JsonSerialize();
	}

	private void UpdateOnlineOfficeById(ResponseData handlerResult)
	{
		OL_OFFICEDTO dto = base.RequestData.Data.JsonDeserialize<OL_OFFICEDTO>(new JsonConverter[0]);
		officeService.UpdateOnlineOfficeById(dto);
	}

	private void DelTempOnlineOfficeById(ResponseData handlerResult)
	{
		OL_OFFICEDTO parameter = base.RequestData.Data.JsonDeserialize<OL_OFFICEDTO>(new JsonConverter[0]);
		officeService.DelTempOnlineOfficeById(parameter);
	}

	private void GetTempOnlineOfficeByUserId(ResponseData handlerResult)
	{
		OL_OFFICEDTO parameter = base.RequestData.Data.JsonDeserialize<OL_OFFICEDTO>(new JsonConverter[0]);
		handlerResult.Data = officeService.GetTempOnlineOfficeByUserId(parameter).JsonSerialize();
	}

	private void GetOnlineOfficeByObjId(ResponseData handlerResult)
	{
		OL_OFFICEDTO dto = base.RequestData.Data.JsonDeserialize<OL_OFFICEDTO>(new JsonConverter[0]);
		handlerResult.Data = officeService.GetOnlineOfficeByObjId(dto.OBJ_ID).JsonSerialize();
	}

	private void SaveOnlineOffice(ResponseData handlerResult)
	{
		OL_OFFICEDTO dto = base.RequestData.Data.JsonDeserialize<OL_OFFICEDTO>(new JsonConverter[0]);
		handlerResult.Data = officeService.SaveOnlineOffice(dto).JsonSerialize();
	}
}
