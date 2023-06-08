using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     An InternalQuery underlies every instance of DbSet and DbQuery.  It acts to lazily initialize a InternalContext as well
///     as an ObjectQuery and EntitySet the first time that it is used.  The InternalQuery also acts to expose necessary
///     information to other parts of the design in a controlled manner without adding a lot of internal methods and
///     properties to the DbSet and DbQuery classes themselves.
/// </summary>
/// <typeparam name="TElement">The type of entity to query for.</typeparam>
internal class InternalQuery<TElement> : IInternalQuery<TElement>, IInternalQuery
{
	private readonly InternalContext _internalContext;

	private ObjectQuery<TElement> _objectQuery;

	/// <summary>
	///     The underlying InternalContext.
	/// </summary>
	public virtual InternalContext InternalContext => _internalContext;

	/// <summary>
	///     The underlying ObjectQuery.
	/// </summary>
	public virtual ObjectQuery<TElement> ObjectQuery => _objectQuery;

	/// <summary>
	///     The underlying ObjectQuery.
	/// </summary>
	ObjectQuery IInternalQuery.ObjectQuery => ObjectQuery;

	/// <summary>
	///     The LINQ query expression.
	/// </summary>
	public virtual Expression Expression => ((IQueryable)_objectQuery).Expression;

	/// <summary>
	///     The LINQ query provider for the underlying <see cref="P:System.Data.Entity.Internal.Linq.InternalQuery`1.ObjectQuery" />.
	/// </summary>
	public virtual IQueryProvider ObjectQueryProvider => ((IQueryable)_objectQuery).Provider;

	/// <summary>
	///     The IQueryable element type.
	/// </summary>
	public Type ElementType => typeof(TElement);

	/// <summary>
	///     Creates a new query that will be backed by the given InternalContext.
	/// </summary>
	/// <param name="internalContext">The backing context.</param>
	public InternalQuery(InternalContext context)
	{
		_internalContext = context;
	}

	/// <summary>
	///     Creates a new internal query based on the information in an existing query together with
	///     a new underlying ObjectQuery.
	/// </summary>
	public InternalQuery(InternalContext internalContext, ObjectQuery objectQuery)
	{
		_internalContext = internalContext;
		_objectQuery = (ObjectQuery<TElement>)objectQuery;
	}

	/// <summary>
	///     Resets the query to its uninitialized state so that it will be re-lazy initialized the next
	///     time it is used.  This allows the ObjectContext backing a DbContext to be switched out.
	/// </summary>
	public virtual void ResetQuery()
	{
		_objectQuery = null;
	}

	/// <summary>
	///     Updates the underlying ObjectQuery with the given include path.
	/// </summary>
	/// <param name="path">The include path.</param>
	/// <returns>A new query containing the defined include path.</returns>
	public virtual IInternalQuery<TElement> Include(string path)
	{
		return new InternalQuery<TElement>(_internalContext, _objectQuery.Include(path));
	}

	/// <summary>
	///     Returns a new query where the entities returned will not be cached in the <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <returns> A new query with NoTracking applied.</returns>
	public virtual IInternalQuery<TElement> AsNoTracking()
	{
		return new InternalQuery<TElement>(_internalContext, (ObjectQuery)DbHelpers.CreateNoTrackingQuery(_objectQuery));
	}

	/// <summary>
	///     Performs lazy initialization of the underlying ObjectContext, ObjectQuery, and EntitySet objects
	///     so that the query can be used.
	/// </summary>
	protected void InitializeQuery(ObjectQuery<TElement> objectQuery)
	{
		_objectQuery = objectQuery;
	}

	/// <summary>
	///     Returns a <see cref="T:System.String" /> representation of the underlying query, equivalent
	///     to ToTraceString on ObjectQuery.
	/// </summary>
	/// <returns>
	///     The query string.
	/// </returns>
	public override string ToString()
	{
		return _objectQuery.ToTraceString();
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	public virtual IEnumerator<TElement> GetEnumerator()
	{
		return ((IEnumerable<TElement>)_objectQuery).GetEnumerator();
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	IEnumerator IInternalQuery.GetEnumerator()
	{
		return GetEnumerator();
	}
}
