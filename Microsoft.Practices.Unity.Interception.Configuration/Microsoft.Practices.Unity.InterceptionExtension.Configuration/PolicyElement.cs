using System.Configuration;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// Configuration element for building up an interception policy.
/// </summary>
public class PolicyElement : DeserializableConfigurationElement
{
	private const string CallHandlersPropertyName = "callHandlers";

	private const string MatchingRulesPropertyName = "matchingRules";

	private const string NamePropertyName = "name";

	private static readonly UnknownElementHandlerMap<PolicyElement> unknownElementHandlerMap = new UnknownElementHandlerMap<PolicyElement>
	{
		{
			"matchingRule",
			delegate(PolicyElement pe, XmlReader xr)
			{
				pe.ReadUnwrappedElement(xr, pe.MatchingRules);
			}
		},
		{
			"callHandler",
			delegate(PolicyElement pe, XmlReader xr)
			{
				pe.ReadUnwrappedElement(xr, pe.CallHandlers);
			}
		}
	};

	/// <summary>
	/// Name of this policy.
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
	/// Matching rules for this policy.
	/// </summary>
	[ConfigurationProperty("matchingRules")]
	public MatchingRuleElementCollection MatchingRules => (MatchingRuleElementCollection)base["matchingRules"];

	/// <summary>
	/// Call handlers for this policy.
	/// </summary>
	[ConfigurationProperty("callHandlers")]
	public CallHandlerElementCollection CallHandlers => (CallHandlerElementCollection)base["callHandlers"];

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
		writer.WriteAttributeString("name", Name);
		foreach (MatchingRuleElement matchingRule in MatchingRules)
		{
			writer.WriteElement("matchingRule", matchingRule.SerializeContent);
		}
		foreach (CallHandlerElement callHandler in CallHandlers)
		{
			writer.WriteElement("callHandler", callHandler.SerializeContent);
		}
	}

	internal void ConfigureContainer(IUnityContainer container)
	{
		PolicyDefinition policyDefinition = container.Configure<Interception>().AddPolicy(Name);
		foreach (MatchingRuleElement matchingRule in MatchingRules)
		{
			matchingRule.Configure(container, policyDefinition);
		}
		foreach (CallHandlerElement callHandler in CallHandlers)
		{
			callHandler.Configure(container, policyDefinition);
		}
	}
}
