using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 流程返回参数
/// </summary>
public class ReturnParameter
{
	/// <summary>
	/// 流程模板ID
	/// </summary>
	public Guid TEMPLATE_ID { get; set; }

	/// <summary>
	/// 实例ID
	/// </summary>
	public Guid INSTANCE_ID { get; set; }

	/// <summary>
	/// 用户
	/// </summary>
	public User USER_ID { get; set; }

	/// <summary>
	/// 工作项ID
	/// </summary>
	public Guid WORKITEM_ID { get; set; }

	/// <summary>
	/// 下一个活动ID
	/// </summary>
	public Guid NEXT_ACTIVITY_ID { get; set; }

	/// <summary>
	/// 处理结果
	/// </summary>
	public int HANDLE_TYPE { get; set; }

	/// <summary>
	/// 处理意见
	/// </summary>
	public string HANDLE_SUGGESTION { get; set; }
}
