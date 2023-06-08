namespace SolrNet.Commands.Parameters;

/// <summary>
/// Controls the output format of the grouping 
/// </summary>
public enum GroupingFormat
{
	/// <summary>
	/// The documents are presented within their groups
	/// </summary>
	Grouped,
	/// <summary>
	/// Simple : the grouped documents are presented in a single flat list.
	/// Note : The start and rows parameters refer to numbers of documents instead of numbers of groups.
	/// </summary>
	Simple
}
