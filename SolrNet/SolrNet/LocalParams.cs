using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Exceptions;

namespace SolrNet;

/// <summary>
/// Provides a way to "localize" information about a specific argument that is being sent to Solr. 
/// In other words, it provides a way to add meta-data to certain argument types such as query strings.
/// </summary>
/// <see href="http://wiki.apache.org/solr/LocalParams" />
public class LocalParams : Dictionary<string, string>
{
	/// <summary>
	/// Query object from a query + local params
	/// </summary>
	public class LocalParamsQuery : ISolrQuery
	{
		private readonly ISolrQuery query;

		private readonly LocalParams local;

		/// <summary>
		/// Query part
		/// </summary>
		public ISolrQuery Query => query;

		/// <summary>
		/// Local params part
		/// </summary>
		public LocalParams Local => local;

		/// <summary>
		/// Query object from a query + local params
		/// </summary>
		/// <param name="query"></param>
		/// <param name="local"></param>
		public LocalParamsQuery(ISolrQuery query, LocalParams local)
		{
			this.query = query;
			this.local = local;
		}
	}

	/// <summary>
	/// New local params
	/// </summary>
	public LocalParams()
	{
	}

	/// <summary>
	/// New local params from dictionary
	/// </summary>
	/// <param name="dictionary"></param>
	public LocalParams(IDictionary<string, string> dictionary)
		: base(dictionary)
	{
	}

	public override string ToString()
	{
		if (base.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder sb = new StringBuilder();
		sb.Append("{!");
		sb.Append(string.Join(" ", this.Select((KeyValuePair<string, string> kv) => $"{kv.Key}={Quote(kv.Value)}").ToArray()));
		sb.Append("}");
		return sb.ToString();
	}

	private static string Quote(string v)
	{
		if (v == null)
		{
			throw new SolrNetException("Null LocalParam value");
		}
		if (!v.Contains(" "))
		{
			return v;
		}
		return string.Format("'{0}'", v.Replace("'", "\\'"));
	}

	public static ISolrQuery operator +(LocalParams p, ISolrQuery q)
	{
		return new LocalParamsQuery(q, p);
	}
}
