using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1837 : Class1351
{
	public delegate Class1837 Delegate1390();

	public delegate void Delegate1391(Class1837 elementData);

	public delegate void Delegate1392(Class1837 elementData);

	public Class1836.Delegate1387 delegate1387_0;

	public Class1836.Delegate1388 delegate1388_0;

	private List<Class1836> list_0;

	public Class1836[] EffectStyleList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "effectStyle")
				{
					Class1836 item = new Class1836(reader);
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

	public Class1837(XmlReader reader)
		: base(reader)
	{
	}

	public Class1837()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1836>();
	}

	protected override void vmethod_2()
	{
		delegate1387_0 = method_3;
		delegate1388_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1836 item in list_0)
		{
			item.vmethod_4("a", writer, "effectStyle");
		}
		writer.WriteEndElement();
	}

	private Class1836 method_3()
	{
		Class1836 @class = new Class1836();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1836 elementData)
	{
		list_0.Add(elementData);
	}
}
