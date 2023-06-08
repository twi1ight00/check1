using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     InternalConnection objects manage DbConnections.
///     Two concrete base classes of this abstract interface exist:<see cref="T:System.Data.Entity.Internal.LazyInternalConnection" />
///     and <see cref="T:System.Data.Entity.Internal.EagerInternalConnection" />.
/// </summary>
internal abstract class InternalConnection : IInternalConnection, IDisposable
{
	private string _key;

	private string _providerName;

	/// <summary>
	///     Returns the underlying DbConnection.
	/// </summary>
	public virtual DbConnection Connection
	{
		get
		{
			if (!(UnderlyingConnection is EntityConnection entityConnection))
			{
				return UnderlyingConnection;
			}
			return entityConnection.StoreConnection;
		}
	}

	/// <summary>
	///     Returns a key consisting of the connection type and connection string.
	///     If this is an EntityConnection then the metadata path is included in the key returned.
	/// </summary>
	/// <value></value>
	public virtual string ConnectionKey => _key ?? (_key = string.Format(CultureInfo.InvariantCulture, "{0};{1}", new object[2]
	{
		UnderlyingConnection.GetType(),
		UnderlyingConnection.ConnectionString
	}));

	/// <summary>
	///     Gets a value indicating whether the connection is an EF connection which therefore contains
	///     metadata specifying the model, or instead is a store connection, in which case it contains no
	///     model info.
	/// </summary>
	/// <value><c>true</c> if the connection contains model info; otherwise, <c>false</c>.</value>
	public virtual bool ConnectionHasModel => UnderlyingConnection is EntityConnection;

	/// <summary>
	///     Returns the origin of the underlying connection string.
	/// </summary>
	public abstract DbConnectionStringOrigin ConnectionStringOrigin { get; }

	/// <summary>
	///     Gets or sets an object representing a config file used for looking for DefaultConnectionFactory entries
	///     and connection strins.
	/// </summary>
	public virtual AppConfig AppConfig { get; set; }

	/// <summary>
	///     Gets or sets the provider to be used when creating the underlying connection.
	/// </summary>
	public virtual string ProviderName
	{
		get
		{
			return _providerName ?? (_providerName = ((UnderlyingConnection == null) ? null : Connection.GetProviderInvariantName()));
		}
		set
		{
			_providerName = value;
		}
	}

	/// <summary>
	///     Gets the name of the underlying connection string.
	/// </summary>
	public virtual string ConnectionStringName => null;

	/// <summary>
	///     Gets the original connection string.
	/// </summary>
	public string OriginalConnectionString { get; private set; }

	/// <summary>
	///     Gets or sets the underlying <see cref="T:System.Data.Common.DbConnection" /> object.  No initialization is done when the
	///     connection is obtained, and it can also be set to null.
	/// </summary>
	/// <value>The underlying connection.</value>
	protected DbConnection UnderlyingConnection { get; set; }

	/// <summary>
	///     Creates an <see cref="T:System.Data.Objects.ObjectContext" /> from metadata in the connection.  This method must
	///     only be called if ConnectionHasModel returns true.
	/// </summary>
	/// <returns>The newly created context.</returns>
	public virtual ObjectContext CreateObjectContextFromConnectionModel()
	{
		ObjectContext objectContext = new ObjectContext((EntityConnection)UnderlyingConnection);
		ReadOnlyCollection<EntityContainer> items = objectContext.MetadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace);
		if (items.Count == 1)
		{
			objectContext.DefaultContainerName = items.Single().Name;
		}
		return objectContext;
	}

	/// <summary>
	///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	/// </summary>
	public abstract void Dispose();

	/// <summary>
	///     Called after the connection is initialized for the first time.
	/// </summary>
	protected void OnConnectionInitialized(DbConnection connection)
	{
		OriginalConnectionString = AddAppNameCookieToConnectionString(connection);
	}

	/// <summary>
	///     Adds a tracking cookie to the connection string for SqlConnections. Returns the
	///     possibly modified store connection string.
	/// </summary>
	public static string AddAppNameCookieToConnectionString(DbConnection connection)
	{
		string result = connection.ConnectionString;
		if (connection is EntityConnection entityConnection)
		{
			connection = entityConnection.StoreConnection;
			result = connection?.ConnectionString;
		}
		if (connection is SqlConnection && connection.State == ConnectionState.Closed)
		{
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connection.ConnectionString);
			if ((string.IsNullOrWhiteSpace(sqlConnectionStringBuilder.ApplicationName) || string.Equals(sqlConnectionStringBuilder.ApplicationName, ".Net SqlClient Data Provider", StringComparison.OrdinalIgnoreCase)) && (sqlConnectionStringBuilder.IntegratedSecurity || !string.IsNullOrEmpty(sqlConnectionStringBuilder.Password)))
			{
				sqlConnectionStringBuilder.ApplicationName = "EntityFrameworkMUE";
				connection.ConnectionString = sqlConnectionStringBuilder.ToString();
				result = connection.ConnectionString;
			}
		}
		return result;
	}
}
