using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.MeetingManagement.Domain.Models;

public class MM_MEETING_APPLY : Entity
{
	public Guid MEETING_APPLY_ID { get; set; }

	public string REMARK { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public Guid? USER_ID { get; set; }

	public string USER_NAME { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public Guid? MEETING_ROOM_LOCATION { get; set; }

	public Guid? MEETING_ROOM_TYPE { get; set; }

	public Guid? MEETING_ROOM_ID { get; set; }

	public string MEETING_ROOM_NAME { get; set; }

	public DateTime? RESERVE_DATE { get; set; }

	public string MEETING_CONTENTS { get; set; }

	public string MEETING_TITLE { get; set; }

	public DateTime? BEGIN_TIME { get; set; }

	public DateTime? END_TIME { get; set; }

	public decimal? MEETING_STATE { get; set; }

	public decimal? DISCLOSURE_LEVEL { get; set; }

	public string REMIND_MODE { get; set; }

	public DateTime? REMIND_TIME { get; set; }

	public decimal? IS_ALLDAY { get; set; }

	public decimal? IS_REPEAT { get; set; }

	public decimal? REPEAT_INTERVAL { get; set; }

	public decimal? MEETING_COLOR { get; set; }

	public decimal? IS_SEND { get; set; }

	public string PARTICIPANTS_NAME { get; set; }

	public string PARTICIPANTS_NAME_STRING { get; set; }

	public string ORG_DATAS { get; set; }

	public string ORG_NAMES { get; set; }

	public string ORG_IDS { get; set; }

	public virtual ICollection<MM_MEETING_PARTICIPANTS> MM_MEETING_PARTICIPANTS { get; set; }

	public MM_MEETING_APPLY()
	{
		MM_MEETING_PARTICIPANTS = new HashSet<MM_MEETING_PARTICIPANTS>();
	}
}
