using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.JScript;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Attachment.AbbyyOCR;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Attachment.Domain.Models;
using Richfit.Garnet.Module.Attachment.SolrNet;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;

namespace Richfit.Garnet.Module.Attachment.Application.Services.Attachment;

public class AttachmentService : ServiceBase, IAttachmentService
{
	/// <summary>
	/// Attachment 仓储对象
	/// </summary>
	private readonly IRepository<SYS_ATTACHMENT> attachmentRepository;

	/// <summary>
	/// AttachmentMapping 仓储对象
	/// </summary>
	private readonly IRepository<SYS_ATTACHMENT_MAPPING> attachmentMappingRepository;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryAttachment">Attachment仓储</param>
	/// <param name="repositoryAttachmentMapping">AttachmentMapping仓储</param>
	public AttachmentService(IRepository<SYS_ATTACHMENT> repositoryAttachment, IRepository<SYS_ATTACHMENT_MAPPING> repositoryAttachmentMapping)
	{
		attachmentRepository = repositoryAttachment;
		attachmentMappingRepository = repositoryAttachmentMapping;
	}

	/// <summary>
	/// 上传附件信息
	/// </summary>
	/// <param name="attachmentDTO">保存附件的DTO</param>
	/// <param name="inputStream">附件内容流</param>
	/// <returns>返回附件信息AttachmentDTO</returns>
	public AttachmentDTO UploadAttachment(AttachmentDTO attachmentDTO, Stream inputStream)
	{
		if (attachmentDTO == null)
		{
			throw new ArgumentException("AddAttachment方法参数不能为空！");
		}
		if (attachmentDTO.IsValid())
		{
			string Create = attachmentRepository.GetSqlConfig("UpdateAttachmentInitData", GetType()).Replace("\n", " ").Replace("\r", " ");
			string Append = attachmentRepository.GetSqlConfig("UpdateAttachmentAppendData", GetType()).Replace("\n", " ").Replace("\r", " ");
			attachmentDTO.ATTACHMENT_TYPE = Richfit.Garnet.Common.Configuration.ConfigurationManager.CurrentPackage.Settings.GetValue(Path.GetExtension(attachmentDTO.ATTACHMENT_NAME)).IfNullOrEmpty("application/octet-stream");
			UserSessionInfo userSessionInfo = SessionContext.UserInfo;
			SYS_ATTACHMENT attachmentPOCO = attachmentDTO.AdaptAsEntity<SYS_ATTACHMENT>();
			attachmentPOCO.ISDEL = 0m;
			attachmentPOCO.CREATETIME = DateTime.UtcNow;
			attachmentPOCO.CREATOR = userSessionInfo.UserID;
			attachmentPOCO.MODIFYTIME = DateTime.UtcNow;
			attachmentPOCO.MODIFIER = userSessionInfo.UserID;
			attachmentRepository.Add(attachmentPOCO);
			attachmentRepository.DbContext.Commit();
			string absolutelyPath = string.Empty;
			switch ((int)attachmentDTO.STORAGE_LOCATION.Value)
			{
			case 1:
			{
				byte[] buff = new byte[16080];
				int index = 0;
				int count = 0;
				attachmentRepository.ExecuteCommand(Create, attachmentDTO.ATTACHMENT_ID);
				while ((count = inputStream.Read(buff, 0, buff.Length)) > 0)
				{
					byte[] contents;
					if (count == buff.Length)
					{
						contents = buff;
					}
					else
					{
						contents = new byte[count];
						Array.Copy(buff, contents, count);
					}
					attachmentRepository.ExecuteCommand(Append, attachmentDTO.ATTACHMENT_ID, contents, contents.Length);
					index += count;
				}
				break;
			}
			case 2:
			{
				string fileExtension = Path.GetExtension(attachmentDTO.ATTACHMENT_NAME);
				if (fileExtension.ToLower() == ".dll" || fileExtension.ToLower() == ".exe")
				{
					throw new ValidationException("Fundation.Public.V_0001");
				}
				if (CreateDirectory(attachmentDTO.FILE_NETWORK_PATH, attachmentDTO.FILE_RELATIVE_PATH))
				{
					absolutelyPath = ((!attachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{attachmentDTO.FILE_NETWORK_PATH}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}");
				}
				using (FileStream fs = File.Create(absolutelyPath))
				{
					inputStream.CopyTo(fs);
				}
				break;
			}
			}
			attachmentDTO = attachmentPOCO.AdaptAsDTO<AttachmentDTO>();
			return attachmentDTO;
		}
		throw new ValidationException(attachmentDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 批量逻辑删除附件及映射关系
	/// </summary>
	/// <param name="objectID">业务记录ID</param>
	/// <param name="objectTableName">业务表名称</param>
	/// <param name="attachmentIDs">附件ID列表</param>
	public void RemoveAttachmentAndMapping(Guid objectID, string objectTableName, List<Guid> attachmentIDs)
	{
		foreach (Guid attachmentID in attachmentIDs)
		{
			RemoveAttachmentMapping(objectID, objectTableName, attachmentID);
			if (!IsExitsMapping(attachmentID))
			{
				SYS_ATTACHMENT AttachmentIDPOCO = attachmentRepository.GetByKey(attachmentID);
				AttachmentIDPOCO.ISDEL = 1m;
				attachmentRepository.UpdateCommit(AttachmentIDPOCO);
			}
		}
	}

	/// <summary>
	/// 删除附件映射关系
	/// </summary>
	/// <param name="objectID"></param>
	/// <param name="objectTableName"></param>
	/// <param name="attachmentID">attachmentID为空值时删除匹配的objectID，objectTableName的所有记录</param>
	private void RemoveAttachmentMapping(Guid objectID, string objectTableName, Guid attachmentID)
	{
		IList<QueryItem> queryItemList = new List<QueryItem>();
		if (objectID != Guid.Empty && !string.IsNullOrEmpty(objectTableName))
		{
			queryItemList.Add(QueryItem.GetQueryItem("OBJECT_ID", objectID.ToString(), "guid", " = "));
			queryItemList.Add(QueryItem.GetQueryItem("OBJECT_TABLE_NAME", objectTableName.ToString(), "string", " = "));
		}
		if (attachmentID != Guid.Empty)
		{
			queryItemList.Add(QueryItem.GetQueryItem("ATTACHMENT_ID", attachmentID.ToString(), "guid", " = "));
		}
		if (queryItemList != null)
		{
			ISpecification<SYS_ATTACHMENT_MAPPING> specification = attachmentMappingRepository.GetSpecification(queryItemList);
			IList<SYS_ATTACHMENT_MAPPING> attachmentMappingPOCOList = null;
			attachmentMappingPOCOList = attachmentMappingRepository.FindAll(specification);
			if (attachmentMappingPOCOList != null && attachmentMappingPOCOList.Any())
			{
				attachmentMappingRepository.RemoveCommit(attachmentMappingPOCOList);
			}
		}
	}

	/// <summary>
	/// 批量逻辑删除附件信息
	/// </summary>
	/// <param name="attachmentIDs"></param>
	public void RemoveAttachment(List<Guid> attachmentIDs)
	{
		if (attachmentIDs == null)
		{
			return;
		}
		foreach (Guid attachmentID in attachmentIDs)
		{
			SYS_ATTACHMENT AttachmentIDPOCO = attachmentRepository.GetByKey(attachmentID);
			if (AttachmentIDPOCO != null)
			{
				IList<SYS_ATTACHMENT_MAPPING> mappingList = attachmentMappingRepository.FindAll((SYS_ATTACHMENT_MAPPING a) => a.ATTACHMENT_ID == attachmentID);
				if (mappingList.Count != 0 && mappingList[0].OBJECT_TABLE_NAME == "DOC_FILE")
				{
					string itemid = $"{attachmentID}";
					SolrNetUtility.Instance.Delete(itemid);
				}
				AttachmentIDPOCO.ISDEL = 1m;
				attachmentRepository.UpdateCommit(AttachmentIDPOCO);
			}
		}
	}

	/// <summary>
	/// 保存附件映射(先删除，再添加)
	/// </summary>
	/// <param name="objectID">业务记录ID</param>
	/// <param name="objectTableName">业务记录表名</param>
	/// <param name="attachmentIDs">附件列表</param>
	public void SaveAttachmentMapping(Guid objectID, string objectTableName, List<AttachmentDTO> attachmentIDs)
	{
		foreach (AttachmentDTO attachmentInfo in attachmentIDs)
		{
			if (attachmentInfo.RecordState == RecordState.Deleted)
			{
				RemoveAttachmentMapping(objectID, objectTableName, attachmentInfo.ATTACHMENT_ID.Value);
			}
			if (attachmentInfo.RecordState == RecordState.Added)
			{
				AddAttachmentMapping(objectID, objectTableName, attachmentInfo.ATTACHMENT_ID.Value);
			}
		}
	}

	/// <summary>
	/// 添加附件映射关系
	/// </summary>
	/// <param name="objectID"></param>
	/// <param name="objectTableName"></param>
	/// <param name="attachmentID"></param>
	public void AddAttachmentMapping(Guid objectID, string objectTableName, Guid attachmentID)
	{
		if (objectID != Guid.Empty && !string.IsNullOrEmpty(objectTableName))
		{
			List<AttachmentMappingDTO> attachmentMappingDTOList = new List<AttachmentMappingDTO>();
			AttachmentMappingDTO attachmentMappingDTO = new AttachmentMappingDTO();
			attachmentMappingDTO.OBJECT_ID = objectID;
			attachmentMappingDTO.OBJECT_TABLE_NAME = objectTableName;
			attachmentMappingDTO.ATTACHMENT_ID = attachmentID;
			attachmentMappingDTOList.Add(attachmentMappingDTO);
			List<SYS_ATTACHMENT_MAPPING> attachmentMappingPOCOList = attachmentMappingDTOList.AdaptAsEntity<SYS_ATTACHMENT_MAPPING>();
			attachmentMappingRepository.AddCommit(attachmentMappingPOCOList);
		}
	}

	/// <summary>
	/// 查询单个附件信息
	/// </summary>
	/// <param name="AttachmentID">AttachmentID</param>
	/// <returns>QueryAttachmentByID</returns>
	public QueryResult<AttachmentDTO> QueryAttachmentByID(Guid AttachmentID)
	{
		QueryResult<AttachmentDTO> queryResult = new QueryResult<AttachmentDTO>();
		if (AttachmentID != Guid.Empty)
		{
			IList<QueryItem> queryItemList = new List<QueryItem>();
			queryItemList.Add(QueryItem.GetQueryItem("ATTACHMENT_ID", AttachmentID.ToString(), "guid", " = "));
			queryResult = SqlQuery<AttachmentDTO, SYS_ATTACHMENT>("GetAttachmentByAttachmentID", queryItemList.TransformCondition(), attachmentRepository);
		}
		return queryResult;
	}

	/// <summary>
	///             查询附件列表信息
	/// </summary>
	/// <param name="queryCondition">查询条件表达式</param>
	/// <returns>返回附件列表</returns>
	public QueryResult<AttachmentDTO> QueryAttachmentList(QueryCondition queryCondition)
	{
		QueryResult<AttachmentDTO> attachmentDTOList = new QueryResult<AttachmentDTO>();
		attachmentDTOList = SqlQuery<AttachmentDTO, SYS_ATTACHMENT>("GetAttachmentList", queryCondition, attachmentRepository);
		foreach (AttachmentDTO attachmentDTO in attachmentDTOList.List)
		{
			if (attachmentDTO.ATTACHMENT_SIZE.Value / 1048576m > 1m)
			{
				attachmentDTO.ATTACHMENTSIZENAME = decimal.Round(attachmentDTO.ATTACHMENT_SIZE.Value / 1048576m, 2) + "MB";
			}
			else
			{
				attachmentDTO.ATTACHMENTSIZENAME = decimal.Round(attachmentDTO.ATTACHMENT_SIZE.Value / 1024m, 2) + "KB";
			}
		}
		return attachmentDTOList;
	}

	/// <summary>
	/// 从数据库读取附件的内容并以二进制流方式传出
	/// </summary>
	/// <param name="attachmentDTO">所要读取附件记录的DTO</param>
	/// <returns>附件内容的二进制流</returns>
	public Stream ReadBaseAttachment(AttachmentDTO attachmentDTO)
	{
		QueryItem queryItemID = QueryItem.GetQueryItem("ATTACHMENT_ID", attachmentDTO.ATTACHMENT_ID.ToString(), "guid", " = ");
		QueryItem queryItemDelete = QueryItem.GetQueryItem("ISDEL", "0", "number", " = ");
		QueryCondition queryCondition = new QueryCondition();
		queryCondition.Insert(0, queryItemID);
		queryCondition.Insert(1, queryItemDelete);
		return ReadDatabaseToFile("GetAttachmentContent", attachmentDTO.ATTACHMENT_NAME, queryCondition);
	}

	/// <summary>
	/// 判断是否有关联
	/// </summary>
	/// <param name="attachmentID"></param>
	/// <returns></returns>
	private bool IsExitsMapping(Guid attachmentID)
	{
		bool isExist = false;
		if (attachmentID != Guid.Empty)
		{
			IList<QueryItem> queryItemList = new List<QueryItem>();
			queryItemList.Add(QueryItem.GetQueryItem("ATTACHMENT_ID", attachmentID.ToString(), "guid", " = "));
			ISpecification<SYS_ATTACHMENT_MAPPING> specification = attachmentMappingRepository.GetSpecification(queryItemList);
			IList<SYS_ATTACHMENT_MAPPING> attachmentMappingList = attachmentMappingRepository.FindAll(specification);
			if (attachmentMappingList != null && attachmentMappingList.Count() > 0)
			{
				isExist = true;
			}
		}
		return isExist;
	}

	/// <summary>
	/// 生成保存路径
	/// </summary>
	/// <param name="fileNetworkPath"></param>
	/// <param name="fileRelativePath"></param>
	/// <returns></returns>
	private bool CreateDirectory(string fileNetworkPath, string fileRelativePath)
	{
		string fullDirectoryPath = string.Empty;
		if (fileNetworkPath.IsNullOrEmpty())
		{
			fileNetworkPath = AppDomain.CurrentDomain.BaseDirectory;
		}
		fullDirectoryPath = $"{fileNetworkPath}{fileRelativePath}";
		try
		{
			if (!Directory.Exists(fullDirectoryPath))
			{
				Directory.CreateDirectory(fullDirectoryPath);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public IList<AttachmentDTO> GetAttachmentByObjId(Guid guid)
	{
		return SqlQuery<AttachmentDTO>("GetAttachmentByObjId", new
		{
			OBJECT_ID = guid
		});
	}

	public IList<AttachmentDTO> GetAttachmentBymap(AttachmentMappingDTO attachmentmapDTO)
	{
		IList<AttachmentDTO> attachList = new List<AttachmentDTO>();
		if (attachmentmapDTO.DOC_TYPE.HasValue)
		{
			return SqlQuery<AttachmentDTO>("GetAttachmentByObjIdTYPE", new { attachmentmapDTO.OBJECT_ID, attachmentmapDTO.DOC_TYPE });
		}
		return SqlQuery<AttachmentDTO>("GetAttachmentByObjId", new { attachmentmapDTO.OBJECT_ID });
	}

	public AttachmentDTO GetAttachmentById(Guid guid)
	{
		return attachmentRepository.GetByKey(guid).AdaptAsDTO<AttachmentDTO>();
	}

	public IList<AttachmentMappingDTO> GetAttachmentListByAttachment_ID(Guid guid)
	{
		IList<AttachmentMappingDTO> attachList = new List<AttachmentMappingDTO>();
		return SqlQuery<AttachmentMappingDTO>("GetAttachmentListByAttachment_ID", new
		{
			ATTACHMENT_ID = guid
		});
	}

	public void SaveAttachment(AttachmentDTO attachmentDTO)
	{
		if (attachmentDTO == null)
		{
			throw new ArgumentException("AddFile方法参数不能为空！");
		}
		if (attachmentDTO.IsValid())
		{
			DateTime date = DateTime.Now;
			SYS_ATTACHMENT attachment = attachmentDTO.AdaptAsEntity<SYS_ATTACHMENT>();
			attachment.ATTACHMENT_NAME = GlobalObject.unescape(attachment.ATTACHMENT_NAME);
			FileInfo fileInfo = new FileInfo(attachment.FILE_RELATIVE_PATH);
			int index = attachment.ATTACHMENT_NAME.LastIndexOf('.');
			attachment.ATTACHMENT_TYPE = ((index > -1) ? attachment.ATTACHMENT_NAME.Substring(index + 1, attachment.ATTACHMENT_NAME.Length - index - 1) : "");
			Guid cREATOR = (attachment.MODIFIER = SessionContext.UserInfo.UserID);
			attachment.CREATOR = cREATOR;
			DateTime cREATETIME = (attachment.MODIFYTIME = DateTime.Now);
			attachment.CREATETIME = cREATETIME;
			attachment.ISDEL = 0m;
			attachment.STORAGE_LOCATION = 2m;
			SYS_ATTACHMENT AttachmentIDPOCO = attachmentRepository.GetByKey(attachment.ATTACHMENT_ID);
			if (AttachmentIDPOCO != null)
			{
				AttachmentIDPOCO.FILE_NO = attachment.FILE_NO;
				AttachmentIDPOCO.IS_EFFECTIVE = attachment.IS_EFFECTIVE;
				AttachmentIDPOCO.ATTACHMENT_NAME = attachment.ATTACHMENT_NAME;
				AttachmentIDPOCO.FILE_RELATIVE_PATH = attachment.FILE_RELATIVE_PATH;
				attachmentRepository.UpdateCommit(AttachmentIDPOCO);
			}
			else
			{
				attachmentRepository.AddCommit(attachment);
			}
			return;
		}
		throw new ValidationException(attachmentDTO.GetInvalidMessages());
	}

	public void SaveAttachmentMapping(IList<AttachmentMappingDTO> attachmentMappingDTOs)
	{
		if (attachmentMappingDTOs == null || attachmentMappingDTOs.Count == 0 || !attachmentMappingDTOs[0].OBJECT_ID.HasValue || attachmentMappingDTOs[0].OBJECT_ID == Guid.Empty)
		{
			return;
		}
		IList<SYS_ATTACHMENT_MAPPING> maps;
		if (attachmentMappingDTOs[0].OBJECT_TABLE_NAME != "DOC_FILE")
		{
			Guid guid = Guid.Empty;
			foreach (AttachmentMappingDTO item in attachmentMappingDTOs)
			{
				if (!(item.OBJECT_ID != guid))
				{
					continue;
				}
				guid = item.OBJECT_ID.Value;
				if (item.DOC_TYPE.HasValue)
				{
					IList<SYS_ATTACHMENT_MAPPING> mappingList = attachmentMappingRepository.FindAll((SYS_ATTACHMENT_MAPPING a) => a.OBJECT_ID == guid && a.DOC_TYPE == item.DOC_TYPE);
					attachmentMappingRepository.RemoveCommit(mappingList);
				}
				else
				{
					IList<SYS_ATTACHMENT_MAPPING> mappingList = attachmentMappingRepository.FindAll((SYS_ATTACHMENT_MAPPING a) => a.OBJECT_ID == guid);
					attachmentMappingRepository.RemoveCommit(mappingList);
				}
			}
			maps = new List<SYS_ATTACHMENT_MAPPING>();
			foreach (AttachmentMappingDTO attachmentMappingDTO in attachmentMappingDTOs)
			{
				SYS_ATTACHMENT_MAPPING map2 = attachmentMappingDTO.AdaptAsEntity<SYS_ATTACHMENT_MAPPING>();
				map2.ATTACHMENT_MAPPING_ID = Guid.NewGuid();
				maps.Add(map2);
				decimal? dOC_TYPE = map2.DOC_TYPE;
				if (dOC_TYPE.GetValueOrDefault() == 2m && dOC_TYPE.HasValue)
				{
					AttachmentDTO attachmentDTO = GetAttachmentById(map2.ATTACHMENT_ID);
					string oldPath = HttpContext.Current.Server.MapPath("/") + GlobalObject.unescape(attachmentDTO.FILE_RELATIVE_PATH) + attachmentDTO.ATTACHMENT_ID;
					string newPath = oldPath + "." + attachmentDTO.ATTACHMENT_TYPE;
					if (!File.Exists(newPath))
					{
						File.Copy(oldPath, newPath, overwrite: true);
					}
				}
			}
			attachmentMappingRepository.AddCommit(maps);
			return;
		}
		maps = new List<SYS_ATTACHMENT_MAPPING>();
		foreach (AttachmentMappingDTO attachmentMappingDTO in attachmentMappingDTOs)
		{
			SYS_ATTACHMENT_MAPPING map = attachmentMappingDTO.AdaptAsEntity<SYS_ATTACHMENT_MAPPING>();
			IList<SYS_ATTACHMENT_MAPPING> mappingList = attachmentMappingRepository.FindAll((SYS_ATTACHMENT_MAPPING a) => a.OBJECT_ID == map.OBJECT_ID && a.ATTACHMENT_ID == map.ATTACHMENT_ID);
			if (mappingList.Count != 0)
			{
				continue;
			}
			map.ATTACHMENT_MAPPING_ID = Guid.NewGuid();
			maps.Add(map);
			AttachmentDTO attachmentDTO = GetAttachmentById(map.ATTACHMENT_ID);
			if (attachmentDTO != null)
			{
				string absolutelyPath = $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}";
				string convertpath = string.Format("{0}{1}{2}", AppDomain.CurrentDomain.BaseDirectory, "Files\\DocFile\\", attachmentDTO.ATTACHMENT_ID);
				string mimeType = "";
				if (attachmentDTO.ATTACHMENT_TYPE.ToLower() == "doc")
				{
					mimeType = "application/msword";
				}
				else if (attachmentDTO.ATTACHMENT_TYPE.ToLower() == "pdf")
				{
					mimeType = "application/pdf";
				}
				else if (attachmentDTO.ATTACHMENT_TYPE.ToLower() == "ppt")
				{
					mimeType = "application/vnd.ms-powerpoint";
				}
				else if (attachmentDTO.ATTACHMENT_TYPE.ToLower() == "docx")
				{
					mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
				}
				else if (attachmentDTO.ATTACHMENT_TYPE.ToLower() == "pptx")
				{
					mimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
				}
				else if (attachmentDTO.ATTACHMENT_TYPE.ToLower() == "txt")
				{
					mimeType = "text/plain";
				}
				if (File.Exists(absolutelyPath) && mimeType != "")
				{
					SolrNetUtility.Instance.IndexDoc(absolutelyPath, mimeType, attachmentDTO.ATTACHMENT_NAME, attachmentDTO.ATTACHMENT_TYPE.ToLower(), attachmentDTO.FILE_RELATIVE_PATH);
				}
			}
		}
		attachmentMappingRepository.AddCommit(maps);
	}

	public void ChangeContentMapping(Guid objectID, Guid attachmentID)
	{
		if (objectID == Guid.Empty)
		{
			return;
		}
		bool flag = 1 == 0;
		IList<SYS_ATTACHMENT_MAPPING> mappingList = attachmentMappingRepository.FindAll((SYS_ATTACHMENT_MAPPING a) => a.ATTACHMENT_ID == attachmentID);
		IList<SYS_ATTACHMENT_MAPPING> maps = new List<SYS_ATTACHMENT_MAPPING>();
		foreach (SYS_ATTACHMENT_MAPPING map in mappingList)
		{
			map.OBJECT_ID = objectID;
			maps.Add(map);
		}
		attachmentMappingRepository.UpdateCommit(maps);
	}

	public QueryResult<SOLRNETDTO> QuerySolrbyword(SOLRNETDTO solrnetdto)
	{
		return SolrNetUtility.Instance.Query(solrnetdto);
	}

	private string Process_File_OCR(Guid? attachment_ID)
	{
		AttachmentDTO attachment = GetAttachmentById(attachment_ID.Value);
		OCRHandler handler = new OCRHandler(null);
		string fileType = attachment.ATTACHMENT_NAME.Substring(attachment.ATTACHMENT_NAME.LastIndexOf('.'));
		string absolutelyPath = AppDomain.CurrentDomain.BaseDirectory;
		string sourceFilePath = $"{absolutelyPath}{attachment.FILE_RELATIVE_PATH}{attachment.ATTACHMENT_ID}";
		string ocrFileName = attachment.ATTACHMENT_NAME.Substring(0, attachment.ATTACHMENT_NAME.LastIndexOf('.')) + ".docx";
		string ocrFilePath = string.Format("{0}{1}{2}{3}", absolutelyPath, attachment.FILE_NETWORK_PATH, System.Configuration.ConfigurationManager.AppSettings["OCRFilePath"].ToString(), string.Concat(attachment.ATTACHMENT_ID, ocrFileName));
		IList<string> imgSource = new List<string>();
		imgSource.Add(sourceFilePath);
		return handler.doWork(imgSource, ocrFilePath, 1);
	}
}
