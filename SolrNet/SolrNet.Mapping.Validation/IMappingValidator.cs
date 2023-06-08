using System;
using System.Collections.Generic;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation;

/// <summary>
/// Provides an interface to validation a Solr schema against a type's mapping.
/// </summary>
public interface IMappingValidator
{
	/// <summary>
	/// Validates the specified validation rules.
	/// </summary>
	/// <param name="documentType">The document type which needs to be validated</param>
	/// <param name="schema">The Solr schema.</param>
	/// <returns>A collection of <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> objects with the problems found during validation. If Any.</returns>
	IEnumerable<ValidationResult> EnumerateValidationResults(Type documentType, SolrSchema schema);
}
