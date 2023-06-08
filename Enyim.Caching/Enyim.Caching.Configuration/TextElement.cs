using System.Configuration;
using System.Xml;

namespace Enyim.Caching.Configuration;

/// <summary>
/// CDATA config element
/// </summary>
public sealed class TextElement : ConfigurationElement
{
	public string Content { get; set; }

	protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
	{
		Content = reader.ReadElementContentAsString();
	}
}
