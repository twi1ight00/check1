using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.Enums;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Domain.Models;

namespace Richfit.Garnet.Module.Workflow.Application.Services;

public interface IRunWorkflow
{
	Guid InstanceId { get; set; }

	/// <summary>
	/// 获取下一步处理人
	/// </summary>
	/// <param name="template">流程模板</param>
	/// <param name="instance">流程实例</param>
	/// <param name="activity">活动</param>
	/// <returns>处理人</returns>
	List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson);

	/// <summary>
	/// 流程提交前执行
	/// </summary>
	/// <typeparam name="T">实体</typeparam>
	/// <param name="activity">当前的活动节点</param>
	/// <param name="t">实体</param>
	/// <returns></returns>
	bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson);

	/// <summary>
	/// 流程提交前执行
	/// </summary>
	/// <typeparam name="T">实体</typeparam>
	/// <param name="activity">当前的活动节点</param>
	/// <param name="t">实体</param>
	/// <returns></returns>
	bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson);

	/// <summary>
	/// 生成流程名称
	/// </summary>
	/// <typeparam name="T">实体模型</typeparam>
	/// <param name="templateName">流程模板名称</param>
	/// <param name="t">实体</param>
	/// <returns></returns>
	string InstanceName(string templateName, string dataJson);

	/// <summary>
	/// 保存数据到数据库
	/// </summary>
	/// <typeparam name="T">实体模型</typeparam>
	/// <param name="connection">数据库连接</param>
	/// <param name="activity">步骤</param>
	/// <param name="t">实体</param>
	/// <returns>是否保存成功</returns>
	bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson);

	IDTO FindByInstanceId(Guid instanceId);

	void SendMessage(WF_INSTANCE currentInstance, WF_WORKITEM item, WF_ACTIVITY activity, User senderUser, string emailTemplate = "");

	void SendToMsg(WF_INSTANCE currentInstance, WF_WORKITEM item, WF_ACTIVITY activity, User senderUser);

	void EditAccount(string formData);

	IDTO GetAccountDataByInstanceId(Guid instanceId, Guid? pId = null);

	/// <summary>
	/// 特殊操作，针对流程的 终止、暂停、恢复启动
	/// </summary>
	/// <param name="template"></param>
	/// <param name="instance"></param>
	/// <param name="handleResult"></param>
	/// <returns></returns>
	bool SpecialOperation(WF_TEMPLATE template, WF_INSTANCE instance, HANDLE_RESULT handleResult);
}
