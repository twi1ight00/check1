using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations.Infrastructure;

/// <summary>
/// Decorator to provide logging during migrations operations..
/// </summary>
public class MigratorLoggingDecorator : MigratorBase
{
	private static readonly Regex _historyInsertRegex = new Regex("^INSERT INTO \\[__MigrationHistory\\].*$", RegexOptions.Multiline | RegexOptions.Compiled);

	private static readonly Regex _historyDeleteRegex = new Regex("^DELETE.* \\[__MigrationHistory\\].*$", RegexOptions.Multiline | RegexOptions.Compiled);

	private static readonly Regex _metadataDeleteRegex = new Regex("DELETE.* \\[EdmMetadata\\].*((\\r?\\n)?|$)", RegexOptions.Compiled);

	private static readonly Regex _metadataInsertRegex = new Regex("INSERT.* \\[EdmMetadata\\].*((\\r?\\n)?|$)", RegexOptions.Compiled);

	private readonly MigrationsLogger _logger;

	/// <summary>
	/// Initializes a new instance of the MigratorLoggingDecorator class.
	/// </summary>
	/// <param name="innerMigrator">The migrator that this decorator is wrapping.</param>
	/// <param name="logger">The logger to write messages to.</param>
	public MigratorLoggingDecorator(MigratorBase innerMigrator, MigrationsLogger logger)
	{
		RuntimeFailureMethods.Requires(innerMigrator != null, null, "innerMigrator != null");
		RuntimeFailureMethods.Requires(logger != null, null, "logger != null");
		base._002Ector(innerMigrator);
		_logger = logger;
		_logger.Verbose(Strings.LoggingTargetDatabase(base.TargetDatabase));
	}

	internal override void AutoMigrate(string migrationId, XDocument sourceModel, XDocument targetModel, bool downgrading)
	{
		_logger.Info(downgrading ? Strings.LoggingRevertAutoMigrate(migrationId) : Strings.LoggingAutoMigrate(migrationId));
		base.AutoMigrate(migrationId, sourceModel, targetModel, downgrading);
	}

	internal override void ExecuteSql(DbTransaction transaction, MigrationStatement migrationStatement)
	{
		string input = _historyInsertRegex.Replace(migrationStatement.Sql, Strings.LoggingHistoryInsert);
		input = _historyDeleteRegex.Replace(input, Strings.LoggingHistoryDelete);
		input = _metadataDeleteRegex.Replace(input, Strings.LoggingMetadataUpdate);
		input = _metadataInsertRegex.Replace(input, string.Empty);
		_logger.Verbose(input.Trim());
		base.ExecuteSql(transaction, migrationStatement);
	}

	internal override void Upgrade(IEnumerable<string> pendingMigrations, string targetMigrationId, string lastMigrationId)
	{
		int num = pendingMigrations.Count();
		_logger.Info((num > 0) ? Strings.LoggingPendingMigrations(num, pendingMigrations.Join()) : (string.IsNullOrWhiteSpace(targetMigrationId) ? Strings.LoggingNoExplicitMigrations : Strings.LoggingAlreadyAtTarget(targetMigrationId)));
		base.Upgrade(pendingMigrations, targetMigrationId, lastMigrationId);
	}

	internal override void Downgrade(IEnumerable<string> pendingMigrations)
	{
		IEnumerable<string> enumerable = pendingMigrations.Take(pendingMigrations.Count() - 1);
		_logger.Info(Strings.LoggingPendingMigrationsDown(enumerable.Count(), enumerable.Join()));
		base.Downgrade(pendingMigrations);
	}

	internal override void ApplyMigration(DbMigration migration, DbMigration lastMigration)
	{
		_logger.Info(Strings.LoggingApplyMigration(((IMigrationMetadata)migration).Id));
		base.ApplyMigration(migration, lastMigration);
	}

	internal override void RevertMigration(string migrationId, DbMigration migration, XDocument targetModel)
	{
		_logger.Info(Strings.LoggingRevertMigration(migrationId));
		base.RevertMigration(migrationId, migration, targetModel);
	}

	internal override void SeedDatabase()
	{
		_logger.Info(Strings.LoggingSeedingDatabase);
		base.SeedDatabase();
	}

	internal override void UpgradeHistory(IEnumerable<MigrationOperation> upgradeOperations)
	{
		_logger.Info(Strings.UpgradingHistoryTable);
		base.UpgradeHistory(upgradeOperations);
	}
}
