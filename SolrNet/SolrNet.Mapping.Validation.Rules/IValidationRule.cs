using System;
using System.Collections.Generic;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Provides a interface to schema mapping validation rules.
/// </summary>
public interface IValidationRule
{
	/// <summary>
	/// Validates the specified solr schema.
	/// </summary>
	/// <param name="propertyType">The type which mappings will be validated.</param>
	/// <param name="solrSchema">The solr schema.</param>
	/// <param name="mappingManager">The mapping manager.</param>
	/// <returns>A collection of <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> objects with any issues found during validation.</returns>
	IEnumerable<ValidationResult> Validate(Type propertyType, SolrSchema solrSchema, IReadOnlyMappingManager mappingManager);
}
