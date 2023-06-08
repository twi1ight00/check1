using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Text;
using Quartz.Util;

namespace Quartz.Impl.AdoJobStore.Common;

/// <summary>
/// Concrete implementation of <see cref="T:Quartz.Impl.AdoJobStore.Common.IDbProvider" />.
/// </summary>
/// <author>Marko Lahma</author>
public class DbProvider : IDbProvider
{
	protected const string PropertyDbProvider = "quartz.dbprovider";

	protected const string DbProviderResourceName = "Quartz.Impl.AdoJobStore.Common.dbproviders.properties";

	private string connectionString;

	private readonly DbMetadata dbMetadata;

	private static readonly Dictionary<string, DbMetadata> dbMetadataLookup;

	private static readonly DbMetadata notInitializedMetadata;

	/// <summary>
	/// Connection string used to create connections.
	/// </summary>
	/// <value></value>
	public virtual string ConnectionString
	{
		get
		{
			return connectionString;
		}
		set
		{
			connectionString = value;
		}
	}

	/// <summary>
	/// Gets the metadata.
	/// </summary>
	/// <value>The metadata.</value>
	public virtual DbMetadata Metadata => dbMetadata;

	/// <summary>
	/// Parse metadata once in static constructor.
	/// </summary>
	static DbProvider()
	{
		dbMetadataLookup = new Dictionary<string, DbMetadata>();
		notInitializedMetadata = new DbMetadata();
		PropertiesParser pp = PropertiesParser.ReadFromEmbeddedAssemblyResource("Quartz.Impl.AdoJobStore.Common.dbproviders.properties");
		IList<string> providers = pp.GetPropertyGroups("quartz.dbprovider");
		foreach (string providerName in providers)
		{
			dbMetadataLookup[providerName] = notInitializedMetadata;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.AdoJobStore.Common.DbProvider" /> class.
	/// </summary>
	/// <param name="dbProviderName">Name of the db provider.</param>
	/// <param name="connectionString">The connection string.</param>
	public DbProvider(string dbProviderName, string connectionString)
	{
		List<string> deprecatedProviders = new List<string> { "Npgsql-10", "SqlServer-11" };
		if (deprecatedProviders.Contains(dbProviderName))
		{
			throw new InvalidConfigurationException(dbProviderName + " provider is no longer supported.");
		}
		this.connectionString = connectionString;
		dbMetadata = GetDbMetadata(dbProviderName);
		if (dbMetadata == null)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid DB provider name: {0}{1}{2}", new object[3]
			{
				dbProviderName,
				Environment.NewLine,
				GenerateValidProviderNamesInfo()
			}));
		}
	}

	public void Initialize()
	{
	}

	/// <summary>
	///  Registers DB metadata information for given provider name.
	/// </summary>
	/// <param name="dbProviderName"></param>
	/// <param name="metadata"></param>
	public static void RegisterDbMetadata(string dbProviderName, DbMetadata metadata)
	{
		dbMetadataLookup[dbProviderName] = metadata;
	}

	protected virtual DbMetadata GetDbMetadata(string providerName)
	{
		dbMetadataLookup.TryGetValue(providerName, out var data);
		if (data == notInitializedMetadata)
		{
			try
			{
				PropertiesParser pp = PropertiesParser.ReadFromEmbeddedAssemblyResource("Quartz.Impl.AdoJobStore.Common.dbproviders.properties");
				DbMetadata metadata = new DbMetadata();
				NameValueCollection props = pp.GetPropertyGroup("quartz.dbprovider." + providerName, stripPrefix: true);
				ObjectUtils.SetObjectProperties(metadata, props);
				metadata.Init();
				RegisterDbMetadata(providerName, metadata);
				return metadata;
			}
			catch (Exception ex)
			{
				throw new Exception("Error while reading metadata information for provider '" + providerName + "'", ex);
			}
		}
		return data;
	}

	protected static string GenerateValidProviderNamesInfo()
	{
		StringBuilder sb = new StringBuilder("Valid DB Provider names are:").Append(Environment.NewLine);
		foreach (string providerName in dbMetadataLookup.Keys)
		{
			sb.Append("\t").Append(providerName).Append(Environment.NewLine);
		}
		return sb.ToString();
	}

	/// <summary>
	/// Returns a new command object for executing SQL statments/Stored Procedures
	/// against the database.
	/// </summary>
	/// <returns>An new <see cref="T:System.Data.IDbCommand" /></returns>
	public virtual IDbCommand CreateCommand()
	{
		return ObjectUtils.InstantiateType<IDbCommand>(dbMetadata.CommandType);
	}

	/// <summary>
	/// Returns a new instance of the providers CommandBuilder class.
	/// </summary>
	/// <returns>A new Command Builder</returns>
	/// <remarks>In .NET 1.1 there was no common base class or interface
	/// for command builders, hence the return signature is object to
	/// be portable (but more loosely typed) across .NET 1.1/2.0</remarks>
	public virtual object CreateCommandBuilder()
	{
		return ObjectUtils.InstantiateType<object>(dbMetadata.CommandBuilderType);
	}

	/// <summary>
	/// Returns a new connection object to communicate with the database.
	/// </summary>
	/// <returns>A new <see cref="T:System.Data.IDbConnection" /></returns>
	public virtual IDbConnection CreateConnection()
	{
		IDbConnection conn = ObjectUtils.InstantiateType<IDbConnection>(dbMetadata.ConnectionType);
		conn.ConnectionString = ConnectionString;
		return conn;
	}

	/// <summary>
	/// Returns a new parameter object for binding values to parameter
	/// placeholders in SQL statements or Stored Procedure variables.
	/// </summary>
	/// <returns>A new <see cref="T:System.Data.IDbDataParameter" /></returns>
	public virtual IDbDataParameter CreateParameter()
	{
		return ObjectUtils.InstantiateType<IDbDataParameter>(dbMetadata.ParameterType);
	}

	/// <summary>
	/// Shutdowns this instance.
	/// </summary>
	public virtual void Shutdown()
	{
	}
}
