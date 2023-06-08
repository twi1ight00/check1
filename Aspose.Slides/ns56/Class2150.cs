using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2150 : Class1351
{
	public delegate Class2150 Delegate2182();

	public delegate void Delegate2183(Class2150 elementData);

	public delegate void Delegate2184(Class2150 elementData);

	public Class2151.Delegate2185 delegate2185_0;

	public Class2151.Delegate2186 delegate2186_0;

	private List<Class2151> list_0;

	public Class2151[] CatList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cat")
				{
					Class2151 item = new Class2151(reader);
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

	public Class2150(XmlReader reader)
		: base(reader)
	{
	}

	public Class2150()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2151>();
	}

	protected override void vmethod_2()
	{
		delegate2185_0 = method_3;
		delegate2186_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2151 item in list_0)
		{
			item.vmethod_4("dgm", writer, "cat");
		}
		writer.WriteEndElement();
	}

	private Class2151 method_3()
	{
		Class2151 @class = new Class2151();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2151 elementData)
	{
		list_0.Add(elementData);
	}
}
