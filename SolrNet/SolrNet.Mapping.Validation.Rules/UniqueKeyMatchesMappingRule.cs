using System;
using System.Collections.Generic;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Validation rule for making sure the uniqueKey mapped in the type is the same as in the Solr schema.
/// </summary>
public class UniqueKeyMatchesMappingRule : IValidationRule
{
	/// <summary>
	/// Validates that the uniqueKey mapped in the type is the same as in the Solr schema.
	/// </summary>
	/// <param name="documentType">Document type</param>
	/// <param name="solrSchema">The solr schema.</param>
	/// <param name="mappingManager">The mapping manager.</param>
	/// <returns>
	/// A collection of <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> objects with any issues found during validation.
	/// </returns>
	public IEnumerable<ValidationResult> Validate(Type documentType, SolrSchema solrSchema, IReadOnlyMappingManager mappingManager)
	{
		SolrFieldModel mappedKey = mappingManager.GetUniqueKey(documentType);
		if (mappedKey != null || solrSchema.UniqueKey != null)
		{
			if (mappedKey == null && solrSchema.UniqueKey != null)
			{
				yield return new ValidationWarning($"Solr schema has unique key field '{solrSchema.UniqueKey}' but mapped type '{documentType}' doesn't have a declared unique key");
			}
			else if (mappedKey != null && solrSchema.UniqueKey == null)
			{
				yield return new ValidationError($"Type '{documentType}' has a declared unique key '{mappedKey.FieldName}' but Solr schema doesn't have a unique key");
			}
			else if (!mappedKey.FieldName.Equals(solrSchema.UniqueKey))
			{
				yield return new ValidationError($"Solr schema unique key '{solrSchema.UniqueKey}' does not match document unique key '{mappedKey}' in type '{documentType}'.");
			}
		}
	}
}
