using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Edm;
using System.Data.Entity.Migrations.Extensions;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace System.Data.Entity.Migrations;

/// <summary>
///     DbMigrator is used to apply existing migrations to a database. 
///     DbMigrator can be used to upgrade and downgrade to any given migration.
///     To scaffold migrations based on changes to your model use <see cref="T:System.Data.Entity.Migrations.Design.MigrationScaffolder" />
/// </summary>
public class DbMigrator : MigratorBase
{
	/// <summary>
	///     Migration Id representing the state of the database before any migrations are applied.
	/// </summary>
	public const string InitialDatabase = "0";

	private static readonly MethodInfo _setInitializerMethod = typeof(Database).GetMethod("SetInitializer");

	private readonly XDocument _emptyModel;

	private readonly DbMigrationsConfiguration _configuration;

	private readonly XDocument _currentModel;

	private readonly DbProviderFactory _providerFactory;

	private readonly HistoryRepository _historyRepository;

	private readonly MigrationAssembly _migrationAssembly;

	private readonly DbContextInfo _usersContextInfo;

	private readonly bool _calledByCreateDatabase;

	private readonly MigrationSqlGenerator _sqlGenerator;

	private readonly ModelDiffer _modelDiffer;

	private readonly string _providerManifestToken;

	private readonly bool _hasSeedLogic;

	private readonly string _targetDatabase;

	private bool _emptyMigrationNeeded;

	/// <summary>
	///     Gets the configuration that is being used for the migration process.
	/// </summary>
	public override DbMigrationsConfiguration Configuration => _configuration;

	internal override string TargetDatabase => _targetDatabase;

	/// <summary>
	///     Initializes a new instance of the DbMigrator class.
	/// </summary>
	/// <param name="configuration">Configuration to be used for the migration process.</param>
	public DbMigrator(DbMigrationsConfiguration configuration)
	{
		RuntimeFailureMethods.Requires(configuration != null, null, "configuration != null");
		RuntimeFailureMethods.Requires(configuration.ContextType != null, null, "configuration.ContextType != null");
		this._002Ector(configuration, null);
	}

	internal DbMigrator(DbMigrationsConfiguration configuration, DbContext usersContext)
		: base(null)
	{
		_configuration = configuration;
		_calledByCreateDatabase = usersContext != null;
		if (usersContext == null)
		{
			DisableInitializer(_configuration.ContextType);
		}
		if (_calledByCreateDatabase)
		{
			_usersContextInfo = new DbContextInfo(usersContext);
		}
		else
		{
			_usersContextInfo = ((configuration.TargetDatabase == null) ? new DbContextInfo(configuration.ContextType) : new DbContextInfo(configuration.ContextType, configuration.TargetDatabase));
			if (!_usersContextInfo.IsConstructible)
			{
				throw Error.ContextNotConstructible(configuration.ContextType);
			}
		}
		_modelDiffer = _configuration.ModelDiffer;
		DbContext dbContext = usersContext ?? _usersContextInfo.CreateInstance();
		try
		{
			_migrationAssembly = new MigrationAssembly(_configuration.MigrationsAssembly, _configuration.MigrationsNamespace);
			_currentModel = dbContext.GetModel();
			_sqlGenerator = _configuration.GetSqlGenerator(_usersContextInfo.ConnectionProviderName);
			DbConnection connection = dbContext.Database.Connection;
			_providerFactory = DbProviderServices.GetProviderFactory(connection);
			_historyRepository = new HistoryRepository(_usersContextInfo.ConnectionString, _providerFactory);
			_providerManifestToken = ((dbContext.InternalContext.ModelProviderInfo != null) ? dbContext.InternalContext.ModelProviderInfo.ProviderManifestToken : DbProviderServices.GetProviderServices(connection).GetProviderManifestTokenChecked(connection));
			_targetDatabase = Strings.LoggingTargetDatabaseFormat(connection.DataSource, connection.Database, _usersContextInfo.ConnectionProviderName, (_usersContextInfo.ConnectionStringOrigin == DbConnectionStringOrigin.DbContextInfo) ? Strings.LoggingExplicit : _usersContextInfo.ConnectionStringOrigin.ToString());
		}
		finally
		{
			if (usersContext == null)
			{
				dbContext.Dispose();
			}
		}
		_emptyModel = new DbModelBuilder().Build(new DbProviderInfo(_usersContextInfo.ConnectionProviderName, _providerManifestToken)).GetModel();
		MethodInfo method = _configuration.GetType().GetMethod("Seed", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
		if (method != null)
		{
			_hasSeedLogic = method.GetMethodBody().GetILAsByteArray().Length > 2;
		}
	}

	internal virtual void DisableInitializer(Type contextType)
	{
		MethodInfo methodInfo = _setInitializerMethod.MakeGenericMethod(contextType);
		object[] parameters = new object[1];
		methodInfo.Invoke(null, parameters);
	}

	/// <summary>
	///     Gets all migrations that are defined in the configured migrations assembly.
	/// </summary>
	public override IEnumerable<string> GetLocalMigrations()
	{
		return _migrationAssembly.MigrationIds;
	}

	/// <summary>
	///     Gets all migrations that have been applied to the target database.
	/// </summary>
	public override IEnumerable<string> GetDatabaseMigrations()
	{
		return _historyRepository.GetMigrationsSince("0");
	}

	internal ScaffoldedMigration ScaffoldInitialCreate(string @namespace)
	{
		string migrationId;
		XDocument lastModel = _historyRepository.GetLastModel(out migrationId);
		if (lastModel == null || !migrationId.MigrationName().Equals(Strings.InitialCreate))
		{
			return null;
		}
		List<MigrationOperation> operations = _modelDiffer.Diff(_emptyModel, lastModel, _usersContextInfo.ConnectionString).ToList();
		ScaffoldedMigration scaffoldedMigration = _configuration.CodeGenerator.Generate(migrationId, operations, null, Convert.ToBase64String(new ModelCompressor().Compress(_currentModel)), @namespace, Strings.InitialCreate);
		scaffoldedMigration.MigrationId = migrationId;
		scaffoldedMigration.Directory = _configuration.MigrationsDirectory;
		return scaffoldedMigration;
	}

	internal ScaffoldedMigration Scaffold(string migrationName, string @namespace, bool ignoreChanges)
	{
		XDocument sourceModel = null;
		CheckLegacyCompatibility(delegate
		{
			sourceModel = _currentModel;
		});
		string migrationId = null;
		sourceModel = sourceModel ?? _historyRepository.GetLastModel(out migrationId) ?? _emptyModel;
		ModelCompressor modelCompressor = new ModelCompressor();
		IEnumerable<MigrationOperation> operations = (ignoreChanges ? Enumerable.Empty<MigrationOperation>() : _modelDiffer.Diff(sourceModel, _currentModel, _usersContextInfo.ConnectionString).ToList());
		string migrationId2;
		if (migrationName.IsValidMigrationId())
		{
			migrationId2 = migrationName;
			migrationName = migrationName.MigrationName();
		}
		else
		{
			migrationName = _migrationAssembly.UniquifyName(migrationName);
			migrationId2 = MigrationAssembly.CreateMigrationId(migrationName);
		}
		ScaffoldedMigration scaffoldedMigration = _configuration.CodeGenerator.Generate(migrationId2, operations, (sourceModel == _emptyModel || sourceModel == _currentModel || !migrationId.IsAutomaticMigration()) ? null : Convert.ToBase64String(modelCompressor.Compress(sourceModel)), Convert.ToBase64String(modelCompressor.Compress(_currentModel)), @namespace, migrationName);
		scaffoldedMigration.MigrationId = migrationId2;
		scaffoldedMigration.Directory = _configuration.MigrationsDirectory;
		return scaffoldedMigration;
	}

	/// <summary>
	///     Gets all migrations that are defined in the assembly but haven't been applied to the target database.
	/// </summary>
	public override IEnumerable<string> GetPendingMigrations()
	{
		return _historyRepository.GetPendingMigrations(_migrationAssembly.MigrationIds);
	}

	private void CheckLegacyCompatibility(Action onCompatible)
	{
		if (_calledByCreateDatabase || _historyRepository.Exists())
		{
			return;
		}
		using DbContext dbContext = _usersContextInfo.CreateInstance();
		bool flag;
		try
		{
			flag = dbContext.Database.CompatibleWithModel(throwIfNoMetadata: true);
		}
		catch
		{
			return;
		}
		if (!flag)
		{
			throw Error.MetadataOutOfDate();
		}
		onCompatible();
	}

	/// <summary>
	///     Updates the target database to a given migration.
	/// </summary>
	/// <param name="targetMigration">The migration to upgrade/downgrade to.</param>
	public override void Update(string targetMigration)
	{
		base.EnsureDatabaseExists();
		IEnumerable<MigrationOperation> upgradeOperations = _historyRepository.GetUpgradeOperations();
		if (upgradeOperations.Any())
		{
			base.UpgradeHistory(upgradeOperations);
		}
		IEnumerable<string> enumerable = GetPendingMigrations();
		if (!enumerable.Any())
		{
			CheckLegacyCompatibility(delegate
			{
				ExecuteOperations(MigrationAssembly.CreateBootstrapMigrationId(), _currentModel, new List<MigrationOperation>(), downgrading: false);
			});
		}
		string targetMigrationId = targetMigration;
		if (!string.IsNullOrWhiteSpace(targetMigrationId))
		{
			if (!targetMigrationId.IsValidMigrationId())
			{
				if (targetMigrationId == Strings.AutomaticMigration)
				{
					throw Error.AutoNotValidTarget(Strings.AutomaticMigration);
				}
				targetMigrationId = GetMigrationId(targetMigration);
			}
			if (enumerable.Any((string m) => m.EqualsIgnoreCase(targetMigrationId)))
			{
				enumerable = enumerable.Where((string m) => string.CompareOrdinal(m.ToLowerInvariant(), targetMigrationId.ToLowerInvariant()) <= 0);
			}
			else
			{
				enumerable = _historyRepository.GetMigrationsSince(targetMigrationId);
				if (enumerable.Any())
				{
					base.Downgrade(enumerable.Concat(new string[1] { targetMigrationId }));
					return;
				}
			}
		}
		base.Upgrade(enumerable, targetMigrationId, null);
	}

	internal override void UpgradeHistory(IEnumerable<MigrationOperation> upgradeOperations)
	{
		IEnumerable<MigrationStatement> migrationStatements = _sqlGenerator.Generate(upgradeOperations, _providerManifestToken);
		base.ExecuteStatements(migrationStatements);
	}

	internal override string GetMigrationId(string migration)
	{
		if (migration.IsValidMigrationId())
		{
			return migration;
		}
		string text = GetPendingMigrations().SingleOrDefault((string m) => m.MigrationName().EqualsIgnoreCase(migration)) ?? _historyRepository.GetMigrationId(migration);
		if (text == null)
		{
			throw Error.MigrationNotFound(migration);
		}
		return text;
	}

	internal override void Upgrade(IEnumerable<string> pendingMigrations, string targetMigrationId, string lastMigrationId)
	{
		DbMigration lastMigration = null;
		if (lastMigrationId != null)
		{
			lastMigration = _migrationAssembly.GetMigration(lastMigrationId);
		}
		foreach (string pendingMigration in pendingMigrations)
		{
			DbMigration migration = _migrationAssembly.GetMigration(pendingMigration);
			base.ApplyMigration(migration, lastMigration);
			lastMigration = migration;
			_emptyMigrationNeeded = false;
			if (pendingMigration.EqualsIgnoreCase(targetMigrationId))
			{
				break;
			}
		}
		if (string.IsNullOrWhiteSpace(targetMigrationId) && ((_emptyMigrationNeeded && _configuration.AutomaticMigrationsEnabled) || IsModelOutOfDate(_currentModel, lastMigration)))
		{
			if (!_configuration.AutomaticMigrationsEnabled)
			{
				throw Error.AutomaticDisabledException();
			}
			base.AutoMigrate(MigrationAssembly.CreateMigrationId(_calledByCreateDatabase ? Strings.InitialCreate : Strings.AutomaticMigration), GetLastModel(lastMigration), _currentModel, downgrading: false);
		}
		if (_hasSeedLogic && !IsModelOutOfDate(_currentModel, lastMigration))
		{
			base.SeedDatabase();
		}
	}

	internal override void SeedDatabase()
	{
		if (!_calledByCreateDatabase)
		{
			using (DbContext dbContext = _usersContextInfo.CreateInstance())
			{
				_configuration.OnSeed(dbContext);
				dbContext.SaveChanges();
			}
		}
	}

	private bool IsModelOutOfDate(XDocument model, DbMigration lastMigration)
	{
		return _modelDiffer.Diff(GetLastModel(lastMigration), model, _usersContextInfo.ConnectionString).Any();
	}

	private XDocument GetLastModel(DbMigration lastMigration, string currentMigrationId = null)
	{
		if (lastMigration != null)
		{
			IMigrationMetadata migrationMetadata = (IMigrationMetadata)lastMigration;
			return new ModelCompressor().Decompress(Convert.FromBase64String(migrationMetadata.Target));
		}
		string migrationId;
		XDocument lastModel = _historyRepository.GetLastModel(out migrationId);
		if (lastModel != null && (currentMigrationId == null || migrationId.ComesBefore(currentMigrationId)))
		{
			return lastModel;
		}
		return _emptyModel;
	}

	internal override void Downgrade(IEnumerable<string> pendingMigrations)
	{
		for (int i = 0; i < pendingMigrations.Count() - 1; i++)
		{
			string migrationId = pendingMigrations.ElementAt(i);
			DbMigration migration = _migrationAssembly.GetMigration(migrationId);
			string text = pendingMigrations.ElementAt(i + 1);
			XDocument targetModel = ((text != "0") ? _historyRepository.GetModel(text) : _emptyModel);
			if (migration == null)
			{
				XDocument model = _historyRepository.GetModel(migrationId);
				bool downgrading = true;
				base.AutoMigrate(migrationId, model, targetModel, downgrading);
			}
			else
			{
				base.RevertMigration(migrationId, migration, targetModel);
			}
		}
	}

	internal override void RevertMigration(string migrationId, DbMigration migration, XDocument targetModel)
	{
		migration.Down();
		bool downgrading = true;
		ExecuteOperations(migrationId, targetModel, migration.Operations.ToList(), downgrading);
	}

	internal override void ApplyMigration(DbMigration migration, DbMigration lastMigration)
	{
		IMigrationMetadata migrationMetadata = (IMigrationMetadata)migration;
		ModelCompressor modelCompressor = new ModelCompressor();
		if (migrationMetadata.Source != null)
		{
			XDocument xDocument = modelCompressor.Decompress(Convert.FromBase64String(migrationMetadata.Source));
			if (IsModelOutOfDate(xDocument, lastMigration))
			{
				bool downgrading = false;
				base.AutoMigrate(migrationMetadata.Id + "_" + Strings.AutomaticMigration, GetLastModel(lastMigration, migrationMetadata.Id), xDocument, downgrading);
			}
		}
		migration.Up();
		XDocument targetModel = modelCompressor.Decompress(Convert.FromBase64String(migrationMetadata.Target));
		ExecuteOperations(migrationMetadata.Id, targetModel, migration.Operations.ToList(), downgrading: false);
	}

	internal override void AutoMigrate(string migrationId, XDocument sourceModel, XDocument targetModel, bool downgrading)
	{
		List<MigrationOperation> list = _modelDiffer.Diff(sourceModel, targetModel, _usersContextInfo.ConnectionString).ToList();
		if (!_configuration.AutomaticMigrationDataLossAllowed && list.Any((MigrationOperation o) => o.IsDestructiveChange))
		{
			throw Error.AutomaticDataLoss();
		}
		ExecuteOperations(migrationId, targetModel, list, downgrading);
	}

	private void ExecuteOperations(string migrationId, XDocument targetModel, IEnumerable<MigrationOperation> operations, bool downgrading)
	{
		FillInForeignKeyOperations(operations, targetModel);
		List<AddForeignKeyOperation> second = (from ct in operations.OfType<CreateTableOperation>()
			from afk in operations.OfType<AddForeignKeyOperation>()
			where ct.Name.EqualsIgnoreCase(afk.DependentTable)
			select afk).ToList();
		List<MigrationOperation> list = operations.Except(second).Concat(second).ToList();
		bool flag = IsFirstMigration(migrationId, downgrading);
		if (downgrading)
		{
			list.Add(_historyRepository.CreateDeleteOperation(migrationId));
			if (flag)
			{
				list.Add(_historyRepository.CreateDropTableOperation(_modelDiffer));
			}
		}
		else
		{
			if (flag)
			{
				list.Add(_historyRepository.CreateCreateTableOperation(_modelDiffer));
			}
			list.Add(_historyRepository.CreateInsertOperation(migrationId, targetModel));
		}
		IEnumerable<MigrationStatement> migrationStatements = _sqlGenerator.Generate(list, _providerManifestToken);
		base.ExecuteStatements(migrationStatements);
	}

	internal override void ExecuteStatements(IEnumerable<MigrationStatement> migrationStatements)
	{
		using DbConnection dbConnection = CreateConnection();
		dbConnection.Open();
		using DbTransaction dbTransaction = dbConnection.BeginTransaction(IsolationLevel.Serializable);
		foreach (MigrationStatement migrationStatement in migrationStatements)
		{
			base.ExecuteSql(dbTransaction, migrationStatement);
		}
		dbTransaction.Commit();
	}

	[SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
	internal override void ExecuteSql(DbTransaction transaction, MigrationStatement migrationStatement)
	{
		if (string.IsNullOrWhiteSpace(migrationStatement.Sql))
		{
			return;
		}
		if (!migrationStatement.SuppressTransaction)
		{
			using (DbCommand dbCommand = transaction.Connection.CreateCommand())
			{
				dbCommand.CommandText = migrationStatement.Sql;
				dbCommand.Transaction = transaction;
				dbCommand.ExecuteNonQuery();
				return;
			}
		}
		using DbConnection dbConnection = CreateConnection();
		using DbCommand dbCommand2 = dbConnection.CreateCommand();
		dbCommand2.CommandText = migrationStatement.Sql;
		dbConnection.Open();
		dbCommand2.ExecuteNonQuery();
	}

	private static void FillInForeignKeyOperations(IEnumerable<MigrationOperation> operations, XDocument targetModel)
	{
		AddForeignKeyOperation foreignKeyOperation;
		foreach (AddForeignKeyOperation item in from fk in operations.OfType<AddForeignKeyOperation>()
			where fk.PrincipalTable != null && !fk.PrincipalColumns.Any()
			select fk)
		{
			foreignKeyOperation = item;
			string entitySetName = (from es in targetModel.Descendants(EdmXNames.Ssdl.EntitySet)
				where ModelDiffer.GetQualifiedTableName(es.TableAttribute(), es.SchemaAttribute()).EqualsIgnoreCase(foreignKeyOperation.PrincipalTable)
				select es.NameAttribute()).SingleOrDefault();
			if (entitySetName != null)
			{
				XElement xElement = targetModel.Descendants(EdmXNames.Ssdl.EntityType).Single((XElement et) => et.NameAttribute().EqualsIgnoreCase(entitySetName));
				System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(xElement.Descendants(EdmXNames.Ssdl.PropertyRef), delegate(XElement pr)
				{
					foreignKeyOperation.PrincipalColumns.Add(pr.NameAttribute());
				});
				continue;
			}
			CreateTableOperation createTableOperation = operations.OfType<CreateTableOperation>().SingleOrDefault((CreateTableOperation ct) => ct.Name.EqualsIgnoreCase(foreignKeyOperation.PrincipalTable));
			if (createTableOperation != null && createTableOperation.PrimaryKey != null)
			{
				System.Data.Entity.Migrations.Extensions.IEnumerableExtensions.Each(createTableOperation.PrimaryKey.Columns, delegate(string c)
				{
					foreignKeyOperation.PrincipalColumns.Add(c);
				});
				continue;
			}
			throw Error.PartialFkOperation(foreignKeyOperation.DependentTable, foreignKeyOperation.DependentColumns.Join());
		}
	}

	internal override void EnsureDatabaseExists()
	{
		using DbConnection dbConnection = CreateConnection();
		if (!Database.Exists(dbConnection))
		{
			new DatabaseCreator().Create(dbConnection);
			_emptyMigrationNeeded = true;
		}
		else
		{
			_emptyMigrationNeeded = false;
		}
	}

	internal override DbMigration GetMigration(string migrationId)
	{
		return _migrationAssembly.GetMigration(migrationId);
	}

	internal override bool IsFirstMigrationIncludingAutomatics(string migrationId)
	{
		string text = _historyRepository.GetMigrationsSince("0").LastOrDefault();
		if (text != null)
		{
			return string.Equals(migrationId, text, StringComparison.Ordinal);
		}
		return true;
	}

	private bool IsFirstMigration(string migrationId, bool downgrading)
	{
		if (downgrading)
		{
			string b = _historyRepository.GetMigrationsSince("0").LastOrDefault();
			return string.Equals(migrationId, b, StringComparison.Ordinal);
		}
		string text = _migrationAssembly.MigrationIds.FirstOrDefault();
		if (text == null || string.Equals(migrationId, text, StringComparison.Ordinal) || migrationId.ComesBefore(text))
		{
			return base.IsFirstMigrationIncludingAutomatics(migrationId);
		}
		return false;
	}

	private DbConnection CreateConnection()
	{
		DbConnection dbConnection = _providerFactory.CreateConnection();
		dbConnection.ConnectionString = _usersContextInfo.ConnectionString;
		return dbConnection;
	}
}
