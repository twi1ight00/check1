using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1876 : Class1351
{
	public delegate Class1876 Delegate1507();

	public delegate void Delegate1508(Class1876 elementData);

	public delegate void Delegate1509(Class1876 elementData);

	public Class1875.Delegate1504 delegate1504_0;

	public Class1875.Delegate1505 delegate1505_0;

	private List<Class1875> list_0;

	public Class1875[] LnList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "ln")
				{
					Class1875 item = new Class1875(reader);
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

	public Class1876(XmlReader reader)
		: base(reader)
	{
	}

	public Class1876()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1875>();
	}

	protected override void vmethod_2()
	{
		delegate1504_0 = method_3;
		delegate1505_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1875 item in list_0)
		{
			item.vmethod_4("a", writer, "ln");
		}
		writer.WriteEndElement();
	}

	private Class1875 method_3()
	{
		Class1875 @class = new Class1875();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1875 elementData)
	{
		list_0.Add(elementData);
	}
}
