using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1702 : Class1351
{
	public delegate void Delegate987(Class1702 elementData);

	public delegate Class1702 Delegate985();

	public delegate void Delegate986(Class1702 elementData);

	public Class1399.Delegate159 delegate159_0;

	public Class1399.Delegate160 delegate160_0;

	private List<Class1399> list_0;

	public Class1399[] CellSmartTagsList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cellSmartTags")
				{
					Class1399 item = new Class1399(reader);
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

	public Class1702(XmlReader reader)
		: base(reader)
	{
	}

	public Class1702()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1399>();
	}

	protected override void vmethod_2()
	{
		delegate159_0 = method_3;
		delegate160_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1399 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cellSmartTags");
		}
		writer.WriteEndElement();
	}

	private Class1399 method_3()
	{
		Class1399 @class = new Class1399();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1399 elementData)
	{
		list_0.Add(elementData);
	}
}
