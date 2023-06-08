using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.SqlServer.Server;

namespace Dapper;

internal sealed class SqlDataRecordListTVPParameter : SqlMapper.ICustomQueryParameter
{
	private readonly IEnumerable<SqlDataRecord> data;

	private readonly string typeName;

	private static readonly Action<SqlParameter, string> setTypeName;

	public SqlDataRecordListTVPParameter(IEnumerable<SqlDataRecord> data, string typeName)
	{
		this.data = data;
		this.typeName = typeName;
	}

	static SqlDataRecordListTVPParameter()
	{
		PropertyInfo property = typeof(SqlParameter).GetProperty("TypeName", BindingFlags.Instance | BindingFlags.Public);
		if (property != null && property.PropertyType == typeof(string) && property.CanWrite)
		{
			setTypeName = (Action<SqlParameter, string>)Delegate.CreateDelegate(typeof(Action<SqlParameter, string>), property.GetSetMethod());
		}
	}

	void SqlMapper.ICustomQueryParameter.AddParameter(IDbCommand command, string name)
	{
		IDbDataParameter dbDataParameter = command.CreateParameter();
		dbDataParameter.ParameterName = name;
		Set(dbDataParameter, data, typeName);
		command.Parameters.Add(dbDataParameter);
	}

	internal static void Set(IDbDataParameter parameter, IEnumerable<SqlDataRecord> data, string typeName)
	{
		parameter.Value = ((object)data) ?? ((object)DBNull.Value);
		if (parameter is SqlParameter sqlParameter)
		{
			sqlParameter.SqlDbType = SqlDbType.Structured;
			sqlParameter.TypeName = typeName;
		}
	}
}
