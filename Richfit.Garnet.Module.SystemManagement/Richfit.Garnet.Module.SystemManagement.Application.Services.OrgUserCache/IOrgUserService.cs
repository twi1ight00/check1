using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

/// <summary>
/// 组织机构人员层级树的服务.
/// </summary>
/// <remarks>
/// 组织机构人员层级树的服务,方法有获取树列表信息,获取组织结构或组织机构及人员信息.
/// </remarks>
/// <example>
/// <code language="cs"><![CDATA[
/// private IOrgUserService orgUserService = ServiceLocator.Instance.GetService<IOrgUserService>();
/// ]]></code>
/// </example>
/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.OrgDTO">用户和组织机构缓存类</seealso>
public interface IOrgUserService
{
	/// <summary>
	/// 查找组织机构和人员Tree数据，直接返回TREE_NODE类型
	/// </summary>
	/// <param name="parentOrgId">父组织机构ID</param>
	/// <param name="levelCount">查找层级数量(-1全部层级，其它查找层级数量跟数字对应)</param>
	/// <param name="isFindUser">是否查找用户信息</param>
	/// <param name="isAllowUserManyToOrg">是否允许用户挂在多个组织机构下</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <param name="checkList">要求选中的树的节点的ID列表</param>
	/// <returns>返回TREE_NODE列表的组织机构及人员数据</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\Application\Services\RoleManagement\RoleAppService.cs" region="Example.QuerySubOrgAndUserTree.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE> GetOrgUserTree(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf, IList<Guid> checkList);

	/// <summary>
	/// 查找组织机构和人员Tree数据，直接返回TREE_NODE&lt;T&gt;类型
	/// </summary>
	/// <typeparam name="T">TreeNode 节点ID的类型</typeparam>
	/// <param name="parentOrgId">父组织机构ID</param>
	/// <param name="levelCount">查找层级数量(-1全部层级，其它查找层级数量跟数字对应)</param>
	/// <param name="isFindUser">是否查找用户信息</param>
	/// <param name="isAllowUserManyToOrg">是否允许用户挂在多个组织机构下</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <param name="checkList">要求选中的树的节点的ID列表</param>
	/// <returns>返回TREE_NODE列表的组织机构及人员数据</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\OrgHandler.cs" region="Example.GetOrgTree.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE<T>> GetOrgUserTree<T>(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf, IList<T> checkList) where T : struct;

	/// <summary>
	/// 查找组织机构和人员Tree数据，直接返回DTO类型
	/// </summary>
	/// <param name="parentOrgId">父组织机构ID</param>
	/// <param name="levelCount">查找层级数量(-1全部层级，其它查找层级数量跟数字对应)</param>
	/// <param name="isFindUser">是否查找用户信息</param>
	/// <param name="isAllowUserManyToOrg">是否允许用户挂在多个组织机构下</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <returns>返回OrgDTO列表的组织机构及人员数据</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\OrgHandler.cs" region="Example.GetOrgList.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.OrgDTO">用户和组织机构缓存类</seealso>
	IList<OrgDTO> GetOrgUserTreeList(Guid? parentOrgId, int levelCount, bool isFindUser, bool isAllowUserManyToOrg, bool isIncludeSelf);

	/// <summary>
	/// 根据给定的用户ID反查只包含用户的组织机构树
	/// </summary>
	/// <param name="userIds">用户ID列表</param>
	/// <param name="isAllowUserManyToOrg">是否允许用户挂在多个组织机构下</param>        
	/// <returns>返回TREE_NODE列表的组织机构及人员数据</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.Workflow\Application\Services\ParticipantService.cs" region="Example.GetActivityParticipantOrgAndUser.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE> GetOrgUserTreeByUser(IList<Guid> userIds, bool isAllowUserManyToOrg = false);

	/// <summary>
	/// 查找某组织机构及所有下级机构
	/// </summary>
	/// <param name="parentOrgId">父组织机构ID</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <returns>返回OrgDTO列表的组织机构及所有下级机构</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\Application\Services\RoleManagement\RoleAppService.cs" region="Example.RoleDistributeSubOrg.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.OrgDTO">用户和组织机构缓存类</seealso>
	IList<OrgDTO> GetOrgAndAllChildren(Guid? parentOrgId, bool isIncludeSelf);

	/// <summary>
	/// 加载机构用户树缓存数据
	/// </summary>        
	/// <returns>返回机构及用户缓存数据</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\Application\Services\OrgUserCache\OrgUserCacheLoader.cs" region="Example.GetOrgUserTreeCache.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.OrgDTO">用户和组织机构缓存类</seealso>
	IList<OrgDTO> LoadOrgUserTreeCacheData();
}
