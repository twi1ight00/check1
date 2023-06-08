using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.AddressBookMangement.Application.DTO;
using Richfit.Garnet.Module.AddressBookMangement.Application.Services;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.AddressBookMangement.HandlerProcess.Handlers;

public class AddressBookHandler : HandlerBase
{
	private IAddressBookService addressBookService = ServiceLocator.Instance.GetService<IAddressBookService>();

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
				case "AddressBook_AddContact":
					AddContact(handlerResult);
					break;
				case "AddressBook_UpdateContact":
					UpdateContact(handlerResult);
					break;
				case "AddressBook_RemoveContact":
					RemoveContact(handlerResult);
					break;
				case "AddressBook_GetContactByKey":
					GetContactByKey(handlerResult);
					break;
				case "AddressBook_QueryContactList":
					QueryContactList(handlerResult);
					break;
				case "AddressBook_SeniorQueryContactList":
					SeniorQueryContactList(handlerResult);
					break;
				case "AddressBook_AddPersonalGroup":
					AddPersonalGroup(handlerResult);
					break;
				case "AddressBook_UpdatePersonalGroup":
					UpdatePersonalGroup(handlerResult);
					break;
				case "AddressBook_RemovePersonalGroup":
					RemovePersonalGroup(handlerResult);
					break;
				case "AddressBook_GetPersonalGroupByKey":
					GetPersonalGroupByKey(handlerResult);
					break;
				case "AddressBook_QueryPersonalGroupList":
					QueryPersonalGroupList(handlerResult);
					break;
				case "AddressBook_AddVirtualContact":
					AddVirtualContact(handlerResult);
					break;
				case "AddressBook_UpdateVirtualContact":
					UpdateVirtualContact(handlerResult);
					break;
				case "AddressBook_RemoveVirtualContact":
					RemoveVirtualContact(handlerResult);
					break;
				case "AddressBook_GetVirtualContactByKey":
					GetContactByKey(handlerResult);
					break;
				case "AddressBook_QueryVirtualContactList":
					QueryVirtualContactList(handlerResult);
					break;
				case "AddressBook_QuerySeniorVirtualContactList":
					QuerySeniorVirtualContactList(handlerResult);
					break;
				case "AddressBook_GetVirtualOrgList":
					GetVirtualOrgList(handlerResult);
					break;
				case "AddressBook_AddGroupContact":
					AddGroupContact(handlerResult);
					break;
				case "AddressBook_UpdateGroupContact":
					UpdateGroupContact(handlerResult);
					break;
				case "AddressBook_RemoveGroupContact":
					RemoveGroupContact(handlerResult);
					break;
				case "AddressBook_GetGroupContactByKey":
					GetContactByKey(handlerResult);
					break;
				case "AddressBook_QueryGroupContactList":
					QueryGroupContactList(handlerResult);
					break;
				case "AddressBook_QuerySeniorGroupContactList":
					QuerySeniorGroupContactList(handlerResult);
					break;
				case "AddressBook_GetEmployeeList":
					GetEmployeeList(handlerResult);
					break;
				case "AddressBook_GetCategoryList":
					GetCategoryList(handlerResult);
					break;
				case "AddressBook_MoveContactToGroup":
					MoveContactToGroup(handlerResult);
					break;
				case "AddressBook_ExportContactList":
					ExportContactList(handlerResult);
					break;
				case "AddressBook_ExportGroupContactList":
					ExportGroupContactList(handlerResult);
					break;
				case "AddressBook_AdjustContactOrg":
					AdjustContactOrg(handlerResult);
					break;
				case "AddressBook_GetContactByUserId":
					GetContactByUserId(handlerResult);
					break;
				case "AddressBook_UpdateContactWay":
					UpdateContactWay(handlerResult);
					break;
				case "MobileFunction_GetOrgList":
					GetOrgList(handlerResult);
					break;
				case "MobileFunction_GetEmployeeListByOrgID":
					GetEmployeeListByOrgID(handlerResult);
					break;
				case "MobileFunction_GetEmployeeListByUnameOrPno":
					GetEmployeeListByUnameOrPno(handlerResult);
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

	private void GetOrgList(ResponseData handlerResult)
	{
		Dictionary<string, string> dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string orgid = "";
		if (dict.ContainsKey("ORG_ID") && !string.IsNullOrEmpty(dict["ORG_ID"]))
		{
			orgid = dict["ORG_ID"];
		}
		handlerResult.Data = addressBookService.GetOrgList(orgid).ToJson();
		handlerResult.Type = ResponseDataType.Json;
	}

	private void GetEmployeeListByOrgID(ResponseData handlerResult)
	{
		Dictionary<string, string> dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string searchValue = "";
		if (dict.ContainsKey("searchValue") && !string.IsNullOrEmpty(dict["searchValue"]))
		{
			searchValue = dict["searchValue"];
		}
		if (dict.ContainsKey("ORG_ID"))
		{
			if (!string.IsNullOrEmpty(dict["ORG_ID"]))
			{
				handlerResult.Data = addressBookService.GetEmployeeListByOrgID(dict["ORG_ID"], searchValue).ToJson();
			}
			else
			{
				handlerResult.Data = "{\"Result\":\"参数[ORG_ID]不能为空\"}";
			}
		}
		else
		{
			handlerResult.Data = "{\"Result\":\"传入的参数[ORG_ID]格式不对,必须GUID格式\"}";
		}
		handlerResult.Type = ResponseDataType.Json;
	}

	private void GetEmployeeListByUnameOrPno(ResponseData handlerResult)
	{
		Dictionary<string, string> dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (dict.ContainsKey("searchValue"))
		{
			handlerResult.Data = addressBookService.GetEmployeeListByUnameOrPno(dict["searchValue"]).ToJson();
		}
		else
		{
			handlerResult.Data = "{\"Result\":\"未找到传入的参数[searchValue]\"}";
		}
		handlerResult.Type = ResponseDataType.Json;
	}

	private void UpdateContactWay(ResponseData handlerResult)
	{
		AB_CONTACTDTO ContactDTO = DTOBase.DeserializeFromJson<AB_CONTACTDTO>(base.RequestData.Data);
		handlerResult.Data = addressBookService.UpdateContactWay(ContactDTO).JsonSerialize();
	}

	private void GetContactByUserId(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid userID = (string.IsNullOrEmpty(dictionary["USER_ID"]) ? Guid.Empty : Guid.Parse(dictionary["USER_ID"]));
		handlerResult.Data = addressBookService.GetContactByUserId(userID).JsonSerialize();
	}

	private void AdjustContactOrg(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid orgId = (string.IsNullOrEmpty(dictionary["ORG_ID"]) ? Guid.Empty : Guid.Parse(dictionary["ORG_ID"]));
		string userIds = dictionary["USER_ID"];
		addressBookService.AdjustContactOrg(userIds, orgId);
	}

	private void ExportGroupContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.ExportGroupContactList(condition).ToJson();
	}

	private void ExportContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.ExportContactList(condition).ToJson();
	}

	private void GetEmployeeList(ResponseData handlerResult)
	{
		handlerResult.Data = addressBookService.GetContactEmployeeList().ToJson();
	}

	private void MoveContactToGroup(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid groupId = (string.IsNullOrEmpty(Dict["GROUP_ID"]) ? Guid.Empty : Guid.Parse(Dict["GROUP_ID"]));
		addressBookService.MoveContactToGroup(groupId, Dict["CONTACT_ID"]);
	}

	private void GetCategoryList(ResponseData handlerResult)
	{
		handlerResult.Data = addressBookService.GetCategoryList().ToJson();
	}

	private void GetVirtualOrgList(ResponseData handlerResult)
	{
		handlerResult.Data = addressBookService.GetVirtualOrgList().ToJson();
	}

	private void QueryVirtualContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.QueryVirtualContactList(condition).ToJson();
	}

	private void QuerySeniorVirtualContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.QuerySeniorVirtualContactList(condition).ToJson();
	}

	private void RemoveVirtualContact(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		addressBookService.RemoveVirtualContact(Dict["CONTACT_ID"]);
	}

	private void UpdateVirtualContact(ResponseData handlerResult)
	{
		AB_CONTACTDTO ContactDTO = DTOBase.DeserializeFromJson<AB_CONTACTDTO>(base.RequestData.Data);
		addressBookService.UpdateContact(ContactDTO);
	}

	private void AddVirtualContact(ResponseData handlerResult)
	{
		AB_CONTACTDTO contactDTO = DTOBase.DeserializeFromJson<AB_CONTACTDTO>(base.RequestData.Data);
		contactDTO = addressBookService.AddVirtualContact(contactDTO);
	}

	private void QueryPersonalGroupList(ResponseData handlerResult)
	{
		QueryCondition condition = GetQueryCondition(base.RequestData.Data);
		handlerResult.Data = addressBookService.QueryPersonalGroupList(condition).ToJson();
	}

	private void GetPersonalGroupByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid groupId = (string.IsNullOrEmpty(Dict["GROUP_ID"]) ? Guid.Empty : Guid.Parse(Dict["GROUP_ID"]));
		handlerResult.Data = addressBookService.GetPersonalGroupByKey(groupId).ToJson();
	}

	private void RemovePersonalGroup(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		addressBookService.RemovePersonalGroup(Dict["GROUP_ID"]);
	}

	private void UpdatePersonalGroup(ResponseData handlerResult)
	{
		AB_PERSONAL_GROUPDTO personalGroupDTO = DTOBase.DeserializeFromJson<AB_PERSONAL_GROUPDTO>(base.RequestData.Data);
		addressBookService.UpdatePersonalGroup(personalGroupDTO);
	}

	private void AddPersonalGroup(ResponseData handlerResult)
	{
		AB_PERSONAL_GROUPDTO personalGroupDTO = DTOBase.DeserializeFromJson<AB_PERSONAL_GROUPDTO>(base.RequestData.Data);
		personalGroupDTO = addressBookService.AddPersonalGroup(personalGroupDTO);
	}

	private void QueryContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.QueryContactList(condition).ToJson();
	}

	private void SeniorQueryContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.SeniorQueryContactList(condition).ToJson();
	}

	private void GetContactByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid contactId = (string.IsNullOrEmpty(Dict["CONTACT_ID"]) ? Guid.Empty : Guid.Parse(Dict["CONTACT_ID"]));
		handlerResult.Data = addressBookService.GetContactByKey(contactId).ToJson();
	}

	private void RemoveContact(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		addressBookService.RemoveContact(Dict["CONTACT_ID"]);
	}

	private void UpdateContact(ResponseData handlerResult)
	{
		AB_CONTACTDTO ContactDTO = DTOBase.DeserializeFromJson<AB_CONTACTDTO>(base.RequestData.Data);
		addressBookService.UpdateContact(ContactDTO);
	}

	private void AddContact(ResponseData handlerResult)
	{
		AB_CONTACTDTO ContactDTO = DTOBase.DeserializeFromJson<AB_CONTACTDTO>(base.RequestData.Data);
		ContactDTO = addressBookService.AddContact(ContactDTO);
	}

	private void QueryGroupContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.QueryGroupContactList(condition).ToJson();
	}

	private void QuerySeniorGroupContactList(ResponseData handlerResult)
	{
		AB_CONTACTDTO condition = base.RequestData.Data.JsonDeserialize<AB_CONTACTDTO>(new JsonConverter[0]);
		handlerResult.Data = addressBookService.QuerySeniorGroupContactList(condition).ToJson();
	}

	private void RemoveGroupContact(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		addressBookService.RemoveGroupContact(Dict["CONTACT_ID"]);
	}

	private void UpdateGroupContact(ResponseData handlerResult)
	{
		AB_CONTACTDTO ContactDTO = DTOBase.DeserializeFromJson<AB_CONTACTDTO>(base.RequestData.Data);
		addressBookService.UpdateContact(ContactDTO);
	}

	private void AddGroupContact(ResponseData handlerResult)
	{
		AB_CONTACTDTO contactDTO = DTOBase.DeserializeFromJson<AB_CONTACTDTO>(base.RequestData.Data);
		contactDTO = addressBookService.AddGroupContact(contactDTO);
	}
}
