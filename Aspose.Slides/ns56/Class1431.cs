using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1431 : Class1351
{
	public delegate Class1431 Delegate255();

	public delegate void Delegate256(Class1431 elementData);

	public delegate void Delegate257(Class1431 elementData);

	public Class1430.Delegate252 delegate252_0;

	public Class1430.Delegate253 delegate253_0;

	private List<Class1430> list_0;

	public Class1430[] ConnectionList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "connection")
				{
					Class1430 item = new Class1430(reader);
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

	public Class1431(XmlReader reader)
		: base(reader)
	{
	}

	public Class1431()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1430>();
	}

	protected override void vmethod_2()
	{
		delegate252_0 = method_3;
		delegate253_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		foreach (Class1430 item in list_0)
		{
			item.vmethod_4("ssml", writer, "connection");
		}
		writer.WriteEndElement();
	}

	private Class1430 method_3()
	{
		Class1430 @class = new Class1430();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1430 elementData)
	{
		list_0.Add(elementData);
	}
}
