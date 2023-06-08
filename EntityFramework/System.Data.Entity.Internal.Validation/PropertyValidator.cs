using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Validates a property of a given EDM property type.
/// </summary>
/// <remarks>
///     This is a composite validator for a property of an entity or a complex type.
/// </remarks>
internal class PropertyValidator
{
	/// <summary>
	///     Simple validators for the corresponding property.
	/// </summary>
	private readonly IEnumerable<IValidator> _propertyValidators;

	/// <summary>
	///     Name of the property the validator was created for.
	/// </summary>
	private readonly string _propertyName;

	/// <summary>
	///     Simple validators for the corresponding property.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public IEnumerable<IValidator> PropertyAttributeValidators => _propertyValidators;

	/// <summary>
	///     Gets the name of the property the validator was created for.
	/// </summary>
	public string PropertyName => _propertyName;

	/// <summary>
	///     Creates an instance of <see cref="T:System.Data.Entity.Internal.Validation.PropertyValidator" /> for a given EDM property.
	/// </summary>
	/// <param name="propertyName">The EDM property name.</param>
	/// <param name="propertyValidators">Validators used to validate the given property.</param>
	public PropertyValidator(string propertyName, IEnumerable<IValidator> propertyValidators)
	{
		_propertyValidators = propertyValidators;
		_propertyName = propertyName;
	}

	/// <summary>
	///     Validates a property.
	/// </summary>
	/// <param name="entityValidationContext">Validation context. Never null.</param>
	/// <param name="property">Property to validate. Never null.</param>
	/// <returns>Validation errors as <see cref="T:System.Collections.Generic.IEnumerable`1" />. Empty if no errors. Never null.
	/// </returns>
	public virtual IEnumerable<DbValidationError> Validate(EntityValidationContext entityValidationContext, InternalMemberEntry property)
	{
		List<DbValidationError> list = new List<DbValidationError>();
		foreach (IValidator propertyValidator in _propertyValidators)
		{
			list.AddRange(propertyValidator.Validate(entityValidationContext, property));
		}
		return list;
	}
}
