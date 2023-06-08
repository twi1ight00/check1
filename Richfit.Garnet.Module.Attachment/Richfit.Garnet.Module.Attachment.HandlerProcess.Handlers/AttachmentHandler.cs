using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Aspose.Cells;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Words;
using Microsoft.JScript;
using Newtonsoft.Json;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Attachment.Application.Services.Attachment;
using Richfit.Garnet.Module.Attachment.Cache;
using Richfit.Garnet.Module.Attachment.SolrNet;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

namespace Richfit.Garnet.Module.Attachment.HandlerProcess.Handlers;

/// <summary>
/// Attachment请求处理类
/// </summary>
public class AttachmentHandler : HandlerBase
{
	private HttpContext context;

	/// <summary>
	/// 附件上传下载接口实例化
	/// </summary>
	private IAttachmentService attachmentService = ServiceLocator.Instance.GetService<IAttachmentService>();

	private static readonly ILogger errorLog = LoggerManager.GetLogger("Exception");

	/// <summary>
	/// ProcessRequest
	/// </summary>
	/// <param name="context">context</param>
	public override void ProcessRequest(HttpContext context)
	{
		this.context = context;
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "System_UploadAttachment":
					if (context.Request.Files.Count > 0)
					{
						UploadAttachment(handlerResult, context);
					}
					break;
				case "System_DownloadAttachment":
					DownloadAttachment();
					break;
				case "System_SaveAttachment":
					SaveAttachmentMapping();
					break;
				case "System_SaveAttachmentList":
					SaveAttachmentListMapping();
					break;
				case "System_RemoveAttachment":
					RemoveAttachment();
					break;
				case "System_QueryAttachmentList":
					QueryAttachmentList(handlerResult);
					break;
				case "System_AddAttachmentMapping":
					AddAttachmentMapping(handlerResult);
					break;
				case "System_RemoveAttachmentAndMapping":
					RemoveAttachmentAndMapping(handlerResult);
					break;
				case "System_QueryAttachmentByID":
					QueryAttachmentByID(handlerResult);
					break;
				case "L_PrepareAddAttachment":
					PrepareAddAttachment(handlerResult);
					break;
				case "L_AddAttachment":
					AddAttachment(handlerResult);
					break;
				case "L_GetAttachmentByObjId":
					GetAttachmentByObjId(handlerResult);
					break;
				case "L_SaveAttachmentMapping":
					SaveAttachmentMapping(handlerResult);
					break;
				case "L_GetAttachmentById":
					GetAttachmentById(handlerResult);
					break;
				case "L_ViewAttachment":
					ViewAttachment(handlerResult);
					break;
				case "GetAttachmentByObjIdOfAndroid":
					GetAttachmentByObjIdOfAndroid(handlerResult);
					break;
				case "DocumentManagement_QuerySolrbyword":
					QuerySolrbyword(handlerResult);
					break;
				case "DocumentManagement_ChangeContent":
					ChangeContent(handlerResult);
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

	private void ViewAttachment(ResponseData handlerResult)
	{
		AttachmentDTO attachmentDTO = base.RequestData.Data.JsonDeserialize<AttachmentDTO>(new JsonConverter[0]);
		string filePath = HttpContext.Current.Server.MapPath("/") + GlobalObject.unescape(attachmentDTO.FILE_RELATIVE_PATH);
		string oldPath = filePath.Substring(0, filePath.LastIndexOf("."));
		string newFilePath = oldPath + ".pdf";
		if (!File.Exists(newFilePath))
		{
			File.Copy(oldPath, filePath, overwrite: true);
		}
		switch (attachmentDTO.ATTACHMENT_TYPE)
		{
		case "doc":
		case "docx":
			if (!File.Exists(newFilePath))
			{
				Document doc = new Document(filePath);
				doc.Save(newFilePath, Aspose.Words.SaveFormat.Pdf);
			}
			break;
		case "xls":
		case "xlsx":
			if (!File.Exists(newFilePath))
			{
				Workbook excel = new Workbook(oldPath);
				excel.Save(newFilePath, Aspose.Cells.SaveFormat.Pdf);
			}
			break;
		case "ppt":
		case "pptx":
			if (!File.Exists(newFilePath))
			{
				Presentation ppt = new Presentation(filePath);
				ppt.Save(newFilePath, Aspose.Slides.Export.SaveFormat.Pdf);
			}
			break;
		case "txt":
			if (!File.Exists(newFilePath))
			{
				newFilePath = oldPath + ".txt";
			}
			break;
		}
		handlerResult.Data = "{\"newFilePath\":\"/" + newFilePath.Replace(HttpContext.Current.Server.MapPath("/"), "").Replace("\\", "/") + "\"}";
	}

	private void GetAttachmentById(ResponseData handlerResult)
	{
		Dictionary<string, Guid> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = attachmentService.GetAttachmentById(dictionary["ATTACHMENT_ID"]).JsonSerialize();
	}

	private void SaveAttachmentMapping(ResponseData handlerResult)
	{
		IList<AttachmentMappingDTO> attachmentDTO = base.RequestData.Data.JsonDeserialize<List<AttachmentMappingDTO>>(new JsonConverter[0]);
		attachmentService.SaveAttachmentMapping(attachmentDTO);
	}

	private void PrepareAddAttachment(ResponseData handlerResult)
	{
		string absolutelyPath = string.Empty;
		string fileNetworkPath = string.Empty;
		string fileRelativePath = string.Empty;
		AttachmentDTO attachmentDTO = base.RequestData.Data.JsonDeserialize<AttachmentDTO>(new JsonConverter[0]);
		attachmentDTO.ATTACHMENT_NAME = GlobalObject.unescape(attachmentDTO.ATTACHMENT_NAME);
		attachmentDTO.ATTACHMENT_ID = Guid.NewGuid();
		if (string.IsNullOrEmpty(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString()) || ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString() == "1")
		{
			int storageLocation = 1;
		}
		else
		{
			int storageLocation = int.Parse(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString());
			fileNetworkPath = ConfigurationManager.CurrentPackage.Settings["FileNetWorkPath"].ToString();
			fileRelativePath = ConfigurationManager.CurrentPackage.Settings["FileRelativePath"].ToString();
			attachmentDTO.FILE_NETWORK_PATH = fileNetworkPath;
			attachmentDTO.STORAGE_LOCATION = storageLocation;
			int i = FileCacheManager.IsHaveFile(ref attachmentDTO);
			string catalog = attachmentDTO.Catalog;
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
			attachmentDTO.Catalog = catalog;
			attachmentDTO.FILE_RELATIVE_PATH = $"{fileRelativePath}{catalog}";
			absolutelyPath = ((!attachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{attachmentDTO.FILE_NETWORK_PATH}{attachmentDTO.FILE_RELATIVE_PATH}" : $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}");
			if (i == 1)
			{
				if (!File.Exists($"{absolutelyPath}/{attachmentDTO.ATTACHMENT_ID}"))
				{
					attachmentDTO.CurrentPosition = 0.0;
				}
				else
				{
					FileInfo fi = new FileInfo($"{absolutelyPath}/{attachmentDTO.ATTACHMENT_ID}");
					attachmentDTO.CurrentPosition = fi.Length;
				}
			}
			else
			{
				if (!Directory.Exists(absolutelyPath))
				{
					Directory.CreateDirectory(absolutelyPath);
				}
				FileCacheManager.AddFileCache(attachmentDTO);
				attachmentDTO.CurrentPosition = 0.0;
			}
		}
		handlerResult.Data = attachmentDTO.JsonSerialize();
	}

	private void DownLoad(ResponseData handlerResult)
	{
		Dictionary<string, Guid> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		QueryResult<AttachmentDTO> attachmentList = attachmentService.QueryAttachmentByID(dictionary["ATTACHMENT_ID"]);
		AttachmentDTO attachmentDTO = attachmentList.List.FirstOrDefault();
		if (attachmentDTO == null)
		{
			return;
		}
		string absolutelyPath = attachmentDTO.FILE_RELATIVE_PATH;
		if (!File.Exists(absolutelyPath))
		{
			return;
		}
		using FileStream stream = new FileStream(absolutelyPath, FileMode.Open, FileAccess.Read, FileShare.Read);
		try
		{
			AttachmentHepler.DownloadStream(stream, attachmentDTO.ATTACHMENT_NAME, attachmentDTO.ATTACHMENT_TYPE);
		}
		catch (Exception ex)
		{
			throw new CustomCodeException("Fundation.Public.V_0003", ex);
		}
	}

	private void GetAttachmentByObjId(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid objId = (string.IsNullOrEmpty(dictionary["OBJ_ID"]) ? Guid.Empty : Guid.Parse(dictionary["OBJ_ID"]));
		AttachmentMappingDTO attachmentmapDTO = base.RequestData.Data.JsonDeserialize<AttachmentMappingDTO>(new JsonConverter[0]);
		attachmentmapDTO.OBJECT_ID = objId;
		handlerResult.Data = attachmentService.GetAttachmentBymap(attachmentmapDTO).JsonSerialize();
	}

	private void AddAttachment(ResponseData handlerResult)
	{
		AttachmentDTO attachmentDTO = base.RequestData.Data.JsonDeserialize<AttachmentDTO>(new JsonConverter[0]);
		attachmentService.SaveAttachment(attachmentDTO);
	}

	private void UploadAttachment(ResponseData handlerResult, HttpContext context)
	{
		if (context.Request.Files.Count != 0)
		{
			AttachmentDTO attachmentDTO = new AttachmentDTO();
			string fileDynamicPath = base.RequestData.Data;
			string absolutelyPath = string.Empty;
			string fileNetworkPath = string.Empty;
			string fileRelativePath = string.Empty;
			int storageLocation;
			if (string.IsNullOrEmpty(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString()) || ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString() == "1")
			{
				storageLocation = 1;
			}
			else
			{
				storageLocation = int.Parse(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString());
				fileNetworkPath = ConfigurationManager.CurrentPackage.Settings["FileNetWorkPath"].ToString();
				fileRelativePath = ConfigurationManager.CurrentPackage.Settings["FileRelativePath"].ToString();
			}
			Stream inputStream = context.Request.Files[0].InputStream;
			attachmentDTO.ATTACHMENT_SIZE = inputStream.Length;
			attachmentDTO.ATTACHMENT_NAME = context.Request.Files[0].FileName;
			attachmentDTO.STORAGE_LOCATION = storageLocation;
			string catalog = fileDynamicPath;
			catalog = catalog.Replace("//", "\\");
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
			attachmentDTO.Catalog = catalog;
			attachmentDTO.FILE_RELATIVE_PATH = $"{fileRelativePath}{catalog}";
			attachmentDTO.ATTACHMENT_ID = Guid.NewGuid();
			handlerResult.Data = attachmentService.UploadAttachment(attachmentDTO, inputStream).ATTACHMENT_ID.ToString();
		}
	}

	private void DownloadAttachment()
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid attachmentID = (string.IsNullOrEmpty(dictionary["ATTACHMENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ATTACHMENT_ID"]));
		QueryResult<AttachmentDTO> attachmentList = attachmentService.QueryAttachmentByID(attachmentID);
		AttachmentDTO attachmentDTO = new AttachmentDTO();
		attachmentDTO = attachmentList.List.FirstOrDefault();
		if (attachmentDTO != null)
		{
			switch ((int)attachmentDTO.STORAGE_LOCATION.Value)
			{
			case 1:
				DownloadFromDataBase(attachmentDTO);
				break;
			case 2:
				DownloadFromFolder(attachmentDTO);
				break;
			}
			return;
		}
		throw new ValidationException("Fundation.Public.V_0002");
	}

	private void DownloadFromFolder(AttachmentDTO attachmentDTO)
	{
		Stream stream = null;
		string absolutelyPath = string.Empty;
		absolutelyPath = ((!attachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{attachmentDTO.FILE_NETWORK_PATH}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}");
		if (File.Exists(absolutelyPath))
		{
			try
			{
				stream = new FileStream(absolutelyPath, FileMode.Open, FileAccess.Read, FileShare.Read);
				AttachmentHepler.DownloadStream(stream, attachmentDTO.ATTACHMENT_NAME, attachmentDTO.ATTACHMENT_TYPE);
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

	private void DownloadFromDataBase(AttachmentDTO attachmentDTO)
	{
		if (attachmentDTO == null)
		{
			return;
		}
		Stream stream = null;
		try
		{
			stream = attachmentService.ReadBaseAttachment(attachmentDTO);
			AttachmentHepler.DownloadStream(stream, attachmentDTO.ATTACHMENT_NAME, attachmentDTO.ATTACHMENT_TYPE);
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

	private void SaveAttachmentMapping()
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid objectID = (string.IsNullOrEmpty(dictionary["ObjectID"]) ? Guid.Empty : Guid.Parse(dictionary["ObjectID"]));
		string objectTableName = (string.IsNullOrEmpty(dictionary["ObjectTableName"]) ? string.Empty : dictionary["ObjectTableName"]);
		string attachmentInfo = (string.IsNullOrEmpty(dictionary["AttachmentID"]) ? string.Empty : dictionary["AttachmentID"]);
		List<AttachmentDTO> attachmentIDList = attachmentInfo.JsonDeserialize<List<AttachmentDTO>>(new JsonConverter[0]);
		attachmentService.SaveAttachmentMapping(objectID, objectTableName, attachmentIDList);
	}

	private void SaveAttachmentListMapping()
	{
		List<Dictionary<string, string>> array = base.RequestData.Data.JsonDeserialize<List<Dictionary<string, string>>>(new JsonConverter[0]);
		foreach (Dictionary<string, string> dictionary in array)
		{
			Guid objectID = (string.IsNullOrEmpty(dictionary["ObjectID"]) ? Guid.Empty : Guid.Parse(dictionary["ObjectID"]));
			string objectTableName = (string.IsNullOrEmpty(dictionary["ObjectTableName"]) ? string.Empty : dictionary["ObjectTableName"]);
			string attachmentInfo = (string.IsNullOrEmpty(dictionary["AttachmentID"]) ? string.Empty : dictionary["AttachmentID"]);
			List<AttachmentDTO> attachmentIDList = attachmentInfo.JsonDeserialize<List<AttachmentDTO>>(new JsonConverter[0]);
			attachmentService.SaveAttachmentMapping(objectID, objectTableName, attachmentIDList);
		}
	}

	private void RemoveAttachment()
	{
		string attachmentID = base.RequestData.Data;
		List<Guid> attachmentIDList = new List<Guid>();
		string[] strAttachmentIDS = attachmentID.Split(',');
		string[] array = strAttachmentIDS;
		foreach (string AttachmentID in array)
		{
			attachmentIDList.Add(Guid.Parse(AttachmentID));
		}
		attachmentService.RemoveAttachment(attachmentIDList);
	}

	private void QueryAttachmentList(ResponseData handlerResult)
	{
		QueryCondition condition = GetQueryCondition(base.RequestData.Data);
		handlerResult.Data = attachmentService.QueryAttachmentList(condition).ToJson();
	}

	private void AddAttachmentMapping(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid objectID = (string.IsNullOrEmpty(dictionary["ObjectID"]) ? Guid.Empty : Guid.Parse(dictionary["ObjectID"]));
		string objectTableName = (string.IsNullOrEmpty(dictionary["ObjectTableName"]) ? string.Empty : dictionary["ObjectTableName"]);
		Guid attachmentID = (string.IsNullOrEmpty(dictionary["AttachmentID"]) ? Guid.Empty : Guid.Parse(dictionary["AttachmentID"]));
		attachmentService.AddAttachmentMapping(objectID, objectTableName, attachmentID);
	}

	private void RemoveAttachmentAndMapping(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid objectID = (string.IsNullOrEmpty(dictionary["ObjectID"]) ? Guid.Empty : Guid.Parse(dictionary["ObjectID"]));
		string objectTableName = (string.IsNullOrEmpty(dictionary["ObjectTableName"]) ? string.Empty : dictionary["ObjectTableName"]);
		string attachmentIDs = (string.IsNullOrEmpty(dictionary["AttachmentID"]) ? string.Empty : dictionary["AttachmentID"]);
		List<Guid> attachmentIDList = attachmentIDs.JsonDeserialize<List<Guid>>(new JsonConverter[0]);
		attachmentService.RemoveAttachmentAndMapping(objectID, objectTableName, attachmentIDList);
	}

	private void QueryAttachmentByID(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid attachmentID = (string.IsNullOrEmpty(dictionary["ATTACHMENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ATTACHMENT_ID"]));
		QueryResult<AttachmentDTO> attachmentList = attachmentService.QueryAttachmentByID(attachmentID);
		AttachmentDTO attachmentDTO = attachmentList.List.FirstOrDefault();
		if (attachmentDTO != null)
		{
			handlerResult.Data = attachmentDTO.ToJson();
			return;
		}
		throw new ValidationException("Fundation.Public.V_0002");
	}

	private void GetAttachmentByObjIdOfAndroid(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid objId = (string.IsNullOrEmpty(dictionary["OBJ_ID"]) ? Guid.Empty : Guid.Parse(dictionary["OBJ_ID"]));
		handlerResult.Data = attachmentService.GetAttachmentByObjId(objId).JsonSerialize();
		List<AttachmentDTO> listATTACHDTO = attachmentService.GetAttachmentByObjId(objId).ToList();
		if (listATTACHDTO.Count <= 0)
		{
			return;
		}
		string absolutelyPath = null;
		string relativePath = null;
		byte[] byData = null;
		int TranRecord = 0;
		string saveDirectory = null;
		string errorFileName = "";
		string keyHanlerName = "$68$";
		try
		{
			foreach (AttachmentDTO item in listATTACHDTO)
			{
				errorFileName = item.ATTACHMENT_NAME;
				relativePath = HttpContext.Current.Server.MapPath("~\\" + item.FILE_RELATIVE_PATH + item.ATTACHMENT_ID);
				absolutelyPath = string.Format("{0}{1}", relativePath + keyHanlerName, "\\" + item.ATTACHMENT_NAME);
				if (File.Exists(absolutelyPath) || !File.Exists(relativePath))
				{
					continue;
				}
				string generatePath = HttpContext.Current.Server.MapPath(string.Concat("~\\", item.FILE_RELATIVE_PATH, item.ATTACHMENT_ID, keyHanlerName));
				if (CreateDirectory(generatePath))
				{
					using FileStream savefs = new FileStream(absolutelyPath, FileMode.Create);
					TranRecord++;
					byte[] byteContent = File.ReadAllBytes(relativePath);
					savefs.Write(byteContent, 0, byteContent.Length);
				}
			}
		}
		catch (Exception ex)
		{
			errorLog.Error($"错误信息：{ex.Message}；调用堆栈信息：{ex.StackTrace}；文件：{errorFileName}");
		}
	}

	private bool CreateDirectory(string saveDirectory)
	{
		try
		{
			if (!Directory.Exists(saveDirectory))
			{
				Directory.CreateDirectory(saveDirectory);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void QuerySolrbyword(ResponseData handlerResult)
	{
		QueryCondition condition = GetQueryCondition(base.RequestData.Data);
		SOLRNETDTO parameter = base.RequestData.Data.JsonDeserialize<SOLRNETDTO>(new JsonConverter[0]);
		handlerResult.Data = attachmentService.QuerySolrbyword(parameter).ToJson();
	}

	private void ChangeContent(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid objectID = (string.IsNullOrEmpty(dictionary["OBJECT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["OBJECT_ID"]));
		Guid attachmentID = (string.IsNullOrEmpty(dictionary["ATTACHMENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ATTACHMENT_ID"]));
		attachmentService.ChangeContentMapping(objectID, attachmentID);
	}
}
