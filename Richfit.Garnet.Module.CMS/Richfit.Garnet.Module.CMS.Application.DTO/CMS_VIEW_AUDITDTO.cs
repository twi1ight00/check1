using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.CMS.Application.DTO;

public class CMS_VIEW_AUDITDTO : DTOBase
{
	public Guid ID { get; set; }

	public Guid ARTICLE_ID { get; set; }

	public Guid VIEW_ID { get; set; }

	public decimal VIEW_TYPE { get; set; }

	public string VIEW_NAME { get; set; }
}
