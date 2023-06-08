using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1704 : Class1351
{
	public delegate void Delegate993(Class1704 elementData);

	public delegate Class1704 Delegate991();

	public delegate void Delegate992(Class1704 elementData);

	public Class1703.Delegate988 delegate988_0;

	public Class1703.Delegate989 delegate989_0;

	private List<Class1703> list_0;

	public Class1703[] SmartTagTypeList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "smartTagType")
				{
					Class1703 item = new Class1703(reader);
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

	public Class1704(XmlReader reader)
		: base(reader)
	{
	}

	public Class1704()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1703>();
	}

	protected override void vmethod_2()
	{
		delegate988_0 = method_3;
		delegate989_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1703 item in list_0)
		{
			item.vmethod_4("ssml", writer, "smartTagType");
		}
		writer.WriteEndElement();
	}

	private Class1703 method_3()
	{
		Class1703 @class = new Class1703();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1703 elementData)
	{
		list_0.Add(elementData);
	}
}
