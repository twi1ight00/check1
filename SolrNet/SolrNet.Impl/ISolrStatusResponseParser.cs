using System.Collections.Generic;
using System.Xml.Linq;

namespace SolrNet.Impl;

/// <summary>
/// Parses a Solr Core Result from a Core Status command.
/// </summary>
public interface ISolrStatusResponseParser
{
	/// <summary>
	/// Parses the list of returned <see cref="T:SolrNet.Impl.CoreResult" /> instances from the response returned.
	/// </summary>
	/// <param name="xml">The XML Document to parse.</param>
	/// <returns>
	/// The list of results.
	/// </returns>
	List<CoreResult> Parse(XDocument xml);
}
