using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses collapse results from query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class CollapseExpandResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	private readonly ISolrDocumentResponseParser<T> docParser;

	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(delegate(SolrQueryResults<T> r)
		{
			Parse(xml, r);
		}, F.DoNothing);
	}

	public CollapseExpandResponseParser(ISolrDocumentResponseParser<T> docParser)
	{
		this.docParser = docParser;
	}

	/// <summary>
	/// Parses the collapsed elements
	/// </summary>
	/// <param name="xml"></param>
	/// <param name="results"></param>
	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		XElement expandElement = xml.XPathSelectElement("response/lst[@name='expanded']");
		if (expandElement != null)
		{
			results.CollapseExpand = ParseGroupedResults(expandElement);
		}
	}

	/// <summary>
	/// Parses collapsed document.ids and their counts
	/// </summary>
	/// <param name="groupNode"></param>
	/// <returns></returns>
	public CollapseExpandResults<T> ParseGroupedResults(XElement expandElement)
	{
		IEnumerable<XElement> resultElements = expandElement.Elements();
		ICollection<Group<T>> groups = ParseGroup(resultElements);
		return new CollapseExpandResults<T>(groups);
	}

	/// <summary>
	/// Parses collapsed document.ids and their counts
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public ICollection<Group<T>> ParseGroup(IEnumerable<XElement> nodes)
	{
		List<Group<T>> groups = new List<Group<T>>();
		foreach (XElement resultElement in nodes)
		{
			XAttribute groupName = resultElement.Attribute("name");
			if (groupName != null)
			{
				int groupMatches = int.Parse(resultElement.Attribute("numFound").Value);
				IList<T> parsedDocs = docParser.ParseResults(resultElement);
				groups.Add(new Group<T>
				{
					Documents = parsedDocs,
					GroupValue = groupName.Value,
					NumFound = groupMatches
				});
			}
		}
		return groups;
	}
}
