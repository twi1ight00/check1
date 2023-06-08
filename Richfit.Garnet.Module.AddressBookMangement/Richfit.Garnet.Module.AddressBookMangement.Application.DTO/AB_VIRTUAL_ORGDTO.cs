using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class AB_VIRTUAL_ORGDTO : DTOBase
{
	public Guid ORG_ID { get; set; }

	public Guid? PARENT_ORG_ID { get; set; }

	public string PARENT_ORG_NAME { get; set; }

	public string ORG_NAME { get; set; }

	public decimal SORT { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<AB_VIRTUAL_CONTACTDTO> AB_VIRTUAL_CONTACT { get; set; }
}
