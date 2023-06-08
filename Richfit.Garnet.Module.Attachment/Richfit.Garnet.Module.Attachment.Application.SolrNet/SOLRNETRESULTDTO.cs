using System.Collections.Generic;
using Richfit.Garnet.Module.Attachment.SolrNet;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Attachment.Application.SolrNet;

public class SOLRNETRESULTDTO : DTOBase
{
	public List<SOLRNETDTO> SOLRNETRTS { get; set; }

	public int Total { get; set; }

	public int PageTotalCount { get; set; }
}
