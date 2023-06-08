using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Migration;

[Serializable]
public class WFInstance
{
	public string InstanceID { get; set; }

	public string InstanceTitle { get; set; }

	public string InstanceTableName { get; set; }

	public string TmpID { get; set; }

	public string StartUserID { get; set; }

	public string StartUserName { get; set; }

	public int? RunState { get; set; }

	public string CurrentWorkItemID { get; set; }

	public string CurrentActivity { get; set; }

	public int? IsChildInstance { get; set; }

	public string ParentInstanceID { get; set; }

	public string ParentActivityID { get; set; }

	public int? NotifyParentFinished { get; set; }

	public DateTime? StartTime { get; set; }

	public DateTime? FinishTime { get; set; }

	public DateTime? PlanFinishedTime { get; set; }

	public int? Priority { get; set; }

	public int? Urgency { get; set; }

	public DateTime? LastActiveTime { get; set; }

	public int? MonitorType { get; set; }

	public string MonitorID { get; set; }

	public string MonitorID2 { get; set; }

	public int? IsDeleted { get; set; }
}
