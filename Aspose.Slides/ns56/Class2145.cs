using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2145 : Class1351
{
	public delegate Class2145 Delegate2167();

	public delegate void Delegate2168(Class2145 elementData);

	public delegate void Delegate2169(Class2145 elementData);

	public Class2144.Delegate2164 delegate2164_0;

	public Class2144.Delegate2165 delegate2165_0;

	private List<Class2144> list_0;

	public Class2144[] AdjList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "adj")
				{
					Class2144 item = new Class2144(reader);
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

	public Class2145(XmlReader reader)
		: base(reader)
	{
	}

	public Class2145()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2144>();
	}

	protected override void vmethod_2()
	{
		delegate2164_0 = method_3;
		delegate2165_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2144 item in list_0)
		{
			item.vmethod_4("dgm", writer, "adj");
		}
		writer.WriteEndElement();
	}

	private Class2144 method_3()
	{
		Class2144 @class = new Class2144();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2144 elementData)
	{
		list_0.Add(elementData);
	}
}
