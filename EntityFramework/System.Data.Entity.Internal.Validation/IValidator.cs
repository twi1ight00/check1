using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace System.Data.Entity.Internal.Validation;

/// <summary>
///     Abstracts simple validators used to validate entities and properties.
/// </summary>
internal interface IValidator
{
	/// <summary>
	///     Validates an entity or a property.
	/// </summary>
	/// <param name="entityValidationContext">Validation context. Never null.</param>
	/// <param name="property">Property to validate. Can be null for type level validation.</param>
	/// <returns>Validation error as<see cref="T:System.Collections.Generic.IEnumerable`1" />. Empty if no errors. Never null.
	/// </returns>
	IEnumerable<DbValidationError> Validate(EntityValidationContext entityValidationContext, InternalMemberEntry property);
}
