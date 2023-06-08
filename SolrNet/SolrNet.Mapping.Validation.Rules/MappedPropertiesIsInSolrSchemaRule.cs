using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Represents a rule validation that all properties in the mapping are present in the Solr schema
/// as either a SolrField or a DynamicField
/// </summary>
public class MappedPropertiesIsInSolrSchemaRule : IValidationRule
{
	/// <summary>
	/// Field names to be ignored. These fields are never checked.
	/// </summary>
	public ICollection<string> IgnoredFieldNames { get; set; }

	public MappedPropertiesIsInSolrSchemaRule()
	{
		IgnoredFieldNames = new string[2] { "score", "geo_distance" };
	}

	/// <summary>
	/// Validates that all properties in the mapping are present in the Solr schema
	/// as either a SolrField or a DynamicField
	/// </summary>
	/// <param name="documentType">Document type</param>
	/// <param name="solrSchema">The solr schema.</param>
	/// <param name="mappingManager">The mapping manager.</param>
	/// <returns>
	/// A collection of <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> objects with any issues found during validation.
	/// </returns>
	public IEnumerable<ValidationResult> Validate(Type documentType, SolrSchema solrSchema, IReadOnlyMappingManager mappingManager)
	{
		foreach (SolrFieldModel mappedField in mappingManager.GetFields(documentType).Values)
		{
			SolrFieldModel field = mappedField;
			if ((IgnoredFieldNames != null && IgnoredFieldNames.Any((string f) => f == field.FieldName)) || field.FieldName.Contains("*"))
			{
				continue;
			}
			bool fieldFoundInSolrSchema = false;
			foreach (SolrField solrField in solrSchema.SolrFields)
			{
				if (solrField.Name.Equals(field.FieldName))
				{
					fieldFoundInSolrSchema = true;
					break;
				}
			}
			if (!fieldFoundInSolrSchema)
			{
				foreach (SolrDynamicField dynamicField in solrSchema.SolrDynamicFields)
				{
					if (IsGlobMatch(dynamicField.Name, field.FieldName))
					{
						fieldFoundInSolrSchema = true;
						break;
					}
				}
			}
			if (!fieldFoundInSolrSchema)
			{
				yield return new ValidationError($"No matching SolrField or DynamicField '{field.FieldName}' found in the Solr schema for document property '{field.Property.Name}' in type '{documentType.FullName}'.");
			}
		}
	}

	private bool IsGlobMatch(string pattern, string input)
	{
		pattern = "^" + Regex.Escape(pattern).Replace("\\*", ".*") + "$";
		Regex regex = new Regex(pattern);
		return regex.Match(input).Success;
	}
}
