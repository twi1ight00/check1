using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.HandlerProcess.Handlers;

public class FormHandler : HandlerBase
{
	private IFormService formService = ServiceLocator.Instance.GetService<IFormService>();

	/// <summary>
	/// ProcessRequest
	/// </summary>
	/// <param name="context">context</param>
	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "Workflow_Form_AddForm":
					AddForm(handlerResult);
					break;
				case "Workflow_Form_UpdateForm":
					UpdateForm(handlerResult);
					break;
				case "Workflow_Form_RemoveForm":
					DeleteForm(handlerResult);
					break;
				case "Workflow_Form_GetFormByParameter":
					GetFormByParameter(handlerResult);
					break;
				case "Workflow_Form_FormRelationTemplate":
					FormRelationTemplate(handlerResult);
					break;
				case "Workflow_Form_GetFormByTemplateFormID":
					GetFormByTemplateFormID(handlerResult);
					break;
				case "Workflow_Form_GetMetaTableByTemplateId":
					GetMetaTableByTemplateId(handlerResult);
					break;
				case "Workflow_Form_SaveMetaTable":
					SaveMetaTable(handlerResult);
					break;
				case "Workflow_Form_SaveMetaData":
					SaveMetaData(handlerResult);
					break;
				case "Workflow_Form_GetFormsByPageId":
					GetFormsByPageId(handlerResult);
					break;
				case "Workflow_Form_SaveForm":
					SaveForm(handlerResult, context.Server.MapPath("/Packages/WorkflowForm/Views"));
					break;
				case "Workflow_Form_CreateTable":
					CreateTable(handlerResult);
					break;
				case "Workflow_Form_SaveAccountTable":
					SaveAccountTable(handlerResult);
					break;
				case "Workflow_Form_GetFormByPage":
					GetFormByPage(handlerResult);
					break;
				case "Workflow_Form_GetMainMetaTable":
					GetMainMetaTable(handlerResult);
					break;
				case "Workflow_Form_GetColByTableId":
					GetColByTableId(handlerResult);
					break;
				case "Workflow_Form_SaveAccount":
					SaveAccount(handlerResult);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			handlerResult = HandleException(ex);
		}
		context.Response.Write(handlerResult.ToJson());
	}

	private void SaveAccount(ResponseData handlerResult)
	{
		SaveAccountParameter saveAccountParameter = base.RequestData.Data.JsonDeserialize<SaveAccountParameter>(new JsonConverter[0]);
		ServiceLocator.Instance.GetService<IMetaTableService>().SaveAccount(saveAccountParameter);
	}

	private void GetMainMetaTable(ResponseData handlerResult)
	{
		handlerResult.Data = ServiceLocator.Instance.GetService<IMetaTableService>().GetMainMetaTable().JsonSerialize();
	}

	private void GetColByTableId(ResponseData handlerResult)
	{
		WF_METADATADTO metaData = base.RequestData.Data.JsonDeserialize<WF_METADATADTO>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IMetaTableService>().GetColByTableId(metaData).JsonSerialize();
	}

	private void GetFormByPage(ResponseData handlerResult)
	{
		Dictionary<string, Guid> template = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IFormService>().GetFormByPage(template["PAGE_ID"]).JsonSerialize();
	}

	private void CreateTable(ResponseData handlerResult)
	{
		Dictionary<string, Guid> template = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IMetaTableService>().CreateTable(template["TEMPLATE_ID"]).JsonSerialize();
	}

	private void SaveAccountTable(ResponseData handlerResult)
	{
		Dictionary<string, Guid> template = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IMetaTableService>().SaveAccountTable(template["TEMPLATE_ID"]).JsonSerialize();
	}

	private void SaveForm(ResponseData handlerResult, string rootPath)
	{
		WF_PAGEDTO wfPage = base.RequestData.Data.JsonDeserialize<WF_PAGEDTO>(new JsonConverter[0]);
		foreach (WF_FORMDTO dto in wfPage.WF_FORM)
		{
			setColSpan(dto);
		}
		ServiceLocator.Instance.GetService<IFormService>().SaveForm(wfPage, rootPath);
	}

	private void setColSpan(WF_FORMDTO dto)
	{
		foreach (WF_FORM_DEFINITIONDTO definition in dto.WF_FORM_DEFINITION)
		{
			definition.COLSPAN = definition._COLSPAN;
		}
		foreach (WF_FORMDTO form in dto.subform)
		{
			setColSpan(form);
		}
	}

	private void GetFormsByPageId(ResponseData handlerResult)
	{
		WF_PAGE package = base.RequestData.Data.JsonDeserialize<WF_PAGE>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IFormService>().GetFormsByPageId(package).JsonSerialize();
	}

	private void SaveMetaData(ResponseData handlerResult)
	{
		List<WF_METADATADTO> metaTable = base.RequestData.Data.JsonDeserialize<List<WF_METADATADTO>>(new JsonConverter[0]);
		ServiceLocator.Instance.GetService<IMetaTableService>().SaveMetaData(metaTable);
	}

	private void SaveMetaTable(ResponseData handlerResult)
	{
		WF_META_TABLEDTO metaTable = base.RequestData.Data.JsonDeserialize<WF_META_TABLEDTO>(new JsonConverter[0]);
		ServiceLocator.Instance.GetService<IMetaTableService>().SaveMetaTable(metaTable);
	}

	private void GetMetaTableByTemplateId(ResponseData handlerResult)
	{
		Dictionary<string, Guid> package = base.RequestData.Data.JsonDeserialize<Dictionary<string, Guid>>(new JsonConverter[0]);
		handlerResult.Data = ServiceLocator.Instance.GetService<IFormService>().GetMetaTableByTemplateId(package["TEMPLATE_ID"]).JsonSerialize();
	}

	/// <summary>
	/// 根据参数获取表单
	/// </summary>
	/// <param name="handlerResult"></param>
	private void GetFormByParameter(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			FormParameter parameter = base.RequestData.Data.JsonDeserialize<FormParameter>(new JsonConverter[0]);
			if (!parameter.IsNull())
			{
				QueryResult<WF_FORMDTO> collection = formService.GetFormByQueryCondition(parameter.ToQueryCondition());
				handlerResult.Data = collection.JsonSerialize();
			}
		}
	}

	private void GetFormByTemplateFormID(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "TEMPLATE_FORM_ID"))
			{
				WF_FORMDTO formDTO = formService.GetFormByTemplateFormID(new Guid(dictionary["TEMPLATE_FORM_ID"]));
				handlerResult.Data = formDTO.JsonSerialize();
			}
		}
	}

	private void FormRelationTemplate(ResponseData handlerResult)
	{
		Dictionary<string, string> dataParams = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid formId = Guid.Parse(dataParams["FORM_ID"]);
		Guid orgId = Guid.Parse(dataParams["ORG_ID"]);
		string templateIds = dataParams["TEMPLATE_ID"];
		formService.FormTemplateRelationship(formId, orgId, templateIds);
	}

	/// <summary>
	/// 增加表单
	/// </summary>
	/// <param name="handlerResult"></param>
	private void AddForm(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_FORMDTO dto = base.RequestData.Data.JsonDeserialize<WF_FORMDTO>(new JsonConverter[0]);
			if (!dto.IsNull())
			{
				WF_FORMDTO returnDTO = formService.AddForm(dto);
				handlerResult.Data = returnDTO.JsonSerialize();
			}
		}
	}

	/// <summary>
	/// 新增表单
	/// </summary>
	/// <param name="handlerResult"></param>
	private void UpdateForm(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			WF_FORMDTO dto = base.RequestData.Data.JsonDeserialize<WF_FORMDTO>(new JsonConverter[0]);
			if (!dto.IsNull())
			{
				WF_FORMDTO returnDTO = formService.UpdateForm(dto);
			}
		}
	}

	/// <summary>
	/// 删除表单
	/// </summary>
	/// <param name="handlerResult"></param>
	private void DeleteForm(ResponseData handlerResult)
	{
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
			if (dictionary.Any((KeyValuePair<string, string> a) => a.Key == "ID"))
			{
				formService.DeleteForm(dictionary["ID"]);
			}
		}
	}
}
