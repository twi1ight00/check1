using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1733 : Class1351
{
	public delegate Class1733 Delegate1078();

	public delegate void Delegate1079(Class1733 elementData);

	public delegate void Delegate1080(Class1733 elementData);

	public Class1734.Delegate1081 delegate1081_0;

	public Class1734.Delegate1082 delegate1082_0;

	private string string_0;

	private List<Class1734> list_0;

	public string First
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class1734[] TpList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tp")
				{
					Class1734 item = new Class1734(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "first")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1733(XmlReader reader)
		: base(reader)
	{
	}

	public Class1733()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1734>();
	}

	protected override void vmethod_2()
	{
		delegate1081_0 = method_3;
		delegate1082_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("first", string_0);
		foreach (Class1734 item in list_0)
		{
			item.vmethod_4("ssml", writer, "tp");
		}
		writer.WriteEndElement();
	}

	private Class1734 method_3()
	{
		Class1734 @class = new Class1734();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1734 elementData)
	{
		list_0.Add(elementData);
	}
}
