using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Resources;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     A LazyInternalConnection object manages information that can be used to create a DbConnection object and
///     is responsible for creating that object and disposing it.
/// </summary>
internal class LazyInternalConnection : InternalConnection
{
	private readonly string _nameOrConnectionString;

	private DbConnectionStringOrigin _connectionStringOrigin;

	private string _connectionStringName;

	private readonly DbConnectionInfo _connectionInfo;

	private bool? _hasModel;

	/// <summary>
	///     Returns the underlying DbConnection, creating it first if it does not already exist.
	/// </summary>
	public override DbConnection Connection
	{
		get
		{
			Initialize();
			return base.Connection;
		}
	}

	/// <summary>
	///     Returns the origin of the underlying connection string.
	/// </summary>
	public override DbConnectionStringOrigin ConnectionStringOrigin
	{
		get
		{
			Initialize();
			return _connectionStringOrigin;
		}
	}

	/// <inheritdoc />
	public override string ProviderName
	{
		get
		{
			Initialize();
			return base.ProviderName;
		}
		set
		{
			base.ProviderName = value;
		}
	}

	/// <summary>
	///     Gets the name of the underlying connection string.
	/// </summary>
	public override string ConnectionStringName
	{
		get
		{
			Initialize();
			return _connectionStringName;
		}
	}

	/// <summary>
	///     Returns a key consisting of the connection type and connection string.
	///     If this is an EntityConnection then the metadata path is included in the key returned.
	/// </summary>
	/// <value></value>
	public override string ConnectionKey
	{
		get
		{
			Initialize();
			return base.ConnectionKey;
		}
	}

	/// <summary>
	///     Gets a value indicating whether the connection is an EF connection which therefore contains
	///     metadata specifying the model, or instead is a store connection, in which case it contains no
	///     model info.
	/// </summary>
	/// <value><c>true</c> if connection contain model info; otherwise, <c>false</c>.</value>
	public override bool ConnectionHasModel
	{
		get
		{
			if (!_hasModel.HasValue)
			{
				if (base.UnderlyingConnection == null)
				{
					string nameOrConnectionString = _nameOrConnectionString;
					string name;
					if (_connectionInfo != null)
					{
						nameOrConnectionString = _connectionInfo.GetConnectionString(AppConfig).ConnectionString;
					}
					else if (DbHelpers.TryGetConnectionName(_nameOrConnectionString, out name))
					{
						ConnectionStringSettings connectionStringSettings = FindConnectionInConfig(name, AppConfig);
						if (connectionStringSettings == null && DbHelpers.TreatAsConnectionString(_nameOrConnectionString))
						{
							throw Error.DbContext_ConnectionStringNotFound(name);
						}
						if (connectionStringSettings != null)
						{
							nameOrConnectionString = connectionStringSettings.ConnectionString;
						}
					}
					_hasModel = DbHelpers.IsFullEFConnectionString(nameOrConnectionString);
				}
				else
				{
					_hasModel = base.UnderlyingConnection is EntityConnection;
				}
			}
			return _hasModel.Value;
		}
	}

	/// <summary>
	///     Gets a value indicating if the lazy connection has been initialized.
	/// </summary>
	internal bool IsInitialized => base.UnderlyingConnection != null;

	/// <summary>
	///     Creates a new LazyInternalConnection using convention to calculate the connection.  
	///     The DbConnection object will be created lazily on demand and will be disposed when the LazyInternalConnection is disposed.
	/// </summary>
	/// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
	public LazyInternalConnection(string nameOrConnectionString)
	{
		_nameOrConnectionString = nameOrConnectionString;
		AppConfig = AppConfig.DefaultInstance;
	}

	/// <summary>
	///     Creates a new LazyInternalConnection targeting a specific database.  
	///     The DbConnection object will be created lazily on demand and will be disposed when the LazyInternalConnection is disposed.
	/// </summary>
	/// <param name="connectionInfo">The connection to target.</param>
	public LazyInternalConnection(DbConnectionInfo connectionInfo)
	{
		_connectionInfo = connectionInfo;
		AppConfig = AppConfig.DefaultInstance;
	}

	/// <summary>
	///     Creates an <see cref="T:System.Data.Objects.ObjectContext" /> from metadata in the connection.  This method must
	///     only be called if ConnectionHasModel returns true.
	/// </summary>
	/// <returns>The newly created context.</returns>
	public override ObjectContext CreateObjectContextFromConnectionModel()
	{
		Initialize();
		return base.CreateObjectContextFromConnectionModel();
	}

	/// <summary>
	///     Disposes the underlying DbConnection.
	///     Note that dispose actually puts the LazyInternalConnection back to its initial state such that
	///     it can be used again.
	/// </summary>
	public override void Dispose()
	{
		if (base.UnderlyingConnection != null)
		{
			base.UnderlyingConnection.Dispose();
			base.UnderlyingConnection = null;
		}
	}

	/// <summary>
	///     Creates the underlying <see cref="T:System.Data.Common.DbConnection" /> (which may actually be an <see cref="T:System.Data.EntityClient.EntityConnection" />)
	///     if it does not already exist.
	/// </summary>
	private void Initialize()
	{
		if (base.UnderlyingConnection != null)
		{
			return;
		}
		string name;
		if (_connectionInfo != null)
		{
			ConnectionStringSettings connectionString = _connectionInfo.GetConnectionString(AppConfig);
			InitializeFromConnectionStringSetting(connectionString);
			_connectionStringOrigin = DbConnectionStringOrigin.DbContextInfo;
			_connectionStringName = connectionString.Name;
		}
		else if (!DbHelpers.TryGetConnectionName(_nameOrConnectionString, out name) || !TryInitializeFromAppConfig(name, AppConfig))
		{
			if (name != null && DbHelpers.TreatAsConnectionString(_nameOrConnectionString))
			{
				throw Error.DbContext_ConnectionStringNotFound(name);
			}
			if (DbHelpers.IsFullEFConnectionString(_nameOrConnectionString))
			{
				base.UnderlyingConnection = new EntityConnection(_nameOrConnectionString);
			}
			else if (base.ProviderName != null)
			{
				CreateConnectionFromProviderName(base.ProviderName);
			}
			else
			{
				IDbConnectionFactory dbConnectionFactory = (Database.DefaultConnectionFactoryChanged ? Database.DefaultConnectionFactory : AppConfig.DefaultConnectionFactory);
				base.UnderlyingConnection = dbConnectionFactory.CreateConnection(name ?? _nameOrConnectionString);
				if (base.UnderlyingConnection == null)
				{
					throw Error.DbContext_ConnectionFactoryReturnedNullConnection();
				}
			}
			if (name != null)
			{
				_connectionStringOrigin = DbConnectionStringOrigin.Convention;
				_connectionStringName = name;
			}
			else
			{
				_connectionStringOrigin = DbConnectionStringOrigin.UserCode;
			}
		}
		OnConnectionInitialized(base.UnderlyingConnection);
	}

	/// <summary>
	///     Searches the app.config/web.config file for a connection that matches the given name.
	///     The connection might be a store connection or an EF connection.
	/// </summary>
	/// <param name="name">The connection name.</param>
	/// <param name="connectionStrings"></param>
	/// <returns>True if a connection from the app.config file was found and used.</returns>
	private bool TryInitializeFromAppConfig(string name, AppConfig config)
	{
		ConnectionStringSettings connectionStringSettings = FindConnectionInConfig(name, config);
		if (connectionStringSettings != null)
		{
			InitializeFromConnectionStringSetting(connectionStringSettings);
			_connectionStringOrigin = DbConnectionStringOrigin.Configuration;
			_connectionStringName = connectionStringSettings.Name;
			return true;
		}
		return false;
	}

	/// <summary>
	///     Attempts to locate a connection entry in the configuration based on the supplied context name.
	/// </summary>
	/// <param name="name">The name to search for.</param>
	/// <param name="config">The configuration to search in.</param>
	/// <returns>Connection string if found, otherwise null.</returns>
	private static ConnectionStringSettings FindConnectionInConfig(string name, AppConfig config)
	{
		List<string> list = new List<string>();
		list.Add(name);
		List<string> list2 = list;
		int num = name.LastIndexOf('.');
		if (num >= 0 && num + 1 < name.Length)
		{
			list2.Add(name.Substring(num + 1));
		}
		return (from c in list2
			where config.GetConnectionString(c) != null
			select config.GetConnectionString(c)).FirstOrDefault();
	}

	/// <summary>
	/// Initializes the connection based on a connection string.
	/// </summary>
	/// <param name="appConfigConnection">The settings to initialize from.</param>
	private void InitializeFromConnectionStringSetting(ConnectionStringSettings appConfigConnection)
	{
		string providerName = appConfigConnection.ProviderName;
		if (string.IsNullOrWhiteSpace(providerName))
		{
			throw Error.DbContext_ProviderNameMissing(appConfigConnection.Name);
		}
		if (string.Equals(providerName, "System.Data.EntityClient", StringComparison.OrdinalIgnoreCase))
		{
			base.UnderlyingConnection = new EntityConnection(appConfigConnection.ConnectionString);
			return;
		}
		CreateConnectionFromProviderName(providerName);
		base.UnderlyingConnection.ConnectionString = appConfigConnection.ConnectionString;
	}

	private void CreateConnectionFromProviderName(string providerInvariantName)
	{
		DbProviderFactory factory = DbProviderFactories.GetFactory(providerInvariantName);
		base.UnderlyingConnection = factory.CreateConnection();
		if (base.UnderlyingConnection == null)
		{
			throw Error.DbContext_ProviderReturnedNullConnection();
		}
	}
}
