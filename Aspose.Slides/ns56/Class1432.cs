using System;
using System.Xml;

namespace ns56;

internal class Class1432 : Class1351
{
	public delegate Class1432 Delegate258();

	public delegate void Delegate259(Class1432 elementData);

	public delegate void Delegate260(Class1432 elementData);

	public const bool bool_0 = true;

	public Class1608.Delegate703 delegate703_0;

	public Class1608.Delegate705 delegate705_0;

	private bool bool_1;

	private Class1608 class1608_0;

	private Class1651 class1651_0;

	public bool AutoPage
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

	public Class1608 Pages => class1608_0;

	public Class1651 RangeSets => class1651_0;

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
				switch (reader.LocalName)
				{
				case "rangeSets":
					class1651_0 = new Class1651(reader);
					break;
				case "pages":
					class1608_0 = new Class1608(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "autoPage")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1432(XmlReader reader)
		: base(reader)
	{
	}

	public Class1432()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = true;
	}

	protected override void vmethod_2()
	{
		delegate703_0 = method_3;
		delegate705_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1651_0 = new Class1651();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_1)
		{
			writer.WriteAttributeString("autoPage", bool_1 ? "1" : "0");
		}
		if (class1608_0 != null)
		{
			class1608_0.vmethod_4("ssml", writer, "pages");
		}
		class1651_0.vmethod_4("ssml", writer, "rangeSets");
		writer.WriteEndElement();
	}

	private Class1608 method_3()
	{
		if (class1608_0 != null)
		{
			throw new Exception("Only one <pages> element can be added.");
		}
		class1608_0 = new Class1608();
		return class1608_0;
	}

	private void method_4(Class1608 _pages)
	{
		class1608_0 = _pages;
	}
}
