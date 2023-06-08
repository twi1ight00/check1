using System;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Migration;

public class WFReceiver
{
	public string RID { get; set; }

	public string WorkItemID { get; set; }

	public string InstanceID { get; set; }

	public string ReceiverID { get; set; }

	public string ReceiverName { get; set; }

	public int? ReceiverType { get; set; }

	public string FinisherID { get; set; }

	public string FinisherName { get; set; }

	public DateTime? FinishTime { get; set; }

	public int? ApproveResult { get; set; }

	public string ApproveSuggestion { get; set; }

	public int? IsHandled { get; set; }

	public int? HandleOrder { get; set; }

	public int? IsDeleted { get; set; }

	public DateTime? CreateTime { get; set; }
}
