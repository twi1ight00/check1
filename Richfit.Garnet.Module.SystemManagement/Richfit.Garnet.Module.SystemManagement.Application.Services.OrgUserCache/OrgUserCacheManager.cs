using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgManagement;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

/// <summary>
/// 用户组织机构树结构缓存管理类，用于组织机构和人员信息变动的时候同步缓存
/// </summary>
public class OrgUserCacheManager
{
	/// <summary>
	/// 获取组织结构人员缓存
	/// </summary>
	/// <returns></returns>
	public static IList<OrgDTO> GetOrgUserTreeCache()
	{
		IList<OrgDTO> listReturn = new List<OrgDTO>();
		IList<OrgDTO> changedList = null;
		OrgUserCacheLoader.SyncLocker.Read(delegate
		{
			listReturn = LocalCacheBus.Instance.Get("OrgUserTreeCacheKey") as IList<OrgDTO>;
			if (listReturn != null && SystemCacheBus.Instance.IsDistributed)
			{
				SystemCacheBus.Instance.Set($"OrgUserChangedCacheKey-{CacheConfig.CurrentServerIndex}", delegate(IList<OrgDTO> list)
				{
					if (list != null)
					{
						changedList = list.ToList();
						list.Clear();
					}
					return list;
				});
				RefreshCache(listReturn, changedList);
			}
		});
		return listReturn;
	}

	/// <summary>
	/// 将变化的二级缓存刷新到一级缓存
	/// </summary>
	/// <param name="listCache"></param>
	/// <param name="listChanged"></param>
	private static void RefreshCache(IList<OrgDTO> listCache, IList<OrgDTO> listChanged)
	{
		if (listChanged == null || !listChanged.Any())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			listChanged.ForEach(delegate(OrgDTO orgDTO)
			{
				if (orgDTO.TYPE == "0")
				{
					RefreshOrgCache(listCache, orgDTO);
				}
				else if (orgDTO.TYPE == "1")
				{
					RefreshUserCache(listCache, orgDTO);
				}
			});
		});
	}

	private static void RefreshUserCache(IList<OrgDTO> treeOrgList, OrgDTO orgDTO)
	{
		if (treeOrgList == null || orgDTO == null)
		{
			return;
		}
		if (orgDTO.DTOStatus.Equals(CacheObjectStatus.Add))
		{
			if (treeOrgList != null && treeOrgList.Any())
			{
				OrgDTO parent2 = treeOrgList.Where((OrgDTO x) => x.ORG_ID == orgDTO.ORG_ID).FirstOrDefault();
				if (parent2 != null)
				{
					OrgDTO child = treeOrgList.Where((OrgDTO x) => x.PARENT_ORG_ID == parent2.ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
					if (child != null)
					{
						treeOrgList.Insert(treeOrgList.IndexOf(child) + 1, orgDTO);
					}
					else
					{
						treeOrgList.Insert(treeOrgList.IndexOf(parent2) + 1, orgDTO);
					}
					parent2.USER_CHILD_COUNT += 1m;
				}
			}
		}
		else if (orgDTO.DTOStatus.Equals(CacheObjectStatus.Modify))
		{
			if (treeOrgList != null && treeOrgList.Any())
			{
				OrgDTO self2 = treeOrgList.Where((OrgDTO x) => x.ORG_ID == orgDTO.ORG_ID && x.PARENT_ORG_ID == orgDTO.PARENT_ORG_ID).FirstOrDefault();
				if (self2 != null)
				{
					if (self2.SORT != orgDTO.SORT)
					{
						OrgDTO child = treeOrgList.Where((OrgDTO x) => x.PARENT_ORG_ID == orgDTO.PARENT_ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
						treeOrgList.Insert(treeOrgList.IndexOf(child) + 1, orgDTO);
						treeOrgList.Remove(self2);
					}
					else
					{
						treeOrgList.Insert(treeOrgList.IndexOf(self2) + 1, orgDTO);
						treeOrgList.Remove(self2);
					}
				}
			}
		}
		else if (orgDTO.DTOStatus.Equals(CacheObjectStatus.Delete) && treeOrgList != null && treeOrgList.Any())
		{
			OrgDTO self = treeOrgList.Where((OrgDTO x) => x.ORG_ID == orgDTO.ORG_ID && x.PARENT_ORG_ID == orgDTO.PARENT_ORG_ID).FirstOrDefault();
			if (self != null)
			{
				OrgDTO parent = treeOrgList.Where(delegate(OrgDTO x)
				{
					Guid oRG_ID = x.ORG_ID;
					Guid? pARENT_ORG_ID = self.PARENT_ORG_ID;
					return oRG_ID == pARENT_ORG_ID;
				}).FirstOrDefault();
				if (parent != null)
				{
					--parent.USER_CHILD_COUNT;
				}
				treeOrgList.Remove(self);
			}
		}
		orgDTO.DTOStatus = CacheObjectStatus.None;
	}

	private static void RefreshOrgCache(IList<OrgDTO> treeOrgList, OrgDTO orgDTO)
	{
		if (treeOrgList == null || orgDTO == null)
		{
			return;
		}
		if (orgDTO.DTOStatus.Equals(CacheObjectStatus.Add))
		{
			if (treeOrgList.Any())
			{
				OrgDTO parent2 = treeOrgList.Where(delegate(OrgDTO x)
				{
					Guid oRG_ID2 = x.ORG_ID;
					Guid? pARENT_ORG_ID2 = orgDTO.PARENT_ORG_ID;
					return oRG_ID2 == pARENT_ORG_ID2;
				}).FirstOrDefault();
				if (parent2 != null)
				{
					OrgDTO child = treeOrgList.Where((OrgDTO x) => x.PARENT_ORG_ID == parent2.ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
					if (child != null)
					{
						treeOrgList.Insert(treeOrgList.IndexOf(child) + 1, orgDTO);
					}
					else
					{
						treeOrgList.Insert(treeOrgList.IndexOf(parent2) + 1, orgDTO);
					}
					parent2.ORG_CHILD_COUNT += 1m;
				}
			}
			else
			{
				orgDTO.PATH = $"\\{orgDTO.ORG_ID}";
				orgDTO.ORG_CHILD_COUNT = 0m;
				orgDTO.USER_CHILD_COUNT = 0m;
				treeOrgList.Add(orgDTO);
			}
		}
		else if (orgDTO.DTOStatus.Equals(CacheObjectStatus.Modify))
		{
			if (treeOrgList != null && treeOrgList.Any())
			{
				OrgDTO self2 = treeOrgList.Where((OrgDTO x) => x.ORG_ID == orgDTO.ORG_ID).FirstOrDefault();
				if (self2 != null)
				{
					if (self2.SORT != orgDTO.SORT)
					{
						OrgDTO child = treeOrgList.Where((OrgDTO x) => x.PARENT_ORG_ID == orgDTO.PARENT_ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
						treeOrgList.Insert(treeOrgList.IndexOf(child) + 1, orgDTO);
						treeOrgList.Remove(self2);
					}
					else
					{
						treeOrgList.Insert(treeOrgList.IndexOf(self2) + 1, orgDTO);
						treeOrgList.Remove(self2);
					}
				}
			}
		}
		else if (orgDTO.DTOStatus.Equals(CacheObjectStatus.Delete) && treeOrgList != null && treeOrgList.Any())
		{
			OrgDTO self = treeOrgList.Where((OrgDTO x) => x.ORG_ID == orgDTO.ORG_ID).FirstOrDefault();
			if (self != null)
			{
				OrgDTO parent = treeOrgList.Where(delegate(OrgDTO x)
				{
					Guid oRG_ID = x.ORG_ID;
					Guid? pARENT_ORG_ID = self.PARENT_ORG_ID;
					return oRG_ID == pARENT_ORG_ID;
				}).FirstOrDefault();
				if (parent != null)
				{
					--parent.ORG_CHILD_COUNT;
				}
				treeOrgList.Remove(self);
			}
		}
		orgDTO.DTOStatus = CacheObjectStatus.None;
	}

	/// <summary>
	/// 新增机构缓存
	/// </summary>
	/// <param name="sysOrgDTO"></param>
	public static void AddCache(SYS_ORGDTO sysOrgDTO)
	{
		if (sysOrgDTO == null || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
			if (orgUserTreeCache != null)
			{
				OrgDTO orgDTO = null;
				if (orgUserTreeCache.Any())
				{
					OrgDTO parent = orgUserTreeCache.Where(delegate(OrgDTO x)
					{
						Guid oRG_ID = x.ORG_ID;
						Guid? pARENT_ORG_ID = sysOrgDTO.PARENT_ORG_ID;
						return oRG_ID == pARENT_ORG_ID;
					}).FirstOrDefault();
					if (parent != null)
					{
						orgDTO = To(sysOrgDTO);
						orgDTO.PATH = $"{parent.PATH}\\{sysOrgDTO.ORG_ID}";
						OrgDTO orgDTO2 = orgUserTreeCache.Where((OrgDTO x) => x.PARENT_ORG_ID == parent.ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
						if (orgDTO2 != null)
						{
							orgUserTreeCache.Insert(orgUserTreeCache.IndexOf(orgDTO2) + 1, orgDTO);
						}
						else
						{
							orgUserTreeCache.Insert(orgUserTreeCache.IndexOf(parent) + 1, orgDTO);
						}
						parent.ORG_CHILD_COUNT += 1m;
					}
				}
				else
				{
					orgDTO = To(sysOrgDTO);
					orgDTO.PATH = $"\\{sysOrgDTO.ORG_ID}";
					orgDTO.ORG_CHILD_COUNT = 0m;
					orgDTO.USER_CHILD_COUNT = 0m;
					orgUserTreeCache.Add(orgDTO);
				}
				UpdateChangedList(orgDTO, CacheObjectStatus.Add);
			}
		});
	}

	/// <summary>
	/// 更新二级缓存记录的发生变动的列表
	/// </summary>
	/// <param name="orgDTO"></param>
	/// <param name="status"></param>
	private static void UpdateChangedList(OrgDTO orgDTO, CacheObjectStatus status)
	{
		if (orgDTO == null || status == CacheObjectStatus.None || !SystemCacheBus.Instance.IsDistributed)
		{
			return;
		}
		orgDTO.DTOStatus = status;
		for (int i = 0; i < CacheConfig.DistributedServerCount; i++)
		{
			if (i == CacheConfig.CurrentServerIndex)
			{
				continue;
			}
			SystemCacheBus.Instance.Set($"OrgUserChangedCacheKey-{i}", delegate(IList<OrgDTO> list)
			{
				if (list != null && list.Any())
				{
					list.Add(orgDTO);
				}
				else
				{
					list = new List<OrgDTO>();
					list.Add(orgDTO);
				}
				return list;
			});
		}
	}

	private static void UpdateChangedList(IList<OrgDTO> orgDTOList, CacheObjectStatus status)
	{
		if (orgDTOList == null || !orgDTOList.Any() || status == CacheObjectStatus.None || !SystemCacheBus.Instance.IsDistributed)
		{
			return;
		}
		orgDTOList.ForEach(delegate(OrgDTO x)
		{
			x.DTOStatus = status;
		});
		for (int i = 0; i < CacheConfig.DistributedServerCount; i++)
		{
			if (i == CacheConfig.CurrentServerIndex)
			{
				continue;
			}
			SystemCacheBus.Instance.Set($"OrgUserChangedCacheKey-{i}", delegate(IList<OrgDTO> list)
			{
				if (list != null && list.Any())
				{
					list.AddRange(orgDTOList);
				}
				else
				{
					list = new List<OrgDTO>();
					list.AddRange(orgDTOList);
				}
				return list;
			});
		}
	}

	/// <summary>
	/// 更新机构缓存
	/// </summary>
	/// <param name="sysOrgDTO"></param>
	public static void UpdateCache(SYS_ORGDTO sysOrgDTO)
	{
		if (sysOrgDTO == null || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
			if (orgUserTreeCache != null && orgUserTreeCache.Any())
			{
				OrgDTO self = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == sysOrgDTO.ORG_ID).FirstOrDefault();
				if (self != null)
				{
					OrgDTO orgDTO = null;
					if (self.SORT != sysOrgDTO.SORT)
					{
						orgDTO = To(sysOrgDTO);
						orgDTO.CHILD_COUNT = self.CHILD_COUNT;
						orgDTO.PATH = self.PATH;
						orgDTO.ORG_CHILD_COUNT = self.ORG_CHILD_COUNT;
						orgDTO.USER_CHILD_COUNT = self.USER_CHILD_COUNT;
						OrgDTO item = orgUserTreeCache.Where((OrgDTO x) => x.PARENT_ORG_ID == orgDTO.PARENT_ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
						orgUserTreeCache.Insert(orgUserTreeCache.IndexOf(item) + 1, orgDTO);
						orgUserTreeCache.Remove(self);
					}
					else
					{
						Update(sysOrgDTO, self);
						orgDTO = self;
					}
					UpdateChangedList(orgDTO, CacheObjectStatus.Modify);
					IList<OrgDTO> list = orgUserTreeCache.Where((OrgDTO x) => x.PARENT_ORG_ID == self.ORG_ID).ToList();
					if (list.Count != 0)
					{
						foreach (OrgDTO current in list)
						{
							current.PARENT_ORG_NAME = self.ORG_NAME;
							UpdateChangedList(current, CacheObjectStatus.Modify);
						}
					}
				}
			}
		});
	}

	/// <summary>
	/// 移除机构缓存
	/// </summary>
	/// <param name="sysOrgDTO"></param>
	public static void RemoveCache(SYS_ORGDTO sysOrgDTO)
	{
		if (sysOrgDTO == null || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
			if (orgUserTreeCache != null && orgUserTreeCache.Any())
			{
				OrgDTO self = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == sysOrgDTO.ORG_ID).FirstOrDefault();
				if (self != null)
				{
					OrgDTO orgDTO = orgUserTreeCache.Where(delegate(OrgDTO x)
					{
						Guid oRG_ID = x.ORG_ID;
						Guid? pARENT_ORG_ID = self.PARENT_ORG_ID;
						return oRG_ID == pARENT_ORG_ID;
					}).FirstOrDefault();
					if (orgDTO != null)
					{
						--orgDTO.ORG_CHILD_COUNT;
					}
					orgUserTreeCache.Remove(self);
					UpdateChangedList(self, CacheObjectStatus.Delete);
				}
			}
		});
	}

	/// <summary>
	/// 根据机构ID列表移除机构缓存
	/// </summary>
	/// <param name="sysOrgIDList"></param>
	public static void RemoveOrgCache(IList<Guid> sysOrgIDList)
	{
		if (sysOrgIDList == null || !sysOrgIDList.Any() || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> treeOrgList = GetOrgUserTreeCache();
			if (treeOrgList != null && treeOrgList.Any())
			{
				IList<OrgDTO> removeList = new List<OrgDTO>();
				sysOrgIDList.ForEach(delegate(Guid id)
				{
					OrgDTO self = treeOrgList.Where((OrgDTO x) => x.ORG_ID == id).FirstOrDefault();
					if (self != null)
					{
						OrgDTO orgDTO = treeOrgList.Where(delegate(OrgDTO x)
						{
							Guid oRG_ID = x.ORG_ID;
							Guid? pARENT_ORG_ID = self.PARENT_ORG_ID;
							return oRG_ID == pARENT_ORG_ID;
						}).FirstOrDefault();
						if (orgDTO != null)
						{
							--orgDTO.ORG_CHILD_COUNT;
						}
						treeOrgList.Remove(self);
						removeList.Add(self);
					}
				});
				UpdateChangedList(removeList, CacheObjectStatus.Delete);
			}
		});
	}

	/// <summary>
	/// 根据机构Id获取机构缓存对象
	/// </summary>
	/// <param name="orgId"></param>
	/// <returns></returns>
	public static SYS_ORGDTO GetOrgByKey(Guid orgId)
	{
		SYS_ORGDTO orgDTO = new SYS_ORGDTO();
		if (orgId != Guid.Empty)
		{
			if (OrgUserCacheLoader.IsCache())
			{
				OrgUserCacheLoader.SyncLocker.Read(delegate
				{
					IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
					if (orgUserTreeCache != null && orgUserTreeCache.Any())
					{
						OrgDTO orgDTO2 = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == orgId).FirstOrDefault();
						if (orgDTO2 != null)
						{
							orgDTO = ToOrgDTO(orgDTO2);
						}
					}
				});
			}
			else
			{
				IOrgAppService orgService = ServiceLocator.Instance.GetService<IOrgAppService>();
				orgDTO = orgService.GetOrgById(orgId);
			}
		}
		return orgDTO;
	}

	/// <summary>
	/// 获取机构级别，0是根节点，依次递增，出错返回-1
	/// </summary>
	/// <param name="orgId"></param>
	/// <returns></returns>
	public static int GetOrgLevel(Guid orgId)
	{
		int count = -1;
		if (orgId != Guid.Empty && OrgUserCacheLoader.IsCache())
		{
			OrgUserCacheLoader.SyncLocker.Read(delegate
			{
				IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
				if (orgUserTreeCache != null && orgUserTreeCache.Any())
				{
					OrgDTO orgDTO = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == orgId).FirstOrDefault();
					if (orgDTO != null)
					{
						count = orgDTO.PATH.CountChar('\\') - 1;
					}
				}
			});
		}
		return count;
	}

	/// <summary>
	/// 根据人员ID获取人员缓存对象
	/// </summary>
	/// <param name="userId"></param>
	/// <returns></returns>
	public static SYS_USERDTO GetUserByKey(Guid userId)
	{
		SYS_USERDTO userDTO = new SYS_USERDTO();
		if (userId != Guid.Empty)
		{
			if (OrgUserCacheLoader.IsCache())
			{
				OrgUserCacheLoader.SyncLocker.Read(delegate
				{
					IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
					if (orgUserTreeCache != null && orgUserTreeCache.Any())
					{
						OrgDTO orgDTO = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == userId && x.USER_IDENTITY_TYPE == 1m).FirstOrDefault();
						if (orgDTO != null)
						{
							userDTO = ToUserDTO(orgDTO);
						}
					}
				});
			}
			else
			{
				ISystemUserService userService = ServiceLocator.Instance.GetService<ISystemUserService>();
				userDTO = userService.GetUserById(userId);
			}
		}
		return userDTO;
	}

	/// <summary>
	/// 新增人员缓存
	/// </summary>
	/// <param name="sysUserDTO"></param>
	public static void AddCache(SYS_USERDTO sysUserDTO)
	{
		if (sysUserDTO == null || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
			if (orgUserTreeCache != null && orgUserTreeCache.Any())
			{
				OrgDTO parent = orgUserTreeCache.Where(delegate(OrgDTO x)
				{
					Guid oRG_ID = x.ORG_ID;
					Guid? oRG_ID2 = sysUserDTO.ORG_ID;
					return oRG_ID == oRG_ID2;
				}).FirstOrDefault();
				if (parent != null)
				{
					OrgDTO orgDTO = To(sysUserDTO);
					orgDTO.PATH = $"{parent.PATH}\\{sysUserDTO.USER_ID}";
					OrgDTO orgDTO2 = orgUserTreeCache.Where((OrgDTO x) => x.PARENT_ORG_ID == parent.ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
					if (orgDTO2 != null)
					{
						orgUserTreeCache.Insert(orgUserTreeCache.IndexOf(orgDTO2) + 1, orgDTO);
					}
					else
					{
						orgUserTreeCache.Insert(orgUserTreeCache.IndexOf(parent) + 1, orgDTO);
					}
					parent.USER_CHILD_COUNT += 1m;
					UpdateChangedList(orgDTO, CacheObjectStatus.Add);
				}
			}
		});
	}

	/// <summary>
	/// 修改人员缓存
	/// </summary>
	/// <param name="sysUserDTO"></param>
	public static void UpdateCache(SYS_USERDTO sysUserDTO)
	{
		if (sysUserDTO == null || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
			if (orgUserTreeCache != null && orgUserTreeCache.Any())
			{
				OrgDTO orgDTO2 = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == sysUserDTO.USER_ID && x.PARENT_ORG_ID == sysUserDTO.ORG_ID).FirstOrDefault();
				if (orgDTO2 != null)
				{
					OrgDTO orgDTO = null;
					if (orgDTO2.SORT != sysUserDTO.SORT)
					{
						orgDTO = To(sysUserDTO);
						orgDTO.CHILD_COUNT = orgDTO2.CHILD_COUNT;
						orgDTO.USER_IDENTITY_TYPE = orgDTO2.USER_IDENTITY_TYPE;
						orgDTO.PATH = orgDTO2.PATH;
						OrgDTO item = orgUserTreeCache.Where((OrgDTO x) => x.PARENT_ORG_ID == orgDTO.PARENT_ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
						orgUserTreeCache.Insert(orgUserTreeCache.IndexOf(item) + 1, orgDTO);
						orgUserTreeCache.Remove(orgDTO2);
					}
					else
					{
						Update(sysUserDTO, orgDTO2);
						orgDTO = orgDTO2;
					}
					UpdateChangedList(orgDTO, CacheObjectStatus.Modify);
				}
			}
		});
	}

	/// <summary>
	/// 移除人员缓存
	/// </summary>
	/// <param name="sysUserDTO"></param>
	public static void RemoveCache(SYS_USERDTO sysUserDTO)
	{
		if (sysUserDTO == null || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> orgUserTreeCache = GetOrgUserTreeCache();
			if (orgUserTreeCache != null && orgUserTreeCache.Any())
			{
				OrgDTO self = orgUserTreeCache.Where((OrgDTO x) => x.ORG_ID == sysUserDTO.USER_ID && x.PARENT_ORG_ID == sysUserDTO.ORG_ID).FirstOrDefault();
				if (self != null)
				{
					OrgDTO orgDTO = orgUserTreeCache.Where(delegate(OrgDTO x)
					{
						Guid oRG_ID = x.ORG_ID;
						Guid? pARENT_ORG_ID = self.PARENT_ORG_ID;
						return oRG_ID == pARENT_ORG_ID;
					}).FirstOrDefault();
					if (orgDTO != null)
					{
						--orgDTO.USER_CHILD_COUNT;
					}
					orgUserTreeCache.Remove(self);
					UpdateChangedList(self, CacheObjectStatus.Delete);
				}
			}
		});
	}

	/// <summary>
	/// 移除人员在指定机构下的缓存（根据人员和机构的对应关系）
	/// </summary>
	/// <param name="userOrgIds">用户ID和组织机构ID的Mapping结构</param>
	public static void RemoveUserCache(ListMapping<Guid, Guid> userOrgIds)
	{
		if (userOrgIds == null || !userOrgIds.Any() || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> treeOrgList = GetOrgUserTreeCache();
			if (treeOrgList != null && treeOrgList.Any())
			{
				IList<OrgDTO> removeList = new List<OrgDTO>();
				userOrgIds.ForEach(delegate(KeyValuePair<Guid, List<Guid>> idMapping)
				{
					Guid userId = idMapping.Key;
					List<Guid> value = idMapping.Value;
					value.ForEach(delegate(Guid orgId)
					{
						OrgDTO self = treeOrgList.Where((OrgDTO x) => x.ORG_ID == userId && x.PARENT_ORG_ID == orgId).FirstOrDefault();
						if (self != null)
						{
							OrgDTO orgDTO = treeOrgList.Where(delegate(OrgDTO x)
							{
								Guid oRG_ID = x.ORG_ID;
								Guid? pARENT_ORG_ID = self.PARENT_ORG_ID;
								return oRG_ID == pARENT_ORG_ID;
							}).FirstOrDefault();
							if (orgDTO != null)
							{
								--orgDTO.USER_CHILD_COUNT;
							}
							treeOrgList.Remove(self);
							removeList.Add(self);
						}
					});
				});
				UpdateChangedList(removeList, CacheObjectStatus.Delete);
			}
		});
	}

	/// <summary>
	/// 移除某人员在指定机构下的缓存
	/// </summary>
	/// <param name="userId">人员ID</param>
	/// <param name="orgIds">用户要移除的组织机构ID列表</param>
	public static void RemoveUserCache(Guid userId, IList<Guid> orgIds)
	{
		if (!(userId != Guid.Empty) || !orgIds.Any() || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> treeOrgList = GetOrgUserTreeCache();
			if (treeOrgList != null && treeOrgList.Any())
			{
				IList<OrgDTO> removeList = new List<OrgDTO>();
				orgIds.ForEach(delegate(Guid orgId)
				{
					OrgDTO self = treeOrgList.Where((OrgDTO x) => x.ORG_ID == userId && x.PARENT_ORG_ID == orgId).FirstOrDefault();
					if (self != null)
					{
						OrgDTO orgDTO = treeOrgList.Where(delegate(OrgDTO x)
						{
							Guid oRG_ID = x.ORG_ID;
							Guid? pARENT_ORG_ID = self.PARENT_ORG_ID;
							return oRG_ID == pARENT_ORG_ID;
						}).FirstOrDefault();
						if (orgDTO != null)
						{
							--orgDTO.USER_CHILD_COUNT;
						}
						treeOrgList.Remove(self);
						removeList.Add(self);
					}
				});
				UpdateChangedList(removeList, CacheObjectStatus.Delete);
			}
		});
	}

	/// <summary>
	/// 新增某人员在指定机构下的缓存
	/// </summary>
	/// <param name="userId">人员ID</param>
	/// <param name="orgIds">用户要新增的组织机构ID列表</param>
	public static void AddUserCache(Guid userId, IList<Guid> orgIds)
	{
		if (!(userId != Guid.Empty) || !orgIds.Any() || !OrgUserCacheLoader.IsCache())
		{
			return;
		}
		OrgUserCacheLoader.SyncLocker.Write(delegate
		{
			IList<OrgDTO> treeOrgList = GetOrgUserTreeCache();
			if (treeOrgList != null && treeOrgList.Any())
			{
				OrgDTO self = treeOrgList.Where((OrgDTO x) => x.ORG_ID == userId && x.USER_IDENTITY_TYPE == 1m).FirstOrDefault();
				if (self != null)
				{
					IList<OrgDTO> addList = new List<OrgDTO>();
					orgIds.ForEach(delegate(Guid orgId)
					{
						OrgDTO parent = treeOrgList.Where((OrgDTO x) => x.ORG_ID == orgId).FirstOrDefault();
						if (parent != null)
						{
							OrgDTO orgDTO = CopyUser(self);
							orgDTO.USER_IDENTITY_TYPE = 2m;
							orgDTO.PARENT_ORG_ID = parent.ORG_ID;
							orgDTO.PARENT_ORG_NAME = parent.ORG_NAME;
							orgDTO.PATH = $"{parent.PATH}\\{userId}";
							OrgDTO orgDTO2 = treeOrgList.Where((OrgDTO x) => x.PARENT_ORG_ID == parent.ORG_ID && x.SORT <= orgDTO.SORT).LastOrDefault();
							if (orgDTO2 != null)
							{
								treeOrgList.Insert(treeOrgList.IndexOf(orgDTO2) + 1, orgDTO);
							}
							else
							{
								treeOrgList.Insert(treeOrgList.IndexOf(parent) + 1, orgDTO);
							}
							parent.USER_CHILD_COUNT += 1m;
							addList.Add(orgDTO);
						}
					});
					UpdateChangedList(addList, CacheObjectStatus.Add);
				}
			}
		});
	}

	private static void Update(SYS_USERDTO source, OrgDTO distinct)
	{
		distinct.ORG_NAME = source.DISPLAY_NAME;
		distinct.PARENT_ORG_ID = source.ORG_ID;
		distinct.PARENT_ORG_NAME = source.ORG_NAME;
		distinct.SORT = source.SORT;
		distinct.USER_IDENTITY_TYPE = 1m;
		distinct.NOTE = source.NOTE;
		distinct.EXTEND1 = source.EXTEND1;
		distinct.EXTEND2 = source.EXTEND2;
		distinct.EXTEND3 = source.EXTEND3;
		distinct.EXTEND4 = source.EXTEND4;
		distinct.EXTEND5 = source.EXTEND5;
	}

	private static void Update(SYS_ORGDTO source, OrgDTO distinct)
	{
		distinct.ORG_NAME = source.ORG_NAME;
		distinct.PARENT_ORG_ID = source.PARENT_ORG_ID;
		distinct.PARENT_ORG_NAME = source.PARENT_ORG_NAME;
		distinct.SORT = source.SORT;
		distinct.USER_IDENTITY_TYPE = 1m;
		distinct.NOTE = source.NOTE;
		distinct.EXTEND1 = source.EXTEND1;
		distinct.EXTEND2 = source.EXTEND2;
		distinct.EXTEND3 = source.EXTEND3;
		distinct.EXTEND4 = source.EXTEND4;
		distinct.EXTEND5 = source.EXTEND5;
	}

	private static SYS_ORGDTO ToOrgDTO(OrgDTO sourceDTO)
	{
		SYS_ORGDTO distinctDTO = new SYS_ORGDTO();
		distinctDTO.ORG_ID = sourceDTO.ORG_ID;
		distinctDTO.ORG_NAME = sourceDTO.ORG_NAME;
		distinctDTO.PARENT_ORG_ID = sourceDTO.PARENT_ORG_ID;
		distinctDTO.PARENT_ORG_NAME = sourceDTO.PARENT_ORG_NAME;
		distinctDTO.SORT = sourceDTO.SORT;
		distinctDTO.NOTE = sourceDTO.NOTE;
		distinctDTO.EXTEND1 = sourceDTO.EXTEND1;
		distinctDTO.EXTEND2 = sourceDTO.EXTEND2;
		distinctDTO.EXTEND3 = sourceDTO.EXTEND3;
		distinctDTO.EXTEND4 = sourceDTO.EXTEND4;
		distinctDTO.EXTEND5 = sourceDTO.EXTEND5;
		return distinctDTO;
	}

	private static OrgDTO To(SYS_ORGDTO sourceDTO)
	{
		OrgDTO distinctDTO = new OrgDTO();
		distinctDTO.ORG_ID = sourceDTO.ORG_ID;
		distinctDTO.ORG_NAME = sourceDTO.ORG_NAME;
		distinctDTO.PARENT_ORG_ID = sourceDTO.PARENT_ORG_ID;
		distinctDTO.PARENT_ORG_NAME = sourceDTO.PARENT_ORG_NAME;
		distinctDTO.SORT = sourceDTO.SORT;
		distinctDTO.TYPE = "0";
		distinctDTO.USER_IDENTITY_TYPE = 1m;
		distinctDTO.CHILD_COUNT = 0m;
		distinctDTO.NOTE = sourceDTO.NOTE;
		distinctDTO.EXTEND1 = sourceDTO.EXTEND1;
		distinctDTO.EXTEND2 = sourceDTO.EXTEND2;
		distinctDTO.EXTEND3 = sourceDTO.EXTEND3;
		distinctDTO.EXTEND4 = sourceDTO.EXTEND4;
		distinctDTO.EXTEND5 = sourceDTO.EXTEND5;
		return distinctDTO;
	}

	private static SYS_USERDTO ToUserDTO(OrgDTO sourceDTO)
	{
		SYS_USERDTO distinctDTO = new SYS_USERDTO();
		distinctDTO.USER_ID = sourceDTO.ORG_ID;
		distinctDTO.DISPLAY_NAME = sourceDTO.ORG_NAME;
		distinctDTO.ORG_ID = sourceDTO.PARENT_ORG_ID;
		distinctDTO.ORG_NAME = sourceDTO.PARENT_ORG_NAME;
		distinctDTO.SORT = sourceDTO.SORT;
		distinctDTO.USER_IDENTITY_TYPE = 1m;
		distinctDTO.NOTE = sourceDTO.NOTE;
		distinctDTO.EXTEND1 = sourceDTO.EXTEND1;
		distinctDTO.EXTEND2 = sourceDTO.EXTEND2;
		distinctDTO.EXTEND3 = sourceDTO.EXTEND3;
		distinctDTO.EXTEND4 = sourceDTO.EXTEND4;
		distinctDTO.EXTEND5 = sourceDTO.EXTEND5;
		return distinctDTO;
	}

	private static OrgDTO CopyUser(OrgDTO sourceDTO)
	{
		OrgDTO distinctDTO = new OrgDTO();
		distinctDTO.ORG_ID = sourceDTO.ORG_ID;
		distinctDTO.ORG_NAME = sourceDTO.ORG_NAME;
		distinctDTO.PARENT_ORG_ID = sourceDTO.PARENT_ORG_ID;
		distinctDTO.PARENT_ORG_NAME = sourceDTO.PARENT_ORG_NAME;
		distinctDTO.TYPE = sourceDTO.TYPE;
		distinctDTO.CHILD_COUNT = sourceDTO.CHILD_COUNT;
		distinctDTO.ORG_CHILD_COUNT = sourceDTO.ORG_CHILD_COUNT;
		distinctDTO.USER_CHILD_COUNT = sourceDTO.USER_CHILD_COUNT;
		distinctDTO.SORT = sourceDTO.SORT;
		distinctDTO.USER_IDENTITY_TYPE = sourceDTO.USER_IDENTITY_TYPE;
		distinctDTO.NOTE = sourceDTO.NOTE;
		distinctDTO.EXTEND1 = sourceDTO.EXTEND1;
		distinctDTO.EXTEND2 = sourceDTO.EXTEND2;
		distinctDTO.EXTEND3 = sourceDTO.EXTEND3;
		distinctDTO.EXTEND4 = sourceDTO.EXTEND4;
		distinctDTO.EXTEND5 = sourceDTO.EXTEND5;
		return distinctDTO;
	}

	private static OrgDTO To(SYS_USERDTO sourceDTO)
	{
		OrgDTO distinctDTO = new OrgDTO();
		distinctDTO.ORG_ID = sourceDTO.USER_ID;
		distinctDTO.ORG_NAME = sourceDTO.DISPLAY_NAME;
		distinctDTO.PARENT_ORG_ID = sourceDTO.ORG_ID;
		distinctDTO.PARENT_ORG_NAME = sourceDTO.ORG_NAME;
		distinctDTO.SORT = sourceDTO.SORT;
		distinctDTO.TYPE = "1";
		distinctDTO.USER_IDENTITY_TYPE = 1m;
		distinctDTO.CHILD_COUNT = 0m;
		distinctDTO.NOTE = sourceDTO.NOTE;
		distinctDTO.EXTEND1 = sourceDTO.EXTEND1;
		distinctDTO.EXTEND2 = sourceDTO.EXTEND2;
		distinctDTO.EXTEND3 = sourceDTO.EXTEND3;
		distinctDTO.EXTEND4 = sourceDTO.EXTEND4;
		distinctDTO.EXTEND5 = sourceDTO.EXTEND5;
		return distinctDTO;
	}
}
