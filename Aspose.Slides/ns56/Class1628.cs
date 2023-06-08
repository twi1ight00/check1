using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1628 : Class1351
{
	public delegate void Delegate765(Class1628 elementData);

	public delegate Class1628 Delegate763();

	public delegate void Delegate764(Class1628 elementData);

	public Class1626.Delegate757 delegate757_0;

	public Class1626.Delegate758 delegate758_0;

	private List<Class1626> list_0;

	public Class1626[] PivotCacheList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "pivotCache")
				{
					Class1626 item = new Class1626(reader);
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

	public Class1628(XmlReader reader)
		: base(reader)
	{
	}

	public Class1628()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1626>();
	}

	protected override void vmethod_2()
	{
		delegate757_0 = method_3;
		delegate758_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1626 item in list_0)
		{
			item.vmethod_4("ssml", writer, "pivotCache");
		}
		writer.WriteEndElement();
	}

	private Class1626 method_3()
	{
		Class1626 @class = new Class1626();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1626 elementData)
	{
		list_0.Add(elementData);
	}
}
