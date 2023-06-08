using System;
using System.Configuration;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// Configuration element representing an extension to add to a container.
/// </summary>
public class ContainerExtensionElement : ContainerConfiguringElement
{
	private const string TypeNamePropertyName = "type";

	/// <summary>
	/// Type of the extension to add.
	/// </summary>
	[ConfigurationProperty("type", IsRequired = true)]
	public string TypeName
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

	/// <summary>
	/// Add the extension specified in this element to the container.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	protected override void ConfigureContainer(IUnityContainer container)
	{
		Type extensionType = GetExtensionType();
		UnityContainerExtension extension = (UnityContainerExtension)container.Resolve(extensionType);
		container.AddExtension(extension);
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
		Guard.ArgumentNotNull(writer, "writer");
		writer.WriteAttributeString("type", TypeName);
	}

	private Type GetExtensionType()
	{
		return TypeResolver.ResolveType(TypeName, throwIfResolveFails: true);
	}
}
