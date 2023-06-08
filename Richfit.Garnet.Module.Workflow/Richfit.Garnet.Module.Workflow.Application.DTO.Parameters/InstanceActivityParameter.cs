using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 实例活动参数
/// </summary>
public class InstanceActivityParameter
{
	/// <summary>
	/// 实例ID
	/// </summary>
	public Guid INSTANCE_ID { get; set; }

	/// <summary>
	/// 活动ID列表
	/// </summary>
	public List<Guid> ACTIVITY_IDs { get; set; }
}
