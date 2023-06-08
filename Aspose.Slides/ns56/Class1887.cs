using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1887 : Class1885
{
	public delegate void Delegate1936(Class1887 elementData);

	private List<Class1452> list_0;

	public override Class1449[] ExtList => list_0.ToArray();

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_3(reader);
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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "ext")
				{
					Class1452 item = new Class1452(reader);
					list_0.Add(item);
					flag = true;
				}
				else
				{
					reader.Skip();
					flag = true;
				}
			}
		}
	}

	private void method_3(XmlReader reader)
	{
	}

	public Class1887(XmlReader reader)
		: base(reader)
	{
	}

	public Class1887()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1452>();
	}

	protected override void vmethod_2()
	{
		delegate383_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1452 item in list_0)
		{
			item.vmethod_4("c", writer, "ext");
		}
		writer.WriteEndElement();
	}

	private Class1449 method_4()
	{
		Class1452 @class = new Class1452();
		list_0.Add(@class);
		return @class;
	}

	private void method_5(Class1452 elementData)
	{
		list_0.Add(elementData);
	}
}
