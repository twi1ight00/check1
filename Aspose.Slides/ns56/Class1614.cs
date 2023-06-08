using System;
using System.Xml;

namespace ns56;

internal class Class1614 : Class1351
{
	public delegate Class1614 Delegate721();

	public delegate void Delegate722(Class1614 elementData);

	public delegate void Delegate723(Class1614 elementData);

	public const Enum227 enum227_0 = Enum227.const_0;

	public Class1419.Delegate219 delegate219_0;

	public Class1419.Delegate221 delegate221_0;

	public Class1419.Delegate219 delegate219_1;

	public Class1419.Delegate221 delegate221_1;

	private Enum227 enum227_1;

	private Class1419 class1419_0;

	private Class1419 class1419_1;

	public Enum227 PatternType
	{
		get
		{
			return enum227_1;
		}
		set
		{
			enum227_1 = value;
		}
	}

	public Class1419 FgColor => class1419_0;

	public Class1419 BgColor => class1419_1;

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
				case "bgColor":
					class1419_1 = new Class1419(reader);
					break;
				case "fgColor":
					class1419_0 = new Class1419(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "patternType")
			{
				enum227_1 = Class2394.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1614(XmlReader reader)
		: base(reader)
	{
	}

	public Class1614()
	{
	}

	protected override void vmethod_1()
	{
		enum227_1 = Enum227.const_0;
	}

	protected override void vmethod_2()
	{
		delegate219_0 = method_3;
		delegate221_0 = method_4;
		delegate219_1 = method_5;
		delegate221_1 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum227_1 != 0)
		{
			writer.WriteAttributeString("patternType", Class2394.smethod_1(enum227_1));
		}
		if (class1419_0 != null)
		{
			class1419_0.vmethod_4("ssml", writer, "fgColor");
		}
		if (class1419_1 != null)
		{
			class1419_1.vmethod_4("ssml", writer, "bgColor");
		}
		writer.WriteEndElement();
	}

	private Class1419 method_3()
	{
		if (class1419_0 != null)
		{
			throw new Exception("Only one <fgColor> element can be added.");
		}
		class1419_0 = new Class1419();
		return class1419_0;
	}

	private void method_4(Class1419 _fgColor)
	{
		class1419_0 = _fgColor;
	}

	private Class1419 method_5()
	{
		if (class1419_1 != null)
		{
			throw new Exception("Only one <bgColor> element can be added.");
		}
		class1419_1 = new Class1419();
		return class1419_1;
	}

	private void method_6(Class1419 _bgColor)
	{
		class1419_1 = _bgColor;
	}
}
