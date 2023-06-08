using System;

namespace SolrNet.Schema;

/// <summary>
/// Represents a Solr dynamic field.
/// </summary>
public class SolrDynamicField
{
	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	/// <value>The name.</value>
	public string Name { get; private set; }

	public SolrDynamicField(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		Name = name;
	}
}
