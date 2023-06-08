using System.Xml;
using ns16;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1513
{
	private Class1489 class1489_0;

	private XmlTextReader xmlTextReader_0;

	internal Class1513(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
	}

	internal void Read(Class746 class746_0)
	{
		xmlTextReader_0 = Class1521.smethod_0(class746_0, "styles.xml");
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		if (!Class536.smethod_4(xmlTextReader_0))
		{
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "master-styles":
			{
				Class1511 class3 = new Class1511(class1489_0);
				class3.Read(xmlTextReader_0);
				break;
			}
			case "automatic-styles":
			{
				Class1507 class2 = new Class1507(class1489_0);
				class2.Read(xmlTextReader_0);
				break;
			}
			case "styles":
			{
				Class1518 @class = new Class1518(class1489_0, bool_3: true);
				@class.Read(xmlTextReader_0);
				break;
			}
			case "font-face-decls":
				method_0();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	[Attribute0(true)]
	private void method_0()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null && localName == "font-face")
			{
				method_1();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_1()
	{
		string text = null;
		string value = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "font-family":
					value = xmlTextReader_0.Value;
					break;
				case "name":
					text = xmlTextReader_0.Value;
					break;
				}
			}
		}
		if (text != null && class1489_0.hashtable_10[text] == null)
		{
			class1489_0.hashtable_10.Add(text, value);
		}
		xmlTextReader_0.Skip();
	}
}
