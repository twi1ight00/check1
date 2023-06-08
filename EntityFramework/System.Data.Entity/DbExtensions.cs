using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity;

[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public static class DbExtensions
{
	private static readonly Type[] StringIncludeTypes = new Type[1] { typeof(string) };

	public static IQueryable<T> Include<T>(this IQueryable<T> source, string path) where T : class
	{
		RuntimeFailureMethods.Requires(source != null, null, "source != null");
		if (source is DbQuery<T> dbQuery)
		{
			return dbQuery.Include(path);
		}
		if (source is ObjectQuery<T> objectQuery)
		{
			return objectQuery.Include(path);
		}
		return CommonInclude(source, path);
	}

	public static IQueryable Include(this IQueryable source, string path)
	{
		RuntimeFailureMethods.Requires(source != null, null, "source != null");
		if (!(source is DbQuery dbQuery))
		{
			return CommonInclude(source, path);
		}
		return dbQuery.Include(path);
	}

	/// <summary>
	///     Common code for generic and non-generic string Include.
	/// </summary>
	private static T CommonInclude<T>(T source, string path)
	{
		MethodInfo method = source.GetType().GetMethod("Include", StringIncludeTypes);
		if (method != null && typeof(T).IsAssignableFrom(method.ReturnType))
		{
			return (T)method.Invoke(source, new object[1] { path });
		}
		return source;
	}

	[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
	public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path) where T : class
	{
		RuntimeFailureMethods.Requires(source != null, null, "source != null");
		RuntimeFailureMethods.Requires(path != null, null, "path != null");
		if (!DbHelpers.TryParsePath(path.Body, out var path2) || path2 == null)
		{
			throw new ArgumentException(Strings.DbExtensions_InvalidIncludePathExpression, "path");
		}
		return source.Include(path2);
	}

	/// <summary>
	///     Returns a new query where the entities returned will not be cached in the <see cref="T:System.Data.Entity.DbContext" />
	///     or <see cref="T:System.Data.Objects.ObjectContext" />.  This method works by calling the AsNoTracking method of the
	///     underlying query object.  If the underlying query object does not have a AsNoTracking method,
	///     then calling this method will have no affect.
	/// </summary>
	/// <typeparam name="T">The element type.</typeparam>
	/// <param name="source">The source query.</param>
	/// <returns>A new query with NoTracking applied, or the source query if NoTracking is not supported.</returns>
	public static IQueryable<T> AsNoTracking<T>(this IQueryable<T> source) where T : class
	{
		RuntimeFailureMethods.Requires(source != null, null, "source != null");
		if (!(source is DbQuery<T> dbQuery))
		{
			return CommonAsNoTracking(source);
		}
		return dbQuery.AsNoTracking();
	}

	/// <summary>
	///     Returns a new query where the entities returned will not be cached in the <see cref="T:System.Data.Entity.DbContext" />
	///     or <see cref="T:System.Data.Objects.ObjectContext" />.  This method works by calling the AsNoTracking method of the
	///     underlying query object.  If the underlying query object does not have a AsNoTracking method,
	///     then calling this method will have no affect.
	/// </summary>
	/// <param name="source">The source query.</param>
	/// <returns>A new query with NoTracking applied, or the source query if NoTracking is not supported.</returns>
	public static IQueryable AsNoTracking(this IQueryable source)
	{
		RuntimeFailureMethods.Requires(source != null, null, "source != null");
		if (!(source is DbQuery dbQuery))
		{
			return CommonAsNoTracking(source);
		}
		return dbQuery.AsNoTracking();
	}

	/// <summary>
	///     Common code for generic and non-generic AsNoTracking.
	/// </summary>
	private static T CommonAsNoTracking<T>(T source) where T : class
	{
		if (source is ObjectQuery query)
		{
			return (T)DbHelpers.CreateNoTrackingQuery(query);
		}
		MethodInfo method = source.GetType().GetMethod("AsNoTracking", Type.EmptyTypes);
		if (method != null && typeof(T).IsAssignableFrom(method.ReturnType))
		{
			return (T)method.Invoke(source, null);
		}
		return source;
	}

	/// <summary>
	///     Enumerates the query such that for server queries such as those of <see cref="T:System.Data.Entity.DbSet`1" />, <see cref="T:System.Data.Objects.ObjectSet`1" />,
	///     <see cref="T:System.Data.Objects.ObjectQuery`1" />, and others the results of the query will be loaded into the associated <see cref="T:System.Data.Entity.DbContext" />,
	///     <see cref="T:System.Data.Objects.ObjectContext" /> or other cache on the client.
	///     This is equivalent to calling ToList and then throwing away the list without the overhead of actually creating the list.
	/// </summary>
	/// <param name="source">The source query.</param>
	public static void Load(this IQueryable source)
	{
		RuntimeFailureMethods.Requires(source != null, null, "source != null");
		IEnumerator enumerator = source.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	/// <summary>
	///     Returns an <see cref="T:System.ComponentModel.BindingList`1" /> implementation that stays in sync with the given <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" />.
	/// </summary>
	/// <typeparam name="T">The element type.</typeparam>
	/// <param name="source">The collection that the binding list will stay in sync with.</param>
	/// <returns>The binding list.</returns>
	public static BindingList<T> ToBindingList<T>(this ObservableCollection<T> source) where T : class
	{
		RuntimeFailureMethods.Requires(source != null, null, "source != null");
		if (!(source is DbLocalView<T> dbLocalView))
		{
			return new ObservableBackedBindingList<T>(source);
		}
		return dbLocalView.BindingList;
	}
}
