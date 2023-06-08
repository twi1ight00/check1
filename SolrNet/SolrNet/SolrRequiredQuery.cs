namespace SolrNet;

/// <summary>
/// Requires a query
/// </summary>
public class SolrRequiredQuery : AbstractSolrQuery
{
	private readonly ISolrQuery query;

	public ISolrQuery Query => query;

	/// <summary>
	/// Requires a query
	/// </summary>
	/// <param name="q"></param>
	public SolrRequiredQuery(ISolrQuery q)
	{
		query = q;
	}
}
