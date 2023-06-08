using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2157 : Class1351
{
	public delegate Class2157 Delegate2203();

	public delegate void Delegate2204(Class2157 elementData);

	public delegate void Delegate2205(Class2157 elementData);

	public Class2156.Delegate2200 delegate2200_0;

	public Class2156.Delegate2201 delegate2201_0;

	private List<Class2156> list_0;

	public Class2156[] ConstrList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "constr")
				{
					Class2156 item = new Class2156(reader);
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

	public Class2157(XmlReader reader)
		: base(reader)
	{
	}

	public Class2157()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2156>();
	}

	protected override void vmethod_2()
	{
		delegate2200_0 = method_3;
		delegate2201_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2156 item in list_0)
		{
			item.vmethod_4("dgm", writer, "constr");
		}
		writer.WriteEndElement();
	}

	private Class2156 method_3()
	{
		Class2156 @class = new Class2156();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2156 elementData)
	{
		list_0.Add(elementData);
	}
}
