using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1387 : Class1351
{
	public delegate Class1387 Delegate123();

	public delegate void Delegate124(Class1387 elementData);

	public delegate void Delegate125(Class1387 elementData);

	public Class1386.Delegate120 delegate120_0;

	public Class1386.Delegate121 delegate121_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private List<Class1386> list_0;

	private Class1502 class1502_0;

	public Class1386[] CList => list_0.ToArray();

	public Class1502 ExtLst => class1502_0;

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
					class1502_0 = new Class1502(reader);
					break;
				case "c":
				{
					Class1386 item = new Class1386(reader);
					list_0.Add(item);
					break;
				}
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
	}

	public Class1387(XmlReader reader)
		: base(reader)
	{
	}

	public Class1387()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1386>();
	}

	protected override void vmethod_2()
	{
		delegate120_0 = method_3;
		delegate121_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		foreach (Class1386 item in list_0)
		{
			item.vmethod_4("ssml", writer, "c");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1386 method_3()
	{
		Class1386 @class = new Class1386();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1386 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
