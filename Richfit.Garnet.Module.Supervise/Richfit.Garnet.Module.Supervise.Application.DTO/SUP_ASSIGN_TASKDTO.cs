using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Supervise.Application.DTO;

public class SUP_ASSIGN_TASKDTO : DTOBase
{
	public Guid ASSIGN_TASK_ID { get; set; }

	public Guid? PARENT_ASSIGN_TASK_ID { get; set; }

	public string WORK_TITLE { get; set; }

	public Guid? PORJECT_ID { get; set; }

	public string PORJECT_NAME { get; set; }

	public string WORK_CONTENT { get; set; }

	public DateTime? ASSIGN_TIME { get; set; }

	public DateTime? BEGIN_TIME { get; set; }

	public DateTime? END_TIME { get; set; }

	public string HAND_REQUIREMENT { get; set; }

	public DateTime? FINISH_TIME { get; set; }

	public string FINISH_CONTENT { get; set; }

	public decimal? FEEDBACK_RATE { get; set; }

	public decimal? IS_EVALUATION { get; set; }

	public string EVALUATION_CONTENT { get; set; }

	public decimal? IS_EXCEED { get; set; }

	public decimal? IS_CAN_CHANGE { get; set; }

	public decimal? IS_CHANGE { get; set; }

	public decimal? TASK_STATUS { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<SUP_CHANGEDTO> SUP_CHANGE { get; set; }

	public List<SUP_FEED_BACKDTO> SUP_FEED_BACK { get; set; }

	public List<SUP_TASK_PROGRESSDTO> SUP_TASK_PROGRESS { get; set; }

	public List<SUP_TASK_USERDTO> SUP_TASK_USER { get; set; }

	public List<SUP_ASSIGN_TASKDTO> CHILD_TASK { get; set; }

	public string PORJECT_TITLE { get; set; }

	public string ISSUED_ORGNAME { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string S_USER_NAME { get; set; }

	public decimal TYPE_ID { get; set; }

	public decimal SUPERVISE_STATUS { get; set; }

	public string STR_TASK_STATUS { get; set; }

	public string TASK_SPONSOR_NAME { get; set; }

	public decimal TASK_TYPE { get; set; }

	public decimal SORT { get; set; }

	public DateTime? FEED_BACK_TIME { get; set; }

	public string MESSAGE_REMINDING { get; set; }

	public Guid? MESSAGE_REMINDING_USER_ID { get; set; }

	public string MESSAGE_REMINDING_USER_NAME { get; set; }

	public decimal CHILD_TASK_COUNT { get; set; }

	public decimal CHILD_TASK_TODO { get; set; }

	public decimal CHILD_TASK_INDO { get; set; }

	public decimal CHILD_TASK_APPLYFORCHANGE { get; set; }

	public decimal CHILD_TASK_APPLYFORCOMPLETED { get; set; }

	public decimal CHILD_TASK_COMPLETED { get; set; }

	public decimal CHILD_TASK_UNDO { get; set; }

	public decimal CHILD_TASK_ABNORMALCOMPLETION { get; set; }

	public DateTime? APPLY_COPLETION_TIME { get; set; }
}
