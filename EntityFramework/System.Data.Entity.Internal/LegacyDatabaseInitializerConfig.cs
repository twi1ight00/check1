using System.Configuration;
using System.Data.Entity.Resources;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.Internal;

/// <summary>
///     Encapsulates information read from the application config file that specifies a database initializer
///     and allows that initializer to be dynamically applied.
/// </summary>
internal class LegacyDatabaseInitializerConfig
{
	private const string ConfigKeyKey = "DatabaseInitializerForType";

	private const string DisabledSpecialValue = "Disabled";

	private static readonly MethodInfo Database_SetInitializerInternal = typeof(Database).GetMethod("SetInitializerInternal", BindingFlags.Static | BindingFlags.NonPublic);

	private readonly string _contextTypeName;

	private readonly string _initializerTypeName;

	private readonly bool _disabled;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.LegacyDatabaseInitializerConfig" /> class.
	/// </summary>
	/// <param name="configKey">The key from the entry in the config file.</param>
	/// <param name="configValue">The value from the enrty in the config file.</param>
	public LegacyDatabaseInitializerConfig(string configKey, string configValue)
	{
		_contextTypeName = configKey.Remove(0, "DatabaseInitializerForType".Length).Trim();
		if (string.IsNullOrWhiteSpace(configValue) || configValue.Trim().Equals("Disabled", StringComparison.OrdinalIgnoreCase))
		{
			_disabled = true;
		}
		else
		{
			_initializerTypeName = configValue.Trim();
		}
		if (string.IsNullOrWhiteSpace(_contextTypeName) || (!_disabled && string.IsNullOrWhiteSpace(_initializerTypeName)))
		{
			throw Error.Database_BadLegacyInitializerEntry(configKey, configValue);
		}
	}

	/// <summary>
	///     Uses the context type and initializer type specified in the config to create an initializer instance
	///     and set it with the DbDbatabase.SetInitializer method.
	/// </summary>
	public void ApplyInitializer()
	{
		try
		{
			Type type = Type.GetType(_contextTypeName);
			if (type == null)
			{
				throw Error.Database_FailedToResolveType(_contextTypeName);
			}
			object obj = null;
			if (!_disabled)
			{
				Type type2 = Type.GetType(_initializerTypeName);
				if (type2 == null)
				{
					throw Error.Database_FailedToResolveType(_initializerTypeName);
				}
				obj = Activator.CreateInstance(type2);
			}
			MethodInfo methodInfo = Database_SetInitializerInternal.MakeGenericMethod(type);
			methodInfo.Invoke(null, BindingFlags.Static | BindingFlags.NonPublic, null, new object[2] { obj, true }, null);
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(Strings.Database_InitializeFromLegacyConfigFailed(_disabled ? "Disabled" : _initializerTypeName, _contextTypeName), innerException);
		}
	}

	/// <summary>
	///     Reads all initializers from the application config file and sets them using the Database class.
	/// </summary>
	public static void ApplyInitializersFromConfig(KeyValueConfigurationCollection appSettings)
	{
		string[] allKeys = appSettings.AllKeys;
		if (allKeys == null)
		{
			return;
		}
		foreach (LegacyDatabaseInitializerConfig item in from k in allKeys
			where k.StartsWith("DatabaseInitializerForType", StringComparison.OrdinalIgnoreCase)
			select new LegacyDatabaseInitializerConfig(k, appSettings[k].Value))
		{
			item.ApplyInitializer();
		}
	}
}
