using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Validation.Internal.EdmModel;

/// <summary>
///     The context for EdmModel Validation
/// </summary>
internal sealed class EdmModelValidationContext : DataModelValidationContext
{
	internal EdmModelParentMap ModelParentMap { get; private set; }

	internal event EventHandler<DataModelErrorEventArgs> OnError;

	internal EdmModelValidationContext(bool validateSyntax)
	{
		base.ValidateSyntax = validateSyntax;
	}

	internal string GetQualifiedPrefix(EdmNamespaceItem item)
	{
		string result = null;
		if (ModelParentMap.TryGetNamespace(item, out var itemNamespace))
		{
			result = itemNamespace.Name;
		}
		return result;
	}

	internal string GetQualifiedPrefix(EdmEntityContainerItem item)
	{
		string result = null;
		EdmEntityContainer container = null;
		if (ModelParentMap.TryGetEntityContainer(item, out container))
		{
			result = container.Name;
		}
		return result;
	}

	internal void RaiseDataModelValidationEvent(DataModelErrorEventArgs error)
	{
		if (this.OnError != null)
		{
			this.OnError(this, error);
		}
	}

	internal void Validate(System.Data.Entity.Edm.EdmModel root)
	{
		ModelParentMap = new EdmModelParentMap(root);
		ModelParentMap.Compute();
		base.ValidationContextVersion = root.Version;
		EdmModelValidator.Validate(root, this);
	}

	internal override void AddError(DataModelItem item, string propertyName, string errorMessage, int errorCode)
	{
		RaiseDataModelValidationEvent(new DataModelErrorEventArgs
		{
			ErrorCode = errorCode,
			ErrorMessage = errorMessage,
			Item = item,
			PropertyName = propertyName
		});
	}

	internal override void AddWarning(DataModelItem item, string propertyName, string errorMessage, int errorCode)
	{
		throw new NotImplementedException();
	}
}
