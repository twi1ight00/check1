using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1946 : Class1351
{
	public delegate Class1946 Delegate1705();

	public delegate void Delegate1707(Class1946 elementData);

	public delegate void Delegate1706(Class1946 elementData);

	public Class1958.Delegate1741 delegate1741_0;

	public Class1958.Delegate1743 delegate1743_0;

	public Class1962.Delegate1753 delegate1753_0;

	public Class1962.Delegate1754 delegate1754_0;

	private Class1947 class1947_0;

	private Class1958 class1958_0;

	private List<Class1962> list_0;

	public Class1947 BodyPr => class1947_0;

	public Class1958 LstStyle => class1958_0;

	public Class1962[] PList => list_0.ToArray();

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
				case "p":
				{
					Class1962 item = new Class1962(reader);
					list_0.Add(item);
					break;
				}
				case "lstStyle":
					class1958_0 = new Class1958(reader);
					break;
				case "bodyPr":
					class1947_0 = new Class1947(reader);
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
	}

	public Class1946(XmlReader reader)
		: base(reader)
	{
	}

	public Class1946()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1962>();
	}

	protected override void vmethod_2()
	{
		delegate1741_0 = method_3;
		delegate1743_0 = method_4;
		delegate1753_0 = method_5;
		delegate1754_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class1947_0 = new Class1947();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1947_0.vmethod_4("a", writer, "bodyPr");
		if (class1958_0 != null)
		{
			class1958_0.vmethod_4("a", writer, "lstStyle");
		}
		foreach (Class1962 item in list_0)
		{
			item.vmethod_4("a", writer, "p");
		}
		writer.WriteEndElement();
	}

	private Class1958 method_3()
	{
		if (class1958_0 != null)
		{
			throw new Exception("Only one <lstStyle> element can be added.");
		}
		class1958_0 = new Class1958();
		return class1958_0;
	}

	private void method_4(Class1958 _lstStyle)
	{
		class1958_0 = _lstStyle;
	}

	private Class1962 method_5()
	{
		Class1962 @class = new Class1962();
		list_0.Add(@class);
		return @class;
	}

	private void method_6(Class1962 elementData)
	{
		list_0.Add(elementData);
	}
}
