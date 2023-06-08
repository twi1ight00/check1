using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     A wrapping query provider that performs expression transformation and then delegates
///     to the <see cref="T:System.Data.Objects.ObjectQuery" /> provider.  The <see cref="T:System.Linq.IQueryable" /> objects returned
///     are always instances of <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> when the generic CreateQuery method is
///     used and are instances of <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> when the non-generic CreateQuery method
///     is used.  This provider is associated with non-generic <see cref="T:System.Data.Entity.Infrastructure.DbQuery" /> objects.
/// </summary>
internal class NonGenericDbQueryProvider : DbQueryProvider
{
	/// <summary>
	///     Creates a provider that wraps the given provider.
	/// </summary>
	/// <param name="provider">The provider to wrap.</param>
	public NonGenericDbQueryProvider(InternalContext internalContext, IQueryProvider provider)
		: base(internalContext, provider)
	{
	}

	/// <summary>
	///     Performs expression replacement and then delegates to the wrapped provider before wrapping
	///     the returned <see cref="T:System.Data.Objects.ObjectQuery" /> as a <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />.
	/// </summary>
	public override IQueryable<TElement> CreateQuery<TElement>(Expression expression)
	{
		return new InternalDbQuery<TElement>(new InternalQuery<TElement>(base.InternalContext, CreateObjectQuery(expression)));
	}

	/// <summary>
	///     Delegates to the wrapped provider except returns instances of <see cref="T:System.Data.Entity.Infrastructure.DbQuery" />.
	/// </summary>
	public override IQueryable CreateQuery(Expression expression)
	{
		IInternalQuery internalQuery = CreateInternalQuery(CreateObjectQuery(expression));
		Type type = typeof(InternalDbQuery<>).MakeGenericType(internalQuery.ElementType);
		ConstructorInfo constructorInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Single();
		return (IQueryable)constructorInfo.Invoke(new object[1] { internalQuery });
	}
}
