using System;
using System.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.Services.Domain;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.OrgManagement;

/// <summary>
/// 组织机构Service.
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
public class OrgAppService : ServiceBase, IOrgAppService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<SYS_ORG> orgRepository;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryOrg">组织机构仓储对象</param>
	public OrgAppService(IRepository<SYS_ORG> repositoryOrg)
	{
		orgRepository = repositoryOrg;
	}

	/// <summary>
	/// 新增组织机构
	/// </summary>
	/// <param name="orgDTO">新增组织信息</param>
	/// <returns>新增组织机构信息</returns>
	/// <inheritdoc />
	public SYS_ORGDTO AddOrg(SYS_ORGDTO orgDTO)
	{
		if (orgDTO != null)
		{
			if (!orgDTO.IsValid())
			{
				throw new ValidationException(orgDTO.GetInvalidMessages());
			}
			SYS_ORG orgPOCO = orgDTO.AdaptAsEntity<SYS_ORG>();
			orgRepository.AddCommit(orgPOCO);
			orgRepository.Reload(orgPOCO);
			string orgName = orgDTO.PARENT_ORG_NAME;
			orgDTO = orgPOCO.AdaptAsDTO<SYS_ORGDTO>();
			orgDTO.PARENT_ORG_NAME = orgName;
			OrgUserCacheManager.AddCache(orgDTO);
			orgRepository.ExecuteCommand(orgRepository.GetSqlStatement("UpdateOrgView", GetType()).Sql);
		}
		return orgDTO;
	}

	/// <summary>
	/// 编辑组织机构信息
	/// </summary>
	/// <param name="orgDTO">编辑组织机构信息</param>
	/// <inheritdoc />
	public void UpdateOrg(SYS_ORGDTO orgDTO)
	{
		if (orgDTO != null && orgDTO.ORG_ID != Guid.Empty)
		{
			if (orgDTO.IsValid())
			{
				SYS_ORG persisted = orgRepository.GetByKey(orgDTO.ORG_ID);
				if (persisted == null)
				{
					throw new ValidationException("SystemManagement.Public.V_0004");
				}
				persisted.ORG_NAME = orgDTO.ORG_NAME;
				persisted.SORT = orgDTO.SORT;
				persisted.NOTE = orgDTO.NOTE;
				persisted.PARENT_ORG_ID = orgDTO.PARENT_ORG_ID;
				persisted.EXTEND1 = orgDTO.EXTEND1;
				persisted.EXTEND2 = orgDTO.EXTEND2;
				persisted.EXTEND3 = orgDTO.EXTEND3;
				persisted.EXTEND4 = orgDTO.EXTEND4;
				persisted.EXTEND5 = orgDTO.EXTEND5;
				orgRepository.UpdateCommit(persisted);
				orgDTO = persisted.AdaptAsDTO<SYS_ORGDTO>();
				OrgUserCacheManager.UpdateCache(orgDTO);
				orgRepository.ExecuteCommand(orgRepository.GetSqlStatement("UpdateOrgView", GetType()).Sql);
			}
			return;
		}
		throw new ValidationException(orgDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 删除组织机构
	/// </summary>
	/// <param name="orgIds">组织机构编号集合，逗号分隔</param>
	/// <inheritdoc />
	public void RemoveOrg(string orgIds)
	{
		string[] orgIdArray = orgIds.Split(',');
		string[] array = orgIdArray;
		foreach (string orgId in array)
		{
			SYS_ORG orgPOCO = orgRepository.GetByKey(Guid.Parse(orgId));
			if (orgPOCO != null)
			{
				if (orgPOCO.SYS_USER_ORG.Count > 0)
				{
					throw new ValidationException("SystemManagement.Public.V_0008");
				}
				orgRepository.RemoveChild(orgPOCO.SYS_ROLE_ORG);
				orgPOCO.ISDEL = 1m;
				orgRepository.Update(orgPOCO);
			}
		}
		orgRepository.DbContext.Commit();
		OrgUserCacheManager.RemoveOrgCache(SplitToGuid(orgIds));
	}

	/// <inheritdoc />
	public SYS_ORGDTO GetOrgById(Guid orgId)
	{
		return GetDTOById<SYS_ORGDTO, SYS_ORG>(orgId, orgRepository);
	}

	/// <summary>
	/// 同步组织机构及用户
	/// </summary>
	/// <param name="domainID">域ID</param>
	/// <inheritdoc />
	public void Synchronize(string domainID)
	{
		DomainDTO domain = (from x in DomainManager.GetAllDomain()
			where x.DOMAIN_ID.Equals(domainID)
			select x).FirstOrDefault();
		if (domain != null)
		{
			string ldap = domain.DOMAIN_ADDRESS;
			string ldapUserName = domain.DOMAIN_NAME;
			string ldapPassWord = domain.DOMAIN_PWD;
			string topOrgID = ConfigurationManager.CurrentPackage.Settings["TopOrgID"].ToString();
		}
	}
}
