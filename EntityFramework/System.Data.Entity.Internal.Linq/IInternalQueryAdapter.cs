namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     An internal interface implemented by <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> and <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> that allows access to
///     the internal query without using reflection.
/// </summary>
internal interface IInternalQueryAdapter
{
	/// <summary>
	///     The underlying internal set.
	/// </summary>
	IInternalQuery InternalQuery { get; }
}
