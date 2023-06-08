using System.Collections.Generic;

namespace SolrNet;

/// <summary>
/// Operation response header
/// </summary>
public class ResponseHeader
{
	/// <summary>
	/// Result status (0 is OK)
	/// </summary>
	public int Status { get; set; }

	/// <summary>
	/// Time this operation took in ms
	/// </summary>
	public int QTime { get; set; }

	/// <summary>
	/// Parameters defined in this operation
	/// </summary>
	public IDictionary<string, string> Params { get; set; }
}
