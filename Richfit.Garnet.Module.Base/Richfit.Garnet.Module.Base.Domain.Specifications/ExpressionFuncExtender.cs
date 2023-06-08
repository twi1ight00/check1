using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Richfit.Garnet.Module.Base.Domain.Specifications;

/// <summary>
/// Represents the extender for Expression[Func[T, bool]] type.
/// This is part of the solution which solves
/// the expression parameter problem when going to Entity Framework by using
/// Apworks specifications. For more information about this solution please
/// refer to http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx.
/// </summary>
public static class ExpressionFuncExtender
{
	private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
	{
		Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((ParameterExpression f, int i) => new
		{
			f = f,
			s = second.Parameters[i]
		}).ToDictionary(p => p.s, p => p.f);
		Expression secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
		return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
	}

	/// <summary>
	/// True Expression
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static Expression<Func<T, bool>> True<T>()
	{
		return (T f) => true;
	}

	/// <summary>
	/// False Expression
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static Expression<Func<T, bool>> False<T>()
	{
		return (T f) => false;
	}

	/// <summary>
	/// Combines two given expressions by using the AND semantics.
	/// </summary>
	/// <typeparam name="T">The type of the object.</typeparam>
	/// <param name="first">The first part of the expression.</param>
	/// <param name="second">The second part of the expression.</param>
	/// <returns>The combined expression.</returns>
	public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
	{
		return first.Compose(second, Expression.And);
	}

	/// <summary>
	/// Combines two given expressions by using the OR semantics.
	/// </summary>
	/// <typeparam name="T">The type of the object.</typeparam>
	/// <param name="first">The first part of the expression.</param>
	/// <param name="second">The second part of the expression.</param>
	/// <returns>The combined expression.</returns>
	public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
	{
		return first.Compose(second, Expression.Or);
	}
}
