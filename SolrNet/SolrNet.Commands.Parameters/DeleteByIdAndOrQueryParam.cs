using System.Collections.Generic;
using System.Xml.Linq;
using SolrNet.Impl;

namespace SolrNet.Commands.Parameters;

/// <summary>
/// Parameter to delete document(s) by one or more ids
/// and or a query parameters.
/// </summary>
public class DeleteByIdAndOrQueryParam
{
	private readonly IEnumerable<string> ids;

	private readonly ISolrQuery query;

	private readonly ISolrQuerySerializer querySerializer;

	public DeleteByIdAndOrQueryParam(IEnumerable<string> ids, ISolrQuery query, ISolrQuerySerializer querySerializer)
	{
		this.ids = ids;
		this.query = query;
		this.querySerializer = querySerializer;
	}

	public IEnumerable<XElement> ToXmlNode()
	{
		if (ids != null)
		{
			using IEnumerator<string> enumerator = ids.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return new XElement(content: enumerator.Current, name: "id");
			}
		}
		if (query != null)
		{
			yield return new XElement(content: querySerializer.Serialize(query), name: "query");
		}
	}
}
