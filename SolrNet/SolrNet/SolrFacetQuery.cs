namespace SolrNet;

/// <summary>
/// Arbitrary facet query
/// </summary>
public class SolrFacetQuery : ISolrFacetQuery
{
	private readonly ISolrQuery query;

	public ISolrQuery Query => query;

	public SolrFacetQuery(ISolrQuery q)
	{
		query = q;
	}
}
