using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

/// <summary>
/// Parses more-like-this results from a query response
/// </summary>
/// <typeparam name="T"></typeparam>
public class MoreLikeThisResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	private readonly ISolrDocumentResponseParser<T> docParser;

	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(delegate(SolrQueryResults<T> r)
		{
			Parse(xml, r);
		}, F.DoNothing);
	}

	public MoreLikeThisResponseParser(ISolrDocumentResponseParser<T> docParser)
	{
		this.docParser = docParser;
	}

	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		XElement moreLikeThis = xml.XPathSelectElement("response/lst[@name='moreLikeThis']");
		if (moreLikeThis != null)
		{
			results.SimilarResults = ParseMoreLikeThis(results, moreLikeThis);
		}
	}

	/// <summary>
	/// Parses more-like-this results
	/// </summary>
	/// <param name="results"></param>
	/// <param name="node"></param>
	/// <returns></returns>
	public IDictionary<string, IList<T>> ParseMoreLikeThis(IEnumerable<T> results, XElement node)
	{
		Dictionary<string, IList<T>> r = new Dictionary<string, IList<T>>();
		IEnumerable<XElement> docRefs = node.Elements("result");
		foreach (XElement docRef in docRefs)
		{
			string docRefKey = docRef.Attribute("name").Value;
			r[docRefKey] = docParser.ParseResults(docRef);
		}
		return r;
	}
}
