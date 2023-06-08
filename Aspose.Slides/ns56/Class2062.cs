using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2062 : Class1351
{
	public delegate Class2062 Delegate1898();

	public delegate void Delegate1900(Class2062 elementData);

	public delegate void Delegate1899(Class2062 elementData);

	public Class2135.Delegate2136 delegate2136_0;

	public Class2135.Delegate2137 delegate2137_0;

	private List<Class2135> list_0;

	public Class2135[] SecondPiePtList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "secondPiePt")
				{
					Class2135 item = new Class2135(reader);
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

	public Class2062(XmlReader reader)
		: base(reader)
	{
	}

	public Class2062()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2135>();
	}

	protected override void vmethod_2()
	{
		delegate2136_0 = method_3;
		delegate2137_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2135 item in list_0)
		{
			item.vmethod_4("c", writer, "secondPiePt");
		}
		writer.WriteEndElement();
	}

	private Class2135 method_3()
	{
		Class2135 @class = new Class2135();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2135 elementData)
	{
		list_0.Add(elementData);
	}
}
