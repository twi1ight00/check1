using System.Collections.Generic;

namespace SolrNet.Commands.Parameters;

/// <summary>
/// Query options
/// </summary>
public class QueryOptions : CommonQueryOptions
{
	/// <summary>
	/// Sort order.
	/// By default, it's "score desc"
	/// </summary>
	public ICollection<SortOrder> OrderBy { get; set; }

	/// <summary>
	/// Highlighting parameters
	/// </summary>
	public HighlightingParameters Highlight { get; set; }

	/// <summary>
	/// Spell-checking parameters
	/// </summary>
	public SpellCheckingParameters SpellCheck { get; set; }

	/// <summary>
	/// Terms parameters
	/// </summary>
	public TermsParameters Terms { get; set; }

	/// <summary>
	/// More-like-this parameters
	/// </summary>
	public MoreLikeThisParameters MoreLikeThis { get; set; }

	/// <summary>
	/// This parameter can be used to return the stats for a specific query on top of the results that are normally returned.  Included in the stats are
	/// min, max, sum, count, missing, sumOfSquares, mean, and stddev values.  
	/// </summary>
	public StatsParameters Stats { get; set; }

	/// <summary>
	/// This parameter can be used to collapse - or group - documents by the unique values of a specified field. Included in the results are the number of
	/// records by document key and by field value
	/// </summary>
	public CollapseParameters Collapse { get; set; }

	/// <summary>
	/// The collapsing query parser and the expand component combine to form an approach to grouping documents for field collapsing in search results.
	/// The expand component requires Solr 4.8+
	/// </summary>
	/// <see href="https://cwiki.apache.org/confluence/display/solr/Collapse+and+Expand+Results" />
	public CollapseExpandParameters CollapseExpand { get; set; }

	/// <summary>
	/// This parameter can be used to collapse - or group - documents by the unique values of a specified field. Included in the results are the number of
	/// records by document key and by field value
	/// </summary>
	public TermVectorParameters TermVector { get; set; }

	/// <summary>
	/// (only SOLR 4.0)
	/// This parameter can be used to collapse - or group - documents by the unique values of a specified field. Included in the results are the number of
	/// records by document key and by field value
	/// </summary>
	public GroupingParameters Grouping { get; set; }

	/// <summary>
	/// This parmeter can be used to group query results into clusters based on document similarity 
	/// </summary>
	public ClusteringParameters Clustering { get; set; }

	private static List<T> Add<T>(IEnumerable<T> l, IEnumerable<T> l2)
	{
		List<T> list = new List<T>(l);
		list.AddRange(l2);
		return list;
	}

	/// <summary>
	/// Adds selected fields to this instance
	/// </summary>
	/// <param name="fields"></param>
	/// <returns></returns>
	public QueryOptions AddFields(params string[] fields)
	{
		base.Fields = Add(base.Fields, fields);
		return this;
	}

	/// <summary>
	/// Adds sort orders to this instance
	/// </summary>
	/// <param name="order"></param>
	/// <returns></returns>
	public QueryOptions AddOrder(params SortOrder[] order)
	{
		OrderBy = Add(OrderBy, order);
		return this;
	}

	/// <summary>
	/// Adds filter queries to this instance
	/// </summary>
	/// <param name="queries"></param>
	/// <returns></returns>
	public QueryOptions AddFilterQueries(params ISolrQuery[] queries)
	{
		base.FilterQueries = Add(base.FilterQueries, queries);
		return this;
	}

	/// <summary>
	/// Adds facet queries to this instance
	/// </summary>
	/// <param name="queries"></param>
	/// <returns></returns>
	public QueryOptions AddFacets(params ISolrFacetQuery[] queries)
	{
		base.Facet.Queries = Add(base.Facet.Queries, queries);
		return this;
	}

	public QueryOptions()
	{
		OrderBy = new List<SortOrder>();
	}
}
