using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace ns58;

internal abstract class Class2606 : XmlDocument
{
	internal const string string_0 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	public const string string_1 = "http://schemas.openxmlformats.org/presentationml/2006/main";

	internal const string string_2 = "http://schemas.openxmlformats.org/drawingml/2006/main";

	internal const string string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties";

	public const string string_4 = "urn:schemas-microsoft-com:vml";

	public const string string_5 = "http://schemas.openxmlformats.org/markup-compatibility/2006";

	public const string string_6 = "http://schemas.microsoft.com/office/2006/activeX";

	public const string string_7 = "http://schemas.microsoft.com/office/powerpoint/2007/7/12/main";

	public const string string_8 = "http://schemas.microsoft.com/office/powerpoint/2010/main";

	public const string string_9 = "http://schemas.microsoft.com/office/powerpoint/2012/main";

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal static readonly Dictionary<string, string> dictionary_0;

	internal static readonly Dictionary<string, string> dictionary_1;

	private static readonly string[] string_10;

	internal XmlSchemaCollection xmlSchemaCollection_0;

	public new Class2607 DocumentElement => (Class2607)base.DocumentElement;

	static Class2606()
	{
		dictionary_0 = new Dictionary<string, string>();
		dictionary_1 = new Dictionary<string, string>();
		string_10 = new string[18]
		{
			"http://schemas.openxmlformats.org/officeDocument/2006/relationships", "r", "http://schemas.openxmlformats.org/presentationml/2006/main", "p", "http://schemas.microsoft.com/office/2006/activeX", "ox", "http://schemas.openxmlformats.org/drawingml/2006/main", "a", "http://schemas.microsoft.com/office/powerpoint/2010/main", "p14",
			"urn:schemas-microsoft-com:vml", "v", "http://schemas.openxmlformats.org/markup-compatibility/2006", "mc", "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties", "", "http://schemas.microsoft.com/office/powerpoint/2012/main", "p15"
		};
		for (int i = 0; i < string_10.Length; i += 2)
		{
			dictionary_0[string_10[i]] = string_10[i + 1];
			dictionary_1[string_10[i + 1]] = string_10[i];
		}
	}

	public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
	{
		XmlElement xmlElement = new Class2607(prefix, localName, namespaceURI, this);
		if (xmlElement != null)
		{
			return xmlElement;
		}
		return new Class2607(prefix, localName, namespaceURI, this);
	}
}
