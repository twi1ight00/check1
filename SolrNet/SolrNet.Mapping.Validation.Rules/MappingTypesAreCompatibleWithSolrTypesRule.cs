using System;
using System.Collections.Generic;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

public class MappingTypesAreCompatibleWithSolrTypesRule : IValidationRule
{
	private readonly ISolrFieldTypeChecker[] fieldTypeCheckers;

	public MappingTypesAreCompatibleWithSolrTypesRule(ISolrFieldTypeChecker[] fieldTypeCheckers)
	{
		this.fieldTypeCheckers = fieldTypeCheckers;
	}

	public IEnumerable<ValidationResult> Validate(Type documentType, SolrSchema solrSchema, IReadOnlyMappingManager mappingManager)
	{
		foreach (KeyValuePair<string, SolrFieldModel> x in mappingManager.GetFields(documentType))
		{
			KeyValuePair<string, SolrFieldModel> keyValuePair = x;
			SolrField solrField = solrSchema.FindSolrFieldByName(keyValuePair.Key);
			if (solrField == null)
			{
				continue;
			}
			try
			{
				ISolrFieldTypeChecker[] array = fieldTypeCheckers;
				foreach (ISolrFieldTypeChecker checker in array)
				{
					keyValuePair = x;
					if (checker.CanHandleType(keyValuePair.Value.Property.PropertyType))
					{
						SolrFieldType type = solrField.Type;
						keyValuePair = x;
						string name = keyValuePair.Value.Property.Name;
						keyValuePair = x;
						ValidationResult i = checker.Validate(type, name, keyValuePair.Value.Property.PropertyType);
						if (i != null)
						{
							yield return i;
						}
					}
				}
			}
			finally
			{
			}
		}
	}
}
