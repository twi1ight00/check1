using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Authorization.Application.DTO;
using Richfit.Garnet.Module.Authorization.Application.Services;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;

namespace Richfit.Garnet.Module.Authorization.HandlerProcess.Handlers;

public class AuthorizeHandler : HandlerBase
{
	private IAuthorizationService AuthorizationService = ServiceLocator.Instance.GetService<IAuthorizationService>();

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
				case "Authorization_EditInfo":
					EditAuthInfo(handlerResult);
					break;
				case "Authorization_GetAuthorizationByauthID":
					GetAuthorizationByauthID(handlerResult);
					break;
				case "Authorization_GetAuthorizationPersonList":
					GetAuthorizationPersonList(handlerResult);
					break;
				case "Authorization_GetBusinessList":
					GetBusinessList(handlerResult);
					break;
				case "Authorization_GetBusinessListByAuthID":
					GetBusinessListByAuthID(handlerResult);
					break;
				case "Authorization_GetList_ByKey":
					GetAuthorizationListByUserID(handlerResult);
					break;
				case "Authorization_GetRoleByAuthID":
					GetRoleByAuthID(handlerResult);
					break;
				case "Authorization_GetRoleByUserID":
					GetRoleByUserID(handlerResult);
					break;
				case "Authorization_QueryUserList":
					QueryUserList(handlerResult);
					break;
				case "Authorization_RemoveRecord":
					RemoveRecord(handlerResult);
					break;
				case "Authorization_SaveBusinessInfo":
					SaveBusinessInfo(handlerResult);
					break;
				case "Authorization_SaveUserList":
					SaveUserList(handlerResult);
					break;
				case "Authorization_GetAuthorizationSpecialList":
					GetAuthorizationSpecialList(handlerResult);
					break;
				case "Authorization_GetAuthorizationList":
					GetAuthorizationList(handlerResult);
					break;
				case "Authorization_SaveAuthorization":
					SaveAuthorization(handlerResult);
					break;
				case "Authorization_GetAuthorizationRole":
					GetAuthorizationRole(handlerResult);
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

	private void GetAuthorizationRole(ResponseData handlerResult)
	{
		SYS_AUTHORIZATIONDTO dict = base.RequestData.Data.JsonDeserialize<SYS_AUTHORIZATIONDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetAuthorizationRole(dict).JsonSerialize();
	}

	private void GetAuthorizationList(ResponseData handlerResult)
	{
		SYS_AUTHORIZATIONDTO dict = base.RequestData.Data.JsonDeserialize<SYS_AUTHORIZATIONDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetAuthorizationByauthID(dict).JsonSerialize();
	}

	private void SaveAuthorization(ResponseData handlerResult)
	{
		SYS_AUTHORIZATIONDTO dict = base.RequestData.Data.JsonDeserialize<SYS_AUTHORIZATIONDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.SaveAuthorization(dict).JsonSerialize();
	}

	private void GetAuthorizationByauthID(ResponseData handlerResult)
	{
		Dictionary<string, Guid> dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetAuthorizationByauthID(dict["SYS_AUTHORIZATION_ID"]).ToJson();
	}

	private void EditAuthInfo(ResponseData handlerResult)
	{
		Dictionary<string, string> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		AuthorizationService.EditAuthInfo(dataParams);
	}

	private void GetBusinessListByAuthID(ResponseData handlerResult)
	{
		AUTHORIZATION_BUSINESSDTO dictionary = base.RequestData.Data.JsonDeserialize<AUTHORIZATION_BUSINESSDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetBusinessListByAuthID(dictionary).ToJson();
	}

	private void GetRoleByAuthID(ResponseData handlerResult)
	{
		AUTHORIZATION_BUSINESSDTO dictionary = base.RequestData.Data.JsonDeserialize<AUTHORIZATION_BUSINESSDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetRoleByAuthID(dictionary).ToJson();
	}

	private void RemoveRecord(ResponseData handlerResult)
	{
		Dictionary<string, string> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid authorizationID = Guid.Parse(dataParams["SYS_AUTHORIZATION_ID"]);
		AuthorizationService.RemoveRecord(authorizationID);
	}

	private void GetAuthorizationListByUserID(ResponseData handlerResult)
	{
		SYS_AUTHORIZATIONDTO dictionary = base.RequestData.Data.JsonDeserialize<SYS_AUTHORIZATIONDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetAuthorizationListByUserID(dictionary).ToJson();
	}

	private void SaveUserList(ResponseData handlerResult)
	{
		AUTHORIZATION_SPECIAL_USERDTO rotateDTO = DTOBase.DeserializeFromJson<AUTHORIZATION_SPECIAL_USERDTO>(base.RequestData.Data);
		handlerResult.Data = AuthorizationService.SaveUserList(rotateDTO.SYS_AUTHORIZATION_SPECIAL, rotateDTO.USER_ID).ToJson();
	}

	private void QueryUserList(ResponseData handlerResult)
	{
		AUTHORIZATION_USERLISTDTO dictionary = base.RequestData.Data.JsonDeserialize<AUTHORIZATION_USERLISTDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.QueryUserList(dictionary).ToJson();
	}

	private void SaveBusinessInfo(ResponseData handlerResult)
	{
		SYS_AUTHORIZATIONDTO rotateDTO = DTOBase.DeserializeFromJson<SYS_AUTHORIZATIONDTO>(base.RequestData.Data);
		handlerResult.Data = AuthorizationService.SaveBusinessInfo(rotateDTO).ToJson();
	}

	private void GetBusinessList(ResponseData handlerResult)
	{
		AUTHORIZATION_BUSINESSDTO dictionary = base.RequestData.Data.JsonDeserialize<AUTHORIZATION_BUSINESSDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetBusinessList(dictionary).ToJson();
	}

	private void GetAuthorizationPersonList(ResponseData handlerResult)
	{
		SYS_AUTHORIZATION_PERSONDTO dictionary = base.RequestData.Data.JsonDeserialize<SYS_AUTHORIZATION_PERSONDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetAuthorizationPersonList(dictionary).ToJson();
	}

	private void GetRoleByUserID(ResponseData handlerResult)
	{
		AUTHORIZATION_ROLEDTO dictionary = base.RequestData.Data.JsonDeserialize<AUTHORIZATION_ROLEDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetRoleByUserID(dictionary).ToJson();
	}

	private void GetAuthorizationSpecialList(ResponseData handlerResult)
	{
		SYS_AUTHORIZATION_SPECIALDTO dictionary = base.RequestData.Data.JsonDeserialize<SYS_AUTHORIZATION_SPECIALDTO>(new JsonConverter[0]);
		handlerResult.Data = AuthorizationService.GetAuthorizationSpecialList(dictionary).ToJson();
	}
}
