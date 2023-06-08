using System.Data.Common;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.Migrations.Sql;

/// <summary>
/// Provider to convert provider agnostic migration operations into SQL commands 
/// that can be run against Microsoft SQL Server Compact Edition.
/// </summary>
public class SqlCeMigrationSqlGenerator : SqlServerMigrationSqlGenerator
{
	/// <inheritdoc />
	protected override DbConnection CreateConnection()
	{
		return DbProviderFactories.GetFactory("System.Data.SqlServerCe.4.0").CreateConnection();
	}

	/// <inheritdoc />
	protected override void GenerateCreateSchema(string schema)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(schema), null, "!string.IsNullOrWhiteSpace(schema)");
	}

	/// <inheritdoc />
	protected override void Generate(RenameColumnOperation renameColumnOperation)
	{
		//Discarded unreachable code: IL_0019
		RuntimeFailureMethods.Requires(renameColumnOperation != null, null, "renameColumnOperation != null");
		throw Error.SqlCeColumnRenameNotSupported();
	}

	/// <inheritdoc />
	protected override void Generate(RenameTableOperation renameTableOperation)
	{
		RuntimeFailureMethods.Requires(renameTableOperation != null, null, "renameTableOperation != null");
		using IndentedTextWriter indentedTextWriter = SqlServerMigrationSqlGenerator.Writer();
		indentedTextWriter.Write("EXECUTE sp_rename @objname = N'");
		indentedTextWriter.Write(renameTableOperation.Name.Split(new char[1] { '.' }, 2).Last());
		indentedTextWriter.Write("', @newname = N'");
		indentedTextWriter.Write(renameTableOperation.NewName);
		indentedTextWriter.Write("', @objtype = N'OBJECT'");
		Statement(indentedTextWriter);
	}

	/// <inheritdoc />
	protected override void Generate(MoveTableOperation moveTableOperation)
	{
		RuntimeFailureMethods.Requires(moveTableOperation != null, null, "moveTableOperation != null");
	}

	/// <inheritdoc />
	protected override void GenerateMakeSystemTable(CreateTableOperation createTableOperation)
	{
		RuntimeFailureMethods.Requires(createTableOperation != null, null, "createTableOperation != null");
	}

	/// <inheritdoc />
	protected override void Generate(DropColumnOperation dropColumnOperation)
	{
		RuntimeFailureMethods.Requires(dropColumnOperation != null, null, "dropColumnOperation != null");
		using IndentedTextWriter indentedTextWriter = SqlServerMigrationSqlGenerator.Writer();
		indentedTextWriter.Write("ALTER TABLE ");
		indentedTextWriter.Write(Name(dropColumnOperation.Table));
		indentedTextWriter.Write(" DROP COLUMN ");
		indentedTextWriter.Write(Quote(dropColumnOperation.Name));
		Statement(indentedTextWriter);
	}

	/// <inheritdoc />
	protected override void Generate(DropIndexOperation dropIndexOperation)
	{
		RuntimeFailureMethods.Requires(dropIndexOperation != null, null, "dropIndexOperation != null");
		using IndentedTextWriter indentedTextWriter = SqlServerMigrationSqlGenerator.Writer();
		indentedTextWriter.Write("DROP INDEX ");
		indentedTextWriter.Write(Name(dropIndexOperation.Table));
		indentedTextWriter.Write(".");
		indentedTextWriter.Write(Quote(dropIndexOperation.Name));
		Statement(indentedTextWriter);
	}

	/// <inheritdoc />
	protected override void Generate(AlterColumnOperation alterColumnOperation)
	{
		RuntimeFailureMethods.Requires(alterColumnOperation != null, null, "alterColumnOperation != null");
		ColumnModel column = alterColumnOperation.Column;
		using (IndentedTextWriter indentedTextWriter = SqlServerMigrationSqlGenerator.Writer())
		{
			indentedTextWriter.Write("ALTER TABLE ");
			indentedTextWriter.Write(Name(alterColumnOperation.Table));
			indentedTextWriter.Write(" ALTER COLUMN ");
			indentedTextWriter.Write(Quote(column.Name));
			indentedTextWriter.Write(" ");
			indentedTextWriter.Write(BuildColumnType(column));
			if (column.IsNullable.HasValue && !column.IsNullable.Value)
			{
				indentedTextWriter.Write(" NOT NULL");
			}
			Statement(indentedTextWriter);
		}
		if (column.DefaultValue != null || !string.IsNullOrWhiteSpace(column.DefaultValueSql))
		{
			using (IndentedTextWriter indentedTextWriter2 = SqlServerMigrationSqlGenerator.Writer())
			{
				indentedTextWriter2.Write("ALTER TABLE ");
				indentedTextWriter2.Write(Name(alterColumnOperation.Table));
				indentedTextWriter2.Write(" ALTER COLUMN ");
				indentedTextWriter2.Write(Quote(column.Name));
				indentedTextWriter2.Write(" SET DEFAULT ");
				indentedTextWriter2.Write((column.DefaultValue != null) ? Generate((dynamic)column.DefaultValue) : column.DefaultValueSql);
				Statement(indentedTextWriter2);
			}
		}
	}

	/// <inheritdoc />
	protected override string Generate(DateTime defaultValue)
	{
		return "'" + defaultValue.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "'";
	}

	/// <inheritdoc />
	protected override string Name(string name)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		return Quote(name.Split(new char[1] { '.' }, 2).Last());
	}
}
