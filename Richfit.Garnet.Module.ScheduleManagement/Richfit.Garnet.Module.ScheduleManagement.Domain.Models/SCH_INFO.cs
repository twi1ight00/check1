using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.ScheduleManagement.Domain.Models;

public class SCH_INFO : Entity
{
	public Guid SCHEDULE_ID { get; set; }

	public string SCHEDULE_TITLE { get; set; }

	public string SCHEDULE_CONTENTS { get; set; }

	public decimal? SCHEDULE_TYPE { get; set; }

	public DateTime? BEGIN_TIME { get; set; }

	public DateTime? END_TIME { get; set; }

	public decimal? SCHEDULE_STATE { get; set; }

	public decimal? DISCLOSURE_LEVEL { get; set; }

	public string REMIND_MODE { get; set; }

	public DateTime? REMIND_TIME { get; set; }

	public decimal? ISALLDAY { get; set; }

	public decimal? ISREPEAT { get; set; }

	public decimal? REPEAT_INTERVAL { get; set; }

	public decimal? SCHEDULE_COLOR { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? ISSEND { get; set; }

	public string DUTY_LEADER_ID { get; set; }

	public string DUTY_LEADER { get; set; }

	public DateTime? SCHEDULE_DATE { get; set; }

	public string SCHEDULE_LOCATION { get; set; }

	public Guid? SCHEDULE_LOCATION_ID { get; set; }

	public string PARTICIPANTS_NAME { get; set; }

	public string PARTICIPANTS_NAME_STRING { get; set; }

	public string REMARK { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public string ORG_DATAS { get; set; }

	public string ORG_NAMES { get; set; }

	public string ORG_IDS { get; set; }

	public virtual ICollection<SCH_BELONGER_USER> SCH_BELONGER_USER { get; set; }

	public virtual ICollection<SCH_PARTICIPANTS_USER> SCH_PARTICIPANTS_USER { get; set; }

	public SCH_INFO()
	{
		SCH_BELONGER_USER = new HashSet<SCH_BELONGER_USER>();
		SCH_PARTICIPANTS_USER = new HashSet<SCH_PARTICIPANTS_USER>();
	}
}
