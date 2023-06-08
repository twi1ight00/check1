namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     An internal interface implemented by <see cref="T:System.Data.Entity.DbSet`1" /> and <see cref="T:System.Data.Entity.DbSet" /> that allows access to
///     the internal set without using reflection.
/// </summary>
internal interface IInternalSetAdapter
{
	/// <summary>
	///     The underlying internal set.
	/// </summary>
	IInternalSet InternalSet { get; }
}
