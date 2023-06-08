using System;

namespace SolrNet.Schema;

/// <summary>
/// Repesents a field in the Solr schema.
/// </summary>
public class SolrField
{
	/// <summary>
	/// Field name
	/// </summary>
	/// <value>The name.</value>
	public string Name { get; private set; }

	/// <summary>
	/// Gets or sets a value indicating whether this instance is required.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is required; otherwise, <c>false</c>.
	/// </value>
	public bool IsRequired { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this instance is multi valued.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is multi valued; otherwise, <c>false</c>.
	/// </value>
	public bool IsMultiValued { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this instance is indexed.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is indexed; otherwise, <c>false</c>.
	/// </value>
	public bool IsIndexed { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this instance is stored.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is stored; otherwise, <c>false</c>.
	/// </value>
	public bool IsStored { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this instance is docValues.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is docValues; otherwise, <c>false</c>.
	/// </value>
	public bool IsDocValues { get; set; }

	/// <summary>
	/// Field type
	/// </summary>
	/// <value>The type.</value>
	public SolrFieldType Type { get; private set; }

	/// <summary>
	/// Repesents a field in the Solr schema.
	/// </summary>
	/// <param name="name">Field name</param>
	/// <param name="type">Field type</param>
	public SolrField(string name, SolrFieldType type)
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
