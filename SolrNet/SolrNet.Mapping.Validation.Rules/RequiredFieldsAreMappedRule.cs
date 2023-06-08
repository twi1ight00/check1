using System;
using System.Collections.Generic;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Represents a rule validating that all SolrFields in the SolrSchema which are required are
/// either present in the mapping or as a CopyField.
/// </summary>
public class RequiredFieldsAreMappedRule : IValidationRule
{
	/// <summary>
	/// Validates that all SolrFields in the SolrSchema which are required are
	/// either present in the mapping or as a CopyField.
	/// </summary>
	/// <param name="documentType">Document type</param>
	/// <param name="solrSchema">The solr schema.</param>
	/// <param name="mappingManager">The mapping manager.</param>
	/// <returns>
	/// A collection of <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> objects with any issues found during validation.
	/// </returns>
	public IEnumerable<ValidationResult> Validate(Type documentType, SolrSchema solrSchema, IReadOnlyMappingManager mappingManager)
	{
		foreach (SolrField solrField in solrSchema.SolrFields)
		{
			if (!solrField.IsRequired)
			{
				continue;
			}
			bool fieldFoundInMappingOrCopyFields = mappingManager.GetFields(documentType).ContainsKey(solrField.Name);
			if (!fieldFoundInMappingOrCopyFields)
			{
				foreach (SolrCopyField copyField in solrSchema.SolrCopyFields)
				{
					if (copyField.Destination.Equals(solrField.Name))
					{
						fieldFoundInMappingOrCopyFields = true;
						break;
					}
				}
			}
			if (!fieldFoundInMappingOrCopyFields)
			{
				yield return new ValidationError($"Required field '{solrField.Name}' in the Solr schema is not mapped in type '{documentType.FullName}'.");
			}
		}
	}
}
