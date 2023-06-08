using System.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.Configuration;

/// <summary>
/// A collection of <see cref="T:Microsoft.Practices.Unity.Configuration.SectionExtensionElement" />s.
/// </summary>
[ConfigurationCollection(typeof(SectionExtensionElement))]
public class SectionExtensionElementCollection : DeserializableConfigurationElementCollection<SectionExtensionElement>
{
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
		SectionExtensionElement sectionExtensionElement = (SectionExtensionElement)element;
		string text = sectionExtensionElement.Prefix;
		if (!string.IsNullOrEmpty(text))
		{
			text += ".";
		}
		return text + sectionExtensionElement.TypeName;
	}
}
