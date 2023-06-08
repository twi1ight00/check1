using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     An instance of this internal class is created whenever an instance of the public <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />
///     class is needed. This allows the public surface to be non-generic, while the runtime type created
///     still implements <see cref="T:System.Linq.IQueryable`1" />.
/// </summary>
/// <typeparam name="TElement">The type of the element.</typeparam>
internal class InternalDbQuery<TElement> : DbQuery, IOrderedQueryable<TElement>, IQueryable<TElement>, IEnumerable<TElement>, IOrderedQueryable, IQueryable, IEnumerable
{
	private readonly IInternalQuery<TElement> _internalQuery;

	/// <summary>
	///     Gets the underlying internal query object.
	/// </summary>
	/// <value>The internal query.</value>
	internal override IInternalQuery InternalQuery => _internalQuery;

	/// <summary>
	///     Creates a new query that will be backed by the given internal query object.
	/// </summary>
	/// <param name="internalQuery">The backing query.</param>
	public InternalDbQuery(IInternalQuery<TElement> internalQuery)
	{
		_internalQuery = internalQuery;
	}

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />.
	/// </summary>
	public override DbQuery Include(string path)
	{
		DbHelpers.ThrowIfNullOrWhitespace(path, "path");
		return new InternalDbQuery<TElement>(_internalQuery.Include(path));
	}

	/// <summary>
	///     See comments in <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />.
	/// </summary>
	public override DbQuery AsNoTracking()
	{
		return new InternalDbQuery<TElement>(_internalQuery.AsNoTracking());
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	public IEnumerator<TElement> GetEnumerator()
	{
		return _internalQuery.GetEnumerator();
	}
}
