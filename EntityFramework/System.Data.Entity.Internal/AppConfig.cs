using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Internal.ConfigFile;
using System.Data.Entity.Resources;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
/// A simple representation of an app.config or web.config file.
/// </summary>
internal class AppConfig
{
	private const string _efSectionName = "entityFramework";

	private static readonly AppConfig _defaultInstance = new AppConfig();

	private readonly KeyValueConfigurationCollection _appSettings;

	private readonly ConnectionStringSettingsCollection _connectionStrings;

	private readonly EntityFrameworkSection _entityFrameworkSettings;

	private readonly Lazy<IDbConnectionFactory> _defaultConnectionFactory;

	private readonly Lazy<IDbConnectionFactory> _defaultDefaultConnectionFactory = new Lazy<IDbConnectionFactory>(() => new SqlConnectionFactory(), isThreadSafe: true);

	private static bool _initializersApplied;

	private static readonly object Lock = new object();

	private static readonly MethodInfo Database_SetInitializerInternal = typeof(Database).GetMethod("SetInitializerInternal", BindingFlags.Static | BindingFlags.NonPublic);

	/// <summary>
	/// Gets the default connection factory based on the configuration
	/// </summary>
	public IDbConnectionFactory DefaultConnectionFactory => _defaultConnectionFactory.Value;

	/// <summary>
	/// Gets a singleton instance of configuration based on the <see cref="T:System.Configuration.ConfigurationManager" /> for the AppDomain
	/// </summary>
	public static AppConfig DefaultInstance => _defaultInstance;

	/// <summary>
	/// Initializes a new instance of AppConfig based on supplied configuration
	/// </summary>
	/// <param name="configuration">Configuration to load settings from</param>
	public AppConfig(System.Configuration.Configuration configuration)
		: this(configuration.ConnectionStrings.ConnectionStrings, configuration.AppSettings.Settings, (EntityFrameworkSection)configuration.GetSection("entityFramework"))
	{
	}

	/// <summary>
	/// Initializes a new instance of AppConfig based on supplied connection strings
	/// The default configuration for database initializers and default connection factory will be used
	/// </summary>
	/// <param name="connectionStrings">Connection strings to be used</param>
	public AppConfig(ConnectionStringSettingsCollection connectionStrings)
		: this(connectionStrings, null, null)
	{
	}

	/// <summary>
	/// Initializes a new instance of AppConfig based on the <see cref="T:System.Configuration.ConfigurationManager" /> for the AppDomain
	/// </summary>
	/// <remarks>
	/// Use AppConfig.DefaultInstance instead of this constructor
	/// </remarks>
	private AppConfig()
		: this(ConfigurationManager.ConnectionStrings, Convert(ConfigurationManager.AppSettings), (EntityFrameworkSection)ConfigurationManager.GetSection("entityFramework"))
	{
	}

	private AppConfig(ConnectionStringSettingsCollection connectionStrings, KeyValueConfigurationCollection appSettings, EntityFrameworkSection entityFrameworkSettings)
	{
		_connectionStrings = connectionStrings;
		_appSettings = appSettings;
		_entityFrameworkSettings = entityFrameworkSettings ?? new EntityFrameworkSection();
		if (_entityFrameworkSettings.DefaultConnectionFactory.ElementInformation.IsPresent)
		{
			bool isThreadSafe = true;
			_defaultConnectionFactory = new Lazy<IDbConnectionFactory>(delegate
			{
				DefaultConnectionFactoryElement defaultConnectionFactory = _entityFrameworkSettings.DefaultConnectionFactory;
				try
				{
					Type factoryType = defaultConnectionFactory.GetFactoryType();
					object[] typedParameterValues = defaultConnectionFactory.Parameters.GetTypedParameterValues();
					return (IDbConnectionFactory)Activator.CreateInstance(factoryType, typedParameterValues);
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException(Strings.SetConnectionFactoryFromConfigFailed(defaultConnectionFactory.FactoryTypeName), innerException);
				}
			}, isThreadSafe);
		}
		else
		{
			_defaultConnectionFactory = _defaultDefaultConnectionFactory;
		}
	}

	/// <summary>
	/// Appies any database intializers specified in the configuration
	/// </summary>
	public void ApplyInitializers()
	{
		bool force = false;
		InternalApplyInitializers(force);
	}

	/// <summary>
	/// Appies any database intializers specified in the configuration
	/// </summary>
	/// <param name="force">
	/// Value indicating if initializers should be re-applied if they have already been applied in this AppDomain
	/// </param>
	internal void InternalApplyInitializers(bool force)
	{
		if (_initializersApplied && !force)
		{
			return;
		}
		lock (Lock)
		{
			if (_initializersApplied && !force)
			{
				return;
			}
			_initializersApplied = true;
			if (_appSettings != null)
			{
				LegacyDatabaseInitializerConfig.ApplyInitializersFromConfig(_appSettings);
			}
			if (_entityFrameworkSettings == null)
			{
				return;
			}
			foreach (ContextElement context in _entityFrameworkSettings.Contexts)
			{
				if (!context.IsDatabaseInitializationDisabled && !context.DatabaseInitializer.ElementInformation.IsPresent)
				{
					continue;
				}
				try
				{
					Type contextType = context.GetContextType();
					object obj = null;
					if (!context.IsDatabaseInitializationDisabled)
					{
						Type initializerType = context.DatabaseInitializer.GetInitializerType();
						object[] typedParameterValues = context.DatabaseInitializer.Parameters.GetTypedParameterValues();
						obj = Activator.CreateInstance(initializerType, typedParameterValues);
					}
					MethodInfo methodInfo = Database_SetInitializerInternal.MakeGenericMethod(contextType);
					methodInfo.Invoke(null, BindingFlags.Static | BindingFlags.NonPublic, null, new object[2] { obj, true }, null);
				}
				catch (Exception innerException)
				{
					string p = (context.IsDatabaseInitializationDisabled ? "Disabled" : context.DatabaseInitializer.InitializerTypeName);
					throw new InvalidOperationException(Strings.Database_InitializeFromConfigFailed(p, context.ContextTypeName), innerException);
				}
			}
		}
	}

	/// <summary>
	/// Gets the specified connection string from the configuration
	/// </summary>
	/// <param name="name">Name of the connection string to get</param>
	/// <returns>The connection string, or null if there is no connection string with the specified name</returns>
	public ConnectionStringSettings GetConnectionString(string name)
	{
		return _connectionStrings[name];
	}

	private static KeyValueConfigurationCollection Convert(NameValueCollection collection)
	{
		KeyValueConfigurationCollection keyValueConfigurationCollection = new KeyValueConfigurationCollection();
		string[] allKeys = collection.AllKeys;
		foreach (string text in allKeys)
		{
			keyValueConfigurationCollection.Add(text, ConfigurationManager.AppSettings[text]);
		}
		return keyValueConfigurationCollection;
	}
}
