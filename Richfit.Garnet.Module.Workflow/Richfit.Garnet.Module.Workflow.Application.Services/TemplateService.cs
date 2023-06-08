using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Workflow.Application.Cache;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

/// <summary>
/// 模板服务
/// </summary>
public class TemplateService : ServiceBase
{
	/// <summary>
	/// 只读仓储对象
	/// </summary>
	private readonly IRepository<WF_TEMPLATE> repository = null;

	private readonly IRepository<WF_META_TABLE> metaTableRepository = null;

	private readonly IRepository<WF_PAGE> pageRepository = null;

	/// <summary>
	/// 模板服务
	/// </summary>
	public TemplateService()
	{
		repository = ServiceLocator.Instance.GetService<IRepository<WF_TEMPLATE>>();
		metaTableRepository = ServiceLocator.Instance.GetService<IRepository<WF_META_TABLE>>();
		pageRepository = ServiceLocator.Instance.GetService<IRepository<WF_PAGE>>();
	}

	/// <summary>
	/// 获取全部模板
	/// </summary>
	/// <returns></returns>
	public IList<WF_TEMPLATE> GetTemplate()
	{
		return repository.FindAll();
	}

	/// <summary>
	/// 获取全部模板
	/// </summary>
	/// <returns></returns>
	public WF_TEMPLATE GetTemplateById(Guid templateId)
	{
		WF_TEMPLATE template = repository.GetByKey(templateId);
		foreach (WF_ACTIVITY item in template.WF_ACTIVITY)
		{
			item.WF_ACTIVITY_PARTICIPANT = item.WF_ACTIVITY_PARTICIPANT.Where((WF_ACTIVITY_PARTICIPANT a) => a.ISDEL == 0m).ToList();
		}
		template.WF_RULE = template.WF_RULE.Where((WF_RULE a) => a.ISDEL == 0m).ToList();
		template.WF_ACTIVITY = template.WF_ACTIVITY.Where((WF_ACTIVITY a) => a.ISDEL == 0m).ToList();
		return template;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="url"></param>
	/// <returns></returns>
	public IList<WF_TEMPLATE_FORMDTO> GetTemplateFormByUrl(string url)
	{
		QueryCondition condition = new QueryCondition();
		QueryItem item = new QueryItem();
		item.Key = "URL";
		item.Method = " = ";
		item.Value = url;
		item.Type = "string";
		condition.QueryItems.Add(item);
		return SqlQueryResult<WF_TEMPLATE_FORMDTO>("GetTemplateFormByParameter", condition).List;
	}

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <param name="queryCondition">查询模板</param>
	/// <returns></returns>
	public QueryResult<WF_TEMPLATEDTO> GetTemplateByQueryCondition(QueryCondition queryCondition)
	{
		return SqlQueryResult<WF_TEMPLATEDTO>("GetTemplateByQueryCondition", queryCondition);
	}

	/// <summary>
	/// 删除某个模板
	/// </summary>
	/// <param name="templateId">模板ID</param>
	public void DeleteTemplate(Guid templateId)
	{
		WF_TEMPLATE template = repository.GetByKey(templateId);
		repository.RemoveCommit(template);
	}

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="templateFormId">模板表单ID</param>
	/// <returns></returns>
	public WF_TEMPLATEDTO GetTemplateByTemplateFormID(Guid templateFormId)
	{
		QueryCondition condition = new QueryCondition();
		QueryItem item = new QueryItem();
		item.Key = "TEMPLATE_FORM_ID";
		item.Method = " = ";
		item.Value = templateFormId.ToString();
		item.Type = "guid";
		condition.QueryItems.Add(item);
		QueryResult<WF_TEMPLATEDTO> resultsDTO = SqlQueryResult<WF_TEMPLATEDTO>("GetTemplateByTemplateFormID", condition);
		if (resultsDTO != null && resultsDTO.RecordCount > 0)
		{
			return resultsDTO.List[0];
		}
		return null;
	}

	/// <summary>
	/// 获取所有规则
	/// </summary>
	/// <returns></returns>
	public IList<WF_RULE> GetRule()
	{
		return ServiceLocator.Instance.GetService<IRepository<WF_RULE>>().FindAll();
	}

	/// <summary>
	/// 增加模板
	/// </summary>
	/// <param name="templateDTO">新增DTO</param>
	/// <returns></returns>
	public void AddTemplate(WF_TEMPLATEDTO templateDTO)
	{
		if (templateDTO == null)
		{
			throw new ArgumentException("AddTemplate方法参数不能为空！");
		}
		if (templateDTO.IsValid())
		{
			WF_TEMPLATE template = repository.GetByKey(templateDTO.TEMPLATE_ID);
			if (template != null)
			{
				repository.RemoveCommit(template);
			}
			WF_TEMPLATE newTemplate = templateDTO.AdaptAsEntity<WF_TEMPLATE>();
			WF_TEMPLATE PARENT = repository.GetByKey(newTemplate.PARENT_TEMPLATE_ID);
			newTemplate.ISACTIVE = 0m;
			newTemplate.VERSION_NUM = repository.FindAll((WF_TEMPLATE a) => a.PARENT_TEMPLATE_ID == PARENT.TEMPLATE_ID).Count();
			repository.AddCommit(newTemplate);
			WorkflowCacheManager.Refused(newTemplate.TEMPLATE_ID);
			if (templateDTO.CREATE_FILE)
			{
				GenerateCode(metaTableRepository.FindAll((WF_META_TABLE a) => a.TEMPLATE_ID == PARENT.TEMPLATE_ID && a.ISDEL == 0m), PARENT, newTemplate);
			}
			return;
		}
		throw new ValidationException(templateDTO.GetInvalidMessages());
	}

	public WF_TEMPLATEDTO SaveTemplate(WF_TEMPLATEDTO templateDTO)
	{
		if (templateDTO == null)
		{
			throw new ArgumentException("SaveTemplate方法参数不能为空！");
		}
		if (templateDTO.IsValid())
		{
			WF_TEMPLATE template;
			if (templateDTO.IsCreate)
			{
				int version;
				if (templateDTO.PARENT_TEMPLATE_ID == Guid.Empty)
				{
					version = 0;
				}
				else
				{
					IList<WF_TEMPLATE> query = repository.FindAll((WF_TEMPLATE a) => a.PARENT_TEMPLATE_ID == templateDTO.PARENT_TEMPLATE_ID);
					version = (query.Any() ? query.Count() : 0);
					WF_TEMPLATE parent = repository.Find((WF_TEMPLATE a) => a.TEMPLATE_ID == templateDTO.PARENT_TEMPLATE_ID);
					templateDTO.TEMPLATE_NAME = parent.TEMPLATE_NAME;
					templateDTO.VERSION_ID = parent.VERSION_ID;
					templateDTO.ORG_ID = parent.ORG_ID;
					version++;
				}
				template = templateDTO.AdaptAsEntity<WF_TEMPLATE>();
				template.VERSION_NUM = version;
				repository.AddCommit(template);
				if (version == 0)
				{
					WF_TEMPLATE wF_TEMPLATE = new WF_TEMPLATE();
					wF_TEMPLATE.TEMPLATE_CODE = templateDTO.TEMPLATE_VERSION_CODE;
					wF_TEMPLATE.IMGURL = template.IMGURL;
					wF_TEMPLATE.PACKAGE_ID = template.PACKAGE_ID;
					wF_TEMPLATE.VERSION_NUM = 0m;
					wF_TEMPLATE.PARENT_TEMPLATE_ID = template.TEMPLATE_ID;
					wF_TEMPLATE.ORG_ID = templateDTO.ORG_ID;
					wF_TEMPLATE.TEMPLATE_NAME = template.TEMPLATE_NAME;
					wF_TEMPLATE.SORT = template.SORT;
					WF_TEMPLATE templateSub = wF_TEMPLATE;
					repository.AddCommit(templateSub);
				}
			}
			else
			{
				template = repository.GetByKey(templateDTO.TEMPLATE_ID);
				template.SORT = templateDTO.SORT;
				template.TEMPLATE_NAME = templateDTO.TEMPLATE_NAME;
				template.VERSION_NUM = templateDTO.VERSION_NUM;
				template.IMGURL = templateDTO.IMGURL;
				template.ISDEL = templateDTO.ISDEL;
				template.TEMPLATE_CODE = templateDTO.TEMPLATE_CODE;
				repository.UpdateCommit(template);
			}
			WorkflowCacheManager.Refused(template.TEMPLATE_ID);
			return template.AdaptAsDTO<WF_TEMPLATEDTO>();
		}
		throw new ValidationException(templateDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 更新模板
	/// </summary>
	/// <param name="templateDTO">更新DTO</param>
	/// <returns></returns>
	public void UpdateTemplate(WF_TEMPLATEDTO templateDTO)
	{
		if (templateDTO.IsValid())
		{
			WF_TEMPLATE template = repository.GetByKey(templateDTO.TEMPLATE_ID);
			if (template == null)
			{
				AddTemplate(templateDTO);
			}
			SaveActivity(templateDTO, template);
			SaveRule(templateDTO, template);
			if (template != null)
			{
				template.TEMPLATE_NAME = templateDTO.TEMPLATE_NAME;
				template.PACKAGE_ID = templateDTO.PACKAGE_ID.Value;
				template.PACKAGE_ID = templateDTO.PACKAGE_ID.Value;
				template.TEMPLATE_CODE = templateDTO.TEMPLATE_CODE;
				template.IMGURL = templateDTO.IMGURL;
				template.MODIFYTIME = DateTime.Now;
				WorkflowCacheManager.Refused(template.TEMPLATE_ID);
				WF_TEMPLATE PARENT = repository.GetByKey(template.PARENT_TEMPLATE_ID);
				template.VERSION_ID = Guid.NewGuid();
				if (templateDTO.CREATE_FILE)
				{
					GenerateCode(metaTableRepository.FindAll((WF_META_TABLE a) => a.TEMPLATE_ID == PARENT.TEMPLATE_ID && a.ISDEL == 0m), PARENT, template);
				}
				repository.UpdateCommit(template, "WF_TEMPLATE", "WF_ACTIVITY", "WF_RULE", "WF_ACTIVITY_PARTICIPANT", "WF_ACTIVITY_REMINDER", "WF_ACTIVITY_REMINDER_RECEIVER");
				WorkflowCacheManager.Refused(template.TEMPLATE_ID);
				return;
			}
			throw new ArgumentException("UpdateCodeTable不存在相关的实体对象！");
		}
		throw new ValidationException(templateDTO.GetInvalidMessages());
	}

	/// <summary>
	/// 更新一个活动
	/// </summary>
	/// <param name="templateDTO"></param>
	/// <param name="template"></param>
	/// <returns></returns>
	private void SaveActivity(WF_TEMPLATEDTO templateDTO, WF_TEMPLATE template)
	{
		templateDTO.WF_ACTIVITY.ForEach(delegate(WF_ACTIVITYDTO a)
		{
			if (!a.STATUS.HasValue)
			{
				a.STATUS = 0m;
			}
		});
		List<WF_ACTIVITYDTO> activityDTOs = templateDTO.WF_ACTIVITY;
		List<WF_ACTIVITY> sourceActivitys = template.WF_ACTIVITY.ToList();
		activityDTOs.ForEach(delegate(WF_ACTIVITYDTO x)
		{
			WF_ACTIVITY wF_ACTIVITY = sourceActivitys.SingleOrDefault((WF_ACTIVITY y) => y.ACTIVITY_ID == x.ACTIVITY_ID);
			if (wF_ACTIVITY == null)
			{
				template.WF_ACTIVITY.Add(x.AdaptAsEntity<WF_ACTIVITY>());
			}
			else
			{
				UpdateActivity(x, wF_ACTIVITY);
			}
		});
		sourceActivitys.ForEach(delegate(WF_ACTIVITY x)
		{
			if (!activityDTOs.Any((WF_ACTIVITYDTO y) => x.ACTIVITY_ID == y.ACTIVITY_ID))
			{
				x.ISDEL = 1m;
			}
		});
	}

	/// <summary>
	/// 更新活动
	/// </summary>
	/// <param name="activityDTO">活动DTO</param>
	/// <param name="activity">活动</param>
	/// <returns>活动DTO</returns>
	private void UpdateActivity(WF_ACTIVITYDTO activityDTO, WF_ACTIVITY activity)
	{
		if (activityDTO != null && activity != null)
		{
			activity.ACTIVITY_CODE = activityDTO.ACTIVITY_CODE;
			activity.ACTIVITY_NAME = activityDTO.ACTIVITY_NAME;
			activity.TEMPLATE_ID = activityDTO.TEMPLATE_ID;
			activity.DESCRIPTION = activityDTO.DESCRIPTION;
			activity.ACTIVITY_TYPE = activityDTO.ACTIVITY_TYPE;
			activity.ACTIVITY_COORDINATE = activityDTO.ACTIVITY_COORDINATE;
			activity.FINISH_NUMBER = activityDTO.FINISH_NUMBER;
			activity.STATUS = activityDTO.STATUS;
			activity.CREATETIME = DateTime.Now;
			activity.MODIFYTIME = DateTime.Now;
			activity.SORT = activityDTO.SORT;
			activity.PARENT_PAGE_ID = activityDTO.PARENT_PAGE_ID;
			activity.PAGE_ID = activityDTO.PAGE_ID;
			activity.PAGE_URL = activityDTO.PAGE_URL;
			if (activity.PAGE_ID.HasValue && activity.PAGE_ID != Guid.Empty && string.IsNullOrEmpty(activityDTO.PAGE_URL))
			{
				activity.PAGE_URL = pageRepository.GetByKey(activity.PAGE_ID).PAGE_URL;
			}
			activity.DETAIL_PAGE_ID = activityDTO.DETAIL_PAGE_ID;
			activity.PARENT_DETAIL_PAGE_ID = activityDTO.PARENT_DETAIL_PAGE_ID;
			activity.DETAIL_PAGE_URL = activityDTO.DETAIL_PAGE_URL;
		}
		SaveActivityParticipant(activityDTO, activity);
	}

	/// <summary>
	/// 保存活动参与者
	/// </summary>
	/// <param name="activityDTO">活动DTO</param>
	/// <param name="activity">活动</param>
	/// <returns></returns>
	private void SaveActivityParticipant(WF_ACTIVITYDTO activityDTO, WF_ACTIVITY activity)
	{
		List<WF_ACTIVITY_PARTICIPANTDTO> activityParticipantDTOs = activityDTO.WF_ACTIVITY_PARTICIPANT;
		List<WF_ACTIVITY_PARTICIPANT> activityParticipants = activity.WF_ACTIVITY_PARTICIPANT.ToList();
		if (activityParticipantDTOs != null)
		{
			activityParticipantDTOs.ForEach(delegate(WF_ACTIVITY_PARTICIPANTDTO x)
			{
				WF_ACTIVITY_PARTICIPANT wF_ACTIVITY_PARTICIPANT = activityParticipants.SingleOrDefault((WF_ACTIVITY_PARTICIPANT y) => y.ACTIVITY_PARTICIPANT_ID == x.ACTIVITY_PARTICIPANT_ID);
				if (wF_ACTIVITY_PARTICIPANT == null)
				{
					activity.WF_ACTIVITY_PARTICIPANT.Add(x.AdaptAsEntity<WF_ACTIVITY_PARTICIPANT>());
				}
				else
				{
					wF_ACTIVITY_PARTICIPANT.ACTIVITY_ID = x.ACTIVITY_ID;
					wF_ACTIVITY_PARTICIPANT.MODIFIER = x.MODIFIER;
					wF_ACTIVITY_PARTICIPANT.MODIFYTIME = x.MODIFYTIME;
					wF_ACTIVITY_PARTICIPANT.PARTICIPANT_ID = x.PARTICIPANT_ID;
					wF_ACTIVITY_PARTICIPANT.PARTICIPANT_TYPE = x.PARTICIPANT_TYPE;
				}
			});
		}
		if (activityParticipants == null)
		{
			return;
		}
		activityParticipants.ForEach(delegate(WF_ACTIVITY_PARTICIPANT x)
		{
			if (!activityParticipantDTOs.Any((WF_ACTIVITY_PARTICIPANTDTO y) => x.ACTIVITY_PARTICIPANT_ID == y.ACTIVITY_PARTICIPANT_ID))
			{
				x.ISDEL = 1m;
			}
		});
	}

	/// <summary>
	/// 更新迁移
	/// </summary>
	/// <param name="templateDTO">模板DTO</param>
	/// <param name="template">模板</param>
	/// <returns></returns>
	private void SaveRule(WF_TEMPLATEDTO templateDTO, WF_TEMPLATE template)
	{
		List<WF_RULEDTO> ruleDTOs = templateDTO.WF_RULE;
		List<WF_RULE> sourceRules = template.WF_RULE.ToList();
		if (ruleDTOs != null)
		{
			ruleDTOs.ForEach(delegate(WF_RULEDTO x)
			{
				WF_RULE wF_RULE = sourceRules.SingleOrDefault((WF_RULE y) => y.RULE_ID == x.RULE_ID);
				if (wF_RULE == null)
				{
					template.WF_RULE.Add(x.AdaptAsEntity<WF_RULE>());
				}
				else
				{
					wF_RULE.TEMPLATE_ID = x.TEMPLATE_ID;
					wF_RULE.RULE_NAME = x.RULE_NAME;
					wF_RULE.RULE_COORDINATE = x.RULE_COORDINATE;
					wF_RULE.RULE_CONDITION = x.RULE_CONDITION;
					wF_RULE.FROM_ACTIVITY_ID = x.FROM_ACTIVITY_ID;
					wF_RULE.TO_ACTIVITY_ID = x.TO_ACTIVITY_ID;
					wF_RULE.LINE_TYPE = x.LINE_TYPE;
					wF_RULE.DESCRIPTION = x.DESCRIPTION;
					wF_RULE.RULE_TYPE = x.RULE_TYPE;
				}
			});
		}
		if (sourceRules == null)
		{
			return;
		}
		sourceRules.ForEach(delegate(WF_RULE x)
		{
			if (!ruleDTOs.Any((WF_RULEDTO y) => x.RULE_ID == y.RULE_ID))
			{
				x.ISDEL = 1m;
			}
		});
	}

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <returns></returns>
	public List<WF_TEMPLATEDTO> GetTemplateNameAndVersions()
	{
		return SqlQueryResult<WF_TEMPLATEDTO>("GetTemplateNameAndVersions", null).List.ToList();
	}

	internal List<WF_TEMPLATEDTO> GetTemplateByPackage(WF_TEMPLATEDTO dto)
	{
		return SqlQuery<WF_TEMPLATEDTO>("GetTemplateByPackageid", dto).ToList();
	}

	internal List<WF_TEMPLATEDTO> GetActiveTemplateByPackageid(WF_TEMPLATEDTO dto)
	{
		return SqlQuery<WF_TEMPLATEDTO>("GetActiveTemplateByPackageid", dto).ToList();
	}

	public List<WF_TEMPLATEDTO> GetTemplateVersionList(Guid? parentTemplateId)
	{
		return SqlQuery<WF_TEMPLATEDTO>("GetTemplateVersionList", new
		{
			PARENT_TEMPLATE_ID = parentTemplateId
		}).ToList();
	}

	private void GenerateCode(IList<WF_META_TABLE> tableList, WF_TEMPLATE parentTemplate, WF_TEMPLATE template)
	{
		template.WF_ACTIVITY = template.WF_ACTIVITY.Where((WF_ACTIVITY a) => a.ISDEL == 0m).ToList();
		string code = $"Richfit.Garnet.Module.Workflow.Form\\Module\\{parentTemplate.TEMPLATE_CODE}\\Service";
		string rootDtoName = parentTemplate.TEMPLATE_CODE + "DTO";
		string rootFieldName = "_" + rootDtoName.ToLower();
		string path = HttpContext.Current.Server.MapPath("/").Replace("webapp\\", code);
		template.TEMPLATE_CODE_PATH = code.Replace("\\", ".") + $".{template.TEMPLATE_CODE}_Service";
		string name = template.TEMPLATE_NAME;
		WF_META_TABLE root = tableList.SingleOrDefault((WF_META_TABLE a) => a.PARENT_TABLE_ID == Guid.Empty);
		IEnumerable<WF_META_TABLE> query = tableList.Where((WF_META_TABLE a) => a.PARENT_TABLE_ID == root.META_TABLE_ID);
		WF_META_TABLE dto = null;
		string dtoName = "";
		bool flag;
		if (flag = query.Count() > 1)
		{
			dtoName = root.TABLE_DB_NAME;
		}
		else
		{
			dto = query.ToList()[0];
			dtoName = dto.TABLE_DB_NAME;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("using {0};\r\n", "System");
		stringBuilder.AppendFormat("using {0};\r\n", "System.Data");
		stringBuilder.AppendFormat("using {0};\r\n", "Dapper");
		stringBuilder.AppendFormat("using {0};\r\n", "Richfit.Garnet.Common.Extensions");
		stringBuilder.AppendFormat("using {0};\r\n", "System.Collections.Generic");
		stringBuilder.AppendFormat("using {0};\r\n", "Richfit.Garnet.Module.Workflow.Application.Services");
		stringBuilder.AppendFormat("using {0};\r\n", "Richfit.Garnet.Module.Workflow.Application.IServices");
		stringBuilder.AppendFormat("using {0};\r\n", "Richfit.Garnet.Module.Workflow.Form.Core");
		stringBuilder.AppendFormat("using {0};\r\n", "Richfit.Garnet.Module.Workflow.Domain.Models");
		stringBuilder.AppendFormat("using {0};\r\n", $"Richfit.Garnet.Module.Workflow.Form.Module.{parentTemplate.TEMPLATE_CODE}.DTO");
		string activityCode = "switch (activity.ACTIVITY_CODE)\r\n            {\r\n";
		foreach (WF_ACTIVITY activity in template.WF_ACTIVITY)
		{
			decimal? aCTIVITY_TYPE = activity.ACTIVITY_TYPE;
			if ((!(aCTIVITY_TYPE.GetValueOrDefault() == -1m) || !aCTIVITY_TYPE.HasValue) && (int)activity.ACTIVITY_TYPE.Value != 0)
			{
				aCTIVITY_TYPE = activity.ACTIVITY_TYPE;
				if (!(aCTIVITY_TYPE.GetValueOrDefault() == 100m) || !aCTIVITY_TYPE.HasValue)
				{
					continue;
				}
			}
			if (!string.IsNullOrEmpty(activity.ACTIVITY_CODE))
			{
				activityCode += $"                //{activity.ACTIVITY_NAME}\r\n                case \"{activity.ACTIVITY_CODE}\":\r\n                    return true;\r\n";
			}
		}
		activityCode += "                default:\r\n                    return true;\r\n            }";
		stringBuilder.AppendFormat("namespace Richfit.Garnet.Module.Workflow.Form.Module.{0}.Service\r\n", parentTemplate.TEMPLATE_CODE);
		stringBuilder.Append("{\r\n");
		stringBuilder.AppendFormat("    public class {0}_Service: RunWorkflow, IRunWorkflow\r\n", template.TEMPLATE_CODE);
		stringBuilder.Append("    {\r\n");
		stringBuilder.AppendFormat("\r\n        public bool PrHandler( WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson) \r\n");
		stringBuilder.Append("        {\r\n");
		stringBuilder.Append("            return true;\r\n        }\r\n");
		stringBuilder.Append("\r\n        public bool AfterHandler( WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson) \r\n        {\r\n");
		stringBuilder.AppendFormat("        {0} {1};\r\n", rootDtoName, rootFieldName);
		stringBuilder.Append("            if (!string.IsNullOrEmpty(dataJson))\r\n");
		stringBuilder.Append("            {\r\n");
		stringBuilder.AppendFormat("                {0}=dataJson.JsonDeserialize<{1}>();\r\n", rootFieldName, rootDtoName);
		stringBuilder.Append("            }\r\n");
		stringBuilder.Append("            else\r\n");
		stringBuilder.AppendFormat("                {0} = ({1})this.FindByInstanceId(instance.INSTANCE_ID);\r\n", rootFieldName, rootDtoName);
		stringBuilder.AppendFormat("            {0} \r\n            return true;\r\n", activityCode);
		stringBuilder.Append("        }\r\n");
		stringBuilder.AppendFormat("\r\n        public string InstanceName(string templateName, string dataJson)\r\n");
		stringBuilder.Append("        {\r\n");
		stringBuilder.AppendFormat("            {0} {1} =dataJson.JsonDeserialize<{0}>();\r\n            {2}\r\n", rootDtoName, rootFieldName, "return string.Format(\"{0}[{1}]\", templateName, DateTime.Now.ToString(\"yyyyMMddHHmmss\"));");
		stringBuilder.Append("        }\r\n");
		stringBuilder.AppendFormat("\r\n        public bool SaveData( WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson) \r\n");
		stringBuilder.Append("        {\r\n");
		stringBuilder.AppendFormat("            {0} {1} =dataJson.JsonDeserialize<{0}>();\r\n", rootDtoName, rootFieldName);
		stringBuilder.AppendFormat("            if ({0}.IsCreate)\r\n", rootFieldName);
		stringBuilder.Append("            {\r\n");
		bool myFlag = false;
		foreach (WF_META_TABLE metaTable3 in query)
		{
			stringBuilder.AppendFormat("                Add<{0}>({1}.{0});\r\n", metaTable3.TABLE_DB_NAME, rootFieldName);
			Func<WF_META_TABLE, bool> predicate = (WF_META_TABLE a) => a.PARENT_TABLE_ID == metaTable3.META_TABLE_ID;
			foreach (WF_META_TABLE meta in tableList.Where(predicate))
			{
				string subFieldName = "_" + meta.TABLE_DB_NAME.ToLower();
				stringBuilder.AppendFormat("                if ({0}.{1}.{2}!=null && {0}.{1}.{2}.Count > 0)\r\n", rootFieldName, metaTable3.TABLE_DB_NAME, meta.TABLE_DB_NAME);
				stringBuilder.Append("                {\r\n");
				stringBuilder.AppendFormat("                    foreach ({0} {1} in {2}.{3}.{0})\r\n", meta.TABLE_DB_NAME, subFieldName, rootFieldName, metaTable3.TABLE_DB_NAME);
				stringBuilder.Append("                    {\r\n");
				stringBuilder.AppendFormat("                        {0}.{1} = {2}.{3}.{4};\r\n", subFieldName, dtoName + "_ID", rootFieldName, metaTable3.TABLE_DB_NAME, dtoName + "_ID");
				stringBuilder.AppendFormat("                        Add<{0}>({1});\r\n", meta.TABLE_DB_NAME, subFieldName);
				stringBuilder.Append("                    }\r\n");
				stringBuilder.Append("                }\r\n");
			}
		}
		stringBuilder.Append("             }\r\n            else\r\n            {\r\n");
		foreach (WF_META_TABLE metaTable2 in query)
		{
			stringBuilder.AppendFormat("                Update({0}.{1});\r\n", rootFieldName, metaTable2.TABLE_DB_NAME);
			Func<WF_META_TABLE, bool> predicate2 = (WF_META_TABLE a) => a.PARENT_TABLE_ID == metaTable2.META_TABLE_ID;
			IEnumerable<WF_META_TABLE> subquery = tableList.Where(predicate2);
			int i = 0;
			foreach (WF_META_TABLE meta in subquery)
			{
				myFlag = true;
				string subFieldName = "_" + meta.TABLE_DB_NAME.ToLower();
				stringBuilder.AppendFormat("                {0}sql = \"delete from {1} where {2}=:{2}\";\r\n", (i++ == 0) ? "string " : "", meta.TABLE_DB_NAME, dtoName + "_ID");
				stringBuilder.AppendFormat("                repository.ExecuteCommand(sql, {0}.{1});\r\n", rootFieldName, metaTable2.TABLE_DB_NAME);
				stringBuilder.AppendFormat("                if ({0}.{1}.{2}.Count > 0)\r\n", rootFieldName, metaTable2.TABLE_DB_NAME, meta.TABLE_DB_NAME);
				stringBuilder.Append("                {\r\n");
				stringBuilder.AppendFormat("                    foreach ({0} {1} in {2}.{3}.{0})\r\n", meta.TABLE_DB_NAME, subFieldName, rootFieldName, metaTable2.TABLE_DB_NAME);
				stringBuilder.Append("                    {\r\n");
				stringBuilder.AppendFormat("                        {0}.{1} = {2}.{3}.{4};\r\n", subFieldName, dtoName + "_ID", rootFieldName, metaTable2.TABLE_DB_NAME, dtoName + "_ID");
				stringBuilder.AppendFormat("                        Add({0});\r\n", subFieldName);
				stringBuilder.Append("                    }\r\n");
				stringBuilder.Append("                }\r\n");
			}
		}
		stringBuilder.Append("            }\r\n            return true;\r\n        }\r\n");
		stringBuilder.AppendFormat("\r\n        public List<Workflow.Application.DTO.User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson) \r\n");
		stringBuilder.Append("        {\r\n");
		stringBuilder.AppendFormat("            return base.GetActivityParticipantOnlyUser(activity.ACTIVITY_ID,orgId,instance==null?null: (Guid?)instance.INSTANCE_ID);\r\n", dtoName, "_" + dtoName.ToLower());
		stringBuilder.Append("        }\r\n");
		stringBuilder.Append("\r\n        public IDTO FindByInstanceId(Guid instanceId) \r\n");
		stringBuilder.Append("        {\r\n");
		stringBuilder.AppendFormat("            {0} {1} = new {0}();\r\n", rootDtoName, rootFieldName);
		foreach (WF_META_TABLE metaTable in query)
		{
			stringBuilder.AppendFormat("            {0}.{1} = base.FindByInstanceId<{1}>(instanceId);\r\n", rootFieldName, metaTable.TABLE_DB_NAME);
			Func<WF_META_TABLE, bool> predicate3 = (WF_META_TABLE a) => a.PARENT_TABLE_ID == metaTable.META_TABLE_ID;
			IEnumerable<WF_META_TABLE> subquery = tableList.Where(predicate3);
			if (!subquery.Any())
			{
				continue;
			}
			stringBuilder.AppendFormat("            if ({0}.{1} != null)\r\n", rootFieldName, metaTable.TABLE_DB_NAME);
			stringBuilder.Append("            {\r\n");
			foreach (WF_META_TABLE meta in subquery)
			{
				string temp = "new { " + metaTable.TABLE_DB_NAME + "_ID = " + rootFieldName + "." + metaTable.TABLE_DB_NAME + "." + metaTable.TABLE_DB_NAME + "_ID }";
				stringBuilder.AppendFormat("                {0}.{1}.{2} = repository.ExecuteQuery<{2}>({3}, {4});\r\n", rootFieldName, metaTable.TABLE_DB_NAME, meta.TABLE_DB_NAME, $"new {meta.TABLE_DB_NAME}().FindByInstance", temp);
			}
			stringBuilder.Append("            }\r\n");
		}
		stringBuilder.AppendFormat("            return {0};\r\n", rootFieldName);
		stringBuilder.Append("        }\r\n");
		stringBuilder.Append("    }\r\n}");
		GenerateCode(stringBuilder.ToString(), template.TEMPLATE_CODE + "_Service.cs", path);
	}

	private void GenerateCode(string codeCompileUnit, string table, string path)
	{
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		path = path + "/" + table;
		if (!File.Exists(path))
		{
			File.Create(path).Close();
		}
		using IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(path, append: false, Encoding.UTF8), "      ");
		tw.Write(codeCompileUnit);
		tw.Close();
	}

	internal bool ActiveTemplate(WF_TEMPLATEDTO template)
	{
		IList<WF_TEMPLATE> query = repository.FindAll((WF_TEMPLATE a) => a.ISDEL == 0m && a.PARENT_TEMPLATE_ID == (Guid)template.PARENT_TEMPLATE_ID);
		foreach (WF_TEMPLATE item in query)
		{
			if (item.TEMPLATE_ID == template.TEMPLATE_ID)
			{
				item.ISACTIVE = 1m;
			}
			else
			{
				item.ISACTIVE = 0m;
			}
		}
		repository.UpdateCommit(query);
		return true;
	}

	internal bool DeleteTemplate(WF_TEMPLATEDTO template)
	{
		WF_TEMPLATE poco = repository.GetByKey(template.TEMPLATE_ID);
		poco.ISDEL = 1m;
		repository.UpdateCommit(poco);
		return true;
	}
}
