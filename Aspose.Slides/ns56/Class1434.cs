using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1434 : Class1351
{
	public delegate void Delegate266(Class1434 elementData);

	public delegate Class1434 Delegate264();

	public delegate void Delegate265(Class1434 elementData);

	public Class1433.Delegate261 delegate261_0;

	public Class1433.Delegate262 delegate262_0;

	private List<Class1433> list_0;

	public Class1433[] ControlList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "control")
				{
					Class1433 item = new Class1433(reader);
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

	public Class1434(XmlReader reader)
		: base(reader)
	{
	}

	public Class1434()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1433>();
	}

	protected override void vmethod_2()
	{
		delegate261_0 = method_3;
		delegate262_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1433 item in list_0)
		{
			item.vmethod_4("ssml", writer, "control");
		}
		writer.WriteEndElement();
	}

	private Class1433 method_3()
	{
		Class1433 @class = new Class1433();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1433 elementData)
	{
		list_0.Add(elementData);
	}
}
