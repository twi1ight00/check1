using System.Data.Entity.Edm.Common;

namespace System.Data.Entity.Edm.Validation.Internal;

internal abstract class DataModelValidationRule
{
	internal abstract Type ValidatedType { get; }

	internal abstract void Evaluate(DataModelValidationContext context, DataModelItem item);
}
internal abstract class DataModelValidationRule<TContext, TItem> : DataModelValidationRule where TContext : DataModelValidationContext where TItem : DataModelItem
{
	protected Action<TContext, TItem> _validate;

	internal override Type ValidatedType => typeof(TItem);

	internal DataModelValidationRule(Action<TContext, TItem> validate)
	{
		_validate = validate;
	}

	internal override void Evaluate(DataModelValidationContext context, DataModelItem item)
	{
		_validate((TContext)context, (TItem)item);
	}
}
