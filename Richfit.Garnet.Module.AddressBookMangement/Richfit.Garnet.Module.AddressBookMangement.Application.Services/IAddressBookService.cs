using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.AddressBookMangement.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.Services;

public interface IAddressBookService
{
	AB_CONTACTDTO AddContact(AB_CONTACTDTO contactDTO);

	void UpdateContact(AB_CONTACTDTO contactDTO);

	void RemoveContact(string contactIds);

	AB_CONTACTDTO GetContactByKey(Guid contactId);

	QueryResult<AB_CONTACTDTO> QueryContactList(AB_CONTACTDTO queryCondition);

	QueryResult<AB_CONTACTDTO> SeniorQueryContactList(AB_CONTACTDTO queryCondition);

	AB_CONTACTDTO AddVirtualContact(AB_CONTACTDTO contactDTO);

	void RemoveVirtualContact(string contactIds);

	QueryResult<AB_CONTACTDTO> QueryVirtualContactList(AB_CONTACTDTO queryCondition);

	QueryResult<AB_CONTACTDTO> QuerySeniorVirtualContactList(AB_CONTACTDTO queryCondition);

	AB_CONTACTDTO AddGroupContact(AB_CONTACTDTO contactDTO);

	void RemoveGroupContact(string contactIds);

	QueryResult<AB_CONTACTDTO> QueryGroupContactList(AB_CONTACTDTO queryCondition);

	QueryResult<AB_CONTACTDTO> QuerySeniorGroupContactList(AB_CONTACTDTO queryCondition);

	AB_PERSONAL_GROUPDTO AddPersonalGroup(AB_PERSONAL_GROUPDTO personalGroupDTO);

	void UpdatePersonalGroup(AB_PERSONAL_GROUPDTO personalGroupDTO);

	void RemovePersonalGroup(string personalGroupIds);

	AB_PERSONAL_GROUPDTO GetPersonalGroupByKey(Guid personalGroupId);

	QueryResult<AB_PERSONAL_GROUPDTO> QueryPersonalGroupList(QueryCondition queryCondition);

	AB_VIRTUAL_ORGDTO AddVirtualOrg(AB_VIRTUAL_ORGDTO orgDTO);

	void UpdateVirtualOrg(AB_VIRTUAL_ORGDTO orgDTO);

	void RemoveVirtualOrg(string orgDTOId);

	AB_VIRTUAL_ORGDTO GetVirtualOrgById(Guid orgId);

	IList<AB_VIRTUAL_ORGDTO> GetVirtualOrgList();

	IList<AB_CATEGORYDTO> GetCategoryList();

	IList<HR_EMPLOYEEDTO> GetContactEmployeeList();

	void MoveContactToGroup(Guid groupId, string contractIDs);

	IList<AB_CONTACTDTO> ExportContactList(AB_CONTACTDTO contactDTO);

	IList<AB_CONTACTDTO> ExportGroupContactList(AB_CONTACTDTO contactDTO);

	void AdjustContactOrg(string userIds, Guid orgId);

	AB_CONTACTDTO GetContactByUserId(Guid userID);

	AB_CONTACTDTO UpdateContactWay(AB_CONTACTDTO contactDTO);

	QueryResult<SYS_ORGDTO> GetOrgList(string ORG_ID);

	QueryResult<AB_CONTACT_MOBILEDTO> GetEmployeeListByOrgID(string ORG_ID, string searchValue);

	QueryResult<AB_CONTACT_MOBILEDTO> GetEmployeeListByUnameOrPno(string searchValue);
}
