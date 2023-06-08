using System;
using Richfit.Garnet.Module.Base.Domain;

namespace Richfit.Garnet.Module.AddressBookMangement.Domain.Models;

public class HR_EMPLOYEE : Entity
{
	public Guid EMPLOYEE_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public Guid? USER_TYPE { get; set; }

	public Guid? AFFILIATED_UNIT { get; set; }

	public string PERSON_ID { get; set; }

	public string EMPLOYEE_NAME { get; set; }

	public Guid? IN_CATEGORY { get; set; }

	public Guid? ORG_ID { get; set; }

	public string WROK_PLACE { get; set; }

	public DateTime? WORKING_START_DATE { get; set; }

	public DateTime? WORK_TIME { get; set; }

	public decimal? SEX { get; set; }

	public Guid? NATION { get; set; }

	public string HOME_TOWN { get; set; }

	public decimal? AGE { get; set; }

	public DateTime? BIRTHDAY { get; set; }

	public Guid? POLITICS_STATUS { get; set; }

	public DateTime? PARTY_TIME { get; set; }

	public Guid? ENG_LEVEL { get; set; }

	public Guid? EDUCATION { get; set; }

	public string EDUCATION_REMARK { get; set; }

	public string GRADUATION_COLLEGE { get; set; }

	public DateTime? GRADUAION_TIME { get; set; }

	public string SCHOOL_MAJOR { get; set; }

	public string ADMINISTRATIVE_FUNCTION { get; set; }

	public string ADMINISTRATIVE_LEVEL { get; set; }

	public string ORIGINAL_UNIT { get; set; }

	public Guid? TECHNICAL_POSITION { get; set; }

	public Guid? RANK { get; set; }

	public DateTime? QUALIFY_TIME { get; set; }

	public string MOBILE { get; set; }

	public string MPHONE { get; set; }

	public string ID_NUMBER { get; set; }

	public string MAIL { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? CREATOR { get; set; }

	public DateTime? MODIFYTIME { get; set; }

	public string UNIT_COMPILATION { get; set; }

	public string ORDER_BK_BUSINESS_TYPE { get; set; }

	public string POSITION_TYPE { get; set; }

	public DateTime? JOIN_RUI_TUO { get; set; }

	public DateTime? YL_START_DATE { get; set; }

	public string CONTRACT_NO { get; set; }

	public string CONTRACT_TYPE { get; set; }

	public DateTime? CONTRACT_VALIDITY_DATE { get; set; }

	public string CONTRACT_EXPIRY_DATE { get; set; }

	public string WORK_TEL { get; set; }

	public string WORK_HOME { get; set; }

	public string JOB_PO_NAME { get; set; }

	public string JOB_PO_UP_SEQ { get; set; }

	public string JOB_PO_SEQ { get; set; }

	public string JOB_PO_ETHNIC_GROUP { get; set; }

	public string JOB_PO_LEVEL { get; set; }

	public Guid? CONTACT_ID { get; set; }

	public decimal? SORT { get; set; }

	public decimal? ISDEL { get; set; }

	public string IMAGE_PATH { get; set; }

	public Guid? MODIFIER { get; set; }

	public Guid? POSITION { get; set; }

	public Guid? MARITAL_STATUS { get; set; }

	public string FAMILY_CONTACT { get; set; }

	public string FAMILY_CONTACT_TEL { get; set; }

	public Guid? EMPLOYEE_STATUS { get; set; }

	public DateTime? APPOINTMENT_TIME { get; set; }

	public DateTime? TRANSFERRED_TIME { get; set; }

	public string NOTE { get; set; }

	public Guid? TECHNICAL_TITLE { get; set; }

	public string HUKOU { get; set; }

	public string TECHNICAL_TITLE_STR { get; set; }

	public virtual SYS_ORG SYS_ORG { get; set; }
}
