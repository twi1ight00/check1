using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Application.Services;
using Richfit.Garnet.Module.ITManagement.Domain.Models;

namespace Richfit.Garnet.Module.ITManagement.HandlerProcess.Handlers;

public class ITSupportHandler : HandlerBase
{
	private IITSupportService itsupportservice = ServiceLocator.Instance.GetService<IITSupportService>();

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
				case "Get_AllitSupportList":
					AllitSupportList(handlerResult);
					break;
				case "Del_ItSupportListByID":
					ItSupportListByID(handlerResult);
					break;
				case "ITSupport_DownloadITAttachment":
					DownloadITAttachment(handlerResult);
					break;
				case "ITSupport_GetITAttachmentByID":
					GetITAttachmentByID(handlerResult);
					break;
				case "Get_AllitSupportModelSearchList":
					AllitSupportModelSearchList(handlerResult);
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

	private void AllitSupportModelSearchList(ResponseData handlerResult)
	{
		IT_SUPPORTMANGDTO itsupportdto = base.RequestData.Data.JsonDeserialize<IT_SUPPORTMANGDTO>(new JsonConverter[0]);
		handlerResult.Data = itsupportservice.AllitSupportModelSearchList(itsupportdto).JsonSerialize();
	}

	private void GetITAttachmentByID(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid IT_SUPPORTMANG_ID = (string.IsNullOrEmpty(dictionary["IT_SUPPORTMANG_ID"]) ? Guid.Empty : Guid.Parse(dictionary["IT_SUPPORTMANG_ID"]));
		itsupportservice.GetITAttachmentByID(IT_SUPPORTMANG_ID);
	}

	private void DownloadITAttachment(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid attachmentID = (string.IsNullOrEmpty(dictionary["IT_SUPPORTMANG_ID"]) ? Guid.Empty : Guid.Parse(dictionary["IT_SUPPORTMANG_ID"]));
		IT_SUPPORTMANG itsupport = itsupportservice.GetITAttachmentByID(attachmentID);
		if (itsupport != null)
		{
			DownloadFromFolder(itsupport);
			return;
		}
		throw new ValidationException("Fundation.Public.V_0002");
	}

	private void DownloadFromFolder(IT_SUPPORTMANG ITattachment)
	{
		Stream stream = null;
		string absolutelyPath = string.Empty;
		absolutelyPath = ((!ITattachment.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{ITattachment.FILE_NETWORK_PATH}{ITattachment.FILE_RELATIVE_PATH}{ITattachment.IT_SUPPORTMANG_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{ITattachment.FILE_RELATIVE_PATH}{ITattachment.IT_SUPPORTMANG_ID}");
		if (File.Exists(absolutelyPath))
		{
			try
			{
				stream = new FileStream(absolutelyPath, FileMode.Open, FileAccess.Read, FileShare.Read);
				AttachmentHepler.DownloadStream(stream, ITattachment.IT_SUPPORTMANG_NAME, ITattachment.FILE_TYPE);
				return;
			}
			catch (Exception ex)
			{
				throw new CustomCodeException("Fundation.Public.V_0003", ex);
			}
			finally
			{
				stream?.Close();
			}
		}
		throw new ValidationException("Fundation.Public.V_0004");
	}

	private void ItSupportListByID(ResponseData handlerResult)
	{
		Dictionary<string, List<string>> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, List<string>>>(new JsonConverter[0]);
		itsupportservice.ITSupportDelAttachment(dictionary["IDs"]);
	}

	private void AllitSupportList(ResponseData handlerResult)
	{
		IT_SUPPORTMANGDTO itsupportdto = base.RequestData.Data.JsonDeserialize<IT_SUPPORTMANGDTO>(new JsonConverter[0]);
		handlerResult.Data = itsupportservice.QueryGetAllItSupportList(itsupportdto).JsonSerialize();
	}
}
