using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses debug results from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class DebugResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	/// <summary>
	/// Parses debug results from a query response
	/// </summary>
	/// <param name="xml">Solr xml response</param>
	/// <param name="results">Solr query results</param>
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(delegate(SolrQueryResults<T> r)
		{
			Parse(xml, r);
		}, F.DoNothing);
	}

	/// <summary>
	/// Parses debug results from a query response
	/// </summary>
	/// <param name="xml">Solr xml response</param>
	/// <param name="results">Solr query results</param>
	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		results.Debug = ParseDebugResults(xml);
	}

	private static DebugResults ParseDebugResults(XDocument xml)
	{
		XElement debugNode = xml.XPathSelectElement("response/lst[@name='debug']");
		if (debugNode == null)
		{
			return null;
		}
		XElement totalTimeNode = xml.XPathSelectElement("response/lst[@name='debug']/lst[@name='timing']/double[@name='time']");
		double totalTime = GetValue(totalTimeNode);
		XElement processNode = xml.XPathSelectElement("response/lst[@name='debug']/lst[@name='timing']/lst[@name='process']");
		IDictionary<string, double> processingTime = ParseDocuments(processNode);
		XElement prepareNode = xml.XPathSelectElement("response/lst[@name='debug']/lst[@name='timing']/lst[@name='prepare']");
		IDictionary<string, double> preparingTime = ParseDocuments(prepareNode);
		string parsedQuery = xml.XPathSelectElement("response/lst[@name='debug']/str[@name='parsedquery']").Value;
		string parsedQueryString = xml.XPathSelectElement("response/lst[@name='debug']/str[@name='parsedquery_toString']").Value;
		TimingResults timing = new TimingResults(totalTime, preparingTime, processingTime);
		XElement explainNode = xml.XPathSelectElement("response/lst[@name='debug']/lst[@name='explain']");
		return F.Func((Func<DebugResults>)delegate
		{
			IDictionary<string, ExplanationModel> dictionary = TryParseStructuredExplanations(explainNode);
			if (dictionary != null)
			{
				return new DebugResults.StructuredDebugResults(timing, parsedQuery, parsedQueryString, dictionary);
			}
			IDictionary<string, string> explanation = ParseSimpleExplanations(explainNode);
			return new DebugResults.PlainDebugResults(timing, parsedQuery, parsedQueryString, explanation);
		})();
	}

	/// <summary>
	/// Parses simple explanations from a query response
	/// </summary>
	/// <param name="rootNode">Explanation root node</param>
	/// <returns>Parsed simple explanations</returns>
	private static IDictionary<string, string> ParseSimpleExplanations(XElement rootNode)
	{
		return rootNode.Elements().ToDictionary((XElement x) => x.Attribute("name").Value, (XElement x) => x.Value);
	}

	/// <summary>
	/// Parses structured explanations from a query response
	/// </summary>
	/// <param name="rootNode">Explanation root node</param>
	/// <returns>Parsed structured explanations</returns>
	private static IDictionary<string, ExplanationModel> TryParseStructuredExplanations(XElement rootNode)
	{
		if (rootNode == null)
		{
			return null;
		}
		IEnumerable<XElement> desc = rootNode.XPathSelectElements("lst");
		if (!desc.Any())
		{
			return null;
		}
		return desc.ToDictionary((XElement x) => x.FirstAttribute.Value, ParseExplanationModel);
	}

	/// <summary>
	/// Recursively parses each explaination node from a query response
	/// </summary>
	/// <param name="item">Explanation node</param>
	/// <returns>Parsed explanation model</returns>
	private static ExplanationModel ParseExplanationModel(XElement item)
	{
		IEnumerable<XElement> detailsItems = item.XPathSelectElements("arr[@name='details']/lst");
		List<ExplanationModel> detailsResult = detailsItems.Select(ParseExplanationModel).ToList();
		return CreateExplanationModel(item, detailsResult);
	}

	/// <summary>
	/// Fills explaination model from xml node
	/// </summary>
	/// <param name="item">Explanation node</param>
	/// <param name="details">Explanation details</param>
	private static ExplanationModel CreateExplanationModel(XElement item, ICollection<ExplanationModel> details)
	{
		bool match = bool.Parse(item.XPathSelectElement("bool[@name='match']").Value);
		string description = item.XPathSelectElement("str[@name='description']").Value;
		double value = double.Parse(item.XPathSelectElement("float[@name='value']").Value, CultureInfo.InvariantCulture);
		return new ExplanationModel(match, value, description, details);
	}

	/// <summary>
	/// Parses term vector results
	/// </summary>
	/// <param name="rootNode"></param>
	/// <returns>Parsed documents</returns>
	private static IDictionary<string, double> ParseDocuments(XElement rootNode)
	{
		if (rootNode == null)
		{
			return new Dictionary<string, double>();
		}
		IEnumerable<XElement> docNodes = rootNode.Elements("lst");
		return docNodes.ToDictionary((XElement docNode) => docNode.Attribute("name").Value, (XElement docNode) => GetValue(docNode.Elements().FirstOrDefault()));
	}

	/// <summary>
	/// Parses double from xml node
	/// </summary>
	/// <param name="docNode">Xml item</param>
	/// <returns>Parsed double</returns>
	private static double GetValue(XElement docNode)
	{
		if (docNode == null)
		{
			return 0.0;
		}
		return double.Parse(docNode.Value, CultureInfo.InvariantCulture);
	}
}
