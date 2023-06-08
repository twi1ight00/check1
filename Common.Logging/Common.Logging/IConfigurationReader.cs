namespace Common.Logging;

/// <summary>
/// Interface for basic operations to read .NET application configuration information.
/// </summary>
/// <remarks>Provides a simple abstraction to handle BCL API differences between .NET 1.x and 2.0. Also
/// useful for testing scenarios.</remarks>
/// <author>Mark Pollack</author>
public interface IConfigurationReader
{
	/// <summary>
	/// Parses the configuration section and returns the resulting object.
	/// </summary>
	/// <remarks>
	/// <p>
	/// Primary purpose of this method is to allow us to parse and 
	/// load configuration sections using the same API regardless
	/// of the .NET framework version.
	/// </p>
	/// </remarks>
	/// <param name="sectionName">Name of the configuration section.</param>
	/// <returns>Object created by a corresponding <see cref="T:System.Configuration.IConfigurationSectionHandler" />.</returns>
	/// <see cref="T:Common.Logging.ConfigurationSectionHandler" />
	object GetSection(string sectionName);
}
