using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class AB_CONTACTDTO : DTOBase
{
	public Guid CONTACT_ID { get; set; }

	public string CONTACT_NAME { get; set; }

	public int CATEGORY_TYPE { get; set; }

	public Guid? ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

	public decimal ORG_SORT { get; set; }

	public string VIRTUAL_ORG_NAME { get; set; }

	public Guid? VIRTUAL_ORG_ID { get; set; }

	public Guid? GROUP_ID { get; set; }

	public Guid? USER_ID { get; set; }

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

	public string ROOM_NUMBER { get; set; }

	public List<AB_GROUP_CONTACTDTO> AB_GROUP_CONTACT { get; set; }

	public List<AB_ORG_CONTACTDTO> AB_ORG_CONTACT { get; set; }

	public List<AB_VIRTUAL_CONTACTDTO> AB_VIRTUAL_CONTACT { get; set; }

	public string S_CONTACT_NAME { get; set; }

	public string S_MOBILE { get; set; }

	public string S_MAIL { get; set; }

	public string S_POST { get; set; }

	public string S_WORK_TEL { get; set; }

	public string DefaultGroup { get; set; }

	public Guid? EMPLOYEE_ID { get; set; }

	public string RESPONSIBILITY { get; set; }

	public IList<IT_DEVICEDTO> DEVICE_LIST { get; set; }
}
