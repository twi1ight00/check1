using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Text;
using Richfit.Garnet.Module.Base.Infrastructure.Data;

namespace Richfit.Garnet.Module.Base.Infrastructure;

/// <summary>
/// 工具方法类
/// </summary>
public class Utility
{
	/// <summary>
	/// 获取Guid值适用于指定数据库的字符串表示
	/// </summary>
	/// <param name="guid">Guid的标准字符串表示</param>
	/// <param name="dbContextName">数据库上下文名称</param>
	/// <returns>适用于指定数据库的字符串表示</returns>
	/// <remarks>
	/// <para>
	/// 应用于：
	/// 1、用于多数据库支持的情况下，Guid与字符串类型相等比较的问题，如：多语言中的StringKey
	/// 2、拼写Sql字符串中的Guid查询条件值，如IN、=等场景
	/// </para>
	/// <para>
	/// 对于SQL Server数据库，Guid的字符串表示就是其标准的字符串表示；
	/// 对于Oracle数据库，Guid的字符串表示是将Guid转换为字符数组后，字符数组的字符串表示。
	/// </para>
	/// </remarks>
	public static string GetGuidString(string guid, string dbContextName = "")
	{
		dbContextName.GuardNotNull("Database Context Name");
		if (Guid.TryParse(guid, out var returnGuid))
		{
			DBType dbType = EntityFrameworkConnection.GetDBType(dbContextName);
			if (dbType == DBType.Oracle)
			{
				return returnGuid.ToOracleHex();
			}
		}
		return guid;
	}

	/// <summary>
	/// 获取Guid值适用于指定数据库的字符串表示
	/// </summary>
	/// <param name="guid">原始Guid值</param>
	/// <param name="dbContextName">数据库上下文名称</param>
	/// <returns>适用于指定数据库的字符串表示</returns>
	/// <remarks>
	/// <para>
	/// 应用于：
	/// 1、用于多数据库支持的情况下，Guid与字符串类型相等比较的问题，如：多语言中的StringKey
	/// 2、拼写Sql字符串中的Guid查询条件值，如IN、=等场景
	/// </para>
	/// <para>
	/// 对于SQL Server数据库，Guid的字符串表示就是其标准的字符串表示；
	/// 对于Oracle数据库，Guid的字符串表示是将Guid转换为字符数组后，字符数组的字符串表示。
	/// </para>
	/// </remarks>
	public static string GetGuidString(Guid guid, string dbContextName = "")
	{
		DBType dbType = EntityFrameworkConnection.GetDBType(dbContextName);
		if (dbType == DBType.Oracle)
		{
			return guid.ToOracleHex();
		}
		return guid.ToString();
	}

	/// <summary>
	/// 获取Oracle SQL语句中参数从前到后出现的索引数组
	/// </summary>
	/// <param name="sql">待执行的Oracle SQL语句</param>
	/// <returns>SQL语句中出现的参数的索引数组</returns>
	/// <remarks>
	/// 如果SQL中出现的参数的顺序为: “:P2 :P1 :P3 :P0”，则返回的索引数组的值为： “2, 1, 3, 0”
	/// </remarks>
	public static int[] GetOracleSqlParaIndex(string sql)
	{
		return (from m in sql.GetMatches(RegexPatterns.OracleParameterToken)
			select m.Groups[3].Value.ConvertToInt32()).ToArray();
	}

	/// <summary>
	/// 获取SQL语句中格式化占位符“{x}”的最大索引
	/// </summary>
	/// <param name="sql">SQL 语句</param>
	/// <returns>格式化占位符“{x}”的最大索引</returns>
	public static int GetMaxStringFormatIndex(string sql)
	{
		return (from m in sql.GetMatches(RegexPatterns.StringFormatToken)
			select m.Groups[1].Value.ConvertToInt32()).DefaultIfEmpty(0).Max();
	}

	/// <summary>
	/// 构造Like or Like表达式
	/// </summary>
	/// <typeparam name="TElement">实体类型</typeparam>
	/// <typeparam name="TValue">值类型</typeparam>
	/// <param name="valueSelector">值选择表达式</param>
	/// <param name="values">值</param>
	/// <returns></returns>
	/// <example><![CDATA[
	/// var productNames = new string[] {"P1", "P2"};
	/// BuildOrLikeExpression<Product, string>(d=>d.ProductName, productNames)
	/// Sql Result：ProductName like '%P1%' or ProductName like '%P2%'
	/// ]]>!</example>
	public static Expression<Func<TElement, bool>> BuildOrLikeExpression<TElement, TValue>(Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
	{
		MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[1] { typeof(string) });
		IEnumerable<Expression> contains = values.Select((Func<TValue, Expression>)((TValue value) => Expression.Call(valueSelector.Body, containsMethod, Expression.Constant(value, typeof(TValue)))));
		Expression body = contains.Aggregate((Expression accumulate, Expression equal) => Expression.Or(accumulate, equal));
		ParameterExpression p = Expression.Parameter(typeof(TElement));
		return Expression.Lambda<Func<TElement, bool>>(body, new ParameterExpression[1] { p });
	}

	/// <summary>
	/// 构造Where In表达式
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	/// <param name="valueSelector"></param>
	/// <param name="values"></param>
	/// <returns></returns>
	/// <example><![CDATA[
	/// var ids = new string[] { "3012472", "3012473", "3012474", "3012475" };
	/// BuildWhereInExpression<Product, string>(d=>d.Id, ids)
	/// Sql Result：Id in ("3012472", "3012473", "3012474", "3012475" )
	/// ]]>!</example>
	public static Expression<Func<TElement, bool>> BuildWhereInExpression<TElement, TValue>(Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
	{
		ParameterExpression p = valueSelector.Parameters.Single();
		if (values.Count() > 3000)
		{
			throw new ArgumentException("Collection too large - execution will cause stack overflow", "collection");
		}
		IEnumerable<Expression> equals = values.Select((Func<TValue, Expression>)((TValue value) => Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue)))));
		Expression body = equals.Aggregate((Expression accumulate, Expression equal) => Expression.Or(accumulate, equal));
		return Expression.Lambda<Func<TElement, bool>>(body, new ParameterExpression[1] { p });
	}
}
