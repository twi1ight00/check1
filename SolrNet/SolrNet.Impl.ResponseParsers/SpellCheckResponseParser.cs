using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses spell-checking results from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class SpellCheckResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
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
		XElement spellCheckingNode = xml.XPathSelectElement("response/lst[@name='spellcheck']");
		if (spellCheckingNode != null)
		{
			results.SpellChecking = ParseSpellChecking(spellCheckingNode);
		}
	}

	/// <summary>
	/// Parses spell-checking results
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public SpellCheckResults ParseSpellChecking(XElement node)
	{
		SpellCheckResults r = new SpellCheckResults();
		XElement suggestionsNode = node.XPathSelectElement("lst[@name='suggestions']");
		XElement collationNode = suggestionsNode.XPathSelectElement("str[@name='collation']");
		if (collationNode != null)
		{
			r.Collation = collationNode.Value;
		}
		IEnumerable<XElement> spellChecks = suggestionsNode.Elements("lst");
		foreach (XElement c in spellChecks)
		{
			SpellCheckResult result = new SpellCheckResult();
			result.Query = c.Attribute("name").Value;
			result.NumFound = Convert.ToInt32(c.XPathSelectElement("int[@name='numFound']").Value);
			result.EndOffset = Convert.ToInt32(c.XPathSelectElement("int[@name='endOffset']").Value);
			result.StartOffset = Convert.ToInt32(c.XPathSelectElement("int[@name='startOffset']").Value);
			List<string> suggestions = new List<string>();
			IEnumerable<XElement> suggestionNodes = c.XPathSelectElements("arr[@name='suggestion']/str");
			foreach (XElement suggestionNode in suggestionNodes)
			{
				suggestions.Add(suggestionNode.Value);
			}
			result.Suggestions = suggestions;
			r.Add(result);
		}
		return r;
	}
}
