using System;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.Double" /> type
/// </summary>
public class DoubleSolrFieldTypeChecker : AbstractSolrFieldTypeChecker
{
	/// <summary>
	/// Checks schema type of properties with <see cref="T:System.Double" /> type
	/// </summary>
	public DoubleSolrFieldTypeChecker()
		: base(new string[3] { "solr.TrieDoubleField", "solr.SortableDoubleField", "solr.DoubleField" }, new string[2] { "solr.TextField", "solr.StrField" })
	{
	}

	public override bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(double) || propertyType == typeof(double?);
	}
}
