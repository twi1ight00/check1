using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class CMS_CATEGORYMDTO : DTOBase
{
	public Guid ID { get; set; }

	public string CATEGORY_NAME { get; set; }

	public string IMAGE { get; set; }

	public string TITLE { get; set; }

	public decimal? CNT { get; set; }
}
