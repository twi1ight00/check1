using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Validation.Internal.EdmModel;

namespace System.Data.Entity.Edm.Validation.Internal;

/// <summary>
///     Data Model Validator
/// </summary>
internal class DataModelValidator
{
	public event EventHandler<DataModelErrorEventArgs> OnError;

	/// <summary>
	///     Validate the <see cref="N:System.Data.Entity.Edm.Validation.Internal.EdmModel" /> and all of its properties given certain version.
	/// </summary>
	/// <param name="root"> The root of the model to be validated </param>
	/// <param name="validateSyntax"> True to validate the syntax, otherwise false </param>
	internal void Validate(System.Data.Entity.Edm.EdmModel root, bool validateSyntax)
	{
		EdmModelValidationContext edmModelValidationContext = new EdmModelValidationContext(validateSyntax);
		edmModelValidationContext.OnError += this.OnError;
		edmModelValidationContext.Validate(root);
	}
}
