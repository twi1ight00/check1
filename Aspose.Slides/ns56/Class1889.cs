using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1889 : Class1885
{
	public delegate void Delegate2447(Class1889 elementData);

	public const bool bool_0 = false;

	private bool bool_1;

	private List<Class1454> list_0;

	public override bool Mod
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

	public override Class1449[] ExtList => list_0.ToArray();

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_3(reader);
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
				if ((localName2 = reader.LocalName) != null && localName2 == "ext")
				{
					Class1454 item = new Class1454(reader);
					list_0.Add(item);
					flag = true;
				}
				else
				{
					reader.Skip();
					flag = true;
				}
			}
		}
	}

	private void method_3(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "mod")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1889(XmlReader reader)
		: base(reader)
	{
	}

	public Class1889()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		list_0 = new List<Class1454>();
	}

	protected override void vmethod_2()
	{
		delegate383_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("mod", bool_1 ? "1" : "0");
		}
		foreach (Class1454 item in list_0)
		{
			item.vmethod_4("p", writer, "ext");
		}
		writer.WriteEndElement();
	}

	private Class1449 method_4()
	{
		Class1454 @class = new Class1454();
		list_0.Add(@class);
		return @class;
	}

	private void method_5(Class1454 elementData)
	{
		list_0.Add(elementData);
	}
}
