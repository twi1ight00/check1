using System.Collections.Concurrent;
using System.Data.Common;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Objects;
using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     A <see cref="T:System.Data.Entity.Internal.LazyInternalContext" /> is a concrete <see cref="T:System.Data.Entity.Internal.InternalContext" /> type that will lazily create the
///     underlying <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> when needed. The <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> created is owned by the
///     internal context and will be disposed when the internal context is disposed.
/// </summary>
internal class LazyInternalContext : InternalContext
{
	private static readonly CreateDatabaseIfNotExists<DbContext> DefaultCodeFirstInitializer = new CreateDatabaseIfNotExists<DbContext>();

	private static readonly ConcurrentDictionary<Tuple<Type, string>, RetryLazy<LazyInternalContext, DbCompiledModel>> CachedModels = new ConcurrentDictionary<Tuple<Type, string>, RetryLazy<LazyInternalContext, DbCompiledModel>>();

	private static readonly ConcurrentDictionary<Tuple<DbCompiledModel, string>, RetryAction<InternalContext>> InitializedDatabases = new ConcurrentDictionary<Tuple<DbCompiledModel, string>, RetryAction<InternalContext>>();

	private IInternalConnection _internalConnection;

	private bool _creatingModel;

	private ObjectContext _objectContext;

	private DbCompiledModel _model;

	private readonly bool _createdWithExistingModel;

	private bool _initialLazyLoadingFlag = true;

	private bool _initialProxyCreationFlag = true;

	private bool _inDatabaseInitialization;

	private Action<DbModelBuilder> _onModelCreating;

	private DbProviderInfo _modelProviderInfo;

	/// <summary>
	///     Returns the underlying <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" />.
	/// </summary>
	public override ObjectContext ObjectContext
	{
		get
		{
			Initialize();
			return ObjectContextInUse;
		}
	}

	/// <summary>
	/// The compiled model created from the Code First pipeline, or null if Code First was
	/// not used to create this context.
	/// Causes the Code First pipeline to be run to create the model if it has not already been
	/// created.
	/// </summary>
	public override DbCompiledModel CodeFirstModel
	{
		get
		{
			InitializeContext();
			return _model;
		}
	}

	/// <summary>
	///     The <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> actually being used, which may be the
	///     temp context for initialization or the real context.
	/// </summary>
	private ObjectContext ObjectContextInUse => base.TempObjectContext ?? _objectContext;

	/// <summary>
	///     The connection underlying this context.  Accessing this property does not cause the context
	///     to be initialized, only its connection.
	/// </summary>
	public override DbConnection Connection
	{
		get
		{
			CheckContextNotDisposed();
			return _internalConnection.Connection;
		}
	}

	/// <summary>
	/// The connection string as originally applied to the context. This is used to perform operations
	/// that need the connection string in a non-mutated form, such as with security info still intact.
	/// </summary>
	public override string OriginalConnectionString => _internalConnection.OriginalConnectionString;

	/// <summary>
	///     Returns the origin of the underlying connection string.
	/// </summary>
	public override DbConnectionStringOrigin ConnectionStringOrigin
	{
		get
		{
			CheckContextNotDisposed();
			return _internalConnection.ConnectionStringOrigin;
		}
	}

	/// <summary>
	///     Gets or sets an object representing a config file used for looking for DefaultConnectionFactory entries
	///     and connection strings.
	/// </summary>
	public override AppConfig AppConfig
	{
		get
		{
			return base.AppConfig;
		}
		set
		{
			base.AppConfig = value;
			_internalConnection.AppConfig = value;
		}
	}

	/// <summary>
	///     Gets the name of the underlying connection string.
	/// </summary>
	public override string ConnectionStringName
	{
		get
		{
			CheckContextNotDisposed();
			return _internalConnection.ConnectionStringName;
		}
	}

	/// <summary>
	///     Gets or sets the provider details to be used when building the EDM model.
	/// </summary>
	public override DbProviderInfo ModelProviderInfo
	{
		get
		{
			CheckContextNotDisposed();
			return _modelProviderInfo;
		}
		set
		{
			CheckContextNotDisposed();
			_modelProviderInfo = value;
			_internalConnection.ProviderName = _modelProviderInfo.ProviderInvariantName;
		}
	}

	/// <inheritdoc />
	public override string ProviderName => _internalConnection.ProviderName;

	/// <summary>
	///     Gets or sets a custom OnModelCreating action.
	/// </summary>
	public override Action<DbModelBuilder> OnModelCreating
	{
		get
		{
			CheckContextNotDisposed();
			return _onModelCreating;
		}
		set
		{
			CheckContextNotDisposed();
			_onModelCreating = value;
		}
	}

	/// <summary>
	///     Gets the default database initializer to use for this context if no other has been registered.
	///     For code first this property returns a <see cref="T:System.Data.Entity.CreateDatabaseIfNotExists`1" /> instance.
	///     For database/model first, this property returns null.
	/// </summary>
	/// <value>The default initializer.</value>
	public override IDatabaseInitializer<DbContext> DefaultInitializer
	{
		get
		{
			if (_model == null)
			{
				return null;
			}
			return DefaultCodeFirstInitializer;
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether lazy loading is enabled.
	///     If the <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> exists, then this property acts as a wrapper over the flag stored there.
	///     If the <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> has not been created yet, then we store the value given so we can later
	///     use it when we create the <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" />.  This allows the flag to be changed, for example in
	///     a DbContext constructor, without it causing the <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> to be created.
	/// </summary>
	public override bool LazyLoadingEnabled
	{
		get
		{
			if (_objectContext == null)
			{
				return _initialLazyLoadingFlag;
			}
			return _objectContext.ContextOptions.LazyLoadingEnabled;
		}
		set
		{
			if (_objectContext != null)
			{
				_objectContext.ContextOptions.LazyLoadingEnabled = value;
			}
			else
			{
				_initialLazyLoadingFlag = value;
			}
		}
	}

	/// <summary>
	///     Gets or sets a value indicating whether proxy creation is enabled.
	///     If the ObjectContext exists, then this property acts as a wrapper over the flag stored there.
	///     If the ObjectContext has not been created yet, then we store the value given so we can later
	///     use it when we create the ObjectContext.  This allows the flag to be changed, for example in
	///     a DbContext constructor, without it causing the ObjectContext to be created.
	/// </summary>
	public override bool ProxyCreationEnabled
	{
		get
		{
			if (_objectContext == null)
			{
				return _initialProxyCreationFlag;
			}
			return _objectContext.ContextOptions.ProxyCreationEnabled;
		}
		set
		{
			if (_objectContext != null)
			{
				_objectContext.ContextOptions.ProxyCreationEnabled = value;
			}
			else
			{
				_initialProxyCreationFlag = value;
			}
		}
	}

	/// <summary>
	///     Constructs a <see cref="T:System.Data.Entity.Internal.LazyInternalContext" /> for the given <see cref="T:System.Data.Entity.DbContext" /> owner that will be initialized
	///     on first use.
	/// </summary>
	/// <param name="owner">The owner <see cref="T:System.Data.Entity.DbContext" />.</param>
	/// <param name="internalConnection">Responsible for creating a connection lazily when the context is used for the first time.</param>
	/// <param name="model">The model, or null if it will be created by convention</param>
	public LazyInternalContext(DbContext owner, IInternalConnection internalConnection, DbCompiledModel model)
		: base(owner)
	{
		_internalConnection = internalConnection;
		_model = model;
		_createdWithExistingModel = model != null;
	}

	/// <summary>
	///     Returns the underlying <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> without causing the underlying database to be created
	///     or the database initialization strategy to be executed.
	///     This is used to get a context that can then be used for database creation/initialization.
	/// </summary>
	public override ObjectContext GetObjectContextWithoutDatabaseInitialization()
	{
		InitializeContext();
		return ObjectContextInUse;
	}

	/// <summary>
	///     Saves all changes made in this context to the underlying database, but only if the
	///     context has been initialized. If the context has not been initialized, then this
	///     method does nothing because there is nothing to do; in particular, it does not
	///     cause the context to be initialized.
	/// </summary>
	/// <returns>The number of objects written to the underlying database.</returns>
	public override int SaveChanges()
	{
		if (ObjectContextInUse != null)
		{
			return base.SaveChanges();
		}
		return 0;
	}

	/// <summary>
	///     Disposes the context. The underlying <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> is also disposed.
	///     The connection to the database (<see cref="T:System.Data.Common.DbConnection" /> object) is also disposed if it was created by
	///     the context, otherwise it is not disposed.
	/// </summary>
	public override void DisposeContext()
	{
		if (!base.IsDisposed)
		{
			_internalConnection.Dispose();
			if (_objectContext != null)
			{
				_objectContext.Dispose();
			}
		}
	}

	/// <inheritdoc />
	public override void OverrideConnection(IInternalConnection connection)
	{
		connection.AppConfig = AppConfig;
		if (connection.ConnectionHasModel != _internalConnection.ConnectionHasModel)
		{
			throw _internalConnection.ConnectionHasModel ? Error.LazyInternalContext_CannotReplaceEfConnectionWithDbConnection() : Error.LazyInternalContext_CannotReplaceDbConnectionWithEfConnection();
		}
		_internalConnection = connection;
	}

	/// <summary>
	///     Initializes the underlying <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" />.
	/// </summary>
	protected override void InitializeContext()
	{
		CheckContextNotDisposed();
		if (_objectContext != null)
		{
			return;
		}
		if (_creatingModel)
		{
			throw Error.DbContext_ContextUsedInModelCreating();
		}
		try
		{
			_creatingModel = true;
			if (_createdWithExistingModel)
			{
				if (_internalConnection.ConnectionHasModel)
				{
					throw Error.DbContext_ConnectionHasModel();
				}
				_objectContext = _model.CreateObjectContext<ObjectContext>(_internalConnection.Connection);
			}
			else if (_internalConnection.ConnectionHasModel)
			{
				_objectContext = _internalConnection.CreateObjectContextFromConnectionModel();
			}
			else
			{
				DbCompiledModel value = CachedModels.GetOrAdd(Tuple.Create(base.Owner.GetType(), _internalConnection.ProviderName), (Tuple<Type, string> t) => new RetryLazy<LazyInternalContext, DbCompiledModel>(CreateModel)).GetValue(this);
				_objectContext = value.CreateObjectContext<ObjectContext>(_internalConnection.Connection);
				_model = value;
			}
			_objectContext.ContextOptions.LazyLoadingEnabled = _initialLazyLoadingFlag;
			_objectContext.ContextOptions.ProxyCreationEnabled = _initialProxyCreationFlag;
			InitializeEntitySetMappings();
		}
		finally
		{
			_creatingModel = false;
		}
	}

	/// <summary>
	///     Creates an immutable, cacheable representation of the model defined by this builder.
	///     This model can be used to create an <see cref="P:System.Data.Entity.Internal.LazyInternalContext.ObjectContext" /> or can be passed to a <see cref="T:System.Data.Entity.DbContext" />
	///     constructor to create a <see cref="T:System.Data.Entity.DbContext" /> for this model.
	/// </summary>
	/// <returns></returns>
	public static DbCompiledModel CreateModel(LazyInternalContext internalContext)
	{
		DbModelBuilder dbModelBuilder = internalContext.CreateModelBuilder();
		DbModel dbModel = ((internalContext._modelProviderInfo == null) ? dbModelBuilder.Build(internalContext._internalConnection.Connection) : dbModelBuilder.Build(internalContext._modelProviderInfo));
		return dbModel.Compile();
	}

	/// <summary>
	///     Creates and configures the <see cref="T:System.Data.Entity.DbModelBuilder" /> instance that will be used to build the
	///     <see cref="T:System.Data.Entity.Infrastructure.DbCompiledModel" />.
	/// </summary>
	/// <remarks>Public for testing.</remarks>
	/// <returns>The builder.</returns>
	public DbModelBuilder CreateModelBuilder()
	{
		DbModelBuilderVersion modelBuilderVersion = new AttributeProvider().GetAttributes(base.Owner.GetType()).OfType<DbModelBuilderVersionAttribute>().FirstOrDefault()?.Version ?? DbModelBuilderVersion.Latest;
		DbModelBuilder dbModelBuilder = new DbModelBuilder(modelBuilderVersion);
		string text = EdmUtil.StripInvalidCharacters(base.Owner.GetType().Namespace);
		if (!string.IsNullOrWhiteSpace(text))
		{
			dbModelBuilder.Conventions.Add(new ModelNamespaceConvention(text));
		}
		string text2 = EdmUtil.StripInvalidCharacters(base.Owner.GetType().Name);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			dbModelBuilder.Conventions.Add(new ModelContainerConvention(text2));
		}
		new DbSetDiscoveryService(base.Owner).RegisterSets(dbModelBuilder);
		base.Owner.CallOnModelCreating(dbModelBuilder);
		if (OnModelCreating != null)
		{
			OnModelCreating(dbModelBuilder);
		}
		return dbModelBuilder;
	}

	/// <summary>
	///     Marks the database as having been initialized without actually running the <see cref="T:System.Data.Entity.IDatabaseInitializer`1" />.
	/// </summary>
	public override void MarkDatabaseInitialized()
	{
		InitializeContext();
		InitializeDatabaseAction(delegate
		{
		});
	}

	/// <summary>
	///     Runs the <see cref="T:System.Data.Entity.IDatabaseInitializer`1" /> unless it has already been run or there
	///     is no initializer for this context type in which case this method does nothing.
	/// </summary>
	protected override void InitializeDatabase()
	{
		InitializeDatabaseAction(delegate(InternalContext c)
		{
			c.PerformDatabaseInitialization();
		});
	}

	/// <summary>
	///     Performs some action (which may do nothing) in such a way that it is guaranteed only to be run
	///     once for the model and connection in this app domain, unless it fails by throwing an exception,
	///     in which case it will be re-tried next time the context is initialized.
	/// </summary>
	/// <param name="action">The action.</param>
	private void InitializeDatabaseAction(Action<InternalContext> action)
	{
		if (_inDatabaseInitialization)
		{
			return;
		}
		try
		{
			_inDatabaseInitialization = true;
			InitializedDatabases.GetOrAdd(Tuple.Create(_model, _internalConnection.ConnectionKey), (Tuple<DbCompiledModel, string> t) => new RetryAction<InternalContext>(action)).PerformAction(this);
		}
		finally
		{
			_inDatabaseInitialization = false;
		}
	}
}
