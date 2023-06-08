using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Richfit.Garnet.Common.Dynamic;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// 与SQL相关的接口
/// </summary>
public interface ISql
{
	/// <summary>
	/// 执行动态Sql查询，返回结果集的动态对象列表
	/// </summary>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="parameters">SQL参数值</param>
	/// <returns>结果集的动态对象列表</returns>
	IList<IDataObject> DynamicSqlQuery(string sql, params object[] parameters);

	/// <summary>
	/// 执行动态Sql查询，返回多个结果集的动态对象列表数组
	/// </summary>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="parameters">SQL参数值</param>
	/// <returns>结果集的动态对象列表数组</returns>
	IList<IDataObject>[] DynamicSqlQueryResults(string sql, params object[] parameters);

	/// <summary>
	/// 执行SQL语句，返回语句影响的记录数量
	/// </summary>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="parameters">SQL参数值</param>
	/// <returns>语句影响的记录数量</returns>
	/// <example>
	/// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer &gt; {0}
	/// </example>
	int ExecuteCommand(string sql, params object[] parameters);

	/// <summary>
	/// 执行SQL语句，返回结果集的对象列表。
	/// </summary>
	/// <typeparam name="TObject">结果集的对象类型</typeparam>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="parameters">SQL参数值</param>
	/// <returns>结果集的对象列表</returns>
	IList<TObject> ExecuteQuery<TObject>(string sql, params object[] parameters);

	/// <summary>
	/// 执行SQL语句，返回结果集的对象列表。
	/// </summary>
	/// <typeparam name="TObject">结果集的对象类型</typeparam>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="parameters">SQL参数值</param>
	/// <returns>结果集的对象列表</returns>
	IList<TObject> ExecuteQuery<TObject>(string sql, object parameters);

	/// <summary>
	/// 执行SQL语句，返回结果集的第一行第一列的值
	/// </summary>
	/// <typeparam name="TObject">结果值类型</typeparam>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="parameters">SQL参数值</param>
	/// <returns>结果集的第一行第一列的值，如果结果集为空则返回null。</returns>
	TObject ExecuteScalar<TObject>(string sql, params object[] parameters);

	/// <summary>
	/// 执行SQL语句，返回整型值，如Count(*)
	/// </summary>
	/// <param name="sql">执行的SQL语句</param>
	/// <param name="parameters">SQL参数值</param>
	/// <returns>结果值</returns>
	int GetCount(string sql, params object[] parameters);

	/// <summary>
	/// 构造适用于当前数据库的SQL参数
	/// </summary>
	/// <param name="parameterName">参数名称</param>
	/// <param name="value">参数值</param>
	/// <param name="direction">参数调用方向</param>
	/// <returns>当前数据库SQL参数</returns>
	/// <seealso href="http://blogs.msdn.com/b/diego/archive/2012/01/10/how-to-execute-stored-procedures-sqlquery-in-the-dbcontext-api.aspx" />
	DbParameter CreateParameter(string parameterName, object value, ParameterDirection direction);
}
