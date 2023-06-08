using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.AddressBookMangement.Application.DTO;

public class AB_CONTACT_MOBILEDTO : DTOBase
{
	public Guid ID { get; set; }

	public string CODE { get; set; }

	public string NAME { get; set; }

	public string SEX { get; set; }

	public string PHOTOGRAPH_PATH { get; set; }

	public Guid? DEPARTMENT { get; set; }

	public string DEPARTMENT_NAME { get; set; }

	public decimal? SORT { get; set; }

	public string TELNO { get; set; }

	public string COMPANY_EMAIL { get; set; }

	public string COMPANY_TELEPHONE { get; set; }

	public string POSITION { get; set; }
}
