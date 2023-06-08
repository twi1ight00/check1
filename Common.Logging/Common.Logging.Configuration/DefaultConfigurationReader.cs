using System.Configuration;

namespace Common.Logging.Configuration;

/// <summary>
/// Implementation of <see cref="T:Common.Logging.IConfigurationReader" /> that uses the standard .NET 
/// configuration APIs, ConfigurationSettings in 1.x and ConfigurationManager in 2.0
/// </summary>
/// <author>Mark Pollack</author>
public class DefaultConfigurationReader : IConfigurationReader
{
	/// <summary>
	/// Parses the configuration section and returns the resulting object.
	/// </summary>
	/// <param name="sectionName">Name of the configuration section.</param>
	/// <returns>
	/// Object created by a corresponding <see cref="T:System.Configuration.IConfigurationSectionHandler" />.
	/// </returns>
	/// <remarks>
	/// 	<p>
	/// Primary purpose of this method is to allow us to parse and
	/// load configuration sections using the same API regardless
	/// of the .NET framework version.
	/// </p>
	/// </remarks>
	/// <see cref="T:Common.Logging.ConfigurationSectionHandler" />
	public object GetSection(string sectionName)
	{
		return ConfigurationManager.GetSection(sectionName);
	}
}
