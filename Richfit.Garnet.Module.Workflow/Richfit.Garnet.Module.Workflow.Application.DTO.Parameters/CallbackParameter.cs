using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 回调参数
/// </summary>
public class CallbackParameter
{
	/// <summary>
	/// 实例ID
	/// </summary>
	public Guid INSTANCE_ID { get; set; }

	/// <summary>
	/// 工作项ID
	/// </summary>
	public Guid WORKITEM_ID { get; set; }

	/// <summary>
	/// 用户ID
	/// </summary>
	public User USER_ID { get; set; }

	/// <summary>
	/// 意见
	/// </summary>
	public string SUGGESTION { get; set; }
}
