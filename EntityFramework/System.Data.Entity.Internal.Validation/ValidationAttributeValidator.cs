using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Entity.Validation;
using System.Linq;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Validates a property, complex property or an entity using validation attributes the property 
///     or the complex/entity type is decorated with.
/// </summary>
/// <remarks>
///     Note that this class is used for validating primitive properties using attributes declared on the property 
///     (property level validation) and complex properties and entities using attributes declared on the type
///     (type level validation).
/// </remarks>
internal class ValidationAttributeValidator : IValidator
{
	/// <summary>
	///     Display attribute used to specify the display name for a property or entity.
	/// </summary>
	private readonly DisplayAttribute _displayAttribute;

	/// <summary>
	///     Validation attribute used to validate a property or an entity.
	/// </summary>
	private readonly ValidationAttribute _validationAttribute;

	/// <summary>
	///     Creates an instance of <see cref="T:System.Data.Entity.Internal.Validation.ValidationAttributeValidator" /> class.
	/// </summary>
	/// <param name="validationAttribute">
	///     Validation attribute used to validate a property or an entity.
	/// </param>
	public ValidationAttributeValidator(ValidationAttribute validationAttribute, DisplayAttribute displayAttribute)
	{
		_validationAttribute = validationAttribute;
		_displayAttribute = displayAttribute;
	}

	/// <summary>
	///     Validates a property or an entity.
	/// </summary>
	/// <param name="entityValidationContext">Validation context. Never null.</param>
	/// <param name="property">Property to validate. Null for entity validation. Not null for property validation.
	/// </param>
	/// <returns>
	///     Validation errors as <see cref="T:System.Collections.Generic.IEnumerable`1" />. Empty if no errors, never null.
	/// </returns>
	public virtual IEnumerable<DbValidationError> Validate(EntityValidationContext entityValidationContext, InternalMemberEntry property)
	{
		ValidationContext externalValidationContext = entityValidationContext.ExternalValidationContext;
		externalValidationContext.SetDisplayName(property, _displayAttribute);
		object value = ((property == null) ? entityValidationContext.InternalEntity.Entity : property.CurrentValue);
		ValidationResult validationResult = null;
		try
		{
			validationResult = _validationAttribute.GetValidationResult(value, externalValidationContext);
		}
		catch (Exception innerException)
		{
			throw new DbUnexpectedValidationException(Strings.DbUnexpectedValidationException_ValidationAttribute(externalValidationContext.DisplayName, _validationAttribute.GetType()), innerException);
		}
		if (validationResult == ValidationResult.Success)
		{
			return Enumerable.Empty<DbValidationError>();
		}
		return DbHelpers.SplitValidationResults(externalValidationContext.MemberName, new ValidationResult[1] { validationResult });
	}
}
