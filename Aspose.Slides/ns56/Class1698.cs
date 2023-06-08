using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1698 : Class1351
{
	public delegate void Delegate975(Class1698 elementData);

	public delegate Class1698 Delegate973();

	public delegate void Delegate974(Class1698 elementData);

	public Class1697.Delegate970 delegate970_0;

	public Class1697.Delegate971 delegate971_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private List<Class1697> list_0;

	private Class1502 class1502_0;

	public Class1697[] SheetViewList => list_0.ToArray();

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
				case "sheetView":
				{
					Class1697 item = new Class1697(reader);
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

	public Class1698(XmlReader reader)
		: base(reader)
	{
	}

	public Class1698()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1697>();
	}

	protected override void vmethod_2()
	{
		delegate970_0 = method_3;
		delegate971_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1697 item in list_0)
		{
			item.vmethod_4("ssml", writer, "sheetView");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1697 method_3()
	{
		Class1697 @class = new Class1697();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1697 elementData)
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
