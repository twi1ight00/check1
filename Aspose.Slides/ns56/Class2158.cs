using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2158 : Class1351
{
	public delegate Class2158 Delegate2206();

	public delegate void Delegate2208(Class2158 elementData);

	public delegate void Delegate2207(Class2158 elementData);

	public Class2159.Delegate2209 delegate2209_0;

	public Class2159.Delegate2210 delegate2210_0;

	private List<Class2159> list_0;

	public Class2159[] CatList => list_0.ToArray();

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
					Class2159 item = new Class2159(reader);
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

	public Class2158(XmlReader reader)
		: base(reader)
	{
	}

	public Class2158()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2159>();
	}

	protected override void vmethod_2()
	{
		delegate2209_0 = method_3;
		delegate2210_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2159 item in list_0)
		{
			item.vmethod_4("dgm", writer, "cat");
		}
		writer.WriteEndElement();
	}

	private Class2159 method_3()
	{
		Class2159 @class = new Class2159();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2159 elementData)
	{
		list_0.Add(elementData);
	}
}
