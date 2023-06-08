using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1827 : Class1351
{
	public delegate void Delegate1362(Class1827 elementData);

	public delegate Class1827 Delegate1360();

	public delegate void Delegate1361(Class1827 elementData);

	public Class1826.Delegate1357 delegate1357_0;

	public Class1826.Delegate1358 delegate1358_0;

	private List<Class1826> list_0;

	public Class1826[] CustClrList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "custClr")
				{
					Class1826 item = new Class1826(reader);
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

	public Class1827(XmlReader reader)
		: base(reader)
	{
	}

	public Class1827()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1826>();
	}

	protected override void vmethod_2()
	{
		delegate1357_0 = method_3;
		delegate1358_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1826 item in list_0)
		{
			item.vmethod_4("a", writer, "custClr");
		}
		writer.WriteEndElement();
	}

	private Class1826 method_3()
	{
		Class1826 @class = new Class1826();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1826 elementData)
	{
		list_0.Add(elementData);
	}
}
