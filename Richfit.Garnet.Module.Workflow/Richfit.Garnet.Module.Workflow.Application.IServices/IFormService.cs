using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.IServices;

/// <summary>
/// 表单服务
/// </summary>
public interface IFormService
{
	List<WF_META_TABLE> GetMetaTableByTemplateId(Guid templateId);

	/// <summary>
	/// 增加一个表单
	/// </summary>
	WF_FORMDTO AddForm(WF_FORMDTO formDTO);

	/// <summary>
	/// 更新一个表单
	/// </summary>
	WF_FORMDTO UpdateForm(WF_FORMDTO formDTO);

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="templateFormID">模板表单ID</param>
	/// <returns></returns>
	WF_FORMDTO GetFormByTemplateFormID(Guid templateFormID);

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="queryCondition"></param>
	/// <returns></returns>
	QueryResult<WF_FORMDTO> GetFormByQueryCondition(QueryCondition queryCondition);

	/// <summary>
	/// 删除表单
	/// </summary>
	void DeleteForm(string formIds);

	void FormTemplateRelationship(Guid formId, Guid orgId, string templateIDs);

	List<WF_FORMDTO> GetFormsByPageId(WF_PAGE page);

	void SaveForm(WF_PAGEDTO wfForm, string rootPath);

	List<WF_PAGEDTO> GetFormByPage(Guid pageId);
}
