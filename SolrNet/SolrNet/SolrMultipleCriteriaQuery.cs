using System.Collections.Generic;
using System.Linq;

namespace SolrNet;

/// <summary>
/// Represents several queries as one
/// </summary>
public class SolrMultipleCriteriaQuery : AbstractSolrQuery
{
	/// <summary>
	/// Operator to apply to the included queries
	/// </summary>
	public class Operator
	{
		public const string OR = "OR";

		public const string AND = "AND";
	}

	private readonly IEnumerable<ISolrQuery> queries;

	private readonly string oper;

	/// <summary>
	/// Queries contained in this multiple criteria
	/// </summary>
	public IEnumerable<ISolrQuery> Queries => queries;

	/// <summary>
	/// Operator used for joining these queries
	/// </summary>
	public string Oper => oper;

	public SolrMultipleCriteriaQuery(IEnumerable<ISolrQuery> queries)
		: this(queries, "")
	{
	}

	public SolrMultipleCriteriaQuery(IEnumerable<ISolrQuery> queries, string oper)
	{
		this.queries = queries;
		this.oper = oper;
	}

	/// <summary>
	/// Static create helper
	/// </summary>
	/// <param name="queries"></param>
	/// <returns></returns>
	public static SolrMultipleCriteriaQuery Create(params ISolrQuery[] queries)
	{
		return Create((IEnumerable<ISolrQuery>)queries);
	}

	/// <summary>
	/// Static create helper
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="queries"></param>
	/// <returns></returns>
	public static SolrMultipleCriteriaQuery Create<T>(IEnumerable<T> queries) where T : ISolrQuery
	{
		return new SolrMultipleCriteriaQuery(queries.Cast<ISolrQuery>());
	}
}
