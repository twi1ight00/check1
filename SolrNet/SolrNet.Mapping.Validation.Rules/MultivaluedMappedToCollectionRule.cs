using System;
using System.Collections.Generic;
using SolrNet.Impl.FieldParsers;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Represents a rule that validates that fields mapped to a solr field with mutilvalued set to true
/// are of a type that implements <see cref="T:System.Collections.Generic.IEnumerable`1" />.
/// </summary>
public class MultivaluedMappedToCollectionRule : IValidationRule
{
	/// <summary>
	/// Validates the specified the mapped document against the solr schema.
	/// </summary>
	/// <param name="documentType">Document type</param>
	/// <param name="solrSchema">The solr schema.</param>
	/// <param name="mappingManager">The mapping manager.</param>
	/// <returns>
	/// A collection of <see cref="T:SolrNet.Mapping.Validation.ValidationResult" /> objects with any issues found during validation.
	/// </returns>
	public IEnumerable<ValidationResult> Validate(Type documentType, SolrSchema solrSchema, IReadOnlyMappingManager mappingManager)
	{
		CollectionFieldParser collectionFieldParser = new CollectionFieldParser(null);
		foreach (KeyValuePair<string, SolrFieldModel> prop in mappingManager.GetFields(documentType))
		{
			KeyValuePair<string, SolrFieldModel> keyValuePair = prop;
			SolrField solrField = solrSchema.FindSolrFieldByName(keyValuePair.Key);
			if (solrField != null)
			{
				keyValuePair = prop;
				bool isCollection = collectionFieldParser.CanHandleType(keyValuePair.Value.Property.PropertyType);
				if (solrField.IsMultiValued && !isCollection)
				{
					string name = solrField.Name;
					keyValuePair = prop;
					Type declaringType = keyValuePair.Value.Property.DeclaringType;
					keyValuePair = prop;
					yield return new ValidationError($"SolrField '{name}' is multivalued while property '{declaringType}.{keyValuePair.Value.Property.Name}' is not mapped as a collection.");
				}
				else if (!solrField.IsMultiValued && isCollection)
				{
					string name2 = solrField.Name;
					keyValuePair = prop;
					Type declaringType2 = keyValuePair.Value.Property.DeclaringType;
					keyValuePair = prop;
					yield return new ValidationError($"SolrField '{name2}' is not multivalued while property '{declaringType2}.{keyValuePair.Value.Property.Name}' is mapped as a collection.");
				}
			}
		}
	}
}
