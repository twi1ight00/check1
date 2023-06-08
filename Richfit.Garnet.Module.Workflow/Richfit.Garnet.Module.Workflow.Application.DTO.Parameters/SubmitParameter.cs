using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 提交流程参数
/// </summary>
public class SubmitParameter
{
	/// <summary>
	/// 工作项ID
	/// </summary>
	public Guid WORKITEM_ID { get; set; }

	/// <summary>
	/// 接收当前工作项的用户
	/// </summary>
	public User USER_ID { get; set; }

	/// <summary>
	/// 实例ID
	/// </summary>
	public Guid INSTANCE_ID { get; set; }

	/// <summary>
	/// 处理结果
	/// </summary>
	public int HANDLE_RESULT { get; set; }

	/// <summary>
	/// 处理意见
	/// </summary>
	public string HANLE_SUGGESTION { get; set; }

	/// <summary>
	/// 处理意见
	/// </summary>
	public string RULE { get; set; }

	/// <summary>
	/// 下一步活动
	/// </summary>
	public List<NEXT_ACTIVITY> NEXT_ACTIVITY { get; set; }
}
