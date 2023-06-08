using System.Linq;
using System.Xml.Linq;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

public class MoreLikeThisHandlerMatchResponseParser<T> : ISolrMoreLikeThisHandlerResponseParser<T>, ISolrAbstractResponseParser<T>
{
	private readonly ISolrDocumentResponseParser<T> docParser;

	public MoreLikeThisHandlerMatchResponseParser(ISolrDocumentResponseParser<T> docParser)
	{
		this.docParser = docParser;
	}

	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(F.DoNothing, delegate(SolrMoreLikeThisHandlerResults<T> r)
		{
			Parse(xml, r);
		});
	}

	public void Parse(XDocument xml, SolrMoreLikeThisHandlerResults<T> results)
	{
		XElement resultNode = xml.Element("response").Elements("result").FirstOrDefault((XElement e) => e.Attribute("name").Value == "match");
		results.Match = ((resultNode == null) ? default(T) : docParser.ParseResults(resultNode).FirstOrDefault());
	}
}
