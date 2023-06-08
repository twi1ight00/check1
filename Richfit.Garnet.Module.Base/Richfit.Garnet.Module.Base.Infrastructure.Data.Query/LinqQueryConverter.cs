using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// 将查询条件转化为linq lambda表达式，支持实体嵌套A.B.C
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public static class LinqQueryConverter<TEntity> where TEntity : Entity
{
	/// <summary>
	/// 判断查询条件key在实体属性中是否存在
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	private static bool IsKeyExists(string key)
	{
		Type type = typeof(TEntity);
		try
		{
			return type.GetPropertyType(key) != null;
		}
		catch
		{
			return false;
		}
	}

	private static Expression GetExpression(ParameterExpression pExpression, string key)
	{
		Type type = typeof(TEntity);
		Expression expr = pExpression;
		if (key.IndexOf(".") > 0)
		{
			string[] SourceProperties = key.Split(new string[1] { "." }, StringSplitOptions.None);
			string[] array = SourceProperties;
			foreach (string prop in array)
			{
				PropertyInfo pi = type.GetProperty(prop);
				expr = Expression.Property(expr, pi);
				type = pi.PropertyType;
			}
		}
		else
		{
			expr = Expression.Property(expr, key);
		}
		return expr;
	}

	private static Expression BuildWhereInExpression(Expression keyExp, string value)
	{
		string[] stringValues = value.Split(',');
		IList<object> values = new List<object>();
		Type valueType = keyExp.Type;
		stringValues.ForEach(delegate(string x)
		{
			values.Add(x.ConvertTo(valueType, valueType.CreateDefault()));
		});
		IEnumerable<Expression> equals = ((IEnumerable<object>)values).Select((Func<object, Expression>)((object x) => Expression.Equal(keyExp, Expression.Constant(x, valueType))));
		return equals.Aggregate((Expression accumulate, Expression equal) => Expression.Or(accumulate, equal));
	}

	/// <summary>
	/// 将某个查询条件对象转化为表达式
	/// </summary>
	/// <param name="queryItem"></param>
	/// <returns></returns>
	public static Expression<Func<TEntity, bool>> Convert(QueryItem queryItem)
	{
		if (queryItem != null && IsKeyExists(queryItem.Key) && !string.IsNullOrEmpty(queryItem.Value))
		{
			queryItem.DateTimeToUtc();
			ParameterExpression entity = Expression.Parameter(typeof(TEntity), "x");
			Expression keyExp = GetExpression(entity, queryItem.Key);
			Expression valueExp;
			if (!string.IsNullOrEmpty(queryItem.Value))
			{
				if (queryItem.Method.Equals(" In "))
				{
					string[] stringValues = queryItem.Value.Split(',');
					IList<object> values = new List<object>();
					Type valueType = keyExp.Type;
					stringValues.ForEach(delegate(string x)
					{
						values.Add(x.ConvertTo(valueType, valueType.CreateDefault()));
					});
					valueExp = Expression.Constant(values);
				}
				else
				{
					Type type = keyExp.Type;
					object value = queryItem.Value.ConvertTo(type, type.CreateDefault());
					valueExp = Expression.Constant(value, type);
				}
			}
			else
			{
				valueExp = Expression.Constant(keyExp.Type.CreateDefault(), keyExp.Type);
			}
			Expression body = (string.IsNullOrWhiteSpace(queryItem.Method) ? ((!keyExp.Type.Equals(typeof(string)) || string.IsNullOrEmpty(queryItem.Value)) ? ((Expression)Expression.Equal(keyExp, valueExp)) : ((Expression)Expression.Call(keyExp, "Contains", null, valueExp))) : (queryItem.Method.Equals(" = ") ? Expression.Equal(keyExp, valueExp) : (queryItem.Method.Equals(" > ") ? Expression.GreaterThan(keyExp, valueExp) : (queryItem.Method.Equals(" >= ") ? Expression.GreaterThanOrEqual(keyExp, valueExp) : (queryItem.Method.Equals(" < ") ? Expression.LessThan(keyExp, valueExp) : (queryItem.Method.Equals(" <= ") ? Expression.LessThanOrEqual(keyExp, valueExp) : (queryItem.Method.Equals(" != ") ? Expression.NotEqual(keyExp, valueExp) : (queryItem.Method.Equals(" Is Null ") ? Expression.Equal(keyExp, valueExp) : (queryItem.Method.Equals(" Is Not Null ") ? Expression.NotEqual(keyExp, valueExp) : (queryItem.Method.Equals(" Like ") ? Expression.Call(keyExp, "Contains", null, valueExp) : ((!queryItem.Method.Equals(" In ")) ? ((Expression)Expression.Equal(keyExp, valueExp)) : ((Expression)Expression.Call(typeof(Enumerable), "Contains", new Type[1] { keyExp.Type }, valueExp, keyExp)))))))))))));
			return Expression.Lambda<Func<TEntity, bool>>(body, new ParameterExpression[1] { entity });
		}
		return null;
	}

	/// <summary>
	/// 将查询条件列表转化为表达式
	/// </summary>
	/// <param name="queryItemList"></param>
	/// <returns></returns>
	public static Expression<Func<TEntity, bool>> Convert(IEnumerable<QueryItem> queryItemList)
	{
		if (queryItemList != null && queryItemList.Count() > 0)
		{
			Expression<Func<TEntity, bool>> expression = ExpressionFuncExtender.True<TEntity>();
			foreach (QueryItem item in queryItemList)
			{
				Expression<Func<TEntity, bool>> whereExpression = Convert(item);
				if (whereExpression != null)
				{
					expression = expression.And(whereExpression);
				}
			}
			return expression;
		}
		return ExpressionFuncExtender.False<TEntity>();
	}

	/// <summary>
	/// 将查询条件列表转化为Specification对象
	/// </summary>
	/// <param name="queryItemList"></param>
	/// <returns></returns>
	public static ISpecification<TEntity> ConvertSpecification(IEnumerable<QueryItem> queryItemList)
	{
		Expression<Func<TEntity, bool>> expression = Convert(queryItemList);
		return Specification<TEntity>.Eval(expression);
	}

	/// <summary>
	/// 将某个查询条件列表转化为Specification对象
	/// </summary>
	/// <param name="queryItem"></param>
	/// <returns></returns>
	public static ISpecification<TEntity> ConvertSpecification(QueryItem queryItem)
	{
		Expression<Func<TEntity, bool>> expression = Convert(queryItem);
		return Specification<TEntity>.Eval(expression);
	}
}
