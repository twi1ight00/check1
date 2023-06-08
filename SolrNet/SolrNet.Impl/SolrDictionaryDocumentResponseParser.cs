using System.Collections.Generic;
using System.Xml.Linq;

namespace SolrNet.Impl;

/// <summary>
/// Parses a solr result into a dictionary of (string, object)
/// </summary>
public class SolrDictionaryDocumentResponseParser : ISolrDocumentResponseParser<Dictionary<string, object>>
{
	private readonly ISolrFieldParser fieldParser;

	public SolrDictionaryDocumentResponseParser(ISolrFieldParser fieldParser)
	{
		this.fieldParser = fieldParser;
	}

	public IList<Dictionary<string, object>> ParseResults(XElement parentNode)
	{
		List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
		if (parentNode == null)
		{
			return results;
		}
		IEnumerable<XElement> nodes = parentNode.Elements("doc");
		foreach (XElement docNode in nodes)
		{
			results.Add(ParseDocument(docNode));
		}
		return results;
	}

	public Dictionary<string, object> ParseDocument(XElement node)
	{
		Dictionary<string, object> doc = new Dictionary<string, object>();
		foreach (XElement field in node.Elements())
		{
			string fieldName = field.Attribute("name").Value;
			doc[fieldName] = fieldParser.Parse(field, typeof(object));
		}
		return doc;
	}
}
