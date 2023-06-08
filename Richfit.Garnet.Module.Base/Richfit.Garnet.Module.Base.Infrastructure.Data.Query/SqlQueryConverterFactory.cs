using System;
using Richfit.Garnet.Common.Data;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

/// <summary>
/// SQL查询转换器工厂
/// </summary>
public class SqlQueryConverterFactory
{
	/// <summary>
	/// 创建适用于指定数据库类型的SQL转换器
	/// </summary>
	/// <param name="type">数据库类型</param>
	/// <returns>SQL转换器对象</returns>
	public static ISqlQueryConverter Create(DBType type)
	{
		return type switch
		{
			DBType.SqlServer => new SqlServerQueryConverter(), 
			DBType.Oracle => new OracleQueryConverter(), 
			_ => throw new NotSupportedException(), 
		};
	}
}
