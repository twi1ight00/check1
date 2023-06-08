using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 流程挂起、重启、终止参数
/// </summary>
public class WorkflowOperationParameter
{
	/// <summary>
	/// 实例ID
	/// </summary>
	public List<Guid> INSTANCE_ID { get; set; }

	/// <summary>
	/// 用户ID
	/// </summary>
	public User USER_ID { get; set; }

	/// <summary>
	/// 用户名称
	/// </summary>
	public string USER_NAME { get; set; }

	/// <summary>
	/// 意见
	/// </summary>
	public string SUGGESTION { get; set; }
}
