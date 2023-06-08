using System;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.DateTime" /> type
/// </summary>
public class DateTimeSolrFieldTypeChecker : AbstractSolrFieldTypeChecker
{
	/// <summary>
	/// Checks schema type of properties with <see cref="T:System.DateTime" /> type
	/// </summary>
	public DateTimeSolrFieldTypeChecker()
		: base(new string[2] { "solr.TrieDateField", "solr.DateField" }, new string[2] { "solr.TextField", "solr.StrField" })
	{
	}

	public override bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(DateTime) || propertyType == typeof(DateTime?);
	}
}
