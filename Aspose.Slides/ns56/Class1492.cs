using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1492 : Class1351
{
	public delegate void Delegate355(Class1492 elementData);

	public delegate Class1492 Delegate353();

	public delegate void Delegate354(Class1492 elementData);

	public Class1491.Delegate350 delegate350_0;

	public Class1491.Delegate351 delegate351_0;

	private List<Class1491> list_0;

	public Class1491[] DefinedNameList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "definedName")
				{
					Class1491 item = new Class1491(reader);
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

	public Class1492(XmlReader reader)
		: base(reader)
	{
	}

	public Class1492()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1491>();
	}

	protected override void vmethod_2()
	{
		delegate350_0 = method_3;
		delegate351_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1491 item in list_0)
		{
			item.vmethod_4("ssml", writer, "definedName");
		}
		writer.WriteEndElement();
	}

	private Class1491 method_3()
	{
		Class1491 @class = new Class1491();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1491 elementData)
	{
		list_0.Add(elementData);
	}
}
