using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 重置流程参数
/// </summary>
public class ResetWorkflowParameter
{
	/// <summary>
	/// 实例ID
	/// </summary>
	public Guid INSTANCE_ID { get; set; }

	/// <summary>
	/// 用户ID
	/// </summary>
	public User USER_ID { get; set; }
}
