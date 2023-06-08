using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace System.Data.Entity.Migrations;

/// <summary>
/// Configuration relating to the use of migrations for a given model.
/// You will typically create a configuration class that derives
/// from <see cref="T:System.Data.Entity.Migrations.DbMigrationsConfiguration`1" /> rather than 
/// using this class.
/// </summary>
public class DbMigrationsConfiguration
{
	private readonly Dictionary<string, MigrationSqlGenerator> _sqlGenerators = new Dictionary<string, MigrationSqlGenerator>();

	private MigrationCodeGenerator _codeGenerator;

	private Type _contextType;

	private Assembly _migrationsAssembly;

	private ModelDiffer _modelDiffer = new EdmModelDiffer();

	private DbConnectionInfo _connectionInfo;

	private string _migrationsDirectory = "Migrations";

	/// <summary>
	/// Gets or sets a value indicating if automatic migrations can be used when migration the database.
	/// </summary>
	public bool AutomaticMigrationsEnabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating if data loss is acceptable during automatic migration.
	/// If set to false an exception will be thrown if data loss may occur as part of an automatic migration.
	/// </summary>
	public bool AutomaticMigrationDataLossAllowed { get; set; }

	/// <summary>
	/// Gets or sets the derived DbContext representing the model to be migrated.
	/// </summary>
	public Type ContextType
	{
		get
		{
			return _contextType;
		}
		set
		{
			if (__ContractsRuntime.insideContractEvaluation <= 4)
			{
				try
				{
					__ContractsRuntime.insideContractEvaluation++;
					RuntimeFailureMethods.Requires(value != null, null, "value != null");
					RuntimeFailureMethods.Requires(typeof(DbContext).IsAssignableFrom(value), null, "typeof(DbContext).IsAssignableFrom(value)");
				}
				finally
				{
					__ContractsRuntime.insideContractEvaluation--;
				}
			}
			_contextType = value;
		}
	}

	/// <summary>
	/// Gets or sets the namespace used for code-based migrations.
	/// </summary>
	public string MigrationsNamespace { get; set; }

	/// <summary>
	/// Gets or sets the sub-directory that code-based migrations are stored in.
	/// </summary>
	public string MigrationsDirectory
	{
		get
		{
			return _migrationsDirectory;
		}
		set
		{
			RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(value), null, "!string.IsNullOrWhiteSpace(value)");
			_migrationsDirectory = value;
		}
	}

	/// <summary>
	/// Gets or sets the code generator to be used when scaffolding migrations.
	/// </summary>
	public MigrationCodeGenerator CodeGenerator
	{
		get
		{
			return _codeGenerator;
		}
		set
		{
			RuntimeFailureMethods.Requires(value != null, null, "value != null");
			_codeGenerator = value;
		}
	}

	/// <summary>
	/// Gets or sets the assembly containing code-based migrations.
	/// </summary>
	public Assembly MigrationsAssembly
	{
		get
		{
			return _migrationsAssembly;
		}
		set
		{
			if (__ContractsRuntime.insideContractEvaluation <= 4)
			{
				try
				{
					__ContractsRuntime.insideContractEvaluation++;
					RuntimeFailureMethods.Requires(value != null, null, "value != null");
				}
				finally
				{
					__ContractsRuntime.insideContractEvaluation--;
				}
			}
			_migrationsAssembly = value;
		}
	}

	/// <summary>
	/// Gets or sets a value to override the connection of the database to be migrated.
	/// </summary>
	public DbConnectionInfo TargetDatabase
	{
		get
		{
			return _connectionInfo;
		}
		set
		{
			RuntimeFailureMethods.Requires(value != null, null, "value != null");
			_connectionInfo = value;
		}
	}

	internal ModelDiffer ModelDiffer
	{
		get
		{
			return _modelDiffer;
		}
		set
		{
			_modelDiffer = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the DbMigrationsConfiguration class. 
	/// </summary>
	public DbMigrationsConfiguration()
	{
		SetSqlGenerator("System.Data.SqlClient", new SqlServerMigrationSqlGenerator());
		SetSqlGenerator("System.Data.SqlServerCe.4.0", new SqlCeMigrationSqlGenerator());
		CodeGenerator = new CSharpMigrationCodeGenerator();
	}

	/// <summary>
	/// Adds a new SQL generator to be used for a given database provider.
	/// </summary>
	/// <param name="providerInvariantName">Name of the database provider to set the SQL generator for.</param>
	/// <param name="migrationSqlGenerator">The SQL generator to be used.</param>
	public void SetSqlGenerator(string providerInvariantName, MigrationSqlGenerator migrationSqlGenerator)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerInvariantName), null, "!string.IsNullOrWhiteSpace(providerInvariantName)");
		RuntimeFailureMethods.Requires(migrationSqlGenerator != null, null, "migrationSqlGenerator != null");
		_sqlGenerators[providerInvariantName] = migrationSqlGenerator;
	}

	/// <summary>
	/// Gets the SQL generator that is set to be used with a given database provider.
	/// </summary>
	/// <param name="providerInvariantName">Name of the database provider to get the SQL generator for.</param>
	/// <returns>The SQL generator that is set for the database provider.</returns>
	public MigrationSqlGenerator GetSqlGenerator(string providerInvariantName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerInvariantName), null, "!string.IsNullOrWhiteSpace(providerInvariantName)");
		return _sqlGenerators[providerInvariantName];
	}

	internal virtual void OnSeed(DbContext context)
	{
	}
}
/// <summary>
/// Configuration relating to the use of migrations for a given model.
/// </summary>
/// <typeparam name="TContext">The context representing the model that this configuration applies to.</typeparam>
public class DbMigrationsConfiguration<TContext> : DbMigrationsConfiguration where TContext : DbContext
{
	/// <summary>
	/// Initializes a new instance of the DbMigrationsConfiguration class. 
	/// </summary>
	public DbMigrationsConfiguration()
	{
		base.ContextType = typeof(TContext);
		base.MigrationsAssembly = GetType().Assembly;
		base.MigrationsNamespace = GetType().Namespace;
	}

	/// <summary>
	/// Runs after upgrading to the latest migration to allow seed data to be updated.
	/// </summary>
	/// <param name="context">Context to be used for updating seed data.</param>
	protected virtual void Seed(TContext context)
	{
		RuntimeFailureMethods.Requires(context != null, null, "context != null");
	}

	internal override void OnSeed(DbContext context)
	{
		Seed((TContext)context);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString()
	{
		return base.ToString();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType()
	{
		return base.GetType();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected new object MemberwiseClone()
	{
		return base.MemberwiseClone();
	}
}
