using System.Data.Entity.Internal;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Exception thrown by <see cref="T:System.Data.Entity.DbContext" /> when it was expected that SaveChanges for an entity would
///     result in a database update but in fact no rows in the database were affected.  This usually indicates
///     that the database has been concurrently updated such that a concurrency token that was expected to match
///     did not actually match.
///     Note that state entries referenced by this exception are not serialized due to security and accesses to
///     the state entries after serialization will return null.
/// </summary>
[Serializable]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Database is not two words.")]
[SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "SerializeObjectState used instead")]
public class DbUpdateConcurrencyException : DbUpdateException
{
	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateConcurrencyException" /> class.
	/// </summary>
	/// <param name="context">The context.</param>
	/// <param name="innerException">The inner exception.</param>
	internal DbUpdateConcurrencyException(InternalContext context, OptimisticConcurrencyException innerException)
		: base(context, innerException, involvesIndependentAssociations: false)
	{
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> class.
	/// </summary>
	public DbUpdateConcurrencyException()
	{
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> class.
	/// </summary>
	/// <param name="message">The message.</param>
	public DbUpdateConcurrencyException(string message)
		: base(message)
	{
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbUpdateException" /> class.
	/// </summary>
	/// <param name="message">The message.</param>
	/// <param name="innerException">The inner exception.</param>
	public DbUpdateConcurrencyException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
