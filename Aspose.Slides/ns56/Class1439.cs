using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1439 : Class1351
{
	public delegate Class1439 Delegate279();

	public delegate void Delegate280(Class1439 elementData);

	public delegate void Delegate281(Class1439 elementData);

	public const bool bool_0 = false;

	public Class1438.Delegate276 delegate276_0;

	public Class1438.Delegate277 delegate277_0;

	private bool bool_1;

	private List<Class1438> list_0;

	public bool And
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class1438[] CustomFilterList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "customFilter")
				{
					Class1438 item = new Class1438(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "and")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1439(XmlReader reader)
		: base(reader)
	{
	}

	public Class1439()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		list_0 = new List<Class1438>();
	}

	protected override void vmethod_2()
	{
		delegate276_0 = method_3;
		delegate277_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("and", bool_1 ? "1" : "0");
		}
		foreach (Class1438 item in list_0)
		{
			item.vmethod_4("ssml", writer, "customFilter");
		}
		writer.WriteEndElement();
	}

	private Class1438 method_3()
	{
		Class1438 @class = new Class1438();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1438 elementData)
	{
		list_0.Add(elementData);
	}
}
