using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class COUNTDTO : DTOBase
{
	public Guid USER_ID { get; set; }

	public string WF_COUNT { get; set; }

	public string MSG_COUNT { get; set; }

	public string NEWS_COUNT { get; set; }
}
