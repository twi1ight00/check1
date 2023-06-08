using System.Xml.Linq;

namespace SolrNet.Impl;

public class SolrMoreLikeThisHandlerQueryResultsParser<T> : ISolrMoreLikeThisHandlerQueryResultsParser<T>
{
	private readonly ISolrAbstractResponseParser<T>[] parsers;

	public SolrMoreLikeThisHandlerQueryResultsParser(ISolrAbstractResponseParser<T>[] parsers)
	{
		this.parsers = parsers;
	}

	public SolrMoreLikeThisHandlerResults<T> Parse(string r)
	{
		SolrMoreLikeThisHandlerResults<T> results = new SolrMoreLikeThisHandlerResults<T>();
		XDocument xml = XDocument.Parse(r);
		ISolrAbstractResponseParser<T>[] array = parsers;
		foreach (ISolrAbstractResponseParser<T> p in array)
		{
			p.Parse(xml, results);
		}
		return results;
	}
}
