using System.Configuration;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Provides runtime information about a given <see cref="T:System.Data.Entity.DbContext" /> type.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public class DbContextInfo
{
	private readonly Type _contextType;

	private readonly DbProviderInfo _modelProviderInfo;

	private readonly DbConnectionInfo _connectionInfo;

	private readonly AppConfig _appConfig;

	private readonly Func<DbContext> _activator;

	private readonly string _connectionString;

	private readonly string _connectionProviderName;

	private readonly bool _isConstructible;

	private readonly DbConnectionStringOrigin _connectionStringOrigin;

	private readonly string _connectionStringName;

	private Action<DbModelBuilder> _onModelCreating;

	/// <summary>
	///     The concrete <see cref="T:System.Data.Entity.DbContext" /> type.
	/// </summary>
	public virtual Type ContextType => _contextType;

	/// <summary>
	///     Whether or not instances of the underlying <see cref="T:System.Data.Entity.DbContext" /> type can be created.
	/// </summary>
	public virtual bool IsConstructible => _isConstructible;

	/// <summary>
	///     The connection string used by the underlying <see cref="T:System.Data.Entity.DbContext" /> type.
	/// </summary>
	public virtual string ConnectionString => _connectionString;

	/// <summary>
	///     The connection string name used by the underlying <see cref="T:System.Data.Entity.DbContext" /> type.
	/// </summary>
	public virtual string ConnectionStringName => _connectionStringName;

	/// <summary>
	///     The ADO.NET provider name of the connection used by the underlying <see cref="T:System.Data.Entity.DbContext" /> type.
	/// </summary>
	public virtual string ConnectionProviderName => _connectionProviderName;

	/// <summary>
	///     The origin of the connection string used by the underlying <see cref="T:System.Data.Entity.DbContext" /> type.
	/// </summary>
	public virtual DbConnectionStringOrigin ConnectionStringOrigin => _connectionStringOrigin;

	/// <summary>
	///     An action to be run on the DbModelBuilder after OnModelCreating has been run on the context.
	/// </summary>
	public virtual Action<DbModelBuilder> OnModelCreating
	{
		get
		{
			return _onModelCreating;
		}
		set
		{
			RuntimeFailureMethods.Requires(value != null, null, "value != null");
			_onModelCreating = value;
		}
	}

	/// <summary>
	///     Creates a new instance representing a given <see cref="T:System.Data.Entity.DbContext" /> type.
	/// </summary>
	/// <param name="contextType">The type deriving from <see cref="T:System.Data.Entity.DbContext" />.</param>
	public DbContextInfo(Type contextType)
	{
		RuntimeFailureMethods.Requires(contextType != null, null, "contextType != null");
		this._002Ector(contextType, null, AppConfig.DefaultInstance, null);
	}

	/// <summary>
	///     Creates a new instance representing a given <see cref="T:System.Data.Entity.DbContext" /> targeting a specific database.
	/// </summary>
	/// <param name="contextType">The type deriving from <see cref="T:System.Data.Entity.DbContext" />.</param>
	/// <param name="connectionInfo">Connection information for the database to be used.</param>
	public DbContextInfo(Type contextType, DbConnectionInfo connectionInfo)
	{
		RuntimeFailureMethods.Requires(contextType != null, null, "contextType != null");
		RuntimeFailureMethods.Requires(connectionInfo != null, null, "connectionInfo != null");
		this._002Ector(contextType, null, AppConfig.DefaultInstance, connectionInfo);
	}

	/// <summary>
	///     Creates a new instance representing a given <see cref="T:System.Data.Entity.DbContext" /> type. An external list of 
	///     connection strings can be supplied and will be used during connection string resolution in place
	///     of any connection strings specified in external configuration files.
	/// </summary>
	/// <remarks>
	/// It is preferable to use the constructor that accepts the entire config document instead of using this
	/// constructor. Providing the entire config document allows DefaultConnectionFactroy entries in the config
	/// to be found in addition to explicitly specified connection strings.
	/// </remarks>
	/// <param name="contextType">The type deriving from <see cref="T:System.Data.Entity.DbContext" />.</param>
	/// <param name="connectionStringSettings">A collection of connection strings.</param>
	[Obsolete("The application configuration can contain multiple settings that affect the connection used by a DbContext. To ensure all configuration is taken into account, use a DbContextInfo constructor that accepts System.Configuration.Configuration")]
	public DbContextInfo(Type contextType, ConnectionStringSettingsCollection connectionStringSettings)
	{
		RuntimeFailureMethods.Requires(contextType != null, null, "contextType != null");
		RuntimeFailureMethods.Requires(connectionStringSettings != null, null, "connectionStringSettings != null");
		this._002Ector(contextType, null, new AppConfig(connectionStringSettings), null);
	}

	/// <summary>
	///     Creates a new instance representing a given <see cref="T:System.Data.Entity.DbContext" /> type. An external config 
	///     object (e.g. app.config or web.config) can be supplied and will be used during connection string
	///     resolution. This includes looking for connection strings and DefaultConnectionFactory entries.
	/// </summary>
	/// <param name="contextType">The type deriving from <see cref="T:System.Data.Entity.DbContext" />.</param>
	/// <param name="config">An object representing the config file.</param>
	public DbContextInfo(Type contextType, System.Configuration.Configuration config)
	{
		RuntimeFailureMethods.Requires(contextType != null, null, "contextType != null");
		RuntimeFailureMethods.Requires(config != null, null, "config != null");
		this._002Ector(contextType, null, new AppConfig(config), null);
	}

	/// <summary>
	///     Creates a new instance representing a given <see cref="T:System.Data.Entity.DbContext" />, targeting a specific database.
	///     An external config object (e.g. app.config or web.config) can be supplied and will be used during connection string
	///     resolution. This includes looking for connection strings and DefaultConnectionFactory entries.
	/// </summary>
	/// <param name="contextType">The type deriving from <see cref="T:System.Data.Entity.DbContext" />.</param>
	/// <param name="config">An object representing the config file.</param>
	/// <param name="connectionInfo">Connection information for the database to be used.</param>
	public DbContextInfo(Type contextType, System.Configuration.Configuration config, DbConnectionInfo connectionInfo)
	{
		RuntimeFailureMethods.Requires(contextType != null, null, "contextType != null");
		RuntimeFailureMethods.Requires(config != null, null, "config != null");
		RuntimeFailureMethods.Requires(connectionInfo != null, null, "connectionInfo != null");
		this._002Ector(contextType, null, new AppConfig(config), connectionInfo);
	}

	/// <summary>
	///     Creates a new instance representing a given <see cref="T:System.Data.Entity.DbContext" /> type.  A <see cref="T:System.Data.Entity.Infrastructure.DbProviderInfo" />
	///     can be supplied in order to override the default determined provider used when constructing
	///     the underlying EDM model.
	/// </summary>
	/// <param name="contextType">The type deriving from <see cref="T:System.Data.Entity.DbContext" />.</param>
	/// <param name="modelProviderInfo">A <see cref="T:System.Data.Entity.Infrastructure.DbProviderInfo" /> specifying the underlying ADO.NET provider to target.</param>
	public DbContextInfo(Type contextType, DbProviderInfo modelProviderInfo)
	{
		RuntimeFailureMethods.Requires(contextType != null, null, "contextType != null");
		RuntimeFailureMethods.Requires(modelProviderInfo != null, null, "modelProviderInfo != null");
		this._002Ector(contextType, modelProviderInfo, AppConfig.DefaultInstance, null);
	}

	/// <summary>
	/// Called internally when a context info is needed for an existing context, which may not be constructable.
	/// </summary>
	/// <param name="context">The context instance to get info from.</param>
	internal DbContextInfo(DbContext context)
	{
		_contextType = context.GetType();
		_appConfig = AppConfig.DefaultInstance;
		InternalContext internalContext = context.InternalContext;
		_connectionProviderName = internalContext.ProviderName;
		_connectionInfo = new DbConnectionInfo(internalContext.OriginalConnectionString, _connectionProviderName);
		_connectionString = internalContext.OriginalConnectionString;
		_connectionStringName = internalContext.ConnectionStringName;
		_connectionStringOrigin = internalContext.ConnectionStringOrigin;
	}

	private DbContextInfo(Type contextType, DbProviderInfo modelProviderInfo, AppConfig config, DbConnectionInfo connectionInfo)
	{
		if (!typeof(DbContext).IsAssignableFrom(contextType))
		{
			throw new ArgumentOutOfRangeException("contextType");
		}
		_contextType = contextType;
		_modelProviderInfo = modelProviderInfo;
		_appConfig = config;
		_connectionInfo = connectionInfo;
		_activator = CreateActivator();
		if (_activator == null)
		{
			return;
		}
		DbContext dbContext = _activator();
		if (dbContext != null)
		{
			_isConstructible = true;
			using (dbContext)
			{
				ConfigureContext(dbContext);
				_connectionString = dbContext.InternalContext.Connection.ConnectionString;
				_connectionStringName = dbContext.InternalContext.ConnectionStringName;
				_connectionProviderName = dbContext.InternalContext.ProviderName;
				_connectionStringOrigin = dbContext.InternalContext.ConnectionStringOrigin;
			}
		}
	}

	/// <summary>
	///     If instances of the underlying <see cref="T:System.Data.Entity.DbContext" /> type can be created, returns
	///     a new instance; otherwise returns null.
	/// </summary>
	/// <returns>A <see cref="T:System.Data.Entity.DbContext" /> instance.</returns>
	public virtual DbContext CreateInstance()
	{
		if (!IsConstructible)
		{
			return null;
		}
		DbContext dbContext = _activator();
		ConfigureContext(dbContext);
		return dbContext;
	}

	private void ConfigureContext(DbContext context)
	{
		if (_modelProviderInfo != null)
		{
			context.InternalContext.ModelProviderInfo = _modelProviderInfo;
		}
		context.InternalContext.AppConfig = _appConfig;
		if (_connectionInfo != null)
		{
			context.InternalContext.OverrideConnection(new LazyInternalConnection(_connectionInfo));
		}
		if (_onModelCreating != null)
		{
			context.InternalContext.OnModelCreating = _onModelCreating;
		}
	}

	private Func<DbContext> CreateActivator()
	{
		ConstructorInfo constructor = _contextType.GetConstructor(Type.EmptyTypes);
		if (constructor != null)
		{
			return () => (DbContext)Activator.CreateInstance(_contextType);
		}
		Type type = (from t in _contextType.Assembly.GetTypes()
			where t.IsClass && typeof(IDbContextFactory<>).MakeGenericType(_contextType).IsAssignableFrom(t)
			select t).FirstOrDefault();
		if (type == null)
		{
			return null;
		}
		if (type.GetConstructor(Type.EmptyTypes) == null)
		{
			throw Error.DbContextServices_MissingDefaultCtor(type);
		}
		IDbContextFactory<DbContext> dbContextFactory = (IDbContextFactory<DbContext>)Activator.CreateInstance(type);
		return dbContextFactory.Create;
	}
}
