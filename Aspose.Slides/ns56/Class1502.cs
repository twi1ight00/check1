using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1502 : Class1351
{
	public delegate void Delegate387(Class1502 elementData);

	public delegate Class1502 Delegate385();

	public delegate void Delegate386(Class1502 elementData);

	public Class1449.Delegate383 delegate383_0;

	private List<Class1450> list_0;

	public Class1449[] ExtList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "ext")
				{
					Class1450 item = new Class1450(reader);
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

	private void method_2(XmlReader reader)
	{
	}

	public Class1502(XmlReader reader)
		: base(reader)
	{
	}

	public Class1502()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1450>();
	}

	protected override void vmethod_2()
	{
		delegate383_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1450 item in list_0)
		{
			item.vmethod_4("ssml", writer, "ext");
		}
		writer.WriteEndElement();
	}

	private Class1449 method_3()
	{
		Class1450 @class = new Class1450();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1450 elementData)
	{
		list_0.Add(elementData);
	}
}
