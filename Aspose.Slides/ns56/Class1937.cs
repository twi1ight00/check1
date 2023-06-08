using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1937 : Class1351
{
	public delegate Class1937 Delegate1678();

	public delegate void Delegate1679(Class1937 elementData);

	public delegate void Delegate1680(Class1937 elementData);

	public Class1936.Delegate1675 delegate1675_0;

	public Class1936.Delegate1676 delegate1676_0;

	private List<Class1936> list_0;

	public Class1936[] GridColList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "gridCol")
				{
					Class1936 item = new Class1936(reader);
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

	public Class1937(XmlReader reader)
		: base(reader)
	{
	}

	public Class1937()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1936>();
	}

	protected override void vmethod_2()
	{
		delegate1675_0 = method_3;
		delegate1676_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1936 item in list_0)
		{
			item.vmethod_4("a", writer, "gridCol");
		}
		writer.WriteEndElement();
	}

	private Class1936 method_3()
	{
		Class1936 @class = new Class1936();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1936 elementData)
	{
		list_0.Add(elementData);
	}
}
