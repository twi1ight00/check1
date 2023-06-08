using System.Configuration;
using System.Xml;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// Configuration element that provides a top-level element for
/// configuration interceptors for types in a container.
/// </summary>
public class InterceptorsElement : ContainerConfiguringElement
{
	private const string InterceptorsPropertyName = "";

	/// <summary>
	/// The various child elements that are contained in this element.
	/// </summary>
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public InterceptorsInterceptorElementCollection Interceptors => (InterceptorsInterceptorElementCollection)base[""];

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		foreach (InterceptorsInterceptorElement interceptor in Interceptors)
		{
			writer.WriteElement("interceptor", interceptor.SerializeContent);
		}
	}

	/// <summary>
	/// Apply this element's configuration to the given <paramref name="container" />.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	protected override void ConfigureContainer(IUnityContainer container)
	{
		foreach (InterceptorsInterceptorElement interceptor in Interceptors)
		{
			interceptor.ConfigureContainer(container);
		}
	}
}
