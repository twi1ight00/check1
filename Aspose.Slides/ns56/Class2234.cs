using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2234 : Class1351
{
	public delegate Class2234 Delegate2440();

	public delegate void Delegate2442(Class2234 elementData);

	public delegate void Delegate2441(Class2234 elementData);

	public Class2132.Delegate2127 delegate2127_0;

	public Class2132.Delegate2128 delegate2128_0;

	private List<Class2132> list_0;

	public Class2132[] EmbeddedFontList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "embeddedFont")
				{
					Class2132 item = new Class2132(reader);
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

	public Class2234(XmlReader reader)
		: base(reader)
	{
	}

	public Class2234()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2132>();
	}

	protected override void vmethod_2()
	{
		delegate2127_0 = method_3;
		delegate2128_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2132 item in list_0)
		{
			item.vmethod_4("p", writer, "embeddedFont");
		}
		writer.WriteEndElement();
	}

	private Class2132 method_3()
	{
		Class2132 @class = new Class2132();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2132 elementData)
	{
		list_0.Add(elementData);
	}
}
