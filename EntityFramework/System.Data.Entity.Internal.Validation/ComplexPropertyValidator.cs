using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Validates a property of a given EDM complex type.
/// </summary>
/// <remarks>
///     This is a composite validator for a complex property of an entity.
/// </remarks>
internal class ComplexPropertyValidator : PropertyValidator
{
	/// <summary>
	///     The complex type validator.
	/// </summary>
	private readonly ComplexTypeValidator _complexTypeValidator;

	public ComplexTypeValidator ComplexTypeValidator => _complexTypeValidator;

	/// <summary>
	///     Creates an instance of <see cref="T:System.Data.Entity.Internal.Validation.ComplexPropertyValidator" /> for a given complex property.
	/// </summary>
	/// <param name="propertyName">The complex property name.</param>
	/// <param name="propertyValidators">Validators used to validate the given property.</param>
	/// <param name="complexTypeValidator">Complex type validator.</param>
	public ComplexPropertyValidator(string propertyName, IEnumerable<IValidator> propertyValidators, ComplexTypeValidator complexTypeValidator)
		: base(propertyName, propertyValidators)
	{
		_complexTypeValidator = complexTypeValidator;
	}

	/// <summary>
	///     Validates a complex property.
	/// </summary>
	/// <param name="entityValidationContext">Validation context. Never null.</param>
	/// <param name="property">Property to validate. Never null.</param>
	/// <returns>Validation errors as <see cref="T:System.Collections.Generic.IEnumerable`1" />. Empty if no errors. Never null.
	/// </returns>
	public override IEnumerable<DbValidationError> Validate(EntityValidationContext entityValidationContext, InternalMemberEntry property)
	{
		List<DbValidationError> list = new List<DbValidationError>();
		list.AddRange(base.Validate(entityValidationContext, property));
		if (!list.Any() && property.CurrentValue != null && _complexTypeValidator != null)
		{
			list.AddRange(_complexTypeValidator.Validate(entityValidationContext, (InternalPropertyEntry)property));
		}
		return list;
	}
}
