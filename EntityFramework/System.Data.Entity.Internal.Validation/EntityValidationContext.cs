using System.ComponentModel.DataAnnotations;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Contains information needed to validate an entity or its properties.
/// </summary>
internal class EntityValidationContext
{
	/// <summary>
	///     The entity being validated or the entity that owns the property being validated.
	/// </summary>
	private readonly InternalEntityEntry _entityEntry;

	/// <summary>
	///     External context needed for validation.
	/// </summary>
	public ValidationContext ExternalValidationContext { get; private set; }

	/// <summary>
	///     Gets the entity being validated or the entity that owns the property being validated.
	/// </summary>
	public InternalEntityEntry InternalEntity => _entityEntry;

	/// <summary>
	///     Initializes a new instance of EntityValidationContext class.
	/// </summary>
	/// <param name="entityEntry">
	///     The entity being validated or the entity that owns the property being validated.
	/// </param>
	/// <param name="externalValidationContexts">
	///     External contexts needed for validation.
	/// </param>
	public EntityValidationContext(InternalEntityEntry entityEntry, ValidationContext externalValidationContext)
	{
		_entityEntry = entityEntry;
		ExternalValidationContext = externalValidationContext;
	}
}
