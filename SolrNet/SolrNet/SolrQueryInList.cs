using System.Collections.Generic;

namespace SolrNet;

/// <summary>
/// Queries a field for a list of possible values
/// </summary>
public class SolrQueryInList : AbstractSolrQuery
{
	private readonly string fieldName;

	private readonly IEnumerable<string> list;

	/// <summary>
	/// Field name
	/// </summary>
	public string FieldName => fieldName;

	/// <summary>
	/// Field values
	/// </summary>
	public IEnumerable<string> List => list;

	/// <summary>
	/// Queries a field for a list of possible values
	/// </summary>
	/// <param name="fieldName">Solr field name</param>
	/// <param name="list">Field values to query</param>
	public SolrQueryInList(string fieldName, IEnumerable<string> list)
	{
		this.fieldName = fieldName;
		this.list = list;
	}

	/// <summary>
	/// Queries a field for a list of possible values
	/// </summary>
	/// <param name="fieldName">Solr field name</param>
	/// <param name="values">Field values to query</param>
	public SolrQueryInList(string fieldName, params string[] values)
		: this(fieldName, (IEnumerable<string>)values)
	{
	}
}
