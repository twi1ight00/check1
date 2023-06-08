using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.LDAP;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;
using Richfit.Garnet.Module.Fundation.Application.Services.Domain;
using Richfit.Garnet.Module.Importing;
using Richfit.Garnet.Module.Importing.Aspose.Excel;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.Services;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO.Parameters;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.SystemManagement.Application.Services.RoleManagement;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;

/// <summary>
/// 用户接口实现.
/// </summary>
/// <remarks>
/// 用户接口实现的功能：信息的新增，修改，删除，查询，兼管机构，分配角色，用户的启用和禁用。
/// </remarks>
/// <example>
/// <code language="cs"><![CDATA[
///  private ISystemUserService userAppService = ServiceLocator.Instance.GetService<ISystemUserService>();
/// ]]></code>
/// </example>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USERDTO">用户DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USER_BUSINESSDTO">用户业务组DTO对象</seealso>
public class SystemUserService : ServiceBase, ISystemUserService
{
	/// <summary>
	/// 用户与角色关系 仓储对象
	/// </summary>
	private readonly IRepository<SYS_USER> userRepository;

	/// <summary>
	/// 用户与角色关系 仓储对象
	/// </summary>
	private readonly IRepository<SYS_USER_ROLE> userRoleRepository;

	/// <summary>
	/// 用户与组织单位关系 仓储对象
	/// </summary>
	private readonly IRepository<SYS_USER_ORG> userOrgRepository;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryUser">用户仓储对象</param>
	/// <param name="repositoryUserRole">用户与角色关系仓储对象</param>
	/// <param name="repositoryUserOrg">用户与组织机构关系仓储对象</param>
	public SystemUserService(IRepository<SYS_USER> repositoryUser, IRepository<SYS_USER_ROLE> repositoryUserRole, IRepository<SYS_USER_ORG> repositoryUserOrg)
	{
		userRepository = repositoryUser;
		userRoleRepository = repositoryUserRole;
		userOrgRepository = repositoryUserOrg;
	}

	/// <summary>
	/// 创建用户
	/// </summary>
	/// <param name="userDTO">用户信息实体</param>
	/// <returns>完成新增后将用户信息(DTO)返回</returns>
	/// <inheritdoc />
	public SYS_USERDTO AddUser(SYS_USERDTO userDTO)
	{
		if (!userDTO.IsValid())
		{
			throw new ValidationException(userDTO.GetInvalidMessages());
		}
		bool isDomain = userDTO.DOMAIN_ID.HasValue;
		if (!IsExistAccount(userDTO.LOGON_NAME, (!userDTO.DOMAIN_ID.HasValue) ? Guid.Empty : userDTO.DOMAIN_ID.Value))
		{
			if (!isDomain)
			{
				userDTO.USER_PASSWORD = userDTO.USER_PASSWORD.EncryptText().Base64Encode();
			}
			SYS_USER userPOCO = userDTO.AdaptAsEntity<SYS_USER>();
			if (userDTO.ORG_ID.HasValue)
			{
				SYS_USER_ORG userOrgPOCO = new SYS_USER_ORG();
				userOrgPOCO.ORG_ID = userDTO.ORG_ID.Value;
				userOrgPOCO.USER_IDENTITY_TYPE = 1m;
				userPOCO.SYS_USER_ORG.Add(userOrgPOCO);
			}
			userRepository.AddCommit(userPOCO);
			SYS_USERDTO userDTOReturn = userPOCO.AdaptAsDTO<SYS_USERDTO>();
			userDTOReturn.ORG_NAME = userDTO.ORG_NAME;
			userDTOReturn.ORG_ID = userDTO.ORG_ID;
			OrgUserCacheManager.AddCache(userDTOReturn);
			userDTO = userDTOReturn;
			return userDTO;
		}
		throw new CustomCodeException("SystemManagement.Public.V_0002");
	}

	/// <summary>
	/// 更新用户
	/// </summary>
	/// <param name="userDTO">用户实体传输对象</param>
	/// <returns>更新用户信息(DTO)</returns>
	/// <inheritdoc />
	public void UpdateUser(SYS_USERDTO userDTO)
	{
		if (userDTO == null || userDTO.USER_ID == Guid.Empty)
		{
			throw new ValidationException("SystemManagement.Public.V_0003");
		}
		if (userDTO.IsValid())
		{
			SYS_USER userPOCO = userRepository.GetByKey(userDTO.USER_ID);
			if (userPOCO != null)
			{
				if (!IsDomain(userDTO))
				{
					userPOCO.USER_PASSWORD = userDTO.USER_PASSWORD.EncryptText().Base64Encode();
				}
				userPOCO.DISPLAY_NAME = userDTO.DISPLAY_NAME;
				userPOCO.USER_TYPE = userDTO.USER_TYPE;
				userPOCO.SORT = userDTO.SORT;
				userPOCO.NOTE = userDTO.NOTE;
				userPOCO.EXTEND1 = userDTO.EXTEND1;
				userPOCO.EXTEND2 = userDTO.EXTEND2;
				userPOCO.EXTEND3 = userDTO.EXTEND3;
				userPOCO.EXTEND4 = userDTO.EXTEND4;
				userPOCO.EXTEND5 = userDTO.EXTEND5;
				userRepository.UpdateCommit(userPOCO);
				SYS_USERDTO userDTOReturn = userPOCO.AdaptAsDTO<SYS_USERDTO>();
				userDTOReturn.ORG_ID = userDTO.ORG_ID;
				userDTOReturn.ORG_NAME = userDTO.ORG_NAME;
				OrgUserCacheManager.UpdateCache(userDTOReturn);
				return;
			}
			throw new ValidationException("SystemManagement.Public.V_0004");
		}
		throw new ValidationException(userDTO.GetInvalidMessages());
	}

	public void UpdateExtendOne(SYS_USERDTO userDTO)
	{
		if (userDTO == null || userDTO.USER_ID == Guid.Empty)
		{
			throw new ValidationException("SystemManagement.Public.V_0003");
		}
		SYS_USER userPOCO = userRepository.GetByKey(userDTO.USER_ID);
		if (userPOCO != null)
		{
			userPOCO.EXTEND1 = userDTO.EXTEND1;
			userRepository.UpdateCommit(userPOCO);
			SYS_USERDTO userDTOReturn = userPOCO.AdaptAsDTO<SYS_USERDTO>();
			userDTOReturn.ORG_ID = userDTO.ORG_ID;
			userDTOReturn.ORG_NAME = OrgUserCacheManager.GetOrgByKey(userDTO.ORG_ID.Value).ORG_NAME;
			OrgUserCacheManager.UpdateCache(userDTOReturn);
			return;
		}
		throw new ValidationException("SystemManagement.Public.V_0004");
	}

	/// <summary>
	/// 逻辑批量删除用户表信息通过用户和组织机构Id
	/// </summary>
	/// <param name="userOrgIds">用户与组织机构ID(形式为用','隔开的字符串，用户ID和组织机构ID之间';'分割)</param>
	/// <inheritdoc />
	public void RemoveUser(string userOrgIds)
	{
		string[] userOrgIdArray = userOrgIds.Split(",", removeEmptyEntries: true);
		if (userOrgIdArray == null || !Enumerable.Any(userOrgIdArray))
		{
			return;
		}
		ListMapping<Guid, Guid> userOrgMapping = new ListMapping<Guid, Guid>();
		userOrgIdArray.ForEach(delegate(string userOrgId)
		{
			string[] array = userOrgId.Split(";", removeEmptyEntries: true);
			Guid guid = Guid.Parse(array[0]);
			Guid orgId = Guid.Parse(array[1]);
			SYS_USER byKey = userRepository.GetByKey(guid);
			if (byKey != null)
			{
				if (IsDistributeOrg(guid, orgId))
				{
					throw new ValidationException("SystemManagement.Public.V_0010", new string[1] { "用户兼职监管其他机构，不能删除 " });
				}
				if (byKey.SYS_USER_ORG.Where(delegate(SYS_USER_ORG x)
				{
					int result;
					if (x.ORG_ID == orgId)
					{
						decimal? uSER_IDENTITY_TYPE = x.USER_IDENTITY_TYPE;
						result = ((uSER_IDENTITY_TYPE.GetValueOrDefault() == 1m && uSER_IDENTITY_TYPE.HasValue) ? 1 : 0);
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				}).Count() > 0)
				{
					byKey.ISDEL = 1m;
					userRepository.Update(byKey);
					IList<SYS_USER_ORG> list = byKey.SYS_USER_ORG.ToList();
					list.ForEach(delegate(SYS_USER_ORG x)
					{
						userOrgMapping.Add(x.USER_ID, x.ORG_ID);
					});
					userRepository.RemoveChild(list);
					userRepository.RemoveChild(byKey.SYS_USER_ROLE);
				}
				else
				{
					userOrgMapping.Add(guid, orgId);
					userRepository.RemoveChild(byKey.SYS_USER_ORG.Where((SYS_USER_ORG x) => x.ORG_ID == orgId).ToList());
					userRepository.RemoveChild(byKey.SYS_USER_ROLE.Where((SYS_USER_ROLE x) => x.ORG_ID == orgId).ToList());
				}
			}
		});
		userRepository.DbContext.Commit();
		BusinessMenuManager.RemoveUserBusiness(userOrgMapping);
		OrgUserCacheManager.RemoveUserCache(userOrgMapping);
	}

	/// <inheritdoc />
	public SYS_USERDTO GetUserById(Guid userId)
	{
		SYS_USERDTO userDTO = GetDTOById<SYS_USERDTO, SYS_USER>(userId, userRepository);
		userDTO.USER_PASSWORD = userDTO.USER_PASSWORD.Base64Decode().DecryptText();
		return userDTO;
	}

	public SYS_USERINFODTO GetUserByToken()
	{
		return SqlQuery<SYS_USERINFODTO>("GetUserByToken", new
		{
			USER_ID = SessionContext.UserInfo.UserID
		}).SingleOrDefault();
	}

	/// <summary>
	/// 获取用户列表信息
	/// </summary>
	/// <param name="queryCondition">查询条件表达式</param>
	/// <returns>用户列表信息</returns>
	/// <inheritdoc />
	public QueryResult<SYS_USERDTO> QueryUserList(QueryCondition queryCondition)
	{
		QueryResult<SYS_USERDTO> queryResult = new QueryResult<SYS_USERDTO>();
		QueryItem isSubOrgQueryItem = queryCondition.GetByKey("IS_CREATE_BY_SELF_ORG");
		QueryItem orgIDQueryItem = queryCondition.GetByKey("ORG_ID");
		QueryItem domailIDQueryItem = queryCondition.GetByKey("DOMAIN_ID");
		if (domailIDQueryItem != null)
		{
			switch (domailIDQueryItem.Value)
			{
			case "":
				queryCondition.Remove(domailIDQueryItem);
				break;
			case "NotDomainUser":
				domailIDQueryItem.Method = " Is Null ";
				domailIDQueryItem.Value = string.Empty;
				break;
			}
		}
		queryCondition.MoveTo(0, orgIDQueryItem);
		QueryItem cultureQueryItem = QueryItem.GetQueryItem("Culture", SessionContext.UserInfo.LanguageCulture, "string", " = ");
		queryCondition.Insert(1, cultureQueryItem);
		string sqlKey = "QuerySingleUserList";
		if (isSubOrgQueryItem != null && isSubOrgQueryItem.Value.ToLower() == "1")
		{
			sqlKey = "QueryMoreUserList";
		}
		queryCondition.Remove(isSubOrgQueryItem);
		queryResult = SqlQueryResult<SYS_USERDTO>(sqlKey, queryCondition, 2);
		if (queryResult.List.Any())
		{
			IList<SYS_LOCALIZINGDTO> userIdentityNameLocal = LocalizingCacheManager.GetSystemData("UserIdentityType");
			IList<SYS_LOCALIZINGDTO> isForbiddenNameLocal = LocalizingCacheManager.GetSystemData("IsForbiddenType");
			queryResult.List.ForEach(delegate(SYS_USERDTO u)
			{
				if (!string.IsNullOrWhiteSpace(u.USER_PASSWORD))
				{
					u.USER_PASSWORD = u.USER_PASSWORD.Base64Decode().DecryptText();
				}
				u.USER_IDENTITY_NAME = LocalizingCacheManager.TranslateByKey(userIdentityNameLocal, u.USER_IDENTITY_TYPE.Value.ToString());
				u.IS_FORBIDDEN_NAME = LocalizingCacheManager.TranslateByKey(isForbiddenNameLocal, u.IS_FORBIDDEN.ToString());
			});
		}
		return queryResult;
	}

	/// <summary>
	/// 修改用户密码
	/// </summary>
	/// <param name="userId">需要修改的用户Id</param>
	/// <param name="passWord"></param>
	/// <param name="newPassword">修改后的新密码</param>
	/// <inheritdoc />
	public void UpdateUserPassword(Guid userId, string passWord, string newPassword)
	{
		if (userId == Guid.Empty || string.IsNullOrWhiteSpace(newPassword))
		{
			throw new ValidationException("SystemManagement.Public.V_0006");
		}
		SYS_USER userPOCO = userRepository.GetByKey(userId);
		SYS_USERDTO userDTO = userPOCO.AdaptAsDTO<SYS_USERDTO>();
		if (IsDomain(userDTO))
		{
			throw new ValidationException("SystemManagement.Public.V_0007");
		}
		if (userDTO.USER_PASSWORD != passWord.EncryptText().Base64Encode())
		{
			throw new ValidationException("SystemManagement.Public.V_0011");
		}
		userPOCO.USER_PASSWORD = newPassword.EncryptText().Base64Encode();
		userRepository.UpdateCommit(userPOCO);
	}

	/// <summary>
	/// 用户分配角色保存
	/// </summary>
	/// <param name="userId">用户编号</param>
	/// <param name="roleOrgIds">角色ID和机构ID对应的结构（多个）每一个角色ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	/// <inheritdoc />
	public void UserDistributeRoles(SYS_USER_ROLE_SAVE_PARM parm)
	{
		IList<SYS_USER_ROLE> userRoleList = parm.SYS_USER_ROLE;
		IList<SYS_USER_ROLE> oldRoleList = userRoleRepository.FindAll((SYS_USER_ROLE a) => a.USER_ID == parm.USER_ID);
		if (userRoleList.Count() > 0)
		{
			IEnumerable<SYS_USER_ROLE> searchResult = oldRoleList.Except(userRoleList, (SYS_USER_ROLE a, SYS_USER_ROLE b) => a.ROLE_ID == b.ROLE_ID);
			userRoleRepository.Remove(searchResult);
			searchResult = userRoleList.Except(oldRoleList, (SYS_USER_ROLE a, SYS_USER_ROLE b) => a.ROLE_ID == b.ROLE_ID);
			userRoleRepository.Add(searchResult);
		}
		else
		{
			userRoleRepository.Remove(oldRoleList);
		}
		userRoleRepository.DbContext.Commit();
		IList<SYS_ORGDTO> getOrgByUser = GetOrgByUser(new SYS_USER
		{
			USER_ID = parm.USER_ID
		});
		List<Guid> orgList = new List<Guid>();
		foreach (SYS_ORGDTO item in getOrgByUser)
		{
			orgList.Add(item.ORG_ID);
		}
		ListMapping<Guid, Guid> deleteUserOrgMapping = new ListMapping<Guid, Guid>();
		userRoleList.ForEach(delegate(SYS_USER_ROLE x)
		{
			deleteUserOrgMapping.Add(parm.USER_ID, x.ORG_ID);
		});
		oldRoleList.ForEach(delegate(SYS_USER_ROLE x)
		{
			deleteUserOrgMapping.Add(parm.USER_ID, x.ORG_ID);
		});
		BusinessMenuManager.RemoveUserBusiness(deleteUserOrgMapping);
	}

	/// <summary>
	/// 用户分配角色
	/// </summary>
	/// <param name="userId">用户编号</param>
	/// <param name="roleOrgIds">角色ID和机构ID对应的结构（多个）每一个角色ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	/// <param name="forbiddenBusinessOrgIds">用户被禁用的业务Id和机构Id对应结构（多个）每一个业务ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	/// <inheritdoc />
	public void UserDistributeRoles(Guid userId, string roleOrgIds, string forbiddenBusinessOrgIds)
	{
		if (!(userId != Guid.Empty))
		{
			return;
		}
		SYS_USER userPOCO = userRepository.GetByKey(userId);
		IList<SYS_USER_ORG> userOrgList = userPOCO.SYS_USER_ORG.ToList();
		IList<Guid> orgIdList = userOrgList.Select((SYS_USER_ORG x) => x.ORG_ID).ToList();
		Specification<SYS_USER_ROLE> specification = new ExpressionSpecification<SYS_USER_ROLE>((SYS_USER_ROLE x) => x.USER_ID == userId && orgIdList.Contains(x.ORG_ID));
		IList<SYS_USER_ROLE> userRoleList = userRoleRepository.FindAll(specification);
		ListMapping<Guid, Guid> deleteUserOrgMapping = new ListMapping<Guid, Guid>();
		userRoleList.ForEach(delegate(SYS_USER_ROLE x)
		{
			deleteUserOrgMapping.Add(x.USER_ID, x.ORG_ID);
		});
		userRoleRepository.Remove(userRoleList);
		string[] roleOrgIdArray = roleOrgIds.Split(',');
		if (roleOrgIdArray != null && Enumerable.Any(roleOrgIdArray))
		{
			IList<Guid> roleIdList = new List<Guid>();
			userRoleList.Clear();
			roleOrgIdArray.ForEach(delegate(string roleIdOrgId)
			{
				string[] array2 = roleIdOrgId.Split(';');
				if (Enumerable.Any(array2) && Enumerable.Count(array2) == 2)
				{
					Guid guid2 = Guid.Parse(array2[0]);
					roleIdList.AddUnique(guid2);
					Guid oRG_ID2 = Guid.Parse(array2[1]);
					SYS_USER_ROLE item = new SYS_USER_ROLE
					{
						USER_ID = userId,
						ORG_ID = oRG_ID2,
						ROLE_ID = guid2
					};
					userRoleList.Add(item);
				}
			});
			userRoleRepository.Add(userRoleList);
			userRepository.RemoveChild(userPOCO.SYS_USER_BUSINESS.ToList());
			IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
			IList<Guid> roleToBusiness = (from x in roleAppService.QueryBusinessByRoleIds(roleIdList.JoinString(","))
				select x.BUSINESS_ID).ToList();
			string[] forbiddenBusinessOrgIdArray = forbiddenBusinessOrgIds.Split(',');
			if (forbiddenBusinessOrgIdArray != null && Enumerable.Any(forbiddenBusinessOrgIdArray))
			{
				forbiddenBusinessOrgIdArray.ForEach(delegate(string forbiddenBusinessOrgId)
				{
					string[] array = forbiddenBusinessOrgId.Split(';');
					if (Enumerable.Any(array) && Enumerable.Count(array) == 2)
					{
						Guid guid = Guid.Parse(array[0]);
						if (roleToBusiness.Contains(guid))
						{
							Guid oRG_ID = Guid.Parse(array[1]);
							SYS_USER_BUSINESS entity = new SYS_USER_BUSINESS
							{
								USER_BUSINESS_ID = IdentityGenerator.NewSequentialGuid(),
								BUSINESS_ID = guid,
								USER_ID = userId,
								ORG_ID = oRG_ID
							};
							userRoleRepository.AddChild(entity);
						}
					}
				});
			}
		}
		userRepository.DbContext.Commit();
		userRoleRepository.DbContext.Commit();
		BusinessMenuManager.RemoveUserBusiness(deleteUserOrgMapping);
	}

	/// <summary>
	/// 查询用户拥有角色信息
	/// </summary>
	/// <param name="userId">用户ID</param>
	/// <returns>用户拥有角色信息</returns>
	/// <inheritdoc />
	public IList<TREE_NODE> QueryOrgRoleTree(Guid userId)
	{
		IList<TREE_NODE> orgRoleList = new List<TREE_NODE>();
		if (userId != Guid.Empty)
		{
			string sqlExpress = string.Empty;
			sqlExpress = ((!ConfigurationManager.CurrentPackage.Settings["IsOrgCreateRole"].ToString().EqualOrdinal("true", ignoreCase: true)) ? userRepository.GetSqlConfig("QueryUserOrgSimpleRoles", GetType()) : userRepository.GetSqlConfig("QueryUserOrgRoles", GetType()));
			orgRoleList = userRepository.ExecuteQuery<TREE_NODE>(sqlExpress, ProcessParameters(new object[1] { userId }, userRepository.DbContext));
		}
		return orgRoleList;
	}

	/// <summary>
	/// 查询用户可分派的组织机构树
	/// </summary>
	/// <param name="userId">用户编号</param>
	/// <param name="orgId">机构编号</param>
	/// <param name="levelCount">查找层级数量</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <returns>可分派的组织机构树</returns>
	/// <inheritdoc />
	public IList<TREE_NODE> QueryDistributableOrgTree(Guid userId, Guid? orgId, int levelCount, bool isIncludeSelf)
	{
		IList<TREE_NODE> treeList = new List<TREE_NODE>();
		if (userId != Guid.Empty)
		{
			Specification<SYS_USER_ORG> specification = new ExpressionSpecification<SYS_USER_ORG>((SYS_USER_ORG x) => x.USER_ID == userId);
			IList<SYS_USER_ORG> userOrgList = userOrgRepository.FindAll(specification);
			IList<Guid> checkList = new List<Guid>();
			if (userOrgList != null && userOrgList.Any())
			{
				userOrgList.ForEach(delegate(SYS_USER_ORG x)
				{
					checkList.Add(x.ORG_ID);
				});
			}
			IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();
			treeList = orgUserService.GetOrgUserTree(orgId, levelCount, isFindUser: false, isAllowUserManyToOrg: false, isIncludeSelf, checkList);
		}
		return treeList;
	}

	/// <summary>
	/// 用户分派组织机构保存
	/// </summary>
	/// <param name="userId">用户UserID</param>
	/// <param name="orgIds">逗号分隔的机构ID字符串</param>
	/// <inheritdoc />
	public void UserDistributeOrg(Guid userId, string orgIds)
	{
		if (!(userId != Guid.Empty))
		{
			return;
		}
		SYS_USER userPOCO = userRepository.GetByKey(userId);
		if (userPOCO == null)
		{
			return;
		}
		Guid? rootOrgId = SessionContext.GetRootOrgId();
		IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();
		IList<OrgDTO> orgList = orgUserService.GetOrgAndAllChildren(rootOrgId, isIncludeSelf: true);
		IList<Guid> orgIdList = orgList.Select((OrgDTO x) => x.ORG_ID).ToList();
		IList<SYS_USER_ORG> userOrgList = userPOCO.SYS_USER_ORG.Where(delegate(SYS_USER_ORG x)
		{
			decimal? uSER_IDENTITY_TYPE = x.USER_IDENTITY_TYPE;
			return uSER_IDENTITY_TYPE.GetValueOrDefault() == 2m && uSER_IDENTITY_TYPE.HasValue;
		}).ToList();
		userRepository.RemoveChild(userOrgList);
		IList<Guid> deleteOrgIdList = new List<Guid>();
		if (userOrgList != null && userOrgList.Any())
		{
			userOrgList.ForEach(delegate(SYS_USER_ORG x)
			{
				deleteOrgIdList.Add(x.ORG_ID);
			});
		}
		IList<Guid> addOrgIdList = SplitToGuid(orgIds);
		addOrgIdList.ForEach(delegate(Guid orgId)
		{
			SYS_USER_ORG item = new SYS_USER_ORG
			{
				USER_ID = userId,
				ORG_ID = orgId,
				USER_IDENTITY_TYPE = 2m
			};
			userPOCO.SYS_USER_ORG.Add(item);
		});
		IList<Guid> deleteOrgIdWithoutAddList = deleteOrgIdList.Except(addOrgIdList).ToList();
		userRepository.RemoveChild(userPOCO.SYS_USER_ROLE.Where((SYS_USER_ROLE x) => deleteOrgIdWithoutAddList.Contains(x.ORG_ID)).ToList());
		userRepository.UpdateCommit(userPOCO, "SYS_USER_ORG");
		BusinessMenuManager.RemoveUserBusiness(userId, deleteOrgIdWithoutAddList);
		OrgUserCacheManager.RemoveUserCache(userId, deleteOrgIdWithoutAddList);
		IList<Guid> addOrgIdWithoutDeleteList = addOrgIdList.Except(deleteOrgIdList).ToList();
		OrgUserCacheManager.AddUserCache(userId, addOrgIdWithoutDeleteList);
	}

	/// <summary>
	/// 复制用户角色
	/// </summary>
	/// <param name="sourceUserIds">源用户编号，逗号分隔</param>
	/// <param name="destinationUserIds">目标用户编号，逗号分隔</param>
	/// <param name="orgId">所属机构编号</param>
	/// <inheritdoc />
	public void UserRolesCopy(string sourceUserIds, string destinationUserIds, Guid orgId)
	{
		IList<Guid> sourceUserIdList = SplitToGuid(sourceUserIds);
		IList<Guid> destinationUserIdList = SplitToGuid(destinationUserIds);
		if (!sourceUserIdList.Any() || !destinationUserIdList.Any() || !(orgId != Guid.Empty))
		{
			return;
		}
		IList<Guid> sourceUserRoleIds = GetRoleIds(sourceUserIdList, orgId);
		if (!sourceUserRoleIds.Any())
		{
			return;
		}
		foreach (Guid userId in destinationUserIdList)
		{
			SYS_USER destinationUser = userRepository.GetByKey(userId);
			IList<Guid> destinationUserRoleIds = (from p in destinationUser.SYS_USER_ROLE
				where p.ORG_ID == orgId
				select p into x
				select x.ROLE_ID).ToList();
			IList<Guid> exceptRoleIdList = sourceUserRoleIds.Except(destinationUserRoleIds).ToList();
			if (exceptRoleIdList.Any())
			{
				exceptRoleIdList.ForEach(delegate(Guid x)
				{
					SYS_USER_ROLE item = new SYS_USER_ROLE
					{
						ROLE_ID = x,
						ORG_ID = orgId
					};
					destinationUser.SYS_USER_ROLE.Add(item);
				});
			}
			userRepository.Update(destinationUser, "SYS_USER_ROLE");
		}
		userRepository.DbContext.Commit();
		BusinessMenuManager.RemoveUserBusiness(destinationUserIdList, orgId);
	}

	/// <inheritdoc />
	public string GetDomainUserName(Guid domainId, string domainAccount)
	{
		if (domainId != Guid.Empty)
		{
			DomainDTO domainDTO = DomainManager.GetDomainById(domainId);
			if (domainDTO != null)
			{
				string ldapAddress = domainDTO.DOMAIN_ADDRESS;
				string ldapAccount = domainDTO.DOMAIN_ACCOUNT;
				string ldapPassword = domainDTO.DOMAIN_PWD.Base64Decode().DecryptText();
				return LDAPHelper.GetUserProperty(ldapAddress, ldapAccount, ldapPassword, domainAccount, "Name") as string;
			}
		}
		return string.Empty;
	}

	/// <summary>
	/// 禁用用户通过用户Id
	/// </summary>
	/// <param name="userIds">用户ID</param>
	/// <inheritdoc />
	public void ForbiddenUser(string userIds)
	{
		string[] userIdArray = userIds.Split(",", removeEmptyEntries: true);
		if (userIdArray == null || !Enumerable.Any(userIdArray))
		{
			return;
		}
		userIdArray.ForEach(delegate(string userId)
		{
			SYS_USER byKey = userRepository.GetByKey(Guid.Parse(userId));
			if (byKey != null)
			{
				byKey.IS_FORBIDDEN = 1m;
				userRepository.UpdateCommit(byKey);
				SYS_USERDTO sYS_USERDTO = byKey.AdaptAsDTO<SYS_USERDTO>();
			}
		});
	}

	/// <summary>
	/// 启用用户通过用户Id
	/// </summary>
	/// <param name="userIds">用户ID</param>
	/// <inheritdoc />
	public void EnableUserUser(string userIds)
	{
		string[] userIdArray = userIds.Split(",", removeEmptyEntries: true);
		if (userIdArray == null || !Enumerable.Any(userIdArray))
		{
			return;
		}
		userIdArray.ForEach(delegate(string userId)
		{
			SYS_USER byKey = userRepository.GetByKey(Guid.Parse(userId));
			if (byKey != null)
			{
				byKey.IS_FORBIDDEN = 0m;
				userRepository.UpdateCommit(byKey);
				SYS_USERDTO sYS_USERDTO = byKey.AdaptAsDTO<SYS_USERDTO>();
			}
		});
	}

	/// <inheritdoc />
	public IList<SYS_USER_BUSINESSDTO> GetUserForbiddenBusinessIds(Guid userId)
	{
		QueryCondition userCondition = new QueryCondition();
		QueryItem userItem = QueryItem.GetQueryItem("USER_ID", userId.ToString(), "guid", " = ");
		userCondition.Add(userItem);
		return SqlQueryResult<SYS_USER_BUSINESSDTO>("GetUserForbiddenBusinessIds", userCondition).List;
	}

	/// <summary>
	/// 查询用户拥有角色列表
	/// </summary>
	/// <param name="userId">用户ID</param>
	/// <param name="orgId">组织机构ID</param>
	/// <returns>用户拥有角色信息</returns>
	/// <inheritdoc />
	public IList<SYS_USER_ROLE> QueryRoleListByUserId(Guid userId, Guid orgId)
	{
		IList<SYS_USER_ROLE> userRoleList = new List<SYS_USER_ROLE>();
		if (userId == Guid.Empty)
		{
			userId = SessionContext.UserInfo.UserID;
		}
		if (orgId == Guid.Empty)
		{
			orgId = SessionContext.UserInfo.BelongToOrgID;
		}
		Specification<SYS_USER_ROLE> specification = new ExpressionSpecification<SYS_USER_ROLE>((SYS_USER_ROLE x) => x.USER_ID == userId && x.ORG_ID == orgId);
		return userRoleRepository.FindAll(specification);
	}

	public IList<SYS_USER_ROLEDTO> GetUserRoleById(Guid userId, Guid orgId)
	{
		IList<SYS_USER_ROLE> roleList = QueryRoleListByUserId(userId, orgId);
		IList<SYS_USER_ROLEDTO> roleDTOList = new List<SYS_USER_ROLEDTO>();
		roleList?.ForEach(delegate(SYS_USER_ROLE role)
		{
			roleDTOList.Add(role.AdaptAsDTO<SYS_USER_ROLEDTO>());
		});
		return roleDTOList;
	}

	public Stream ImportUser(Stream userInfo)
	{
		Stream errorStream = null;
		IList<DomainDTO> domainDTOList = DomainManager.GetAllDomain();
		AsposeExcelImporter importer = ImportManager.Default.GetImporter("ExcelImporter") as AsposeExcelImporter;
		AsposeExcelImportOptions options = new AsposeExcelImportOptions();
		options.ValueResolve = delegate(ValueResolveContext context)
		{
			if (context.Item.Name.EqualOrdinal("DOMAIN_ID"))
			{
				if (string.IsNullOrEmpty(context.RawValue))
				{
					context.Error = true;
					context.ErrorMessage = context.Item.Title + "该值为必填项";
				}
				else if (context.RawValue.Trim() == "非域用户")
				{
					context.Result = null;
				}
				else
				{
					DomainDTO domainDTO = domainDTOList.FirstOrDefault((DomainDTO p) => p.DOMAIN_NAME == context.RawValue.ToString().Trim() && p.ISDEL == 0m);
					if (domainDTO.IsNull())
					{
						context.Error = true;
						context.ErrorMessage = "系统域中不存在[" + context.RawValue + "]，请更改域类型！";
					}
					else
					{
						context.Result = domainDTO.DOMAIN_ID;
					}
				}
			}
			if (context.Item.Name.EqualOrdinal("ORG_ID") && !string.IsNullOrEmpty(context.RawValues["ORG_NAME"].ToString().Trim()))
			{
				IOrgUserService service2 = ServiceLocator.Instance.GetService<IOrgUserService>();
				IList<OrgDTO> orgUserTreeList2 = service2.GetOrgUserTreeList(Guid.Empty, -1, isFindUser: false, isAllowUserManyToOrg: false, isIncludeSelf: true);
				List<OrgDTO> source2 = orgUserTreeList2.Where((OrgDTO t) => t.ORG_NAME == context.RawValues["ORG_NAME"].ToString().Trim() && t.ISDEL == 0m).ToList();
				if (source2.Count() > 1)
				{
					if (string.IsNullOrEmpty(context.RawValues["ORG_ID"].ToString().Trim()))
					{
						context.Error = true;
						context.ErrorMessage = "机构名称在系统中重复时，机构ID不能为空！";
					}
					else if (source2.Where((OrgDTO t) => t.ORG_ID.ToString() == context.RawValues["ORG_ID"].ToString().Trim().ToLower() && t.ISDEL == 0m).Count() > 0)
					{
						context.Result = context.RawValues["ORG_ID"].ToString().Trim();
					}
					else
					{
						context.Error = true;
						context.ErrorMessage = "机构名称与机构名ID不对应！";
					}
				}
				else if (source2.Count() == 1)
				{
					if (string.IsNullOrEmpty(context.RawValues["ORG_ID"].ToString().Trim().ToLower()))
					{
						context.Result = source2.FirstOrDefault().ORG_ID;
					}
					else if (source2.FirstOrDefault().ORG_ID.ToString() == context.RawValues["ORG_ID"].ToString().Trim().ToLower())
					{
						context.Result = context.RawValues["ORG_ID"].ToString().Trim();
					}
					else
					{
						context.Error = true;
						context.ErrorMessage = "机构名称与机构名ID不对应！";
					}
				}
			}
		};
		options.ValueValidate = delegate(ValueValidateContext context)
		{
			if (context.Item.Name.EqualOrdinal("LOGON_NAME"))
			{
				if (context.Value == null || string.IsNullOrEmpty(context.Value.ToString()))
				{
					context.Error = true;
					context.ErrorMessage = context.Item.Title + "该值为必填项";
				}
				else if (context.Value.ToString().Length > 64)
				{
					context.Error = true;
					context.ErrorMessage = "登陆账户长度超过64个字符！";
				}
			}
			if (context.Item.Name.EqualOrdinal("DISPLAY_NAME"))
			{
				if (context.Value == null || string.IsNullOrEmpty(context.Value.ToString()))
				{
					context.Error = true;
					context.ErrorMessage = context.Item.Title + "该值为必填项";
				}
				else if (context.Value.ToString().Length > 64)
				{
					context.Error = true;
					context.ErrorMessage = "用户名长度超过128个字符！";
				}
			}
			if (context.Item.Name.EqualOrdinal("ORG_NAME"))
			{
				if (context.Value == null || string.IsNullOrEmpty(context.Value.ToString()))
				{
					context.Error = true;
					context.ErrorMessage = context.Item.Title + "该值为必填项";
				}
				else
				{
					IOrgUserService service = ServiceLocator.Instance.GetService<IOrgUserService>();
					IList<OrgDTO> orgUserTreeList = service.GetOrgUserTreeList(Guid.Empty, -1, isFindUser: false, isAllowUserManyToOrg: false, isIncludeSelf: true);
					List<OrgDTO> source = orgUserTreeList.Where((OrgDTO t) => t.ORG_NAME == context.Value.ToString().Trim() && t.ISDEL == 0m).ToList();
					if (source.Count() < 1)
					{
						context.Error = true;
						context.ErrorMessage = "系统中没有对应的机构名称，请检查核对！";
					}
				}
			}
			if (context.Item.Name.EqualOrdinal("SORT") && (context.Value == null || string.IsNullOrEmpty(context.Value.ToString())))
			{
				context.Error = true;
				context.ErrorMessage = context.Item.Title + "该值为必填项";
			}
			if (context.Item.Name.EqualOrdinal("NOTE") && context.Value != null && context.Value.ToString().Length > 1024)
			{
				context.Error = true;
				context.ErrorMessage = "备注长度超过1024个字符！";
			}
			if (context.Item.Name.EqualOrdinal("EXTEND1") && context.Value != null && context.Value.ToString().Length > 64)
			{
				context.Error = true;
				context.ErrorMessage = "备注长度超过64个字符！";
			}
			if (context.Item.Name.EqualOrdinal("EXTEND2") && context.Value != null && context.Value.ToString().Length > 128)
			{
				context.Error = true;
				context.ErrorMessage = "备注长度超过128个字符！";
			}
			if (context.Item.Name.EqualOrdinal("EXTEND3") && context.Value != null && context.Value.ToString().Length > 255)
			{
				context.Error = true;
				context.ErrorMessage = "备注长度超过255个字符！";
			}
			if (context.Item.Name.EqualOrdinal("EXTEND4") && context.Value != null && context.Value.ToString().Length > 512)
			{
				context.Error = true;
				context.ErrorMessage = "备注长度超过512个字符！";
			}
			if (context.Item.Name.EqualOrdinal("EXTEND5") && context.Value != null && context.Value.ToString().Length > 512)
			{
				context.Error = true;
				context.ErrorMessage = "备注长度超过512个字符！";
			}
		};
		options.RecordValidate = delegate(RecordValidateContext context)
		{
			dynamic user = context.Record;
			if ((bool)IsExistAccount(user.LOGON_NAME, (user.DOMAIN_ID == null) ? ((object)Guid.Empty) : user.DOMAIN_ID))
			{
				context.Error = true;
				context.ErrorMessage = "系统对应的域中已经存在重复用户帐号，请检查确认！";
			}
			if (context.Records.Where((dynamic t) => t.LOGON_NAME == user.LOGON_NAME && t.DOMAIN_ID == user.DOMAIN_ID).Count() > 0)
			{
				context.Error = true;
				context.ErrorMessage = "导入模板中已经存在重复用户帐号，请检查确认！";
			}
		};
		try
		{
			List<IDataObject> infos = importer.ImportFromTemplate(userInfo, "UserInfo", options, out errorStream);
			if (errorStream != null)
			{
				return errorStream;
			}
			List<IDataObject> records = infos;
			List<SYS_USERDTO> userInfoList = new List<SYS_USERDTO>(records.Select((IDataObject x) => x.MapTo<SYS_USERDTO>()));
			List<SYS_USER> saveUserList = new List<SYS_USER>();
			if (userInfoList.Count > 0)
			{
				foreach (SYS_USERDTO item2 in userInfoList)
				{
					SYS_USER userPOCO = item2.AdaptAsEntity<SYS_USER>();
					userPOCO.USER_PASSWORD = ConfigurationManager.CurrentPackage.Settings["UserPassWord"].ToString();
					userPOCO.USER_TYPE = 0m;
					userPOCO.IS_FORBIDDEN = 0m;
					SYS_USER_ORG userOrgPOCO = new SYS_USER_ORG();
					userOrgPOCO.ORG_ID = item2.ORG_ID.Value;
					userOrgPOCO.USER_IDENTITY_TYPE = 1m;
					userPOCO.SYS_USER_ORG.Add(userOrgPOCO);
					saveUserList.Add(userPOCO);
				}
				userRepository.AddCommit(saveUserList);
				foreach (SYS_USER item in saveUserList)
				{
					SYS_USERDTO userDto = item.AdaptAsDTO<SYS_USERDTO>();
					userDto.ORG_ID = item.SYS_USER_ORG.FirstOrDefault().ORG_ID;
					OrgUserCacheManager.AddCache(userDto);
				}
			}
			return errorStream;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	/// <summary>
	/// 判断是否是域用户
	/// </summary>
	/// <param name="userDTO">用户实体</param>
	/// <returns>返回是否标记</returns>
	private bool IsDomain(SYS_USERDTO userDTO)
	{
		if (userDTO.DOMAIN_ID.HasValue && userDTO.DOMAIN_ID != Guid.Empty)
		{
			DomainDTO commonDomainDTO = DomainManager.GetDomainById(userDTO.DOMAIN_ID.Value);
			if (commonDomainDTO != null)
			{
				string ldapAddress = commonDomainDTO.DOMAIN_ADDRESS;
				string ldapAccount = commonDomainDTO.DOMAIN_ACCOUNT;
				string ldapPassword = commonDomainDTO.DOMAIN_PWD.Base64Decode().DecryptText();
				return LDAPHelper.UserExists(ldapAddress, ldapAccount, ldapPassword, userDTO.LOGON_NAME);
			}
		}
		return false;
	}

	/// <summary>
	/// 判断用户帐号是否重复（包括 普通用户 与 域用户），普通用户类型帐号唯一，域帐号在该域内唯一
	/// 该方法一般在新增用户时调用，判断新增的帐号是否已经存在
	/// </summary>
	/// <param name="logonName">帐号</param>
	/// <param name="domainId">域用户为:域Id;普通用户为：Guid.Empty</param>
	/// <returns>返回是否标记</returns>
	public bool IsExistAccount(string logonName, Guid domainId)
	{
		bool isExist = false;
		if (!string.IsNullOrWhiteSpace(logonName))
		{
			Specification<SYS_USER> specification = new ExpressionSpecification<SYS_USER>((SYS_USER x) => x.ISDEL == 0m && x.LOGON_NAME.Equals(logonName));
			if (domainId != Guid.Empty)
			{
				specification &= (Specification<SYS_USER>)new ExpressionSpecification<SYS_USER>((SYS_USER x) => x.DOMAIN_ID == domainId);
			}
			else
			{
				specification &= (Specification<SYS_USER>)new ExpressionSpecification<SYS_USER>((SYS_USER x) => x.DOMAIN_ID == null);
			}
			isExist = userRepository.Exists(specification);
		}
		return isExist;
	}

	/// <summary>
	/// 获取某机构下人员的角色ID列表
	/// </summary>
	/// <param name="userIds"></param>
	/// <param name="orgId"></param>
	/// <returns></returns>
	private IList<Guid> GetRoleIds(IList<Guid> userIds, Guid orgId)
	{
		IList<Guid> roleIdList = new List<Guid>();
		Specification<SYS_USER_ROLE> specification = new ExpressionSpecification<SYS_USER_ROLE>((SYS_USER_ROLE x) => userIds.Contains(x.USER_ID) && x.ORG_ID == orgId);
		IList<SYS_USER_ROLE> userRoleList = userRoleRepository.FindAll(specification);
		if (userRoleList != null && userRoleList.Any())
		{
			userRoleList.ForEach(delegate(SYS_USER_ROLE x)
			{
				if (!roleIdList.Contains(x.ROLE_ID))
				{
					roleIdList.Add(x.ROLE_ID);
				}
			});
		}
		return roleIdList;
	}

	/// <summary>
	/// 判断人员是否分配机构
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="orgId"></param>
	/// <returns></returns>
	private bool IsDistributeOrg(Guid userId, Guid orgId)
	{
		bool isExist = false;
		if (userId != Guid.Empty && orgId != Guid.Empty)
		{
			Specification<SYS_USER_ORG> specification = new ExpressionSpecification<SYS_USER_ORG>((SYS_USER_ORG x) => x.ORG_ID == orgId && x.USER_ID == userId && x.USER_IDENTITY_TYPE == (decimal?)1m);
			isExist = userOrgRepository.Exists(specification);
			if (isExist)
			{
				specification = new ExpressionSpecification<SYS_USER_ORG>((SYS_USER_ORG x) => x.USER_ID == userId && x.USER_IDENTITY_TYPE == (decimal?)2m);
				isExist = userOrgRepository.Exists(specification);
			}
		}
		return isExist;
	}

	public IList<SYS_ORGDTO> GetOrgByUser(SYS_USER user)
	{
		return SqlQuery<SYS_ORGDTO>("GetOrgByUser", user);
	}

	public IList<SYS_USER_ROLEDTO> GetUserRoleOrg(SYS_USER_ROLE user)
	{
		return SqlQuery<SYS_USER_ROLEDTO>("GetUserRoleOrg", user);
	}

	public void SaveUserRole(USER_ROLE_PARM userRoleParm)
	{
		IList<SYS_USER_ROLE> query = userRoleRepository.FindAll((SYS_USER_ROLE a) => a.ROLE_ID == userRoleParm.ROLE_ID && a.USER_ID == userRoleParm.USER_ID);
		userRoleRepository.Remove(query);
		foreach (Guid orgId in userRoleParm.ORG_ID)
		{
			SYS_USER_ROLE sYS_USER_ROLE = new SYS_USER_ROLE();
			sYS_USER_ROLE.USER_ID = userRoleParm.USER_ID;
			sYS_USER_ROLE.ROLE_ID = userRoleParm.ROLE_ID;
			sYS_USER_ROLE.ORG_ID = orgId;
			SYS_USER_ROLE userRole = sYS_USER_ROLE;
			userRoleRepository.Add(userRole);
		}
		userRoleRepository.DbContext.Commit();
	}

	public UserDTO GetUserBySapId(string sapId)
	{
		UserDTO userDTO = null;
		SYS_USER userPOCO = userRepository.Find((SYS_USER a) => a.EXTEND4 == sapId && a.ISDEL != 1m);
		if (userPOCO != null)
		{
			userDTO = userPOCO.AdaptAsDTO<UserDTO>();
			SYS_USER_ORG userOrg = userOrgRepository.Find((SYS_USER_ORG a) => a.USER_ID == userDTO.USER_ID && a.USER_IDENTITY_TYPE == (decimal?)1m);
			if (userOrg != null)
			{
				userDTO.ORG_ID = userOrg.ORG_ID;
				userDTO.ORG_NAME = OrgUserCacheManager.GetOrgByKey(userOrg.ORG_ID).ORG_NAME;
			}
		}
		return userDTO;
	}

	public void AddUserFromIAM(string sapId, Dictionary<string, string> attributes)
	{
		SYS_USERDTO userDTO = new SYS_USERDTO();
		userDTO.DOMAIN_ID = new Guid("BF23BC40-0224-4C54-9F1C-08CE7B01859B");
		userDTO.LOGON_NAME = sapId;
		userDTO.DISPLAY_NAME = attributes["displayName"];
		userDTO.USER_TYPE = 0m;
		userDTO.IS_FORBIDDEN = 0m;
		userDTO.SORT = 9999m;
		userDTO.ISDEL = 0m;
		userDTO.EXTEND4 = sapId;
		userDTO.ORG_ID = new Guid("9877E4CF-5E8D-4E6A-AD9D-310BDB393638");
		userDTO.ORG_NAME = "信息技术审计处";
		SYS_USER userPOCO = userDTO.AdaptAsEntity<SYS_USER>();
		if (userDTO.ORG_ID.HasValue)
		{
			SYS_USER_ORG userOrgPOCO = new SYS_USER_ORG();
			userOrgPOCO.ORG_ID = userDTO.ORG_ID.Value;
			userOrgPOCO.USER_IDENTITY_TYPE = 1m;
			userPOCO.SYS_USER_ORG.Add(userOrgPOCO);
		}
		userRepository.AddCommit(userPOCO);
		SYS_USERDTO userDTOReturn = userPOCO.AdaptAsDTO<SYS_USERDTO>();
		userDTOReturn.ORG_NAME = userDTO.ORG_NAME;
		userDTOReturn.ORG_ID = userDTO.ORG_ID;
		OrgUserCacheManager.AddCache(userDTOReturn);
	}

	public void RemoveUserFromIAM(Guid userId)
	{
		ListMapping<Guid, Guid> userOrgMapping = new ListMapping<Guid, Guid>();
		SYS_USER userPOCO = userRepository.GetByKey(userId);
		if (userPOCO != null)
		{
			userPOCO.ISDEL = 1m;
			userRepository.Update(userPOCO);
			IList<SYS_USER_ORG> userOrgList = userPOCO.SYS_USER_ORG.ToList();
			userOrgList.ForEach(delegate(SYS_USER_ORG x)
			{
				userOrgMapping.Add(x.USER_ID, x.ORG_ID);
			});
			userRepository.RemoveChild(userOrgList);
			userRepository.RemoveChild(userPOCO.SYS_USER_ROLE);
			userRepository.DbContext.Commit();
			BusinessMenuManager.RemoveUserBusiness(userOrgMapping);
			OrgUserCacheManager.RemoveUserCache(userOrgMapping);
		}
	}
}
