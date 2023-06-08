using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Storage;
using Richfit.Garnet.Module.Exporting;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.Domain;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO.Parameters;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.HandlerProcess.Handlers;

public class UserHandler : HandlerBase
{
	/// <summary>
	/// 用户接口实例化
	/// </summary>
	private ISystemUserService userAppService = ServiceLocator.Instance.GetService<ISystemUserService>();

	/// <summary>
	/// ProcessRequest
	/// </summary>
	/// <param name="context">context</param>
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
				case "SystemManagement_AddUser":
					AddUser(handlerResult);
					break;
				case "SystemManagement_UpdateUser":
					UpdateUser(handlerResult);
					break;
				case "SystemManagement_UpdateExtendOne":
					UpdateExtendOne(handlerResult);
					break;
				case "SystemManagement_RemoveUser":
					RemoveUser(handlerResult);
					break;
				case "SystemManagement_QueryUserList":
					QueryUserList(handlerResult);
					break;
				case "SystemManagement_UpdateUserPassword":
					UpdateUserPassWord(handlerResult);
					break;
				case "SystemManagement_QueryOrgRoleTree":
					QueryOrgRoleTree(handlerResult);
					break;
				case "SystemManagement_UserDistributeRoles":
					UserDistributeRoles(handlerResult);
					break;
				case "SystemManagement_QueryDistributableOrgTree":
					QueryDistributableOrgTree(handlerResult);
					break;
				case "SystemManagement_UserDistributeOrg":
					UserDistributeOrg(handlerResult);
					break;
				case "SystemManagement_UserRolesCopy":
					UserRolesCopy(handlerResult);
					break;
				case "SystemManagement_GetDomainList":
					GetDomainList(handlerResult);
					break;
				case "SystemManagement_GetDomainUserName":
					GetDomainUserName(handlerResult);
					break;
				case "SystemManagement_ForbiddenUser":
					ForbiddenUser(handlerResult);
					break;
				case "SystemManagement_EnableUser":
					EnableUser(handlerResult);
					break;
				case "SystemManagement_GetUserByKey":
					GetUserByKey(handlerResult);
					break;
				case "SystemManagement_GetUserByToken":
					GetUserByToken(handlerResult);
					break;
				case "SystemManagement_GetUserForbiddenBusinessIds":
					GetUserForbiddenBusinessIds(handlerResult);
					break;
				case "SystemManagement_ImportUser":
					ImportUser(context, handlerResult);
					break;
				case "SystemManagement_ExportUser":
					ExportUser(handlerResult);
					break;
				case "SystemManagement_GetUserRoleById":
					GetUserRoleById(handlerResult);
					break;
				case "SystemManagement_GetOrgByUser":
					GetOrgByUser(handlerResult);
					break;
				case "SystemManagement_GetUserRoleOrg":
					GetUserRoleOrg(handlerResult);
					break;
				case "SystemManagement_SaveUserRole":
					SaveUserRole(handlerResult);
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

	private void SaveUserRole(ResponseData handlerResult)
	{
		USER_ROLE_PARM userRoleParm = base.RequestData.Data.JsonDeserialize<USER_ROLE_PARM>(new JsonConverter[0]);
		userAppService.SaveUserRole(userRoleParm);
	}

	private void GetUserRoleOrg(ResponseData handlerResult)
	{
		SYS_USER_ROLE user = base.RequestData.Data.JsonDeserialize<SYS_USER_ROLE>(new JsonConverter[0]);
		handlerResult.Data = userAppService.GetUserRoleOrg(user).JsonSerialize();
	}

	private void GetOrgByUser(ResponseData handlerResult)
	{
		SYS_USER user = base.RequestData.Data.JsonDeserialize<SYS_USER>(new JsonConverter[0]);
		handlerResult.Data = userAppService.GetOrgByUser(user).JsonSerialize();
	}

	private void GetUserRoleById(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid userId = Guid.Parse(Dict["USER_ID"]);
		Guid orgId = Guid.Parse(Dict["ORG_ID"]);
		handlerResult.Data = userAppService.GetUserRoleById(userId, orgId).JsonSerialize();
	}

	private void GetUserForbiddenBusinessIds(ResponseData handlerResult)
	{
		Guid userId = Guid.Parse(base.RequestData.Data);
		handlerResult.Data = userAppService.GetUserForbiddenBusinessIds(userId).JsonSerialize();
	}

	private void AddUser(ResponseData handlerResult)
	{
		SYS_USERDTO userDTO = DTOBase.DeserializeFromJson<SYS_USERDTO>(base.RequestData.Data);
		handlerResult.Data = userAppService.AddUser(userDTO).JsonSerialize();
	}

	private void UpdateUser(ResponseData handlerResult)
	{
		SYS_USERDTO userDTO = DTOBase.DeserializeFromJson<SYS_USERDTO>(base.RequestData.Data);
		userAppService.UpdateUser(userDTO);
	}

	private void UpdateExtendOne(ResponseData handlerResult)
	{
		SYS_USERDTO userDTO = DTOBase.DeserializeFromJson<SYS_USERDTO>(base.RequestData.Data);
		userAppService.UpdateExtendOne(userDTO);
	}

	private void RemoveUser(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		userAppService.RemoveUser(Dict["USER_ID"]);
	}

	private void QueryOrgRoleTree(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid userId = (string.IsNullOrEmpty(dictionary["USER_ID"]) ? Guid.Empty : Guid.Parse(dictionary["USER_ID"]));
		handlerResult.Data = userAppService.QueryOrgRoleTree(userId).ToJson();
	}

	private void QueryUserList(ResponseData handlerResult)
	{
		QueryCondition condition = GetQueryCondition(base.RequestData.Data);
		string isPaging = GetParameter("IsPaging");
		if (isPaging.EqualOrdinal("false", ignoreCase: true))
		{
			condition.PagingSetting = null;
		}
		handlerResult.Data = userAppService.QueryUserList(condition).ToJson();
	}

	private void UpdateUserPassWord(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userId = dictionary["USER_ID"];
		string passWord = dictionary["PASSWORD"];
		string newPassWord = dictionary["NEWPASSWORD"];
		userAppService.UpdateUserPassword(Guid.Parse(userId), passWord, newPassWord);
	}

	private void UserDistributeRoles(ResponseData handlerResult)
	{
		SYS_USER_ROLE_SAVE_PARM dictionary = base.RequestData.Data.JsonDeserialize<SYS_USER_ROLE_SAVE_PARM>(new JsonConverter[0]);
		userAppService.UserDistributeRoles(dictionary);
	}

	/// <summary>
	///             查询用户可分派的组织机构树
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void QueryDistributableOrgTree(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid userId = (string.IsNullOrEmpty(dictionary["USER_ID"]) ? Guid.Empty : Guid.Parse(dictionary["USER_ID"]));
		Guid parentId = (string.IsNullOrEmpty(dictionary["PARENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["PARENT_ID"]));
		int level = int.Parse(dictionary["LEVEL"]);
		string isIncludeSelf = dictionary["IS_INCLUDE_SELF"];
		handlerResult.Data = userAppService.QueryDistributableOrgTree(userId, parentId, level, isIncludeSelf.Equals("1")).ToJson();
	}

	private void UserDistributeOrg(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid userId = (string.IsNullOrEmpty(dictionary["USER_ID"]) ? Guid.Empty : Guid.Parse(dictionary["USER_ID"]));
		string orgIds = dictionary["ORG_ID"];
		userAppService.UserDistributeOrg(userId, orgIds);
	}

	private void UserRolesCopy(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid orgId = (string.IsNullOrEmpty(dictionary["ORG_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ORG_ID"]));
		string sourceUserIds = dictionary["SOURCEUSERID"];
		string destinationUserIds = dictionary["OBJECTIVEUSERID"];
		userAppService.UserRolesCopy(sourceUserIds, destinationUserIds, orgId);
	}

	/// <summary>
	/// 获取域列表
	/// </summary>
	/// <param name="responseData"></param>
	public void GetDomainList(ResponseData responseData)
	{
		if (ConfigurationManager.System.Settings.EnableDomain)
		{
			IList<DomainDTO> domainList = DomainManager.GetAllDomain();
			responseData.Data = domainList.ToJson();
		}
	}

	/// <summary>
	/// 获取域用户名称
	/// </summary>
	/// <param name="handlerResult"></param>
	public void GetDomainUserName(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid domainId = (string.IsNullOrEmpty(dictionary["DomainId"]) ? Guid.Empty : Guid.Parse(dictionary["DomainId"]));
		string domainAccount = dictionary["DomainAccount"];
		handlerResult.Type = ResponseDataType.Text;
		handlerResult.Data = userAppService.GetDomainUserName(domainId, domainAccount);
	}

	private void ForbiddenUser(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		userAppService.ForbiddenUser(Dict["USER_ID"]);
	}

	private void EnableUser(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		userAppService.EnableUserUser(Dict["USER_ID"]);
	}

	private void GetUserByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid userId = (string.IsNullOrEmpty(Dict["USER_ID"]) ? Guid.Empty : Guid.Parse(Dict["USER_ID"]));
		handlerResult.Data = userAppService.GetUserById(userId).ToJson();
	}

	private void GetUserByToken(ResponseData handlerResult)
	{
		handlerResult.Data = userAppService.GetUserByToken().ToJson();
	}

	private void ImportUser(HttpContext context, ResponseData handlerResult)
	{
		context.Response.ClearHeaders();
		context.Response.ContentType = "text/plain";
		Stream inputStream = null;
		string fileName = string.Empty;
		Stream errorStream = null;
		try
		{
			inputStream = context.Request.Files[0].InputStream;
			fileName = Path.GetFileName(context.Request.Files[0].FileName);
			errorStream = userAppService.ImportUser(inputStream);
			if (errorStream != null)
			{
				handlerResult.Code = "Public.E_0001";
				handlerResult.Data = FileHandler.SaveErrorFile(errorStream, fileName);
			}
			else
			{
				handlerResult.Code = "Public.I_0001";
			}
		}
		catch (Exception ex)
		{
			handlerResult.Code = "ImportTemplate_Error";
			handlerResult.Data = ex.Message;
		}
		finally
		{
			inputStream?.Close();
			errorStream?.Close();
		}
	}

	private void ExportUser(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string queryCondition = (string.IsNullOrEmpty(Dict["QueryCondition"]) ? string.Empty : Dict["QueryCondition"]);
		string dataGridColumn = (string.IsNullOrEmpty(Dict["DataGridColumn"]) ? string.Empty : Dict["DataGridColumn"]);
		string excelName = (string.IsNullOrEmpty(Dict["ExcelName"]) ? "ExcelName" : Dict["ExcelName"]);
		IList<SYS_USERDTO> resultList = new List<SYS_USERDTO>();
		QueryCondition condition = GetQueryCondition(queryCondition);
		resultList = userAppService.QueryUserList(condition).List;
		try
		{
			using Stream stream = ExportManager.Default.ExportCommonExcel(dataGridColumn, resultList.ToList(), excelName);
			AttachmentHepler.DownloadStream(stream, "用户信息表.xls", "application/vnd.ms-excel");
		}
		catch (Exception ex)
		{
			throw new CustomCodeException("Fundation.Public.V_0003", ex);
		}
	}
}
