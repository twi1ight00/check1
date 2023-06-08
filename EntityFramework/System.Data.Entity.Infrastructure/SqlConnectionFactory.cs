using System.Data.Common;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Instances of this class are used to create DbConnection objects for
///     SQL Server based on a given database name or connection string. By default, the connection is
///     made to '.\SQLEXPRESS'.  This can be changed by changing the base connection
///     string when constructing a factory instance.
/// </summary>
/// <remarks>
///     An instance of this class can be set on the <see cref="T:System.Data.Entity.Database" /> class to
///     cause all DbContexts created with no connection information or just a database
///     name or connection string to use SQL Server by default.
///     This class is immutable since multiple threads may access instances simultaneously
///     when creating connections.
/// </remarks>
public sealed class SqlConnectionFactory : IDbConnectionFactory
{
	private readonly string _baseConnectionString;

	private Func<string, DbProviderFactory> _providerFactoryCreator;

	/// <summary>
	///     The connection string to use for options to the database other than the 'Initial Catalog'.
	///     The 'Initial Catalog' will  be prepended to this string based on the database name when
	///     CreateConnection is called.
	///     The default is 'Data Source=.\SQLEXPRESS; Integrated Security=True; MultipleActiveResultSets=True'.
	/// </summary>
	public string BaseConnectionString => _baseConnectionString;

	/// <summary>
	///     Remove hard dependency on DbProviderFactories.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	internal Func<string, DbProviderFactory> ProviderFactory
	{
		get
		{
			return _providerFactoryCreator ?? ((Func<string, DbProviderFactory>)((string name) => DbProviderFactories.GetFactory(name)));
		}
		set
		{
			_providerFactoryCreator = value;
		}
	}

	/// <summary>
	///     Creates a new connection factory with a default BaseConnectionString property of
	///     'Data Source=.\SQLEXPRESS; Integrated Security=True; MultipleActiveResultSets=True'.
	/// </summary>
	public SqlConnectionFactory()
	{
		_baseConnectionString = "Data Source=.\\SQLEXPRESS; Integrated Security=True; MultipleActiveResultSets=True";
	}

	/// <summary>
	///     Creates a new connection factory with the given BaseConnectionString property.
	/// </summary>
	/// <param name="baseConnectionString">
	///     The connection string to use for options to the database other than the 'Initial Catalog'. The 'Initial Catalog' will
	///     be prepended to this string based on the database name when CreateConnection is called.
	/// </param>
	public SqlConnectionFactory(string baseConnectionString)
	{
		RuntimeFailureMethods.Requires(baseConnectionString != null, null, "baseConnectionString != null");
		base._002Ector();
		_baseConnectionString = baseConnectionString;
	}

	/// <summary>
	///     Creates a connection for SQL Server based on the given database name or connection string.
	///     If the given string contains an '=' character then it is treated as a full connection string,
	///     otherwise it is treated as a database name only.
	/// </summary>
	/// <param name="nameOrConnectionString">The database name or connection string.</param>
	/// <returns>An initialized DbConnection.</returns>
	public DbConnection CreateConnection(string nameOrConnectionString)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(nameOrConnectionString), null, "!String.IsNullOrWhiteSpace(nameOrConnectionString)");
		string connectionString = nameOrConnectionString;
		if (!DbHelpers.TreatAsConnectionString(nameOrConnectionString))
		{
			bool ignoreCase = true;
			CultureInfo culture = null;
			if (nameOrConnectionString.EndsWith(".mdf", ignoreCase, culture))
			{
				throw Error.SqlConnectionFactory_MdfNotSupported(nameOrConnectionString);
			}
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(BaseConnectionString);
			sqlConnectionStringBuilder.InitialCatalog = nameOrConnectionString;
			connectionString = sqlConnectionStringBuilder.ConnectionString;
		}
		DbConnection dbConnection = null;
		try
		{
			dbConnection = ProviderFactory("System.Data.SqlClient").CreateConnection();
			dbConnection.ConnectionString = connectionString;
		}
		catch
		{
			dbConnection = new SqlConnection(connectionString);
		}
		return dbConnection;
	}
}
