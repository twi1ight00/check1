using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Diagnostics;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Infrastructure;

/// <summary>
/// Base class for decorators that wrap the core <see cref="T:System.Data.Entity.Migrations.DbMigrator" />
/// </summary>
[DebuggerStepThrough]
public abstract class MigratorBase
{
	private MigratorBase _this;

	/// <summary>
	/// Gets the configuration being used for the migrations process.
	/// </summary>
	public virtual DbMigrationsConfiguration Configuration => _this.Configuration;

	internal virtual string TargetDatabase => _this.TargetDatabase;

	/// <summary>
	/// Initializes a new instance of the MigratorBase class.
	/// </summary>
	/// <param name="innerMigrator">The migrator that this decorator is wrapping.</param>
	protected MigratorBase(MigratorBase innerMigrator)
	{
		if (innerMigrator == null)
		{
			_this = this;
			return;
		}
		_this = innerMigrator;
		MigratorBase migratorBase = innerMigrator;
		while (migratorBase._this != innerMigrator)
		{
			migratorBase = migratorBase._this;
		}
		migratorBase._this = this;
	}

	/// <summary>
	/// Gets a list of the pending migrations that have not been applied to the database.
	/// </summary>
	/// <returns>List of migration Ids</returns>
	public virtual IEnumerable<string> GetPendingMigrations()
	{
		return _this.GetPendingMigrations();
	}

	/// <summary>
	/// Updates the target database to the latest migration.
	/// </summary>
	public void Update()
	{
		Update(null);
	}

	/// <summary>
	/// Updates the target database to a given migration.
	/// </summary>
	/// <param name="targetMigration">The migration to upgrade/downgrade to.</param>
	public virtual void Update(string targetMigration)
	{
		_this.Update(targetMigration);
	}

	internal virtual string GetMigrationId(string migration)
	{
		return _this.GetMigrationId(migration);
	}

	/// <summary>
	/// Gets a list of the migrations that are defined in the assembly.
	/// </summary>
	/// <returns>List of migration Ids</returns>
	public virtual IEnumerable<string> GetLocalMigrations()
	{
		return _this.GetLocalMigrations();
	}

	/// <summary>
	/// Gets a list of the migrations that have been applied to the database.
	/// </summary>
	/// <returns>List of migration Ids</returns>
	public virtual IEnumerable<string> GetDatabaseMigrations()
	{
		return _this.GetDatabaseMigrations();
	}

	internal virtual void AutoMigrate(string migrationId, XDocument sourceModel, XDocument targetModel, bool downgrading)
	{
		_this.AutoMigrate(migrationId, sourceModel, targetModel, downgrading);
	}

	internal virtual void ApplyMigration(DbMigration migration, DbMigration lastMigration)
	{
		_this.ApplyMigration(migration, lastMigration);
	}

	internal virtual void EnsureDatabaseExists()
	{
		_this.EnsureDatabaseExists();
	}

	internal virtual void RevertMigration(string migrationId, DbMigration migration, XDocument targetModel)
	{
		_this.RevertMigration(migrationId, migration, targetModel);
	}

	internal virtual void SeedDatabase()
	{
		_this.SeedDatabase();
	}

	internal virtual void ExecuteStatements(IEnumerable<MigrationStatement> migrationStatements)
	{
		_this.ExecuteStatements(migrationStatements);
	}

	internal virtual void ExecuteSql(DbTransaction transaction, MigrationStatement migrationStatement)
	{
		_this.ExecuteSql(transaction, migrationStatement);
	}

	internal virtual void Upgrade(IEnumerable<string> pendingMigrations, string targetMigrationId, string lastMigrationId)
	{
		_this.Upgrade(pendingMigrations, targetMigrationId, lastMigrationId);
	}

	internal virtual void Downgrade(IEnumerable<string> pendingMigrations)
	{
		_this.Downgrade(pendingMigrations);
	}

	internal virtual void UpgradeHistory(IEnumerable<MigrationOperation> upgradeOperations)
	{
		_this.UpgradeHistory(upgradeOperations);
	}

	internal virtual DbMigration GetMigration(string migrationId)
	{
		return _this.GetMigration(migrationId);
	}

	internal virtual bool IsFirstMigrationIncludingAutomatics(string migrationId)
	{
		return _this.IsFirstMigrationIncludingAutomatics(migrationId);
	}
}
