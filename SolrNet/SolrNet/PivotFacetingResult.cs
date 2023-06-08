using System.Collections.Generic;

namespace SolrNet;

public class PivotFacetingResult
{
	public IDictionary<string, Pivot> Result;

	public PivotFacetingResult()
	{
		Result = new Dictionary<string, Pivot>();
	}
}
