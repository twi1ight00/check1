using System.Data.Common;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;

namespace System.Data.Entity.Infrastructure;

/// <summary>
///     Instances of this class are used to create DbConnection objects for
///     SQL Server Compact Edition based on a given database name or connection string.
/// </summary>
/// <remarks>
///     It is necessary to provide the provider invariant name of the SQL Server Compact
///     Edition to use when creating an instance of this class.  This is because different
///     versions of SQL Server Compact Editions use different invariant names.
///     An instance of this class can be set on the <see cref="T:System.Data.Entity.Database" /> class to
///     cause all DbContexts created with no connection information or just a database
///     name or connection string to use SQL Server Compact Edition by default.
///     This class is immutable since multiple threads may access instances simultaneously
///     when creating connections.
/// </remarks>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public sealed class SqlCeConnectionFactory : IDbConnectionFactory
{
	private readonly string _databaseDirectory;

	private readonly string _baseConnectionString;

	private readonly string _providerInvariantName;

	/// <summary>
	///     The path to prepend to the database name that will form the file name used by
	///     SQL Server Compact Edition when it creates or reads the database file.
	///     The default value is "|DataDirectory|", which means the file will be placed
	///     in the designated data directory.
	/// </summary>
	public string DatabaseDirectory => _databaseDirectory;

	/// <summary>
	///     The connection string to use for options to the database other than the 'Data Source'.
	///     The Data Source will be prepended to this string based on the database name when
	///     CreateConnection is called.
	///     The default is the empty string, which means no other options will be used.
	/// </summary>
	public string BaseConnectionString => _baseConnectionString;

	/// <summary>
	///     The provider invariant name that specifies the version of SQL Server Compact Edition
	///     that should be used.
	/// </summary>
	public string ProviderInvariantName => _providerInvariantName;

	/// <summary>
	///     Creates a new connection factory with empty (default) DatabaseDirectory and BaseConnectionString
	///     properties.
	/// </summary>
	/// <param name="providerInvariantName">The provider invariant name that specifies the version of SQL Server Compact Edition that should be used.</param>
	public SqlCeConnectionFactory(string providerInvariantName)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerInvariantName), null, "!String.IsNullOrWhiteSpace(providerInvariantName)");
		base._002Ector();
		_providerInvariantName = providerInvariantName;
		_databaseDirectory = "|DataDirectory|";
		_baseConnectionString = "";
	}

	/// <summary>
	///     Creates a new connection factory with the given DatabaseDirectory and BaseConnectionString properties.
	/// </summary>
	/// <param name="providerInvariantName">
	///     The provider invariant name that specifies the version of SQL Server Compact Edition that should be used.
	/// </param>
	/// <param name="databaseDirectory">
	///     The path to prepend to the database name that will form the file name used by SQL Server Compact Edition
	///     when it creates or reads the database file. An empty string means that SQL Server Compact Edition will use
	///     its default for the database file location.
	/// </param>
	/// <param name="baseConnectionString">
	///     The connection string to use for options to the database other than the 'Data Source'. The Data Source will
	///     be prepended to this string based on the database name when CreateConnection is called.
	/// </param>
	public SqlCeConnectionFactory(string providerInvariantName, string databaseDirectory, string baseConnectionString)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(providerInvariantName), null, "!String.IsNullOrWhiteSpace(providerInvariantName)");
		RuntimeFailureMethods.Requires(databaseDirectory != null, null, "databaseDirectory != null");
		RuntimeFailureMethods.Requires(baseConnectionString != null, null, "baseConnectionString != null");
		base._002Ector();
		_providerInvariantName = providerInvariantName;
		_databaseDirectory = databaseDirectory;
		_baseConnectionString = baseConnectionString;
	}

	/// <summary>
	///     Creates a connection for SQL Server Compact Edition based on the given database name or connection string.
	///     If the given string contains an '=' character then it is treated as a full connection string,
	///     otherwise it is treated as a database name only.
	/// </summary>
	/// <param name="nameOrConnectionString">The database name or connection string.</param>
	/// <returns>An initialized DbConnection.</returns>
	public DbConnection CreateConnection(string nameOrConnectionString)
	{
		RuntimeFailureMethods.Requires(!string.IsNullOrWhiteSpace(nameOrConnectionString), null, "!String.IsNullOrWhiteSpace(nameOrConnectionString)");
		DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderInvariantName);
		DbConnection dbConnection = factory.CreateConnection();
		if (dbConnection == null)
		{
			throw Error.DbContext_ProviderReturnedNullConnection();
		}
		if (DbHelpers.TreatAsConnectionString(nameOrConnectionString))
		{
			dbConnection.ConnectionString = nameOrConnectionString;
		}
		else
		{
			string text = nameOrConnectionString;
			bool ignoreCase = true;
			CultureInfo culture = null;
			if (!text.EndsWith(".sdf", ignoreCase, culture))
			{
				nameOrConnectionString += ".sdf";
			}
			string text2 = ((DatabaseDirectory.StartsWith("|", StringComparison.Ordinal) && DatabaseDirectory.EndsWith("|", StringComparison.Ordinal)) ? (DatabaseDirectory + nameOrConnectionString) : Path.Combine(DatabaseDirectory, nameOrConnectionString));
			dbConnection.ConnectionString = string.Format(CultureInfo.InvariantCulture, "Data Source={0}; {1}", new object[2] { text2, BaseConnectionString });
		}
		return dbConnection;
	}
}
