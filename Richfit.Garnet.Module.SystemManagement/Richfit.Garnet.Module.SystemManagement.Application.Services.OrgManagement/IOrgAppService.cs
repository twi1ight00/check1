using System;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.OrgManagement;

/// <summary>
/// 组织机构接口.
/// </summary>
/// <remarks>
/// 组织机构信息的新增，修改，删除，查询.
/// </remarks>
/// <example>
/// <code language="cs"><![CDATA[
///  private IOrgAppService orgAppService = ServiceLocator.Instance.GetService<IOrgAppService>();
/// ]]></code>
/// </example>
/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ORGDTO">组织机构类</seealso>
public interface IOrgAppService
{
	/// <summary>
	/// 新增组织机构
	/// </summary>
	/// <param name="orgDTO">组织机构DTO对象</param>
	/// <returns>返回新增组织机构信息</returns>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">IsValid方法验证ORGDTO对象，验证有错误则抛出异常</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\OrgHandler.cs" region="Example.AddOrg.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ORGDTO">组织机构DTO对象</seealso>
	SYS_ORGDTO AddOrg(SYS_ORGDTO orgDTO);

	/// <summary>
	/// 编辑组织机构信息
	/// </summary>
	/// <param name="orgDTO">编辑组织机构信息</param>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">IsValid方法验证ORGDTO对象，验证有错误则抛出异常</exception>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">通过主键返回的实体不存在，提示数据库中没有要更新的记录</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\OrgHandler.cs" region="Example.UpdateOrg.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ORGDTO">组织机构DTO对象</seealso>
	void UpdateOrg(SYS_ORGDTO orgDTO);

	/// <summary>
	/// 删除组织机构
	/// </summary>
	/// <remarks>
	/// 逻辑删除组织机构，同时物理删除组织机构对应的角色
	/// </remarks>
	/// <param name="orgDTOId">组织机构Id集合，逗号分隔</param>
	/// <exception cref="T:Richfit.Garnet.Module.Base.Infrastructure.Exceptions.ValidationException">判断机构下是否有用户,有则不能删除该机构</exception>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\OrgHandler.cs" region="Example.RemoveOrg.1">
	/// </code>
	/// </example>
	void RemoveOrg(string orgDTOId);

	/// <summary>
	/// 根据Id获取组织机构信息
	/// </summary>
	/// <param name="orgId">组织机构Id</param>
	/// <returns>返回组织机构DTO对象</returns>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\Application\Services\OrgUserCache\OrgUserCacheManager.cs" region="Example.GetOrgByKey.1">
	/// </code>
	/// </example>
	/// <seealso cref="T:Richfit.Garnet.Module.SystemManagement.Application.DTO.SYS_ORGDTO">组织机构DTO对象</seealso>
	SYS_ORGDTO GetOrgById(Guid orgId);

	/// <summary>
	/// 同步组织机构及用户
	/// </summary>
	/// <param name="domainID">域ID</param>
	/// <example>
	/// <code language="cs" source="Richfit.Garnet.Module.SystemManagement\HandlerProcess\Handlers\OrgHandler.cs" region="Example.Synchronize.1">
	/// </code>
	/// </example>
	void Synchronize(string domainID);
}
