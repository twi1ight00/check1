using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1820 : Class1351
{
	public delegate Class1820 Delegate1339();

	public delegate void Delegate1340(Class1820 elementData);

	public delegate void Delegate1341(Class1820 elementData);

	public Class1818.Delegate1333 delegate1333_0;

	public Class1818.Delegate1334 delegate1334_0;

	private List<Class1818> list_0;

	public Class1818[] ExtraClrSchemeList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "extraClrScheme")
				{
					Class1818 item = new Class1818(reader);
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

	public Class1820(XmlReader reader)
		: base(reader)
	{
	}

	public Class1820()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1818>();
	}

	protected override void vmethod_2()
	{
		delegate1333_0 = method_3;
		delegate1334_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1818 item in list_0)
		{
			item.vmethod_4("a", writer, "extraClrScheme");
		}
		writer.WriteEndElement();
	}

	private Class1818 method_3()
	{
		Class1818 @class = new Class1818();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1818 elementData)
	{
		list_0.Add(elementData);
	}
}
