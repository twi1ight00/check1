using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.AddressBookMangement.Application.DTO;
using Richfit.Garnet.Module.AddressBookMangement.Domain.Models;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.ITManagement.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.Services;

public class AddressBookService : ServiceBase, IAddressBookService
{
	private readonly IRepository<SYS_ORG> sysOrgRepository;

	private readonly IRepository<AB_VIRTUAL_ORG> abVirtualOrgRepository;

	private readonly IRepository<AB_VIRTUAL_CONTACT> abVirtualContactRepository;

	private readonly IRepository<AB_PERSONAL_GROUP> abPersonalGroupRepository;

	private readonly IRepository<AB_ORG_CONTACT> abOrgContactRepository;

	private readonly IRepository<AB_GROUP_CONTACT> abGroupContactRepository;

	private readonly IRepository<AB_CONTACT> abContactRepository;

	private readonly IRepository<AB_CATEGORY> abCategoryRepository;

	private readonly IRepository<HR_EMPLOYEE> hrEmployeeRepository;

	public AddressBookService(IRepository<AB_CATEGORY> abCategoryRepository, IRepository<AB_CONTACT> abContactRepository, IRepository<AB_GROUP_CONTACT> abGroupContactRepository, IRepository<AB_ORG_CONTACT> abOrgContactRepository, IRepository<AB_PERSONAL_GROUP> abPersonalGroupRepository, IRepository<AB_VIRTUAL_CONTACT> abVirtualContactRepository, IRepository<AB_VIRTUAL_ORG> abVirtualOrgRepository, IRepository<SYS_ORG> sysOrgRepository, IRepository<HR_EMPLOYEE> hrEmployeeRepository)
	{
		this.abCategoryRepository = abCategoryRepository;
		this.abContactRepository = abContactRepository;
		this.abGroupContactRepository = abGroupContactRepository;
		this.abOrgContactRepository = abOrgContactRepository;
		this.abPersonalGroupRepository = abPersonalGroupRepository;
		this.abVirtualContactRepository = abVirtualContactRepository;
		this.abVirtualOrgRepository = abVirtualOrgRepository;
		this.sysOrgRepository = sysOrgRepository;
		this.hrEmployeeRepository = hrEmployeeRepository;
	}

	public IList<AB_CATEGORYDTO> GetCategoryList()
	{
		return SqlQuery<AB_CATEGORYDTO>("GetCategoryList", new { });
	}

	public IList<HR_EMPLOYEEDTO> GetContactEmployeeList()
	{
		List<HR_EMPLOYEEDTO> employeeList = new List<HR_EMPLOYEEDTO>();
		IList<HR_EMPLOYEE> hrList = new List<HR_EMPLOYEE>();
		hrList = hrEmployeeRepository.FindAll((HR_EMPLOYEE t) => t.ISDEL == (decimal?)0m && t.CONTACT_ID == Guid.Empty);
		if (hrList.Count > 0)
		{
			hrList.ToList().ForEach(delegate(HR_EMPLOYEE employee)
			{
				HR_EMPLOYEEDTO hR_EMPLOYEEDTO = employee.AdaptAsDTO<HR_EMPLOYEEDTO>();
				hR_EMPLOYEEDTO.ORG_NAME = employee.SYS_ORG.ORG_NAME;
				hR_EMPLOYEEDTO.SYS_ORG = null;
				hR_EMPLOYEEDTO.AB_CONTACT = null;
				employeeList.Add(hR_EMPLOYEEDTO);
			});
		}
		return employeeList;
	}

	public AB_CONTACTDTO AddContact(AB_CONTACTDTO contactDTO)
	{
		if (contactDTO.IsValid())
		{
			AB_CONTACT contactPOCO = contactDTO.AdaptAsEntity<AB_CONTACT>();
			if (contactDTO.ORG_ID.HasValue)
			{
				AB_ORG_CONTACT orgContactPOCO = new AB_ORG_CONTACT();
				orgContactPOCO.ORG_ID = contactDTO.ORG_ID.Value;
				contactPOCO.AB_ORG_CONTACT.Add(orgContactPOCO);
			}
			abContactRepository.AddCommit(contactPOCO);
			HR_EMPLOYEE employee = hrEmployeeRepository.GetByKey(contactDTO.EMPLOYEE_ID);
			if (employee != null)
			{
				employee.CONTACT_ID = contactPOCO.CONTACT_ID;
				employee.EMPLOYEE_NAME = contactDTO.CONTACT_NAME;
				employee.SEX = contactDTO.SEX;
				employee.BIRTHDAY = contactDTO.BIRTHDAY;
				employee.MOBILE = contactDTO.MOBILE;
				employee.MAIL = contactDTO.MAIL;
				employee.WORK_TEL = contactDTO.WORK_TEL;
				employee.SORT = contactDTO.SORT;
				hrEmployeeRepository.UpdateCommit(employee);
			}
			contactDTO = contactPOCO.AdaptAsDTO<AB_CONTACTDTO>();
			return contactDTO;
		}
		throw new ValidationException(contactDTO.GetInvalidMessages());
	}

	public void UpdateContact(AB_CONTACTDTO contactDTO)
	{
		if (contactDTO != null && contactDTO.CONTACT_ID != Guid.Empty)
		{
			if (!contactDTO.IsValid())
			{
				return;
			}
			AB_CONTACT persisted = abContactRepository.GetByKey(contactDTO.CONTACT_ID);
			if (persisted != null)
			{
				persisted.CONTACT_NAME = contactDTO.CONTACT_NAME;
				persisted.MOBILE = contactDTO.MOBILE;
				persisted.MAIL = contactDTO.MAIL;
				persisted.POST = contactDTO.POST;
				persisted.UNIT_NAME = contactDTO.UNIT_NAME;
				persisted.UNIT_ADDRESS = contactDTO.UNIT_ADDRESS;
				persisted.UNIT_POSTCODE = contactDTO.UNIT_POSTCODE;
				persisted.WORK_TEL = contactDTO.WORK_TEL;
				persisted.WORK_FAX = contactDTO.WORK_FAX;
				persisted.HOME_TEL = contactDTO.HOME_TEL;
				persisted.HOME_ADDRESS = contactDTO.HOME_ADDRESS;
				persisted.HOME_POSTCODE = contactDTO.HOME_POSTCODE;
				persisted.SEX = contactDTO.SEX;
				persisted.BIRTHDAY = contactDTO.BIRTHDAY;
				persisted.QQ = contactDTO.QQ;
				persisted.MSN = contactDTO.MSN;
				persisted.MATE = contactDTO.MATE;
				persisted.CHILD = contactDTO.CHILD;
				persisted.NOTE = contactDTO.NOTE;
				persisted.SORT = contactDTO.SORT;
				persisted.ROOM_NUMBER = contactDTO.ROOM_NUMBER;
				persisted.IMAGE_PATH = contactDTO.IMAGE_PATH;
				if (contactDTO.CATEGORY_TYPE == 1)
				{
					if (contactDTO.ORG_ID.HasValue && contactDTO.ORG_ID != persisted.AB_ORG_CONTACT.First().ORG_ID)
					{
						persisted.AB_ORG_CONTACT.First().ORG_ID = contactDTO.ORG_ID.Value;
					}
				}
				else if (contactDTO.CATEGORY_TYPE == 2)
				{
					if (contactDTO.VIRTUAL_ORG_ID.HasValue && contactDTO.VIRTUAL_ORG_ID != persisted.AB_VIRTUAL_CONTACT.First().ORG_ID)
					{
						persisted.AB_VIRTUAL_CONTACT.First().ORG_ID = contactDTO.VIRTUAL_ORG_ID.Value;
					}
				}
				else if (contactDTO.GROUP_ID.HasValue && contactDTO.GROUP_ID != persisted.AB_GROUP_CONTACT.First().GROUP_ID)
				{
					persisted.AB_GROUP_CONTACT.First().GROUP_ID = contactDTO.GROUP_ID.Value;
				}
				if (contactDTO.CATEGORY_TYPE == 1)
				{
					HR_EMPLOYEE employee = hrEmployeeRepository.GetByKey(contactDTO.EMPLOYEE_ID);
					if (employee != null)
					{
						employee.CONTACT_ID = contactDTO.CONTACT_ID;
						employee.EMPLOYEE_NAME = contactDTO.CONTACT_NAME;
						employee.SEX = contactDTO.SEX;
						employee.BIRTHDAY = contactDTO.BIRTHDAY;
						employee.MOBILE = contactDTO.MOBILE;
						employee.MAIL = contactDTO.MAIL;
						employee.WORK_TEL = contactDTO.WORK_TEL;
						employee.SORT = contactDTO.SORT;
						hrEmployeeRepository.UpdateCommit(employee);
					}
				}
				abContactRepository.UpdateCommit(persisted);
				return;
			}
			throw new ValidationException("SystemManagement.Public.V_0004");
		}
		throw new ValidationException(contactDTO.GetInvalidMessages());
	}

	public void RemoveContact(string contactIds)
	{
		string[] contactIdArray = contactIds.Split(',');
		if (contactIdArray == null || !contactIdArray.Any())
		{
			return;
		}
		contactIdArray.ToList().ForEach(delegate(string cId)
		{
			AB_CONTACT contactPOCO = abContactRepository.GetByKey(Guid.Parse(cId));
			if (contactPOCO != null)
			{
				HR_EMPLOYEE hR_EMPLOYEE = hrEmployeeRepository.Find((HR_EMPLOYEE a) => a.CONTACT_ID == contactPOCO.CONTACT_ID);
				if (hR_EMPLOYEE != null)
				{
					hR_EMPLOYEE.CONTACT_ID = Guid.Empty;
					hrEmployeeRepository.UpdateCommit(hR_EMPLOYEE);
				}
				contactPOCO.ISDEL = 1m;
				abContactRepository.Update(contactPOCO);
				abContactRepository.RemoveChild(contactPOCO.AB_ORG_CONTACT);
			}
		});
		abContactRepository.DbContext.Commit();
	}

	public AB_CONTACTDTO GetContactByKey(Guid contactId)
	{
		AB_CONTACT contactPOCO = abContactRepository.GetByKey(contactId);
		AB_CONTACTDTO contactDTO = contactPOCO.AdaptAsDTO<AB_CONTACTDTO>();
		if (contactPOCO.AB_GROUP_CONTACT.Count == 1)
		{
			contactDTO.GROUP_ID = contactPOCO.AB_GROUP_CONTACT.First().GROUP_ID;
			contactDTO.ORG_NAME = contactPOCO.UNIT_NAME;
		}
		if (contactPOCO.AB_ORG_CONTACT.Count == 1)
		{
			contactDTO.ORG_ID = contactPOCO.AB_ORG_CONTACT.First().ORG_ID;
			contactDTO.ORG_NAME = contactPOCO.AB_ORG_CONTACT.First().SYS_ORG.ORG_NAME;
		}
		if (contactPOCO.AB_VIRTUAL_CONTACT.Count == 1)
		{
			contactDTO.ORG_ID = contactPOCO.AB_VIRTUAL_CONTACT.First().ORG_ID;
			contactDTO.ORG_NAME = contactPOCO.AB_VIRTUAL_CONTACT.First().AB_VIRTUAL_ORG.ORG_NAME;
		}
		contactDTO.AB_GROUP_CONTACT = null;
		contactDTO.AB_ORG_CONTACT = null;
		contactDTO.AB_VIRTUAL_CONTACT = null;
		return contactDTO;
	}

	public QueryResult<AB_CONTACTDTO> QueryContactList(AB_CONTACTDTO queryCondition)
	{
		return SqlQueryPager<AB_CONTACTDTO>("QueryContactList", queryCondition);
	}

	public IList<AB_CONTACTDTO> ExportContactList(AB_CONTACTDTO contactDTO)
	{
		string strSql = "SeniorQueryContactList";
		if (contactDTO.SearchType == 1)
		{
			strSql = "QueryContactList";
		}
		IList<AB_CONTACTDTO> contactList = SqlQuery<AB_CONTACTDTO>(strSql, contactDTO);
		IOrderedEnumerable<AB_CONTACTDTO> result = from contact in contactList
			orderby contact.ORG_SORT, contact.SORT
			select contact;
		return result.ToList();
	}

	public QueryResult<AB_CONTACTDTO> SeniorQueryContactList(AB_CONTACTDTO queryCondition)
	{
		return SqlQueryPager<AB_CONTACTDTO>("SeniorQueryContactList", queryCondition);
	}

	public AB_PERSONAL_GROUPDTO AddPersonalGroup(AB_PERSONAL_GROUPDTO personalGroupDTO)
	{
		if (personalGroupDTO.IsValid())
		{
			AB_PERSONAL_GROUP rolePOCO = personalGroupDTO.AdaptAsEntity<AB_PERSONAL_GROUP>();
			abPersonalGroupRepository.AddCommit(rolePOCO);
			personalGroupDTO = rolePOCO.AdaptAsDTO<AB_PERSONAL_GROUPDTO>();
			return personalGroupDTO;
		}
		throw new ValidationException(personalGroupDTO.GetInvalidMessages());
	}

	public void UpdatePersonalGroup(AB_PERSONAL_GROUPDTO personalGroupDTO)
	{
		if (personalGroupDTO.IsValid())
		{
			AB_PERSONAL_GROUP personalGroupPOCO = abPersonalGroupRepository.GetByKey(personalGroupDTO.GROUP_ID);
			personalGroupPOCO.GROUP_NAME = personalGroupDTO.GROUP_NAME;
			personalGroupPOCO.SORT = personalGroupDTO.SORT;
			abPersonalGroupRepository.UpdateCommit(personalGroupPOCO);
			return;
		}
		throw new ValidationException(personalGroupDTO.GetInvalidMessages());
	}

	public void RemovePersonalGroup(string personalGroupIds)
	{
		string[] groupIdArray = personalGroupIds.Split(',');
		string[] array = groupIdArray;
		foreach (string groupId in array)
		{
			AB_PERSONAL_GROUP groupPOCO = abPersonalGroupRepository.GetByKey(Guid.Parse(groupId));
			if (groupPOCO != null)
			{
				groupPOCO.ISDEL = 1m;
				if (groupPOCO.AB_GROUP_CONTACT.Count > 0)
				{
					groupPOCO.AB_GROUP_CONTACT.First().GROUP_ID = null;
					abPersonalGroupRepository.UpdateCommit(groupPOCO);
				}
			}
		}
		abPersonalGroupRepository.DbContext.Commit();
	}

	public AB_PERSONAL_GROUPDTO GetPersonalGroupByKey(Guid personalGroupId)
	{
		return GetDTOById<AB_PERSONAL_GROUPDTO, AB_PERSONAL_GROUP>(personalGroupId, abPersonalGroupRepository);
	}

	public QueryResult<AB_PERSONAL_GROUPDTO> QueryPersonalGroupList(QueryCondition queryCondition)
	{
		return SqlQueryResult<AB_PERSONAL_GROUPDTO>("QueryPersonalGroupList", queryCondition);
	}

	public AB_CONTACTDTO AddVirtualContact(AB_CONTACTDTO contactDTO)
	{
		if (contactDTO.IsValid())
		{
			AB_CONTACT contactPOCO = contactDTO.AdaptAsEntity<AB_CONTACT>();
			if (contactDTO.VIRTUAL_ORG_ID.HasValue)
			{
				AB_VIRTUAL_CONTACT virtualContactPOCO = new AB_VIRTUAL_CONTACT();
				virtualContactPOCO.ORG_ID = contactDTO.VIRTUAL_ORG_ID.Value;
				contactPOCO.AB_VIRTUAL_CONTACT.Add(virtualContactPOCO);
			}
			abContactRepository.AddCommit(contactPOCO);
			contactDTO = contactPOCO.AdaptAsDTO<AB_CONTACTDTO>();
			return contactDTO;
		}
		throw new ValidationException(contactDTO.GetInvalidMessages());
	}

	public void RemoveVirtualContact(string contactIds)
	{
		string[] contactIdArray = contactIds.Split(',');
		string[] array = contactIdArray;
		foreach (string contactId in array)
		{
			AB_CONTACT contactPOCO = abContactRepository.GetByKey(Guid.Parse(contactId));
			if (contactPOCO != null)
			{
				contactPOCO.ISDEL = 1m;
				abContactRepository.Update(contactPOCO);
				abContactRepository.RemoveChild(contactPOCO.AB_VIRTUAL_CONTACT);
			}
		}
		abContactRepository.DbContext.Commit();
	}

	public QueryResult<AB_CONTACTDTO> QueryVirtualContactList(AB_CONTACTDTO queryCondition)
	{
		return SqlQueryPager<AB_CONTACTDTO>("QueryVirtualContactList", queryCondition);
	}

	public QueryResult<AB_CONTACTDTO> QuerySeniorVirtualContactList(AB_CONTACTDTO queryCondition)
	{
		return SqlQueryPager<AB_CONTACTDTO>("QuerySeniorVirtualContactList", queryCondition);
	}

	public AB_VIRTUAL_ORGDTO AddVirtualOrg(AB_VIRTUAL_ORGDTO orgDTO)
	{
		if (orgDTO != null)
		{
			if (!orgDTO.IsValid())
			{
				throw new ValidationException(orgDTO.GetInvalidMessages());
			}
			AB_VIRTUAL_ORG orgPOCO = orgDTO.AdaptAsEntity<AB_VIRTUAL_ORG>();
			abVirtualOrgRepository.AddCommit(orgPOCO);
			abVirtualOrgRepository.Reload(orgPOCO);
			string orgName = orgDTO.PARENT_ORG_NAME;
			orgDTO = orgPOCO.AdaptAsDTO<AB_VIRTUAL_ORGDTO>();
			orgDTO.PARENT_ORG_NAME = orgName;
		}
		return orgDTO;
	}

	public void UpdateVirtualOrg(AB_VIRTUAL_ORGDTO orgDTO)
	{
		if (orgDTO != null && orgDTO.ORG_ID != Guid.Empty)
		{
			if (orgDTO.IsValid())
			{
				AB_VIRTUAL_ORG persisted = abVirtualOrgRepository.GetByKey(orgDTO.ORG_ID);
				if (persisted == null)
				{
					throw new ValidationException("SystemManagement.Public.V_0004");
				}
				persisted.ORG_NAME = orgDTO.ORG_NAME;
				persisted.SORT = orgDTO.SORT;
				persisted.NOTE = orgDTO.NOTE;
				persisted.PARENT_ORG_ID = orgDTO.PARENT_ORG_ID;
				abVirtualOrgRepository.UpdateCommit(persisted);
			}
			return;
		}
		throw new ValidationException(orgDTO.GetInvalidMessages());
	}

	public void RemoveVirtualOrg(string orgIds)
	{
		string[] orgIdArray = orgIds.Split(',');
		string[] array = orgIdArray;
		foreach (string orgId in array)
		{
			AB_VIRTUAL_ORG orgPOCO = abVirtualOrgRepository.GetByKey(Guid.Parse(orgId));
			if (orgPOCO != null)
			{
				orgPOCO.ISDEL = 1m;
				abVirtualOrgRepository.Update(orgPOCO);
			}
		}
		abVirtualOrgRepository.DbContext.Commit();
	}

	public AB_VIRTUAL_ORGDTO GetVirtualOrgById(Guid orgId)
	{
		return GetDTOById<AB_VIRTUAL_ORGDTO, AB_VIRTUAL_ORG>(orgId, abVirtualOrgRepository);
	}

	public IList<AB_VIRTUAL_ORGDTO> GetVirtualOrgList()
	{
		QueryResult<AB_VIRTUAL_ORGDTO> orgQueryResult = SqlQueryPager<AB_VIRTUAL_ORGDTO>("GetOrgList", null);
		return orgQueryResult.List;
	}

	public AB_CONTACTDTO AddGroupContact(AB_CONTACTDTO contactDTO)
	{
		if (contactDTO.IsValid())
		{
			AB_CONTACT contactPOCO = contactDTO.AdaptAsEntity<AB_CONTACT>();
			if (contactDTO.USER_ID.HasValue)
			{
				AB_GROUP_CONTACT groupContactPOCO = new AB_GROUP_CONTACT();
				if (contactDTO.GROUP_ID.HasValue)
				{
					groupContactPOCO.GROUP_ID = contactDTO.GROUP_ID.Value;
				}
				groupContactPOCO.USER_ID = contactDTO.USER_ID.Value;
				contactPOCO.AB_GROUP_CONTACT.Add(groupContactPOCO);
			}
			abContactRepository.AddCommit(contactPOCO);
			contactDTO = contactPOCO.AdaptAsDTO<AB_CONTACTDTO>();
			return contactDTO;
		}
		throw new ValidationException(contactDTO.GetInvalidMessages());
	}

	public void RemoveGroupContact(string contactIds)
	{
		string[] contactIdArray = contactIds.Split(',');
		if (contactIdArray == null || !contactIdArray.Any())
		{
			return;
		}
		contactIdArray.ToList().ForEach(delegate(string cId)
		{
			AB_CONTACT byKey = abContactRepository.GetByKey(Guid.Parse(cId));
			if (byKey != null)
			{
				byKey.ISDEL = 1m;
				abContactRepository.Update(byKey);
				abContactRepository.RemoveChild(byKey.AB_GROUP_CONTACT);
			}
		});
		abContactRepository.DbContext.Commit();
	}

	public QueryResult<AB_CONTACTDTO> QueryGroupContactList(AB_CONTACTDTO queryCondition)
	{
		if (queryCondition.DefaultGroup == "1")
		{
			return SqlQueryPager<AB_CONTACTDTO>("QueryDefaultGroupContactList", queryCondition);
		}
		return SqlQueryPager<AB_CONTACTDTO>("QueryGroupContactList", queryCondition);
	}

	public QueryResult<AB_CONTACTDTO> QuerySeniorGroupContactList(AB_CONTACTDTO queryCondition)
	{
		if (queryCondition.DefaultGroup == "1")
		{
			return SqlQueryPager<AB_CONTACTDTO>("QuerySeniorDefaultGroupContactList", queryCondition);
		}
		return SqlQueryPager<AB_CONTACTDTO>("QuerySeniorGroupContactList", queryCondition);
	}

	public IList<AB_CONTACTDTO> ExportGroupContactList(AB_CONTACTDTO contactDTO)
	{
		string strSql = "QuerySeniorGroupContactList";
		if (contactDTO.SearchType == 1)
		{
			strSql = "QueryGroupContactList";
		}
		IList<AB_CONTACTDTO> contactList = SqlQuery<AB_CONTACTDTO>(strSql, contactDTO);
		IOrderedEnumerable<AB_CONTACTDTO> result = contactList.OrderBy((AB_CONTACTDTO contact) => contact.SORT);
		return result.ToList();
	}

	public void MoveContactToGroup(Guid groupId, string contactIds)
	{
		if (!(groupId != Guid.Empty))
		{
			return;
		}
		string[] contactIdArray = contactIds.Split(',');
		if (contactIdArray == null || !contactIdArray.Any())
		{
			return;
		}
		contactIdArray.ToList().ForEach(delegate(string cId)
		{
			Guid guid = Guid.Parse(cId);
			AB_CONTACT byKey = abContactRepository.GetByKey(guid);
			if (byKey != null)
			{
				byKey.AB_GROUP_CONTACT.First().GROUP_ID = groupId;
				abContactRepository.UpdateCommit(byKey);
			}
		});
		abContactRepository.DbContext.Commit();
	}

	public void AdjustContactOrg(string userIds, Guid orgId)
	{
		string[] userIdArray = userIds.Split(",", removeEmptyEntries: true);
		if (userIdArray == null || !userIdArray.Any())
		{
			return;
		}
		List<Guid> contactList = new List<Guid>();
		userIdArray.ForEach(delegate(string userId)
		{
			Guid userID = Guid.Parse(userId);
			HR_EMPLOYEE employee = hrEmployeeRepository.Find((HR_EMPLOYEE h) => h.USER_ID == userID && h.ISDEL == (decimal?)0m);
			if (employee != null)
			{
				employee.ORG_ID = orgId;
				hrEmployeeRepository.UpdateCommit(employee);
				AB_CONTACT aB_CONTACT = abContactRepository.Find((AB_CONTACT a) => a.CONTACT_ID == employee.CONTACT_ID && a.ISDEL == 0m);
				if (aB_CONTACT != null)
				{
					contactList.Add(aB_CONTACT.CONTACT_ID);
				}
			}
		});
		List<AB_ORG_CONTACT> removeOrgContact = new List<AB_ORG_CONTACT>();
		contactList.ForEach(delegate(Guid contactId)
		{
			AB_ORG_CONTACT aB_ORG_CONTACT = abOrgContactRepository.Find((AB_ORG_CONTACT a) => a.CONTACT_ID == contactId);
			if (aB_ORG_CONTACT != null)
			{
				removeOrgContact.Add(aB_ORG_CONTACT);
			}
		});
		abOrgContactRepository.RemoveCommit(removeOrgContact);
		List<AB_ORG_CONTACT> addOrgContact = new List<AB_ORG_CONTACT>();
		contactList.ForEach(delegate(Guid contactId)
		{
			AB_ORG_CONTACT item = new AB_ORG_CONTACT
			{
				ORG_CONTACT_ID = Guid.NewGuid(),
				CONTACT_ID = contactId,
				ORG_ID = orgId
			};
			addOrgContact.Add(item);
		});
		abOrgContactRepository.AddCommit(addOrgContact);
	}

	public AB_CONTACTDTO GetContactByUserId(Guid userID)
	{
		IList<AB_CONTACTDTO> list = SqlQuery<AB_CONTACTDTO>("GetContactByUserId", new
		{
			USER_ID = userID
		});
		AB_CONTACTDTO result = ((list.Count > 0) ? list[0] : new AB_CONTACTDTO());
		IList<IT_DEVICEDTO> deviceList = SqlQuery<IT_DEVICEDTO>("GetDeviceListByUserId", new
		{
			USER_ID = userID
		});
		result.DEVICE_LIST = deviceList;
		return result;
	}

	public AB_CONTACTDTO UpdateContactWay(AB_CONTACTDTO contactDTO)
	{
		if (contactDTO != null && contactDTO.CONTACT_ID != Guid.Empty)
		{
			if (contactDTO.IsValid())
			{
				AB_CONTACT persisted = abContactRepository.GetByKey(contactDTO.CONTACT_ID);
				if (persisted != null)
				{
					persisted.WORK_TEL = contactDTO.WORK_TEL;
					persisted.MOBILE = contactDTO.MOBILE;
					persisted.UNIT_ADDRESS = contactDTO.UNIT_ADDRESS;
					if (contactDTO.CATEGORY_TYPE == 1)
					{
						HR_EMPLOYEE employee = hrEmployeeRepository.GetByKey(contactDTO.EMPLOYEE_ID);
						if (employee != null)
						{
							employee.MOBILE = contactDTO.MOBILE;
							employee.WORK_TEL = contactDTO.WORK_TEL;
							hrEmployeeRepository.UpdateCommit(employee);
						}
					}
					abContactRepository.UpdateCommit(persisted);
					SqlRepository repository = new SqlRepository();
					string sql = " UPDATE SYS_USER SET MODIFYTIME=SYSDATE WHERE USER_ID=:UserID";
					repository.ExecuteCommand(sql, SessionContext.UserInfo);
					return contactDTO;
				}
				throw new ValidationException("SystemManagement.Public.V_0004");
			}
			return new AB_CONTACTDTO();
		}
		throw new ValidationException(contactDTO.GetInvalidMessages());
	}

	public QueryResult<SYS_ORGDTO> GetOrgList(string ORG_ID)
	{
		QueryResult<SYS_ORGDTO> qrSYSORGDTO = new QueryResult<SYS_ORGDTO>();
		if (string.IsNullOrEmpty(ORG_ID))
		{
			return SqlQuery<SYS_ORGDTO>("MobileFunction_GetOrgList", null, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[0]);
		}
		string condition = "f_guidtoraw('" + ORG_ID + "')";
		return SqlQuery<SYS_ORGDTO>("MobileFunction_GetOrgListByOrgID", null, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[1] { condition });
	}

	public QueryResult<AB_CONTACT_MOBILEDTO> GetEmployeeListByOrgID(string ORG_ID, string searchValue)
	{
		Guid reuslt = Guid.Empty;
		QueryResult<AB_CONTACT_MOBILEDTO> qrEMPLOYEEUNION = new QueryResult<AB_CONTACT_MOBILEDTO>();
		if (!string.IsNullOrEmpty(ORG_ID) && Guid.TryParse(ORG_ID, out reuslt) && searchValue == "")
		{
			qrEMPLOYEEUNION = SqlQuery<AB_CONTACT_MOBILEDTO>("MobileFunction_GetEmployeeListByOrgID", null, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[1] { ORG_ID });
		}
		else if (!string.IsNullOrEmpty(ORG_ID) && Guid.TryParse(ORG_ID, out reuslt) && searchValue != "")
		{
			qrEMPLOYEEUNION = SqlQuery<AB_CONTACT_MOBILEDTO>("MobileFunction_GetEmployeeListBySearchValue", null, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[2] { ORG_ID, searchValue });
		}
		return qrEMPLOYEEUNION;
	}

	public QueryResult<AB_CONTACT_MOBILEDTO> GetEmployeeListByUnameOrPno(string searchValue)
	{
		return SqlQuery<AB_CONTACT_MOBILEDTO>("MobileFunction_GetEmployeeListByUnameOrPno", null, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[1] { searchValue });
	}
}
