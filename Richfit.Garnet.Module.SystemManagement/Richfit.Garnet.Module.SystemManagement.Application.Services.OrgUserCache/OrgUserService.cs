using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Adapter;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Data;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

/// <summary>
/// 组织机构人员层级树的服务.
/// </summary>
/// <remarks>
/// 组织机构人员层级树的服务,方法有获取树列表信息,获取组织结构或组织机构及人员信息.
/// </remarks>
/// <inheritdoc />
public class OrgUserService : ServiceBase, IOrgUserService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<SYS_USER> userRepository = null;

	/// <summary>
	/// 实例服务
	/// </summary>
	/// <param name="userRepository">用户仓储对象</param>
	public OrgUserService(IRepository<SYS_USER> userRepository)
	{
		this.userRepository = userRepository;
	}

	/// <summary>
	/// 查找组织机构和人员Tree数据，直接返回TREE_NODE类型
	/// </summary>
	/// <inheritdoc />
	public IList<TREE_NODE> GetOrgUserTree(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf, IList<Guid> checkList)
	{
		IList<OrgDTO> orgList = GetOrgUserTreeList(parentOrgId, levelCount, isFindUser, isAllowUserManyToOrg, isIncludeSelf);
		IList<TREE_NODE> orgTree = new List<TREE_NODE>();
		if (orgList != null && orgList.Any())
		{
			ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
			orgTree = adapter.Adapt<List<TREE_NODE>>(orgList);
			CheckTreeNode(orgTree, checkList);
		}
		return orgTree;
	}

	/// <summary>
	/// 查找组织机构和人员Tree数据，直接返回TREE_NODE泛型类型
	/// </summary>
	/// <inheritdoc />
	public IList<TREE_NODE<T>> GetOrgUserTree<T>(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf, IList<T> checkList) where T : struct
	{
		IList<OrgDTO> orgList = GetOrgUserTreeList(parentOrgId, levelCount, isFindUser, isAllowUserManyToOrg, isIncludeSelf);
		IList<TREE_NODE<T>> orgTree = new List<TREE_NODE<T>>();
		if (orgList != null && orgList.Any())
		{
			ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
			orgTree = adapter.Adapt<List<TREE_NODE<T>>>(orgList);
			CheckTreeNode(orgTree, checkList);
		}
		return orgTree;
	}

	/// <summary>
	/// 加载机构用户树缓存数据
	/// </summary>        
	/// <inheritdoc />
	public IList<OrgDTO> LoadOrgUserTreeCacheData()
	{
		string sqlKey = "LoadOrgUserTreeCache";
		QueryResult<OrgDTO> orgQueryResult = SqlQueryResult<OrgDTO>(sqlKey, null);
		return orgQueryResult.List;
	}

	/// <summary>
	/// 根据给定的用户ID反查只包含用户的组织机构树
	/// </summary>
	/// <inheritdoc />
	public IList<TREE_NODE> GetOrgUserTreeByUser(IList<Guid> userIds, bool isAllowUserManyToOrg = false)
	{
		IList<TREE_NODE> orgTree = new List<TREE_NODE>();
		IList<OrgDTO> orgList = new List<OrgDTO>();
		if (userIds != null && userIds.Any())
		{
			if (!OrgUserCacheLoader.IsCache())
			{
				IList<string> userIdList = new List<string>();
				userIds.ForEach(delegate(Guid x)
				{
					userIdList.Add(Utility.GetGuidString(x));
				});
				string sqlUserIds = userIdList.JoinString("'{0}'", ",");
				string sqlUser = string.Empty;
				if (!isAllowUserManyToOrg)
				{
					sqlUser += "  AND B.USER_IDENTITY_TYPE = 1";
				}
				QueryResult<OrgDTO> orgQueryResult = SqlQuery<OrgDTO>("GetOrgUserTreeByUser", null, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[2] { sqlUserIds, sqlUser });
				orgList = orgQueryResult.List;
			}
			else
			{
				OrgUserCacheLoader.SyncLocker.Read(delegate
				{
					IList<OrgDTO> treeOrgList = OrgUserCacheManager.GetOrgUserTreeCache();
					if (treeOrgList != null && treeOrgList.Any())
					{
						userIds.ForEach(delegate(Guid x)
						{
							RecurseTreeUp(x, treeOrgList, orgList, isAllowUserManyToOrg);
						});
					}
				});
			}
			if (orgList != null && orgList.Any())
			{
				ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
				orgTree = adapter.Adapt<List<TREE_NODE>>(orgList);
			}
		}
		return orgTree;
	}

	/// <summary>
	/// 查找组织机构和人员Tree数据，直接返回DTO类型
	/// </summary>
	/// <inheritdoc />
	public IList<OrgDTO> GetOrgUserTreeList(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf)
	{
		if (!OrgUserCacheLoader.IsCache())
		{
			return GetOrgUserTreeListFromDB(parentOrgId, levelCount, isFindUser, isAllowUserManyToOrg, isIncludeSelf);
		}
		return OrgUserCacheLoader.SyncLocker.Read(delegate
		{
			IList<OrgDTO> orgUserTreeCache = OrgUserCacheManager.GetOrgUserTreeCache();
			if (orgUserTreeCache != null && orgUserTreeCache.Any())
			{
				OrgDTO self;
				if (parentOrgId.HasValue && parentOrgId.Value != Guid.Empty)
				{
					self = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == parentOrgId.Value).FirstOrDefault();
				}
				else
				{
					parentOrgId = null;
					self = orgUserTreeCache.Where((OrgDTO x) => x.PARENT_ORG_ID == parentOrgId).FirstOrDefault();
				}
				if (self != null)
				{
					IEnumerable<OrgDTO> source = orgUserTreeCache;
					if (!isFindUser)
					{
						source = orgUserTreeCache.Where((OrgDTO x) => x.TYPE == "0");
					}
					if (!isAllowUserManyToOrg)
					{
						source = source.Where((OrgDTO x) => x.USER_IDENTITY_TYPE == 1m);
					}
					source = ((levelCount > 0) ? source.Where((OrgDTO x) => x.PATH.StartsWith(self.PATH) && x.PATH.Length <= self.PATH.Length + levelCount * 37) : ((levelCount != 0) ? source.Where((OrgDTO x) => x.PATH.StartsWith(self.PATH)) : (isFindUser ? source.Where((OrgDTO x) => (x.PATH.Equals(self.PATH) && x.TYPE == "0") || (x.PATH.StartsWith(self.PATH) && x.PATH.Length == self.PATH.Length + 37 && x.TYPE == "1")) : source.Where((OrgDTO x) => x.PATH.Equals(self.PATH)))));
					if (!isIncludeSelf && parentOrgId.HasValue && parentOrgId.Value != Guid.Empty)
					{
						source = source.Where((OrgDTO x) => x.PATH.Length > self.PATH.Length);
					}
					return SetChildCount(source.ToList(), isFindUser);
				}
			}
			return null;
		});
	}

	/// <summary>
	/// 查找某组织机构及所有下级机构
	/// </summary>
	/// <inheritdoc />
	public IList<OrgDTO> GetOrgAndAllChildren(Guid? parentOrgId, bool isIncludeSelf)
	{
		if (!OrgUserCacheLoader.IsCache())
		{
			QueryCondition queryConditon = new QueryCondition();
			SqlRepository repository = ServiceLocator.Instance.GetService<SqlRepository>();
			string sqlOrg = string.Empty;
			if (parentOrgId.HasValue && parentOrgId.Value != Guid.Empty)
			{
				if (!isIncludeSelf)
				{
					queryConditon.Add(QueryItem.GetQueryItem("PARENT_ORG_ID", parentOrgId.Value.ToString(), "guid", " = "));
				}
				else
				{
					queryConditon.Add(QueryItem.GetQueryItem("ORG_ID", parentOrgId.Value.ToString(), "guid", " = "));
				}
			}
			else
			{
				queryConditon.Add(QueryItem.GetQueryItem("PARENT_ORG_ID", string.Empty, "guid", " Is Null "));
			}
			sqlOrg += repository.GetWhereSqlClause(queryConditon.QueryItems);
			QueryResult<OrgDTO> orgQueryResult = SqlQuery<OrgDTO>("GetOrgAndAllChild", queryConditon, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[1] { sqlOrg });
			return orgQueryResult.List;
		}
		return OrgUserCacheLoader.SyncLocker.Read(delegate
		{
			IList<OrgDTO> orgUserTreeCache = OrgUserCacheManager.GetOrgUserTreeCache();
			if (orgUserTreeCache != null && orgUserTreeCache.Any())
			{
				OrgDTO self;
				if (parentOrgId.HasValue && parentOrgId.Value != Guid.Empty)
				{
					self = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == parentOrgId.Value).FirstOrDefault();
				}
				else
				{
					parentOrgId = null;
					self = orgUserTreeCache.Where((OrgDTO x) => x.PARENT_ORG_ID == parentOrgId).FirstOrDefault();
				}
				if (self != null)
				{
					IEnumerable<OrgDTO> source = orgUserTreeCache.Where((OrgDTO x) => x.PATH.StartsWith(self.PATH) && x.TYPE == "0");
					if (!isIncludeSelf && parentOrgId.HasValue && parentOrgId.Value != Guid.Empty)
					{
						source = source.Where((OrgDTO x) => x.PATH.Length > self.PATH.Length);
					}
					return SetChildCount(source.ToList(), isSumUser: false);
				}
			}
			return null;
		});
	}

	private IList<OrgDTO> SetChildCount(IList<OrgDTO> orgDTOList, bool isSumUser)
	{
		orgDTOList.ForEach(delegate(OrgDTO x)
		{
			x.CHILD_COUNT = (isSumUser ? (x.ORG_CHILD_COUNT + x.USER_CHILD_COUNT) : x.ORG_CHILD_COUNT);
		});
		return orgDTOList;
	}

	/// <summary>
	/// 根据人员ID递归查找树结构
	/// </summary>
	/// <param name="selfId"></param>
	/// <param name="treeOrgList"></param>
	/// <param name="orgDTOList"></param>
	/// <param name="isAllowUserManyToOrg"></param>
	private void RecurseTreeUp(Guid selfId, IList<OrgDTO> treeOrgList, IList<OrgDTO> orgDTOList, bool isAllowUserManyToOrg)
	{
		IList<OrgDTO> queryList = (isAllowUserManyToOrg ? treeOrgList.Where((OrgDTO x) => x.ORG_ID == selfId).ToList() : treeOrgList.Where((OrgDTO x) => x.ORG_ID == selfId && x.USER_IDENTITY_TYPE == 1m).ToList());
		if (queryList == null || !queryList.Any())
		{
			return;
		}
		queryList.ForEach(delegate(OrgDTO self)
		{
			if (!orgDTOList.Contains(self))
			{
				if (!orgDTOList.Any())
				{
					orgDTOList.Add(self);
				}
				else
				{
					OrgDTO orgDTO = orgDTOList.Where((OrgDTO x) => x.PARENT_ORG_ID == self.PARENT_ORG_ID && x.SORT <= self.SORT).LastOrDefault();
					if (orgDTO != null)
					{
						int num = orgDTOList.IndexOf(orgDTO);
						if (num != orgDTOList.Count - 1)
						{
							orgDTOList.Insert(orgDTOList.IndexOf(orgDTO) + 1, self);
						}
						else
						{
							orgDTOList.Add(self);
						}
					}
					else
					{
						orgDTOList.Add(self);
					}
				}
			}
			if (self.PARENT_ORG_ID.HasValue)
			{
				RecurseTreeUp(self.PARENT_ORG_ID.Value, treeOrgList, orgDTOList, isAllowUserManyToOrg);
			}
		});
	}

	private IList<OrgDTO> GetAllChildOrgUserTreeListFromDB(Guid? parentOrgId, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf)
	{
		QueryCondition queryConditon = new QueryCondition();
		SqlRepository repository = ServiceLocator.Instance.GetService<SqlRepository>();
		string sqlOrg = string.Empty;
		if (parentOrgId.HasValue && parentOrgId.Value != Guid.Empty)
		{
			if (!isIncludeSelf)
			{
				queryConditon.Add(QueryItem.GetQueryItem("PARENT_ORG_ID", parentOrgId.Value.ToString(), "guid", " = "));
			}
			else
			{
				queryConditon.Add(QueryItem.GetQueryItem("ORG_ID", parentOrgId.Value.ToString(), "guid", " = "));
			}
		}
		else
		{
			queryConditon.Add(QueryItem.GetQueryItem("PARENT_ORG_ID", string.Empty, "guid", " Is Null "));
		}
		sqlOrg += repository.GetWhereSqlClause(queryConditon.QueryItems);
		string sqlUser = string.Empty;
		string sqlUserCount = string.Empty;
		if (isFindUser)
		{
			if (EntityFrameworkConnection.GetDBType("Fundation") == DBType.SqlServer)
			{
				sqlUser = "          UNION ALL\r\n                      SELECT A.USER_ID, B.ORG_ID, A.DISPLAY_NAME, A.SORT, '1' AS TYPE,B.USER_IDENTITY_TYPE,A.NOTE,A.EXTEND1,A.EXTEND2,A.EXTEND3,A.EXTEND4,A.EXTEND5\r\n                        FROM SYS_USER A, SYS_USER_ORG B, SYS_ORG C\r\n                       WHERE A.USER_ID = B.USER_ID\r\n                         AND B.ORG_ID = C.ORG_ID\r\n                         AND A.ISDEL = 0 AND A.USER_TYPE = 0\r\n                         AND C.ISDEL = 0 {0}";
			}
			else
			{
				sqlUser = "       UNION\r\n                    SELECT A.USER_ID,\r\n                           B.ORG_ID,\r\n                           A.DISPLAY_NAME,\r\n                           A.SORT,\r\n                           '1' TYPE,\r\n                           B.USER_IDENTITY_TYPE,\r\n                           A.NOTE,\r\n                           A.EXTEND1,\r\n                           A.EXTEND2,\r\n                           A.EXTEND3,\r\n                           A.EXTEND4,\r\n                           A.EXTEND5\r\n                      FROM SYS_USER A, SYS_USER_ORG B, SYS_ORG C\r\n                     WHERE A.USER_ID = B.USER_ID\r\n                       AND B.ORG_ID = C.ORG_ID\r\n                       AND A.ISDEL = 0\r\n                       AND A.USER_TYPE = 0\r\n                       AND C.ISDEL = 0 {0}";
				sqlUserCount = "+\r\n                       (SELECT COUNT(B.USER_ID)\r\n                           FROM SYS_USER A, SYS_USER_ORG B, SYS_ORG C\r\n                          WHERE A.USER_ID = B.USER_ID\r\n                            AND B.ORG_ID = C.ORG_ID\r\n                            AND A.ISDEL = 0\r\n                            AND A.USER_TYPE = 0\r\n                            AND C.ISDEL = 0 {0}\r\n                            AND B.ORG_ID = D.ORG_ID\r\n                            AND D.TYPE = '0')";
			}
			string userType = string.Empty;
			if (!isAllowUserManyToOrg)
			{
				userType = "  AND B.USER_IDENTITY_TYPE = 1";
			}
			sqlUser = string.Format(sqlUser, userType);
			sqlUserCount = string.Format(sqlUserCount, userType);
		}
		string sqlKey = "GetAllOrgUserTree";
		QueryResult<OrgDTO> orgQueryResult = SqlQuery<OrgDTO>(sqlKey, queryConditon, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[3] { sqlOrg, sqlUser, sqlUserCount });
		return orgQueryResult.List;
	}

	private IList<OrgDTO> GetLevelOrgUserTreeListFromDB(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf)
	{
		Guid orgId = Guid.Empty;
		IList<OrgDTO> orgDTOListReturn = new List<OrgDTO>();
		if (!parentOrgId.HasValue || parentOrgId.Value == Guid.Empty)
		{
			isIncludeSelf = true;
			string sqlKey = "GetOrgRootID";
			IList<Guid> queryResult = SqlQuery<Guid>(sqlKey, null, ParameterResolveRule.Empty, ValueResolveRule.Empty).List;
			if (queryResult.Any())
			{
				orgId = queryResult.First();
			}
		}
		else
		{
			orgId = parentOrgId.Value;
		}
		if (levelCount == 0 && isIncludeSelf)
		{
			orgDTOListReturn = GetFirstLevelOrgUserTreeListFromDB(orgId, idIsParent: false, isFindUser, isAllowUserManyToOrg, isIncludeSelf);
		}
		else
		{
			int i = 0;
			IList<OrgDTO> toFindOrgList = null;
			IList<OrgDTO> orgUserListResult = new List<OrgDTO>();
			for (; i < levelCount; i++)
			{
				orgUserListResult.Clear();
				if (toFindOrgList == null)
				{
					orgUserListResult = GetFirstLevelOrgUserTreeListFromDB(orgId, idIsParent: true, isFindUser, isAllowUserManyToOrg, isIncludeSelf);
				}
				else if (toFindOrgList.Any())
				{
					toFindOrgList.ForEach(delegate(OrgDTO x)
					{
						orgUserListResult.AddRange(GetFirstLevelOrgUserTreeListFromDB(x.ORG_ID, idIsParent: true, isFindUser, isAllowUserManyToOrg, isIncludeSelf: false));
					});
				}
				orgDTOListReturn.AddRange(orgUserListResult);
				toFindOrgList = orgUserListResult.Where((OrgDTO x) => x.TYPE.Equals("0")).ToList();
			}
		}
		return orgDTOListReturn;
	}

	private IList<OrgDTO> GetFirstLevelOrgUserTreeListFromDB(Guid orgId, bool idIsParent, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf)
	{
		DBType dbType = EntityFrameworkConnection.GetDBType("SystemManage");
		string orgParam = "@p0";
		if (dbType == DBType.Oracle)
		{
			orgParam = ":p0";
		}
		QueryCondition queryConditon = new QueryCondition();
		queryConditon.Add(QueryItem.GetQueryItem("ORG_ID", orgId.ToString(), "guid", " = "));
		string sqlOrg = string.Empty;
		if (idIsParent)
		{
			sqlOrg = " AND PARENT_ORG_ID = {0}";
			if (isIncludeSelf)
			{
				sqlOrg += " OR ORG_ID = {0}";
			}
		}
		else
		{
			sqlOrg = " AND ORG_ID = {0}";
		}
		sqlOrg = string.Format(sqlOrg, orgParam);
		string sqlUser = string.Empty;
		string sqlUserCount = string.Empty;
		if (isFindUser)
		{
			sqlUser = " UNION\r\n        SELECT A.USER_ID,\r\n               B.ORG_ID,\r\n               A.DISPLAY_NAME,\r\n               C.ORG_NAME,\r\n               A.SORT,\r\n               '1' AS TYPE,\r\n               B.USER_IDENTITY_TYPE,\r\n               A.NOTE,\r\n               A.EXTEND1,\r\n               A.EXTEND2,\r\n               A.EXTEND3,\r\n               A.EXTEND4,\r\n               A.EXTEND5\r\n          FROM SYS_USER A, SYS_USER_ORG B, SYS_ORG C\r\n         WHERE A.USER_ID = B.USER_ID\r\n           AND B.ORG_ID = C.ORG_ID\r\n           AND A.ISDEL = 0\r\n           AND A.USER_TYPE = 0\r\n           AND C.ISDEL = 0 {0}\r\n           AND B.ORG_ID = {1}";
			sqlUserCount = ((dbType != DBType.SqlServer) ? " + (SELECT COUNT(B.USER_ID)\r\n           FROM SYS_USER A, SYS_USER_ORG B, SYS_ORG C\r\n          WHERE A.USER_ID = B.USER_ID\r\n            AND B.ORG_ID = C.ORG_ID\r\n            AND A.ISDEL = 0\r\n            AND A.USER_TYPE = 0\r\n            AND C.ISDEL = 0 {0}\r\n            AND B.ORG_ID = D.ORG_ID\r\n            AND D.TYPE = '0')" : " +(SELECT CAST(COUNT(B.USER_ID) AS DECIMAL)\r\n           FROM SYS_USER A, SYS_USER_ORG B, SYS_ORG C\r\n          WHERE A.USER_ID = B.USER_ID\r\n            AND B.ORG_ID = C.ORG_ID\r\n            AND A.ISDEL = 0\r\n            AND A.USER_TYPE = 0\r\n            AND C.ISDEL = 0 {0}\r\n            AND B.ORG_ID = D.ORG_ID\r\n            AND D.TYPE = '0')");
			string userType = string.Empty;
			if (!isAllowUserManyToOrg)
			{
				userType = "  AND B.USER_IDENTITY_TYPE = 1";
			}
			sqlUser = string.Format(sqlUser, userType, orgParam);
			sqlUserCount = string.Format(sqlUserCount, userType);
		}
		string sqlKey = "GetFirstLevelOrgUserTree";
		QueryResult<OrgDTO> orgQueryResult = SqlQuery<OrgDTO>(sqlKey, queryConditon, ParameterResolveRule.Empty, ValueResolveRule.Null, new string[3] { sqlUser, sqlUserCount, sqlOrg });
		return orgQueryResult.List;
	}

	private IList<OrgDTO> GetOrgUserTreeListFromDB(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf)
	{
		if (levelCount < 0)
		{
			return GetAllChildOrgUserTreeListFromDB(parentOrgId, isFindUser, isAllowUserManyToOrg, isIncludeSelf);
		}
		return GetLevelOrgUserTreeListFromDB(parentOrgId, levelCount, isFindUser, isAllowUserManyToOrg, isIncludeSelf);
	}
}
