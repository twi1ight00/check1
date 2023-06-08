using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Internal;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Represents a SQL query for entities that is created from a <see cref="T:System.Data.Entity.DbContext" /> 
///     and is executed using the connection from that context.
///     Instances of this class are obtained from the <see cref="T:System.Data.Entity.DbSet`1" /> instance for the 
///     entity type. The query is not executed when this object is created; it is executed
///     each time it is enumerated, for example by using foreach.
///     SQL queries for non-entities are created using the <see cref="P:System.Data.Entity.DbContext.Database" />.
///     See <see cref="T:System.Data.Entity.Infrastructure.DbSqlQuery" /> for a non-generic version of this class.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Db is not an abbreviation for data base.")]
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Name is intentional")]
public class DbSqlQuery<TEntity> : IEnumerable<TEntity>, IEnumerable, IListSource where TEntity : class
{
	private readonly InternalSqlQuery _internalQuery;

	/// <summary>
	///     Gets the internal query.
	/// </summary>
	/// <value>The internal query.</value>
	internal InternalSqlQuery InternalQuery => _internalQuery;

	/// <summary>
	///     Returns <c>false</c>.
	/// </summary>
	/// <returns><c>false</c>.</returns>
	bool IListSource.ContainsListCollection => _internalQuery.ContainsListCollection;

	internal DbSqlQuery(InternalSqlQuery internalQuery)
	{
		_internalQuery = internalQuery;
	}

	/// <summary>
	///     Executes the query and returns an enumerator for the elements.
	/// </summary>
	/// An
	/// <see cref="T:System.Collections.Generic.IEnumerator`1" />
	/// object that can be used to iterate through the elements.
	public IEnumerator<TEntity> GetEnumerator()
	{
		return (IEnumerator<TEntity>)_internalQuery.GetEnumerator();
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
	///     Returns a new query where the results of the query will not be tracked by the associated
	///     <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <returns>A new query with no-tracking applied.</returns>
	public DbSqlQuery<TEntity> AsNoTracking()
	{
		return new DbSqlQuery<TEntity>(InternalQuery.AsNoTracking());
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
///     Represents a SQL query for entities that is created from a <see cref="T:System.Data.Entity.DbContext" /> 
///     and is executed using the connection from that context.
///     Instances of this class are obtained from the <see cref="T:System.Data.Entity.DbSet" /> instance for the 
///     entity type. The query is not executed when this object is created; it is executed
///     each time it is enumerated, for example by using foreach.
///     SQL queries for non-entities are created using the <see cref="P:System.Data.Entity.DbContext.Database" />.
///     See <see cref="T:System.Data.Entity.Infrastructure.DbSqlQuery`1" /> for a generic version of this class.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Name is intentional")]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db", Justification = "FxCop rule is wrong; Db is not an abbreviation for data base.")]
public class DbSqlQuery : IEnumerable, IListSource
{
	private readonly InternalSqlQuery _internalQuery;

	/// <summary>
	///     Gets the internal query.
	/// </summary>
	/// <value>The internal query.</value>
	internal InternalSqlQuery InternalQuery => _internalQuery;

	/// <summary>
	///     Returns <c>false</c>.
	/// </summary>
	/// <returns><c>false</c>.</returns>
	bool IListSource.ContainsListCollection => _internalQuery.ContainsListCollection;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.DbSqlQuery" /> class.
	/// </summary>
	/// <param name="internalQuery">The internal query.</param>
	internal DbSqlQuery(InternalSqlQuery internalQuery)
	{
		_internalQuery = internalQuery;
	}

	/// <summary>
	///     Executes the query and returns an enumerator for the elements.
	/// </summary>
	/// <returns>
	///     An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the elements.
	/// </returns>
	public IEnumerator GetEnumerator()
	{
		return _internalQuery.GetEnumerator();
	}

	/// <summary>
	///     Returns a new query where the results of the query will not be tracked by the associated
	///     <see cref="T:System.Data.Entity.DbContext" />.
	/// </summary>
	/// <returns>A new query with no-tracking applied.</returns>
	public DbSqlQuery AsNoTracking()
	{
		return new DbSqlQuery(InternalQuery.AsNoTracking());
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
