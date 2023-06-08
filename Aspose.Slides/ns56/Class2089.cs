using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2089 : Class1351
{
	public delegate Class2089 Delegate1985();

	public delegate void Delegate1986(Class2089 elementData);

	public delegate void Delegate1987(Class2089 elementData);

	public Class2121.Delegate2091 delegate2091_0;

	public Class2121.Delegate2092 delegate2092_0;

	private List<Class2121> list_0;

	public Class2121[] PtList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "pt")
				{
					Class2121 item = new Class2121(reader);
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

	public Class2089(XmlReader reader)
		: base(reader)
	{
	}

	public Class2089()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2121>();
	}

	protected override void vmethod_2()
	{
		delegate2091_0 = method_3;
		delegate2092_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2121 item in list_0)
		{
			item.vmethod_4("c", writer, "pt");
		}
		writer.WriteEndElement();
	}

	private Class2121 method_3()
	{
		Class2121 @class = new Class2121();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2121 elementData)
	{
		list_0.Add(elementData);
	}
}
