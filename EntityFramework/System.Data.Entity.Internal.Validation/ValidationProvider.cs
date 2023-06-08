using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Used to cache and retrieve generated validators and to create context for validating entities or properties.
/// </summary>
internal class ValidationProvider
{
	/// <summary>
	///     Collection of validators keyed by the entity CLR type. Note that if there's no validation for a given type
	///     it will be associated with a null validator.
	/// </summary>
	private readonly Dictionary<Type, EntityValidator> _entityValidators;

	private readonly EntityValidatorBuilder _entityValidatorBuilder;

	/// <summary>
	///     Initializes a new instance of <see cref="T:System.Data.Entity.Internal.Validation.ValidationProvider" /> class.
	/// </summary>
	public ValidationProvider(EntityValidatorBuilder builder = null)
	{
		_entityValidators = new Dictionary<Type, EntityValidator>();
		_entityValidatorBuilder = builder ?? new EntityValidatorBuilder(new AttributeProvider());
	}

	/// <summary>
	///     Returns a validator to validate <paramref name="entityEntry" />.
	/// </summary>
	/// <param name="entityEntry">Entity the validator is requested for.</param>
	/// <returns>
	///     <see cref="T:System.Data.Entity.Internal.Validation.EntityValidator" /> to validate <paramref name="entityEntry" />. Possibly null if no validation 
	///     has been specified for the entity.
	/// </returns>
	public virtual EntityValidator GetEntityValidator(InternalEntityEntry entityEntry)
	{
		Type entityType = entityEntry.EntityType;
		EntityValidator value = null;
		if (_entityValidators.TryGetValue(entityType, out value))
		{
			return value;
		}
		value = _entityValidatorBuilder.BuildEntityValidator(entityEntry);
		_entityValidators[entityType] = value;
		return value;
	}

	/// <summary>
	///     Returns a validator to validate <paramref name="property" />.
	/// </summary>
	/// <param name="property">Navigation property the validator is requested for.</param>
	/// <returns>
	///     Validator to validate <paramref name="property" />. Possibly null if no validation 
	///     has been specified for the requested property.
	/// </returns>
	public virtual PropertyValidator GetPropertyValidator(InternalEntityEntry owningEntity, InternalMemberEntry property)
	{
		EntityValidator entityValidator = GetEntityValidator(owningEntity);
		if (entityValidator == null)
		{
			return null;
		}
		return GetValidatorForProperty(entityValidator, property);
	}

	/// <summary>
	///     Gets a validator for the <paramref name="memberEntry" />.
	/// </summary>
	/// <param name="entityValidator">Entity validator.</param>
	/// <param name="memberEntry">Property to get a validator for.</param>
	/// <returns>
	///     Validator to validate <paramref name="memberEntry" />. Possibly null if there is no validation for the 
	///     <paramref name="memberEntry" />.
	/// </returns>
	/// <remarks>
	///     For complex properties this method walks up the type hierarchy to get to the entity level and then goes down
	///     and gets a validator for the child property that is an ancestor of the property to validate. If a validator
	///     returned for an ancestor is null it means that there is no validation defined beneath and the method just 
	///     propagates (and eventually returns) null.
	/// </remarks>
	protected virtual PropertyValidator GetValidatorForProperty(EntityValidator entityValidator, InternalMemberEntry memberEntry)
	{
		if (memberEntry is InternalNestedPropertyEntry internalNestedPropertyEntry)
		{
			if (!(GetValidatorForProperty(entityValidator, internalNestedPropertyEntry.ParentPropertyEntry) is ComplexPropertyValidator complexPropertyValidator) || complexPropertyValidator.ComplexTypeValidator == null)
			{
				return null;
			}
			return complexPropertyValidator.ComplexTypeValidator.GetPropertyValidator(memberEntry.Name);
		}
		return entityValidator.GetPropertyValidator(memberEntry.Name);
	}

	/// <summary>
	///     Creates <see cref="T:System.Data.Entity.Internal.Validation.EntityValidationContext" /> for <paramref name="entityEntry" />.
	/// </summary>
	/// <param name="entityEntry">Entity entry for which a validation context needs to be created.</param>
	/// <param name="items">User defined dictionary containing additional info for custom validation. This parameter is optional and can be null.</param>
	/// <returns>An instance of <see cref="T:System.Data.Entity.Internal.Validation.EntityValidationContext" /> class.</returns>
	/// <seealso cref="M:System.Data.Entity.DbContext.ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry,System.Collections.Generic.IDictionary{System.Object,System.Object})" />
	public virtual EntityValidationContext GetEntityValidationContext(InternalEntityEntry entityEntry, IDictionary<object, object> items)
	{
		return new EntityValidationContext(entityEntry, new ValidationContext(entityEntry.Entity, null, items));
	}
}
