using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses documents from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class ResultsResponseParser<T> : ISolrAbstractResponseParser<T>
{
	private readonly ISolrDocumentResponseParser<T> docParser;

	public ResultsResponseParser(ISolrDocumentResponseParser<T> docParser)
	{
		this.docParser = docParser;
	}

	private static XElement GetMainResultNode(XDocument xml)
	{
		return xml.Element("response").Elements("result").FirstOrDefault(delegate(XElement e)
		{
			XAttribute xAttribute = e.Attribute("name");
			return xAttribute == null || string.IsNullOrEmpty(xAttribute.Value) || xAttribute.Value == "response";
		});
	}

	private static XElement GetGroupResultNode(XDocument xml)
	{
		return xml.Element("response").Elements("lst").FirstOrDefault((XElement e) => e.Attribute("name").Value == "grouped")?.Descendants().FirstOrDefault((XElement e) => e.Name == "result");
	}

	private static StartOrCursor.Cursor GetNextCursorMark(XDocument xml)
	{
		XElement nextCursorMarkElement = xml.Element("response").Elements("str").FirstOrDefault((XElement e) => e.Attribute("name").Value == "nextCursorMark");
		if (nextCursorMarkElement == null)
		{
			return null;
		}
		return new StartOrCursor.Cursor(nextCursorMarkElement.Value);
	}

	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		XElement resultNode = GetMainResultNode(xml) ?? GetGroupResultNode(xml);
		if (resultNode != null)
		{
			results.NumFound = Convert.ToInt32(resultNode.Attribute("numFound").Value);
			XAttribute maxScore = resultNode.Attribute("maxScore");
			if (maxScore != null)
			{
				results.MaxScore = double.Parse(maxScore.Value, CultureInfo.InvariantCulture.NumberFormat);
			}
			results.AddRange(docParser.ParseResults(resultNode));
			results.NextCursorMark = GetNextCursorMark(xml);
		}
	}
}
