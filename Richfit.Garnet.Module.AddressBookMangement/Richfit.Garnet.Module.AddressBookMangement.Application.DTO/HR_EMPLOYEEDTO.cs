using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class HR_EMPLOYEEDTO : DTOBase
{
	public Guid EMPLOYEE_ID { get; set; }

	public Guid CONTACT_ID { get; set; }

	public Guid ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public string EMPLOYEE_NAME { get; set; }

	public decimal? SEX { get; set; }

	public string PERSON_ID { get; set; }

	public string ID_NUMBER { get; set; }

	public DateTime? BIRTHDAY { get; set; }

	public Guid? MARITAL_STATUS { get; set; }

	public Guid? NATION { get; set; }

	public string HOME_TOWN { get; set; }

	public string HUKOU { get; set; }

	public DateTime? WORK_TIME { get; set; }

	public DateTime? TRANSFERRED_TIME { get; set; }

	public Guid? POSITION { get; set; }

	public Guid? RANK { get; set; }

	public DateTime? APPOINTMENT_TIME { get; set; }

	public DateTime? PARTY_TIME { get; set; }

	public Guid? TECHNICAL_TITLE { get; set; }

	public DateTime? QUALIFY_TIME { get; set; }

	public Guid? EDUCATION { get; set; }

	public string SCHOOL_MAJOR { get; set; }

	public DateTime? GRADUAION_TIME { get; set; }

	public string WROK_PLACE { get; set; }

	public Guid? EMPLOYEE_STATUS { get; set; }

	public decimal? SORT { get; set; }

	public string WORK_TEL { get; set; }

	public string MOBILE { get; set; }

	public string MAIL { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public string IMAGE_PATH { get; set; }

	public AB_CONTACTDTO AB_CONTACT { get; set; }

	public SYS_ORGDTO SYS_ORG { get; set; }
}
