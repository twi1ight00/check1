using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Impl.FieldParsers;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses facets from query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class FacetsResponseParser<T> : ISolrAbstractResponseParser<T>
{
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		XElement mainFacetNode = xml.Element("response").Elements("lst").FirstOrDefault(X.AttrEq("name", "facet_counts"));
		if (mainFacetNode != null)
		{
			results.FacetQueries = ParseFacetQueries(mainFacetNode);
			results.FacetFields = ParseFacetFields(mainFacetNode);
			results.FacetDates = ParseFacetDates(mainFacetNode);
			results.FacetPivots = ParseFacetPivots(mainFacetNode);
		}
	}

	/// <summary>
	/// Parses facet queries results
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public IDictionary<string, int> ParseFacetQueries(XElement node)
	{
		Dictionary<string, int> d = new Dictionary<string, int>();
		IEnumerable<XElement> facetQueries = node.Elements("lst").Where(X.AttrEq("name", "facet_queries")).Elements();
		foreach (XElement fieldNode in facetQueries)
		{
			string key = fieldNode.Attribute("name").Value;
			int value = Convert.ToInt32(fieldNode.Value);
			d[key] = value;
		}
		return d;
	}

	/// <summary>
	/// Parses facet fields results
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public IDictionary<string, ICollection<KeyValuePair<string, int>>> ParseFacetFields(XElement node)
	{
		Dictionary<string, ICollection<KeyValuePair<string, int>>> d = new Dictionary<string, ICollection<KeyValuePair<string, int>>>();
		IEnumerable<XElement> facetFields = node.Elements("lst").Where(X.AttrEq("name", "facet_fields")).SelectMany((XElement x) => x.Elements());
		foreach (XElement fieldNode in facetFields)
		{
			string field = fieldNode.Attribute("name").Value;
			List<KeyValuePair<string, int>> c = new List<KeyValuePair<string, int>>();
			foreach (XElement facetNode in fieldNode.Elements())
			{
				XAttribute nameAttr = facetNode.Attribute("name");
				string key = ((nameAttr == null) ? "" : nameAttr.Value);
				int value = Convert.ToInt32(facetNode.Value);
				c.Add(new KeyValuePair<string, int>(key, value));
			}
			d[field] = c;
		}
		return d;
	}

	/// <summary>
	/// Parses facet dates results
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public IDictionary<string, DateFacetingResult> ParseFacetDates(XElement node)
	{
		Dictionary<string, DateFacetingResult> d = new Dictionary<string, DateFacetingResult>();
		IEnumerable<XElement> facetDateNode = node.Elements("lst").Where(X.AttrEq("name", "facet_dates"));
		if (facetDateNode != null)
		{
			foreach (XElement fieldNode in facetDateNode.Elements())
			{
				string name = fieldNode.Attribute("name").Value;
				d[name] = ParseDateFacetingNode(fieldNode);
			}
		}
		return d;
	}

	public DateFacetingResult ParseDateFacetingNode(XElement node)
	{
		DateFacetingResult r = new DateFacetingResult();
		IntFieldParser intParser = new IntFieldParser();
		foreach (XElement dateFacetingNode in node.Elements())
		{
			string name = dateFacetingNode.Attribute("name").Value;
			switch (name)
			{
			case "gap":
				r.Gap = dateFacetingNode.Value;
				continue;
			case "end":
				r.End = DateTimeFieldParser.ParseDate(dateFacetingNode.Value);
				continue;
			}
			if (!(dateFacetingNode.Name != "int"))
			{
				int count = (int)intParser.Parse(dateFacetingNode, typeof(int));
				if (name == FacetDateOther.After.ToString())
				{
					r.OtherResults[FacetDateOther.After] = count;
					continue;
				}
				if (name == FacetDateOther.Before.ToString())
				{
					r.OtherResults[FacetDateOther.Before] = count;
					continue;
				}
				if (name == FacetDateOther.Between.ToString())
				{
					r.OtherResults[FacetDateOther.Between] = count;
					continue;
				}
				DateTime d = DateTimeFieldParser.ParseDate(name);
				r.DateResults.Add(KV.Create(d, count));
			}
		}
		return r;
	}

	/// <summary>
	/// Parses facet pivot results
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public IDictionary<string, IList<Pivot>> ParseFacetPivots(XElement node)
	{
		Dictionary<string, IList<Pivot>> d = new Dictionary<string, IList<Pivot>>();
		IEnumerable<XElement> facetPivotNode = node.Elements("lst").Where(X.AttrEq("name", "facet_pivot"));
		foreach (XElement fieldNode in facetPivotNode.Elements())
		{
			string name = fieldNode.Attribute("name").Value;
			d[name] = fieldNode.Elements("lst").Select(ParsePivotNode).ToArray();
		}
		return d;
	}

	public Pivot ParsePivotNode(XElement node)
	{
		Pivot pivot = new Pivot();
		pivot.Field = node.Elements("str").First(X.AttrEq("name", "field")).Value;
		pivot.Value = node.Elements().First(X.AttrEq("name", "value")).Value;
		pivot.Count = int.Parse(node.Elements("int").First(X.AttrEq("name", "count")).Value);
		List<XElement> childPivotNodes = node.Elements("arr").Where(X.AttrEq("name", "pivot")).ToList();
		if (childPivotNodes.Count > 0)
		{
			pivot.HasChildPivots = true;
			pivot.ChildPivots = new List<Pivot>();
			foreach (XElement childNode in childPivotNodes.Elements())
			{
				pivot.ChildPivots.Add(ParsePivotNode(childNode));
			}
		}
		return pivot;
	}
}
