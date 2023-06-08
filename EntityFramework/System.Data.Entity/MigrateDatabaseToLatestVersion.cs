using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity;

/// <summary>
/// An implementation of <see cref="T:System.Data.Entity.IDatabaseInitializer`1" /> that will use Code First Migrations
/// to update the database to the latest version.
/// </summary>
public class MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration> : IDatabaseInitializer<TContext> where TContext : DbContext where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
{
	private readonly DbMigrationsConfiguration _config;

	/// <summary>
	/// Initializes a new instance of the MigrateDatabaseToLatestVersion class. 
	/// </summary>
	public MigrateDatabaseToLatestVersion()
	{
		_config = new TMigrationsConfiguration();
	}

	/// <summary>
	/// Initializes a new instance of the MigrateDatabaseToLatestVersion class that will
	/// use a specific connection string from the configuration file to connect to
	/// the database to perform the migration.
	/// </summary>
	/// <param name="connectionStringName">The name of the connection string to use for migration.</param>
	public MigrateDatabaseToLatestVersion(string connectionStringName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(connectionStringName), null, "!string.IsNullOrWhiteSpace(connectionStringName)");
		base._002Ector();
		_config = new TMigrationsConfiguration
		{
			TargetDatabase = new DbConnectionInfo(connectionStringName)
		};
	}

	/// <inheritdoc />
	public void InitializeDatabase(TContext context)
	{
		RuntimeFailureMethods.Requires(context != null, null, "context != null");
		DbMigrator dbMigrator = new DbMigrator(_config);
		dbMigrator.Update();
	}
}
