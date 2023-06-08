using System.Configuration;
using System.Xml;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// A configuration element that contains the top-level container configuration
/// information for interception - handler policies and global interceptor definitions.
/// </summary>
public class InterceptionElement : ContainerConfiguringElement
{
	private const string PoliciesPropertyName = "policies";

	private static readonly UnknownElementHandlerMap<InterceptionElement> unknownElementHandlerMap = new UnknownElementHandlerMap<InterceptionElement> { 
	{
		"policy",
		delegate(InterceptionElement ie, XmlReader xr)
		{
			ie.ReadUnwrappedElement(xr, ie.Policies);
		}
	} };

	/// <summary>
	/// Policies defined for this container.
	/// </summary>
	[ConfigurationProperty("policies")]
	public PolicyElementCollection Policies => (PolicyElementCollection)base["policies"];

	/// <summary>
	/// Gets a value indicating whether an unknown element is encountered during deserialization.
	/// </summary>
	/// <returns>
	/// true when an unknown element is encountered while deserializing; otherwise, false.
	/// </returns>
	/// <param name="elementName">The name of the unknown subelement.
	///                 </param><param name="reader">The <see cref="T:System.Xml.XmlReader" /> being used for deserialization.
	///                 </param><exception cref="T:System.Configuration.ConfigurationErrorsException">The element identified by <paramref name="elementName" /> is locked.
	///                     - or -
	///                     One or more of the element's attributes is locked.
	///                     - or -
	///                 <paramref name="elementName" /> is unrecognized, or the element has an unrecognized attribute.
	///                     - or -
	///                     The element has a Boolean attribute with an invalid value.
	///                     - or -
	///                     An attempt was made to deserialize a property more than once.
	///                     - or -
	///                     An attempt was made to deserialize a property that is not a valid member of the element.
	///                     - or -
	///                     The element cannot contain a CDATA or text element.
	///                 </exception>
	protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
	{
		if (!unknownElementHandlerMap.ProcessElement(this, elementName, reader))
		{
			return base.OnDeserializeUnrecognizedElement(elementName, reader);
		}
		return true;
	}

	/// <summary>
	/// Write the contents of this element to the given <see cref="T:System.Xml.XmlWriter" />.
	/// </summary>
	/// <remarks>The caller of this method has already written the start element tag before
	/// calling this method, so deriving classes only need to write the element content, not
	/// the start or end tags.</remarks>
	/// <param name="writer">Writer to send XML content to.</param>
	public override void SerializeContent(XmlWriter writer)
	{
		foreach (PolicyElement policy in Policies)
		{
			writer.WriteElement("policy", policy.SerializeContent);
		}
	}

	/// <summary>
	/// Apply this element's configuration to the given <paramref name="container" />.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	protected override void ConfigureContainer(IUnityContainer container)
	{
		Policies.ForEach(delegate(PolicyElement policy)
		{
			policy.ConfigureContainer(container);
		});
	}
}
