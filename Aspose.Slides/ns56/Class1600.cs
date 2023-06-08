using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1600 : Class1351
{
	public delegate void Delegate681(Class1600 elementData);

	public delegate Class1600 Delegate679();

	public delegate void Delegate680(Class1600 elementData);

	public Class1599.Delegate676 delegate676_0;

	public Class1599.Delegate677 delegate677_0;

	private List<Class1599> list_0;

	public Class1599[] OleObjectList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "oleObject")
				{
					Class1599 item = new Class1599(reader);
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

	public Class1600(XmlReader reader)
		: base(reader)
	{
	}

	public Class1600()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1599>();
	}

	protected override void vmethod_2()
	{
		delegate676_0 = method_3;
		delegate677_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1599 item in list_0)
		{
			item.vmethod_4("ssml", writer, "oleObject");
		}
		writer.WriteEndElement();
	}

	private Class1599 method_3()
	{
		Class1599 @class = new Class1599();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1599 elementData)
	{
		list_0.Add(elementData);
	}
}
