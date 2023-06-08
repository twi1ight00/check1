using System;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.Configuration.Properties;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A configuration section describing configuration for an <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />.
/// </summary>
public class UnityConfigurationSection : ConfigurationSection
{
	private class ExtensionContext : SectionExtensionContext
	{
		private readonly UnityConfigurationSection section;

		private readonly string prefix;

		private readonly bool saveAliases;

		public ExtensionContext(UnityConfigurationSection section, string prefix)
			: this(section, prefix, saveAliases: true)
		{
		}

		public ExtensionContext(UnityConfigurationSection section, string prefix, bool saveAliases)
		{
			this.section = section;
			this.prefix = prefix;
			this.saveAliases = saveAliases;
		}

		/// <summary>
		/// Add a new alias to the configuration section. This is useful
		/// for those extensions that add commonly used types to configuration
		/// so users don't have to alias them repeatedly.
		/// </summary>
		/// <param name="newAlias">The alias to use.</param>
		/// <param name="aliasedType">Type the alias maps to.</param>
		public override void AddAlias(string newAlias, Type aliasedType)
		{
			if (saveAliases)
			{
				string text = newAlias;
				if (!string.IsNullOrEmpty(prefix))
				{
					text = prefix + "." + text;
				}
				section.TypeAliases.Add(new AliasElement(text, aliasedType));
			}
		}

		/// <summary>
		/// Add a new element to the configuration section schema.
		/// </summary>
		/// <param name="tag">Tag name in the XML.</param>
		/// <param name="elementType">Type the tag maps to.</param>
		public override void AddElement(string tag, Type elementType)
		{
			if (typeof(ContainerConfiguringElement).IsAssignableFrom(elementType))
			{
				ExtensionElementMap.AddContainerConfiguringElement(prefix, tag, elementType);
				return;
			}
			if (typeof(InjectionMemberElement).IsAssignableFrom(elementType))
			{
				ExtensionElementMap.AddInjectionMemberElement(prefix, tag, elementType);
				return;
			}
			if (typeof(ParameterValueElement).IsAssignableFrom(elementType))
			{
				ExtensionElementMap.AddParameterValueElement(prefix, tag, elementType);
				return;
			}
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidExtensionElementType, elementType.Name));
		}
	}

	/// <summary>
	/// The name of the section where unity configuration is expected to be found.
	/// </summary>
	public const string SectionName = "unity";

	/// <summary>
	/// XML Namespace string used for IntelliSense in this section.
	/// </summary>
	public const string XmlNamespace = "http://schemas.microsoft.com/practices/2010/unity";

	private const string ContainersPropertyName = "";

	private const string TypeAliasesPropertyName = "aliases";

	private const string SectionExtensionsPropertyName = "extensions";

	private const string NamespacesPropertyName = "namespaces";

	private const string AssembliesPropertyName = "assemblies";

	private const string XmlnsPropertyName = "xmlns";

	[ThreadStatic]
	private static UnityConfigurationSection currentSection;

	private static readonly UnknownElementHandlerMap<UnityConfigurationSection> unknownElementHandlerMap = new UnknownElementHandlerMap<UnityConfigurationSection>
	{
		{
			"typeAliases",
			delegate(UnityConfigurationSection s, XmlReader xr)
			{
				s.TypeAliases.Deserialize(xr);
			}
		},
		{
			"containers",
			delegate(UnityConfigurationSection s, XmlReader xr)
			{
				s.Containers.Deserialize(xr);
			}
		},
		{
			"alias",
			delegate(UnityConfigurationSection s, XmlReader xr)
			{
				s.ReadUnwrappedElement(xr, s.TypeAliases);
			}
		},
		{
			"sectionExtension",
			delegate(UnityConfigurationSection s, XmlReader xr)
			{
				s.DeserializeSectionExtension(xr);
			}
		},
		{
			"namespace",
			delegate(UnityConfigurationSection s, XmlReader xr)
			{
				s.ReadUnwrappedElement(xr, s.Namespaces);
			}
		},
		{
			"assembly",
			delegate(UnityConfigurationSection s, XmlReader xr)
			{
				s.ReadUnwrappedElement(xr, s.Assemblies);
			}
		}
	};

	/// <summary>
	/// The current <see cref="T:Microsoft.Practices.Unity.Configuration.UnityConfigurationSection" /> that is being deserialized
	/// or being configured from.
	/// </summary>
	public static UnityConfigurationSection CurrentSection => currentSection;

	/// <summary>
	/// Storage for XML namespace. The namespace isn't used or validated by config, but
	/// it is useful for Visual Studio XML IntelliSense to kick in.
	/// </summary>
	[ConfigurationProperty("xmlns", IsRequired = false, DefaultValue = "http://schemas.microsoft.com/practices/2010/unity")]
	public string Xmlns
	{
		get
		{
			return (string)base["xmlns"];
		}
		set
		{
			base["xmlns"] = value;
		}
	}

	/// <summary>
	/// The set of containers defined in this configuration section.
	/// </summary>
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public ContainerElementCollection Containers
	{
		get
		{
			ContainerElementCollection containerElementCollection = (ContainerElementCollection)base[""];
			containerElementCollection.ContainingSection = this;
			return containerElementCollection;
		}
	}

	/// <summary>
	/// The set of type aliases defined in this configuration file.
	/// </summary>
	[ConfigurationProperty("aliases")]
	public AliasElementCollection TypeAliases => (AliasElementCollection)base["aliases"];

	/// <summary>
	/// Any schema extensions that are added.
	/// </summary>
	[ConfigurationProperty("extensions")]
	public SectionExtensionElementCollection SectionExtensions => (SectionExtensionElementCollection)base["extensions"];

	/// <summary>
	/// Any namespaces added to the type search list.
	/// </summary>
	[ConfigurationProperty("namespaces")]
	public NamespaceElementCollection Namespaces => (NamespaceElementCollection)base["namespaces"];

	/// <summary>
	/// Any assemblies added to the type search list.
	/// </summary>
	[ConfigurationProperty("assemblies")]
	public AssemblyElementCollection Assemblies => (AssemblyElementCollection)base["assemblies"];

	/// <summary>
	/// Apply the configuration in the default container element to the given container.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	/// <returns>The passed in <paramref name="container" />.</returns>
	public IUnityContainer Configure(IUnityContainer container)
	{
		return Configure(container, "");
	}

	/// <summary>
	/// Apply the configuration in the default container element to the given container.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	/// <param name="configuredContainerName">Name of the container element to use to configure the container.</param>
	/// <returns>The passed in <paramref name="container" />.</returns>
	public IUnityContainer Configure(IUnityContainer container, string configuredContainerName)
	{
		currentSection = this;
		TypeResolver.SetAliases(this);
		ContainerElement containerElement = GuardContainerExists(configuredContainerName, Containers[configuredContainerName]);
		containerElement.ConfigureContainer(container);
		return container;
	}

	private static ContainerElement GuardContainerExists(string configuredContainerName, ContainerElement containerElement)
	{
		if (containerElement == null)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.NoSuchContainer, configuredContainerName), "configuredContainerName");
		}
		return containerElement;
	}

	/// <summary>
	/// Reads XML from the configuration file.
	/// </summary>
	/// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> object, which reads from the configuration file. 
	///                 </param><exception cref="T:System.Configuration.ConfigurationErrorsException"><paramref name="reader" /> found no elements in the configuration file.
	///                 </exception>
	protected override void DeserializeSection(XmlReader reader)
	{
		ExtensionElementMap.Clear();
		currentSection = this;
		base.DeserializeSection(reader);
	}

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

	private void DeserializeSectionExtension(XmlReader reader)
	{
		TypeResolver.SetAliases(this);
		SectionExtensionElement sectionExtensionElement = this.ReadUnwrappedElement(reader, SectionExtensions);
		sectionExtensionElement.ExtensionObject.AddExtensions(new ExtensionContext(this, sectionExtensionElement.Prefix));
	}

	/// <summary>
	/// Creates an XML string containing an unmerged view of the <see cref="T:System.Configuration.ConfigurationSection" /> object as a single section to write to a file.
	/// </summary>
	/// <returns>
	/// An XML string containing an unmerged view of the <see cref="T:System.Configuration.ConfigurationSection" /> object.
	/// </returns>
	/// <param name="parentElement">The <see cref="T:System.Configuration.ConfigurationElement" /> instance to use as the parent when performing the un-merge.
	///                 </param><param name="name">The name of the section to create.
	///                 </param><param name="saveMode">The <see cref="T:System.Configuration.ConfigurationSaveMode" /> instance to use when writing to a string.
	///                 </param>
	protected override string SerializeSection(ConfigurationElement parentElement, string name, ConfigurationSaveMode saveMode)
	{
		ExtensionElementMap.Clear();
		currentSection = this;
		TypeResolver.SetAliases(this);
		InitializeSectionExtensions();
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter xmlWriter = MakeXmlWriter(stringBuilder))
		{
			xmlWriter.WriteStartElement(name, "http://schemas.microsoft.com/practices/2010/unity");
			xmlWriter.WriteAttributeString("xmlns", "http://schemas.microsoft.com/practices/2010/unity");
			TypeAliases.SerializeElementContents(xmlWriter, "alias");
			Namespaces.SerializeElementContents(xmlWriter, "namespace");
			Assemblies.SerializeElementContents(xmlWriter, "assembly");
			SectionExtensions.SerializeElementContents(xmlWriter, "sectionExtension");
			Containers.SerializeElementContents(xmlWriter, "container");
			xmlWriter.WriteEndElement();
		}
		return stringBuilder.ToString();
	}

	private static XmlWriter MakeXmlWriter(StringBuilder sb)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.OmitXmlDeclaration = true;
		xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;
		XmlWriterSettings settings = xmlWriterSettings;
		return XmlWriter.Create(sb, settings);
	}

	private void InitializeSectionExtensions()
	{
		foreach (SectionExtensionElement sectionExtension in SectionExtensions)
		{
			SectionExtension extensionObject = sectionExtension.ExtensionObject;
			extensionObject.AddExtensions(new ExtensionContext(this, sectionExtension.Prefix, saveAliases: false));
		}
	}
}
