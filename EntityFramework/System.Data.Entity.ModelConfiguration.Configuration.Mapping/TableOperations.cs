using System.Data.Entity.Edm.Db;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal static class TableOperations
{
	public static DbTableColumnMetadata CopyColumnAndAnyConstraints(DbDatabaseMetadata database, DbTableMetadata fromTable, DbTableMetadata toTable, DbTableColumnMetadata column, bool useExisting, bool allowPkConstraintCopy)
	{
		DbTableColumnMetadata dbTableColumnMetadata = column;
		if (fromTable != toTable)
		{
			dbTableColumnMetadata = TablePrimitiveOperations.IncludeColumn(toTable, column, useExisting);
			if (allowPkConstraintCopy || !dbTableColumnMetadata.IsPrimaryKeyColumn)
			{
				ForeignKeyPrimitiveOperations.CopyAllForeignKeyConstraintsForColumn(database, fromTable, toTable, column);
			}
		}
		return dbTableColumnMetadata;
	}

	public static DbTableColumnMetadata MoveColumnAndAnyConstraints(DbTableMetadata fromTable, DbTableMetadata toTable, DbTableColumnMetadata column, bool useExisting)
	{
		DbTableColumnMetadata result = column;
		if (fromTable != toTable)
		{
			result = TablePrimitiveOperations.IncludeColumn(toTable, column, useExisting);
			TablePrimitiveOperations.RemoveColumn(fromTable, column);
			ForeignKeyPrimitiveOperations.MoveAllForeignKeyConstraintsForColumn(fromTable, toTable, column);
		}
		return result;
	}
}
