using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1583 : Class1351
{
	public delegate Class1583 Delegate628();

	public delegate void Delegate629(Class1583 elementData);

	public delegate void Delegate630(Class1583 elementData);

	public Class1585.Delegate634 delegate634_0;

	public Class1585.Delegate635 delegate635_0;

	private List<Class1585> list_0;

	public Class1585[] RcList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "rc")
				{
					Class1585 item = new Class1585(reader);
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

	public Class1583(XmlReader reader)
		: base(reader)
	{
	}

	public Class1583()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1585>();
	}

	protected override void vmethod_2()
	{
		delegate634_0 = method_3;
		delegate635_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1585 item in list_0)
		{
			item.vmethod_4("ssml", writer, "rc");
		}
		writer.WriteEndElement();
	}

	private Class1585 method_3()
	{
		Class1585 @class = new Class1585();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1585 elementData)
	{
		list_0.Add(elementData);
	}
}
