using System.Configuration;

namespace System.Data.Entity.Internal.ConfigFile;

/// <summary>
/// Represents setting the default connection factory
/// </summary>
internal class DefaultConnectionFactoryElement : ConfigurationElement
{
	private const string _typeKey = "type";

	private const string _parametersKey = "parameters";

	[ConfigurationProperty("type", IsRequired = true)]
	public string FactoryTypeName
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

	public Type GetFactoryType()
	{
		bool throwOnError = true;
		return Type.GetType(FactoryTypeName, throwOnError);
	}
}
