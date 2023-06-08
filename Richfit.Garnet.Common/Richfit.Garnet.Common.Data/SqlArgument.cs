using System.Collections.Generic;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Data;

/// <summary>
/// SQL参数对象
/// </summary>
public class SqlArgument
{
	/// <summary>
	/// 获取SQL语句的数据库类型
	/// </summary>
	public DBType DatabaseType { get; private set; }

	/// <summary>
	/// 获取参数对应的SQL语句
	/// </summary>
	public SqlStatement Sql { get; private set; }

	/// <summary>
	/// 获取参数前缀符号
	/// </summary>
	public string Prefix { get; private set; }

	/// <summary>
	/// 获取参数名称
	/// </summary>
	public string Name { get; private set; }

	/// <summary>
	/// 获取参数序号
	/// </summary>
	public int No { get; private set; }

	/// <summary>
	/// 获取参数索引
	/// </summary>
	public int Index { get; private set; }

	/// <summary>
	/// 从SQL语句中生成SQL参数对象
	/// </summary>
	/// <param name="sql">SQL语句对象</param>
	/// <returns>SQL参数对象数组</returns>
	public static SqlArgument[] Parse(SqlStatement sql)
	{
		if (sql.IsNull())
		{
			return new SqlArgument[0];
		}
		Regex pattern = sql.DatabaseType switch
		{
			DBType.SqlServer => new Regex("(@)([a-zA-Z]+(\\d+))", RegexOptions.Compiled), 
			DBType.Oracle => new Regex("(:)([a-zA-Z]+(\\d+))", RegexOptions.Compiled), 
			_ => null, 
		};
		if (pattern.IsNull())
		{
			return new SqlArgument[0];
		}
		List<SqlArgument> parameters = new List<SqlArgument>();
		int index = 0;
		foreach (Match i in pattern.Matches(sql.Sql))
		{
			if (i.Success && i.Length > 0 && i.Groups.Count >= 2)
			{
				SqlArgument parameter = new SqlArgument();
				parameter.DatabaseType = sql.DatabaseType;
				parameter.Sql = sql;
				parameter.Prefix = i.Groups[1].Value;
				parameter.Name = i.Groups[2].Value;
				parameter.Index = index++;
				if (i.Groups.Count > 3 && i.Groups[3].Length > 0)
				{
					parameter.No = i.Groups[3].Value.ConvertToInt32();
				}
				else
				{
					parameter.No = -1;
				}
				parameters.Add(parameter);
			}
		}
		return parameters.ToArray();
	}

	/// <summary>
	/// 初始化
	/// </summary>
	public SqlArgument()
	{
		DatabaseType = DBType.Unspecified;
		Sql = null;
		Prefix = string.Empty;
		Name = string.Empty;
		No = 0;
		Index = 0;
	}

	/// <summary>
	/// 将参数对象转换为字符串
	/// </summary>
	/// <returns>参数全名</returns>
	public override string ToString()
	{
		return Prefix + Name;
	}
}
