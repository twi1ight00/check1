using System;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.Int64" /> type
/// </summary>
public class LongSolrFieldTypeChecker : AbstractSolrFieldTypeChecker
{
	/// <summary>
	/// Checks schema type of properties with <see cref="T:System.Int64" /> type
	/// </summary>
	public LongSolrFieldTypeChecker()
		: base(new string[3] { "solr.TrieLongField", "solr.LongField", "solr.SortableLongField" }, new string[2] { "solr.TextField", "solr.StrField" })
	{
	}

	public override bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(long) || propertyType == typeof(long?);
	}
}
