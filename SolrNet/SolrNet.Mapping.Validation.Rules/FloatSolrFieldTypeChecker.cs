using System;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.Single" /> type
/// </summary>
public class FloatSolrFieldTypeChecker : AbstractSolrFieldTypeChecker
{
	/// <summary>
	/// Checks schema type of properties with <see cref="T:System.Single" /> type
	/// </summary>
	public FloatSolrFieldTypeChecker()
		: base(new string[6] { "solr.TrieFloatField", "solr.FloatField", "solr.SortableFloatField", "solr.TrieDoubleField", "solr.SortableDoubleField", "solr.DoubleField" }, new string[2] { "solr.TextField", "solr.StrField" })
	{
	}

	public override bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(float) || propertyType == typeof(float?);
	}
}
