namespace SolrNet.Commands.Parameters;

/// <summary>
/// ExpandComponent parameters
/// </summary>
public class ExpandParameters
{
	private readonly SortOrder sort;

	private readonly int? rows;

	private readonly ISolrQuery query;

	private readonly ISolrQuery filterQuery;

	/// <summary>
	/// Orders the documents with the expanded groups.
	/// </summary>
	public SortOrder Sort => sort;

	/// <summary>
	/// The number of rows to display in each group.
	/// </summary>
	public int? Rows => rows;

	/// <summary>
	/// Overrides the main q parameter, determines which documents to include in the main group.
	/// </summary>
	public ISolrQuery Query => query;

	/// <summary>
	/// Overrides main fq's, determines which documents to include in the main group.
	/// </summary>
	public ISolrQuery FilterQuery => filterQuery;

	/// <summary>
	/// ExpandComponent parameters
	/// </summary>
	/// <param name="sort">Orders the documents with the expanded groups. By default: score desc</param>
	/// <param name="rows">The number of rows to display in each group. By default: 5</param>
	/// <param name="query">(Optional) Overrides the main q parameter, determines which documents to include in the main group.</param>
	/// <param name="filterQuery">(Optional) Overrides main fq, determines which documents to include in the main group.</param>
	public ExpandParameters(SortOrder sort, int? rows, ISolrQuery query, ISolrQuery filterQuery)
	{
		this.sort = sort;
		this.rows = rows;
		this.query = query;
		this.filterQuery = filterQuery;
	}
}
