using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Linq;

namespace System.Data.Entity.Edm.Validation.Internal;

/// <summary>
///     RuleSet for DataModel Validation
/// </summary>
internal abstract class DataModelValidationRuleSet
{
	private readonly List<DataModelValidationRule> _rules = new List<DataModelValidationRule>();

	protected void AddRule(DataModelValidationRule rule)
	{
		_rules.Add(rule);
	}

	/// <summary>
	///     Get the related rules given certain DataModelItem
	/// </summary>
	/// <param name="itemToValidate"> The <see cref="T:System.Data.Entity.Edm.Common.DataModelItem" /> to validate </param>
	/// <returns> A collection of <see cref="T:System.Data.Entity.Edm.Validation.Internal.DataModelValidationRule" /> </returns>
	internal IEnumerable<DataModelValidationRule> GetRules(DataModelItem itemToValidate)
	{
		return _rules.Where((DataModelValidationRule r) => r.ValidatedType.IsAssignableFrom(itemToValidate.GetType()));
	}
}
