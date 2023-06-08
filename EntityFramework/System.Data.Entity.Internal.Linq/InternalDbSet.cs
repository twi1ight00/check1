using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     An instance of this internal class is created whenever an instance of the public <see cref="T:System.Data.Entity.DbSet`1" />
///     class is needed. This allows the public surface to be non-generic, while the runtime type created
///     still implements <see cref="T:System.Linq.IQueryable`1" />.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
internal class InternalDbSet<TEntity> : DbSet, IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable where TEntity : class
{
	private readonly IInternalSet<TEntity> _internalSet;

	/// <summary>
	///     Gets the underlying internal query object.
	/// </summary>
	/// <value>The internal query.</value>
	internal override IInternalQuery InternalQuery => _internalSet;

	/// <summary>
	///     Gets the underlying internal set.
	/// </summary>
	/// <value>The internal set.</value>
	internal override IInternalSet InternalSet => _internalSet;

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.DbSet`1" />.
	/// </summary>
	public override IList Local => _internalSet.Local;

	/// <summary>
	///     Creates a new set that will be backed by the given internal set.
	/// </summary>
	/// <param name="internalSet">The internal set.</param>
	public InternalDbSet(IInternalSet<TEntity> internalSet)
	{
		_internalSet = internalSet;
	}

	/// <summary>
	///     Creates an instance of this class.  This method is used with CreateDelegate to cache a delegate
	///     that can create a generic instance without calling MakeGenericType every time.
	/// </summary>
	/// <param name="internalContext"></param>
	/// <param name="internalSet">The internal set to wrap, or null if a new internal set should be created.</param>
	/// <returns>The set.</returns>
	public static InternalDbSet<TEntity> Create(InternalContext internalContext, IInternalSet internalSet)
	{
		return new InternalDbSet<TEntity>(((IInternalSet<TEntity>)internalSet) ?? new InternalSet<TEntity>(internalContext));
	}

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />.
	/// </summary>
	public override DbQuery Include(string path)
	{
		DbHelpers.ThrowIfNullOrWhitespace(path, "path");
		return new InternalDbQuery<TEntity>(_internalSet.Include(path));
	}

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />.
	/// </summary>
	public override DbQuery AsNoTracking()
	{
		return new InternalDbQuery<TEntity>(_internalSet.AsNoTracking());
	}

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.DbSet`1" />.
	/// </summary>
	public override object Find(params object[] keyValues)
	{
		return _internalSet.Find(keyValues);
	}

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.DbSet`1" />.
	/// </summary>
	public override object Create()
	{
		return _internalSet.Create();
	}

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.DbSet`1" />.
	/// </summary>
	public override object Create(Type derivedEntityType)
	{
		DbHelpers.ThrowIfNull(derivedEntityType, "derivedEntityType");
		return _internalSet.Create(derivedEntityType);
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	public IEnumerator<TEntity> GetEnumerator()
	{
		return _internalSet.GetEnumerator();
	}
}
