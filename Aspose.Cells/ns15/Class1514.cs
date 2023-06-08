using System.IO;
using System.Xml;
using Aspose.Cells;
using ns16;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1514
{
	private Workbook workbook_0;

	private Class1489 class1489_0;

	private XmlTextReader xmlTextReader_0;

	private bool bool_0;

	private Class1523 class1523_0;

	private Class1508 class1508_0;

	internal Class1514(Workbook workbook_1, Class1489 class1489_1, bool bool_1)
	{
		workbook_0 = workbook_1;
		class1489_0 = class1489_1;
		bool_0 = bool_1;
	}

	internal void method_0()
	{
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
			string text;
			if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "automatic-styles")
			{
				if (bool_0)
				{
					xmlTextReader_0.Skip();
					continue;
				}
				Class1518 @class = new Class1518(class1489_0, bool_3: false);
				@class.method_0(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		class1523_0 = null;
	}

	internal void method_1(Class746 class746_0)
	{
		Class744 class744_ = class746_0.method_38("content.xml");
		Stream stream = class746_0.method_39(class744_);
		xmlTextReader_0 = Class1029.smethod_1(stream);
		method_0();
		stream.Seek(0L, SeekOrigin.Begin);
		xmlTextReader_0 = Class1029.smethod_1(stream);
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
			case "body":
				method_4();
				break;
			case "automatic-styles":
			{
				if (bool_0)
				{
					xmlTextReader_0.Skip();
					break;
				}
				Class1518 @class = new Class1518(class1489_0, bool_3: false);
				@class.method_1(xmlTextReader_0);
				break;
			}
			case "font-face-decls":
				if (bool_0)
				{
					xmlTextReader_0.Skip();
				}
				else
				{
					method_2();
				}
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		class1523_0 = null;
	}

	[Attribute0(true)]
	private void method_2()
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
				method_3();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_3()
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
			xmlTextReader_0.MoveToElement();
		}
		if (text != null && class1489_0.hashtable_10[text] == null)
		{
			class1489_0.hashtable_10.Add(text, value);
		}
		xmlTextReader_0.Skip();
	}

	private void method_4()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string text;
			if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "spreadsheet")
			{
				method_5();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	private void method_5()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int num = 0;
		class1489_0.hashtable_0[class1489_0.string_0] = 15;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "content-validations":
				method_6();
				break;
			case "named-expressions":
				if (!bool_0)
				{
					method_7();
				}
				else
				{
					xmlTextReader_0.Skip();
				}
				break;
			case "table":
				if (bool_0)
				{
					if (class1508_0 == null)
					{
						class1508_0 = new Class1508(class1489_0);
					}
					class1508_0.Read(xmlTextReader_0, (Class1490)class1489_0.arrayList_0[num++]);
				}
				else
				{
					if (class1523_0 == null)
					{
						class1523_0 = new Class1523(class1489_0);
					}
					class1523_0.Read(xmlTextReader_0);
				}
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	private void method_6()
	{
		xmlTextReader_0.Skip();
	}

	private void method_7()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "named-expression":
			case "named-range":
				method_8();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	private void method_8()
	{
		string text = null;
		string text2 = null;
		string text3 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "cell-range-address":
					text3 = xmlTextReader_0.Value;
					break;
				case "expression":
					text2 = xmlTextReader_0.Value;
					break;
				case "name":
					text = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		if (text != null && !text.StartsWith("Excel_BuiltIn"))
		{
			if (text2 != null && text2 != "")
			{
				Name name = new Name(workbook_0.Worksheets, text);
				name.RefersTo = Class1508.smethod_0(text2, null);
				workbook_0.Worksheets.Names.method_3(name, bool_0: false);
			}
			else if (text3 != null && text3 != "")
			{
				Name name2 = new Name(workbook_0.Worksheets, text);
				string text4 = Class1516.smethod_3(text3);
				name2.RefersTo = '=' + text4;
				workbook_0.Worksheets.Names.method_3(name2, bool_0: false);
			}
		}
	}
}
