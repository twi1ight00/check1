using System;
using System.Xml;

namespace ns56;

internal class Class2318 : Class1351
{
	public delegate Class2318 Delegate2701();

	public delegate void Delegate2702(Class2318 elementData);

	public delegate void Delegate2703(Class2318 elementData);

	public const string string_0 = "";

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class1820.Delegate1339 delegate1339_0;

	public Class1820.Delegate1341 delegate1341_0;

	public Class1827.Delegate1360 delegate1360_0;

	public Class1827.Delegate1362 delegate1362_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_1;

	private Class1805 class1805_0;

	private Class1457 class1457_0;

	private Class1820 class1820_0;

	private Class1827 class1827_0;

	private Class1886 class1886_0;

	public string Name
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Class1805 ThemeElements => class1805_0;

	public Class1457 ObjectDefaults => class1457_0;

	public Class1820 ExtraClrSchemeLst => class1820_0;

	public Class1827 CustClrLst => class1827_0;

	public Class1885 ExtLst => class1886_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				switch (reader.LocalName)
				{
				case "extLst":
					class1886_0 = new Class1886(reader);
					break;
				case "custClrLst":
					class1827_0 = new Class1827(reader);
					break;
				case "extraClrSchemeLst":
					class1820_0 = new Class1820(reader);
					break;
				case "objectDefaults":
					class1457_0 = new Class1457(reader);
					flag = true;
					break;
				case "themeElements":
					class1805_0 = new Class1805(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "name")
			{
				string_1 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2318(XmlReader reader)
		: base(reader)
	{
	}

	public Class2318()
	{
	}

	protected override void vmethod_1()
	{
		string_1 = "";
	}

	protected override void vmethod_2()
	{
		delegate303_0 = method_3;
		delegate304_0 = method_4;
		delegate1339_0 = method_5;
		delegate1341_0 = method_6;
		delegate1360_0 = method_7;
		delegate1362_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
		class1805_0 = new Class1805();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("a", elementName, "http://schemas.openxmlformats.org/drawingml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (string_1 != "")
		{
			writer.WriteAttributeString("name", string_1);
		}
		class1805_0.vmethod_4("a", writer, "themeElements");
		if (class1457_0 != null)
		{
			class1457_0.vmethod_4("a", writer, "objectDefaults");
		}
		if (class1820_0 != null)
		{
			class1820_0.vmethod_4("a", writer, "extraClrSchemeLst");
		}
		if (class1827_0 != null)
		{
			class1827_0.vmethod_4("a", writer, "custClrLst");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1447 method_3()
	{
		if (class1457_0 != null)
		{
			throw new Exception("Only one <objectDefaults> element can be added.");
		}
		class1457_0 = new Class1457();
		return class1457_0;
	}

	private void method_4(Class1447 _objectDefaults)
	{
		class1457_0 = (Class1457)_objectDefaults;
	}

	private Class1820 method_5()
	{
		if (class1820_0 != null)
		{
			throw new Exception("Only one <extraClrSchemeLst> element can be added.");
		}
		class1820_0 = new Class1820();
		return class1820_0;
	}

	private void method_6(Class1820 _extraClrSchemeLst)
	{
		class1820_0 = _extraClrSchemeLst;
	}

	private Class1827 method_7()
	{
		if (class1827_0 != null)
		{
			throw new Exception("Only one <custClrLst> element can be added.");
		}
		class1827_0 = new Class1827();
		return class1827_0;
	}

	private void method_8(Class1827 _custClrLst)
	{
		class1827_0 = _custClrLst;
	}

	private Class1885 method_9()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
