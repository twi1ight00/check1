using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO;

public class SYS_USERDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public Guid? DOMAIN_ID { get; set; }

	public string DOMAIN_NAME { get; set; }

	public string LOGON_NAME { get; set; }

	public string DISPLAY_NAME { get; set; }

	public string USER_PASSWORD { get; set; }

	public decimal? USER_TYPE { get; set; }

	public string USER_TYPE_NAME { get; set; }

	public decimal SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid? ORG_ID { get; set; }

	public Guid? ROLE_ID { get; set; }

	public decimal? USER_IDENTITY_TYPE { get; set; }

	public string USER_IDENTITY_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public string EXTEND1 { get; set; }

	public string EXTEND2 { get; set; }

	public string EXTEND3 { get; set; }

	public string EXTEND4 { get; set; }

	public string EXTEND5 { get; set; }

	public decimal IS_FORBIDDEN { get; set; }

	public string IS_FORBIDDEN_NAME { get; set; }
}
