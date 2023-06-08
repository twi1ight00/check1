using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1896 : Class1351
{
	public delegate Class1896 Delegate1555();

	public delegate void Delegate1556(Class1896 elementData);

	public delegate void Delegate1557(Class1896 elementData);

	public Class1894.Delegate1549 delegate1549_0;

	public Class1894.Delegate1550 delegate1550_0;

	private List<Class1894> list_0;

	public Class1894[] PathList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "path")
				{
					Class1894 item = new Class1894(reader);
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

	public Class1896(XmlReader reader)
		: base(reader)
	{
	}

	public Class1896()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1894>();
	}

	protected override void vmethod_2()
	{
		delegate1549_0 = method_3;
		delegate1550_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1894 item in list_0)
		{
			item.vmethod_4("a", writer, "path");
		}
		writer.WriteEndElement();
	}

	private Class1894 method_3()
	{
		Class1894 @class = new Class1894();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1894 elementData)
	{
		list_0.Add(elementData);
	}
}
