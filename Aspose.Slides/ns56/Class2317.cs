using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2317 : Class1351
{
	public delegate Class2317 Delegate2698();

	public delegate void Delegate2699(Class2317 elementData);

	public delegate void Delegate2700(Class2317 elementData);

	public Class2262.Delegate2533 delegate2533_0;

	public Class2262.Delegate2534 delegate2534_0;

	private List<Class2262> list_0;

	public Class2262[] TagList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tag")
				{
					Class2262 item = new Class2262(reader);
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

	public Class2317(XmlReader reader)
		: base(reader)
	{
	}

	public Class2317()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2262>();
	}

	protected override void vmethod_2()
	{
		delegate2533_0 = method_3;
		delegate2534_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		foreach (Class2262 item in list_0)
		{
			item.vmethod_4("p", writer, "tag");
		}
		writer.WriteEndElement();
	}

	private Class2262 method_3()
	{
		Class2262 @class = new Class2262();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2262 elementData)
	{
		list_0.Add(elementData);
	}
}
