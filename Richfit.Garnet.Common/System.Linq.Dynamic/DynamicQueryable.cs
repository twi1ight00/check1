using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Linq.Dynamic;

/// <summary>
/// DynamicQueryable
/// </summary>
public static class DynamicQueryable
{
	/// <summary>
	/// Where
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="source"></param>
	/// <param name="predicate"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static IQueryable<T> Where<T>(this IQueryable<T> source, string predicate, params object[] values)
	{
		return (IQueryable<T>)((IQueryable)source).Where(predicate, values);
	}

	/// <summary>
	/// Where
	/// </summary>
	/// <param name="source"></param>
	/// <param name="predicate"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static IQueryable Where(this IQueryable source, string predicate, params object[] values)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (predicate == null)
		{
			throw new ArgumentNullException("predicate");
		}
		LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(bool), predicate, values);
		return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Where", new Type[1] { source.ElementType }, source.Expression, Expression.Quote(lambda)));
	}

	/// <summary>
	/// Select
	/// </summary>
	/// <param name="source"></param>
	/// <param name="selector"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static IQueryable Select(this IQueryable source, string selector, params object[] values)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (selector == null)
		{
			throw new ArgumentNullException("selector");
		}
		LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, null, selector, values);
		return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Select", new Type[2]
		{
			source.ElementType,
			lambda.Body.Type
		}, source.Expression, Expression.Quote(lambda)));
	}

	/// <summary>
	/// OrderBy
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="source"></param>
	/// <param name="ordering"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, params object[] values)
	{
		return (IQueryable<T>)((IQueryable)source).OrderBy(ordering, values);
	}

	/// <summary>
	/// OrderBy
	/// </summary>
	/// <param name="source"></param>
	/// <param name="ordering"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static IQueryable OrderBy(this IQueryable source, string ordering, params object[] values)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (ordering == null)
		{
			throw new ArgumentNullException("ordering");
		}
		ParameterExpression[] parameters = new ParameterExpression[1] { Expression.Parameter(source.ElementType, "") };
		ExpressionParser parser = new ExpressionParser(parameters, ordering, values);
		IEnumerable<DynamicOrdering> orderings = parser.ParseOrdering();
		Expression queryExpr = source.Expression;
		string methodAsc = "OrderBy";
		string methodDesc = "OrderByDescending";
		foreach (DynamicOrdering o in orderings)
		{
			queryExpr = Expression.Call(typeof(Queryable), o.Ascending ? methodAsc : methodDesc, new Type[2]
			{
				source.ElementType,
				o.Selector.Type
			}, queryExpr, Expression.Quote(Expression.Lambda(o.Selector, parameters)));
			methodAsc = "ThenBy";
			methodDesc = "ThenByDescending";
		}
		return source.Provider.CreateQuery(queryExpr);
	}

	/// <summary>
	/// Take
	/// </summary>
	/// <param name="source"></param>
	/// <param name="count"></param>
	/// <returns></returns>
	public static IQueryable Take(this IQueryable source, int count)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Take", new Type[1] { source.ElementType }, source.Expression, Expression.Constant(count)));
	}

	/// <summary>
	/// Skip
	/// </summary>
	/// <param name="source"></param>
	/// <param name="count"></param>
	/// <returns></returns>
	public static IQueryable Skip(this IQueryable source, int count)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Skip", new Type[1] { source.ElementType }, source.Expression, Expression.Constant(count)));
	}

	/// <summary>
	/// GroupBy
	/// </summary>
	/// <param name="source"></param>
	/// <param name="keySelector"></param>
	/// <param name="elementSelector"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static IQueryable GroupBy(this IQueryable source, string keySelector, string elementSelector, params object[] values)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		if (elementSelector == null)
		{
			throw new ArgumentNullException("elementSelector");
		}
		LambdaExpression keyLambda = DynamicExpression.ParseLambda(source.ElementType, null, keySelector, values);
		LambdaExpression elementLambda = DynamicExpression.ParseLambda(source.ElementType, null, elementSelector, values);
		return source.Provider.CreateQuery(Expression.Call(typeof(Queryable), "GroupBy", new Type[3]
		{
			source.ElementType,
			keyLambda.Body.Type,
			elementLambda.Body.Type
		}, source.Expression, Expression.Quote(keyLambda), Expression.Quote(elementLambda)));
	}

	/// <summary>
	/// Any
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	public static bool Any(this IQueryable source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return (bool)source.Provider.Execute(Expression.Call(typeof(Queryable), "Any", new Type[1] { source.ElementType }, source.Expression));
	}

	/// <summary>
	/// Count
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	public static int Count(this IQueryable source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return (int)source.Provider.Execute(Expression.Call(typeof(Queryable), "Count", new Type[1] { source.ElementType }, source.Expression));
	}

	/// <summary>
	/// 构造条件中like or like 的关系
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	/// <param name="query"></param>
	/// <param name="valueSelector"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	/// <example>
	/// var productNames = new string[] {"P1", "P2"}; 
	/// query.WhereOrLike(d=&gt;d.ProductName, productNames).ToList(); 
	/// </example>
	public static IQueryable<TElement> WhereOrLike<TElement, TValue>(this IQueryable<TElement> query, Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
	{
		return query.Where(BuildContainsExpression(valueSelector, values));
	}

	/// <summary>
	/// BuildContainsExpression
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	/// <param name="valueSelector"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	/// <example>
	///             var productNames = new string[] { "P1", "P2" };
	///             var query1 = from a in query.Where(BuildContainsExpression&lt;Product, string&gt;(d =&gt; d.ProductName, productNames))
	///             select a;
	///             var items2 = query1.ToList(); 
	/// </example>
	public static Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
	{
		MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[1] { typeof(string) });
		IEnumerable<Expression> startWiths = values.Select((Func<TValue, Expression>)((TValue value) => Expression.Call(valueSelector.Body, startsWithMethod, Expression.Constant(value, typeof(TValue)))));
		Expression body = startWiths.Aggregate((Expression accumulate, Expression equal) => Expression.Or(accumulate, equal));
		ParameterExpression p = Expression.Parameter(typeof(TElement));
		return Expression.Lambda<Func<TElement, bool>>(body, new ParameterExpression[1] { p });
	}
}
