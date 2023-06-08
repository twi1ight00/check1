using System;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.JScript;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Application.Services;

namespace Richfit.Garnet.Module.ITManagement.HandlerProcess.Handlers;

public class ITSupportAttachmentHandler : HandlerBase
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
				case "Add_ITSupportAttachment":
					ITSupportAddAttachment(handlerResult);
					break;
				case "Get_ITSupportdelAttachment":
					ITSupportdelAttachment(handlerResult);
					break;
				case "Get_ITSupportAllAttachment":
					ITSupportAllAttachment(handlerResult);
					break;
				case "Get_ITSupportAttachmentByType":
					ITSupportAttachmentByType(handlerResult);
					break;
				case "Read_ITPrepareAddAttachment":
					ITPrepareAddAttachment(handlerResult);
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

	private void ITSupportAddAttachment(ResponseData handlerResult)
	{
		IT_SUPPORTMANGDTO itattachmentDTO = base.RequestData.Data.JsonDeserialize<IT_SUPPORTMANGDTO>(new JsonConverter[0]);
		itsupportservice.ITSupportAddAttachment(itattachmentDTO);
	}

	private void ITPrepareAddAttachment(ResponseData handlerResult)
	{
		string absolutelyPath = string.Empty;
		string fileNetworkPath = string.Empty;
		string fileRelativePath = string.Empty;
		string json = base.RequestData.Data.ToString();
		IT_SUPPORTMANGDTO itattachmentDTO = json.JsonDeserialize<IT_SUPPORTMANGDTO>(new JsonConverter[0]);
		itattachmentDTO.IT_SUPPORTMANG_ID = Guid.NewGuid();
		itattachmentDTO.IT_SUPPORTMANG_NAME = GlobalObject.unescape(itattachmentDTO.IT_SUPPORTMANG_NAME);
		string value1 = ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString();
		string value2 = ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString();
		if (string.IsNullOrEmpty(value1) || value2 == "1")
		{
			int storageLocation = 1;
		}
		else
		{
			int storageLocation = int.Parse(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString());
			fileNetworkPath = ConfigurationManager.CurrentPackage.Settings["FileNetWorkPath"].ToString();
			fileRelativePath = ConfigurationManager.CurrentPackage.Settings["FileRelativePath"].ToString();
			itattachmentDTO.FILE_NETWORK_PATH = fileNetworkPath;
			string catalog = itattachmentDTO.Catalog;
			char[] myByte = catalog.ToArray();
			if (myByte[0] != '\\')
			{
				catalog = "\\" + catalog;
			}
			if (myByte[myByte.Length - 1] != '\\')
			{
				catalog += "\\";
			}
			if (catalog.Contains("yyyy-MM-dd"))
			{
				catalog = catalog.Replace("yyyy-MM-dd", string.Format("{0}\\{1}\\{2}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd")));
			}
			if (catalog.Contains("yyyy-MM"))
			{
				catalog = catalog.Replace("yyyy-MM", string.Format("{0}\\{1}\\", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM")));
			}
			if (catalog.Contains("yyyy"))
			{
				catalog = catalog.Replace("yyyy", string.Format("{0}\\", DateTime.Now.ToString("yyyy")));
			}
			itattachmentDTO.Catalog = catalog;
			itattachmentDTO.FILE_RELATIVE_PATH = $"{fileRelativePath}{catalog}";
			absolutelyPath = ((!itattachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{itattachmentDTO.FILE_NETWORK_PATH}{itattachmentDTO.FILE_RELATIVE_PATH}" : $"{AppDomain.CurrentDomain.BaseDirectory}{itattachmentDTO.FILE_RELATIVE_PATH}");
			if (!Directory.Exists(absolutelyPath))
			{
				Directory.CreateDirectory(absolutelyPath);
			}
		}
		handlerResult.Data = itattachmentDTO.JsonSerialize();
	}

	private void ITSupportAttachmentByType(ResponseData handlerResult)
	{
	}

	private void ITSupportAllAttachment(ResponseData handlerResult)
	{
	}

	private void ITSupportdelAttachment(ResponseData handlerResult)
	{
	}
}
