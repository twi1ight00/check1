using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1855 : Class1351
{
	public delegate Class1855 Delegate1444();

	public delegate void Delegate1446(Class1855 elementData);

	public delegate void Delegate1445(Class1855 elementData);

	public Class1854.Delegate1441 delegate1441_0;

	public Class1854.Delegate1442 delegate1442_0;

	private List<Class1854> list_0;

	public Class1854[] GsList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "gs")
				{
					Class1854 item = new Class1854(reader);
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

	public Class1855(XmlReader reader)
		: base(reader)
	{
	}

	public Class1855()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1854>();
	}

	protected override void vmethod_2()
	{
		delegate1441_0 = method_3;
		delegate1442_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1854 item in list_0)
		{
			item.vmethod_4("a", writer, "gs");
		}
		writer.WriteEndElement();
	}

	private Class1854 method_3()
	{
		Class1854 @class = new Class1854();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1854 elementData)
	{
		list_0.Add(elementData);
	}
}
