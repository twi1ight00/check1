using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses TermVector results from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class TermVectorResultsParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
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
		XElement rootNode = xml.XPathSelectElement("response/lst[@name='termVectors']");
		if (rootNode != null)
		{
			results.TermVectorResults = ParseDocuments(rootNode).ToList();
		}
	}

	/// <summary>
	/// Parses term vector results
	/// </summary>
	/// <param name="rootNode"></param>
	/// <returns></returns>
	public IEnumerable<TermVectorDocumentResult> ParseDocuments(XElement rootNode)
	{
		IEnumerable<XElement> docNodes = rootNode.Elements("lst");
		foreach (XElement docNode in docNodes)
		{
			string docNodeName = docNode.Attribute("name").Value;
			if (!(docNodeName == "warnings") && !(docNodeName == "uniqueKeyFieldName"))
			{
				yield return ParseDoc(docNode);
			}
		}
	}

	private static TermVectorDocumentResult ParseDoc(XElement docNode)
	{
		IEnumerable<XElement> fieldNodes = docNode.Elements();
		string uniqueKey = (from x in fieldNodes.Where(X.AttrEq("name", "uniqueKey"))
			select x.Value).FirstOrDefault();
		List<TermVectorResult> termVectorResults = fieldNodes.Where((XElement x) => !X.AttrEq("name", "uniqueKey")(x)).SelectMany(ParseField).ToList();
		return new TermVectorDocumentResult(uniqueKey, termVectorResults);
	}

	private static IEnumerable<TermVectorResult> ParseField(XElement fieldNode)
	{
		return from termNode in fieldNode.Elements()
			select ParseTerm(termNode, fieldNode.Attribute("name").Value);
	}

	private static TermVectorResult ParseTerm(XElement termNode, string fieldName)
	{
		var nameValues = (from e in termNode.Elements()
			select new
			{
				name = e.Attribute("name").Value,
				value = e.Value
			}).ToList();
		int? tf = (from x in nameValues
			where x.name == "tf"
			select (int?)int.Parse(x.value)).FirstOrDefault();
		int? df = (from x in nameValues
			where x.name == "df"
			select (int?)int.Parse(x.value)).FirstOrDefault();
		double? tfidf = (from x in nameValues
			where x.name == "tf-idf"
			select (double?)double.Parse(x.value, CultureInfo.InvariantCulture.NumberFormat)).FirstOrDefault();
		List<Offset> offsets = termNode.Elements().SelectMany(ParseOffsets).ToList();
		List<int> positions = termNode.Elements().SelectMany(ParsePositions).ToList();
		return new TermVectorResult(fieldName, termNode.Attribute("name").Value, tf, df, tfidf, offsets, positions);
	}

	private static IEnumerable<int> ParsePositions(XElement valueNode)
	{
		return from e in new XElement[1] { valueNode }
			where e.Attribute("name").Value == "positions"
			from p in e.Elements()
			select int.Parse(p.Value);
	}

	private static IEnumerable<Offset> ParseOffsets(XElement valueNode)
	{
		return from e in new XElement[1] { valueNode }
			where e.Attribute("name").Value == "offsets"
			let startEnd = e.Elements()
			let start = startEnd.FirstOrDefault((XElement x) => x.Attribute("name").Value == "start")
			let end = startEnd.FirstOrDefault((XElement x) => x.Attribute("name").Value == "end")
			where start != null
			where end != null
			select new Offset(int.Parse(start.Value), int.Parse(end.Value));
	}
}
