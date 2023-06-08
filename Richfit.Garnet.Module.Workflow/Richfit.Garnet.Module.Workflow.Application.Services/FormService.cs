using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.JScript;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

/// <summary>
/// 表单服务
/// </summary>
public class FormService : ServiceBase, IFormService
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<WF_FORM> formRepository = null;

	private readonly IRepository<WF_META_TABLE> metaTableRepository = null;

	private readonly IRepository<WF_ACTIVITY> activityRepository = null;

	private readonly IRepository<WF_TEMPLATE> templateRepository = null;

	private readonly IRepository<WF_PAGE> pageRepository = null;

	public FormService()
	{
		formRepository = ServiceLocator.Instance.GetService<IRepository<WF_FORM>>();
		metaTableRepository = ServiceLocator.Instance.GetService<IRepository<WF_META_TABLE>>();
		activityRepository = ServiceLocator.Instance.GetService<IRepository<WF_ACTIVITY>>();
		templateRepository = ServiceLocator.Instance.GetService<IRepository<WF_TEMPLATE>>();
		pageRepository = ServiceLocator.Instance.GetService<IRepository<WF_PAGE>>();
	}

	/// <summary>
	/// 增加一个表单
	/// </summary>
	public WF_FORMDTO AddForm(WF_FORMDTO formDTO)
	{
		if (formDTO == null)
		{
			throw new ArgumentException("Addform方法参数不能为空！");
		}
		if (formDTO.IsValid())
		{
			WF_FORM Form = formDTO.AdaptAsEntity<WF_FORM>();
			formRepository.AddCommit(Form);
			return Form.AdaptAsDTO<WF_FORMDTO>();
		}
		throw new ValidationException(formDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 更新一个表单
	/// </summary>
	public WF_FORMDTO UpdateForm(WF_FORMDTO formDTO)
	{
		if (formDTO == null)
		{
			throw new ArgumentException("UpdateForm方法参数不能为空！");
		}
		if (formDTO.IsValid())
		{
			return null;
		}
		throw new ValidationException(formDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="queryCondition"></param>
	/// <returns></returns>
	public QueryResult<WF_FORMDTO> GetFormByQueryCondition(QueryCondition queryCondition)
	{
		return SqlQueryResult<WF_FORMDTO>("GetFormByQueryCondition", queryCondition);
	}

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <returns></returns>
	public IList<WF_FORM> GetForm()
	{
		return formRepository.FindAll();
	}

	/// <summary>
	/// 根据ID获取表单
	/// </summary>
	/// <param name="formId">表单ID</param>
	/// <returns></returns>
	public WF_FORM GetFormById(Guid formId)
	{
		return formRepository.GetByKey(formId);
	}

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="templateFormId">模板表单ID</param>
	/// <returns></returns>
	public WF_FORMDTO GetFormByTemplateFormID(Guid templateFormId)
	{
		QueryCondition condition = new QueryCondition();
		QueryItem item = new QueryItem();
		item.Key = "TEMPLATE_FORM_ID";
		item.Method = " = ";
		item.Value = templateFormId.ToString();
		item.Type = "guid";
		condition.QueryItems.Add(item);
		QueryResult<WF_FORMDTO> resultsDTO = SqlQueryResult<WF_FORMDTO>("GetFormByTemplateFormID", condition);
		if (resultsDTO != null && resultsDTO.RecordCount > 0)
		{
			return resultsDTO.List.ToList()[0];
		}
		return null;
	}

	/// <summary>
	/// 删除表单
	/// </summary>
	public void DeleteForm(string formIds)
	{
		formRepository.LogicRemoveCommit(formIds);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="formId"></param>
	/// <param name="orgId"></param>
	/// <param name="templateIDs"></param>
	public void FormTemplateRelationship(Guid formId, Guid orgId, string templateIDs)
	{
	}

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="version_id"></param>
	/// <param name="form_id"></param>
	/// <returns></returns>
	public List<WF_FORMDTO> GetTemplateForms(Guid? version_id, Guid? form_id)
	{
		QueryCondition condition = new QueryCondition();
		QueryItem item = new QueryItem();
		item.Key = "VERSION_ID";
		item.Method = " = ";
		item.Value = version_id.ToString();
		item.Type = "guid";
		condition.QueryItems.Add(item);
		item = new QueryItem();
		item.Key = "FORM_ID";
		item.Method = " = ";
		item.Value = form_id.ToString();
		item.Type = "guid";
		condition.QueryItems.Add(item);
		return SqlQueryResult<WF_FORMDTO>("GetTemplateForms", condition).List.ToList();
	}

	public List<WF_FORMDTO> GetFormsByPageId(WF_PAGE page)
	{
		List<WF_FORMDTO> dtoList = new List<WF_FORMDTO>();
		List<WF_FORM> formList = formRepository.FindAll((WF_FORM a) => a.PAGE_ID == page.PAGE_ID).ToList();
		foreach (WF_FORM form in formList)
		{
			WF_FORMDTO dtoForm = form.AdaptAsDTO<WF_FORMDTO>();
			if (dtoForm.WF_FORM_DEFINITION != null && dtoForm.WF_FORM_DEFINITION.Any())
			{
				dtoForm.WF_FORM_DEFINITION = dtoForm.WF_FORM_DEFINITION.OrderBy((WF_FORM_DEFINITIONDTO a) => a.SORT).ToList();
			}
			dtoList.Add(dtoForm);
		}
		return dtoList;
	}

	public List<WF_META_TABLE> GetMetaTableByTemplateId(Guid templateId)
	{
		IList<WF_META_TABLE> tableList = SqlQuery<WF_META_TABLE>("GetMetaTableByTemplateId", new
		{
			TEMPLATE_ID = templateId
		});
		foreach (WF_META_TABLE table in tableList)
		{
			table.WF_METADATA = SqlQuery<WF_METADATA>("GetMetaDataByTableId", new { table.META_TABLE_ID });
		}
		return tableList.ToList();
	}

	private void ChangeId(WF_FORMDTO dto, Guid pageId, Guid? parentFormId = null)
	{
		dto.PAGE_ID = pageId;
		dto.PARENT_FORM_ID = parentFormId ?? new Guid?(Guid.Empty);
		dto.FORM_ID = Guid.NewGuid();
		foreach (WF_FORM_DEFINITIONDTO defintion in dto.WF_FORM_DEFINITION)
		{
			defintion.FORM_DEFINITION_ID = Guid.NewGuid();
			defintion.FORM_ID = dto.FORM_ID;
			defintion.COLSPAN = defintion._COLSPAN;
			foreach (WF_FORM_DEFINITION_DATADTO defineDto in defintion.WF_FORM_DEFINITION_DATA)
			{
				defineDto.FORM_DEFINITION_DATA_ID = Guid.NewGuid();
				defineDto.FORM_DEFINITION_ID = defintion.FORM_DEFINITION_ID;
			}
		}
		if (dto.subform == null || dto.subform.Count <= 0)
		{
			return;
		}
		foreach (WF_FORMDTO sub in dto.subform)
		{
			ChangeId(sub, pageId, dto.FORM_ID);
		}
	}

	public void SaveForm(WF_PAGEDTO wfPage, string rootPath)
	{
		if (wfPage.IS_MOBILE == 0)
		{
			switch (wfPage.SaveModel)
			{
			case SaveModel.New:
				SaveNew(wfPage.WF_FORM[0]);
				break;
			case SaveModel.Edit:
				SaveEdit(wfPage.WF_FORM[0]);
				break;
			case SaveModel.Version:
			{
				WF_PAGE newPage = new PageService().SavePage(new WF_PAGEDTO
				{
					VERSION_NAME = wfPage.VERSION_NAME,
					PAGE_ID = Guid.NewGuid(),
					PAGE_NAME = wfPage.PAGE_NAME,
					TEMPLATE_ID = wfPage.TEMPLATE_ID,
					PARENT_PAGE_ID = wfPage.PARENT_PAGE_ID,
					IsCreate = true
				});
				foreach (WF_FORMDTO formDto in wfPage.WF_FORM)
				{
					ChangeId(formDto, newPage.PAGE_ID);
				}
				SaveNew(wfPage.WF_FORM[0]);
				break;
			}
			}
		}
		WF_PAGE parentPage = pageRepository.GetByKey(wfPage.PARENT_PAGE_ID);
		WF_TEMPLATE template = templateRepository.GetByKey(parentPage.TEMPLATE_ID);
		string htmlPath = string.Format("/Packages/WorkflowForm/Views/{0}/{1}/{2}.html", template.TEMPLATE_CODE, parentPage.VERSION_NAME, (wfPage.IS_MOBILE == 0) ? wfPage.VERSION_NAME : (wfPage.VERSION_NAME + "_mobile"));
		if (wfPage.IS_MOBILE == 0)
		{
			WF_PAGE page = pageRepository.GetByKey(wfPage.PAGE_ID);
			page.PAGE_URL = htmlPath;
			pageRepository.UpdateCommit(page, "WF_PAGE");
			formRepository.DbContext.Commit();
		}
		string path = rootPath + "\\" + template.TEMPLATE_CODE + "\\" + parentPage.VERSION_NAME;
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		path = path + "\\" + ((wfPage.IS_MOBILE == 0) ? wfPage.VERSION_NAME : (wfPage.VERSION_NAME + "_mobile")) + ".html";
		string userCode = "";
		try
		{
			if (File.Exists(path))
			{
				File.SetAttributes(path, FileAttributes.Normal);
				using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
				{
					string html = streamReader.ReadToEnd();
					int start = html.IndexOf("<!--split-start-->");
					int end = html.IndexOf("<!--split-end-->");
					if (start != -1 && end != -1)
					{
						if (end == -1)
						{
							end = html.Length;
						}
						userCode = html.Substring(start, end - start + 16);
					}
				}
				File.Delete(path);
			}
			using (FileStream fileStream = new FileStream(path, FileMode.Create))
			{
				byte[] data = Encoding.UTF8.GetBytes(GlobalObject.unescape(wfPage.HTML).Replace(">", ">\r\n") + "\r\n" + userCode + $"<script src=\"/Packages/WorkflowForm/Views/{template.TEMPLATE_CODE}/{parentPage.VERSION_NAME}/{wfPage.VERSION_NAME}.js\"></script>");
				fileStream.Write(data, 0, data.Length);
				fileStream.Flush();
				fileStream.Close();
			}
			if (wfPage.IS_MOBILE == 0 && wfPage.CREATE_FILE)
			{
				string jsPath = path.Replace(".html", ".js");
				if (File.Exists(jsPath))
				{
					File.SetAttributes(jsPath, FileAttributes.Normal);
					File.Delete(jsPath);
				}
				using FileStream fileStream = new FileStream(jsPath, FileMode.Create);
				byte[] data = Encoding.UTF8.GetBytes(GlobalObject.unescape(wfPage.JS));
				fileStream.Write(data, 0, data.Length);
				fileStream.Flush();
				fileStream.Close();
				return;
			}
		}
		catch (Exception)
		{
			throw;
		}
	}

	private void SaveNew(WF_FORMDTO wfForm)
	{
		formRepository.Add(wfForm.AdaptAsEntity<WF_FORM>());
		foreach (WF_FORMDTO dto in wfForm.subform)
		{
			formRepository.Add(dto.AdaptAsEntity<WF_FORM>());
			if (dto.subform == null || dto.subform.Count <= 0)
			{
				continue;
			}
			foreach (WF_FORMDTO sub in dto.subform)
			{
				formRepository.Add(sub.AdaptAsEntity<WF_FORM>());
			}
		}
	}

	private void SaveEdit(WF_FORMDTO wfForm)
	{
		IList<WF_FORM> query = formRepository.FindAll((WF_FORM a) => a.PAGE_ID == wfForm.PAGE_ID);
		foreach (WF_FORM form in query)
		{
			formRepository.RemoveCommit(form);
		}
		SaveNew(wfForm);
	}

	public List<WF_PAGEDTO> GetFormByPage(Guid pageId)
	{
		formRepository.FindAll((WF_FORM a) => a.PAGE_ID == pageId);
		return null;
	}
}
