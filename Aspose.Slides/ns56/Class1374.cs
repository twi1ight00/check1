using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1374 : Class1351
{
	public delegate void Delegate86(Class1374 elementData);

	public delegate Class1374 Delegate84();

	public delegate void Delegate85(Class1374 elementData);

	public Class1373.Delegate81 delegate81_0;

	public Class1373.Delegate82 delegate82_0;

	private List<Class1373> list_0;

	public Class1373[] WorkbookViewList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "workbookView")
				{
					Class1373 item = new Class1373(reader);
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

	public Class1374(XmlReader reader)
		: base(reader)
	{
	}

	public Class1374()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1373>();
	}

	protected override void vmethod_2()
	{
		delegate81_0 = method_3;
		delegate82_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1373 item in list_0)
		{
			item.vmethod_4("ssml", writer, "workbookView");
		}
		writer.WriteEndElement();
	}

	private Class1373 method_3()
	{
		Class1373 @class = new Class1373();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1373 elementData)
	{
		list_0.Add(elementData);
	}
}
