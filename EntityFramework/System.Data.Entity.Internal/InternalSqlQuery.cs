using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Resources;

namespace System.Data.Entity.Internal;

/// <summary>
///     Represents a raw SQL query against the context that may be for entities in an entity set
///     or for some other non-entity element type.
/// </summary>
internal abstract class InternalSqlQuery : IEnumerable, IListSource
{
	private readonly string _sql;

	private readonly object[] _parameters;

	/// <summary>
	///     Gets the SQL query string,
	/// </summary>
	/// <value>The SQL query.</value>
	public string Sql => _sql;

	/// <summary>
	///     Gets the parameters.
	/// </summary>
	/// <value>The parameters.</value>
	public object[] Parameters => _parameters;

	/// <summary>
	///     Returns <c>false</c>.
	/// </summary>
	/// <returns><c>false</c>.</returns>
	public bool ContainsListCollection => false;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalSqlQuery" /> class.
	/// </summary>
	/// <param name="sql">The SQL.</param>
	/// <param name="parameters">The parameters.</param>
	internal InternalSqlQuery(string sql, object[] parameters)
	{
		_sql = sql;
		_parameters = parameters;
	}

	/// <summary>
	///     If the query is would track entities, then this method returns a new query that will
	///     not track entities.
	/// </summary>
	/// <returns>A no-tracking query.</returns>
	public abstract InternalSqlQuery AsNoTracking();

	/// <summary>
	///     Executes the query and returns an enumerator for the results.
	/// </summary>
	/// <returns>The query results.</returns>
	public abstract IEnumerator GetEnumerator();

	/// <summary>
	///     Throws an exception indicating that binding directly to a store query is not supported.
	/// </summary>
	/// <returns>
	///     Never returns; always throws.
	/// </returns>
	public IList GetList()
	{
		throw Error.DbQuery_BindingToDbQueryNotSupported();
	}

	/// <summary>
	///     Returns a <see cref="T:System.String" /> that contains the SQL string that was set
	///     when the query was created.  The parameters are not included.
	/// </summary>
	/// <returns>
	///     A <see cref="T:System.String" /> that represents this instance.
	/// </returns>
	public override string ToString()
	{
		return Sql;
	}
}
/// <summary>
///     Generic wrapper around <see cref="T:System.Data.Entity.Internal.InternalSqlQuery" /> to allow results to be
///     returned as generic <see cref="T:System.Collections.Generic.IEnumerable`1" />
/// </summary>
/// <typeparam name="TElement">The type of the element.</typeparam>
internal class InternalSqlQuery<TElement> : IEnumerable<TElement>, IEnumerable, IListSource
{
	private readonly InternalSqlQuery _internalQuery;

	/// <summary>
	///     Returns <c>false</c>.
	/// </summary>
	/// <returns><c>false</c>.</returns>
	bool IListSource.ContainsListCollection => _internalQuery.ContainsListCollection;

	internal InternalSqlQuery(InternalSqlQuery internalQuery)
	{
		_internalQuery = internalQuery;
	}

	/// <summary>
	///     Executes the query and returns an enumerator for the elements.
	/// </summary>
	/// An
	/// <see cref="T:System.Collections.Generic.IEnumerator`1" />
	/// object that can be used to iterate through the elements.
	public IEnumerator<TElement> GetEnumerator()
	{
		return (IEnumerator<TElement>)_internalQuery.GetEnumerator();
	}

	/// <summary>
	///     Executes the query and returns an enumerator for the elements.
	/// </summary>
	/// <returns>
	///     An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the elements.
	/// </returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	/// <summary>
	///     Returns a <see cref="T:System.String" /> that contains the SQL string that was set
	///     when the query was created.  The parameters are not included.
	/// </summary>
	/// <returns>
	///     A <see cref="T:System.String" /> that represents this instance.
	/// </returns>
	public override string ToString()
	{
		return _internalQuery.ToString();
	}

	/// <summary>
	///     Throws an exception indicating that binding directly to a store query is not supported.
	/// </summary>
	/// <returns>
	///     Never returns; always throws.
	/// </returns>
	IList IListSource.GetList()
	{
		return _internalQuery.GetList();
	}
}
