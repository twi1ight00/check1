using System;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.String" /> type
/// </summary>
public class StringSolrFieldTypeChecker : AbstractSolrFieldTypeChecker
{
	/// <summary>
	/// Checks schema type of properties with <see cref="T:System.String" /> type
	/// </summary>
	public StringSolrFieldTypeChecker()
		: base(new string[2] { "solr.StrField", "solr.TextField" }, null)
	{
	}

	public override bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(string);
	}
}
