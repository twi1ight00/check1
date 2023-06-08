using System.Collections;

namespace System.Data.Entity.Internal;

/// <summary>
///     Represents a raw SQL query against the context for any type where the results are never
///     associated with an entity set and are never tracked.
/// </summary>
internal class InternalSqlNonSetQuery : InternalSqlQuery
{
	private readonly InternalContext _internalContext;

	private readonly Type _elementType;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalSqlNonSetQuery" /> class.
	/// </summary>
	/// <param name="internalContext">The internal context.</param>
	/// <param name="elementType">Type of the element.</param>
	/// <param name="sql">The SQL.</param>
	/// <param name="parameters">The parameters.</param>
	internal InternalSqlNonSetQuery(InternalContext internalContext, Type elementType, string sql, object[] parameters)
		: base(sql, parameters)
	{
		_internalContext = internalContext;
		_elementType = elementType;
	}

	/// <summary>
	///     Returns this query since it can never be a tracking query.
	/// </summary>
	/// <returns>This instance.</returns>
	public override InternalSqlQuery AsNoTracking()
	{
		return this;
	}

	/// <summary>
	///     Executes the query and returns an enumerator for the results.
	/// </summary>
	/// <returns>The query results.</returns>
	public override IEnumerator GetEnumerator()
	{
		return _internalContext.ExecuteSqlQuery(_elementType, base.Sql, base.Parameters).GetEnumerator();
	}
}
