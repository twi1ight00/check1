using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.RoleManagement;

/// <summary>
/// 角色接口.
/// </summary>
/// <remarks>
/// 角色接口,角色分私有角色和共享角色,私有角色意思是角色是建立在某个组织机构下，共享角色是跟组织机构没关系的一类角色，在业务系统中两者只用其一。
/// 角色接口的功能：信息的新增，修改，删除，查询，权限分配，用户分配，角色分配到下级机构，获取流程信息。
/// </remarks>
/// <example>
/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\Application\Services\RoleManagement\RoleServiceFactory.cs" region="Example.GetRoleService.1">
/// </code>
/// </example>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ROLEDTO">角色DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ORGDTO">组织机构DTO对象</seealso>
public interface IRoleAppService
{
	/// <summary>
	/// 新增角色
	/// </summary>
	/// <remarks>
	/// 新增角色信息到角色表里，另外，对于私有角色新增角色跟组织机构的关系，共享角色不用新增角色跟组织机构的关系.
	/// </remarks>
	/// <param name="roleDTO">角色DTO对象</param>
	/// <returns>返回新增角色DTO对象</returns>
	/// <exception cref="T:System.ArgumentException">IsValid方法验证roleDTO对象，验证有错误则抛出异常</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.AddRole.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ROLEDTO">角色DTO对象</seealso>
	SYS_ROLEDTO AddRole(SYS_ROLEDTO roleDTO);

	/// <summary>
	/// 更新角色信息
	/// </summary>
	/// <param name="roleDTO">角色信息DTO对象</param>
	/// <exception cref="T:System.ArgumentException">角色DTO对象为空或角色ID属性为空，UpdateRole方法参数不能为空</exception>
	/// <exception cref="T:System.ArgumentException">IsValid方法验证roleDTO对象，验证有错误则抛出异常</exception>
	/// <exception cref="T:System.ArgumentException">通过主键返回的实体不存在，提示数据库中没有要更新的记录</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.UpdateRole.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ROLEDTO">角色DTO对象</seealso>
	void UpdateRole(SYS_ROLEDTO roleDTO);

	/// <summary>
	/// 删除角色和删除角色对应的缓存信息
	/// </summary>
	/// <remarks>
	/// <para>删除角色接口实现有两个Service：1、共享角色RoleService，2、私有角色RoleAppService</para>
	/// <list type="bullet">
	/// <item>
	/// <description>1.1共享角色：
	///  删除共享角色只有一种情况：
	///  a.角色表的角色信息进行逻辑删除，同时物理删除角色和权限关系.
	/// </description>
	/// </item>
	/// <item>
	/// <description>1.2私有角色：
	/// 删除私有角色分两种情况：
	/// a、本级创建角色删除，角色表的角色信息进行逻辑删除，同时物理删除角色和权限关系，物理删除角色和用户关系，物理删除角色和机构关系.
	/// b、继承角色删除，物理删除继承角色和用户关系，物理删除继承角色和机构关系.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	/// <param name="roleOrgIds">角色与组织机构ID(形式为用','隔开的字符串，角色ID和组织机构ID之间';'分割)</param>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">如果角色已分配人，则抛角色已分配人不能删除的异常提示！</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.RemoveRole.1">
	/// </code>
	/// </example>
	void RemoveRole(string roleOrgIds);

	/// <summary>
	/// 分配角色到下级机构
	/// </summary>
	/// <remarks>
	/// 分配角色到下级机构(只有私有角色具有这个功能)，在角色和组织机构关系表中，先删除分配的角色和组织机构的关系，再新增新的分配的角色和组织机构的关系
	/// </remarks>
	/// <param name="roleId">角色ID</param>
	/// <param name="orgIds">分配的组织机构ID，逗号分隔</param>
	/// <param name="sourceOrgId">源组织结构ID</param>
	/// <param name="usingOrgId">使用组织结构ID</param>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.RoleDistributeSubOrg.1">
	/// </code>
	/// </example>
	void RoleDistributeSubOrg(Guid roleId, string orgIds, Guid sourceOrgId, Guid usingOrgId);

	/// <summary>
	/// 分配用户
	/// </summary>
	/// <remarks>
	/// 分配用户，同时更新用户和业务组的缓存，先在人员角色对应关系表中删除该机构及以下的该角色的数据,然后新增相应的数据.
	/// </remarks>
	/// <param name="roleId">角色ID</param>
	/// <param name="orgId">角色所在的组织机构ID</param>
	/// <param name="userOrgIds">用户ID和机构ID对应的结构（多个）每一个用户ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.RoleDistributeUser.1">
	/// </code>
	/// </example>
	void RoleDistributeUser(Guid roleId, Guid orgId, string userOrgIds);

	/// <summary>
	/// 批量初始化分配用户
	/// </summary>
	/// <remarks>
	/// 批量初始化分配用户，同时更新用户和业务组的缓存，先在人员角色对应关系表中删除该机构及以下的该角色的数据,然后新增相应的数据.
	/// </remarks>
	/// <param name="roleIds">角色ID列表</param>
	/// <param name="userOrgIds">用户ID和机构ID对应的结构（多个）每一个用户ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	void BatchRoleDistributeUser(string roleIds, string userOrgIds);

	/// <summary>
	/// 分配权限
	/// </summary>
	/// <remarks>
	/// 分配权限，删除缓存(移除用户的权限),先删除角色和业务组的权限关系，在新增角色和业务组的权限关系
	/// </remarks>
	/// <param name="roleID">角色ID</param>
	/// <param name="businessIDs">业务权限ID</param>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.PrivilegeDistribute.1">
	/// </code>
	/// </example>
	void PrivilegeDistribute(Guid roleID, List<Guid> businessIDs);

	/// <summary>
	/// 查询角色
	/// </summary>
	/// <remarks>
	/// <para>queryCondition包含查询条件项描述：</para>
	/// <list type="bullet">
	/// <item>
	/// <description>ORG_ID:组织机构ID</description>
	/// </item>
	/// <item>
	/// <description>ROLE_NAME:角色名称</description>
	/// </item>
	/// <item>
	/// <description>IS_CREATE_BY_SELF_ORG:归属,Value为1查本级创建，为0查继承角色，为""查全部</description>
	/// </item>
	/// <item>
	/// <description>ISINCLUDESUBORG:包含下级,Value为1查本级及下级，为0查本级</description>
	/// </item>
	/// </list>
	/// </remarks>
	/// <param name="queryCondition">查询条件集合</param>
	/// <returns>返回角色列表</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.QueryRoleListBySql.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ROLEDTO">角色DTO对象</seealso>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition">查询条件集合</seealso>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult">返回结果公用类</seealso>
	QueryResult<SYS_ROLEDTO> QueryRoleList(QueryCondition queryCondition);

	/// <summary>
	/// 获取角色拥有的权限
	/// </summary>
	/// <param name="roleID">角色ID</param>
	/// <returns>获取角色拥有的权限</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.QueryRolePivilege.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE<Guid>> QueryRolePivilege(Guid roleID);

	/// <summary>
	/// 获取角色拥有的权限
	/// </summary>
	/// <param name="roleID">角色ID</param>
	/// <returns>获取角色拥有的权限</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.QueryDistributeRolePivilege.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE<Guid>> QueryDistributeRolePivilege(Guid roleID);

	/// <summary>
	/// 获取组织机构以及组织机构(含下级)下的用户
	/// </summary>
	/// <param name="roleId">角色ID</param>
	/// <param name="orgId">组织机构ID</param>
	/// <param name="levelCount">查找层级数量</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <returns>返回组织机构以及组织机构(含下级)下的用户</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.QueryDistributableOrgUserTree.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE> QuerySubOrgAndUserTree(Guid roleId, Guid orgId, int levelCount, bool isIncludeSelf);

	/// <summary>
	/// 查询角色可分配的机构树
	/// </summary>
	/// <param name="roleId">角色ID</param>
	/// <param name="orgId">角色所属的组织机构ID</param>
	/// <param name="levelCount">查找层级数量(-1全部层级，其它查找层级数量跟数字对应)</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <returns>返回组织机构以及下级组织机构</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.QueryDistributableSubOrgTree.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE> QueryDistributableSubOrgTree(Guid roleId, Guid orgId, int levelCount, bool isIncludeSelf);

	/// <summary>
	/// 获取用户可以发起流程的机构范围
	/// </summary>
	/// <remarks>
	/// <para>queryCondition包含查询条件项描述：</para>
	/// <list type="bullet">
	/// <item>
	/// <description>USER_ID:当前用户ID</description>
	/// </item>
	/// <item>
	/// <description>ROLE_IDS:角色ID 集合，以逗号分隔的角色ID</description>
	/// </item>
	/// </list>
	/// </remarks>
	/// <param name="queryCondition">查询条件集合</param>
	/// <returns>返回用户可以发起流程的机构DTO列表</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.GetWorkflowParticipantOrg.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ORGDTO">组织机构DTO</seealso>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition">查询条件集合</seealso>
	IList<SYS_ORGDTO> GetWorkflowParticipantOrg(QueryCondition queryCondition);

	/// <summary>
	/// 获取流程节点的参与人
	/// </summary>
	/// <remarks>
	/// <para>queryCondition包含查询条件项描述：</para>
	/// <list type="bullet">
	/// <item>
	/// <description>ORG_ID:流程发起机构</description>
	/// </item>
	/// <item>
	/// <description>NORMAL_ROLE_IDS：私有角色ID 集合，以逗号分隔的角色ID</description>
	/// </item>
	/// <item>
	/// <description>GLOBAL_ROLE_IDS：全局角色ID 集合，以逗号分隔的角色ID</description>
	/// </item>
	/// </list>
	/// </remarks>
	/// <param name="queryCondition">查询条件集合</param>
	/// <returns>返回流程节点的参与人的用户DTO列表</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.GetWorkflowParticipant.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USERDTO">组织机构DTO</seealso>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition">查询条件集合</seealso>
	IList<SYS_USERDTO> GetWorkflowParticipant(QueryCondition queryCondition);

	/// <summary>
	/// 根据角色ID查询角色对应的业务树
	/// </summary>
	/// <remarks>
	/// 返回的TREE_NODE结果中注意TYPE的值，业务树中节点的TYPE，"0"是菜单，"1"是功能
	/// </remarks>
	/// <param name="roleId"></param>
	/// <returns>返回业务组的TREE_NODE的DTO列表</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\RoleHandler.cs" region="Example.QueryBusinessTreeByRole.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构基类</seealso>
	IList<TREE_NODE<Guid>> QueryBusinessTreeByRole(Guid roleId);

	/// <summary>
	/// 根据角色Id（可多个）查询对应的业务
	/// </summary>        
	/// <param name="roleIds">多个角色Id，逗号分隔</param>
	/// <returns>返回业务组DTO列表</returns> 
	/// <example>
	/// <code language="cs">
	/// IRoleAppService roleAppService = RoleServiceFactory.GetRoleService();
	/// handlerResult.Data = roleAppService.QueryBusinessByRoleIds(roleIds).JsonSerialize();
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.Fundation.Application.DTO.BusinessDTO">业务组(菜单)DTO</seealso>
	IList<BusinessDTO> QueryBusinessByRoleIds(string roleIds);

	/// <summary>
	/// 根据ID获取角色信息
	/// </summary>
	/// <param name="roleID"></param>
	/// <returns></returns>
	SYS_ROLEDTO GetRoleByKey(Guid roleID);

	IList<SYS_ROLEDTO> GetWorkflowRoleByUser(Guid userId);

	IList<SYS_ROLEDTO> GetRoleByUser(Guid guid);

	IList<SYS_USERDTO> GetUserListByRoleId(Guid roleId);
}
