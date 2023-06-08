using System.Configuration;
using System.Globalization;
using System.Xml;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.InterceptionExtension.Configuration.Properties;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// Base class for the two children of the Policy element:
/// MatchingRuleElement and CallHandlerElement.
/// </summary>
/// <remarks>
/// <para>
/// These configuration elements have a required "name" attribute, an optional "type" attribute, and 
/// optional child elements &lt;lifetime&gt; and &lt;injection&gt;
/// </para>
/// <para>
/// Elements without a value for the type attribute can only have a value for the name attribute, and 
/// indicate that the represented handler or rule is configured elsewhere and that a reference to 
/// the given name must be added to the policy to be resolved, while elements with a value for the type
/// attribute indicate how the represented handler or rule should be built and can optionally specify
/// lifetime management and injection configuration.
/// </para>
/// <para>
/// This element is similar to the <see cref="T:Microsoft.Practices.Unity.Configuration.RegisterElement" />, except that it does not provide 
/// an extension point for arbitrary configuration.
/// </para>
/// </remarks>
public abstract class PolicyChildElement : DeserializableConfigurationElement
{
	private const string InjectionPropertyName = "";

	private const string LifetimePropertyName = "lifetime";

	private const string NamePropertyName = "name";

	private const string TypeNamePropertyName = "type";

	/// <summary>
	/// Name of this item
	/// </summary>
	[ConfigurationProperty("name", IsRequired = true)]
	public string Name
	{
		get
		{
			return (string)base["name"];
		}
		set
		{
			base["name"] = value;
		}
	}

	/// <summary>
	/// Type that implements this matching rule or call handler.
	/// </summary>
	[ConfigurationProperty("type", IsRequired = false)]
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
	/// Injection members that control how this item is created.
	/// </summary>
	[ConfigurationProperty("", IsDefaultCollection = true)]
	public InjectionMemberElementCollection Injection => (InjectionMemberElementCollection)base[""];

	/// <summary>
	/// Lifetime manager for this item.
	/// </summary>
	[ConfigurationProperty("lifetime", IsRequired = false, DefaultValue = null)]
	public LifetimeElement Lifetime
	{
		get
		{
			return (LifetimeElement)base["lifetime"];
		}
		set
		{
			base["lifetime"] = value;
		}
	}

	/// <summary>
	/// Reads XML from the configuration file.
	/// </summary>
	/// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> that reads from the configuration file.
	///                 </param><param name="serializeCollectionKey">true to serialize only the collection key properties; otherwise, false.
	///                 </param><exception cref="T:System.Configuration.ConfigurationErrorsException">The element to read is locked.
	///                     - or -
	///                     An attribute of the current node is not recognized.
	///                     - or -
	///                     The lock status of the current node cannot be determined.  
	///                 </exception>
	protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
	{
		base.DeserializeElement(reader, serializeCollectionKey);
		if (string.IsNullOrEmpty(TypeName) && LifetimeIsPresent())
		{
			throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.CannotHaveLifetimeWithoutTypeName, Name), reader);
		}
		if (string.IsNullOrEmpty(TypeName) && Injection.Count > 0)
		{
			throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.CannotHaveInjectionWithoutTypeName, Name), reader);
		}
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
		writer.WriteAttributeString("name", Name);
		writer.WriteAttributeIfNotEmpty("type", TypeName);
		if (LifetimeIsPresent())
		{
			writer.WriteElement("lifetime", Lifetime.SerializeContent);
		}
		foreach (InjectionMemberElement item in Injection)
		{
			writer.WriteElement(item.ElementName, item.SerializeContent);
		}
	}

	private bool LifetimeIsPresent()
	{
		if (string.IsNullOrEmpty(Lifetime.TypeName) && string.IsNullOrEmpty(Lifetime.TypeConverterTypeName))
		{
			return !string.IsNullOrEmpty(Lifetime.Value);
		}
		return true;
	}
}
