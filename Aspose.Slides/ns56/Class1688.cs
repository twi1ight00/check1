using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1688 : Class1351
{
	public delegate Class1688 Delegate943();

	public delegate void Delegate944(Class1688 elementData);

	public delegate void Delegate945(Class1688 elementData);

	public Class1671.Delegate892 delegate892_0;

	public Class1671.Delegate893 delegate893_0;

	private List<Class1671> list_0;

	public Class1671[] RowList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "row")
				{
					Class1671 item = new Class1671(reader);
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

	public Class1688(XmlReader reader)
		: base(reader)
	{
	}

	public Class1688()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1671>();
	}

	protected override void vmethod_2()
	{
		delegate892_0 = method_3;
		delegate893_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1671 item in list_0)
		{
			item.vmethod_4("ssml", writer, "row");
		}
		writer.WriteEndElement();
	}

	private Class1671 method_3()
	{
		Class1671 @class = new Class1671();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1671 elementData)
	{
		list_0.Add(elementData);
	}
}
