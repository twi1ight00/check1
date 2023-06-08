using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Metadata.Edm;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace System.Data.Entity.Migrations.Sql;

/// <summary>
/// Provider to convert provider agnostic migration operations into SQL commands 
/// that can be run against a Microsoft SQL Server database.
/// </summary>
public class SqlServerMigrationSqlGenerator : MigrationSqlGenerator
{
	internal const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffK";

	internal const string DateTimeOffsetFormat = "yyyy-MM-ddTHH:mm:ss.fffzzz";

	private const int DefaultMaxLength = 128;

	private const int DefaultNumericPrecision = 18;

	private const byte DefaultTimePrecision = 7;

	private const byte DefaultScale = 0;

	private DbProviderManifest _providerManifest;

	private List<MigrationStatement> _statements;

	private HashSet<string> _generatedSchemas;

	private int _variableCounter;

	/// <summary>
	/// Converts a set of migration operations into Microsoft SQL Server specific SQL.
	/// </summary>
	/// <param name="migrationOperations">The operations to be converted.</param>
	/// <param name="providerManifestToken">Token representing the version of SQL Server being targeted (i.e. "2005", "2008").</param>
	/// <returns>A list of SQL statements to be executed to perform the migration operations.</returns>
	public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
	{
		RuntimeFailureMethods.Requires(migrationOperations != null, null, "migrationOperations != null");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerManifestToken), null, "!string.IsNullOrWhiteSpace(providerManifestToken)");
		_statements = new List<MigrationStatement>();
		_generatedSchemas = new HashSet<string>();
		_variableCounter = 0;
		using (DbConnection connection = CreateConnection())
		{
			_providerManifest = DbProviderServices.GetProviderServices(connection).GetProviderManifest(providerManifestToken);
		}
		System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(migrationOperations, delegate(dynamic o)
		{
			Generate(o);
		});
		return _statements;
	}

	/// <summary>
	/// Creates an empty connection for the current provider.
	/// Allows derived providers to use connection other than <see cref="T:System.Data.SqlClient.SqlConnection" />.
	/// </summary>
	/// <returns></returns>
	protected virtual DbConnection CreateConnection()
	{
		return new SqlConnection();
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.CreateTableOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="createTableOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(CreateTableOperation createTableOperation)
	{
		RuntimeFailureMethods.Requires(createTableOperation != null, null, "createTableOperation != null");
		string[] array = createTableOperation.Name.Split(new char[1] { '.' }, 2);
		if (array.Length > 1)
		{
			string text = array[0];
			if (!text.EqualsIgnoreCase("dbo") && !_generatedSchemas.Contains(text))
			{
				GenerateCreateSchema(text);
				_generatedSchemas.Add(text);
			}
		}
		IndentedTextWriter writer = Writer();
		try
		{
			writer.WriteLine("CREATE TABLE " + Name(createTableOperation.Name) + " (");
			writer.Indent++;
			int columnCount = createTableOperation.Columns.Count();
			System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(createTableOperation.Columns, delegate(ColumnModel c, int i)
			{
				Generate(c, writer);
				if (i < columnCount - 1)
				{
					writer.WriteLine(",");
				}
			});
			if (createTableOperation.PrimaryKey != null)
			{
				writer.WriteLine(",");
				writer.Write("CONSTRAINT ");
				writer.Write(Quote(createTableOperation.PrimaryKey.Name));
				writer.Write(" PRIMARY KEY (");
				writer.Write(createTableOperation.PrimaryKey.Columns.Join(Quote));
				writer.WriteLine(")");
			}
			else
			{
				writer.WriteLine();
			}
			writer.Indent--;
			writer.Write(")");
			Statement(writer);
		}
		finally
		{
			if (writer != null)
			{
				((IDisposable)writer).Dispose();
			}
		}
		GenerateMakeSystemTable(createTableOperation);
	}

	/// <summary>
	/// Generates SQL to mark a table as a system table.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="createTableOperation">The table to mark as a system table.</param>
	protected virtual void GenerateMakeSystemTable(CreateTableOperation createTableOperation)
	{
		RuntimeFailureMethods.Requires(createTableOperation != null, null, "createTableOperation != null");
		createTableOperation.AnonymousArguments.TryGetValue("IsMSShipped", out var value);
		if (value as bool? == true)
		{
			using (IndentedTextWriter indentedTextWriter = Writer())
			{
				indentedTextWriter.WriteLine("BEGIN TRY");
				indentedTextWriter.Indent++;
				indentedTextWriter.WriteLine("EXEC sp_MS_marksystemobject '" + createTableOperation.Name + "'");
				indentedTextWriter.Indent--;
				indentedTextWriter.WriteLine("END TRY");
				indentedTextWriter.WriteLine("BEGIN CATCH");
				indentedTextWriter.Write("END CATCH");
				Statement(indentedTextWriter);
			}
		}
	}

	/// <summary>
	/// Generates SQL to create a database schema.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="createTableOperation">The name of the schema to create.</param>
	protected virtual void GenerateCreateSchema(string schema)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(schema), null, "!string.IsNullOrWhiteSpace(schema)");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("IF schema_id('");
		indentedTextWriter.Write(schema);
		indentedTextWriter.WriteLine("') IS NULL");
		indentedTextWriter.Indent++;
		indentedTextWriter.Write("EXECUTE('CREATE SCHEMA ");
		indentedTextWriter.Write(Quote(schema));
		indentedTextWriter.Write("')");
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.AddForeignKeyOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="addForeignKeyOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(AddForeignKeyOperation addForeignKeyOperation)
	{
		RuntimeFailureMethods.Requires(addForeignKeyOperation != null, null, "addForeignKeyOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("ALTER TABLE ");
		indentedTextWriter.Write(Name(addForeignKeyOperation.DependentTable));
		indentedTextWriter.Write(" ADD CONSTRAINT ");
		indentedTextWriter.Write(Quote(addForeignKeyOperation.Name));
		indentedTextWriter.Write(" FOREIGN KEY (");
		indentedTextWriter.Write(addForeignKeyOperation.DependentColumns.Select(Quote).Join());
		indentedTextWriter.Write(") REFERENCES ");
		indentedTextWriter.Write(Name(addForeignKeyOperation.PrincipalTable));
		indentedTextWriter.Write(" (");
		indentedTextWriter.Write(addForeignKeyOperation.PrincipalColumns.Select(Quote).Join());
		indentedTextWriter.Write(")");
		if (addForeignKeyOperation.CascadeDelete)
		{
			indentedTextWriter.Write(" ON DELETE CASCADE");
		}
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.DropForeignKeyOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="dropForeignKeyOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(DropForeignKeyOperation dropForeignKeyOperation)
	{
		RuntimeFailureMethods.Requires(dropForeignKeyOperation != null, null, "dropForeignKeyOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("ALTER TABLE ");
		indentedTextWriter.Write(Name(dropForeignKeyOperation.DependentTable));
		indentedTextWriter.Write(" DROP CONSTRAINT ");
		indentedTextWriter.Write(Quote(dropForeignKeyOperation.Name));
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.CreateIndexOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="createIndexOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(CreateIndexOperation createIndexOperation)
	{
		RuntimeFailureMethods.Requires(createIndexOperation != null, null, "createIndexOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("CREATE ");
		if (createIndexOperation.IsUnique)
		{
			indentedTextWriter.Write("UNIQUE ");
		}
		indentedTextWriter.Write("INDEX ");
		indentedTextWriter.Write(Quote(createIndexOperation.Name));
		indentedTextWriter.Write(" ON ");
		indentedTextWriter.Write(Name(createIndexOperation.Table));
		indentedTextWriter.Write("(");
		indentedTextWriter.Write(createIndexOperation.Columns.Join(Quote));
		indentedTextWriter.Write(")");
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.DropIndexOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="dropIndexOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(DropIndexOperation dropIndexOperation)
	{
		RuntimeFailureMethods.Requires(dropIndexOperation != null, null, "dropIndexOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("DROP INDEX ");
		indentedTextWriter.Write(Quote(dropIndexOperation.Name));
		indentedTextWriter.Write(" ON ");
		indentedTextWriter.Write(Name(dropIndexOperation.Table));
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.AddPrimaryKeyOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="addPrimaryKeyOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(AddPrimaryKeyOperation addPrimaryKeyOperation)
	{
		RuntimeFailureMethods.Requires(addPrimaryKeyOperation != null, null, "addPrimaryKeyOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("ALTER TABLE ");
		indentedTextWriter.Write(Name(addPrimaryKeyOperation.Table));
		indentedTextWriter.Write(" ADD CONSTRAINT ");
		indentedTextWriter.Write(Quote(addPrimaryKeyOperation.Name));
		indentedTextWriter.Write(" PRIMARY KEY (");
		indentedTextWriter.Write(addPrimaryKeyOperation.Columns.Select(Quote).Join());
		indentedTextWriter.Write(")");
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.DropPrimaryKeyOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="dropPrimaryKeyOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(DropPrimaryKeyOperation dropPrimaryKeyOperation)
	{
		RuntimeFailureMethods.Requires(dropPrimaryKeyOperation != null, null, "dropPrimaryKeyOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("ALTER TABLE ");
		indentedTextWriter.Write(Name(dropPrimaryKeyOperation.Table));
		indentedTextWriter.Write(" DROP CONSTRAINT ");
		indentedTextWriter.Write(Quote(dropPrimaryKeyOperation.Name));
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.AddColumnOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="addColumnOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(AddColumnOperation addColumnOperation)
	{
		RuntimeFailureMethods.Requires(addColumnOperation != null, null, "addColumnOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("ALTER TABLE ");
		indentedTextWriter.Write(Name(addColumnOperation.Table));
		indentedTextWriter.Write(" ADD ");
		ColumnModel column = addColumnOperation.Column;
		Generate(column, indentedTextWriter);
		if (column.IsNullable.HasValue && !column.IsNullable.Value && column.DefaultValue == null && string.IsNullOrWhiteSpace(column.DefaultValueSql) && !column.IsIdentity)
		{
			indentedTextWriter.Write(" DEFAULT ");
			indentedTextWriter.Write(Generate((dynamic)column.ClrDefaultValue));
		}
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.DropColumnOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="dropColumnOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(DropColumnOperation dropColumnOperation)
	{
		RuntimeFailureMethods.Requires(dropColumnOperation != null, null, "dropColumnOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		string value = "@var" + _variableCounter++;
		indentedTextWriter.Write("DECLARE ");
		indentedTextWriter.Write(value);
		indentedTextWriter.WriteLine(" nvarchar(128)");
		indentedTextWriter.Write("SELECT ");
		indentedTextWriter.Write(value);
		indentedTextWriter.WriteLine(" = name");
		indentedTextWriter.WriteLine("FROM sys.default_constraints");
		indentedTextWriter.Write("WHERE parent_object_id = object_id(N'");
		indentedTextWriter.Write(dropColumnOperation.Table);
		indentedTextWriter.WriteLine("')");
		indentedTextWriter.Write("AND col_name(parent_object_id, parent_column_id) = '");
		indentedTextWriter.Write(dropColumnOperation.Name);
		indentedTextWriter.WriteLine("';");
		indentedTextWriter.Write("IF ");
		indentedTextWriter.Write(value);
		indentedTextWriter.WriteLine(" IS NOT NULL");
		indentedTextWriter.Indent++;
		indentedTextWriter.Write("EXECUTE('ALTER TABLE ");
		indentedTextWriter.Write(Name(dropColumnOperation.Table));
		indentedTextWriter.Write(" DROP CONSTRAINT ' + ");
		indentedTextWriter.Write(value);
		indentedTextWriter.WriteLine(")");
		indentedTextWriter.Indent--;
		indentedTextWriter.Write("ALTER TABLE ");
		indentedTextWriter.Write(Name(dropColumnOperation.Table));
		indentedTextWriter.Write(" DROP COLUMN ");
		indentedTextWriter.Write(Quote(dropColumnOperation.Name));
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.AlterColumnOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="alterColumnOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(AlterColumnOperation alterColumnOperation)
	{
		RuntimeFailureMethods.Requires(alterColumnOperation != null, null, "alterColumnOperation != null");
		ColumnModel column = alterColumnOperation.Column;
		if (column.DefaultValue != null || !string.IsNullOrWhiteSpace(column.DefaultValueSql))
		{
			using IndentedTextWriter indentedTextWriter = Writer();
			indentedTextWriter.Write("ALTER TABLE ");
			indentedTextWriter.Write(Name(alterColumnOperation.Table));
			indentedTextWriter.Write(" ADD CONSTRAINT DF_");
			indentedTextWriter.Write(column.Name);
			indentedTextWriter.Write(" DEFAULT ");
			indentedTextWriter.Write((column.DefaultValue != null) ? Generate((dynamic)column.DefaultValue) : column.DefaultValueSql);
			indentedTextWriter.Write(" FOR ");
			indentedTextWriter.Write(Quote(column.Name));
			Statement(indentedTextWriter);
		}
		using IndentedTextWriter indentedTextWriter2 = Writer();
		indentedTextWriter2.Write("ALTER TABLE ");
		indentedTextWriter2.Write(Name(alterColumnOperation.Table));
		indentedTextWriter2.Write(" ALTER COLUMN ");
		indentedTextWriter2.Write(Quote(column.Name));
		indentedTextWriter2.Write(" ");
		indentedTextWriter2.Write(BuildColumnType(column));
		if (column.IsNullable.HasValue && !column.IsNullable.Value)
		{
			indentedTextWriter2.Write(" NOT NULL");
		}
		Statement(indentedTextWriter2);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.DropTableOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="dropTableOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(DropTableOperation dropTableOperation)
	{
		RuntimeFailureMethods.Requires(dropTableOperation != null, null, "dropTableOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("DROP TABLE ");
		indentedTextWriter.Write(Name(dropTableOperation.Name));
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.SqlOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="sqlOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(SqlOperation sqlOperation)
	{
		RuntimeFailureMethods.Requires(sqlOperation != null, null, "sqlOperation != null");
		Statement(sqlOperation.Sql, sqlOperation.SuppressTransaction);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.RenameColumnOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="renameColumnOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(RenameColumnOperation renameColumnOperation)
	{
		RuntimeFailureMethods.Requires(renameColumnOperation != null, null, "renameColumnOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("EXECUTE sp_rename @objname = N'");
		indentedTextWriter.Write(renameColumnOperation.Table);
		indentedTextWriter.Write(".");
		indentedTextWriter.Write(renameColumnOperation.Name);
		indentedTextWriter.Write("', @newname = N'");
		indentedTextWriter.Write(renameColumnOperation.NewName);
		indentedTextWriter.Write("', @objtype = N'COLUMN'");
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.RenameTableOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="renameTableOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(RenameTableOperation renameTableOperation)
	{
		RuntimeFailureMethods.Requires(renameTableOperation != null, null, "renameTableOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("EXECUTE sp_rename @objname = N'");
		indentedTextWriter.Write(renameTableOperation.Name);
		indentedTextWriter.Write("', @newname = N'");
		indentedTextWriter.Write(renameTableOperation.NewName);
		indentedTextWriter.Write("', @objtype = N'OBJECT'");
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.MoveTableOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="moveTableOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(MoveTableOperation moveTableOperation)
	{
		RuntimeFailureMethods.Requires(moveTableOperation != null, null, "moveTableOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		string text = moveTableOperation.NewSchema ?? "dbo";
		if (!text.EqualsIgnoreCase("dbo") && !_generatedSchemas.Contains(text))
		{
			GenerateCreateSchema(text);
			_generatedSchemas.Add(text);
		}
		indentedTextWriter.Write("ALTER SCHEMA ");
		indentedTextWriter.Write(Quote(text));
		indentedTextWriter.Write(" TRANSFER ");
		indentedTextWriter.Write(Name(moveTableOperation.Name));
		Statement(indentedTextWriter);
	}

	private void Generate(ColumnModel column, IndentedTextWriter writer)
	{
		writer.Write(Quote(column.Name));
		writer.Write(" ");
		writer.Write(BuildColumnType(column));
		if (column.IsNullable.HasValue && !column.IsNullable.Value)
		{
			writer.Write(" NOT NULL");
		}
		if (column.DefaultValue != null)
		{
			writer.Write(" DEFAULT ");
			writer.Write(Generate((dynamic)column.DefaultValue));
		}
		else if (!string.IsNullOrWhiteSpace(column.DefaultValueSql))
		{
			writer.Write(" DEFAULT ");
			writer.Write(column.DefaultValueSql);
		}
		else if (column.IsIdentity)
		{
			if (column.Type == PrimitiveTypeKind.Guid && column.DefaultValue == null)
			{
				writer.Write(" DEFAULT newid()");
			}
			else
			{
				writer.Write(" IDENTITY");
			}
		}
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.InsertHistoryOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="insertHistoryOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(InsertHistoryOperation insertHistoryOperation)
	{
		RuntimeFailureMethods.Requires(insertHistoryOperation != null, null, "insertHistoryOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("INSERT INTO ");
		indentedTextWriter.Write(Name(insertHistoryOperation.Table));
		indentedTextWriter.Write(" ([MigrationId], [CreatedOn], [Model], [ProductVersion])");
		indentedTextWriter.Write(" VALUES (");
		indentedTextWriter.Write(Generate(insertHistoryOperation.MigrationId));
		indentedTextWriter.Write(", ");
		indentedTextWriter.Write(Generate(insertHistoryOperation.CreatedOn));
		indentedTextWriter.Write(", ");
		indentedTextWriter.Write(Generate(insertHistoryOperation.Model));
		indentedTextWriter.Write(", ");
		indentedTextWriter.Write(Generate(insertHistoryOperation.ProductVersion));
		indentedTextWriter.Write(")");
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL for a <see cref="T:System.Data.Entity.Migrations.Model.DeleteHistoryOperation" />.
	/// Generated SQL should be added using the Statement method.
	/// </summary>
	/// <param name="deleteHistoryOperation">The operation to produce SQL for.</param>
	protected virtual void Generate(DeleteHistoryOperation deleteHistoryOperation)
	{
		RuntimeFailureMethods.Requires(deleteHistoryOperation != null, null, "deleteHistoryOperation != null");
		using IndentedTextWriter indentedTextWriter = Writer();
		indentedTextWriter.Write("DELETE FROM ");
		indentedTextWriter.Write(Name(deleteHistoryOperation.Table));
		indentedTextWriter.Write(" WHERE [MigrationId] = ");
		indentedTextWriter.Write(Generate(deleteHistoryOperation.MigrationId));
		Statement(indentedTextWriter);
	}

	/// <summary>
	/// Generates SQL to specify a constant byte[] default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(byte[] defaultValue)
	{
		RuntimeFailureMethods.Requires(defaultValue != null, null, "defaultValue != null");
		return "0x" + defaultValue.ToHexString();
	}

	/// <summary>
	/// Generates SQL to specify a constant bool default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(bool defaultValue)
	{
		if (!defaultValue)
		{
			return "0";
		}
		return "1";
	}

	/// <summary>
	/// Generates SQL to specify a constant DateTime default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(DateTime defaultValue)
	{
		return "'" + defaultValue.ToString("yyyy-MM-ddTHH:mm:ss.fffK") + "'";
	}

	/// <summary>
	/// Generates SQL to specify a constant DateTimeOffset default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(DateTimeOffset defaultValue)
	{
		return "'" + defaultValue.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz") + "'";
	}

	/// <summary>
	/// Generates SQL to specify a constant Guid default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(Guid defaultValue)
	{
		return string.Concat("'", defaultValue, "'");
	}

	/// <summary>
	/// Generates SQL to specify a constant string default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(string defaultValue)
	{
		return "'" + defaultValue + "'";
	}

	/// <summary>
	/// Generates SQL to specify a constant TimeSpan default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(TimeSpan defaultValue)
	{
		return string.Concat("'", defaultValue, "'");
	}

	/// <summary>
	/// Generates SQL to specify a constant default value being set on a column.
	/// This method just generates the actual value, not the SQL to set the default value.
	/// </summary>
	/// <param name="defaultValue">The value to be set.</param>
	/// <returns>SQL representing the default value.</returns>
	protected virtual string Generate(object defaultValue)
	{
		return defaultValue.ToString();
	}

	/// <summary>
	/// Generates SQL to specify the data type of a column.
	/// This method just generates the actual type, not the SQL to create the column.
	/// </summary>
	/// <param name="defaultValue">The definition of the column.</param>
	/// <returns>SQL representing the data type.</returns>
	protected virtual string BuildColumnType(ColumnModel column)
	{
		RuntimeFailureMethods.Requires(column != null, null, "column != null");
		if (column.IsTimestamp)
		{
			return "rowversion";
		}
		string text = column.StoreType;
		if (string.IsNullOrWhiteSpace(text))
		{
			EdmType edmType = _providerManifest.GetStoreType(column.TypeUsage).EdmType;
			text = edmType.Name;
		}
		string text2 = text;
		text2 = ((!text2.EndsWith("(max)", StringComparison.Ordinal)) ? Quote(text2) : (Quote(text2.Substring(0, text2.Length - "(max)".Length)) + "(max)"));
		switch (text)
		{
		case "decimal":
		case "numeric":
		{
			object obj3 = text2;
			text2 = string.Concat(obj3, "(", column.Precision ?? 18, ", ", column.Scale ?? 0, ")");
			break;
		}
		case "datetime2":
		case "datetimeoffset":
		case "time":
		{
			object obj2 = text2;
			text2 = string.Concat(obj2, "(", column.Precision ?? 7, ")");
			break;
		}
		case "binary":
		case "varbinary":
		case "nvarchar":
		case "varchar":
		case "char":
		case "nchar":
		{
			object obj = text2;
			text2 = string.Concat(obj, "(", column.MaxLength ?? 128, ")");
			break;
		}
		}
		return text2;
	}

	/// <summary>
	/// Generates a quoted name. The supplied name may or may not contain the schema.
	/// </summary>
	/// <param name="name">The name to be quoted.</param>
	/// <returns>The quoted name.</returns>
	protected virtual string Name(string name)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		string[] ts = name.Split(new char[1] { '.' }, 2);
		return ts.Join(Quote, ".");
	}

	/// <summary>
	/// Quotes an identifier for SQL Server.
	/// </summary>
	/// <param name="identifier">The identifier to be quoted.</param>
	/// <returns>The quoted identifier.</returns>
	protected virtual string Quote(string identifier)
	{
		return "[" + identifier + "]";
	}

	/// <summary>
	/// Adds a new Statement to be executed against the database.
	/// </summary>
	/// <param name="sql">The statement to be executed.</param>
	/// <param name="suppressTransaction">
	/// Gets or sets a value indicating whether this statement should be performed outside of
	/// the transaction scope that is used to make the migration process transactional.
	/// If set to true, this operation will not be rolled back if the migration process fails.
	/// </param>
	protected void Statement(string sql, bool suppressTransaction = false)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(sql), null, "!string.IsNullOrWhiteSpace(sql)");
		_statements.Add(new MigrationStatement
		{
			Sql = sql,
			SuppressTransaction = suppressTransaction
		});
	}

	/// <summary>
	/// Gets a new <see cref="T:System.Data.Entity.Migrations.Utilities.IndentedTextWriter" /> that can be used to build SQL.
	///
	/// This is just a helper method to create a writer. Writing to the writer will
	/// not cause SQL to be registered for execution. You must pass the generated
	/// SQL to the Statement method.
	/// </summary>
	/// <returns>An empty text writer to use for SQL generation.</returns>
	[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
	protected static IndentedTextWriter Writer()
	{
		return new IndentedTextWriter(new StringWriter());
	}

	/// <summary>
	/// Adds a new Statement to be executed against the database.
	/// </summary>
	/// <param name="writer">The writer containing the SQL to be executed.</param>
	protected void Statement(IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		Statement(writer.InnerWriter.ToString());
	}
}
