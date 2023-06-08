using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class TablePrimitiveOperations
{
	private static DbTableColumnMetadata AddColumn(DbTableMetadata table, DbTableColumnMetadata column)
	{
		if (!table.Columns.Contains(column))
		{
			if (!(column.GetConfiguration() is System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration primitivePropertyConfiguration) || string.IsNullOrWhiteSpace(primitivePropertyConfiguration.ColumnName))
			{
				string name = column.GetPreferredName() ?? column.Name;
				column.SetUnpreferredUniqueName(column.Name);
				column.Name = table.Columns.UniquifyName(name);
			}
			table.Columns.Add(column);
		}
		return column;
	}

	public static DbTableColumnMetadata RemoveColumn(DbTableMetadata table, DbTableColumnMetadata column)
	{
		if (!column.IsPrimaryKeyColumn)
		{
			table.Columns.Remove(column);
		}
		return column;
	}

	public static DbTableColumnMetadata IncludeColumn(DbTableMetadata table, DbTableColumnMetadata templateColumn, bool useExisting)
	{
		DbTableColumnMetadata dbTableColumnMetadata = table.Columns.SingleOrDefault((DbTableColumnMetadata c) => string.Equals(c.Name, templateColumn.Name, StringComparison.Ordinal));
		if (dbTableColumnMetadata == null)
		{
			templateColumn = templateColumn.Clone();
		}
		else if (!useExisting && !dbTableColumnMetadata.IsPrimaryKeyColumn)
		{
			templateColumn = templateColumn.Clone();
		}
		else
		{
			templateColumn = dbTableColumnMetadata;
		}
		return AddColumn(table, templateColumn);
	}

	public static DbTableColumnMetadata IncludeColumn(DbTableMetadata table, string columnName, bool useExisting)
	{
		DbTableColumnMetadata dbTableColumnMetadata = table.Columns.SingleOrDefault((DbTableColumnMetadata c) => string.Equals(c.Name, columnName, StringComparison.Ordinal));
		DbTableColumnMetadata dbTableColumnMetadata2 = null;
		dbTableColumnMetadata2 = ((dbTableColumnMetadata == null) ? table.AddColumn(columnName) : ((useExisting || dbTableColumnMetadata.IsPrimaryKeyColumn) ? dbTableColumnMetadata : table.AddColumn(columnName)));
		return AddColumn(table, dbTableColumnMetadata2);
	}
}
