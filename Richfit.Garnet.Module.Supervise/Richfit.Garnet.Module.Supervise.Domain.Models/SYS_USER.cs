using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.Supervise.Domain.Models;

public class SYS_USER : Entity
{
	public Guid USER_ID { get; set; }

	public Guid? DOMAIN_ID { get; set; }

	public string LOGON_NAME { get; set; }

	public string DISPLAY_NAME { get; set; }

	public string USER_PASSWORD { get; set; }

	public decimal? USER_TYPE { get; set; }

	public decimal? IS_FORBIDDEN { get; set; }

	public decimal SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string EXTEND1 { get; set; }

	public string EXTEND2 { get; set; }

	public string EXTEND3 { get; set; }

	public string EXTEND4 { get; set; }

	public string EXTEND5 { get; set; }

	public virtual ICollection<SUP_PORJECT> SUP_PORJECT { get; set; }

	public virtual ICollection<SUP_PORJECT> SUP_PORJECT1 { get; set; }

	public virtual ICollection<SUP_PORJECT_USER> SUP_PORJECT_USER { get; set; }

	public virtual ICollection<SUP_TASK_USER> SUP_TASK_USER { get; set; }

	public SYS_USER()
	{
		SUP_PORJECT = new HashSet<SUP_PORJECT>();
		SUP_PORJECT1 = new HashSet<SUP_PORJECT>();
		SUP_PORJECT_USER = new HashSet<SUP_PORJECT_USER>();
		SUP_TASK_USER = new HashSet<SUP_TASK_USER>();
	}
}
