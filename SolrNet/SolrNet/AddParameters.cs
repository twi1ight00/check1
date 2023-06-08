namespace SolrNet;

/// <summary>
/// Contains parameters that can be specified when adding a document to the index.
/// </summary>
/// <remarks>
/// See http://wiki.apache.org/solr/UpdateXmlMessages#Optional_attributes_for_.22add.22
/// </remarks>
public class AddParameters : UpdateParameters
{
	/// <summary>
	/// Gets or sets the document overwrite option.
	/// </summary>
	/// <value>If <c>true</c>, newer documents will replace previously added documents with the same uniqueKey.</value>
	public bool? Overwrite { get; set; }
}
