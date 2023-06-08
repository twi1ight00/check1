using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2302 : Class1351
{
	public delegate Class2302 Delegate2653();

	public delegate void Delegate2655(Class2302 elementData);

	public delegate void Delegate2654(Class2302 elementData);

	public Class2301.Delegate2650 delegate2650_0;

	public Class2301.Delegate2651 delegate2651_0;

	private List<Class2301> list_0;

	public Class2301[] CondList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cond")
				{
					Class2301 item = new Class2301(reader);
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

	public Class2302(XmlReader reader)
		: base(reader)
	{
	}

	public Class2302()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2301>();
	}

	protected override void vmethod_2()
	{
		delegate2650_0 = method_3;
		delegate2651_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2301 item in list_0)
		{
			item.vmethod_4("p", writer, "cond");
		}
		writer.WriteEndElement();
	}

	private Class2301 method_3()
	{
		Class2301 @class = new Class2301();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2301 elementData)
	{
		list_0.Add(elementData);
	}
}
