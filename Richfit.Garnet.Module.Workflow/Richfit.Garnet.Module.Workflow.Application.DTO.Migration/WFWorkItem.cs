using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Migration;

public class WFWorkItem
{
	public string WorkItemID { get; set; }

	public string InstanceID { get; set; }

	public string ActivityID { get; set; }

	public string ActivityInstanceID { get; set; }

	public string WorkItemTitle { get; set; }

	public string WorkItemDesc { get; set; }

	public int? ReceiverType { get; set; }

	public string SenderID { get; set; }

	public string SenderName { get; set; }

	public DateTime? SendTime { get; set; }

	public int? Priority { get; set; }

	public int? Urgency { get; set; }

	public int? WorkItemState { get; set; }

	public int? DelegateType { get; set; }

	public string DelegateID { get; set; }

	public string DelegateName { get; set; }

	public string FormUrl { get; set; }

	public string PreWorkItemID { get; set; }

	public int? StartWorkItem { get; set; }

	public int? ApproveResult { get; set; }

	public string ApproveSuggestion { get; set; }

	public int? IsDeleted { get; set; }

	public int? Display { get; set; }

	public int? IsNew { get; set; }
}
