namespace Oracle.DataAccess.Client.SqlGen;

internal interface ISqlFragment
{
	void WriteSql(SqlWriter writer, SqlGenerator sqlGenerator);
}
