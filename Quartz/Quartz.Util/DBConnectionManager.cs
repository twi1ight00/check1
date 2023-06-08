using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Common.Logging;
using Quartz.Impl.AdoJobStore.Common;

namespace Quartz.Util;

/// <summary>
/// Manages a collection of IDbProviders, and provides transparent access
/// to their database.
/// </summary>
/// <seealso cref="T:Quartz.Impl.AdoJobStore.Common.IDbProvider" />
/// <author>James House</author>
/// <author>Sharada Jambula</author>
/// <author>Mohammad Rezaei</author>
/// <author>Marko Lahma (.NET)</author>
public class DBConnectionManager : IDbConnectionManager
{
	private static readonly DBConnectionManager instance = new DBConnectionManager();

	private static readonly ILog log = LogManager.GetLogger(typeof(DBConnectionManager));

	private readonly Dictionary<string, IDbProvider> providers = new Dictionary<string, IDbProvider>();

	/// <summary> 
	/// Get the class instance.
	/// </summary>
	/// <returns> an instance of this class
	/// </returns>
	public static IDbConnectionManager Instance => instance;

	/// <summary> 
	/// Private constructor
	/// </summary>
	private DBConnectionManager()
	{
	}

	/// <summary>
	/// Adds the connection provider.
	/// </summary>
	/// <param name="dataSourceName">Name of the data source.</param>
	/// <param name="provider">The provider.</param>
	public virtual void AddConnectionProvider(string dataSourceName, IDbProvider provider)
	{
		log.Info($"Registering datasource '{dataSourceName}' with db provider: '{provider}'");
		providers[dataSourceName] = provider;
	}

	/// <summary>
	/// Get a database connection from the DataSource with the given name.
	/// </summary>
	/// <returns> a database connection </returns>
	public virtual IDbConnection GetConnection(string dataSourceName)
	{
		IDbProvider provider = GetDbProvider(dataSourceName);
		return provider.CreateConnection();
	}

	/// <summary> 
	/// Shuts down database connections from the DataSource with the given name,
	/// if applicable for the underlying provider.
	/// </summary>
	public virtual void Shutdown(string dsName)
	{
		IDbProvider provider = GetDbProvider(dsName);
		provider.Shutdown();
	}

	public DbMetadata GetDbMetadata(string dsName)
	{
		return GetDbProvider(dsName).Metadata;
	}

	/// <summary>
	/// Gets the db provider.
	/// </summary>
	/// <param name="dsName">Name of the ds.</param>
	/// <returns></returns>
	public IDbProvider GetDbProvider(string dsName)
	{
		if (string.IsNullOrEmpty(dsName))
		{
			throw new ArgumentException("DataSource name cannot be null or empty", "dsName");
		}
		providers.TryGetValue(dsName, out var provider);
		if (provider == null)
		{
			throw new Exception(string.Format(CultureInfo.InvariantCulture, "There is no DataSource named '{0}'", new object[1] { dsName }));
		}
		return provider;
	}
}
