using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1898 : Class1351
{
	public delegate Class1898 Delegate1561();

	public delegate void Delegate1562(Class1898 elementData);

	public delegate void Delegate1563(Class1898 elementData);

	private List<Class1782> list_0;

	public Class1782 Pt1 => list_0[0];

	public Class1782 Pt2 => list_0[1];

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
					Class1782 item = new Class1782(reader);
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

	public Class1898(XmlReader reader)
		: base(reader)
	{
	}

	public Class1898()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1782>();
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		list_0.Add(new Class1782());
		list_0.Add(new Class1782());
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		Pt1.vmethod_4("a", writer, "pt");
		Pt2.vmethod_4("a", writer, "pt");
		writer.WriteEndElement();
	}
}
