using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1850 : Class1351
{
	public delegate Class1850 Delegate1429();

	public delegate void Delegate1431(Class1850 elementData);

	public delegate void Delegate1430(Class1850 elementData);

	public Class1849.Delegate1426 delegate1426_0;

	public Class1849.Delegate1427 delegate1427_0;

	private List<Class1849> list_0;

	public Class1849[] GdList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "gd")
				{
					Class1849 item = new Class1849(reader);
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

	public Class1850(XmlReader reader)
		: base(reader)
	{
	}

	public Class1850()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1849>();
	}

	protected override void vmethod_2()
	{
		delegate1426_0 = method_3;
		delegate1427_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1849 item in list_0)
		{
			item.vmethod_4("a", writer, "gd");
		}
		writer.WriteEndElement();
	}

	private Class1849 method_3()
	{
		Class1849 @class = new Class1849();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1849 elementData)
	{
		list_0.Add(elementData);
	}
}
