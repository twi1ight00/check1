using System.Collections.Generic;

namespace SolrNet.Commands.Parameters;

/// <summary>
/// TermsVectorComponent parameters
/// </summary>
public class TermVectorParameters
{
	/// <summary>
	/// Provides the list of fields to get term vectors for (defaults to fl)
	/// (tv.fl)
	/// </summary>
	public IEnumerable<string> Fields { get; set; }

	public TermVectorParameterOptions Options { get; set; }
}
