using System;
using System.Linq;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Data;

/// <summary>
/// SQL语句对象
/// </summary>
public class SqlStatement
{
	/// <summary>
	/// 获取SQL语句的数据库类型
	/// </summary>
	public DBType DatabaseType { get; private set; }

	/// <summary>
	/// 获取SQL语句的数据库
	/// </summary>
	public string DatabaseName { get; private set; }

	/// <summary>
	/// 获取SQL语句名称
	/// </summary>
	public string Name { get; private set; }

	/// <summary>
	/// 获取SQL语句文本
	/// </summary>
	public string Sql { get; private set; }

	/// <summary>
	/// 获取SQL参数数组
	/// </summary>
	public SqlArgument[] Parameters { get; private set; }

	/// <summary>
	/// 初始化SQL语句对象
	/// </summary>
	/// <param name="type">SQL语句的数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <param name="sql">SQL语句文本</param>
	public SqlStatement(DBType type, string name, string sql)
	{
		DatabaseType = type;
		DatabaseName = type.ToString();
		Name = name.GuardNotNull();
		Sql = sql.GuardNotNull();
		Parameters = SqlArgument.Parse(this);
	}

	/// <summary>
	/// 初始化SQL语句对象
	/// </summary>
	/// <param name="databaseName">SQL语句的数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <param name="sql">SQL语句文本</param>
	public SqlStatement(string databaseName, string name, string sql)
	{
		DatabaseName = databaseName.GuardNotNull();
		Name = name.GuardNotNull();
		Sql = sql.GuardNotNull();
		if (!Enum.TryParse<DBType>(databaseName, out var type))
		{
			type = DBType.Unspecified;
		}
		DatabaseType = type;
		Parameters = SqlArgument.Parse(this);
	}

	/// <summary>
	/// 获取SQL参数的最大编号
	/// </summary>
	/// <returns></returns>
	public int GetParameterMaxNo()
	{
		if (Parameters.IsNull() || Parameters.Length == 0)
		{
			return -1;
		}
		return Parameters.Select((SqlArgument p) => p.No).Max();
	}

	/// <summary>
	/// 将SQL语句对象转化为SQL文本
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return Sql;
	}
}
