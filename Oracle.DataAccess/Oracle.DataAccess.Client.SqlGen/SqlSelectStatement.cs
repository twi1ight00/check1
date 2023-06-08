using System.Collections.Generic;
using System.Globalization;

namespace Oracle.DataAccess.Client.SqlGen;

internal sealed class SqlSelectStatement : ISqlFragment
{
	private bool outputColumnsRenamed;

	private Dictionary<string, Symbol> outputColumns;

	private bool isDistinct;

	private List<Symbol> allJoinExtents;

	private List<Symbol> fromExtents;

	private Dictionary<Symbol, bool> outerExtents;

	private TopClause top;

	private SqlBuilder select = new SqlBuilder();

	private SqlBuilder from = new SqlBuilder();

	private SqlBuilder where;

	private SqlBuilder groupBy;

	private SqlBuilder orderBy;

	private static TopClause top_s;

	private bool isTopMost;

	internal bool OutputColumnsRenamed
	{
		get
		{
			return outputColumnsRenamed;
		}
		set
		{
			outputColumnsRenamed = value;
		}
	}

	internal Dictionary<string, Symbol> OutputColumns
	{
		get
		{
			return outputColumns;
		}
		set
		{
			outputColumns = value;
		}
	}

	internal bool IsDistinct
	{
		get
		{
			return isDistinct;
		}
		set
		{
			isDistinct = value;
		}
	}

	internal List<Symbol> AllJoinExtents
	{
		get
		{
			return allJoinExtents;
		}
		set
		{
			allJoinExtents = value;
		}
	}

	internal List<Symbol> FromExtents
	{
		get
		{
			if (fromExtents == null)
			{
				fromExtents = new List<Symbol>();
			}
			return fromExtents;
		}
	}

	internal Dictionary<Symbol, bool> OuterExtents
	{
		get
		{
			if (outerExtents == null)
			{
				outerExtents = new Dictionary<Symbol, bool>();
			}
			return outerExtents;
		}
	}

	internal TopClause Top
	{
		get
		{
			return top;
		}
		set
		{
			top = value;
		}
	}

	internal SqlBuilder Select => select;

	internal SqlBuilder From => from;

	internal SqlBuilder Where
	{
		get
		{
			if (where == null)
			{
				where = new SqlBuilder();
			}
			return where;
		}
	}

	internal SqlBuilder GroupBy
	{
		get
		{
			if (groupBy == null)
			{
				groupBy = new SqlBuilder();
			}
			return groupBy;
		}
	}

	public SqlBuilder OrderBy
	{
		get
		{
			if (orderBy == null)
			{
				orderBy = new SqlBuilder();
			}
			return orderBy;
		}
	}

	internal static TopClause Top_s
	{
		get
		{
			return top_s;
		}
		set
		{
			top_s = value;
		}
	}

	internal bool IsTopMost
	{
		get
		{
			return isTopMost;
		}
		set
		{
			isTopMost = value;
		}
	}

	public void WriteSql(SqlWriter writer, SqlGenerator sqlGenerator)
	{
		List<string> list = null;
		if (outerExtents != null && 0 < outerExtents.Count)
		{
			foreach (Symbol key in outerExtents.Keys)
			{
				if (key is JoinSymbol joinSymbol)
				{
					foreach (Symbol flattenedExtent in joinSymbol.FlattenedExtentList)
					{
						if (list == null)
						{
							list = new List<string>();
						}
						list.Add(flattenedExtent.NewName);
					}
				}
				else
				{
					if (list == null)
					{
						list = new List<string>();
					}
					list.Add(key.NewName);
				}
			}
		}
		List<Symbol> list2 = AllJoinExtents ?? fromExtents;
		if (list2 != null)
		{
			foreach (Symbol item in list2)
			{
				if (list != null && list.Contains(item.Name))
				{
					int num = sqlGenerator.AllExtentNames[item.Name];
					string text;
					do
					{
						num++;
						text = item.Name + num.ToString(CultureInfo.InvariantCulture);
					}
					while (sqlGenerator.AllExtentNames.ContainsKey(text));
					sqlGenerator.AllExtentNames[item.Name] = num;
					item.NewName = text;
					sqlGenerator.AllExtentNames[text] = 0;
				}
				if (list == null)
				{
					list = new List<string>();
				}
				list.Add(item.NewName);
			}
		}
		writer.Indent++;
		if ((IsTopMost && Top != null && orderBy != null && !OrderBy.IsEmpty) || (!IsTopMost && orderBy != null && !OrderBy.IsEmpty))
		{
			writer.Write("SELECT * ");
			writer.WriteLine();
			writer.Write("FROM ( ");
			writer.WriteLine();
		}
		writer.Write("SELECT ");
		if (IsDistinct)
		{
			writer.Write("DISTINCT ");
		}
		if (select == null || Select.IsEmpty)
		{
			writer.Write("*");
		}
		else
		{
			Select.WriteSql(writer, sqlGenerator);
		}
		writer.WriteLine();
		writer.Write("FROM ");
		From.WriteSql(writer, sqlGenerator);
		if (where != null && !Where.IsEmpty)
		{
			writer.WriteLine();
			writer.Write("WHERE (");
			Where.WriteSql(writer, sqlGenerator);
			writer.Write(")");
			if (Top != null && (orderBy == null || (orderBy != null && OrderBy.IsEmpty)))
			{
				writer.Write(" AND (");
				Top.WriteSql(writer, sqlGenerator);
				writer.Write(")");
			}
		}
		else if (Top != null && (orderBy == null || (orderBy != null && OrderBy.IsEmpty)))
		{
			writer.WriteLine();
			writer.Write("WHERE (");
			Top.WriteSql(writer, sqlGenerator);
			writer.Write(")");
		}
		if (groupBy != null && !GroupBy.IsEmpty)
		{
			writer.WriteLine();
			writer.Write("GROUP BY ");
			GroupBy.WriteSql(writer, sqlGenerator);
		}
		if (orderBy != null && !OrderBy.IsEmpty && (IsTopMost || Top != null))
		{
			writer.WriteLine();
			writer.Write("ORDER BY ");
			OrderBy.WriteSql(writer, sqlGenerator);
		}
		if (Top != null && orderBy != null && !OrderBy.IsEmpty)
		{
			Top_s = Top;
		}
		if (IsTopMost || (orderBy != null && !OrderBy.IsEmpty))
		{
			if ((IsTopMost && Top != null && orderBy != null && !OrderBy.IsEmpty) || (!IsTopMost && orderBy != null && !OrderBy.IsEmpty))
			{
				writer.WriteLine();
				writer.Write(")");
			}
			if (Top_s != null)
			{
				writer.WriteLine();
				writer.Write("WHERE (");
				Top_s.WriteSql(writer, sqlGenerator);
				writer.Write(")");
				Top_s = null;
			}
		}
		writer.Indent--;
	}
}
