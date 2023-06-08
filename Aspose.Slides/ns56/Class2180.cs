using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2180 : Class1351
{
	public delegate Class2180 Delegate2272();

	public delegate void Delegate2273(Class2180 elementData);

	public delegate void Delegate2274(Class2180 elementData);

	public Class2179.Delegate2269 delegate2269_0;

	public Class2179.Delegate2270 delegate2270_0;

	private List<Class2179> list_0;

	public Class2179[] PtList => list_0.ToArray();

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
					Class2179 item = new Class2179(reader);
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

	public Class2180(XmlReader reader)
		: base(reader)
	{
	}

	public Class2180()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2179>();
	}

	protected override void vmethod_2()
	{
		delegate2269_0 = method_3;
		delegate2270_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2179 item in list_0)
		{
			item.vmethod_4("dgm", writer, "pt");
		}
		writer.WriteEndElement();
	}

	private Class2179 method_3()
	{
		Class2179 @class = new Class2179();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2179 elementData)
	{
		list_0.Add(elementData);
	}
}
