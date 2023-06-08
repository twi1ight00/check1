using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class AB_PERSONAL_GROUPDTO : DTOBase
{
	public Guid GROUP_ID { get; set; }

	public Guid? CATEGORY_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public string GROUP_NAME { get; set; }

	public string CATEGORY_TYPE { get; set; }

	public decimal ISDEL { get; set; }

	public Guid CREATOR { get; set; }

	public DateTime CREATETIME { get; set; }

	public Guid MODIFIER { get; set; }

	public DateTime MODIFYTIME { get; set; }

	public decimal? SORT { get; set; }

	public AB_CATEGORYDTO AB_CATEGORY { get; set; }

	public List<AB_GROUP_CONTACTDTO> AB_GROUP_CONTACT { get; set; }
}
