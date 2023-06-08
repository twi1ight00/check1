using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses group.fields from query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class GroupingResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	private readonly ISolrDocumentResponseParser<T> docParser;

	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(delegate(SolrQueryResults<T> r)
		{
			Parse(xml, r);
		}, F.DoNothing);
	}

	public GroupingResponseParser(ISolrDocumentResponseParser<T> docParser)
	{
		this.docParser = docParser;
	}

	/// <summary>
	/// Parses the grouped elements
	/// </summary>
	/// <param name="xml"></param>
	/// <param name="results"></param>
	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		XElement mainGroupingNode = xml.Element("response").Elements("lst").FirstOrDefault(X.AttrEq("name", "grouped"));
		if (mainGroupingNode != null)
		{
			var groupings = from groupNode in mainGroupingNode.Elements()
				let groupName = groupNode.Attribute("name").Value
				let groupResults = ParseGroupedResults(groupNode)
				select new { groupName, groupResults };
			results.Grouping = groupings.ToDictionary(x => x.groupName, x => x.groupResults);
		}
	}

	/// <summary>
	/// Parses collapsed document.ids and their counts
	/// </summary>
	/// <param name="groupNode"></param>
	/// <returns></returns>
	public GroupedResults<T> ParseGroupedResults(XElement groupNode)
	{
		XElement ngroupNode = groupNode.Elements("int").FirstOrDefault(X.AttrEq("name", "ngroups"));
		int matchesValue = int.Parse(groupNode.Elements("int").First(X.AttrEq("name", "matches")).Value);
		GroupedResults<T> groupedResults = new GroupedResults<T>();
		groupedResults.Groups = ParseGroup(groupNode).ToList();
		groupedResults.Matches = matchesValue;
		groupedResults.Ngroups = ((ngroupNode == null) ? null : new int?(int.Parse(ngroupNode.Value)));
		return groupedResults;
	}

	/// <summary>
	/// Parses collapsed document.ids and their counts
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public IEnumerable<Group<T>> ParseGroup(XElement node)
	{
		return from docNode in node.Elements("arr").Where(X.AttrEq("name", "groups")).Elements()
			let groupValueNode = docNode.Elements().FirstOrDefault(X.AttrEq("name", "groupValue"))
			where groupValueNode != null
			let groupValue = (groupValueNode.Name == "null") ? "UNMATCHED" : groupValueNode.Value
			let resultNode = docNode.Elements("result").First(X.AttrEq("name", "doclist"))
			let numFound = Convert.ToInt32(resultNode.Attribute("numFound").Value)
			let docs = docParser.ParseResults(resultNode).ToList()
			select new Group<T>
			{
				GroupValue = groupValue,
				Documents = docs,
				NumFound = numFound
			};
	}
}
