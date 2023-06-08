using System.Configuration;

namespace System.Data.Entity.Internal.ConfigFile;

/// <summary>
/// Represents all Entity Framework related configuration
/// </summary>
internal class EntityFrameworkSection : ConfigurationSection
{
	private const string _defaultConnectionFactoryKey = "defaultConnectionFactory";

	private const string _contextsKey = "contexts";

	[ConfigurationProperty("defaultConnectionFactory")]
	public DefaultConnectionFactoryElement DefaultConnectionFactory
	{
		get
		{
			return (DefaultConnectionFactoryElement)base["defaultConnectionFactory"];
		}
		set
		{
			base["defaultConnectionFactory"] = value;
		}
	}

	[ConfigurationProperty("contexts")]
	public ContextCollection Contexts => (ContextCollection)base["contexts"];
}
