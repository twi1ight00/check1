using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Db;

internal static class DbTableMetadataExtensions
{
	private const string TableNameAnnotation = "TableName";

	private const string KeyNamesTypeAnnotation = "KeyNamesType";

	public static DbTableColumnMetadata AddColumn(this DbTableMetadata table, string name)
	{
		DbTableColumnMetadata dbTableColumnMetadata = new DbTableColumnMetadata();
		dbTableColumnMetadata.Name = table.Columns.UniquifyName(name);
		DbTableColumnMetadata dbTableColumnMetadata2 = dbTableColumnMetadata.Initialize();
		dbTableColumnMetadata2.SetPreferredName(name);
		table.Columns.Add(dbTableColumnMetadata2);
		return dbTableColumnMetadata2;
	}

	public static bool ContainsEquivalentForeignKey(this DbTableMetadata table, DbForeignKeyConstraintMetadata foreignKey)
	{
		return table.ForeignKeyConstraints.Any((DbForeignKeyConstraintMetadata fk) => fk.PrincipalTable == foreignKey.PrincipalTable && fk.DependentColumns.SequenceEqual(foreignKey.DependentColumns));
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static object GetConfiguration(this DbTableMetadata table)
	{
		return table.Annotations.GetConfiguration();
	}

	public static void SetConfiguration(this DbTableMetadata table, object configuration)
	{
		table.Annotations.SetConfiguration(configuration);
	}

	public static DatabaseName GetTableName(this DbTableMetadata table)
	{
		return (DatabaseName)table.Annotations.GetAnnotation("TableName");
	}

	public static void SetTableName(this DbTableMetadata table, DatabaseName tableName)
	{
		table.Annotations.SetAnnotation("TableName", tableName);
	}

	public static EdmEntityType GetKeyNamesType(this DbTableMetadata table)
	{
		return (EdmEntityType)table.Annotations.GetAnnotation("KeyNamesType");
	}

	public static void SetKeyNamesType(this DbTableMetadata table, EdmEntityType entityType)
	{
		table.Annotations.SetAnnotation("KeyNamesType", entityType);
	}
}
