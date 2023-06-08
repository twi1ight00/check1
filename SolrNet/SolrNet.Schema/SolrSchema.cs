using System.Collections.Generic;
using System.Linq;

namespace SolrNet.Schema;

/// <summary>
/// Represents a Solr schema.
/// </summary>
public class SolrSchema
{
	/// <summary>
	/// Gets or sets the solr fields types.
	/// </summary>
	/// <value>The solr fields types.</value>
	public List<SolrFieldType> SolrFieldTypes { get; set; }

	/// <summary>
	/// Gets or sets the solr fields.
	/// </summary>
	/// <value>The solr fields.</value>
	public List<SolrField> SolrFields { get; set; }

	/// <summary>
	/// Gets or sets the solr dynamic fields.
	/// </summary>
	/// <value>The solr dynamic fields.</value>
	public List<SolrDynamicField> SolrDynamicFields { get; set; }

	/// <summary>
	/// Gets or sets the solr copy fields.
	/// </summary>
	/// <value>The solr copy fields.</value>
	public List<SolrCopyField> SolrCopyFields { get; set; }

	/// <summary>
	/// Gets or sets the unique key.
	/// </summary>
	/// <value>The unique key.</value>
	public string UniqueKey { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="T:SolrNet.Schema.SolrSchema" /> class.
	/// </summary>
	public SolrSchema()
	{
		SolrFieldTypes = new List<SolrFieldType>();
		SolrFields = new List<SolrField>();
		SolrDynamicFields = new List<SolrDynamicField>();
		SolrCopyFields = new List<SolrCopyField>();
	}

	/// <summary>
	/// Finds the solr field by name.
	/// </summary>
	/// <param name="name">The name of the solr field to find.</param>
	/// <returns>The solr field if found. Null otherwise.</returns>
	public SolrField FindSolrFieldByName(string name)
	{
		foreach (SolrField field in SolrFields)
		{
			if (field.Name.Equals(name))
			{
				return field;
			}
		}
		return null;
	}

	public SolrFieldType FindSolrFieldTypeByName(string name)
	{
		return SolrFieldTypes.FirstOrDefault((SolrFieldType t) => t.Name == name);
	}
}
