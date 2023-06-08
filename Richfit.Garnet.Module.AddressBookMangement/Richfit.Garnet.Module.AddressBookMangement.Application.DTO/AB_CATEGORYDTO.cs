using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class AB_CATEGORYDTO : DTOBase
{
	public Guid CATEGORY_ID { get; set; }

	public string CATEGORY_NAME { get; set; }

	public string CATEGORY_TYPE { get; set; }

	public string NOTE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public List<AB_PERSONAL_GROUPDTO> AB_PERSONAL_GROUP { get; set; }
}
