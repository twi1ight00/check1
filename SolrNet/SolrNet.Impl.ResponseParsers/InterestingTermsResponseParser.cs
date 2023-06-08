using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SolrNet.Impl.FieldParsers;
using SolrNet.Utils;

namespace SolrNet.Impl.ResponseParsers;

public class InterestingTermsResponseParser<T> : ISolrMoreLikeThisHandlerResponseParser<T>, ISolrAbstractResponseParser<T>
{
	public void Parse(XDocument xml, AbstractSolrQueryResults<T> results)
	{
		results.Switch(F.DoNothing, delegate(SolrMoreLikeThisHandlerResults<T> r)
		{
			Parse(xml, r);
		});
	}

	public static IEnumerable<KeyValuePair<string, float>> ParseList(XDocument xml)
	{
		XElement root = xml.Element("response").Elements("arr").FirstOrDefault((XElement e) => e.Attribute("name").Value == "interestingTerms");
		if (root == null)
		{
			return Enumerable.Empty<KeyValuePair<string, float>>();
		}
		return from x in root.Elements()
			select new KeyValuePair<string, float>(x.Value.Trim(), 0f);
	}

	public static IEnumerable<KeyValuePair<string, float>> ParseDetails(XDocument xml)
	{
		XElement root = xml.Element("response").Elements("lst").FirstOrDefault((XElement e) => e.Attribute("name").Value == "interestingTerms");
		if (root == null)
		{
			return Enumerable.Empty<KeyValuePair<string, float>>();
		}
		return from x in root.Elements()
			select new KeyValuePair<string, float>(x.Attribute("name").Value, FloatFieldParser.Parse(x));
	}

	public static IList<KeyValuePair<string, float>> ParseListOrDetails(XDocument xml)
	{
		List<KeyValuePair<string, float>> list = ParseList(xml).ToList();
		if (list.Count > 0)
		{
			return list;
		}
		return ParseDetails(xml).ToList();
	}

	public void Parse(XDocument xml, SolrMoreLikeThisHandlerResults<T> results)
	{
		results.InterestingTerms = ParseListOrDetails(xml);
	}
}
