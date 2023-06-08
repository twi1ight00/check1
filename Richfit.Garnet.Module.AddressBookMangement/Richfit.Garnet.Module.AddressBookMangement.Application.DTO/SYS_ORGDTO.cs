using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class SYS_ORGDTO : DTOBase
{
	public Guid ORG_ID { get; set; }

	public Guid? PARENT_ORG_ID { get; set; }

	public string ORG_NAME { get; set; }

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

	public List<AB_ORG_CONTACTDTO> AB_ORG_CONTACT { get; set; }

	public List<HR_EMPLOYEEDTO> HR_EMPLOYEE { get; set; }

	public List<SYS_ORGDTO> SYS_ORG1 { get; set; }

	public SYS_ORGDTO SYS_ORG2 { get; set; }
}
