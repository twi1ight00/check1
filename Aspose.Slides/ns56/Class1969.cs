using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1969 : Class1351
{
	public delegate Class1969 Delegate1774();

	public delegate void Delegate1776(Class1969 elementData);

	public delegate void Delegate1775(Class1969 elementData);

	public Class1968.Delegate1771 delegate1771_0;

	public Class1968.Delegate1772 delegate1772_0;

	private List<Class1968> list_0;

	public Class1968[] TabList => list_0.ToArray();

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "tab")
				{
					Class1968 item = new Class1968(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class1969(XmlReader reader)
		: base(reader)
	{
	}

	public Class1969()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1968>();
	}

	protected override void vmethod_2()
	{
		delegate1771_0 = method_3;
		delegate1772_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1968 item in list_0)
		{
			item.vmethod_4("a", writer, "tab");
		}
		writer.WriteEndElement();
	}

	private Class1968 method_3()
	{
		Class1968 @class = new Class1968();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1968 elementData)
	{
		list_0.Add(elementData);
	}
}
