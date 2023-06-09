using System;
using System.Xml.Linq;

namespace SolrNet.Impl.ResponseParsers;

public class CoreStatusResponseParser<T> : ISolrResponseParser<T>, ISolrAbstractResponseParser<T>
{
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		if (results is SolrQueryResults<T>)
		{
			Parse(xml, (SolrQueryResults<T>)results);
		}
	}

	public void Parse(XDocument xml, SolrQueryResults<T> results)
	{
		throw new NotImplementedException();
	}
}
