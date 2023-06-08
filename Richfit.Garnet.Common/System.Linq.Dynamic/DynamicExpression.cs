using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq.Dynamic;

/// <summary>
/// DynamicExpression
/// </summary>
public static class DynamicExpression
{
	/// <summary>
	/// Parse
	/// </summary>
	/// <param name="resultType"></param>
	/// <param name="expression"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static Expression Parse(Type resultType, string expression, params object[] values)
	{
		ExpressionParser parser = new ExpressionParser(null, expression, values);
		return parser.Parse(resultType);
	}

	/// <summary>
	/// ParseLambda
	/// </summary>
	/// <param name="itType"></param>
	/// <param name="resultType"></param>
	/// <param name="expression"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static LambdaExpression ParseLambda(Type itType, Type resultType, string expression, params object[] values)
	{
		return ParseLambda(new ParameterExpression[1] { Expression.Parameter(itType, "") }, resultType, expression, values);
	}

	/// <summary>
	/// ParseLambda
	/// </summary>
	/// <param name="parameters"></param>
	/// <param name="resultType"></param>
	/// <param name="expression"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static LambdaExpression ParseLambda(ParameterExpression[] parameters, Type resultType, string expression, params object[] values)
	{
		ExpressionParser parser = new ExpressionParser(parameters, expression, values);
		return Expression.Lambda(parser.Parse(resultType), parameters);
	}

	/// <summary>
	/// ParseLambda
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="S"></typeparam>
	/// <param name="expression"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	public static Expression<Func<T, S>> ParseLambda<T, S>(string expression, params object[] values)
	{
		return (Expression<Func<T, S>>)ParseLambda(typeof(T), typeof(S), expression, values);
	}

	/// <summary>
	/// CreateClass
	/// </summary>
	/// <param name="properties"></param>
	/// <returns></returns>
	public static Type CreateClass(params DynamicProperty[] properties)
	{
		return ClassFactory.Instance.GetDynamicClass(properties);
	}

	/// <summary>
	/// CreateClass
	/// </summary>
	/// <param name="properties"></param>
	/// <returns></returns>
	public static Type CreateClass(IEnumerable<DynamicProperty> properties)
	{
		return ClassFactory.Instance.GetDynamicClass(properties);
	}
}
