using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.Validation;

/// <summary>
///     Represents validation results for single entity.
/// </summary>
[Serializable]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
public class DbEntityValidationResult
{
	/// <summary>
	///     Entity entry the results applies to. Never null.
	/// </summary>
	[NonSerialized]
	private readonly InternalEntityEntry _entry;

	/// <summary>
	///     List of <see cref="T:System.Data.Entity.Validation.DbValidationError" /> instances. Never null. Can be empty meaning the entity is valid.
	/// </summary>
	private readonly List<DbValidationError> _validationErrors;

	/// <summary>
	///     Gets an instance of <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry" /> the results applies to.
	/// </summary>
	public DbEntityEntry Entry
	{
		get
		{
			if (_entry == null)
			{
				return null;
			}
			return new DbEntityEntry(_entry);
		}
	}

	/// <summary>
	///     Gets validation errors. Never null.
	/// </summary>
	public ICollection<DbValidationError> ValidationErrors => _validationErrors;

	/// <summary>
	///     Gets an indicator if the entity is valid.
	/// </summary>
	public bool IsValid => !_validationErrors.Any();

	/// <summary>
	///     Creates an instance of <see cref="T:System.Data.Entity.Validation.DbEntityValidationResult" /> class.
	/// </summary>
	/// <param name="entry">
	///     Entity entry the results applies to. Never null.
	/// </param>
	/// <param name="validationErrors">
	///     List of <see cref="T:System.Data.Entity.Validation.DbValidationError" /> instances. Never null. Can be empty meaning the entity is valid.
	/// </param>
	public DbEntityValidationResult(DbEntityEntry entry, IEnumerable<DbValidationError> validationErrors)
	{
		RuntimeFailureMethods.Requires(entry != null, null, "entry != null");
		RuntimeFailureMethods.Requires(validationErrors != null, null, "validationErrors != null");
		base._002Ector();
		_entry = entry.InternalEntry;
		_validationErrors = validationErrors.ToList();
	}

	/// <summary>
	///     Creates an instance of <see cref="T:System.Data.Entity.Validation.DbEntityValidationResult" /> class.
	/// </summary>
	/// <param name="entry">
	///     Entity entry the results applies to. Never null.
	/// </param>
	/// <param name="validationErrors">
	///     List of <see cref="T:System.Data.Entity.Validation.DbValidationError" /> instances. Never null. Can be empty meaning the entity is valid.
	/// </param>
	internal DbEntityValidationResult(InternalEntityEntry entry, IEnumerable<DbValidationError> validationErrors)
	{
		_entry = entry;
		_validationErrors = validationErrors.ToList();
	}
}
