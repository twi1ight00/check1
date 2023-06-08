using System.Collections;
using System.Data.Entity.Internal.Linq;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Internal;

/// <summary>
///     Represents a raw SQL query against the context for entities in an entity set.
/// </summary>
internal class InternalSqlSetQuery : InternalSqlQuery
{
	private readonly IInternalSet _set;

	private readonly bool _isNoTracking;

	/// <summary>
	///     Gets a value indicating whether this instance is set to track entities or not.
	/// </summary>
	/// <value>
	///     <c>true</c> if this instance is no-tracking; otherwise, <c>false</c>.
	/// </value>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public bool IsNoTracking => _isNoTracking;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.InternalSqlSetQuery" /> class.
	/// </summary>
	/// <param name="set">The set.</param>
	/// <param name="sql">The SQL.</param>
	/// <param name="isNoTracking">if set to <c>true</c> then the entities will not be tracked.</param>
	/// <param name="parameters">The parameters.</param>
	internal InternalSqlSetQuery(IInternalSet set, string sql, bool isNoTracking, object[] parameters)
		: base(sql, parameters)
	{
		_set = set;
		_isNoTracking = isNoTracking;
	}

	/// <summary>
	///     If the query is would track entities, then this method returns a new query that will
	///     not track entities.
	/// </summary>
	/// <returns>A no-tracking query.</returns>
	public override InternalSqlQuery AsNoTracking()
	{
		bool isNoTracking = true;
		object[] parameters = base.Parameters;
		return new InternalSqlSetQuery(_set, base.Sql, isNoTracking, parameters);
	}

	/// <summary>
	///     Executes the query and returns an enumerator for the results.
	/// </summary>
	/// <returns>The query results.</returns>
	public override IEnumerator GetEnumerator()
	{
		return _set.ExecuteSqlQuery(base.Sql, _isNoTracking, base.Parameters).GetEnumerator();
	}
}
