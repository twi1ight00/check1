using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses collapse_counts from query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class CollapseResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		if (results is SolrQueryResults<T>)
		{
			Parse(xml, (SolrQueryResults<T>)results);
		}
	}

	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		XElement mainCollapseNode = xml.Element("response").Elements("lst").FirstOrDefault(X.AttrEq("name", "collapse_counts"));
		if (mainCollapseNode != null)
		{
			string value = mainCollapseNode.Elements("str").First(X.AttrEq("name", "field")).Value;
			results.Collapsing = new CollapseResults
			{
				CollapsedDocuments = ParseCollapsedResults(mainCollapseNode).ToArray(),
				Field = value
			};
		}
	}

	/// <summary>
	/// Parses collapsed document.ids and their counts
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public static IEnumerable<CollapsedDocument> ParseCollapsedResults(XElement node)
	{
		IEnumerable<XElement> results = node.Elements("lst").Where(X.AttrEq("name", "results")).Elements();
		return results.Select(delegate(XElement docNode)
		{
			string value = docNode.Elements("str").First(X.AttrEq("name", "fieldValue")).Value;
			string value2 = docNode.Elements("int").First(X.AttrEq("name", "collapseCount")).Value;
			int collapseCount = int.Parse(value2);
			return new CollapsedDocument
			{
				Id = docNode.Attribute("name").Value,
				FieldValue = value,
				CollapseCount = collapseCount
			};
		});
	}
}
