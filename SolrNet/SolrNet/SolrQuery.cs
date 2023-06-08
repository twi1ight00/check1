using SolrNet.Impl;

namespace SolrNet;

/// <summary>
/// Basic solr query
/// </summary>	
public class SolrQuery : AbstractSolrQuery, ISelfSerializingQuery, ISolrQuery
{
	private readonly string query;

	/// <summary>
	/// Represents a query for all documents ("*:*")
	/// </summary>
	public static readonly AbstractSolrQuery All = new SolrQuery("*:*");

	/// <summary>
	/// query to execute
	/// </summary>
	public string Query => query;

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="query">solr query to execute</param>
	public SolrQuery(string query)
	{
		this.query = query;
	}
}
