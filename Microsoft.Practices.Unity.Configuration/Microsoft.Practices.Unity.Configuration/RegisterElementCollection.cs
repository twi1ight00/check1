using System.Configuration;
using System.Xml;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A collection of <see cref="T:Microsoft.Practices.Unity.Configuration.RegisterElement" />s.
/// </summary>
[ConfigurationCollection(typeof(RegisterElement), AddItemName = "register")]
public class RegisterElementCollection : DeserializableConfigurationElementCollection<RegisterElement>
{
	private static readonly UnknownElementHandlerMap<RegisterElementCollection> unknownElementHandlerMap = new UnknownElementHandlerMap<RegisterElementCollection> { 
	{
		"type",
		delegate(RegisterElementCollection rec, XmlReader xr)
		{
			rec.ReadUnwrappedElement(xr, rec);
		}
	} };

	/// <summary>
	/// Causes the configuration system to throw an exception.
	/// </summary>
	/// <returns>
	/// true if the unrecognized element was deserialized successfully; otherwise, false. The default is false.
	/// </returns>
	/// <param name="elementName">The name of the unrecognized element. 
	///                 </param><param name="reader">An input stream that reads XML from the configuration file. 
	///                 </param><exception cref="T:System.Configuration.ConfigurationErrorsException">The element specified in <paramref name="elementName" /> is the &lt;clear&gt; element.
	///                 </exception><exception cref="T:System.ArgumentException"><paramref name="elementName" /> starts with the reserved prefix "config" or "lock".
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
	/// Gets the element key for a specified configuration element when overridden in a derived class.
	/// </summary>
	/// <returns>
	/// An <see cref="T:System.Object" /> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement" />.
	/// </returns>
	/// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement" /> to return the key for. 
	///                 </param>
	protected override object GetElementKey(ConfigurationElement element)
	{
		RegisterElement registerElement = (RegisterElement)element;
		return registerElement.TypeName + ":" + registerElement.Name;
	}
}
