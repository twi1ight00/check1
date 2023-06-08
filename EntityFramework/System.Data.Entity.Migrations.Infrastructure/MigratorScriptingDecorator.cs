using System.Collections.Generic;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;
using System.Text;

namespace System.Data.Entity.Migrations.Infrastructure;

/// <summary>
/// Decorator to produce a SQL script instead of applying changes to the database.
/// Using this decorator to wrap <see cref="T:System.Data.Entity.Migrations.DbMigrator" /> will prevent <see cref="T:System.Data.Entity.Migrations.DbMigrator" /> 
/// from applying any changes to the target database.
/// </summary>
public class MigratorScriptingDecorator : MigratorBase
{
	private readonly StringBuilder _sqlBuilder;

	/// <summary>
	/// Initializes a new instance of the  MigratorScriptingDecorator class.
	/// </summary>
	/// <param name="innerMigrator">The migrator that this decorator is wrapping.</param>
	public MigratorScriptingDecorator(MigratorBase innerMigrator)
	{
		RuntimeFailureMethods.Requires(innerMigrator != null, null, "innerMigrator != null");
		_sqlBuilder = new StringBuilder();
		base._002Ector(innerMigrator);
	}

	public string ScriptUpdate(string sourceMigration, string targetMigration)
	{
		_sqlBuilder.Clear();
		if (string.IsNullOrWhiteSpace(sourceMigration))
		{
			Update(targetMigration);
		}
		else
		{
			if (sourceMigration.IsAutomaticMigration())
			{
				throw Error.AutoNotValidForScriptWindows(sourceMigration);
			}
			string sourceMigrationId = GetMigrationId(sourceMigration);
			IEnumerable<string> enumerable = from m in GetLocalMigrations()
				where string.CompareOrdinal(m, sourceMigrationId) > 0
				select m;
			string targetMigrationId = null;
			if (!string.IsNullOrWhiteSpace(targetMigration))
			{
				if (targetMigration.IsAutomaticMigration())
				{
					throw Error.AutoNotValidForScriptWindows(targetMigration);
				}
				targetMigrationId = GetMigrationId(targetMigration);
				if (string.CompareOrdinal(sourceMigrationId, targetMigrationId) > 0)
				{
					throw Error.DownScriptWindowsNotSupported();
				}
				enumerable = enumerable.Where((string m) => string.CompareOrdinal(m, targetMigrationId) <= 0);
			}
			Upgrade(enumerable, targetMigrationId, sourceMigrationId);
		}
		return _sqlBuilder.ToString();
	}

	internal override void EnsureDatabaseExists()
	{
	}

	internal override void ExecuteStatements(IEnumerable<MigrationStatement> migrationStatements)
	{
		foreach (MigrationStatement migrationStatement in migrationStatements)
		{
			if (!string.IsNullOrWhiteSpace(migrationStatement.Sql))
			{
				_sqlBuilder.AppendLine(migrationStatement.Sql);
			}
		}
	}

	internal override void SeedDatabase()
	{
	}

	internal override bool IsFirstMigrationIncludingAutomatics(string migrationId)
	{
		if (migrationId.IsAutomaticMigration())
		{
			return true;
		}
		DbMigration migration = base.GetMigration(migrationId);
		IMigrationMetadata migrationMetadata = (IMigrationMetadata)migration;
		return migrationMetadata.Source == null;
	}
}
