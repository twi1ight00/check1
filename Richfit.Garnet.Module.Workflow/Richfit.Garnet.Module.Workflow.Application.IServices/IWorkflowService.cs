using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Migration;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.IServices;

/// <summary>
/// 工作流服务
/// </summary>
public interface IWorkflowService
{
	/// <summary>
	/// 创建流程
	/// </summary>
	/// <param name="user">用户DTO</param> 
	/// <param name="instanceId">当前实例ID</param>
	/// <param name="templateId"></param>
	/// <param name="formId"></param>
	/// <param name="instanceTitle">实例名称</param>
	/// <param name="instanceTableName">实例表名称</param>
	/// <param name="parentInstanceId">父模板ID</param>
	/// <param name="parentActivityId">父活动id</param>
	/// <returns>工作项ID</returns>
	WF_INSTANCE CreateWorkflow(WF_INSTANCE instance, SubmitDTO submitDto);

	/// <summary>
	/// 提交工作流
	/// </summary>
	/// <param name="instanceId">当前实例</param>
	/// <param name="workItemId">当前工作项</param>
	/// <param name="user">提交用户信息</param>
	/// <param name="handleResult">处理结果</param>
	/// <param name="handleSuggestion">处理意见</param>
	/// <param name="rules">规则</param>
	/// <param name="customNext">自定义活动</param>
	/// <returns>提交结果</returns>
	WF_INSTANCE Submit(SubmitDTO dto);

	/// <summary>
	/// 重置已完成流程
	/// </summary>
	/// <param name="instanceId"></param>
	/// <param name="user"></param>
	/// <returns></returns>
	void ResetWorkflow(Guid instanceId, User user);

	/// <summary>
	/// 流程调整
	/// </summary>
	WF_INSTANCE Adjust(Guid workItemId, List<User> users);

	/// <summary>
	/// 更新实例名称
	/// </summary>
	/// <param name="instanceId"></param>
	/// <param name="instanceName"></param>
	void UpdateInstanceName(Guid instanceId, string instanceName);

	/// <summary>
	/// 删除流程
	/// </summary>
	/// <param name="instanceIds"></param>
	void DeleteInstance(string instanceIds);

	/// <summary>
	/// 根据ID获取一个活动（缓存）
	/// </summary>
	/// <param name="activityId">活动ID</param>
	/// <returns>活动DTO</returns>
	WF_ACTIVITYDTO GetActivityById(Guid activityId);

	/// <summary>
	/// 获取开始活动
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <returns>开始活动</returns>
	WF_ACTIVITYDTO GetStartActivity(Guid templateId);

	/// <summary>
	/// 获取退回步骤
	/// </summary>
	/// <param name="activityId"></param>
	/// <returns></returns>
	List<WF_ACTIVITYDTO> GetGoBackNextActivity(Guid activityId);

	/// <summary>
	/// 根据规则，获取某个活动的后继规则表达式
	/// </summary>
	/// <param name="activityId">活动ID</param>
	/// <param name="rules">规则，格式为state:1|money:500</param>
	/// <returns></returns>
	List<NEXT_ACTIVITY> GetPostActivitys(Guid activityId, string rules);

	/// <summary>
	/// 获取所有步骤
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="orgId"></param>
	/// <param name="rules"></param>
	/// <param name="instanceId"></param>
	/// <param name="activityId"></param>
	/// <returns></returns>
	List<WF_ACTIVITYDTO> GetAllActivitys(Guid templateId, Guid orgId, string rules, Guid instanceId, List<WF_ACTIVITYDTO> activitys);

	/// <summary>
	/// 增加模板
	/// </summary>
	/// <param name="templateDTO">新增DTO</param>
	/// <returns></returns>
	void AddTemplate(WF_TEMPLATEDTO templateDTO);

	/// <summary>
	/// 保存模板
	/// </summary>
	/// <param name="templateDTO"></param>
	WF_TEMPLATEDTO SaveTemplate(WF_TEMPLATEDTO templateDTO);

	/// <summary>
	/// 更新模板
	/// </summary>
	/// <param name="templateDTO">更新DTO</param>
	/// <returns></returns>
	void UpdateTemplate(WF_TEMPLATEDTO templateDTO);

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <returns></returns>
	WF_TEMPLATEDTO GetTemplateById(Guid templateId);

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="templateFormId">模板表单ID</param>
	/// <returns></returns>
	WF_TEMPLATEDTO GetTemplateByTemplateFormID(Guid templateFormId);

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <param name="parameter">查询模板</param>
	/// <returns></returns>
	QueryResult<WF_TEMPLATEDTO> GetTemplateByParameter(TemplateParameter parameter);

	/// <summary>
	///
	/// </summary>
	/// <param name="url"></param>
	/// <returns></returns>
	IList<WF_TEMPLATE_FORMDTO> GetTemplateFormByUrl(string url);

	/// <summary>
	/// 获取互斥步骤
	/// </summary>
	/// <param name="instanceId">流程实例ID</param>
	/// <param name="activityId">当前工作项对应的节点ID</param>
	/// <returns></returns>
	List<ReturnConstraintActivitys> GetReturnConstraintActivitys(Guid instanceId, Guid activityId);

	/// <summary>
	/// 获取指定用户参与的流程集合
	/// </summary>
	/// <param name="userId"></param>
	/// <returns></returns>
	List<WF_TEMPLATEDTO> GetTemplateByUserId(Guid userId);

	/// <summary>
	/// 获取模板
	/// </summary>
	/// <returns></returns>
	List<WF_TEMPLATEDTO> GetTemplateNameAndVersions();

	/// <summary>
	/// 获取表单
	/// </summary>
	/// <param name="version_id"></param>
	/// <param name="form_id"></param>
	/// <returns></returns>
	List<WF_FORMDTO> GetTemplateForms(Guid? version_id, Guid? form_id);

	List<WF_TEMPLATEDTO> GetTemplateByPackage(WF_TEMPLATEDTO dto);

	List<WF_TEMPLATEDTO> GetActiveTemplateByPackageid(WF_TEMPLATEDTO dto);

	IList<Driver> GetNextDrivers(WF_TEMPLATEDTO template, WF_ACTIVITYDTO activity, string ruleExpress = null);

	IList<Driver> GetBackDrivers(WF_TEMPLATEDTO template, WF_ACTIVITYDTO activity);

	List<WF_TEMPLATEDTO> GetTemplateVersionList(Guid? parentTemplateId);

	bool ActiveTemplate(WF_TEMPLATEDTO template);

	bool DeleteTemplate(WF_TEMPLATEDTO template);

	object GetMyTemplate(string action = null);

	object WorkflowDataMigration(IList<DataMigrationDTO> list);

	IDTO GetAccountDataByInstanceId(Guid instanceId, Guid? pid);

	void EditAccount(Guid instanceId, string formData);

	QueryResult<WF_INSTANCEDTO> GetWorkflowMonitorByUser(WorkflowMonitorParameter parameter);

	bool Authentication(WF_WORKITEMDTO workItem);

	IList<WF_ACTIVITYDTO> GetFutureDriversInvoke(WF_TEMPLATEDTO template, Guid orgId, Driver driver, string ruleExpress = null);

	WF_TEMPLATEDTO GetFuture(WF_ACTIVITYDTO activityDto);
}
