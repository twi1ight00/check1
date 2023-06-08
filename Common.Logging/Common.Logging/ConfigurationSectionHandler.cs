using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml;
using Common.Logging.Configuration;
using Common.Logging.Simple;

namespace Common.Logging;

/// <summary>
/// Used in an application's configuration file (App.Config or Web.Config) to configure the logging subsystem.
/// </summary>
/// <example>
/// An example configuration section that writes log messages to the Console using the
/// built-in Console Logger.
/// <code lang="XML">
/// &lt;configuration&gt;
///     &lt;configSections&gt;
///       &lt;sectionGroup name="common"&gt;
///         &lt;section name="logging" type="Common.Logging.ConfigurationSectionHandler, Common.Logging" /&gt;
///       &lt;/sectionGroup&gt; 
///     &lt;/configSections&gt;
///     &lt;common&gt;
///       &lt;logging&gt;
///         &lt;factoryAdapter type="Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter, Common.Logging"&gt;
///           &lt;arg key="showLogName" value="true" /&gt;
///           &lt;arg key="showDataTime" value="true" /&gt;
///           &lt;arg key="level" value="ALL" /&gt;
///           &lt;arg key="dateTimeFormat" value="yyyy/MM/dd HH:mm:ss:fff" /&gt;
///         &lt;/factoryAdapter&gt;
///       &lt;/logging&gt;
///     &lt;/common&gt;
/// &lt;/configuration&gt;
/// </code>
/// </example>
public class ConfigurationSectionHandler : IConfigurationSectionHandler
{
	private static readonly string LOGFACTORYADAPTER_ELEMENT;

	private static readonly string LOGFACTORYADAPTER_ELEMENT_TYPE_ATTRIB;

	private static readonly string ARGUMENT_ELEMENT;

	private static readonly string ARGUMENT_ELEMENT_KEY_ATTRIB;

	private static readonly string ARGUMENT_ELEMENT_VALUE_ATTRIB;

	/// <summary>
	/// Ensure static fields get initialized before any class member 
	/// can be accessed (avoids beforeFieldInit)
	/// </summary>
	static ConfigurationSectionHandler()
	{
		LOGFACTORYADAPTER_ELEMENT = "factoryAdapter";
		LOGFACTORYADAPTER_ELEMENT_TYPE_ATTRIB = "type";
		ARGUMENT_ELEMENT = "arg";
		ARGUMENT_ELEMENT_KEY_ATTRIB = "key";
		ARGUMENT_ELEMENT_VALUE_ATTRIB = "value";
	}

	/// <summary>
	/// Constructor
	/// </summary>
	public ConfigurationSectionHandler()
	{
	}

	/// <summary>
	/// Retrieves the <see cref="T:System.Type" /> of the logger the use by looking at the logFactoryAdapter element
	/// of the logging configuration element.
	/// </summary>
	/// <param name="section"></param>
	/// <returns>
	/// A <see cref="T:Common.Logging.Configuration.LogSetting" /> object containing the specified type that implements 
	/// <see cref="T:Common.Logging.ILoggerFactoryAdapter" /> along with zero or more properties that will be 
	/// passed to the logger factory adapter's constructor as an <see cref="T:System.Collections.IDictionary" />.
	/// </returns>
	private LogSetting ReadConfiguration(XmlNode section)
	{
		XmlNode logFactoryElement = section.SelectSingleNode(LOGFACTORYADAPTER_ELEMENT);
		string factoryTypeString = string.Empty;
		if (logFactoryElement.Attributes[LOGFACTORYADAPTER_ELEMENT_TYPE_ATTRIB] != null)
		{
			factoryTypeString = logFactoryElement.Attributes[LOGFACTORYADAPTER_ELEMENT_TYPE_ATTRIB].Value;
		}
		if (factoryTypeString == string.Empty)
		{
			throw new ConfigurationException("Required Attribute '" + LOGFACTORYADAPTER_ELEMENT_TYPE_ATTRIB + "' not found in element '" + LOGFACTORYADAPTER_ELEMENT + "'");
		}
		Type factoryType = null;
		try
		{
			factoryType = ((string.Compare(factoryTypeString, "CONSOLE", ignoreCase: true) == 0) ? typeof(ConsoleOutLoggerFactoryAdapter) : ((string.Compare(factoryTypeString, "TRACE", ignoreCase: true) == 0) ? typeof(TraceLoggerFactoryAdapter) : ((string.Compare(factoryTypeString, "NOOP", ignoreCase: true) != 0) ? Type.GetType(factoryTypeString, throwOnError: true, ignoreCase: false) : typeof(NoOpLoggerFactoryAdapter))));
		}
		catch (Exception e)
		{
			throw new ConfigurationException("Unable to create type '" + factoryTypeString + "'", e);
		}
		XmlNodeList propertyNodes = logFactoryElement.SelectNodes(ARGUMENT_ELEMENT);
		NameValueCollection properties = null;
		properties = new NameValueCollection();
		foreach (XmlNode propertyNode in propertyNodes)
		{
			string key = string.Empty;
			string itsValue = string.Empty;
			XmlAttribute keyAttrib = propertyNode.Attributes[ARGUMENT_ELEMENT_KEY_ATTRIB];
			XmlAttribute valueAttrib = propertyNode.Attributes[ARGUMENT_ELEMENT_VALUE_ATTRIB];
			if (keyAttrib == null)
			{
				throw new ConfigurationException("Required Attribute '" + ARGUMENT_ELEMENT_KEY_ATTRIB + "' not found in element '" + ARGUMENT_ELEMENT + "'");
			}
			key = keyAttrib.Value;
			if (valueAttrib != null)
			{
				itsValue = valueAttrib.Value;
			}
			properties.Add(key, itsValue);
		}
		return new LogSetting(factoryType, properties);
	}

	/// <summary>
	/// Verifies that the logFactoryAdapter element appears once in the configuration section.
	/// </summary>
	/// <param name="parent">settings of a parent section - atm this must always be null</param>
	/// <param name="configContext">Additional information about the configuration process.</param>
	/// <param name="section">The configuration section to apply an XPath query too.</param>
	/// <returns>
	/// A <see cref="T:Common.Logging.Configuration.LogSetting" /> object containing the specified logFactoryAdapter type
	/// along with user supplied configuration properties.
	/// </returns>
	public LogSetting Create(LogSetting parent, object configContext, XmlNode section)
	{
		if (parent != null)
		{
			throw new ConfigurationException("parent configuration sections are not allowed");
		}
		int logFactoryElementsCount = section.SelectNodes(LOGFACTORYADAPTER_ELEMENT).Count;
		if (logFactoryElementsCount > 1)
		{
			throw new ConfigurationException("Only one <factoryAdapter> element allowed");
		}
		if (logFactoryElementsCount == 1)
		{
			return ReadConfiguration(section);
		}
		return null;
	}

	/// <summary>
	/// Verifies that the logFactoryAdapter element appears once in the configuration section.
	/// </summary>
	/// <param name="parent">The parent of the current item.</param>
	/// <param name="configContext">Additional information about the configuration process.</param>
	/// <param name="section">The configuration section to apply an XPath query too.</param>
	/// <returns>
	/// A <see cref="T:Common.Logging.Configuration.LogSetting" /> object containing the specified logFactoryAdapter type
	/// along with user supplied configuration properties.
	/// </returns>
	object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
	{
		return Create(parent as LogSetting, configContext, section);
	}
}
