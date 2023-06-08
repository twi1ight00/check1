using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class CMS_GUESTBOOKDTO : DTOBase
{
	public Guid ID { get; set; }

	public decimal? TYPE { get; set; }

	public string CONTENT { get; set; }

	public Guid? USER_ID { get; set; }

	public string NAME { get; set; }

	public string EMAIL { get; set; }

	public string PHONE { get; set; }

	public string WORKUNIT { get; set; }

	public string IP { get; set; }

	public DateTime? CREATE_DATE { get; set; }

	public Guid? RE_USER_ID { get; set; }

	public DateTime? RE_DATE { get; set; }

	public string RE_CONTENT { get; set; }
}
