using System.Globalization;

namespace Oracle.DataAccess.Client.SqlGen;

internal class TopClause : ISqlFragment
{
	private ISqlFragment topCount;

	private bool withTies;

	internal bool WithTies => withTies;

	internal ISqlFragment TopCount => topCount;

	internal TopClause(ISqlFragment topCount, bool withTies)
	{
		this.topCount = topCount;
		this.withTies = withTies;
	}

	internal TopClause(int topCount, bool withTies)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(topCount.ToString(CultureInfo.InvariantCulture));
		this.topCount = sqlBuilder;
		this.withTies = withTies;
	}

	public void WriteSql(SqlWriter writer, SqlGenerator sqlGenerator)
	{
		writer.Write("ROWNUM <= (");
		TopCount.WriteSql(writer, sqlGenerator);
		writer.Write(")");
		writer.Write(" ");
		if (WithTies)
		{
			writer.Write("WITH TIES ");
		}
	}
}
