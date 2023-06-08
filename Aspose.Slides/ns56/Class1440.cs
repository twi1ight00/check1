using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1440 : Class1351
{
	public delegate void Delegate284(Class1440 elementData);

	public delegate Class1440 Delegate282();

	public delegate void Delegate283(Class1440 elementData);

	public Class1441.Delegate285 delegate285_0;

	public Class1441.Delegate286 delegate286_0;

	private List<Class1441> list_0;

	public Class1441[] CustomPrList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "customPr")
				{
					Class1441 item = new Class1441(reader);
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

	public Class1440(XmlReader reader)
		: base(reader)
	{
	}

	public Class1440()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1441>();
	}

	protected override void vmethod_2()
	{
		delegate285_0 = method_3;
		delegate286_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1441 item in list_0)
		{
			item.vmethod_4("ssml", writer, "customPr");
		}
		writer.WriteEndElement();
	}

	private Class1441 method_3()
	{
		Class1441 @class = new Class1441();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1441 elementData)
	{
		list_0.Add(elementData);
	}
}
