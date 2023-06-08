using System.Xml.Linq;

namespace SolrNet.Schema;

/// <summary>
/// Provides an interface to parsing a solr schema xml document into a <see cref="T:SolrNet.Schema.SolrSchema" /> object.
/// </summary>
public interface ISolrSchemaParser
{
	/// <summary>
	/// Parses the specified solr schema XML.
	/// </summary>
	/// <param name="solrSchemaXml">The solr schema XML.</param>
	/// <returns>a object model of the solr schema.</returns>
	SolrSchema Parse(XDocument solrSchemaXml);
}
