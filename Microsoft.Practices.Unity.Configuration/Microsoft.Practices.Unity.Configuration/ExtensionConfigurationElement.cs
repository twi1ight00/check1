using System.Globalization;
using System.Threading;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// Base class used to derive new elements that can occur
/// directly within a container element.
/// </summary>
public abstract class ExtensionConfigurationElement : DeserializableConfigurationElement
{
	private static int extensionConfigurationCount;

	private readonly int extensionConfigurationNumber;

	/// <summary>
	/// Unique key generated for use in the collection class.
	/// </summary>
	public string Key => string.Format(CultureInfo.InvariantCulture, "extensionConfig:{0}", extensionConfigurationNumber);

	/// <summary>
	/// Initialize a new instance of <see cref="T:Microsoft.Practices.Unity.Configuration.ExtensionConfigurationElement" />.
	/// </summary>
	protected ExtensionConfigurationElement()
	{
		extensionConfigurationNumber = Interlocked.Increment(ref extensionConfigurationCount);
	}

	internal void Configure(IUnityContainer container)
	{
		ConfigureContainer(container);
	}

	/// <summary>
	/// When overridden in a derived class, this method will make configuration
	/// calls into the given <paramref name="container" /> according to its contents.
	/// </summary>
	/// <param name="container">The container to configure.</param>
	protected abstract void ConfigureContainer(IUnityContainer container);
}
