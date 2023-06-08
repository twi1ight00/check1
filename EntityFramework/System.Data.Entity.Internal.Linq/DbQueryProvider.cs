using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Internal.Linq;

/// <summary>
///     A wrapping query provider that performs expression transformation and then delegates
///     to the <see cref="T:System.Data.Objects.ObjectQuery" /> provider.  The <see cref="T:System.Linq.IQueryable" /> objects returned are always instances
///     of <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" />. This provider is associated with generic <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> objects.
/// </summary>
internal class DbQueryProvider : IQueryProvider
{
	private readonly InternalContext _internalContext;

	private readonly IQueryProvider _provider;

	/// <summary>
	///     Gets the internal context.
	/// </summary>
	/// <value>The internal context.</value>
	public InternalContext InternalContext => _internalContext;

	/// <summary>
	///     Creates a provider that wraps the given provider.
	/// </summary>
	/// <param name="provider">The provider to wrap.</param>
	public DbQueryProvider(InternalContext internalContext, IQueryProvider provider)
	{
		_internalContext = internalContext;
		_provider = provider;
	}

	/// <summary>
	///     Performs expression replacement and then delegates to the wrapped provider before wrapping
	///     the returned <see cref="T:System.Data.Objects.ObjectQuery" /> as a <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" />.
	/// </summary>
	public virtual IQueryable<TElement> CreateQuery<TElement>(Expression expression)
	{
		return new DbQuery<TElement>(new InternalQuery<TElement>(_internalContext, CreateObjectQuery(expression)));
	}

	/// <summary>
	///     Performs expression replacement and then delegates to the wrapped provider before wrapping
	///     the returned <see cref="T:System.Data.Objects.ObjectQuery" /> as a <see cref="T:System.Data.Entity.Infrastructure.DbQuery`1" /> where T is determined
	///     from the element type of the ObjectQuery.
	/// </summary>
	public virtual IQueryable CreateQuery(Expression expression)
	{
		IInternalQuery internalQuery = CreateInternalQuery(CreateObjectQuery(expression));
		Type type = typeof(DbQuery<>).MakeGenericType(internalQuery.ElementType);
		ConstructorInfo constructorInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Single();
		return (IQueryable)constructorInfo.Invoke(new object[1] { internalQuery });
	}

	/// <summary>
	///     By default, calls the same method on the wrapped provider.
	/// </summary>
	public virtual TResult Execute<TResult>(Expression expression)
	{
		return _provider.Execute<TResult>(expression);
	}

	/// <summary>
	///     By default, calls the same method on the wrapped provider.
	/// </summary>
	public virtual object Execute(Expression expression)
	{
		return _provider.Execute(expression);
	}

	/// <summary>
	///     Performs expression replacement and then delegates to the wrapped provider to create an
	///     <see cref="T:System.Data.Objects.ObjectQuery" />.
	/// </summary>
	protected ObjectQuery CreateObjectQuery(Expression expression)
	{
		expression = new DbQueryVisitor().Visit(expression);
		return (ObjectQuery)_provider.CreateQuery(expression);
	}

	/// <summary>
	///     Wraps the given <see cref="T:System.Data.Objects.ObjectQuery" /> as a <see cref="T:System.Data.Entity.Internal.Linq.InternalQuery`1" /> where T is determined
	///     from the element type of the ObjectQuery.
	/// </summary>
	protected IInternalQuery CreateInternalQuery(ObjectQuery objectQuery)
	{
		Type type = typeof(InternalQuery<>).MakeGenericType(((IQueryable)objectQuery).ElementType);
		ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
		{
			typeof(InternalContext),
			typeof(ObjectQuery)
		}, null);
		return (IInternalQuery)constructor.Invoke(new object[2] { _internalContext, objectQuery });
	}
}
