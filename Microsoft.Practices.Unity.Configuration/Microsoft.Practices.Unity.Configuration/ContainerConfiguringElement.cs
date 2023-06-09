using System.Globalization;
using System.Threading;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A base class for those elements that can be used
/// to configure a unity container.
/// </summary>
public abstract class ContainerConfiguringElement : DeserializableConfigurationElement
{
	private static int configuringElementCount;

	private readonly int configuringElementNum;

	/// <summary>
	/// Return a unique key that can be used to manage this element in a collection.
	/// </summary>
	public virtual string Key => string.Format(CultureInfo.InvariantCulture, "configuring:{0}", configuringElementNum);

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.Configuration.ContainerConfiguringElement" />.
	/// </summary>
	protected ContainerConfiguringElement()
	{
		configuringElementNum = Interlocked.Increment(ref configuringElementCount);
	}

	/// <summary>
	/// Apply this element's configuration to the given <paramref name="container" />.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	protected abstract void ConfigureContainer(IUnityContainer container);

	internal void ConfigureContainerInternal(IUnityContainer container)
	{
		ConfigureContainer(container);
	}
}
