using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses stats results from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class StatsResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
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
		XElement statsNode = xml.XPathSelectElement("response/lst[@name='stats']");
		if (statsNode != null)
		{
			results.Stats = ParseStats(statsNode, "stats_fields");
		}
	}

	/// <summary>
	/// Parses the stats results and uses recursion to get any facet results
	/// </summary>
	/// <param name="node"></param>
	/// <param name="selector">Start with 'stats_fields'</param>
	/// <returns></returns>
	public Dictionary<string, StatsResult> ParseStats(XElement node, string selector)
	{
		Dictionary<string, StatsResult> d = new Dictionary<string, StatsResult>();
		XElement mainNode = node.XPathSelectElement($"lst[@name='{selector}']");
		foreach (XElement i in mainNode.Elements())
		{
			string name = i.Attribute("name").Value;
			d[name] = ParseStatsNode(i);
		}
		return d;
	}

	public IDictionary<string, Dictionary<string, StatsResult>> ParseFacetNode(XElement node)
	{
		Dictionary<string, Dictionary<string, StatsResult>> r = new Dictionary<string, Dictionary<string, StatsResult>>();
		foreach (XElement i in node.Elements())
		{
			string facetName = i.Attribute("name").Value;
			r[facetName] = ParseStats(i.Parent, facetName);
		}
		return r;
	}

	public StatsResult ParseStatsNode(XElement node)
	{
		StatsResult r = new StatsResult();
		foreach (XElement statNode in node.Elements())
		{
			switch (statNode.Attribute("name").Value)
			{
			case "min":
				r.Min = GetDoubleValue(statNode);
				break;
			case "max":
				r.Max = GetDoubleValue(statNode);
				break;
			case "sum":
				r.Sum = GetDoubleValue(statNode);
				break;
			case "sumOfSquares":
				r.SumOfSquares = GetDoubleValue(statNode);
				break;
			case "mean":
				r.Mean = GetDoubleValue(statNode);
				break;
			case "stddev":
				r.StdDev = GetDoubleValue(statNode);
				break;
			case "count":
				r.Count = Convert.ToInt64(statNode.Value, CultureInfo.InvariantCulture);
				break;
			case "missing":
				r.Missing = Convert.ToInt64(statNode.Value, CultureInfo.InvariantCulture);
				break;
			default:
				r.FacetResults = ParseFacetNode(statNode);
				break;
			}
		}
		return r;
	}

	private static double GetDoubleValue(XElement statNode)
	{
		if (!double.TryParse(statNode.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsedValue))
		{
			return double.NaN;
		}
		return parsedValue;
	}
}
