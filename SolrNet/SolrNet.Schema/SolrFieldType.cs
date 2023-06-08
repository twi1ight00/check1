using System;

namespace SolrNet.Schema;

/// <summary>
/// Represents a Solr field type.
/// </summary>
public class SolrFieldType
{
	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	/// <value>The name.</value>
	public string Name { get; private set; }

	/// <summary>
	/// Gets or sets the type.
	/// </summary>
	/// <value>The type.</value>
	public string Type { get; private set; }

	/// <summary>
	/// Represents a Solr field type.
	/// </summary>
	/// <param name="name">Solr field type name</param>
	/// <param name="type">Solr field type type (java class name)</param>
	public SolrFieldType(string name, string type)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		Name = name;
		Type = type;
	}
}
