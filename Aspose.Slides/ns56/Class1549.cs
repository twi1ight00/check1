using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1549 : Class1351
{
	public delegate void Delegate528(Class1549 elementData);

	public delegate Class1549 Delegate526();

	public delegate void Delegate527(Class1549 elementData);

	public Class1548.Delegate523 delegate523_0;

	public Class1548.Delegate524 delegate524_0;

	private List<Class1548> list_0;

	public Class1548[] HyperlinkList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "hyperlink")
				{
					Class1548 item = new Class1548(reader);
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

	public Class1549(XmlReader reader)
		: base(reader)
	{
	}

	public Class1549()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1548>();
	}

	protected override void vmethod_2()
	{
		delegate523_0 = method_3;
		delegate524_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1548 item in list_0)
		{
			item.vmethod_4("ssml", writer, "hyperlink");
		}
		writer.WriteEndElement();
	}

	private Class1548 method_3()
	{
		Class1548 @class = new Class1548();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1548 elementData)
	{
		list_0.Add(elementData);
	}
}
