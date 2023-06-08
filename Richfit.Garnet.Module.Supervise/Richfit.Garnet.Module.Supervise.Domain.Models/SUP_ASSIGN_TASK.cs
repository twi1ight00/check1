using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SUP_ASSIGN_TASK : Entity
{
	public Guid ASSIGN_TASK_ID { get; set; }

	public Guid? PORJECT_ID { get; set; }

	public Guid? PARENT_ASSIGN_TASK_ID { get; set; }

	public string WORK_TITLE { get; set; }

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

	public decimal? TASK_TYPE { get; set; }

	public decimal? SORT { get; set; }

	public DateTime? APPLY_COPLETION_TIME { get; set; }

	public virtual SUP_PORJECT SUP_PORJECT { get; set; }

	public virtual List<SUP_CHANGE> SUP_CHANGE { get; set; }

	public virtual List<SUP_FEED_BACK> SUP_FEED_BACK { get; set; }

	public virtual List<SUP_TASK_PROGRESS> SUP_TASK_PROGRESS { get; set; }

	public virtual List<SUP_TASK_USER> SUP_TASK_USER { get; set; }

	public SUP_ASSIGN_TASK()
	{
		SUP_CHANGE = new List<SUP_CHANGE>();
		SUP_FEED_BACK = new List<SUP_FEED_BACK>();
		SUP_TASK_PROGRESS = new List<SUP_TASK_PROGRESS>();
		SUP_TASK_USER = new List<SUP_TASK_USER>();
	}
}
