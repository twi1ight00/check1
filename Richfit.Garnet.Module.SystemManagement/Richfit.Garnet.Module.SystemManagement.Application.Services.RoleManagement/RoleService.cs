using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.RoleManagement;

/// <summary>
/// 角色接口.
/// </summary>
/// <remarks>
/// 角色信息的新增，修改，删除，查询，权限分配，用户分配，获取流程信息，
/// 此Service用到的角色都是直接挂在某个组织机构下的。
/// </remarks>
/// <example>
/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\Application\Services\RoleManagement\RoleServiceFactory.cs" region="Example.GetRoleService.1">
/// </code>
/// </example>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ROLEDTO">角色DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ORGDTO">组织机构DTO对象</seealso>
public class RoleService : ServiceBase, IRoleAppService
{
	/// <summary>
	/// 角色 仓储对象
	/// </summary>
	private readonly IRepository<SYS_ROLE> roleRepository;

	/// <summary>
	/// 角色与组织机构关系 仓储对象
	/// </summary>
	private readonly IRepository<SYS_ROLE_ORG> roleOrgRepository;

	/// <summary>
	/// 用户与角色关系 仓储对象
	/// </summary>
	private readonly IRepository<SYS_USER_ROLE> userRoleRepository;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryRole">角色仓储对象</param>
	/// <param name="repositoryRoleOrg">角色与组织机构关系仓储对象</param>
	/// <param name="repositoryUserRole">角色与用户关系仓储对象</param>
	public RoleService(IRepository<SYS_ROLE> repositoryRole, IRepository<SYS_ROLE_ORG> repositoryRoleOrg, IRepository<SYS_USER_ROLE> repositoryUserRole)
	{
		roleRepository = repositoryRole;
		roleOrgRepository = repositoryRoleOrg;
		userRoleRepository = repositoryUserRole;
	}

	/// <inheritdoc />
	public SYS_ROLEDTO AddRole(SYS_ROLEDTO roleDTO)
	{
		if (roleDTO.IsValid())
		{
			SYS_ROLE rolePOCO = roleDTO.AdaptAsEntity<SYS_ROLE>();
			roleRepository.AddCommit(rolePOCO);
			roleDTO = rolePOCO.AdaptAsDTO<SYS_ROLEDTO>();
			return roleDTO;
		}
		throw new ValidationException(roleDTO.GetInvalidMessages());
	}

	/// <inheritdoc />
	public void UpdateRole(SYS_ROLEDTO roleDTO)
	{
		if (roleDTO == null || roleDTO.ROLE_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateRole方法参数不能为空！");
		}
		if (roleDTO.IsValid())
		{
			SYS_ROLE rolePOCO = roleRepository.GetByKey(roleDTO.ROLE_ID);
			if (rolePOCO != null)
			{
				rolePOCO.NOTE = roleDTO.NOTE;
				rolePOCO.ROLE_NAME = roleDTO.ROLE_NAME;
				rolePOCO.ROLE_TYPE = roleDTO.ROLE_TYPE;
				roleRepository.UpdateCommit(rolePOCO);
				return;
			}
			throw new ArgumentException("UpdateRole不存在相关的实体对象！");
		}
		throw new ValidationException(roleDTO.GetInvalidMessages());
	}

	/// <inheritdoc />
	public void RemoveRole(string roleIds)
	{
		string[] roleIdArray = roleIds.Split(",", removeEmptyEntries: true);
		if (roleIdArray == null || !Enumerable.Any(roleIdArray))
		{
			return;
		}
		roleIdArray.ForEach(delegate(string roleIdString)
		{
			Guid guid = Guid.Parse(roleIdString);
			SYS_ROLE byKey = roleRepository.GetByKey(guid);
			if (byKey != null)
			{
				if (byKey.SYS_USER_ROLE.Count > 0)
				{
					throw new ValidationException("SystemManagement.Public.V_0009", new string[1] { byKey.ROLE_NAME });
				}
				byKey.ISDEL = 1m;
				roleRepository.Update(byKey);
				roleRepository.RemoveChild(byKey.SYS_PRIVILEGE.ToList());
			}
		});
		roleRepository.DbContext.Commit();
	}

	/// <inheritdoc />
	public void RoleDistributeUser(Guid roleId, Guid roleOrgId, string userOrgIds)
	{
		if (!(roleId != Guid.Empty))
		{
			return;
		}
		Guid? orgId = SessionContext.GetRootOrgId();
		IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();
		IList<OrgDTO> orgList = orgUserService.GetOrgAndAllChildren(orgId, isIncludeSelf: true);
		IList<Guid> orgIdList = orgList.Select((OrgDTO x) => x.ORG_ID).ToList();
		Specification<SYS_USER_ROLE> specification = new ExpressionSpecification<SYS_USER_ROLE>((SYS_USER_ROLE x) => x.ROLE_ID == roleId);
		IList<SYS_USER_ROLE> userRoleList = userRoleRepository.FindAll(specification);
		ListMapping<Guid, Guid> deleteUserOrgMapping = new ListMapping<Guid, Guid>();
		userRoleList.ForEach(delegate(SYS_USER_ROLE x)
		{
			deleteUserOrgMapping.Add(x.USER_ID, x.ORG_ID);
		});
		userRoleRepository.Remove(userRoleList);
		string[] userOrgIdArray = userOrgIds.Split(',');
		if (userOrgIdArray != null && Enumerable.Any(userOrgIdArray))
		{
			userRoleList.Clear();
			userOrgIdArray.ForEach(delegate(string userIdOrgId)
			{
				string[] array = userIdOrgId.Split(';');
				if (Enumerable.Any(array) && Enumerable.Count(array) == 2)
				{
					Guid guid = Guid.Parse(array[0]);
					Guid guid2 = Guid.Parse(array[1]);
					SYS_USER_ROLE item = new SYS_USER_ROLE
					{
						USER_ID = guid,
						ORG_ID = guid2,
						ROLE_ID = roleId
					};
					userRoleList.Add(item);
					deleteUserOrgMapping.AddUniqueValue(guid, guid2);
				}
			});
			userRoleRepository.Add(userRoleList);
		}
		userRoleRepository.DbContext.Commit();
		BusinessMenuManager.RemoveUserBusiness(deleteUserOrgMapping);
	}

	/// <inheritdoc />
	public void BatchRoleDistributeUser(string roleIds, string userOrgIds)
	{
		string[] userOrgIdArray = userOrgIds.Split(',');
		ListMapping<Guid, Guid> addUserOrgMapping = new ListMapping<Guid, Guid>();
		userOrgIdArray.ForEach(delegate(string userIdOrgId)
		{
			string[] array = userIdOrgId.Split(';');
			if (Enumerable.Any(array) && Enumerable.Count(array) == 2)
			{
				Guid userId = Guid.Parse(array[0]);
				Guid userOrgId = Guid.Parse(array[1]);
				ListMapping<Guid, Guid> deleteUserOrgMapping = new ListMapping<Guid, Guid>();
				Specification<SYS_USER_ROLE> specification = new ExpressionSpecification<SYS_USER_ROLE>((SYS_USER_ROLE x) => x.USER_ID == userId && x.ORG_ID == userOrgId);
				IList<SYS_USER_ROLE> userRoleList = userRoleRepository.FindAll(specification);
				string[] array2 = roleIds.Split(',');
				if (array2 != null && Enumerable.Any(array2))
				{
					array2.ForEach(delegate(string roleId)
					{
						Guid userIdGuid = Guid.Parse(roleId);
						if (userRoleList.Where((SYS_USER_ROLE x) => x.ROLE_ID == userIdGuid).ToList().Count() == 0)
						{
							SYS_USER_ROLE entity = new SYS_USER_ROLE
							{
								USER_ID = userId,
								ORG_ID = userOrgId,
								ROLE_ID = userIdGuid
							};
							userRoleRepository.Add(entity);
							deleteUserOrgMapping.Add(userId, userOrgId);
							BusinessMenuManager.RemoveUserBusiness(deleteUserOrgMapping);
						}
					});
					userRoleRepository.DbContext.Commit();
				}
			}
		});
	}

	/// <inheritdoc />
	public void PrivilegeDistribute(Guid roleID, List<Guid> businessIDs)
	{
		if (!(roleID != Guid.Empty))
		{
			return;
		}
		SYS_ROLE rolePOCO = roleRepository.GetByKey(roleID);
		if (rolePOCO != null)
		{
			roleRepository.RemoveChild(rolePOCO.SYS_PRIVILEGE.ToList());
			IList<SYS_PRIVILEGE> addPrivileges = new List<SYS_PRIVILEGE>();
			businessIDs.ForEach(delegate(Guid businessId)
			{
				SYS_PRIVILEGE item = new SYS_PRIVILEGE
				{
					PRIVILEGE_ID = Guid.NewGuid(),
					BUSINESS_ID = businessId,
					ROLE_ID = roleID
				};
				addPrivileges.Add(item);
			});
			roleRepository.AddChild((IEnumerable<SYS_PRIVILEGE>)addPrivileges);
			roleRepository.DbContext.Commit();
			BusinessMenuManager.RemoveUserBusiness(GetUserOrgMapping(roleID));
		}
	}

	/// <inheritdoc />
	public QueryResult<SYS_ROLEDTO> QueryRoleList(QueryCondition queryCondition)
	{
		QueryItem orgIDQueryItem = queryCondition.GetByKey("ORG_ID");
		queryCondition.Remove(orgIDQueryItem);
		return SqlQueryResult<SYS_ROLEDTO>("GetSimpleRoleList", queryCondition);
	}

	/// <inheritdoc />
	public IList<TREE_NODE<Guid>> QueryRolePivilege(Guid roleID)
	{
		IList<TREE_NODE<Guid>> privilegeList = new List<TREE_NODE<Guid>>();
		if (roleID != Guid.Empty)
		{
			string sqlExpress = roleRepository.GetSqlConfig("GetRolePrivilegeList", GetType());
			privilegeList = roleRepository.ExecuteQuery<TREE_NODE<Guid>>(sqlExpress, new object[1] { roleID });
		}
		return privilegeList;
	}

	/// <inheritdoc />
	public IList<TREE_NODE<Guid>> QueryDistributeRolePivilege(Guid roleID)
	{
		IList<TREE_NODE<Guid>> privilegeList = new List<TREE_NODE<Guid>>();
		if (roleID != Guid.Empty)
		{
			string sqlExpress = roleRepository.GetSqlConfig("GetRoleDistributePrivilegeList", GetType());
			privilegeList = roleRepository.ExecuteQuery<TREE_NODE<Guid>>(sqlExpress, new object[1] { roleID });
		}
		return privilegeList;
	}

	/// <inheritdoc />
	public IList<TREE_NODE> QuerySubOrgAndUserTree(Guid roleId, Guid orgId, int levelCount, bool isIncludeSelf)
	{
		IList<TREE_NODE> treeList = new List<TREE_NODE>();
		if (roleId != Guid.Empty)
		{
			IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();
			treeList = orgUserService.GetOrgUserTree(orgId, levelCount, isFindUser: true, isAllowUserManyToOrg: true, isIncludeSelf, null);
			treeList = (from x in treeList
				orderby x.TYPE descending, x.SORT
				select x).ToList();
			IList<Guid> orgIdList = (from x in treeList
				where x.TYPE.Equals("0")
				select x.ID).ToList();
			if (!orgIdList.Contains(orgId))
			{
				orgIdList.Add(orgId);
			}
			Specification<SYS_USER_ROLE> specification = new ExpressionSpecification<SYS_USER_ROLE>((SYS_USER_ROLE x) => x.ROLE_ID == roleId && orgIdList.Contains(x.ORG_ID));
			IList<SYS_USER_ROLE> userRoleList = userRoleRepository.FindAll(specification);
			if (treeList != null && treeList.Any() && userRoleList != null && userRoleList.Any())
			{
				userRoleList.ForEachParallel(delegate(SYS_USER_ROLE x)
				{
					IEnumerable<TREE_NODE> enumerable = treeList.Where((TREE_NODE y) => y.ID.Equals(x.USER_ID) && y.PARENT_ID.Equals(x.ORG_ID));
					if (enumerable != null && enumerable.Any())
					{
						enumerable.ForEachParallel(delegate(TREE_NODE z)
						{
							z.IS_CHECK = 1m;
						});
					}
				});
			}
		}
		return treeList;
	}

	/// <summary>
	/// 返回要从缓存中移除的用户ID和机构ID的对应字典
	/// </summary>
	/// <param name="roleId">角色ID</param>
	/// <returns>用户ID和机构ID的对应字典</returns>
	private ListMapping<Guid, Guid> GetUserOrgMapping(Guid roleId)
	{
		ListMapping<Guid, Guid> userIdOrgIds = new ListMapping<Guid, Guid>();
		Specification<SYS_USER_ROLE> specification = new ExpressionSpecification<SYS_USER_ROLE>((SYS_USER_ROLE x) => x.ROLE_ID == roleId);
		IList<SYS_USER_ROLE> userRoleList = userRoleRepository.FindAll(specification);
		if (userRoleList != null && userRoleList.Any())
		{
			userRoleList.ForEach(delegate(SYS_USER_ROLE x)
			{
				userIdOrgIds.Add(x.USER_ID, x.ORG_ID);
			});
		}
		return userIdOrgIds;
	}

	/// <inheritdoc />
	public void RoleDistributeSubOrg(Guid roleId, string orgIds, Guid sourceOrgId, Guid usingOrgId)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public IList<TREE_NODE> QueryDistributableSubOrgTree(Guid roleId, Guid orgId, int levelCount, bool isIncludeSelf)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public IList<SYS_ORGDTO> GetWorkflowParticipantOrg(QueryCondition queryCondition)
	{
		string roleIds = queryCondition.GetByKey("ROLE_IDS").Value;
		string roleIdsSql = string.Empty;
		if (!string.IsNullOrEmpty(roleIds))
		{
			string[] roleIdArray = roleIds.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			roleIdsSql = roleIdArray.JoinString("'{0}'", ",");
			return SqlQuery<SYS_ORGDTO>("GetWorkflowParticipantOrg", queryCondition, ParameterResolveRule.Empty, new ValueResolveRule(0, 1), new string[1] { roleIdsSql }).List;
		}
		return new List<SYS_ORGDTO>();
	}

	/// <inheritdoc />
	public IList<SYS_USERDTO> GetWorkflowParticipant(QueryCondition queryCondition)
	{
		string normalRoleIds = queryCondition.GetByKey("NORMAL_ROLE_IDS").Value;
		string globalRoleIds = queryCondition.GetByKey("GLOBAL_ROLE_IDS").Value;
		string normalRoleIdsSql = string.Empty;
		string globalRoleIdsSql = string.Empty;
		if (!string.IsNullOrEmpty(normalRoleIds) || !string.IsNullOrEmpty(globalRoleIds))
		{
			if (!string.IsNullOrEmpty(normalRoleIds))
			{
				string[] normalRoleIdArray = normalRoleIds.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				normalRoleIdsSql = normalRoleIdArray.JoinString("'{0}'", ",");
			}
			else
			{
				normalRoleIdsSql = $"'{Utility.GetGuidString(Guid.Empty)}'";
			}
			if (!string.IsNullOrEmpty(globalRoleIds))
			{
				string[] globalRoleIdArray = globalRoleIds.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				globalRoleIdsSql = globalRoleIdArray.JoinString("'{0}'", ",");
			}
			else
			{
				globalRoleIdsSql = $"'{Utility.GetGuidString(Guid.Empty)}'";
			}
			return SqlQuery<SYS_USERDTO>("GetWorkflowParticipant", queryCondition, ParameterResolveRule.Empty, new ValueResolveRule(0, 1), new string[2] { normalRoleIdsSql, globalRoleIdsSql }).List;
		}
		return new List<SYS_USERDTO>();
	}

	/// <inheritdoc />
	public IList<TREE_NODE<Guid>> QueryBusinessTreeByRole(Guid roleId)
	{
		QueryCondition roleCondition = new QueryCondition();
		QueryItem roleItem = QueryItem.GetQueryItem("ROLE_ID", roleId.ToString(), "guid", " = ");
		roleCondition.Add(roleItem);
		IList<TREE_NODE<Guid>> queryResult = SqlQueryResult<TREE_NODE<Guid>>("GetBusinessTreeByRole", roleCondition).List;
		if (queryResult.Any())
		{
			BusinessMenuCacheLoader.SyncLocker.Read(delegate
			{
				Dictionary<Guid, MenuDTO> menuDictionary = LocalCacheBus.Instance.Get("MenuCacheKey") as Dictionary<Guid, MenuDTO>;
				if (menuDictionary != null && menuDictionary.Any())
				{
					queryResult.ForEachParallel(delegate(TREE_NODE<Guid> x)
					{
						if (menuDictionary.ContainsKey(x.ID))
						{
							x.TYPE = "0";
						}
					});
				}
			});
		}
		return queryResult;
	}

	/// <inheritdoc />
	public IList<BusinessDTO> QueryBusinessByRoleIds(string roleIds)
	{
		IList<BusinessDTO> businessList = new List<BusinessDTO>();
		if (!string.IsNullOrEmpty(roleIds))
		{
			string[] roleIdArray = roleIds.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			roleIdArray.ForEach(delegate(string x)
			{
				x = Utility.GetGuidString(x);
			});
			string roleIdsSql = roleIdArray.JoinString("'{0}'", ",");
			businessList = SqlQueryResult<BusinessDTO>("QueryBusinessByRoleIds", null, 0, new string[1] { roleIdsSql }).List;
		}
		return businessList;
	}

	public SYS_ROLEDTO GetRoleByKey(Guid orgId)
	{
		return GetDTOById<SYS_ROLEDTO, SYS_ROLE>(orgId, roleRepository);
	}

	public IList<SYS_ROLEDTO> GetWorkflowRoleByUser(Guid userId)
	{
		return SqlQuery<SYS_ROLEDTO>("GetWorkflowRoleByUser", new
		{
			USER_ID = userId
		});
	}

	public IList<SYS_ROLEDTO> GetRoleByUser(Guid userId)
	{
		return SqlQuery<SYS_ROLEDTO>("GetRoleByUser", new
		{
			USER_ID = userId
		});
	}

	public IList<SYS_USERDTO> GetUserListByRoleId(Guid roleId)
	{
		return SqlQuery<SYS_USERDTO>("GetUserListByRoleId", new
		{
			ROLE_ID = roleId
		});
	}
}
