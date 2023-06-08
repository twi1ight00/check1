namespace SolrNet.Commands.Parameters;

/// <summary>
///  Different types of fragmenter used when highlighting.
/// </summary>
public enum SolrHighlightFragmenter
{
	/// <summary>
	/// Creates fixed-sized fragments with gaps for multi-valued fields.
	/// </summary>
	Gap,
	/// <summary>
	/// Create fragments that "look like" a certain regular expression. 
	/// </summary>
	Regex
}
