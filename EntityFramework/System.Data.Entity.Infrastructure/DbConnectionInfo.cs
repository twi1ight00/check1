using System.ComponentModel;
using System.Configuration;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure;

/// <summary>
/// Represents information about a database connection.
/// </summary>
[Serializable]
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public class DbConnectionInfo
{
	private readonly string _connectionName;

	private readonly string _connectionString;

	private readonly string _providerInvariantName;

	/// <summary>
	/// Creates a new instance of DbConnectionInfo representing a connection that is specified in the application configuration file.
	/// </summary>
	/// <param name="connectionName">The name of the connection string in the application configuration.</param>
	public DbConnectionInfo(string connectionName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(connectionName), null, "!string.IsNullOrWhiteSpace(connectionName)");
		base._002Ector();
		_connectionName = connectionName;
	}

	/// <summary>
	/// Creates a new instance of DbConnectionInfo based on a connection string.
	/// </summary>
	/// <param name="connectionString">The connection string to use for the connection.</param>
	/// <param name="providerInvariantName">The name of the provider to use for the connection. Use 'System.Data.SqlClient' for SQL Server.</param>
	public DbConnectionInfo(string connectionString, string providerInvariantName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(connectionString), null, "!string.IsNullOrWhiteSpace(connectionString)");
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerInvariantName), null, "!string.IsNullOrWhiteSpace(providerInvariantName)");
		base._002Ector();
		_connectionString = connectionString;
		_providerInvariantName = providerInvariantName;
	}

	/// <summary>
	/// Gets the connection information represented by this instance.
	/// </summary>
	/// <param name="config">Configuration to use if connection comes from the configuration file.</param>
	internal ConnectionStringSettings GetConnectionString(AppConfig config)
	{
		if (_connectionName != null)
		{
			ConnectionStringSettings connectionString = config.GetConnectionString(_connectionName);
			if (connectionString == null)
			{
				throw Error.DbConnectionInfo_ConnectionStringNotFound(_connectionName);
			}
			return connectionString;
		}
		return new ConnectionStringSettings(null, _connectionString, _providerInvariantName);
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
}
