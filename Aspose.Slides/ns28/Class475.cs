using System.Xml;

namespace ns28;

internal sealed class Class475 : XmlDocument
{
	internal static Class482 class482_0;

	internal static readonly string string_0;

	internal Class408 Manifests => base.DocumentElement as Class408;

	static Class475()
	{
		string_0 = "urn:oasis:names:tc:opendocument:xmlns:manifest:1.0";
		class482_0 = new Class482(string_0);
		class482_0.Add(string_0, Class408.string_0, typeof(Class408));
		class482_0.Add(string_0, Class407.string_0, typeof(Class407));
	}

	internal Class475()
	{
	}

	public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
	{
		XmlElement xmlElement = class482_0.CreateElement(prefix, localName, namespaceURI, this);
		if (xmlElement != null)
		{
			return xmlElement;
		}
		return base.CreateElement(prefix, localName, namespaceURI);
	}

	internal void method_0(string mediaType, string fullPath)
	{
		Class407 @class = (Class407)Manifests.method_35("file-entry", string_0);
		@class.ManifestMediaType = mediaType;
		@class.ManifestFullPath = fullPath.Replace("\\", "/");
	}
}
