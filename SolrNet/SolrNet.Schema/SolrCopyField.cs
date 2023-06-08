using System;

namespace SolrNet.Schema;

/// <summary>
/// Represents a Solr copy field.
/// </summary>
public class SolrCopyField
{
	/// <summary>
	/// Gets or sets the source.
	/// </summary>
	/// <value>The source.</value>
	public string Source { get; private set; }

	/// <summary>
	/// Gets or sets the destination.
	/// </summary>
	/// <value>The destination.</value>
	public string Destination { get; private set; }

	public SolrCopyField(string source, string destination)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (destination == null)
		{
			throw new ArgumentNullException("destination");
		}
		Source = source;
		Destination = destination;
	}
}
