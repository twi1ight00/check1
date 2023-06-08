using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1597 : Class1351
{
	public delegate Class1597 Delegate670();

	public delegate void Delegate671(Class1597 elementData);

	public delegate void Delegate672(Class1597 elementData);

	public Class1596.Delegate667 delegate667_0;

	public Class1596.Delegate668 delegate668_0;

	private List<Class1596> list_0;

	public Class1596[] OleItemList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "oleItem")
				{
					Class1596 item = new Class1596(reader);
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

	public Class1597(XmlReader reader)
		: base(reader)
	{
	}

	public Class1597()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1596>();
	}

	protected override void vmethod_2()
	{
		delegate667_0 = method_3;
		delegate668_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1596 item in list_0)
		{
			item.vmethod_4("ssml", writer, "oleItem");
		}
		writer.WriteEndElement();
	}

	private Class1596 method_3()
	{
		Class1596 @class = new Class1596();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1596 elementData)
	{
		list_0.Add(elementData);
	}
}
