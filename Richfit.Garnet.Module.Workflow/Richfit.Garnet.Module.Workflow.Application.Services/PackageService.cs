using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

/// <summary>
/// 包服务
/// </summary>
public class PackageService : ServiceBase, IPackageService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<WF_PACKAGE> packageRepository = null;

	private readonly IRepository<WF_TEMPLATE> templateRepository = null;

	/// <summary>
	/// 包服务
	/// </summary>
	/// <param name="packageRepository"></param>
	public PackageService()
	{
		packageRepository = ServiceLocator.Instance.GetService<IRepository<WF_PACKAGE>>();
		templateRepository = ServiceLocator.Instance.GetService<IRepository<WF_TEMPLATE>>();
	}

	/// <summary>
	/// 包服务
	/// </summary>
	/// <param name="packageRepository"></param>
	public PackageService(IRepository<WF_PACKAGE> packageRepository)
	{
		this.packageRepository = packageRepository;
	}

	/// <summary>
	/// 增加一个包
	/// </summary>
	/// <param name="packageDTO">包DTO</param>
	public void SavePackage(WF_PACKAGEDTO packageDTO)
	{
		if (packageDTO == null)
		{
			throw new ArgumentException("AddPackage方法参数不能为空！");
		}
		if (packageDTO.IsValid())
		{
			if (packageDTO.IsCreate)
			{
				AddPackage(packageDTO);
			}
			else
			{
				UpdatePackage(packageDTO);
			}
			return;
		}
		throw new ValidationException(packageDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 增加一个包
	/// </summary>
	/// <param name="packageDTO">包DTO</param>
	public void AddPackage(WF_PACKAGEDTO packageDTO)
	{
		WF_PACKAGE Package = packageDTO.AdaptAsEntity<WF_PACKAGE>();
		packageRepository.AddCommit(Package);
	}

	/// <summary>
	/// 更新包
	/// </summary>
	/// <param name="packageDTO">包DTO</param>
	public void UpdatePackage(WF_PACKAGEDTO packageDTO)
	{
		WF_PACKAGE package = packageRepository.GetByKey(packageDTO.PACKAGE_ID);
		if (package != null)
		{
			package.PACKAGE_NAME = packageDTO.PACKAGE_NAME;
			package.IMG = packageDTO.IMG;
			package.SORT = packageDTO.SORT;
			package.DESCRIPTION = packageDTO.DESCRIPTION;
			package.ISDEL = packageDTO.ISDEL;
			packageRepository.UpdateCommit(package);
			return;
		}
		throw new ArgumentException("UpdatePackage不存在相关的实体对象！");
	}

	/// <summary>
	/// 根据ID获取模板组
	/// </summary>
	/// <param name="packagesId">包ID</param>
	public WF_PACKAGEDTO GetPackageByID(Guid packagesId)
	{
		return GetDTOById<WF_PACKAGEDTO, WF_PACKAGE>(packagesId, packageRepository);
	}

	/// <summary>
	/// 根据条件获取模板组
	/// </summary>
	/// <param name="queryCondition">查询条件</param>
	/// <returns>包集合</returns>
	public QueryResult<WF_PACKAGEDTO> GetPackageByParameter(QueryCondition queryCondition)
	{
		return SqlQueryResult<WF_PACKAGEDTO>("GetPackageByParameter", queryCondition);
	}

	/// <summary>
	/// 删除模板组
	/// </summary>
	/// <param name="packageIds">包ID数组</param>
	public void DeletePackage(string packageIds)
	{
		packageRepository.LogicRemoveCommit(packageIds);
	}

	public IList<TREE_NODE> GetPackageTemplate(string formId, string orgId)
	{
		QueryCondition queryCondition = new QueryCondition();
		queryCondition.Add(new QueryItem
		{
			Key = "FORM_ID",
			Value = formId,
			Method = " = ",
			Type = "guid"
		});
		IList<WF_TEMPLATE_FORMDTO> templateFormCollection = SqlQueryResult<WF_TEMPLATE_FORMDTO>("GetTemplateForm", queryCondition).List;
		IList<Guid> templateIds = new List<Guid>();
		foreach (WF_TEMPLATE_FORMDTO item in templateFormCollection)
		{
			templateIds.Add(item.TEMPLATE_ID);
		}
		queryCondition = new QueryCondition();
		queryCondition.Add(new QueryItem
		{
			Key = "ORG_ID",
			Value = orgId,
			Method = " = ",
			Type = "guid"
		});
		IList<TREE_NODE> list = SqlQueryResult<TREE_NODE>("GetPackageTemplate", queryCondition).List;
		CheckTreeNode(list, templateIds);
		return list;
	}

	internal object GetMyTemplate(string action = null)
	{
		IList<WF_TEMPLATEDTO> allTemplate = new List<WF_TEMPLATEDTO>();
		if (string.IsNullOrEmpty(action))
		{
			action = "GetUserTemplate";
			allTemplate = SqlQuery<WF_TEMPLATEDTO>("GetMyTemplate", null);
		}
		else
		{
			IList<WF_TEMPLATE> query2 = templateRepository.FindAll((WF_TEMPLATE a) => a.ISDEL == 0m && a.PARENT_TEMPLATE_ID == Guid.Empty);
			foreach (WF_TEMPLATE item in query2)
			{
				allTemplate.Add(item.AdaptAsDTO<WF_TEMPLATEDTO>());
			}
		}
		IList<WF_PACKAGEDTO> result = SqlQuery<WF_PACKAGEDTO>("GetPackageByParameter", null);
		IList<WF_TEMPLATEDTO> myTemplate = SqlQuery<WF_TEMPLATEDTO>(action, new
		{
			USER_ID = SessionContext.UserInfo.UserID
		});
		foreach (WF_PACKAGEDTO package in result)
		{
			IList<WF_TEMPLATEDTO> source = allTemplate;
			Func<WF_TEMPLATEDTO, bool> predicate = (WF_TEMPLATEDTO a) => a.PACKAGE_ID == package.PACKAGE_ID;
			IEnumerable<WF_TEMPLATEDTO> queryTemplate = source.Where(predicate);
			if (queryTemplate != null && queryTemplate.Any())
			{
				package.WF_TEMPLATE = queryTemplate.OrderBy((WF_TEMPLATEDTO a) => a.SORT).ToList();
				foreach (WF_TEMPLATEDTO dtoTemplate in package.WF_TEMPLATE)
				{
					Func<WF_TEMPLATEDTO, bool> predicate2 = (WF_TEMPLATEDTO a) => a.TEMPLATE_ID == dtoTemplate.TEMPLATE_ID;
					IEnumerable<WF_TEMPLATEDTO> query = myTemplate.Where(predicate2);
					dtoTemplate.HavePermission = (query.Any() ? 1 : 0);
				}
			}
			else
			{
				package.WF_TEMPLATE = new List<WF_TEMPLATEDTO>();
			}
		}
		return result;
	}
}
