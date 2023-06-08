using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1696 : Class1351
{
	public delegate Class1696 Delegate967();

	public delegate void Delegate968(Class1696 elementData);

	public delegate void Delegate969(Class1696 elementData);

	public Class1690.Delegate949 delegate949_0;

	public Class1690.Delegate950 delegate950_0;

	private List<Class1690> list_0;

	public Class1690[] SheetList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "sheet")
				{
					Class1690 item = new Class1690(reader);
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

	public Class1696(XmlReader reader)
		: base(reader)
	{
	}

	public Class1696()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1690>();
	}

	protected override void vmethod_2()
	{
		delegate949_0 = method_3;
		delegate950_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1690 item in list_0)
		{
			item.vmethod_4("ssml", writer, "sheet");
		}
		writer.WriteEndElement();
	}

	private Class1690 method_3()
	{
		Class1690 @class = new Class1690();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1690 elementData)
	{
		list_0.Add(elementData);
	}
}
