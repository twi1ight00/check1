using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Internal.Linq;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Represents a non-generic LINQ to Entities query against a DbContext.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Name is intentional")]
public abstract class DbQuery : IOrderedQueryable, IQueryable, IEnumerable, IListSource, IInternalQueryAdapter
{
	private IQueryProvider _provider;

	/// <summary>
	///     Returns <c>false</c>.
	/// </summary>
	/// <returns><c>false</c>.</returns>
	bool IListSource.ContainsListCollection => false;

	/// <summary>
	///     The IQueryable element type.
	/// </summary>
	public Type ElementType => InternalQuery.ElementType;

	/// <summary>
	///     The IQueryable LINQ Expression.
	/// </summary>
	Expression IQueryable.Expression => InternalQuery.Expression;

	/// <summary>
	///     The IQueryable provider.
	/// </summary>
	IQueryProvider IQueryable.Provider => _provider ?? (_provider = new NonGenericDbQueryProvider(InternalQuery.InternalContext, InternalQuery.ObjectQueryProvider));

	/// <summary>
	///     Gets the underlying internal query object.
	/// </summary>
	/// <value>The internal query.</value>
	internal abstract IInternalQuery InternalQuery { get; }

	/// <summary>
	///     The internal query object that is backing this DbQuery
	/// </summary>
	IInternalQuery IInternalQueryAdapter.InternalQuery => InternalQuery;

	/// <summary>
	///     Internal constructor prevents external classes deriving from DbQuery.
	/// </summary>
	internal DbQuery()
	{
	}

	/// <summary>
	///     Throws an exception indicating that binding directly to a store query is not supported.
	///     Instead populate a DbSet with data, for example by using the Load extension method, and
	///     then bind to local data.  For WPF bind to DbSet.Local.  For Windows Forms bind to
	///     DbSet.Local.ToBindingList().
	/// </summary>
	/// <returns>
	///     Never returns; always throws.
	/// </returns>
	IList IListSource.GetList()
	{
		throw Error.DbQuery_BindingToDbQueryNotSupported();
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return InternalQuery.GetEnumerator();
	}

	public abstract DbQuery Include(string path);

	/// <summary>
	///     Returns a new query where the entities returned will not be cached in the <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <returns> A new query with NoTracking applied.</returns>
	public abstract DbQuery AsNoTracking();

	/// <summary>
	///     Returns the equivalent generic <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> object.
	/// </summary>
	/// <typeparam name="TElement">The type of element for which the query was created.</typeparam>
	/// <returns>The generic set object.</returns>
	public DbQuery<TElement> Cast<TElement>()
	{
		if (typeof(TElement) != InternalQuery.ElementType)
		{
			throw Error.DbEntity_BadTypeForCast(typeof(DbQuery).Name, typeof(TElement).Name, InternalQuery.ElementType.Name);
		}
		return new DbQuery<TElement>((IInternalQuery<TElement>)InternalQuery);
	}

	/// <summary>
	///     Returns a <see cref="T:System.String" /> representation of the underlying query.
	/// </summary>
	/// <returns>
	///     The query string.
	/// </returns>
	public override string ToString()
	{
		return InternalQuery.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
/// <summary>
///     Represents a LINQ to Entities query against a DbContext.
/// </summary>
/// <typeparam name="TResult">The type of entity to query for.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Name is intentional")]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public class DbQuery<TResult> : IOrderedQueryable<TResult>, IQueryable<TResult>, IEnumerable<TResult>, IOrderedQueryable, IQueryable, IEnumerable, IListSource, IInternalQueryAdapter
{
	private readonly IInternalQuery<TResult> _internalQuery;

	private IQueryProvider _provider;

	/// <summary>
	///     Returns <c>false</c>.
	/// </summary>
	/// <returns><c>false</c>.</returns>
	bool IListSource.ContainsListCollection => false;

	/// <summary>
	///     The IQueryable element type.
	/// </summary>
	Type IQueryable.ElementType => _internalQuery.ElementType;

	/// <summary>
	///     The IQueryable LINQ Expression.
	/// </summary>
	Expression IQueryable.Expression => _internalQuery.Expression;

	/// <summary>
	///     The IQueryable provider.
	/// </summary>
	IQueryProvider IQueryable.Provider => _provider ?? (_provider = new DbQueryProvider(_internalQuery.InternalContext, _internalQuery.ObjectQueryProvider));

	/// <summary>
	///     The internal query object that is backing this DbQuery
	/// </summary>
	IInternalQuery IInternalQueryAdapter.InternalQuery => _internalQuery;

	/// <summary>
	///     The internal query object that is backing this DbQuery
	/// </summary>
	internal IInternalQuery<TResult> InternalQuery => _internalQuery;

	/// <summary>
	///     Creates a new query that will be backed by the given internal query object.
	/// </summary>
	/// <param name="internalQuery">The backing query.</param>
	internal DbQuery(IInternalQuery<TResult> internalQuery)
	{
		_internalQuery = internalQuery;
	}

	public DbQuery<TResult> Include(string path)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(path), null, "!String.IsNullOrWhiteSpace(path)");
		return new DbQuery<TResult>(_internalQuery.Include(path));
	}

	/// <summary>
	///     Returns a new query where the entities returned will not be cached in the <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <returns> A new query with NoTracking applied.</returns>
	public DbQuery<TResult> AsNoTracking()
	{
		return new DbQuery<TResult>(_internalQuery.AsNoTracking());
	}

	/// <summary>
	///     Throws an exception indicating that binding directly to a store query is not supported.
	///     Instead populate a DbSet with data, for example by using the Load extension method, and
	///     then bind to local data.  For WPF bind to DbSet.Local.  For Windows Forms bind to
	///     DbSet.Local.ToBindingList().
	/// </summary>
	/// <returns>
	///     Never returns; always throws.
	/// </returns>
	IList IListSource.GetList()
	{
		throw Error.DbQuery_BindingToDbQueryNotSupported();
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
	{
		return _internalQuery.GetEnumerator();
	}

	/// <summary>
	///     Gets the enumeration of this query causing it to be executed against the store.
	/// </summary>
	/// <returns>An enumerator for the query</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return _internalQuery.GetEnumerator();
	}

	/// <summary>
	///     Returns a <see cref="T:System.String" /> representation of the underlying query.
	/// </summary>
	/// <returns>
	///     The query string.
	/// </returns>
	public override string ToString()
	{
		return _internalQuery.ToString();
	}

	/// <summary>
	///     Returns a new instance of the non-generic <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> class for this query.
	/// </summary>
	/// <returns>A non-generic version.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Intentionally just implicit to reduce API clutter.")]
	public static implicit operator DbQuery(DbQuery<TResult> entry)
	{
		return new InternalDbQuery<TResult>(entry._internalQuery);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}
}
