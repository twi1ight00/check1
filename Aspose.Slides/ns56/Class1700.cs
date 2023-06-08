using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1700 : Class1351
{
	public delegate Class1700 Delegate979();

	public delegate void Delegate980(Class1700 elementData);

	public delegate void Delegate981(Class1700 elementData);

	public Class1699.Delegate976 delegate976_0;

	public Class1699.Delegate977 delegate977_0;

	private List<Class1699> list_0;

	public Class1699[] SingleXmlCellList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "singleXmlCell")
				{
					Class1699 item = new Class1699(reader);
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

	public Class1700(XmlReader reader)
		: base(reader)
	{
	}

	public Class1700()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1699>();
	}

	protected override void vmethod_2()
	{
		delegate976_0 = method_3;
		delegate977_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		foreach (Class1699 item in list_0)
		{
			item.vmethod_4("ssml", writer, "singleXmlCell");
		}
		writer.WriteEndElement();
	}

	private Class1699 method_3()
	{
		Class1699 @class = new Class1699();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1699 elementData)
	{
		list_0.Add(elementData);
	}
}
