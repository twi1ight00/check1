using System.Configuration;

namespace System.Data.Entity.Internal.ConfigFile;

/// <summary>
/// Represents the configuration for a specific context type
/// </summary>
internal class ContextElement : ConfigurationElement
{
	private const string _typeKey = "type";

	private const string _disableDatabaseInitializationKey = "disableDatabaseInitialization";

	private const string _databaseInitializerKey = "databaseInitializer";

	[ConfigurationProperty("type", IsRequired = true)]
	public string ContextTypeName
	{
		get
		{
			return (string)base["type"];
		}
		set
		{
			base["type"] = value;
		}
	}

	[ConfigurationProperty("disableDatabaseInitialization", DefaultValue = false)]
	public bool IsDatabaseInitializationDisabled
	{
		get
		{
			return (bool)base["disableDatabaseInitialization"];
		}
		set
		{
			base["disableDatabaseInitialization"] = value;
		}
	}

	[ConfigurationProperty("databaseInitializer")]
	public DatabaseInitializerElement DatabaseInitializer
	{
		get
		{
			return (DatabaseInitializerElement)base["databaseInitializer"];
		}
		set
		{
			base["databaseInitializer"] = value;
		}
	}

	public Type GetContextType()
	{
		bool throwOnError = true;
		return Type.GetType(ContextTypeName, throwOnError);
	}
}
