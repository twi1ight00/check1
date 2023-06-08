using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.Migrations.Design;

/// <summary>
/// Scaffolds code-based migrations to apply pending model changes to the database.
/// </summary>
public class MigrationScaffolder
{
	private readonly DbMigrator _migrator;

	private string _namespace;

	private bool _namespaceSpecified;

	/// <summary>
	/// Gets or sets the namespace used in the migration's generated code.
	///
	/// By default, this is the same as MigrationsNamespace on the migrations
	/// configuration object passed into the constructor. For VB.NET projects, this
	/// will need to be updated to take into account the project's root namespace.
	/// </summary>
	public string Namespace
	{
		get
		{
			if (!_namespaceSpecified)
			{
				return _migrator.Configuration.MigrationsNamespace;
			}
			return _namespace;
		}
		set
		{
			_namespaceSpecified = _migrator.Configuration.MigrationsNamespace != value;
			_namespace = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the MigrationScaffolder class.
	/// </summary>
	/// <param name="migrationsConfiguration">Configuration to be used for scaffolding.</param>
	public MigrationScaffolder(DbMigrationsConfiguration migrationsConfiguration)
	{
		RuntimeFailureMethods.Requires(migrationsConfiguration != null, null, "migrationsConfiguration != null");
		base._002Ector();
		_migrator = new DbMigrator(migrationsConfiguration);
	}

	/// <summary>
	/// Scaffolds a code based migration to apply any pending model changes to the database.
	/// </summary>
	/// <param name="migrationName">The name to use for the scaffolded migration.</param>
	/// <returns>The scaffolded migration.</returns>
	public virtual ScaffoldedMigration Scaffold(string migrationName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(migrationName), null, "!string.IsNullOrWhiteSpace(migrationName)");
		DbMigrator migrator = _migrator;
		bool ignoreChanges = false;
		return migrator.Scaffold(migrationName, Namespace, ignoreChanges);
	}

	/// <summary>
	/// Scaffolds a code based migration to apply any pending model changes to the database.
	/// </summary>
	/// <param name="migrationName">The name to use for the scaffolded migration.</param>
	/// <param name="ignoreChanges">Whether or not to include model changes.</param>
	/// <returns>The scaffolded migration.</returns>
	public virtual ScaffoldedMigration Scaffold(string migrationName, bool ignoreChanges)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(migrationName), null, "!string.IsNullOrWhiteSpace(migrationName)");
		return _migrator.Scaffold(migrationName, Namespace, ignoreChanges);
	}

	/// <summary>
	/// Scaffolds the initial code-based migration corresponding to a previously run database initializer.
	/// </summary>
	/// <returns>The scaffolded migration.</returns>
	public virtual ScaffoldedMigration ScaffoldInitialCreate()
	{
		return _migrator.ScaffoldInitialCreate(Namespace);
	}
}
