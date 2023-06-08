using System.Collections;
using System.Drawing;
using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1612
{
	private Class1547 class1547_0;

	private Workbook workbook_0;

	private string string_0;

	private XmlDocument xmlDocument_0;

	internal Class1612(Class1547 class1547_1, string string_1)
	{
		class1547_0 = class1547_1;
		workbook_0 = class1547_1.workbook_0;
		string_0 = string_1;
	}

	internal Class1612(Workbook workbook_1, string string_1)
	{
		workbook_0 = workbook_1;
		string_0 = string_1;
	}

	internal void Read(XmlDocument xmlDocument_1)
	{
		xmlDocument_0 = xmlDocument_1;
		method_0();
	}

	private void method_0()
	{
		if (xmlDocument_0.DocumentElement != null && xmlDocument_0.DocumentElement.NamespaceURI == "http://schemas.openxmlformats.org/drawingml/2006/3/main" && workbook_0.class1558_0 != null)
		{
			workbook_0.class1558_0.bool_2 = true;
		}
		XmlElement xmlElement = Class1618.smethod_173(xmlDocument_0.DocumentElement, "themeElements");
		if (xmlElement == null)
		{
			return;
		}
		foreach (object childNode in xmlElement.ChildNodes)
		{
			if (childNode is XmlElement)
			{
				XmlElement xmlElement2 = (XmlElement)childNode;
				string localName = xmlElement2.LocalName;
				if (localName == "clrScheme")
				{
					method_3(xmlElement2);
				}
				else if (localName == "fontScheme")
				{
					method_1(xmlElement2);
				}
			}
		}
	}

	private void method_1(XmlElement xmlElement_0)
	{
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "majorFont");
		if (xmlElement != null)
		{
			workbook_0.class1569_0.class1193_0.class1192_0 = method_2(xmlElement);
		}
		XmlElement xmlElement2 = Class1618.smethod_173(xmlElement_0, "minorFont");
		if (xmlElement2 != null)
		{
			workbook_0.class1569_0.class1193_0.class1192_1 = method_2(xmlElement2);
		}
	}

	private Class1192 method_2(XmlElement xmlElement_0)
	{
		Class1192 @class = new Class1192();
		foreach (object childNode in xmlElement_0.ChildNodes)
		{
			if (!(childNode is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNode;
			switch (xmlElement.LocalName)
			{
			case "latin":
			{
				string text5 = Class1618.smethod_172(xmlElement, "typeface");
				if (text5 != null && text5 != "")
				{
					@class.string_0 = text5;
				}
				break;
			}
			case "ea":
			{
				string text4 = Class1618.smethod_172(xmlElement, "typeface");
				if (text4 != null && text4 != "")
				{
					@class.string_1 = text4;
				}
				break;
			}
			case "cs":
			{
				string text3 = Class1618.smethod_172(xmlElement, "typeface");
				if (text3 != null && text3 != "")
				{
					@class.string_2 = text3;
				}
				break;
			}
			case "font":
			{
				string text = Class1618.smethod_172(xmlElement, "script");
				string text2 = Class1618.smethod_172(xmlElement, "typeface");
				if (text != null && text2 != null)
				{
					int num = workbook_0.class1569_0.class1193_0.method_2(text);
					if (num != -1)
					{
						@class.hashtable_0[num] = text2;
					}
				}
				break;
			}
			}
		}
		return @class;
	}

	private void method_3(XmlElement xmlElement_0)
	{
		workbook_0.class1569_0.string_0 = Class1618.smethod_172(xmlElement_0, "name");
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			object obj = childNodes[i];
			if (obj is XmlElement)
			{
				Class928 @class = method_4((XmlElement)obj);
				if (@class != null)
				{
					int num = Class1618.smethod_159(@class.string_0);
					workbook_0.class1569_0.class928_0[num] = @class;
				}
			}
		}
	}

	private Class928 method_4(XmlElement xmlElement_0)
	{
		Class928 @class = new Class928();
		@class.Color = Color.Empty;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string text = null;
			if (xmlElement.LocalName == "sysClr")
			{
				XmlAttribute xmlAttribute = Class1188.smethod_6(xmlElement, "lastClr");
				if (xmlAttribute != null)
				{
					text = xmlAttribute.Value;
				}
				XmlAttribute xmlAttribute2 = Class1188.smethod_6(xmlElement, "val");
				if (xmlAttribute2 != null)
				{
					@class.string_1 = xmlAttribute2.Value;
					if (text == null)
					{
						text = ((!(xmlAttribute2.Value == "window")) ? "000000" : "ffffff");
					}
				}
				@class.method_1(bool_1: true);
			}
			if (xmlElement.LocalName == "srgbClr")
			{
				XmlAttribute xmlAttribute3 = Class1188.smethod_6(xmlElement, "val");
				if (xmlAttribute3 != null)
				{
					text = xmlAttribute3.Value;
				}
				ArrayList arrayList = new ArrayList();
				IEnumerator enumerator = xmlElement.Attributes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlAttribute xmlAttribute4 = (XmlAttribute)enumerator.Current;
					if (!(xmlAttribute4.Name == "val"))
					{
						arrayList.Add(new Class927(xmlAttribute4.Name, xmlAttribute4.Value));
					}
				}
				if (arrayList.Count > 0)
				{
					@class.class1363_0.Add(Enum129.const_3, arrayList);
				}
			}
			if (text != null)
			{
				@class.color_0 = Class1618.smethod_63(text);
			}
			break;
		}
		@class.string_0 = xmlElement_0.LocalName;
		if (Class1178.smethod_0(@class.Color))
		{
			return null;
		}
		return @class;
	}
}
