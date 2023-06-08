using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 流程调整参数
/// </summary>
public class AdjustParameter
{
	/// <summary>
	/// 工作项ID
	/// </summary>
	public Guid WORKITEM_ID { get; set; }

	/// <summary>
	/// 处理用户集合
	/// </summary>
	public List<User> HANDLE_USER { get; set; }
}
