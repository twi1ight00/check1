using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     A non-generic interface implemented by <see cref="T:System.Data.Entity.Internal.Linq.InternalQuery`1" /> that allows operations on
///     any query object without knowing the type to which it applies.
/// </summary>
internal interface IInternalQuery
{
	InternalContext InternalContext { get; }

	ObjectQuery ObjectQuery { get; }

	Type ElementType { get; }

	Expression Expression { get; }

	IQueryProvider ObjectQueryProvider { get; }

	void ResetQuery();

	IEnumerator GetEnumerator();
}
/// <summary>
///     An interface implemented by <see cref="T:System.Data.Entity.Internal.Linq.InternalQuery`1" />.
/// </summary>
/// <typeparam name="TElement">The type of the element.</typeparam>
internal interface IInternalQuery<out TElement> : IInternalQuery
{
	IInternalQuery<TElement> Include(string path);

	IInternalQuery<TElement> AsNoTracking();

	new IEnumerator<TElement> GetEnumerator();
}
