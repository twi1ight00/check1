using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgManagement;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

namespace Richfit.Garnet.Module.SystemManagement.HandlerProcess.Handlers;

public class OrgHandler : HandlerBase
{
	/// <summary>
	/// Service locator
	/// </summary>
	private IOrgAppService orgAppService = ServiceLocator.Instance.GetService<IOrgAppService>();

	private IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();

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
				case "SystemManagement_GetOrgTree":
					GetOrgTree(handlerResult);
					break;
				case "SystemManagement_GetOrgAndUserTree":
					GetOrgAndUserTree(handlerResult);
					break;
				case "SystemManagement_GetOrgAndAllowUserManyToOrgTree":
					GetOrgAndAllowUserManyToOrgTree(handlerResult);
					break;
				case "SystemManagement_GetOrgList":
					GetOrgList(handlerResult);
					break;
				case "SystemManagement_AddOrg":
					AddOrg(handlerResult);
					break;
				case "SystemManagement_UpdateOrg":
					UpdateOrg(handlerResult);
					break;
				case "SystemManagement_RemoveOrg":
					RemoveOrg(handlerResult);
					break;
				case "SystemManagement_Synchronize":
					Synchronize(handlerResult);
					break;
				case "SystemManagement_GetOrgByKey":
					GetOrgByKey(handlerResult);
					break;
				case "SystemManagement_GetOrgLevel":
					GetOrgLevel(handlerResult);
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

	/// <summary>
	/// 获取组织机构及人员树信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void GetOrgAndUserTree(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid parentId = (string.IsNullOrEmpty(dictionary["PARENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["PARENT_ID"]));
		int level = int.Parse(dictionary["LEVEL"]);
		string isIncludeSelf = dictionary["IS_INCLUDE_SELF"];
		handlerResult.Data = orgUserService.GetOrgUserTree(parentId, level, isFindUser: true, isAllowUserManyToOrg: false, isIncludeSelf.Equals("1"), null).ToJson();
	}

	/// <summary>
	/// 获取组织机构树信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void GetOrgTree(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid parentId = (string.IsNullOrEmpty(dictionary["PARENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["PARENT_ID"]));
		int level = int.Parse(dictionary["LEVEL"]);
		string isIncludeSelf = dictionary["IS_INCLUDE_SELF"];
		handlerResult.Data = orgUserService.GetOrgUserTree<Guid>(parentId, level, isFindUser: false, isAllowUserManyToOrg: false, isIncludeSelf.Equals("1"), null).ToJson();
	}

	/// <summary>
	/// 获取组织机构及人员树信息
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void GetOrgAndAllowUserManyToOrgTree(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid parentId = (string.IsNullOrEmpty(dictionary["PARENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["PARENT_ID"]));
		int level = int.Parse(dictionary["LEVEL"]);
		string isIncludeSelf = dictionary["IS_INCLUDE_SELF"];
		handlerResult.Data = (from x in orgUserService.GetOrgUserTree(parentId, level, isFindUser: true, isAllowUserManyToOrg: true, isIncludeSelf.Equals("1"), null)
			where x.TYPE == "1"
			orderby x.TYPE descending, x.SORT
			select x).ToList().ToJson();
	}

	/// <summary>
	/// 获取组织机构列表
	/// </summary>
	/// <param name="handlerResult">handlerResult</param>
	private void GetOrgList(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid parentId = (string.IsNullOrEmpty(dictionary["PARENT_ID"]) ? Guid.Empty : Guid.Parse(dictionary["PARENT_ID"]));
		int level = int.Parse(dictionary["LEVEL"]);
		string isIncludeSelf = dictionary["IS_INCLUDE_SELF"];
		handlerResult.Data = orgUserService.GetOrgUserTreeList(parentId, level, isFindUser: false, isAllowUserManyToOrg: false, isIncludeSelf.Equals("1")).ToJson();
	}

	private void AddOrg(ResponseData handlerResult)
	{
		SYS_ORGDTO orgDTO = DTOBase.DeserializeFromJson<SYS_ORGDTO>(base.RequestData.Data);
		orgDTO.ORG_ID = Guid.NewGuid();
		orgDTO.ISDEL = 0m;
		DateTime cREATETIME = (orgDTO.MODIFYTIME = DateTime.Now);
		orgDTO.CREATETIME = cREATETIME;
		Guid cREATOR = (orgDTO.MODIFIER = SessionContext.UserInfo.UserID);
		orgDTO.CREATOR = cREATOR;
		handlerResult.Data = orgAppService.AddOrg(orgDTO).ToJson();
	}

	private void UpdateOrg(ResponseData handlerResult)
	{
		SYS_ORGDTO orgDTO = DTOBase.DeserializeFromJson<SYS_ORGDTO>(base.RequestData.Data);
		orgAppService.UpdateOrg(orgDTO);
	}

	private void RemoveOrg(ResponseData handlerResult)
	{
		orgAppService.RemoveOrg(base.RequestData.Data);
	}

	private void Synchronize(ResponseData handlerResult)
	{
		orgAppService.Synchronize(base.RequestData.Data);
	}

	private void GetOrgByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid orgId = (string.IsNullOrEmpty(Dict["ORG_ID"]) ? Guid.Empty : Guid.Parse(Dict["ORG_ID"]));
		handlerResult.Data = OrgUserCacheManager.GetOrgByKey(orgId).ToJson();
	}

	private void GetOrgLevel(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid orgId = (string.IsNullOrEmpty(Dict["ORG_ID"]) ? Guid.Empty : Guid.Parse(Dict["ORG_ID"]));
		handlerResult.Data = OrgUserCacheManager.GetOrgLevel(orgId).ToString();
	}
}
