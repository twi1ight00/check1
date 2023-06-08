using System;
using System.Xml;

namespace ns56;

internal class Class1378 : Class1351
{
	public delegate Class1378 Delegate96();

	public delegate void Delegate98(Class1378 elementData);

	public delegate void Delegate97(Class1378 elementData);

	public Class1419.Delegate219 delegate219_0;

	public Class1419.Delegate221 delegate221_0;

	private Enum184 enum184_0;

	private Class1419 class1419_0;

	public static readonly Enum184 enum184_1 = Class2350.smethod_0("none");

	public Enum184 Style
	{
		get
		{
			return enum184_0;
		}
		set
		{
			enum184_0 = value;
		}
	}

	public Class1419 Color => class1419_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "color")
				{
					class1419_0 = new Class1419(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "style")
			{
				enum184_0 = Class2350.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1378(XmlReader reader)
		: base(reader)
	{
	}

	public Class1378()
	{
	}

	protected override void vmethod_1()
	{
		enum184_0 = enum184_1;
	}

	protected override void vmethod_2()
	{
		delegate219_0 = method_3;
		delegate221_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum184_0 != enum184_1)
		{
			writer.WriteAttributeString("style", Class2350.smethod_1(enum184_0));
		}
		if (class1419_0 != null)
		{
			class1419_0.vmethod_4("ssml", writer, "color");
		}
		writer.WriteEndElement();
	}

	private Class1419 method_3()
	{
		if (class1419_0 != null)
		{
			throw new Exception("Only one <color> element can be added.");
		}
		class1419_0 = new Class1419();
		return class1419_0;
	}

	private void method_4(Class1419 _color)
	{
		class1419_0 = _color;
	}
}
