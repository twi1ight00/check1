using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses highlighting results from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class HighlightingResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(delegate(SolrQueryResults<T> r)
		{
			Parse(xml, r);
		}, F.DoNothing);
	}

	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		XElement highlightingNode = xml.XPathSelectElement("response/lst[@name='highlighting']");
		if (highlightingNode != null)
		{
			results.Highlights = ParseHighlighting(results, highlightingNode);
		}
	}

	/// <summary>
	/// Parses highlighting results
	/// </summary>
	/// <param name="results"></param>
	/// <param name="node"></param>
	/// <returns></returns>
	public static IDictionary<string, HighlightedSnippets> ParseHighlighting(IEnumerable<T> results, XElement node)
	{
		Dictionary<string, HighlightedSnippets> highlights = new Dictionary<string, HighlightedSnippets>();
		IEnumerable<XElement> docRefs = node.Elements("lst");
		foreach (XElement docRef in docRefs)
		{
			string docRefKey = docRef.Attribute("name").Value;
			highlights.Add(docRefKey, ParseHighlightingFields(docRef.Elements()));
		}
		return highlights;
	}

	/// <summary>
	/// Parse highlighting snippets for each field.
	/// </summary>
	/// <param name="nodes"></param>
	/// <returns></returns>
	public static HighlightedSnippets ParseHighlightingFields(IEnumerable<XElement> nodes)
	{
		HighlightedSnippets fields = new HighlightedSnippets();
		foreach (XElement field in nodes)
		{
			string fieldName = field.Attribute("name").Value;
			ICollection<string> snippets = (from str in field.Elements("str")
				select str.Value).ToList();
			if (snippets.Count == 0 && !string.IsNullOrEmpty(field.Value))
			{
				snippets = new string[1] { field.Value };
			}
			fields.Add(fieldName, snippets);
		}
		return fields;
	}
}
