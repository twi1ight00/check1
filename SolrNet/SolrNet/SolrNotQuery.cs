namespace SolrNet;

/// <summary>
/// Negates a query
/// </summary>
public class SolrNotQuery : AbstractSolrQuery
{
	private readonly ISolrQuery query;

	public ISolrQuery Query => query;

	/// <summary>
	/// Negates a query
	/// </summary>
	/// <param name="q"></param>
	public SolrNotQuery(ISolrQuery q)
	{
		query = q;
	}
}
