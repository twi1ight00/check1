using System;
using System.Collections.Generic;
using System.IO;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO.Parameters;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;

/// <summary>
/// 用户接口.
/// </summary>
/// <remarks>
/// 用户接口的功能：信息的新增，修改，删除，查询，兼管机构，分配角色，用户的启用和禁用。
/// </remarks>
/// <example>
/// <code language="cs"><![CDATA[
///  private ISystemUserService userAppService = ServiceLocator.Instance.GetService<ISystemUserService>();
/// ]]></code>
/// </example>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USERDTO">用户DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.Base.Application.DTO.TREE_NODE">树结构DTO对象</seealso>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USER_BUSINESSDTO">用户业务组DTO对象</seealso>
public interface ISystemUserService
{
	/// <summary>
	/// 创建用户
	/// </summary>
	/// <remarks>
	/// 新增用户信息到用户表里，同时新增用户所属组织机构,并同时把新增人员更新缓存.
	/// </remarks>
	/// <param name="userDTO">用户信息DTO对象</param>
	/// <returns>返回新增用户DTO对象</returns>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">IsValid方法验证roleDTO对象，验证有错误则抛出异常</exception>
	/// <exception cref="T:Richfit.Garnet.Common.AOP.Handler.CustomCodeException">如果域用户不存在，则抛出域用户验证失败,请确保帐号是否正确的异常提示</exception>
	/// <exception cref="T:Richfit.Garnet.Common.AOP.Handler.CustomCodeException">如果用户帐号重复，则抛出用户对应的域中已经存在重复帐号的异常提示</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\UserHandler.cs" region="Example.AddUser.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USERDTO">用户DTO对象</seealso>
	SYS_USERDTO AddUser(SYS_USERDTO userDTO);

	/// <summary>
	/// 更新用户
	/// </summary>
	/// <remarks>
	/// 更新用户，同时更新人员缓存.
	/// </remarks>
	/// <param name="userDTO">用户信息DTO对象</param>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">如果更新的DTO对象中主键为空，则抛出UpdateUser方法参数不能为空的异常提示！</exception>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">如果从数据库中返回的POCO对象为空，则抛出不存在相关的实体对象的异常提示！</exception>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">IsValid方法验证roleDTO对象，验证有错误则抛出异常</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\UserHandler.cs" region="Example.UpdateUser.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USERDTO">用户DTO对象</seealso>
	void UpdateUser(SYS_USERDTO userDTO);

	void UpdateExtendOne(SYS_USERDTO userDTO);

	/// <summary>
	/// 逻辑批量删除用户表信息和用户对应的缓存信息
	/// </summary>
	/// <remarks>
	/// <para>删除用户分两种1、本组织机构创建用户，2、兼管机构用户</para>
	/// <list type="bullet">
	/// <item>
	/// <description>1.1本组织机构创建用户：
	///  删除本组织机构创建用户：
	///  a.逻辑删除用户信息.
	///  b.删除用户组织机构关系映射表.
	///  c.删除用户角色关系表.
	/// </description>
	/// </item>
	/// <item>
	/// <description>1.2兼管机构用户：
	/// 删除兼管机构用户：
	/// a、删除用户组织机构关系映射表.
	/// b、删除用户角色关系表.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	/// <param name="userOrgIds">用户与组织机构ID(形式为用','隔开的字符串，用户ID和组织机构ID之间';'分割)</param>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">如果用户已分配机构，则抛用户已分配机构不能删除的异常提示！</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\UserHandler.cs" region="Example.RemoveUser.1">
	/// </code>
	/// </example>
	void RemoveUser(string userOrgIds);

	/// <summary>
	/// 根据用户ID获取用户信息
	/// </summary>
	/// <param name="userId">用户ID</param>
	/// <returns>返回用户信息DTO对象</returns>
	SYS_USERDTO GetUserById(Guid userId);

	/// <summary>
	/// 根据用户ID获取用户信息
	/// </summary>
	/// <param name="userId">用户ID</param>
	/// <returns>返回用户信息DTO对象</returns>
	SYS_USERINFODTO GetUserByToken();

	/// <summary>
	/// 根据用户域ID和域帐号获取用户名称
	/// </summary>
	/// <param name="domainId">域ID</param>
	/// <param name="domainAccount">域帐号</param>
	/// <returns>返回用户名称</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\UserHandler.cs" region="Example.GetDomainUserName.1">
	/// </code>
	/// </example>
	string GetDomainUserName(Guid domainId, string domainAccount);

	/// <summary>
	/// 获取用户列表信息
	/// </summary>
	/// <remarks>
	/// <para>查询条件表达式queryCondition包含查询条件项描述：</para>
	/// <list type="bullet">
	/// <item>
	/// <description>ORG_ID:组织机构ID</description>
	/// </item>
	/// <item>
	/// <description>Culture:语种名如zh-CN</description>
	/// </item>
	/// <item>
	/// <description>IS_CREATE_BY_SELF_ORG:包含下级,Value为1查本级及下级，为0查本级</description>
	/// </item>
	/// <item>
	/// <description>LOGON_NAME:用户帐号</description>
	/// </item>
	/// <item>
	/// <description>DISPLAY_NAME:用户名</description>
	/// </item>
	/// <item>
	/// <description>IS_FORBIDDEN:是否禁用，Value为1禁用，0为启用</description>
	/// </item>
	/// </list>
	/// </remarks>
	/// <param name="queryCondition">查询条件集合</param>
	/// <returns>返回用户列表</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\UserHandler.cs" region="Example.QueryUserList.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_USERDTO">用户DTO对象</seealso>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryCondition">查询条件表达式</seealso>
	/// <seealso cref="T:Richfit.Garnet.Module.Base.Infrastructure.Data.Query.QueryResult">返回结果公用类</seealso>
	QueryResult<SYS_USERDTO> QueryUserList(QueryCondition queryCondition);

	/// <summary>
	/// 修改用户密码
	/// </summary>
	/// <param name="userId">需要修改的用户Id</param>
	/// <param name="passWord"></param>
	/// <param name="newPassword">修改后的新密码</param>
	void UpdateUserPassword(Guid userId, string passWord, string newPassword);

	/// <summary>
	/// 用户分配角色
	/// </summary>
	/// <param name="userId">用户编号</param>
	/// <param name="roleOrgIds">角色ID和机构ID对应的结构（多个）每一个角色ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	void UserDistributeRoles(SYS_USER_ROLE_SAVE_PARM userRoleList);

	/// <summary>
	/// 用户分配角色
	/// </summary>
	/// <param name="userId">用户编号</param>
	/// <param name="roleOrgIds">角色ID和机构ID对应的结构（多个）每一个角色ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	/// <param name="forbiddenBusinessOrgIds">用户被禁用的业务Id和机构Id对应结构（多个）每一个业务ID和机构ID之间分号分隔，多个之间逗号分隔</param>
	void UserDistributeRoles(Guid userId, string roleOrgIds, string forbiddenBusinessOrgIds);

	/// <summary>
	/// 查看用户拥有角色信息 带组织单位关系条件
	/// </summary>
	/// <param name="userId">用户id</param>
	/// <returns>用户拥有角色信息 带组织单位关系条件</returns>
	IList<TREE_NODE> QueryOrgRoleTree(Guid userId);

	/// <summary>
	/// 查询用户可分派的组织机构树
	/// </summary>
	/// <param name="UserId">用户编号</param>
	/// <param name="OrgId">机构编号</param>
	/// <param name="levelCount">查找层级数量</param>
	/// <param name="isIncludeSelf">是否将本级返回</param>
	/// <returns>可分派的组织机构树</returns>
	IList<TREE_NODE> QueryDistributableOrgTree(Guid UserId, Guid? OrgId, int levelCount, bool isIncludeSelf);

	/// <summary>
	/// 用户分配组织机构保存
	/// </summary>
	/// <param name="userId">用户UserID</param>
	/// <param name="orgIds">逗号分隔的机构ID字符串</param>
	void UserDistributeOrg(Guid userId, string orgIds);

	/// <summary>
	/// 复制用户角色
	/// </summary>
	/// <param name="sourceUserIds">原用户编号，逗号分隔</param>
	/// <param name="destinationUserIds">目标用户编号，逗号分隔</param>
	/// <param name="orgId">人员所属机构编号</param>
	void UserRolesCopy(string sourceUserIds, string destinationUserIds, Guid orgId);

	/// <summary>
	/// 禁用用户
	/// </summary>
	/// <param name="userIds">用户ID(形式为用','隔开的字符串)</param>
	void ForbiddenUser(string userIds);

	/// <summary>
	/// 启用用户
	/// </summary>
	/// <param name="userIds">用户ID(形式为用','隔开的字符串)</param>
	void EnableUserUser(string userIds);

	/// <summary>
	/// 获得用户被禁用的业务
	/// </summary>
	/// <param name="userId"></param>
	/// <returns></returns>
	IList<SYS_USER_BUSINESSDTO> GetUserForbiddenBusinessIds(Guid userId);

	/// <summary>
	/// 查询用户拥有角色列表
	/// </summary>
	/// <param name="userId">用户ID</param>
	/// <param name="orgId">组织机构ID</param>
	/// <returns>用户拥有角色信息</returns>
	/// <inheritdoc />
	IList<SYS_USER_ROLE> QueryRoleListByUserId(Guid userId, Guid orgId);

	/// <summary>
	/// 导入人员信息
	/// </summary>
	/// <param name="input"></param>
	/// <param name="data"></param>
	Stream ImportUser(Stream inputStream);

	/// <summary>
	/// 获取用户的角色列表
	/// </summary>
	/// <param name="userId"></param>
	/// <param name="orgId"></param>
	/// <returns></returns>
	IList<SYS_USER_ROLEDTO> GetUserRoleById(Guid userId, Guid orgId);

	bool IsExistAccount(string logonName, Guid domainId);

	IList<SYS_ORGDTO> GetOrgByUser(SYS_USER user);

	IList<SYS_USER_ROLEDTO> GetUserRoleOrg(SYS_USER_ROLE user);

	void SaveUserRole(USER_ROLE_PARM userRoleParm);

	UserDTO GetUserBySapId(string sapId);

	void AddUserFromIAM(string sapId, Dictionary<string, string> attributes);

	void RemoveUserFromIAM(Guid userId);
}
