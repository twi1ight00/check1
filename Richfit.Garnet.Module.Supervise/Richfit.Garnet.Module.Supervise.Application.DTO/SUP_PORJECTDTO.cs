using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Supervise.Application.DTO;

public class SUP_PORJECTDTO : DTOBase
{
	public Guid PORJECT_ID { get; set; }

	public string SUPERVISE_NUMBER { get; set; }

	public decimal? SUPERVISE_TYPE { get; set; }

	public decimal? SUPERVISE_CLASSIFY { get; set; }

	public string ISSUED_ORGNAME { get; set; }

	public string ISSUED_FILENUMBER { get; set; }

	public string PORJECT_TITLE { get; set; }

	public string WORK_TITLE { get; set; }

	public string WORK_CONTENT { get; set; }

	public string LEADER_INSTRUCTION { get; set; }

	public string LEADER_NAME { get; set; }

	public DateTime? ASSIGN_TIME { get; set; }

	public DateTime? BEGIN_TIME { get; set; }

	public DateTime? END_TIME { get; set; }

	public string HAND_REQUIREMENT { get; set; }

	public DateTime? FINISH_TIME { get; set; }

	public string FINISH_CONTENT { get; set; }

	public decimal? FEEDBACK_RATE { get; set; }

	public decimal? IS_EVALUATION { get; set; }

	public decimal? IS_EXCEED { get; set; }

	public decimal? SUPERVISE_STATUS { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public string CREATE_NAME { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<SUP_ASSIGN_TASKDTO> SUP_ASSIGN_TASK { get; set; }

	public List<SUP_CHANGEDTO> SUP_CHANGE { get; set; }

	public List<SUP_PORJECT_USERDTO> SUP_PORJECT_USER { get; set; }

	public Guid USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public string STR_SUPERVISE_STATUS { get; set; }

	public decimal PROJECT_TASK_COUNT { get; set; }

	public decimal PROJECT_TODO { get; set; }

	public decimal PROJECT_INDO { get; set; }

	public decimal PROJECT_APPLYFORCHANGE { get; set; }

	public decimal PROJECT_APPLYFORCOMPLETED { get; set; }

	public decimal PROJECT_COMPLETED { get; set; }

	public decimal PROJECT_UNDO { get; set; }

	public decimal PROJECT_ABNORMALCOMPLETION { get; set; }

	public string SUPERVISOR_ID { get; set; }

	public string SUPERVISOR_NAME { get; set; }

	public decimal FOCUS_ON { get; set; }

	public decimal TIME_LIMIT { get; set; }
}
