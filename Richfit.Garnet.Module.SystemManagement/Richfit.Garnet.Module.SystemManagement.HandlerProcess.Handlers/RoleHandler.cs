using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO.QueryParameters;
using Richfit.Garnet.Module.SystemManagement.Application.Services.RoleManagement;

namespace Richfit.Garnet.Module.SystemManagement.HandlerProcess.Handlers;

public class RoleHandler : HandlerBase
{
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
				case "SystemManagement_AddRole":
					AddRole(handlerResult);
					break;
				case "SystemManagement_UpdateRole":
					UpdateRole(handlerResult);
					break;
				case "SystemManagement_RemoveRole":
					RemoveRole(handlerResult);
					break;
				case "SystemManagement_GetRoleByKey":
					GetRoleByKey(handlerResult);
					break;
				case "SystemManagement_QueryRoleList":
					QueryRoleListBySql(handlerResult);
					break;
				case "SystemManagement_QueryRoleListByParameter":
					QueryRoleListBySql(handlerResult);
					break;
				case "SystemManagement_PrivilegeDistribute":
					PrivilegeDistribute(handlerResult);
					break;
				case "SystemManagement_QueryRolePivilege":
					QueryRolePivilege(handlerResult);
					break;
				case "SystemManagement_QueryDistributableOrgUserTree":
					QueryDistributableOrgUserTree(handlerResult);
					break;
				case "SystemManagement_RoleDistributeUser":
					RoleDistributeUser(handlerResult);
					break;
				case "SystemManagement_QueryDistributableSubOrgTree":
					QueryDistributableSubOrgTree(handlerResult);
					break;
				case "SystemManagement_RoleDistributeSubOrg":
					RoleDistributeSubOrg(handlerResult);
					break;
				case "SystemManagement_GetWorkflowParticipantOrg":
					GetWorkflowParticipantOrg(handlerResult);
					break;
				case "SystemManagement_GetWorkflowParticipant":
					GetWorkflowParticipant(handlerResult);
					break;
				case "SystemManagement_QueryBusinessTreeByRole":
					QueryBusinessTreeByRole(handlerResult);
					break;
				case "SystemManagement_QueryDistributeRolePivilege":
					QueryDistributeRolePivilege(handlerResult);
					break;
				case "SystemManagement_BatchRoleDistributeUser":
					BatchRoleDistributeUser(handlerResult);
					break;
				case "SystemManagement_GetWorkflowRoleByUser":
					GetWorkflowRoleByUser(handlerResult);
					break;
				case "SystemManagement_GetRoleByUser":
					GetRoleByUser(handlerResult);
					break;
				case "SystemManagement_GetUserListByRoleId":
					GetUserListByRoleId(handlerResult);
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

	private void GetUserListByRoleId(ResponseData handlerResult)
	{
		Guid roleId = Guid.Parse(base.RequestData.Data);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.GetUserListByRoleId(roleId).ToJson();
	}

	private void GetRoleByUser(ResponseData handlerResult)
	{
		Dictionary<string, Guid> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.GetRoleByUser(dataParams["USER_ID"]).ToJson();
	}

	private void GetWorkflowRoleByUser(ResponseData handlerResult)
	{
		Dictionary<string, Guid> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.GetWorkflowRoleByUser(dataParams["USER_ID"]).ToJson();
	}

	/// <summary>
	/// 根据角色ID获取角色信息
	/// </summary>
	/// <param name="handlerResult"></param>
	private void GetRoleByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		Guid roleID = Guid.Parse(dataParams["ROLE_ID"]);
		handlerResult.Data = roleAppService.GetRoleByKey(roleID).ToJson();
	}

	/// <summary>
	/// 根据角色ID查询角色对应的业务树
	/// </summary>
	/// <param name="handlerResult"></param>
	private void QueryBusinessTreeByRole(ResponseData handlerResult)
	{
		Guid roleId = Guid.Parse(base.RequestData.Data);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.QueryBusinessTreeByRole(roleId).JsonSerialize();
	}

	private void QueryDistributeRolePivilege(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid roleId = (string.IsNullOrEmpty(dictionary["ROLE_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ROLE_ID"]));
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.QueryDistributeRolePivilege(roleId).ToJson();
	}

	/// <summary>
	/// 获取用户可以发起流程的机构范围
	/// </summary>
	/// <param name="handlerResult"></param>
	private void GetWorkflowParticipantOrg(ResponseData handlerResult)
	{
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.GetWorkflowParticipantOrg(GetQueryCondition(base.RequestData.Data)).JsonSerialize();
	}

	/// <summary>
	/// 获取流程节点的参与人
	/// </summary>
	/// <param name="handlerResult"></param>
	private void GetWorkflowParticipant(ResponseData handlerResult)
	{
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.GetWorkflowParticipant(GetQueryCondition(base.RequestData.Data)).JsonSerialize();
	}

	/// <summary>
	/// 新增角色信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void AddRole(ResponseData handlerResult)
	{
		SYS_ROLEDTO roleDTO = DTOBase.DeserializeFromJson<SYS_ROLEDTO>(base.RequestData.Data);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		roleDTO = roleAppService.AddRole(roleDTO);
	}

	/// <summary>
	/// 批量逻辑删除码表信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void RemoveRole(ResponseData handlerResult)
	{
		Dictionary<string, string> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string roleOrgIds = ((!RoleServiceFactory.IsOrgCreateRole()) ? dataParams["ROLE_ID"] : dataParams["ROLE_ORG_ID"]);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		roleAppService.RemoveRole(roleOrgIds);
	}

	/// <summary>
	/// 更新角色信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void UpdateRole(ResponseData handlerResult)
	{
		SYS_ROLEDTO roleDTO = DTOBase.DeserializeFromJson<SYS_ROLEDTO>(base.RequestData.Data);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		roleAppService.UpdateRole(roleDTO);
	}

	/// <summary>
	/// 查询角色信息_通过SqlKey
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void QueryRoleListBySql(ResponseData handlerResult)
	{
		QueryCondition condition = GetQueryCondition(base.RequestData.Data);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.QueryRoleList(condition).ToJson();
	}

	/// <summary>
	/// 根据查询参数对象查询角色列表
	/// </summary>
	/// <param name="handlerResult"></param>
	private void QueryRoleListByParameter(ResponseData handlerResult)
	{
		if (string.IsNullOrEmpty(base.RequestData.Data))
		{
			return;
		}
		RoleQueryParameter parameter = base.RequestData.Data.JsonDeserialize<RoleQueryParameter>(new JsonConverter[0]);
		if (!parameter.IsNull())
		{
			QueryCondition queryCondition = parameter.ToQueryCondition();
			if (!RoleServiceFactory.IsOrgCreateRole())
			{
				queryCondition.RemoveByKey("ORG_ID");
			}
			IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
			handlerResult.Data = roleAppService.QueryRoleList(queryCondition).ToJson();
		}
	}

	/// <summary>
	/// 查看角色拥有的权限
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void QueryRolePivilege(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid roleId = (string.IsNullOrEmpty(dictionary["ROLE_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ROLE_ID"]));
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.QueryRolePivilege(roleId).ToJson();
	}

	private void PrivilegeDistribute(ResponseData handlerResult)
	{
		Dictionary<string, string> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (string.IsNullOrEmpty(dataParams["ROLE_ID"]))
		{
			return;
		}
		Guid roleID = Guid.Parse(dataParams["ROLE_ID"]);
		string bussinessIdsStr = dataParams["BUSSINESSID"];
		List<Guid> bussinessIDs = new List<Guid>();
		string[] strbussinessIDs = bussinessIdsStr.Split(',');
		string[] array = strbussinessIDs;
		foreach (string strbussinessID in array)
		{
			if (!string.IsNullOrEmpty(strbussinessID))
			{
				bussinessIDs.Add(Guid.Parse(strbussinessID));
			}
		}
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		roleAppService.PrivilegeDistribute(roleID, bussinessIDs);
	}

	private void RoleDistributeUser(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid roleId = (string.IsNullOrEmpty(dictionary["ROLE_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ROLE_ID"]));
		Guid orgId = (string.IsNullOrEmpty(dictionary["USING_ORG_ID"]) ? Guid.Empty : Guid.Parse(dictionary["USING_ORG_ID"]));
		string userOrgIds = dictionary["USER_ORG_ID"];
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		roleAppService.RoleDistributeUser(roleId, orgId, userOrgIds);
	}

	private void BatchRoleDistributeUser(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string roleIds = (string.IsNullOrEmpty(dictionary["ROLE_ID"]) ? string.Empty : dictionary["ROLE_ID"]);
		string userOrgIds = (string.IsNullOrEmpty(dictionary["USER_ORG_ID"]) ? string.Empty : dictionary["USER_ORG_ID"]);
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		roleAppService.BatchRoleDistributeUser(roleIds, userOrgIds);
	}

	private void RoleDistributeSubOrg(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid roleId = (string.IsNullOrEmpty(dictionary["ROLE_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ROLE_ID"]));
		Guid sourceOrgId = (string.IsNullOrEmpty(dictionary["SOURCE_ORG_ID"]) ? Guid.Empty : Guid.Parse(dictionary["SOURCE_ORG_ID"]));
		Guid usingOrgId = (string.IsNullOrEmpty(dictionary["USING_ORG_ID"]) ? Guid.Empty : Guid.Parse(dictionary["USING_ORG_ID"]));
		string orgIds = dictionary["ORG_ID"];
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		roleAppService.RoleDistributeSubOrg(roleId, orgIds, sourceOrgId, usingOrgId);
	}

	/// <summary>
	/// 角色分配人员时，查询可分配的用户树
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void QueryDistributableOrgUserTree(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid roleId = (string.IsNullOrEmpty(dictionary["ROLE_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ROLE_ID"]));
		Guid parentId = (string.IsNullOrEmpty(dictionary["PARENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["PARENT_ID"]));
		int level = int.Parse(dictionary["LEVEL"]);
		string isIncludeSelf = dictionary["IS_INCLUDE_SELF"];
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.QuerySubOrgAndUserTree(roleId, parentId, level, isIncludeSelf.Equals("1")).ToJson();
	}

	/// <summary>
	///             查询角色可分配的机构树
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void QueryDistributableSubOrgTree(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid roleId = (string.IsNullOrEmpty(dictionary["ROLE_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ROLE_ID"]));
		Guid parentId = (string.IsNullOrEmpty(dictionary["PARENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["PARENT_ID"]));
		int level = int.Parse(dictionary["LEVEL"]);
		string isIncludeSelf = dictionary["IS_INCLUDE_SELF"];
		IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
		handlerResult.Data = roleAppService.QueryDistributableSubOrgTree(roleId, parentId, level, isIncludeSelf.Equals("1")).ToJson();
	}
}
