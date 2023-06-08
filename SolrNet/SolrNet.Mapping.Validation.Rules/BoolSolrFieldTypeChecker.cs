using System;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.Boolean" /> type
/// </summary>
public class BoolSolrFieldTypeChecker : AbstractSolrFieldTypeChecker
{
	/// <summary>
	/// Checks schema type of properties with <see cref="T:System.Boolean" /> type
	/// </summary>
	public BoolSolrFieldTypeChecker()
		: base(new string[1] { "solr.BoolField" }, new string[2] { "solr.TextField", "solr.StrField" })
	{
	}

	public override bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(bool) || propertyType == typeof(bool?);
	}
}
