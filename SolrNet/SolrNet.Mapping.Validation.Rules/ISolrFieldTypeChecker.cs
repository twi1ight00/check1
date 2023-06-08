using System;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Validates a mapped document property against a Solr field type
/// </summary>
public interface ISolrFieldTypeChecker
{
	/// <summary>
	/// Validates a mapped document property against a Solr field type
	/// </summary>
	/// <param name="solrFieldType"></param>
	/// <param name="propertyName"></param>
	/// <param name="propertyType"></param>
	/// <returns></returns>
	ValidationResult Validate(SolrFieldType solrFieldType, string propertyName, Type propertyType);

	bool CanHandleType(Type propertyType);
}
