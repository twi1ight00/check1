using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Workflow.Application.DTO;

namespace Richfit.Garnet.Module.Workflow.Application.IServices;

/// <summary>
/// 包服务
/// </summary>
public interface IPackageService
{
	/// <summary>
	/// 增加一个包
	/// </summary>
	void SavePackage(WF_PACKAGEDTO packageDTO);

	/// <summary>
	/// 根据ID获取模板组
	/// </summary>
	WF_PACKAGEDTO GetPackageByID(Guid packagesID);

	/// <summary>
	/// 根据条件获取模板组
	/// </summary>
	/// <param name="queryCondition"></param>
	/// <returns></returns>
	QueryResult<WF_PACKAGEDTO> GetPackageByParameter(QueryCondition queryCondition);

	/// <summary>
	/// 删除模板组
	/// </summary>
	void DeletePackage(string packageIds);

	/// <summary>
	///
	/// </summary>
	/// <param name="formId"></param>
	/// <param name="orgId"></param>
	/// <returns></returns>
	IList<TREE_NODE> GetPackageTemplate(string formId, string orgId);
}
