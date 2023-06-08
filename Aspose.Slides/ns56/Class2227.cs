using System;
using System.Xml;

namespace ns56;

internal class Class2227 : Class1351
{
	public delegate Class2227 Delegate2417();

	public delegate void Delegate2418(Class2227 elementData);

	public delegate void Delegate2419(Class2227 elementData);

	public const string string_0 = "";

	public Class2222.Delegate2402 delegate2402_0;

	public Class2222.Delegate2404 delegate2404_0;

	public Class2232.Delegate2434 delegate2434_0;

	public Class2232.Delegate2436 delegate2436_0;

	public Class2229.Delegate2425 delegate2425_0;

	public Class2229.Delegate2427 delegate2427_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_1;

	private Class2222 class2222_0;

	private Class1998 class1998_0;

	private Class2232 class2232_0;

	private Class2229 class2229_0;

	private Class1888 class1888_0;

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

	public Class2222 Bg => class2222_0;

	public Class1995 SpTree => class1998_0;

	public Class2232 CustDataLst => class2232_0;

	public Class2229 Controls => class2229_0;

	public Class1885 ExtLst => class1888_0;

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
					class1888_0 = new Class1888(reader);
					break;
				case "controls":
					class2229_0 = new Class2229(reader);
					break;
				case "custDataLst":
					class2232_0 = new Class2232(reader);
					break;
				case "spTree":
					class1998_0 = new Class1998(reader);
					break;
				case "bg":
					class2222_0 = new Class2222(reader);
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

	public Class2227(XmlReader reader)
		: base(reader)
	{
	}

	public Class2227()
	{
	}

	protected override void vmethod_1()
	{
		string_1 = "";
	}

	protected override void vmethod_2()
	{
		delegate2402_0 = method_3;
		delegate2404_0 = method_4;
		delegate2434_0 = method_5;
		delegate2436_0 = method_6;
		delegate2425_0 = method_7;
		delegate2427_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
		class1998_0 = new Class1998();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_1 != "")
		{
			writer.WriteAttributeString("name", string_1);
		}
		if (class2222_0 != null)
		{
			class2222_0.vmethod_4("p", writer, "bg");
		}
		class1998_0.vmethod_4("p", writer, "spTree");
		if (class2232_0 != null)
		{
			class2232_0.vmethod_4("p", writer, "custDataLst");
		}
		if (class2229_0 != null)
		{
			class2229_0.vmethod_4("p", writer, "controls");
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2222 method_3()
	{
		if (class2222_0 != null)
		{
			throw new Exception("Only one <bg> element can be added.");
		}
		class2222_0 = new Class2222();
		return class2222_0;
	}

	private void method_4(Class2222 _bg)
	{
		class2222_0 = _bg;
	}

	private Class2232 method_5()
	{
		if (class2232_0 != null)
		{
			throw new Exception("Only one <custDataLst> element can be added.");
		}
		class2232_0 = new Class2232();
		return class2232_0;
	}

	private void method_6(Class2232 _custDataLst)
	{
		class2232_0 = _custDataLst;
	}

	private Class2229 method_7()
	{
		if (class2229_0 != null)
		{
			throw new Exception("Only one <controls> element can be added.");
		}
		class2229_0 = new Class2229();
		return class2229_0;
	}

	private void method_8(Class2229 _controls)
	{
		class2229_0 = _controls;
	}

	private Class1885 method_9()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}
}
