using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 转批参数
/// </summary>
public class TransitParameter
{
	/// <summary>
	/// 当前处理用户
	/// </summary>
	public User CURRENT_USER_ID { get; set; }

	/// <summary>
	/// 实例ID
	/// </summary>
	public Guid INSTANCE_ID { get; set; }

	/// <summary>
	/// 工作项ID
	/// </summary>
	public Guid WORKITEM_ID { get; set; }

	/// <summary>
	/// 处理意见
	/// </summary>
	public string HANDLE_SUGGESTION { get; set; }

	/// <summary>
	/// 转批的用户
	/// </summary>
	public List<User> USER_IDS { get; set; }
}
