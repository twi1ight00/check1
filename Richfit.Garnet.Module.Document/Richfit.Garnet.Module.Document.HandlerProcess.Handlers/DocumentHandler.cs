using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Microsoft.JScript;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Attachment.Application.Services.Attachment;
using Richfit.Garnet.Module.Attachment.Cache;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Document.Application.DTO;
using Richfit.Garnet.Module.Document.Application.Services;

namespace Richfit.Garnet.Module.Document.HandlerProcess.Handlers;

public class DocumentHandler : HandlerBase
{
	private IDocumentService DocumentService = ServiceLocator.Instance.GetService<IDocumentService>();

	private IAttachmentService AttachmentService = ServiceLocator.Instance.GetService<IAttachmentService>();

	public List<myDataType> allTd = new List<myDataType>();

	public List<myDataType> NoChildren = new List<myDataType>();

	private static string _directory = "";

	public string filepath = "";

	public List<FileTableData> guidNameList = new List<FileTableData>();

	public SortedList<string, string> DownloadguidErrorList = null;

	public int page = 0;

	public int filecount = 0;

	public int pageNum = 1;

	public CountdownEvent latch = null;

	public int nowpage = 1;

	private WebBrowser _webbrowder;

	public string filePath = "";

	public string fileGroupGuid = "";

	public SortedList<string, List<string>> groupFiles = new SortedList<string, List<string>>();

	public List<string> FilePageList = null;

	private string _result { get; set; }

	private string _path { get; set; }

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
				case "DocumentManagement_AddDocContent":
					AddDocContent(handlerResult);
					break;
				case "DocumentManagement_GetAllContents":
					GetAllContents(handlerResult);
					break;
				case "DocumentManagement_UpdateDocContent":
					UpdateDocContent(handlerResult);
					break;
				case "DocumentManagement_RemoveDocContent":
					RemoveDocContent(handlerResult);
					break;
				case "DocumentManagement_GetDocContentQuery":
					GetDocContentQuery(handlerResult);
					break;
				case "DocumentManagement_GetContentByID":
					GetContentByID(handlerResult);
					break;
				case "DocumentManagement_QueryFileList":
					QueryFileList(handlerResult);
					break;
				case "DocumentManagement_AddSourceDocContent":
					AddSourceDocContent2(handlerResult, context);
					break;
				case "DocumentManagement_GetSourceAllContent":
					GetSourceAllContent(handlerResult);
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

	private void AddDocContent(ResponseData handlerResult)
	{
		DOC_CONTENTSDTO dto = DTOBase.DeserializeFromJson<DOC_CONTENTSDTO>(base.RequestData.Data);
		handlerResult.Data = DocumentService.AddContent(dto).JsonSerialize();
	}

	private void GetAllContents(ResponseData handlerResult)
	{
		handlerResult.Data = DocumentService.GetContentsTree<Guid>().ToJson();
	}

	private void UpdateDocContent(ResponseData handlerResult)
	{
		DOC_CONTENTSDTO codeDTO = DTOBase.DeserializeFromJson<DOC_CONTENTSDTO>(base.RequestData.Data);
		DocumentService.UpdateDocContent(codeDTO);
	}

	private void RemoveDocContent(ResponseData handlerResult)
	{
		DocumentService.RemoveDocContent(base.RequestData.Data);
	}

	private void GetDocContentQuery(ResponseData handlerResult)
	{
		DOC_CONTENTSDTO parameter = base.RequestData.Data.JsonDeserialize<DOC_CONTENTSDTO>(new JsonConverter[0]);
		handlerResult.Data = DocumentService.GetDocContentList(parameter).JsonSerialize();
	}

	private void GetContentByID(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (!string.IsNullOrEmpty(dictionary["CONTENT_ID"]))
		{
			Guid contentId = (string.IsNullOrEmpty(dictionary["CONTENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["CONTENT_ID"]));
			DOC_CONTENTSDTO dto = DocumentService.GetContentByID(contentId);
			handlerResult.Data = dto.ToJson();
		}
	}

	private void QueryFileList(ResponseData handlerResult)
	{
		AttachmentDTO parameter = base.RequestData.Data.JsonDeserialize<AttachmentDTO>(new JsonConverter[0]);
		handlerResult.Data = DocumentService.QueryFileList(parameter).ToJson();
	}

	public static void DeleteDir(string file)
	{
		try
		{
			DirectoryInfo fileInfo = new DirectoryInfo(file);
			fileInfo.Attributes = (FileAttributes)0;
			File.SetAttributes(file, FileAttributes.Normal);
			if (!Directory.Exists(file))
			{
				return;
			}
			string[] fileSystemEntries = Directory.GetFileSystemEntries(file);
			foreach (string f in fileSystemEntries)
			{
				if (File.Exists(f))
				{
					File.Delete(f);
					Console.WriteLine(f);
				}
				else
				{
					DeleteDir(f);
				}
			}
			Directory.Delete(file);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message.ToString());
		}
	}

	private void AddSourceDocContent2(ResponseData handlerResult, HttpContext context)
	{
		string ret = "false";
		string zipFilepath = HttpContext.Current.Server.MapPath("~/upload/download.zip");
		if (File.Exists(zipFilepath))
		{
			string extractPath = HttpContext.Current.Server.MapPath("~/upload/file");
			bool ZipFileTrue = false;
			do
			{
				string strex = "";
				try
				{
					if (!Directory.Exists(extractPath))
					{
						Directory.CreateDirectory(extractPath);
					}
					else
					{
						DeleteDir(extractPath);
						Directory.CreateDirectory(extractPath);
					}
					File.SetAttributes(extractPath, FileAttributes.Normal);
					ZipFile.ExtractToDirectory(zipFilepath, extractPath);
					ZipFileTrue = true;
				}
				catch (Exception)
				{
				}
			}
			while (!ZipFileTrue);
			ReadMenuListAddTable("");
			List<string[]> retTrueTxtList = new List<string[]>();
			List<string[]> retFalseTxtList = new List<string[]>();
			ReadFileListAddTable(retTrueTxtList, retFalseTxtList);
			Guid objId = (string.IsNullOrEmpty("") ? Guid.Empty : Guid.Parse(""));
			AttachmentMappingDTO attachmentmapDTO = new AttachmentMappingDTO();
			attachmentmapDTO.OBJECT_ID = objId;
			IList<AttachmentDTO> AttachmetList = AttachmentService.GetAttachmentBymap(attachmentmapDTO);
			Guid Token = Singleton<SessionManager>.Instance.GetCurrentSessionToken();
			IList<AttachmentMappingDTO> attachmentDTOList = new List<AttachmentMappingDTO>();
			List<Guid> attachmentIDList = new List<Guid>();
			foreach (string[] val in retFalseTxtList)
			{
				attachmentIDList.Add(Guid.Parse(val[0]));
			}
			AttachmentService.RemoveAttachment(attachmentIDList);
			foreach (string[] guidName in retTrueTxtList)
			{
				try
				{
					FileInfo fileInfo = new FileInfo(extractPath + "\\" + guidName[2]);
					string absolutelyPath = string.Empty;
					string fileNetworkPath = string.Empty;
					string fileRelativePath = string.Empty;
					AttachmentDTO attachmentDTO = new AttachmentDTO();
					attachmentDTO.ATTACHMENT_NAME = guidName[1] + ".docx";
					attachmentDTO.ATTACHMENT_TYPE = "docx";
					attachmentDTO.ATTACHMENT_SIZE = fileInfo.Length;
					attachmentDTO.ATTACHMENT_ID = (string.IsNullOrEmpty(guidName[0]) ? Guid.Empty : Guid.Parse(guidName[0]));
					attachmentDTO.OBJECT_ID = (string.IsNullOrEmpty(guidName[3]) ? Guid.Empty : Guid.Parse(guidName[3]));
					attachmentDTO.FILE_NO = guidName[5];
					attachmentDTO.IS_EFFECTIVE = ((!(guidName[4] == "True")) ? 1 : 0);
					attachmentDTO.Token = Token;
					if (string.IsNullOrEmpty(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString()) || ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString() == "1")
					{
						int storageLocation = 1;
						continue;
					}
					AttachmentDTO getattachmentDTO = new AttachmentDTO();
					IList<AttachmentDTO> ilist = AttachmentService.QueryAttachmentByID(attachmentDTO.ATTACHMENT_ID.Value).List;
					if (ilist.Count > 0)
					{
						getattachmentDTO = ilist[0];
						attachmentDTO.ATTACHMENT_TYPE = getattachmentDTO.ATTACHMENT_TYPE;
					}
					else
					{
						getattachmentDTO = attachmentDTO;
					}
					if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}{getattachmentDTO.FILE_RELATIVE_PATH}{getattachmentDTO.ATTACHMENT_ID}"))
					{
						int storageLocation = int.Parse(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString());
						fileNetworkPath = ConfigurationManager.CurrentPackage.Settings["FileNetWorkPath"].ToString();
						fileRelativePath = ConfigurationManager.CurrentPackage.Settings["FileRelativePath"].ToString();
						attachmentDTO.FILE_NETWORK_PATH = fileNetworkPath;
						attachmentDTO.STORAGE_LOCATION = storageLocation;
						attachmentDTO.Catalog = "Attachment\\yyyy-MM-dd";
						int i = FileCacheManager.IsHaveFile(ref attachmentDTO);
						string catalog = attachmentDTO.Catalog;
						char[] myByte = catalog.ToArray();
						if (myByte[0] != '\\')
						{
							catalog = "\\" + catalog;
						}
						if (myByte[^1] != '\\')
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
						absolutelyPath = ((!attachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{attachmentDTO.FILE_NETWORK_PATH}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}");
						FileStream fsr = new FileStream(extractPath + "\\" + guidName[2], FileMode.Open);
						SaveFile(absolutelyPath, StreamToBytes(fsr));
					}
					else
					{
						attachmentDTO.FILE_RELATIVE_PATH = getattachmentDTO.FILE_RELATIVE_PATH;
					}
					Guid guid = Guid.Parse(guidName[0]);
					List<AttachmentMappingDTO> findAttachmentDTO = AttachmentService.GetAttachmentListByAttachment_ID(guid).ToList();
					if (findAttachmentDTO.Count == 0)
					{
						AttachmentService.SaveAttachment(attachmentDTO);
						AttachmentMappingDTO Attmap = new AttachmentMappingDTO();
						Attmap.ATTACHMENT_MAPPING_ID = Guid.NewGuid();
						Attmap.ATTACHMENT_ID = attachmentDTO.ATTACHMENT_ID;
						Attmap.OBJECT_ID = attachmentDTO.OBJECT_ID;
						Attmap.OBJECT_TABLE_NAME = "DOC_FILE";
						Attmap.DOC_TYPE = null;
						attachmentDTOList.Add(Attmap);
					}
					else
					{
						AttachmentService.SaveAttachment(attachmentDTO);
					}
				}
				catch (Exception)
				{
				}
			}
			AttachmentService.SaveAttachmentMapping(attachmentDTOList);
			ret = "true";
		}
		handlerResult.Data = ret.JsonSerialize();
	}

	public void ReadFileListAddTable(List<string[]> retTrueTxtList, List<string[]> retFalseTxtList)
	{
		string FileListPath = HttpContext.Current.Server.MapPath("~/upload/file/FileLocation.txt");
		string FileListTxtFileContent = "";
		if (File.Exists(FileListPath))
		{
			using StreamReader sr = new StreamReader(FileListPath);
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				FileListTxtFileContent += line;
			}
		}
		List<string> list = new List<string>();
		list = Enumerable.ToList(FileListTxtFileContent.Split("#"));
		foreach (string s in list)
		{
			if (s != null || s != "")
			{
				string[] vlaue = s.Split(";");
				retTrueTxtList.Add(vlaue);
				if (vlaue[4] != "True")
				{
					retFalseTxtList.Add(vlaue);
				}
			}
		}
	}

	private void AddSourceDocContent(ResponseData handlerResult)
	{
		getType();
		_directory = HttpContext.Current.Server.MapPath("/") + "Files\\Download";
		foreach (myDataType dt in allTd)
		{
			GetChild(dt, dt.TypeName, dt.TypeID);
		}
		foreach (KeyValuePair<string, List<string>> item in groupFiles)
		{
			string[] PathAndGuid = item.Key.ToString().Split("#");
			foreach (string page in item.Value)
			{
				getEventTable(page, guidNameList, PathAndGuid[0], PathAndGuid[1]);
			}
		}
		string attachmentID = base.RequestData.Data;
		List<Guid> attachmentIDList = new List<Guid>();
		string[] strAttachmentIDS = attachmentID.Split(',');
		List<FileTableData> DelNameList = guidNameList.Where((FileTableData x) => !x.IsDel).ToList();
		foreach (FileTableData val in DelNameList)
		{
			attachmentIDList.Add(Guid.Parse(val.ID));
		}
		AttachmentService.RemoveAttachment(attachmentIDList);
		guidNameList = guidNameList.Where((FileTableData x) => x.IsDel).ToList();
		latch = new CountdownEvent(1);
		ParameterizedThreadStart method = delegate
		{
			batchDownloadFile(guidNameList);
		};
		Thread thread = new Thread(method);
		thread.Start("param" + 1);
		latch.Wait();
		SaveTableFile();
		string ret = "true";
		handlerResult.Data = ret.JsonSerialize();
	}

	private void SaveTableFile()
	{
		Guid objId = (string.IsNullOrEmpty("") ? Guid.Empty : Guid.Parse(""));
		AttachmentMappingDTO attachmentmapDTO = new AttachmentMappingDTO();
		attachmentmapDTO.OBJECT_ID = objId;
		IList<AttachmentDTO> AttachmetList = AttachmentService.GetAttachmentBymap(attachmentmapDTO);
		Guid Token = Singleton<SessionManager>.Instance.GetCurrentSessionToken();
		IList<AttachmentMappingDTO> attachmentDTOList = new List<AttachmentMappingDTO>();
		foreach (FileTableData guidName in guidNameList)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(_directory + "\\" + guidName.locationPath + "x");
				string absolutelyPath = string.Empty;
				string fileNetworkPath = string.Empty;
				string fileRelativePath = string.Empty;
				AttachmentDTO attachmentDTO = new AttachmentDTO();
				attachmentDTO.ATTACHMENT_NAME = GlobalObject.unescape(fileInfo.Name);
				attachmentDTO.ATTACHMENT_SIZE = fileInfo.Length;
				attachmentDTO.ATTACHMENT_ID = (string.IsNullOrEmpty(guidName.ID) ? Guid.Empty : Guid.Parse(guidName.ID));
				attachmentDTO.OBJECT_ID = (string.IsNullOrEmpty(guidName.ParentID) ? Guid.Empty : Guid.Parse(guidName.ParentID));
				attachmentDTO.Token = Token;
				int storageLocation;
				if (string.IsNullOrEmpty(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString()) || ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString() == "1")
				{
					storageLocation = 1;
					continue;
				}
				storageLocation = int.Parse(ConfigurationManager.CurrentPackage.Settings["StorageLocationType"].ToString());
				fileNetworkPath = ConfigurationManager.CurrentPackage.Settings["FileNetWorkPath"].ToString();
				fileRelativePath = ConfigurationManager.CurrentPackage.Settings["FileRelativePath"].ToString();
				attachmentDTO.FILE_NETWORK_PATH = fileNetworkPath;
				attachmentDTO.STORAGE_LOCATION = storageLocation;
				attachmentDTO.Catalog = "Attachment\\yyyy-MM-dd";
				int i = FileCacheManager.IsHaveFile(ref attachmentDTO);
				string catalog = attachmentDTO.Catalog;
				char[] myByte = catalog.ToArray();
				if (myByte[0] != '\\')
				{
					catalog = "\\" + catalog;
				}
				if (myByte[^1] != '\\')
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
				absolutelyPath = ((!attachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{attachmentDTO.FILE_NETWORK_PATH}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}");
				FileStream fsr = new FileStream(_directory + "\\" + guidName.locationPath + "x", FileMode.Open);
				Guid guid = Guid.Parse(guidName.ID);
				List<AttachmentMappingDTO> findAttachmentDTO = AttachmentService.GetAttachmentListByAttachment_ID(guid).ToList();
				if (findAttachmentDTO.Count == 0)
				{
					SaveFile(absolutelyPath, StreamToBytes(fsr));
					AttachmentService.SaveAttachment(attachmentDTO);
					AttachmentMappingDTO Attmap = new AttachmentMappingDTO();
					Attmap.ATTACHMENT_MAPPING_ID = Guid.NewGuid();
					Attmap.ATTACHMENT_ID = attachmentDTO.ATTACHMENT_ID;
					Attmap.OBJECT_ID = attachmentDTO.OBJECT_ID;
					Attmap.OBJECT_TABLE_NAME = "DOC_FILE";
					Attmap.DOC_TYPE = null;
					attachmentDTOList.Add(Attmap);
				}
				fsr.Close();
			}
			catch (Exception)
			{
			}
		}
		AttachmentService.SaveAttachmentMapping(attachmentDTOList);
	}

	private void GetChild(myDataType dt, string path, string OrgID)
	{
		foreach (myDataType ch in dt.children)
		{
			if (ch.children != null && ch.children.Count > 0)
			{
				GetChild(ch, path + "\\" + ch.TypeName, OrgID);
				continue;
			}
			pageNum = 1;
			string groupParentChilden = ch.TypeName;
			filepath = path + "\\" + groupParentChilden + "\\";
			if (!Directory.Exists(_directory + "\\" + filepath))
			{
				Directory.CreateDirectory(_directory + "\\" + filepath);
			}
			PageArrangeGetData(ch, guidNameList, filepath, OrgID);
		}
	}

	private void SaveFile(string filePath, byte[] data)
	{
		FileMode fm = (File.Exists(filePath) ? FileMode.Append : FileMode.OpenOrCreate);
		using FileStream fs = new FileStream(filePath, fm);
		fs.Write(data, 0, data.Length);
	}

	private byte[] StreamToBytes(Stream stream)
	{
		stream.Position = 0L;
		byte[] buffer = new byte[stream.Length];
		for (int totalBytesCopied = 0; totalBytesCopied < stream.Length; totalBytesCopied += stream.Read(buffer, totalBytesCopied, System.Convert.ToInt32(stream.Length) - totalBytesCopied))
		{
		}
		return buffer;
	}

	public void GetSourceAllContent(ResponseData handlerResult)
	{
		string ret = "true";
		try
		{
			ReadMenuListAddTable(base.RequestData.Data);
		}
		catch (Exception)
		{
			ret = "false";
		}
		handlerResult.Data = ret.JsonSerialize();
	}

	private void ReadMenuListAddTable(string data)
	{
		string value = ReadJsonString(data);
		int IndexofA = value.IndexOf("[");
		int IndexofB = value.IndexOf("]");
		List<myDataType> addList = new List<myDataType>();
		value = value.Substring(IndexofA, IndexofB - IndexofA + 1);
		JToken jarry2 = (JToken)JsonConvert.DeserializeObject(value);
		JArray list = (JArray)jarry2;
		foreach (JToken jt in list)
		{
			myDataType dt = new myDataType();
			dt = jt.ToObject<myDataType>();
			if (addList.Where((myDataType x) => x.TypeID == dt.TypeID).ToList().Count <= 0)
			{
				addList.Add(dt);
			}
		}
		IList<DOC_CONTENTSDTO> List = DocumentService.GetSuggestTableByID();
		int i;
		for (i = 0; i < addList.Count; i++)
		{
			DOC_CONTENTSDTO dto = new DOC_CONTENTSDTO();
			dto.CONTENT_ID = Guid.Parse(addList[i].TypeID);
			dto.CONTENT_NAME = addList[i].TypeName;
			dto.PARENT_CONTENT_ID = Guid.Parse(addList[i].ParentID);
			if (List.Where((DOC_CONTENTSDTO x) => x.CONTENT_ID == dto.CONTENT_ID).Count() <= 0)
			{
				List.Add(dto);
				if ((from x in List
					where x.PARENT_CONTENT_ID == Guid.Parse(addList[i].ParentID)
					orderby x.SORT descending
					select x).ToList().Count <= 0)
				{
					dto.SORT = 1m;
				}
				else
				{
					dto.SORT = (from x in List
						where x.PARENT_CONTENT_ID == Guid.Parse(addList[i].ParentID)
						orderby x.SORT descending
						select x).FirstOrDefault().SORT + 1m;
				}
			}
			else
			{
				DOC_CONTENTSDTO olddto = List.Where((DOC_CONTENTSDTO x) => x.CONTENT_ID == dto.CONTENT_ID).FirstOrDefault();
				dto.SORT = olddto.SORT;
				dto.CREATETIME = olddto.CREATETIME;
			}
			DocumentService.AddContent(dto);
		}
	}

	public string ReadJsonString(string data)
	{
		string value = "";
		if (data == "")
		{
			using StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/upload/file/FileGroupData.txt"));
			value = sr.ReadToEnd();
		}
		else
		{
			value = data.ToString();
		}
		return value;
	}

	public Dictionary<string, string> CompanyList()
	{
		Dictionary<string, string> compList = new Dictionary<string, string>();
		compList.Add("4D8DE435-D8AD-465F-B207-A13EDE6BC9F7", "集团公司总部");
		compList.Add("28D3332E-0E5B-472D-A047-E6D8F1A4D60F", "股份公司总部");
		return compList;
	}

	private void getType()
	{
		Dictionary<string, string> Company = CompanyList();
		foreach (KeyValuePair<string, string> company in Company)
		{
			myDataType companydt = new myDataType();
			companydt.TypeID = company.Key.ToLower();
			companydt.TypeName = company.Value;
			List<myDataType> lsit = new List<myDataType>();
			companydt.children = lsit;
			WebRequest request = null;
			request = WebRequest.Create("http://law.petrochina/LawPortal/QueryAndStatistics/CommonQuery/CommonGetLawType.aspx?OrgID=" + company.Key.ToLower() + "&typeId=00000000-0000-0000-0000-000000000000");
			WebResponse response = request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
			string value = reader.ReadToEnd();
			string Data = "";
			Data = GetListJson(value, Data);
			JToken jarry2 = (JToken)JsonConvert.DeserializeObject(Data);
			JArray list = (JArray)jarry2;
			foreach (JToken jt in list)
			{
				myDataType dt = new myDataType();
				dt = jt.ToObject<myDataType>();
				dt.ParentID = company.Key.ToLower();
				dt.ParentName = company.Value;
				companydt.children.Add(dt);
			}
			companydt.Count = companydt.children.Count;
			allTd.Add(companydt);
			getListItemAndAllChildren(allTd, NoChildren, null);
		}
	}

	private string GetListJson(string value, string Data)
	{
		JObject jarry2 = (JObject)JsonConvert.DeserializeObject(value);
		foreach (KeyValuePair<string, JToken> v in jarry2)
		{
			string ss = v.Value.ToString();
			if (!(ss == "[]") && ss != null && !(ss == ""))
			{
				Data = v.Value.ToString();
			}
		}
		return Data;
	}

	private void getListItemAndAllChildren(List<myDataType> allTd, List<myDataType> NoChildren, string ParentName)
	{
		foreach (myDataType dt in allTd)
		{
			string parnt = "6DD90AE5-9D12-4C67-8F36-DDF6325E3BB6";
			myDataType Now = new myDataType();
			Now.TypeID = dt.TypeID;
			Now.TypeName = dt.TypeName;
			Now.TypeLevel = dt.TypeLevel;
			Now.RootID = dt.RootID;
			if (ParentName == null)
			{
				Now.ParentID = parnt.ToLower();
				Now.ParentName = "审计中心";
			}
			else
			{
				Now.ParentID = dt.ParentID;
				Now.ParentName = ParentName;
			}
			Now.OrderID = dt.OrderID;
			NoChildren.Add(Now);
			if (dt.children != null)
			{
				getListItemAndAllChildren(dt.children, NoChildren, dt.TypeName);
			}
		}
	}

	private void PageArrangeGetData(myDataType dt, List<FileTableData> guidNameList, string locationPath, string orgID)
	{
		string url = "http://law.petrochina/LawPortal/QueryAndStatistics/CommonQuery/CommonQuery.aspx?typeId=" + dt.TypeID + "&OrgId=" + orgID;
		GetReult(url, locationPath, dt.TypeID);
	}

	public int getTablePage(string htmlvalue)
	{
		htmlvalue = htmlvalue.Replace("\r\n", "").Replace("\t", "").Replace("&nbsp;", "");
		string Startindex = "<span id=\"sTotlaPageCount\"><font color=\"Red\">";
		string EndIndex = "</font></span>";
		string subStartValue = htmlvalue.Substring(htmlvalue.IndexOf(Startindex), htmlvalue.Length - htmlvalue.IndexOf(Startindex));
		string myPage = subStartValue.Substring(0, subStartValue.IndexOf(EndIndex) + EndIndex.Length).Replace("\r\n", "").Replace("\t", "");
		return System.Convert.ToInt32(myPage.Replace(Startindex, "").Replace(EndIndex, ""));
	}

	public int getFileCount(string htmlvalue)
	{
		htmlvalue = htmlvalue.Replace("\r\n", "").Replace("\t", "").Replace("&nbsp;", "");
		string Startindex = "<span id=\"sTotalRecordCount\"><font color=\"Red\">";
		string EndIndex = "</font></span>";
		string subStartValue = htmlvalue.Substring(htmlvalue.IndexOf(Startindex), htmlvalue.Length - htmlvalue.IndexOf(Startindex));
		string myPage = subStartValue.Substring(0, subStartValue.IndexOf(EndIndex) + EndIndex.Length).Replace("\r\n", "").Replace("\t", "");
		return System.Convert.ToInt32(myPage.Replace(Startindex, "").Replace(EndIndex, ""));
	}

	public void getTable(string htmlvalue, List<FileTableData> guidNameList, string locationPath, string ParentID)
	{
		htmlvalue = htmlvalue.Replace("\r\n", "").Replace("\t", "").Replace("&nbsp;", "");
		string Startindex = "<table class=\"tableview font\" cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"#CCCCCC\" border=\"1\" id=\"dgLaw\" bgcolor=\"White\" width=\"100%\">";
		string EndIndex = "</table>";
		string subStartValue = htmlvalue.Substring(htmlvalue.IndexOf(Startindex), htmlvalue.Length - htmlvalue.IndexOf(Startindex));
		string myTable = subStartValue.Substring(0, subStartValue.IndexOf(EndIndex) + EndIndex.Length).Replace("\r\n", "").Replace("\t", "");
		myTable = myTable.Replace(Startindex, "").Replace(EndIndex, "").Replace("</tr><tr", "</tr>!<tr")
			.Replace("<b></b>", "<b>空</b>")
			.Replace("&nbsp;", "空");
		string myTableofName = myTable.Replace("<td align=\"Center\"><font", "<td align=\"Center\">$<font").Replace("<font color=\"#003399\"><a id=\"dgLaw", "<font color=\"#003399\">T*A<a id=\"dgLaw").Replace("显示规章制度正文", "");
		myTableofName = DelHTML(myTableofName).Replace("已失效", "$已失效");
		string[] strArray = myTableofName.Split(new string[3] { "!", "T*", "$" }, StringSplitOptions.RemoveEmptyEntries);
		List<FileNameAndIsDel> NameList = new List<FileNameAndIsDel>();
		List<string> fileContent = new List<string>();
		string[] array = strArray;
		foreach (string value in array)
		{
			fileContent.Add(value);
		}
		for (int i = 0; i < fileContent.Count; i++)
		{
			FileNameAndIsDel filename = new FileNameAndIsDel();
			if (fileContent[i].Contains("A") && fileContent[i].IndexOf("A") == 0)
			{
				filename.FileName = fileContent[i].Substring(1, fileContent[i].Length - 1);
				filename.IsDel = ((fileContent[i + 1] == "有效") ? true : false);
				filename.locationPath = locationPath + filename.FileName + ".doc";
				NameList.Add(filename);
			}
		}
		Regex guid = new Regex("\\w{8}(-\\w{4}){3}-\\w{12}");
		MatchCollection result = guid.Matches(myTable);
		List<string> GuidList = new List<string>();
		foreach (Match j in result)
		{
			if (!GuidList.Contains(j.ToString()))
			{
				GuidList.Add(j.ToString());
			}
		}
		if (GuidList.Count != NameList.Count)
		{
			return;
		}
		int a = 0;
		foreach (string key in GuidList)
		{
			Func<FileTableData, bool> predicate = (FileTableData d) => d.ID == key;
			if (guidNameList.Where(predicate).ToList().Count() <= 0)
			{
				FileTableData fileTalbe = new FileTableData();
				fileTalbe.ID = key;
				fileTalbe.FileName = NameList[a].FileName;
				fileTalbe.IsDel = NameList[a].IsDel;
				fileTalbe.ParentID = ParentID;
				fileTalbe.locationPath = NameList[a].locationPath;
				guidNameList.Add(fileTalbe);
			}
			a++;
		}
	}

	public void getEventTable(string htmlvalue, List<FileTableData> guidNameList, string locationPath, string ParentID)
	{
		htmlvalue = htmlvalue.Replace("\r\n", "").Replace("\t", "").Replace("&nbsp;", "")
			.ToLower();
		string Startindex = "<TABLE id=dgLaw class=\"tableview font\" style=\"BORDER-TOP: #cccccc 1px; BORDER-RIGHT: #cccccc 1px; WIDTH: 100%; BORDER-COLLAPSE: collapse; BORDER-BOTTOM: #cccccc 1px; BORDER-LEFT: #cccccc 1px; BACKGROUND-COLOR: white\" borderColor=#cccccc cellSpacing=0 cellPadding=3 rules=all border=1><TBODY>";
		string EndIndex = "</TABLE>";
		Startindex = Startindex.ToLower();
		EndIndex = EndIndex.ToLower();
		string subStartValue = htmlvalue.Substring(htmlvalue.IndexOf(Startindex), htmlvalue.Length - htmlvalue.IndexOf(Startindex));
		string myTable = subStartValue.Substring(0, subStartValue.IndexOf(EndIndex) + EndIndex.Length).Replace("\r\n", "").Replace("\t", "");
		myTable = myTable.Replace(Startindex, "").Replace(EndIndex, "").Replace("</tr><tr", "</tr>!<tr")
			.Replace("<b></b>", "<b>空</b>")
			.Replace("&nbsp;", "空");
		string myTableofName = myTable.Replace("<td align=center>", "<td align=center>$").Replace("<td align=left><a onclick", "<td align=left>T*A<a onclick").Replace("显示规章制度正文", "");
		myTableofName = DelHTML(myTableofName).Replace("已失效", "$已失效");
		string[] strArray = myTableofName.Split(new string[3] { "!", "T*", "$" }, StringSplitOptions.RemoveEmptyEntries);
		List<FileNameAndIsDel> NameList = new List<FileNameAndIsDel>();
		List<string> fileContent = new List<string>();
		string[] array = strArray;
		foreach (string value in array)
		{
			fileContent.Add(value);
		}
		for (int i = 0; i < fileContent.Count; i++)
		{
			FileNameAndIsDel filename = new FileNameAndIsDel();
			if (fileContent[i].Contains("A") && fileContent[i].IndexOf("A") == 0)
			{
				filename.FileName = fileContent[i].Substring(1, fileContent[i].Length - 1).Trim();
				filename.IsDel = ((fileContent[i + 1] == "有效") ? true : false);
				filename.locationPath = locationPath + filename.FileName.Trim() + ".doc";
				NameList.Add(filename);
			}
		}
		Regex guid = new Regex("javascript:openlawfile\\(\\'\\w{8}(-\\w{4}){3}-\\w{12}");
		MatchCollection result = guid.Matches(myTable);
		List<string> GuidList = new List<string>();
		foreach (Match j in result)
		{
			if (!GuidList.Contains(j.ToString()))
			{
				GuidList.Add(j.ToString().Replace("javascript:openlawfile('", ""));
			}
		}
		if (GuidList.Count != NameList.Count)
		{
			return;
		}
		int a = 0;
		foreach (string key in GuidList)
		{
			Func<FileTableData, bool> predicate = (FileTableData d) => d.ID == key;
			if (guidNameList.Where(predicate).ToList().Count() <= 0)
			{
				FileTableData fileTalbe = new FileTableData();
				fileTalbe.ID = key;
				fileTalbe.FileName = NameList[a].FileName.Trim();
				fileTalbe.IsDel = NameList[a].IsDel;
				fileTalbe.ParentID = ParentID;
				fileTalbe.locationPath = NameList[a].locationPath;
				guidNameList.Add(fileTalbe);
			}
			a++;
		}
	}

	private void batchDownloadFile(List<FileTableData> guidNameLists)
	{
		DownloadguidErrorList = new SortedList<string, string>();
		int i = 0;
		foreach (FileTableData guidName in guidNameLists)
		{
			try
			{
				if (!File.Exists(_directory + "\\" + guidName.locationPath + "x"))
				{
					if (Download("http://law.petrochina/LawPortal/QueryAndStatistics/CommonQuery/CommonLawFile.aspx?LawID=" + guidName.ID, _directory + "\\" + guidName.locationPath))
					{
						i++;
						continue;
					}
					DownloadguidErrorList.Add(guidName.ID, guidName.FileName);
					i++;
				}
			}
			catch
			{
			}
		}
		latch.Signal();
	}

	private void GetReult(string url, string locationPath, string TypeID)
	{
		_path = url;
		nowpage = 1;
		filePath = locationPath;
		fileGroupGuid = TypeID;
		FilePageList = new List<string>();
		groupFiles.Add(locationPath + "#" + TypeID, FilePageList);
		Thread mThread = new Thread(FatchDataToResult);
		mThread.SetApartmentState(ApartmentState.STA);
		mThread.Start();
		mThread.Join();
		mThread.Abort();
	}

	private void FatchDataToResult()
	{
		try
		{
			_webbrowder = new WebBrowser();
			_webbrowder.Url = new Uri(_path);
			_webbrowder.DocumentCompleted += _webbrowder_DocumentCompleted;
			do
			{
				System.Windows.Forms.Application.DoEvents();
			}
			while (_webbrowder.ReadyState != WebBrowserReadyState.Complete);
			_webbrowder.Dispose();
		}
		catch (Exception)
		{
		}
	}

	private void _webbrowder_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		try
		{
			HtmlDocument doc = (sender as WebBrowser).Document;
			HtmlElement uinList = doc.GetElementById("btnNextPage");
			string _ResponseStr = doc.Body.OuterHtml;
			int num = getPageFileCount(_ResponseStr);
			if (num == 1 || nowpage == num)
			{
				groupFiles[filePath + "#" + fileGroupGuid].Add(_ResponseStr);
				if (nowpage != num)
				{
				}
			}
			else if (num != 0)
			{
				groupFiles[filePath + "#" + fileGroupGuid].Add(_ResponseStr);
				nowpage++;
				(sender as WebBrowser).Navigate("javascript:__doPostBack('btnNextPage','')");
			}
		}
		catch (Exception)
		{
		}
	}

	public int getPageFileCount(string htmlvalue)
	{
		try
		{
			htmlvalue = htmlvalue.Replace("\r\n", "").Replace("\t", "").Replace("&nbsp;", "");
			string Startindex = "总页数<SPAN id=sTotlaPageCount style=\"COLOR: red\">";
			string EndIndex = "</SPAN> <A id=btnPrevPage";
			string disabledEndIndex = "</SPAN> <A disabled id=btnPrevPage>";
			string subStartValue = "";
			string myPage = "";
			int FileCount = 0;
			if (htmlvalue.Contains("<A disabled id=btnPrevPage>"))
			{
				subStartValue = htmlvalue.Substring(htmlvalue.IndexOf(Startindex), htmlvalue.Length - htmlvalue.IndexOf(Startindex));
				myPage = subStartValue.Substring(0, subStartValue.IndexOf(disabledEndIndex) + disabledEndIndex.Length).Replace("\r\n", "").Replace("\t", "");
				FileCount = System.Convert.ToInt32(myPage.Replace(Startindex, "").Replace(disabledEndIndex, ""));
			}
			else
			{
				subStartValue = htmlvalue.Substring(htmlvalue.IndexOf(Startindex), htmlvalue.Length - htmlvalue.IndexOf(Startindex));
				myPage = subStartValue.Substring(0, subStartValue.IndexOf(EndIndex) + EndIndex.Length).Replace("\r\n", "").Replace("\t", "");
				FileCount = System.Convert.ToInt32(myPage.Replace(Startindex, "").Replace(EndIndex, ""));
			}
			return FileCount;
		}
		catch (Exception)
		{
			return nowpage;
		}
	}

	public bool Download(string url, string localfile)
	{
		bool flag = false;
		long startPosition = 0L;
		long remoteFileLength = GetHttpLength(url);
		Console.WriteLine("remoteFileLength=" + remoteFileLength);
		if (remoteFileLength == 745)
		{
			Console.WriteLine("远程文件不存在.");
			return false;
		}
		FileStream writeStream;
		if (File.Exists(localfile))
		{
			writeStream = File.OpenWrite(localfile);
			startPosition = writeStream.Length;
			if (startPosition >= remoteFileLength)
			{
				Console.WriteLine("本地文件长度" + startPosition + "已经大于等于远程文件长度" + remoteFileLength);
				writeStream.Close();
				return false;
			}
			writeStream.Seek(startPosition, SeekOrigin.Current);
		}
		else
		{
			writeStream = new FileStream(localfile, FileMode.Create);
			startPosition = 0L;
		}
		try
		{
			HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
			if (startPosition > 0)
			{
				myRequest.AddRange((int)startPosition);
			}
			Stream readStream = myRequest.GetResponse().GetResponseStream();
			byte[] btArray = new byte[10240];
			int contentSize = readStream.Read(btArray, 0, btArray.Length);
			long currPostion = startPosition;
			while (contentSize > 0)
			{
				currPostion += contentSize;
				int percent = (int)(currPostion * 100 / remoteFileLength);
				writeStream.Write(btArray, 0, contentSize);
				contentSize = readStream.Read(btArray, 0, btArray.Length);
			}
			writeStream.Close();
			readStream.Close();
			LoadWordFileDocToWordTypeDocxForCompatible(localfile, string.Concat((object)localfile, (object)"x"));
			flag = true;
		}
		catch (Exception)
		{
			writeStream.Close();
			LoadWordFileDocToWordTypeDocxForCompatible(localfile, string.Concat((object)localfile, (object)"x"));
			flag = false;
		}
		return flag;
	}

	private static long GetHttpLength(string url)
	{
		long length = 0L;
		try
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
			if (rsp.StatusCode == HttpStatusCode.OK)
			{
				length = rsp.ContentLength;
			}
			rsp.Close();
			return length;
		}
		catch (Exception)
		{
			return length;
		}
	}

	public static string DelHTML(string Htmlstring)
	{
		Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
		Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
		Htmlstring.Replace("\r\n", "");
		return Htmlstring;
	}

	private static void LoadWordFileDocToWordTypeDocxForCompatible(object path, object replacepath)
	{
		Microsoft.Office.Interop.Word.Application wordApp = (Microsoft.Office.Interop.Word.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
		if (File.Exists((string)path))
		{
			object Nothing = System.Reflection.Missing.Value;
			Documents documents = wordApp.Documents;
			object PasswordDocument = System.Reflection.Missing.Value;
			object PasswordTemplate = System.Reflection.Missing.Value;
			object Revert = System.Reflection.Missing.Value;
			object WritePasswordDocument = System.Reflection.Missing.Value;
			object WritePasswordTemplate = System.Reflection.Missing.Value;
			object Format = System.Reflection.Missing.Value;
			object Encoding = System.Reflection.Missing.Value;
			object Visible = System.Reflection.Missing.Value;
			object OpenAndRepair = System.Reflection.Missing.Value;
			object DocumentDirection = System.Reflection.Missing.Value;
			object NoEncodingDialog = System.Reflection.Missing.Value;
			object XMLTransform = System.Reflection.Missing.Value;
			Microsoft.Office.Interop.Word.Document wordDoc = documents.Open(ref path, ref Nothing, ref Nothing, ref Nothing, ref PasswordDocument, ref PasswordTemplate, ref Revert, ref WritePasswordDocument, ref WritePasswordTemplate, ref Format, ref Encoding, ref Visible, ref OpenAndRepair, ref DocumentDirection, ref NoEncodingDialog, ref XMLTransform);
			object format = WdSaveFormat.wdFormatDocumentDefault;
			PasswordDocument = System.Reflection.Missing.Value;
			wordDoc.SaveAs2(ref replacepath, ref format, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref PasswordDocument);
			wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
			wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
			File.Delete((string)path);
		}
	}

	private static string myRequestWebPage(int pageNum, string typeID)
	{
		if (typeID == "")
		{
			typeID = "00000000-0000-0000-0000-000000000000";
		}
		NameValueCollection PostVars = new NameValueCollection();
		PostVars.Add("__EVENTTARGET", "btnNextPage");
		PostVars.Add("drpOrg", "4D8DE435-D8AD-465F-B207-A13EDE6BC9F7");
		PostVars.Add("txtOrgID", "4D8DE435-D8AD-465F-B207-A13EDE6BC9F7");
		PostVars.Add("dropDLSta", "1998");
		PostVars.Add("dropDLEnd", "2019");
		PostVars.Add("drpLevel", "0");
		PostVars.Add("drpState", "-1");
		PostVars.Add("txtTitle", "");
		PostVars.Add("txtTypeName", "");
		PostVars.Add("txtTypeID", "");
		PostVars.Add("txtSearch", "");
		PostVars.Add("txtNavTypeID", typeID);
		PostVars.Add("drpPageIndex", pageNum.ToString());
		PostVars.Add("__EVENTARGUMENT", "100");
		string url = "http://law.petrochina/LawPortal/QueryAndStatistics/CommonQuery/CommonQuery.aspx?typeId=" + typeID + "&OrgId=4D8DE435-D8AD-465F-B207-A13EDE6BC9F7";
		WebClient webClient = new WebClient();
		webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
		byte[] responseData = webClient.UploadValues(url, "POST", PostVars);
		return Encoding.UTF8.GetString(responseData);
	}
}
