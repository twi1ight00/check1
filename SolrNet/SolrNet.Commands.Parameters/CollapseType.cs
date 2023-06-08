namespace SolrNet.Commands.Parameters;

/// <summary>
/// Parameters to query collapse
/// <see href="https://issues.apache.org/jira/browse/SOLR-236" />
/// </summary>
public enum CollapseType
{
	/// <summary>
	/// Collapse all documents having equal collapsing field
	/// </summary>
	Normal,
	/// <summary>
	/// Collapse only consecutive documents
	/// </summary>
	Adjacent
}
