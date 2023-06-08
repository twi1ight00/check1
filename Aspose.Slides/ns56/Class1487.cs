using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1487 : Class1351
{
	public delegate Class1487 Delegate338();

	public delegate void Delegate339(Class1487 elementData);

	public delegate void Delegate340(Class1487 elementData);

	public Class1486.Delegate335 delegate335_0;

	public Class1486.Delegate336 delegate336_0;

	private List<Class1486> list_0;

	public Class1486[] DdeItemList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "ddeItem")
				{
					Class1486 item = new Class1486(reader);
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

	public Class1487(XmlReader reader)
		: base(reader)
	{
	}

	public Class1487()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1486>();
	}

	protected override void vmethod_2()
	{
		delegate335_0 = method_3;
		delegate336_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1486 item in list_0)
		{
			item.vmethod_4("ssml", writer, "ddeItem");
		}
		writer.WriteEndElement();
	}

	private Class1486 method_3()
	{
		Class1486 @class = new Class1486();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1486 elementData)
	{
		list_0.Add(elementData);
	}
}
