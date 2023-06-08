using System.Data.Entity.Edm.Common;

namespace System.Data.Entity.Edm.Validation.Internal.EdmModel;

internal class EdmModelValidationRule<TItem> : DataModelValidationRule<EdmModelValidationContext, TItem> where TItem : DataModelItem
{
	internal EdmModelValidationRule(Action<EdmModelValidationContext, TItem> validate)
		: base(validate)
	{
	}
}
