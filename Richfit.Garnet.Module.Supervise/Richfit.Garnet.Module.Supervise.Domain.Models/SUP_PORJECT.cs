using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SUP_PORJECT : Entity
{
	public Guid PORJECT_ID { get; set; }

	public string SUPERVISE_NUMBER { get; set; }

	public decimal? SUPERVISE_TYPE { get; set; }

	public decimal? SUPERVISE_CLASSIFY { get; set; }

	public string ISSUED_ORGNAME { get; set; }

	public string ISSUED_FILENUMBER { get; set; }

	public string PORJECT_TITLE { get; set; }

	public string WORK_CONTENT { get; set; }

	public string LEADER_INSTRUCTION { get; set; }

	public string LEADER_NAME { get; set; }

	public DateTime? ASSIGN_TIME { get; set; }

	public DateTime? BEGIN_TIME { get; set; }

	public DateTime? END_TIME { get; set; }

	public string HAND_REQUIREMENT { get; set; }

	public DateTime? FINISH_TIME { get; set; }

	public string FINISH_CONTENT { get; set; }

	public decimal? IS_EXCEED { get; set; }

	public decimal? SUPERVISE_STATUS { get; set; }

	public Guid USER_ID { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public Guid? SUPERVISOR_ID { get; set; }

	public decimal? FOCUS_ON { get; set; }

	public decimal? TIME_LIMIT { get; set; }

	public virtual ICollection<SUP_ASSIGN_TASK> SUP_ASSIGN_TASK { get; set; }

	public virtual ICollection<SUP_PORJECT_USER> SUP_PORJECT_USER { get; set; }

	public virtual SYS_USER SYS_USER { get; set; }

	public virtual SYS_USER SYS_USER1 { get; set; }

	public SUP_PORJECT()
	{
		SUP_ASSIGN_TASK = new HashSet<SUP_ASSIGN_TASK>();
		SUP_PORJECT_USER = new HashSet<SUP_PORJECT_USER>();
	}
}
