using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1555 : Class1351
{
	public delegate Class1555 Delegate544();

	public delegate void Delegate546(Class1555 elementData);

	public delegate void Delegate545(Class1555 elementData);

	public Class1670.Delegate889 delegate889_0;

	public Class1670.Delegate890 delegate890_0;

	private List<Class1670> list_0;

	public Class1670[] RgbColorList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "rgbColor")
				{
					Class1670 item = new Class1670(reader);
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

	public Class1555(XmlReader reader)
		: base(reader)
	{
	}

	public Class1555()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1670>();
	}

	protected override void vmethod_2()
	{
		delegate889_0 = method_3;
		delegate890_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1670 item in list_0)
		{
			item.vmethod_4("ssml", writer, "rgbColor");
		}
		writer.WriteEndElement();
	}

	private Class1670 method_3()
	{
		Class1670 @class = new Class1670();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1670 elementData)
	{
		list_0.Add(elementData);
	}
}
