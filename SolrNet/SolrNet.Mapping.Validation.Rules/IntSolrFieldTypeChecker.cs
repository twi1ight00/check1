using System;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.Int32" /> type
/// </summary>
public class IntSolrFieldTypeChecker : AbstractSolrFieldTypeChecker
{
	/// <summary>
	/// Checks schema type of properties with <see cref="T:System.Int32" /> type
	/// </summary>
	public IntSolrFieldTypeChecker()
		: base(new string[3] { "solr.TrieIntField", "solr.IntField", "solr.SortableIntField" }, new string[2] { "solr.TextField", "solr.StrField" })
	{
	}

	public override bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(int) || propertyType == typeof(int?);
	}
}
