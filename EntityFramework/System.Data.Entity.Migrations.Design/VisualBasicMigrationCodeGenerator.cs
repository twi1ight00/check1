using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Metadata.Edm;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace System.Data.Entity.Migrations.Design;

/// <summary>
/// Generates VB.Net code for a code-based migration.
/// </summary>
public class VisualBasicMigrationCodeGenerator : MigrationCodeGenerator
{
	private IEnumerable<Tuple<CreateTableOperation, AddForeignKeyOperation>> _newTableForeignKeys;

	private IEnumerable<Tuple<CreateTableOperation, CreateIndexOperation>> _newTableIndexes;

	/// <inheritdoc />
	public override ScaffoldedMigration Generate(string migrationId, IEnumerable<MigrationOperation> operations, string sourceModel, string targetModel, string @namespace, string className)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(migrationId), null, "!string.IsNullOrWhiteSpace(migrationId)");
		RuntimeFailureMethods.Requires(operations != null, null, "operations != null");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(targetModel), null, "!string.IsNullOrWhiteSpace(targetModel)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(className), null, "!string.IsNullOrWhiteSpace(className)");
		IEnumerable<MigrationOperation> operations2 = operations;
		_newTableForeignKeys = (from ct in operations2.OfType<CreateTableOperation>()
			from cfk in operations2.OfType<AddForeignKeyOperation>()
			where ct.Name.EqualsIgnoreCase(cfk.DependentTable)
			select Tuple.Create(ct, cfk)).ToList();
		_newTableIndexes = (from ct in operations2.OfType<CreateTableOperation>()
			from cfk in operations2.OfType<CreateIndexOperation>()
			where ct.Name.EqualsIgnoreCase(cfk.Table)
			select Tuple.Create(ct, cfk)).ToList();
		ScaffoldedMigration scaffoldedMigration = new ScaffoldedMigration();
		scaffoldedMigration.Language = "vb";
		scaffoldedMigration.UserCode = Generate(operations2, @namespace, className);
		scaffoldedMigration.DesignerCode = Generate(migrationId, sourceModel, targetModel, @namespace, className);
		return scaffoldedMigration;
	}

	/// <summary>
	/// Generates the primary code file that the user can view and edit.
	/// </summary>
	/// <param name="operations">Operations to be performed by the migration.</param>
	/// <param name="namespace">Namespace that code should be generated in.</param>
	/// <param name="className">Name of the class that should be generated.</param>
	/// <returns>The generated code.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
	protected virtual string Generate(IEnumerable<MigrationOperation> operations, string @namespace, string className)
	{
		RuntimeFailureMethods.Requires(operations != null, null, "operations != null");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(className), null, "!string.IsNullOrWhiteSpace(className)");
		using StringWriter stringWriter = new StringWriter();
		IndentedTextWriter writer = new IndentedTextWriter(stringWriter, "    ");
		try
		{
			WriteClassStart(@namespace, className, writer, "Inherits DbMigration");
			writer.WriteLine("Public Overrides Sub Up()");
			writer.Indent++;
			System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(operations.Except(_newTableForeignKeys.Select((Tuple<CreateTableOperation, AddForeignKeyOperation> t) => t.Item2)).Except(_newTableIndexes.Select((Tuple<CreateTableOperation, CreateIndexOperation> t) => t.Item2)), delegate(dynamic o)
			{
				Generate(o, writer);
			});
			writer.Indent--;
			writer.WriteLine("End Sub");
			writer.WriteLine();
			writer.WriteLine("Public Overrides Sub Down()");
			writer.Indent++;
			System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each((from o in operations
				select o.Inverse into o
				where o != null
				select o).Reverse(), delegate(dynamic o)
			{
				Generate(o, writer);
			});
			writer.Indent--;
			writer.WriteLine("End Sub");
			WriteClassEnd(@namespace, writer);
		}
		finally
		{
			if (writer != null)
			{
				((IDisposable)writer).Dispose();
			}
		}
		return stringWriter.ToString();
	}

	/// <summary>
	/// Generates the code behind file with migration metadata.
	/// </summary>
	/// <param name="migrationId">Unique identifier of the migration.</param>
	/// <param name="sourceModel">Source model to be stored in the migration metadata.</param>
	/// <param name="targetModel">Target model to be stored in the migration metadata.</param>
	/// <param name="namespace">Namespace that code should be generated in.</param>
	/// <param name="className">Name of the class that should be generated.</param>
	/// <returns>The generated code.</returns>
	[SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
	protected virtual string Generate(string migrationId, string sourceModel, string targetModel, string @namespace, string className)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(migrationId), null, "!string.IsNullOrWhiteSpace(migrationId)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(targetModel), null, "!string.IsNullOrWhiteSpace(targetModel)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(className), null, "!string.IsNullOrWhiteSpace(className)");
		using StringWriter stringWriter = new StringWriter();
		using (IndentedTextWriter indentedTextWriter = new IndentedTextWriter(stringWriter, "    "))
		{
			indentedTextWriter.WriteLine("' <auto-generated />");
			bool designer = true;
			WriteClassStart(@namespace, className, indentedTextWriter, "Implements IMigrationMetadata", designer);
			WriteProperty("Id", migrationId, indentedTextWriter);
			indentedTextWriter.WriteLine();
			WriteProperty("Source", sourceModel, indentedTextWriter);
			indentedTextWriter.WriteLine();
			WriteProperty("Target", targetModel, indentedTextWriter);
			WriteClassEnd(@namespace, indentedTextWriter);
		}
		return stringWriter.ToString();
	}

	/// <summary>
	/// Generates a property to return the source or target model in the code behind file.
	/// </summary>
	/// <param name="name">Name of the property.</param>
	/// <param name="model">Model to be returned.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void WriteProperty(string name, string model, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(name), null, "!string.IsNullOrWhiteSpace(name)");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("Private ReadOnly Property IMigrationMetadata_");
		writer.Write(name);
		writer.Write("() As String Implements IMigrationMetadata.");
		writer.WriteLine(name);
		writer.Indent++;
		writer.WriteLine("Get");
		writer.Indent++;
		writer.Write("Return ");
		if (model == null)
		{
			writer.WriteLine("Nothing");
		}
		else
		{
			writer.Write("\"");
			writer.Write(model);
			writer.WriteLine("\"");
		}
		writer.Indent--;
		writer.WriteLine("End Get");
		writer.Indent--;
		writer.WriteLine("End Property");
	}

	/// <summary>
	/// Generates a namespace, using statements and class definition.
	/// </summary>
	/// <param name="namespace">Namespace that code should be generated in.</param>
	/// <param name="className">Name of the class that should be generated.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	/// <param name="base">Base class for the generated class.</param>
	/// <param name="designer">A value indicating if this class is being generated for a code-behind file.</param>
	protected virtual void WriteClassStart(string @namespace, string className, IndentedTextWriter writer, string @base, bool designer = false)
	{
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(className), null, "!string.IsNullOrWhiteSpace(className)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(@base), null, "!string.IsNullOrWhiteSpace(@base)");
		writer.WriteLine("Imports System.Data.Entity.Migrations");
		if (designer)
		{
			writer.WriteLine("Imports System.Data.Entity.Migrations.Infrastructure");
		}
		writer.WriteLine();
		if (!string.IsNullOrWhiteSpace(@namespace))
		{
			writer.Write("Namespace ");
			writer.WriteLine(@namespace);
			writer.Indent++;
		}
		writer.Write("Public ");
		if (designer)
		{
			writer.Write("NotInheritable ");
		}
		writer.Write("Partial Class ");
		writer.Write(ScrubName(className));
		writer.WriteLine();
		writer.Indent++;
		writer.WriteLine(@base);
		writer.Indent--;
		writer.WriteLine();
		writer.Indent++;
	}

	/// <summary>
	/// Generates the closing code for a class that was started with WriteClassStart.
	/// </summary>
	/// <param name="namespace">Namespace that code should be generated in.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void WriteClassEnd(string @namespace, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Indent--;
		writer.WriteLine("End Class");
		if (!string.IsNullOrWhiteSpace(@namespace))
		{
			writer.Indent--;
			writer.WriteLine("End Namespace");
		}
	}

	/// <summary>
	/// Generates code to perform an <see cref="T:System.Data.Entity.Migrations.Model.AddColumnOperation" />.
	/// </summary>
	/// <param name="addColumnOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(AddColumnOperation addColumnOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(addColumnOperation != null, null, "addColumnOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("AddColumn(");
		writer.Write(Quote(addColumnOperation.Table));
		writer.Write(", ");
		writer.Write(Quote(addColumnOperation.Column.Name));
		writer.Write(", Function(c)");
		Generate(addColumnOperation.Column, writer);
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.DropColumnOperation" />.
	/// </summary>
	/// <param name="dropColumnOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(DropColumnOperation dropColumnOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(dropColumnOperation != null, null, "dropColumnOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("DropColumn(");
		writer.Write(Quote(dropColumnOperation.Table));
		writer.Write(", ");
		writer.Write(Quote(dropColumnOperation.Name));
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform an <see cref="T:System.Data.Entity.Migrations.Model.AlterColumnOperation" />.
	/// </summary>
	/// <param name="alterColumnOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(AlterColumnOperation alterColumnOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(alterColumnOperation != null, null, "alterColumnOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("AlterColumn(");
		writer.Write(Quote(alterColumnOperation.Table));
		writer.Write(", ");
		writer.Write(Quote(alterColumnOperation.Column.Name));
		writer.Write(", Function(c)");
		Generate(alterColumnOperation.Column, writer);
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.CreateTableOperation" />.
	/// </summary>
	/// <param name="createTableOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(CreateTableOperation createTableOperation, IndentedTextWriter writer)
	{
		CreateTableOperation createTableOperation3 = createTableOperation;
		IndentedTextWriter writer3 = writer;
		RuntimeFailureMethods.Requires(createTableOperation3 != null, null, "createTableOperation != null");
		RuntimeFailureMethods.Requires(writer3 != null, null, "writer != null");
		CreateTableOperation createTableOperation2 = createTableOperation;
		IndentedTextWriter writer2 = writer;
		writer2.WriteLine("CreateTable(");
		writer2.Indent++;
		writer2.WriteLine(Quote(createTableOperation2.Name) + ",");
		writer2.WriteLine("Function(c) New With");
		writer2.Indent++;
		writer2.WriteLine("{");
		writer2.Indent++;
		int columnCount = createTableOperation2.Columns.Count();
		System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(createTableOperation2.Columns, delegate(ColumnModel c, int i)
		{
			string text = ScrubName(c.Name);
			writer2.Write(".");
			writer2.Write(text);
			writer2.Write(" =");
			Generate(c, writer2, !string.Equals(c.Name, text, StringComparison.Ordinal));
			if (i < columnCount - 1)
			{
				writer2.Write(",");
			}
			writer2.WriteLine();
		});
		writer2.Indent--;
		writer2.Write("}");
		writer2.Indent--;
		writer2.Write(")");
		GenerateInline(createTableOperation2.PrimaryKey, writer2);
		System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(_newTableForeignKeys.Where((Tuple<CreateTableOperation, AddForeignKeyOperation> t) => t.Item1 == createTableOperation2), delegate(Tuple<CreateTableOperation, AddForeignKeyOperation> t)
		{
			GenerateInline(t.Item2, writer2);
		});
		System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(_newTableIndexes.Where((Tuple<CreateTableOperation, CreateIndexOperation> t) => t.Item1 == createTableOperation2), delegate(Tuple<CreateTableOperation, CreateIndexOperation> t)
		{
			GenerateInline(t.Item2, writer2);
		});
		writer2.WriteLine();
		writer2.Indent--;
		writer2.WriteLine();
	}

	/// <summary>
	/// Generates code to perform an <see cref="T:System.Data.Entity.Migrations.Model.AddPrimaryKeyOperation" /> as part of a <see cref="T:System.Data.Entity.Migrations.Model.CreateTableOperation" />.
	/// </summary>
	/// <param name="addPrimaryKeyOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void GenerateInline(AddPrimaryKeyOperation addPrimaryKeyOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		if (addPrimaryKeyOperation != null)
		{
			writer.WriteLine(" _");
			writer.Write(".PrimaryKey(");
			Generate(addPrimaryKeyOperation.Columns, writer);
			if (!addPrimaryKeyOperation.HasDefaultName)
			{
				writer.Write(", name := ");
				writer.Write(Quote(addPrimaryKeyOperation.Name));
			}
			writer.Write(")");
		}
	}

	/// <summary>
	/// Generates code to perform an <see cref="T:System.Data.Entity.Migrations.Model.AddForeignKeyOperation" /> as part of a <see cref="T:System.Data.Entity.Migrations.Model.CreateTableOperation" />.
	/// </summary>
	/// <param name="addForeignKeyOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void GenerateInline(AddForeignKeyOperation addForeignKeyOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(addForeignKeyOperation != null, null, "addForeignKeyOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.WriteLine(" _");
		writer.Write(".ForeignKey(" + Quote(addForeignKeyOperation.PrincipalTable) + ", ");
		Generate(addForeignKeyOperation.DependentColumns, writer);
		if (addForeignKeyOperation.CascadeDelete)
		{
			writer.Write(", cascadeDelete := True");
		}
		writer.Write(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.CreateIndexOperation" /> as part of a <see cref="T:System.Data.Entity.Migrations.Model.CreateTableOperation" />.
	/// </summary>
	/// <param name="createIndexOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void GenerateInline(CreateIndexOperation createIndexOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(createIndexOperation != null, null, "createIndexOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.WriteLine(" _");
		writer.Write(".Index(");
		Generate(createIndexOperation.Columns, writer);
		writer.Write(")");
	}

	/// <summary>
	/// Generates code to specify a set of column names using a lambda expression.
	/// </summary>
	/// <param name="columns">The columns to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(IEnumerable<string> columns, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(columns != null, null, "columns != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("Function(t) ");
		if (columns.Count() == 1)
		{
			writer.Write("t." + columns.Single());
			return;
		}
		writer.Write("New With { " + columns.Join((string c) => "t." + c) + " }");
	}

	/// <summary>
	/// Generates code to perform an <see cref="T:System.Data.Entity.Migrations.Model.AddForeignKeyOperation" />.
	/// </summary>
	/// <param name="addForeignKeyOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(AddForeignKeyOperation addForeignKeyOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(addForeignKeyOperation != null, null, "addForeignKeyOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("AddForeignKey(");
		writer.Write(Quote(addForeignKeyOperation.DependentTable));
		writer.Write(", ");
		bool flag = addForeignKeyOperation.DependentColumns.Count() > 1;
		if (flag)
		{
			writer.Write("New String() { ");
		}
		writer.Write(addForeignKeyOperation.DependentColumns.Join(Quote));
		if (flag)
		{
			writer.Write(" }");
		}
		writer.Write(", ");
		writer.Write(Quote(addForeignKeyOperation.PrincipalTable));
		if (addForeignKeyOperation.PrincipalColumns.Any())
		{
			writer.Write(", ");
			if (flag)
			{
				writer.Write("New String() { ");
			}
			writer.Write(addForeignKeyOperation.PrincipalColumns.Join(Quote));
			if (flag)
			{
				writer.Write(" }");
			}
		}
		if (addForeignKeyOperation.CascadeDelete)
		{
			writer.Write(", cascadeDelete := True");
		}
		if (!addForeignKeyOperation.HasDefaultName)
		{
			writer.Write(", name := ");
			writer.Write(Quote(addForeignKeyOperation.Name));
		}
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.DropForeignKeyOperation" />.
	/// </summary>
	/// <param name="dropForeignKeyOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(DropForeignKeyOperation dropForeignKeyOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(dropForeignKeyOperation != null, null, "dropForeignKeyOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("DropForeignKey(");
		writer.Write(Quote(dropForeignKeyOperation.DependentTable));
		writer.Write(", ");
		if (!dropForeignKeyOperation.HasDefaultName)
		{
			writer.Write(Quote(dropForeignKeyOperation.Name));
		}
		else
		{
			bool flag = dropForeignKeyOperation.DependentColumns.Count() > 1;
			if (flag)
			{
				writer.Write("New String() { ");
			}
			writer.Write(dropForeignKeyOperation.DependentColumns.Join(Quote));
			if (flag)
			{
				writer.Write(" }");
			}
			writer.Write(", ");
			writer.Write(Quote(dropForeignKeyOperation.PrincipalTable));
		}
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform an <see cref="T:System.Data.Entity.Migrations.Model.AddPrimaryKeyOperation" />.
	/// </summary>
	/// <param name="addPrimaryKeyOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(AddPrimaryKeyOperation addPrimaryKeyOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(addPrimaryKeyOperation != null, null, "addPrimaryKeyOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("AddPrimaryKey(");
		writer.Write(Quote(addPrimaryKeyOperation.Table));
		writer.Write(", ");
		bool flag = addPrimaryKeyOperation.Columns.Count() > 1;
		if (flag)
		{
			writer.Write("New String() { ");
		}
		writer.Write(addPrimaryKeyOperation.Columns.Join(Quote));
		if (flag)
		{
			writer.Write(" }");
		}
		if (!addPrimaryKeyOperation.HasDefaultName)
		{
			writer.Write(", name := ");
			writer.Write(Quote(addPrimaryKeyOperation.Name));
		}
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.DropPrimaryKeyOperation" />.
	/// </summary>
	/// <param name="dropPrimaryKeyOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(DropPrimaryKeyOperation dropPrimaryKeyOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(dropPrimaryKeyOperation != null, null, "dropPrimaryKeyOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("DropPrimaryKey(");
		writer.Write(Quote(dropPrimaryKeyOperation.Table));
		writer.Write(", ");
		if (!dropPrimaryKeyOperation.HasDefaultName)
		{
			writer.Write(Quote(dropPrimaryKeyOperation.Name));
		}
		else
		{
			writer.Write("New String() { ");
			writer.Write(dropPrimaryKeyOperation.Columns.Join(Quote));
			writer.Write(" }");
		}
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.CreateIndexOperation" />.
	/// </summary>
	/// <param name="createIndexOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(CreateIndexOperation createIndexOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(createIndexOperation != null, null, "createIndexOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("CreateIndex(");
		writer.Write(Quote(createIndexOperation.Table));
		writer.Write(", ");
		bool flag = createIndexOperation.Columns.Count() > 1;
		if (flag)
		{
			writer.Write("New String() { ");
		}
		writer.Write(createIndexOperation.Columns.Join(Quote));
		if (flag)
		{
			writer.Write(" }");
		}
		if (createIndexOperation.IsUnique)
		{
			writer.Write(", unique := True");
		}
		if (!createIndexOperation.HasDefaultName)
		{
			writer.Write(", name := ");
			writer.Write(Quote(createIndexOperation.Name));
		}
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.DropIndexOperation" />.
	/// </summary>
	/// <param name="dropIndexOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(DropIndexOperation dropIndexOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(dropIndexOperation != null, null, "dropIndexOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("DropIndex(");
		writer.Write(Quote(dropIndexOperation.Table));
		writer.Write(", ");
		if (!dropIndexOperation.HasDefaultName)
		{
			writer.Write(Quote(dropIndexOperation.Name));
		}
		else
		{
			writer.Write("New String() { ");
			writer.Write(dropIndexOperation.Columns.Join(Quote));
			writer.Write(" }");
		}
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to specify the definition for a <see cref="T:System.Data.Entity.Migrations.Model.ColumnModel" />.
	/// </summary>
	/// <param name="column">The column definition to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	/// <param name="emitName">A value indicating whether to include the column name in the definition.</param>
	protected virtual void Generate(ColumnModel column, IndentedTextWriter writer, bool emitName = false)
	{
		RuntimeFailureMethods.Requires(column != null, null, "column != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write(" c.");
		writer.Write(TranslateColumnType(column.Type));
		writer.Write("(");
		List<string> list = new List<string>();
		if (emitName)
		{
			list.Add("name := " + Quote(column.Name));
		}
		if (column.IsNullable == false)
		{
			list.Add("nullable := False");
		}
		if (column.MaxLength.HasValue)
		{
			list.Add("maxLength := " + column.MaxLength);
		}
		if (((int?)column.Precision).HasValue)
		{
			list.Add("precision := " + column.Precision);
		}
		if (((int?)column.Scale).HasValue)
		{
			list.Add("scale := " + column.Scale);
		}
		if (column.IsFixedLength.HasValue)
		{
			list.Add("fixedLength := " + column.IsFixedLength.ToString().ToLowerInvariant());
		}
		if (column.IsUnicode.HasValue)
		{
			list.Add("unicode := " + column.IsUnicode.ToString().ToLowerInvariant());
		}
		if (column.IsIdentity)
		{
			list.Add("identity := True");
		}
		if (column.DefaultValue != null)
		{
			list.Add("defaultValue := " + Generate((dynamic)column.DefaultValue));
		}
		if (!string.IsNullOrWhiteSpace(column.DefaultValueSql))
		{
			list.Add("defaultValueSql := " + Quote(column.DefaultValueSql));
		}
		if (column.IsTimestamp)
		{
			list.Add("timestamp := True");
		}
		if (!string.IsNullOrWhiteSpace(column.StoreType))
		{
			list.Add("storeType := " + Quote(column.StoreType));
		}
		writer.Write(list.Join());
		writer.Write(")");
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:byte[]" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(byte[] defaultValue)
	{
		return "New Byte() {" + defaultValue.Join() + "}";
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.DateTime" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(DateTime defaultValue)
	{
		return "New DateTime(" + defaultValue.Ticks + ", DateTimeKind." + Enum.GetName(typeof(DateTimeKind), defaultValue.Kind) + ")";
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.DateTimeOffset" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(DateTimeOffset defaultValue)
	{
		return "New DateTimeOffset(" + defaultValue.Ticks + ", new TimeSpan(" + defaultValue.Offset.Ticks + "))";
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.Byte" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(byte defaultValue)
	{
		return defaultValue.ToString();
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.Decimal" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(decimal defaultValue)
	{
		return defaultValue + "D";
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.Guid" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(Guid defaultValue)
	{
		return string.Concat("New Guid(\"", defaultValue, "\")");
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.Int64" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(long defaultValue)
	{
		return defaultValue.ToString();
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.Single" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(float defaultValue)
	{
		return defaultValue + "F";
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.String" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(string defaultValue)
	{
		return Quote(defaultValue);
	}

	/// <summary>
	/// Generates code to specify the default value for a <see cref="T:System.TimeSpan" /> column.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(TimeSpan defaultValue)
	{
		return "New TimeSpan(" + defaultValue.Ticks + ")";
	}

	/// <summary>
	/// Generates code to specify the default value for a column of unknown data type.
	/// </summary>
	/// <param name="defaultValue">The value to be used as the default.</param>
	/// <returns>Code representing the default value.</returns>
	protected virtual string Generate(object defaultValue)
	{
		return defaultValue.ToString().ToLowerInvariant();
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.DropTableOperation" />.
	/// </summary>
	/// <param name="dropTableOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(DropTableOperation dropTableOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(dropTableOperation != null, null, "dropTableOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("DropTable(");
		writer.Write(Quote(dropTableOperation.Name));
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.MoveTableOperation" />.
	/// </summary>
	/// <param name="moveTableOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(MoveTableOperation moveTableOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(moveTableOperation != null, null, "moveTableOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("MoveTable(name := ");
		writer.Write(Quote(moveTableOperation.Name));
		writer.Write(", newSchema := ");
		writer.Write(string.IsNullOrWhiteSpace(moveTableOperation.NewSchema) ? "Nothing" : Quote(moveTableOperation.NewSchema));
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.RenameTableOperation" />.
	/// </summary>
	/// <param name="renameTableOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(RenameTableOperation renameTableOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(renameTableOperation != null, null, "renameTableOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("RenameTable(name := ");
		writer.Write(Quote(renameTableOperation.Name));
		writer.Write(", newName := ");
		writer.Write(Quote(renameTableOperation.NewName));
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.RenameColumnOperation" />.
	/// </summary>
	/// <param name="renameColumnOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(RenameColumnOperation renameColumnOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(renameColumnOperation != null, null, "renameColumnOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("RenameColumn(table := ");
		writer.Write(Quote(renameColumnOperation.Table));
		writer.Write(", name := ");
		writer.Write(Quote(renameColumnOperation.Name));
		writer.Write(", newName := ");
		writer.Write(Quote(renameColumnOperation.NewName));
		writer.WriteLine(")");
	}

	/// <summary>
	/// Generates code to perform a <see cref="T:System.Data.Entity.Migrations.Model.SqlOperation" />.
	/// </summary>
	/// <param name="sqlOperation">The operation to generate code for.</param>
	/// <param name="writer">Text writer to add the generated code to.</param>
	protected virtual void Generate(SqlOperation sqlOperation, IndentedTextWriter writer)
	{
		RuntimeFailureMethods.Requires(sqlOperation != null, null, "sqlOperation != null");
		RuntimeFailureMethods.Requires(writer != null, null, "writer != null");
		writer.Write("Sql(");
		writer.Write(Quote(sqlOperation.Sql));
		if (sqlOperation.SuppressTransaction)
		{
			writer.Write(", suppressTransaction := True");
		}
		writer.WriteLine(")");
	}

	/// <summary>
	/// Removes any invalid characters from the name of an database artifact.
	/// </summary>
	/// <param name="name">The name to be scrubbed.</param>
	/// <returns>The scrubbed name.</returns>
	protected virtual string ScrubName(string name)
	{
		Regex regex = new Regex("[^\\p{Ll}\\p{Lu}\\p{Lt}\\p{Lo}\\p{Nd}\\p{Nl}\\p{Mn}\\p{Mc}\\p{Cf}\\p{Pc}\\p{Lm}]");
		name = regex.Replace(name, string.Empty);
		using (VBCodeProvider vBCodeProvider = new VBCodeProvider())
		{
			if (!char.IsLetter(name[0]) || !vBCodeProvider.IsValidIdentifier(name))
			{
				name = "_" + name;
			}
		}
		return name;
	}

	/// <summary>
	/// Gets the type name to use for a column of the given data type.
	/// </summary>
	/// <param name="primitiveTypeKind">The data type to translate.</param>
	/// <returns>The type name to use in the generated migration.</returns>
	protected virtual string TranslateColumnType(PrimitiveTypeKind primitiveTypeKind)
	{
		return primitiveTypeKind switch
		{
			PrimitiveTypeKind.Int16 => "Short", 
			PrimitiveTypeKind.Int32 => "Int", 
			PrimitiveTypeKind.Int64 => "Long", 
			_ => Enum.GetName(typeof(PrimitiveTypeKind), primitiveTypeKind), 
		};
	}

	/// <summary>
	/// Quotes an identifier using appropriate escaping to allow it to be stored in a string.
	/// </summary>
	/// <param name="identifier">The identifier to be quoted.</param>
	/// <returns>The quoted identifier.</returns>
	protected virtual string Quote(string identifier)
	{
		return "\"" + identifier + "\"";
	}
}
