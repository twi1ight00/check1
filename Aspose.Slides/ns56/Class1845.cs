using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1845 : Class1351
{
	public delegate Class1845 Delegate1414();

	public delegate void Delegate1415(Class1845 elementData);

	public delegate void Delegate1416(Class1845 elementData);

	public Class1930.Delegate1657 delegate1657_0;

	public Class1930.Delegate1658 delegate1658_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1956 class1956_0;

	private Class1956 class1956_1;

	private Class1956 class1956_2;

	private List<Class1930> list_0;

	private Class1886 class1886_0;

	public Class1956 Latin => class1956_0;

	public Class1956 Ea => class1956_1;

	public Class1956 Cs => class1956_2;

	public Class1930[] FontList => list_0.ToArray();

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
				case "font":
				{
					Class1930 item = new Class1930(reader);
					list_0.Add(item);
					break;
				}
				case "cs":
					class1956_2 = new Class1956(reader);
					break;
				case "ea":
					class1956_1 = new Class1956(reader);
					break;
				case "latin":
					class1956_0 = new Class1956(reader);
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
	}

	public Class1845(XmlReader reader)
		: base(reader)
	{
	}

	public Class1845()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1930>();
	}

	protected override void vmethod_2()
	{
		delegate1657_0 = method_3;
		delegate1658_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class1956_0 = new Class1956();
		class1956_1 = new Class1956();
		class1956_2 = new Class1956();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1956_0.vmethod_4("a", writer, "latin");
		class1956_1.vmethod_4("a", writer, "ea");
		class1956_2.vmethod_4("a", writer, "cs");
		foreach (Class1930 item in list_0)
		{
			item.vmethod_4("a", writer, "font");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1930 method_3()
	{
		Class1930 @class = new Class1930();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1930 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1885 method_5()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
