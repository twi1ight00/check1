using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

/// <summary>
/// 下一步活动
/// </summary>
public class NEXT_ACTIVITY
{
	/// <summary>
	/// 活动
	/// </summary>
	public WF_ACTIVITYDTO ACTIVITY { get; set; }

	/// <summary>
	/// 活动
	/// </summary>
	public WF_ACTIVITYDTO PARENT_ACTIVITY { get; set; }

	/// <summary>
	/// 参与人
	/// </summary>
	public List<User> USER_IDS { get; set; }
}
