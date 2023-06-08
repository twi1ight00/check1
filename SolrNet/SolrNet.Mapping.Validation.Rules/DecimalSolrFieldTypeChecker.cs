using System;
using System.Linq;
using System.Text.RegularExpressions;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Checks schema type of properties with <see cref="T:System.Decimal" /> type
/// </summary>
public class DecimalSolrFieldTypeChecker : ISolrFieldTypeChecker
{
	public ValidationResult Validate(SolrFieldType solrFieldType, string propertyName, Type propertyType)
	{
		if (new string[2] { "solr.TextField", "solr.StrField" }.Any((string st) => st == solrFieldType.Type))
		{
			return new ValidationWarning($"Property '{propertyName}' of type '{propertyType.FullName}' is mapped to a solr field of type '{solrFieldType.Name}'. These types are not fully compatible. You won't be able to use this field for range queries.");
		}
		if (new string[2] { "FloatField", "DoubleField" }.Any((string st) => Regex.IsMatch(solrFieldType.Type, st)))
		{
			return new ValidationWarning($"Property '{propertyName}' of type '{propertyType.FullName}' is mapped to a solr field of type '{solrFieldType.Name}'. These types are not fully compatible. You might lose precision or get OverflowExceptions");
		}
		return new ValidationError($"Property '{propertyName}' of type '{propertyType.FullName}' cannot be stored in solr field type '{solrFieldType.Name}'.");
	}

	public bool CanHandleType(Type propertyType)
	{
		return propertyType == typeof(decimal) || propertyType == typeof(decimal?);
	}
}
