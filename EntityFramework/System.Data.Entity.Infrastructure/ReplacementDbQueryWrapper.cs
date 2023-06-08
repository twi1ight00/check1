using System.Data.Objects;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Instances of this class are used internally to create constant expressions for <see cref="T:System.Data.Objects.ObjectQuery`1" />
///     that are inserted into the expression tree to  replace references to <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" />
///     and <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />.
/// </summary>
/// <typeparam name="TElement">The type of the element.</typeparam>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Db")]
public sealed class ReplacementDbQueryWrapper<TElement>
{
	private readonly ObjectQuery<TElement> _query;

	/// <summary>
	///     The public property expected in the LINQ expression tree.
	/// </summary>
	/// <value>The query.</value>
	public ObjectQuery<TElement> Query => _query;

	/// <summary>
	///     Private constructor called by the Create factory method.
	/// </summary>
	/// <param name="query">The query.</param>
	private ReplacementDbQueryWrapper(ObjectQuery<TElement> query)
	{
		_query = query;
	}

	/// <summary>
	///     Factory method called by CreateDelegate to create an instance of this class.
	/// </summary>
	/// <param name="query">The query, which must be a generic object of the expected type.</param>
	/// <returns>A new instance.</returns>
	internal static ReplacementDbQueryWrapper<TElement> Create(ObjectQuery query)
	{
		return new ReplacementDbQueryWrapper<TElement>((ObjectQuery<TElement>)query);
	}
}
