using System.Configuration;

namespace System.Data.Entity.Internal.ConfigFile;

/// <summary>
/// Represents setting the database initializer for a specific context type
/// </summary>
internal class DatabaseInitializerElement : ConfigurationElement
{
	private const string _typeKey = "type";

	private const string _parametersKey = "parameters";

	[ConfigurationProperty("type", IsRequired = true)]
	public string InitializerTypeName
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

	[ConfigurationProperty("parameters")]
	public ParameterCollection Parameters => (ParameterCollection)base["parameters"];

	public Type GetInitializerType()
	{
		bool throwOnError = true;
		return Type.GetType(InitializerTypeName, throwOnError);
	}
}
