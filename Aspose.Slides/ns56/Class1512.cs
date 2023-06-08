using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1512 : Class1351
{
	public delegate Class1512 Delegate415();

	public delegate void Delegate417(Class1512 elementData);

	public delegate void Delegate416(Class1512 elementData);

	public Class1511.Delegate412 delegate412_0;

	public Class1511.Delegate413 delegate413_0;

	private List<Class1511> list_0;

	public Class1511[] SheetDataList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "sheetData")
				{
					Class1511 item = new Class1511(reader);
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

	public Class1512(XmlReader reader)
		: base(reader)
	{
	}

	public Class1512()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1511>();
	}

	protected override void vmethod_2()
	{
		delegate412_0 = method_3;
		delegate413_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1511 item in list_0)
		{
			item.vmethod_4("ssml", writer, "sheetData");
		}
		writer.WriteEndElement();
	}

	private Class1511 method_3()
	{
		Class1511 @class = new Class1511();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1511 elementData)
	{
		list_0.Add(elementData);
	}
}
