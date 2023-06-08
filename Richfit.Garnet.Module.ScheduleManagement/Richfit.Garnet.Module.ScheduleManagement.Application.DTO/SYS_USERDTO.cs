using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ScheduleManagement.Application.DTO;

public class SYS_USERDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public Guid? DOMAIN_ID { get; set; }

	public string LOGON_NAME { get; set; }

	public string DISPLAY_NAME { get; set; }

	public string USER_PASSWORD { get; set; }

	public decimal? USER_TYPE { get; set; }

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

	public decimal? IS_FORBIDDEN { get; set; }

	public List<SCH_BELONGER_USERDTO> SCH_BELONGER_USER { get; set; }

	public List<SCH_PARTICIPANTS_USERDTO> SCH_PARTICIPANTS_USER { get; set; }
}
