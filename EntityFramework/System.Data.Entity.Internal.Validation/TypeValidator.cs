using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Validator used to validate an entity of a given EDM Type.
/// </summary>
/// <remarks>
///     This is a composite validator for an EDM Type.
/// </remarks>
internal abstract class TypeValidator
{
	private readonly IEnumerable<IValidator> _typeLevelValidators;

	private readonly IEnumerable<PropertyValidator> _propertyValidators;

	public IEnumerable<IValidator> TypeLevelValidators => _typeLevelValidators;

	public IEnumerable<PropertyValidator> PropertyValidators => _propertyValidators;

	/// <summary>
	///     Creates an instance <see cref="T:System.Data.Entity.Internal.Validation.EntityValidator" /> for a given EDM type.
	/// </summary>
	/// <param name="propertyValidators">Property validators.</param>
	/// <param name="typeLevelValidators">Type level validators.</param>
	public TypeValidator(IEnumerable<PropertyValidator> propertyValidators, IEnumerable<IValidator> typeLevelValidators)
	{
		_typeLevelValidators = typeLevelValidators;
		_propertyValidators = propertyValidators;
	}

	/// <summary>
	///     Validates an instance.
	/// </summary>
	/// <param name="entityValidationContext">Entity validation context. Must not be null.</param>
	/// <param name="property">The entry for the complex property. Null if validating an entity.</param>
	/// <returns><see cref="T:System.Data.Entity.Validation.DbEntityValidationResult" /> instance. Never null.</returns>
	/// <remarks>
	///     Protected so it doesn't appear on EntityValidator.
	/// </remarks>
	protected IEnumerable<DbValidationError> Validate(EntityValidationContext entityValidationContext, InternalPropertyEntry property)
	{
		List<DbValidationError> list = new List<DbValidationError>();
		ValidateProperties(entityValidationContext, property, list);
		if (!list.Any())
		{
			foreach (IValidator typeLevelValidator in _typeLevelValidators)
			{
				list.AddRange(typeLevelValidator.Validate(entityValidationContext, property));
			}
		}
		return list;
	}

	/// <summary>
	///     Validates type properties. Any validation errors will be added to <paramref name="validationErrors" />
	///     collection.
	/// </summary>
	/// <param name="entityValidationContext">
	///     Validation context. Must not be null.
	/// </param>
	/// <param name="validationErrors">
	///     Collection of validation errors. Any validation errors will be added to it.
	/// </param>
	/// <param name="parentProperty">The entry for the complex property. Null if validating an entity.</param>
	/// <remarks>
	///     Note that <paramref name="validationErrors" /> will be modified by this method. Errors should be only added,
	///     never removed or changed. Taking a collection as a modifiable parameter saves a couple of memory allocations
	///     and a merge of validation error lists per entity.
	/// </remarks>
	protected abstract void ValidateProperties(EntityValidationContext entityValidationContext, InternalPropertyEntry parentProperty, List<DbValidationError> validationErrors);

	/// <summary>
	///     Returns a validator for a child property.
	/// </summary>
	/// <param name="propertyName">Name of the child property for which to return a validator.</param>
	/// <returns>
	///     Validator for a child property. Possibly null if there are no validators for requested property.
	/// </returns>
	public PropertyValidator GetPropertyValidator(string name)
	{
		return _propertyValidators.SingleOrDefault((PropertyValidator v) => v.PropertyName == name);
	}
}
