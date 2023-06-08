using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1736 : Class1351
{
	public delegate Class1736 Delegate1087();

	public delegate void Delegate1088(Class1736 elementData);

	public delegate void Delegate1089(Class1736 elementData);

	public Class1733.Delegate1078 delegate1078_0;

	public Class1733.Delegate1079 delegate1079_0;

	private Enum257 enum257_0;

	private List<Class1733> list_0;

	public Enum257 Type
	{
		get
		{
			return enum257_0;
		}
		set
		{
			enum257_0 = value;
		}
	}

	public Class1733[] MainList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "main")
				{
					Class1733 item = new Class1733(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "type")
			{
				enum257_0 = Class2424.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1736(XmlReader reader)
		: base(reader)
	{
	}

	public Class1736()
	{
	}

	protected override void vmethod_1()
	{
		enum257_0 = Enum257.const_0;
		list_0 = new List<Class1733>();
	}

	protected override void vmethod_2()
	{
		delegate1078_0 = method_3;
		delegate1079_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("type", Class2424.smethod_1(enum257_0));
		foreach (Class1733 item in list_0)
		{
			item.vmethod_4("ssml", writer, "main");
		}
		writer.WriteEndElement();
	}

	private Class1733 method_3()
	{
		Class1733 @class = new Class1733();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1733 elementData)
	{
		list_0.Add(elementData);
	}
}
