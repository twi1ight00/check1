using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.HRManagement.Application.DTO;

public class AB_CONTACTDTO : DTOBase
{
	public Guid CONTACT_ID { get; set; }

	public string CONTACT_NAME { get; set; }

	public string MOBILE { get; set; }

	public string MAIL { get; set; }

	public string POST { get; set; }

	public string UNIT_NAME { get; set; }

	public string UNIT_ADDRESS { get; set; }

	public string UNIT_POSTCODE { get; set; }

	public string WORK_TEL { get; set; }

	public string WORK_FAX { get; set; }

	public string HOME_TEL { get; set; }

	public string HOME_ADDRESS { get; set; }

	public string HOME_POSTCODE { get; set; }

	public decimal? SEX { get; set; }

	public DateTime? BIRTHDAY { get; set; }

	public string QQ { get; set; }

	public string MSN { get; set; }

	public string MATE { get; set; }

	public string CHILD { get; set; }

	public string IMAGE_PATH { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal SORT { get; set; }

	public Guid? HR_EMPLOYEE_ID { get; set; }
}
