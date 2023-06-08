using System.Xml;

namespace ns56;

internal class Class2514
{
	public static XmlDocument smethod_0(Class1885 extensionListElementData, string uri)
	{
		if (extensionListElementData == null)
		{
			return null;
		}
		Class1449[] extList = extensionListElementData.ExtList;
		int num = 0;
		Class1454 @class;
		while (true)
		{
			if (num < extList.Length)
			{
				@class = (Class1454)extList[num];
				XmlAttribute xmlAttribute = @class.XmlDocument.DocumentElement.Attributes["uri"];
				if (xmlAttribute != null && xmlAttribute.Value == uri)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.XmlDocument;
	}

	public static Class1454 smethod_1(Class1885 extensionListElementData, string uri)
	{
		if (extensionListElementData == null)
		{
			return null;
		}
		Class1449[] extList = extensionListElementData.ExtList;
		int num = 0;
		Class1454 @class;
		while (true)
		{
			if (num < extList.Length)
			{
				@class = (Class1454)extList[num];
				XmlAttribute xmlAttribute = @class.XmlDocument.DocumentElement.Attributes["uri"];
				if (xmlAttribute != null && xmlAttribute.Value == uri)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	public static Class1454 smethod_2(Class1885 extensionListElementData, string uri)
	{
		Class1454 @class = smethod_1(extensionListElementData, uri);
		if (@class == null)
		{
			@class = (Class1454)extensionListElementData.delegate383_0();
			@class.OuterXml = "<p:ext uri=\"" + uri + "\" xmlns:p=\"http://schemas.openxmlformats.org/presentationml/2006/main\"></p:ext>";
		}
		return @class;
	}
}
