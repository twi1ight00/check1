using System;
using System.Collections.Generic;
using SolrNet.Mapping.Validation.Rules;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation;

/// <summary>
/// Manages the validation of a mapping against a solr schema XML document.
/// </summary>
public class MappingValidator : IMappingValidator
{
	private readonly IReadOnlyMappingManager mappingManager;

	private readonly IValidationRule[] rules;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:SolrNet.Mapping.Validation.MappingValidator" /> class.
	/// </summary>
	/// <param name="mappingManager">The mapping manager that is used to map types to and from their Solr representation.</param>
	/// <param name="rules">Validation rules</param>
	public MappingValidator(IReadOnlyMappingManager mappingManager, IValidationRule[] rules)
	{
		this.mappingManager = mappingManager;
		this.rules = rules;
	}

	/// <summary>
	/// Validates the specified validation rules.
	/// </summary>
	/// <param name="documentType">The document type which needs to be validated</param>
	/// <param name="schema">The Solr schema.</param>
	/// <returns>A collection of <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> objects with the problems found during validation. If Any.</returns>
	public IEnumerable<ValidationResult> EnumerateValidationResults(Type documentType, SolrSchema schema)
	{
		try
		{
			IValidationRule[] array = rules;
			foreach (IValidationRule rule in array)
			{
				IEnumerable<ValidationResult> items = rule.Validate(documentType, schema, mappingManager);
				foreach (ValidationResult item in items)
				{
					yield return item;
				}
			}
		}
		finally
		{
		}
	}
}
