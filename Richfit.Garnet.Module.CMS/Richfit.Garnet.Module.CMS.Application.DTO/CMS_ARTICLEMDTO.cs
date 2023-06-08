using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class CMS_ARTICLEMDTO : DTOBase
{
	public Guid ID { get; set; }

	public string TITLE { get; set; }

	public string USER_NAME { get; set; }

	public decimal? HITS { get; set; }

	public DateTime? AUDIT_DATE { get; set; }

	public decimal? IS_SCANNED { get; set; }

	public decimal? ATT_COUNT { get; set; }

	public string IMAGE { get; set; }

	public string CATEGORY_NAME { get; set; }

	public string FILE_RELATIVE_PATH { get; set; }
}
