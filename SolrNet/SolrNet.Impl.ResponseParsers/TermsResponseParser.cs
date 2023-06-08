using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses spell-checking results from a query response
/// </summary>
/// <typeparam name="T">Document type</typeparam>
public class TermsResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
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
		XElement termsNode = xml.XPathSelectElement("response/lst[@name='terms']");
		if (termsNode != null)
		{
			results.Terms = ParseTerms(termsNode);
		}
	}

	/// <summary>
	/// Parses spell-checking results
	/// </summary>
	/// <param name="node"></param>
	/// <returns></returns>
	public TermsResults ParseTerms(XElement node)
	{
		TermsResults r = new TermsResults();
		IEnumerable<XElement> terms = node.Elements("lst");
		foreach (XElement c in terms)
		{
			TermsResult result = new TermsResult();
			result.Field = c.Attribute("name").Value;
			List<KeyValuePair<string, int>> termList = new List<KeyValuePair<string, int>>();
			IEnumerable<XElement> termNodes = c.XPathSelectElements("int");
			foreach (XElement termNode in termNodes)
			{
				termList.Add(new KeyValuePair<string, int>(termNode.Attribute("name").Value, int.Parse(termNode.Value)));
			}
			result.Terms = termList;
			r.Add(result);
		}
		return r;
	}
}
