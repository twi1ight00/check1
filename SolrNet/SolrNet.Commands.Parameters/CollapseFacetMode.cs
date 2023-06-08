namespace SolrNet.Commands.Parameters;

/// <summary>
/// Controls if collapsing happens before or after faceting
/// </summary>
public enum CollapseFacetMode
{
	/// <summary>
	/// Faceting happens before collapsing
	/// </summary>
	Before,
	/// <summary>
	/// Faceting happens after collapsing
	/// </summary>
	After
}
