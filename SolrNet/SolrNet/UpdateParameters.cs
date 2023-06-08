namespace SolrNet;

/// <summary>
/// Contains parameters that can be specified when making any update to the index.
/// </summary>
public abstract class UpdateParameters
{
	/// <summary>
	/// Gets or sets the time period (in milliseconds) within which the document will be committed to the index.
	/// </summary>
	/// <value>The time period (in milliseconds) within which the document will be committed to the index.</value>
	public int? CommitWithin { get; set; }
}
