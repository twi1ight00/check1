using System;
using System.Data;

namespace Oracle.DataAccess.Client;

internal class RefCursorInfo
{
	internal string name = string.Empty;

	internal int position;

	internal ParameterDirection mode;

	internal bool isPrimaryKeyPresent;

	internal DataTable columnInfo = new DataTable("SchemaTable");

	internal RefCursorInfo()
	{
		columnInfo.Columns.Add("ColumnName", typeof(string));
		columnInfo.Columns.Add("ColumnOrdinal", typeof(int));
		columnInfo.Columns.Add("ColumnSize", typeof(int));
		columnInfo.Columns.Add("NumericPrecision", typeof(short));
		columnInfo.Columns.Add("NumericScale", typeof(short));
		columnInfo.Columns.Add("IsUnique", typeof(bool));
		columnInfo.Columns.Add("IsKey", typeof(bool));
		columnInfo.Columns.Add("IsRowID", typeof(bool));
		columnInfo.Columns.Add("BaseColumnName", typeof(string));
		columnInfo.Columns.Add("BaseSchemaName", typeof(string));
		columnInfo.Columns.Add("BaseTableName", typeof(string));
		columnInfo.Columns.Add("DataType", typeof(Type));
		columnInfo.Columns.Add("ProviderType", typeof(OracleDbType));
		columnInfo.Columns.Add("AllowDBNull", typeof(bool));
		columnInfo.Columns.Add("IsAliased", typeof(bool));
		columnInfo.Columns.Add("IsByteSemantic", typeof(bool));
		columnInfo.Columns.Add("IsExpression", typeof(bool));
		columnInfo.Columns.Add("IsHidden", typeof(bool));
		columnInfo.Columns.Add("IsReadOnly", typeof(bool));
		columnInfo.Columns.Add("IsLong", typeof(bool));
		columnInfo.Columns.Add("UdtTypeName", typeof(string));
		columnInfo.Columns.Add("NativeDataType", typeof(string));
		columnInfo.Columns.Add("ProviderDBType", typeof(DbType));
		columnInfo.Columns.Add("ObjectName", typeof(string));
	}
}
