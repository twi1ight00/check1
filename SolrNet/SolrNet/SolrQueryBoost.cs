namespace SolrNet;

/// <summary>
/// Applies a boost to a query or query fragment
/// </summary>
public class SolrQueryBoost : AbstractSolrQuery
{
	private readonly ISolrQuery query;

	private readonly double factor;

	/// <summary>
	/// Boost factor
	/// </summary>
	public double Factor => factor;

	public ISolrQuery Query => query;

	/// <summary>
	/// Applies a boost to a query or query fragment
	/// </summary>
	/// <param name="query">Query to boost</param>
	/// <param name="factor">Boost factor</param>
	public SolrQueryBoost(ISolrQuery query, double factor)
	{
		this.query = query;
		this.factor = factor;
	}
}
