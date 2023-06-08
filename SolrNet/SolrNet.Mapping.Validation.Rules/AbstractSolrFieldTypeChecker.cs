using System;
using System.Collections.Generic;
using SolrNet.Schema;

namespace SolrNet.Mapping.Validation.Rules;

/// <summary>
/// Abstract schema type checker. Uses a list of "safe" types and a list of "warning" types
/// </summary>
public abstract class AbstractSolrFieldTypeChecker : ISolrFieldTypeChecker
{
	protected readonly ICollection<string> safeTypes;

	protected readonly ICollection<string> warningTypes;

	protected AbstractSolrFieldTypeChecker(ICollection<string> safeTypes, ICollection<string> warningTypes)
	{
		this.safeTypes = safeTypes;
		this.warningTypes = warningTypes;
	}

	public virtual ValidationResult Validate(SolrFieldType solrFieldType, string propertyName, Type propertyType)
	{
		if (safeTypes != null && safeTypes.Contains(solrFieldType.Type))
		{
			return null;
		}
		if (warningTypes != null && warningTypes.Contains(solrFieldType.Type))
		{
			return new ValidationWarning($"Property '{propertyName}' of type '{propertyType.FullName}' is mapped to a solr field of type '{solrFieldType.Name}'. These types are not fully compatible.");
		}
		return new ValidationError($"Property '{propertyName}' of type '{propertyType.FullName}' cannot be stored in solr field type '{solrFieldType.Name}'.");
	}

	/// <summary>
	/// Returns true if this type checked can handle <paramref name="propertyType" />
	/// </summary>
	/// <param name="propertyType">Type to check if this checker can handle</param>
	/// <returns></returns>
	public abstract bool CanHandleType(Type propertyType);
}
