using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1900 : Class1351
{
	public delegate Class1900 Delegate1567();

	public delegate void Delegate1568(Class1900 elementData);

	public delegate void Delegate1569(Class1900 elementData);

	public const PatternStyle patternStyle_0 = PatternStyle.Unknown;

	public Class1814.Delegate1321 delegate1321_0;

	public Class1814.Delegate1323 delegate1323_0;

	public Class1814.Delegate1321 delegate1321_1;

	public Class1814.Delegate1323 delegate1323_1;

	private PatternStyle patternStyle_1;

	private Class1814 class1814_0;

	private Class1814 class1814_1;

	public PatternStyle Prst
	{
		get
		{
			return patternStyle_1;
		}
		set
		{
			patternStyle_1 = value;
		}
	}

	public Class1814 FgClr => class1814_0;

	public Class1814 BgClr => class1814_1;

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
				case "bgClr":
					class1814_1 = new Class1814(reader);
					break;
				case "fgClr":
					class1814_0 = new Class1814(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "prst")
			{
				patternStyle_1 = Class2550.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1900(XmlReader reader)
		: base(reader)
	{
	}

	public Class1900()
	{
	}

	protected override void vmethod_1()
	{
		patternStyle_1 = PatternStyle.Unknown;
	}

	protected override void vmethod_2()
	{
		delegate1321_0 = method_3;
		delegate1323_0 = method_4;
		delegate1321_1 = method_5;
		delegate1323_1 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (patternStyle_1 != 0)
		{
			writer.WriteAttributeString("prst", Class2550.smethod_1(patternStyle_1));
		}
		if (class1814_0 != null)
		{
			class1814_0.vmethod_4("a", writer, "fgClr");
		}
		if (class1814_1 != null)
		{
			class1814_1.vmethod_4("a", writer, "bgClr");
		}
		writer.WriteEndElement();
	}

	private Class1814 method_3()
	{
		if (class1814_0 != null)
		{
			throw new Exception("Only one <fgClr> element can be added.");
		}
		class1814_0 = new Class1814();
		return class1814_0;
	}

	private void method_4(Class1814 _fgClr)
	{
		class1814_0 = _fgClr;
	}

	private Class1814 method_5()
	{
		if (class1814_1 != null)
		{
			throw new Exception("Only one <bgClr> element can be added.");
		}
		class1814_1 = new Class1814();
		return class1814_1;
	}

	private void method_6(Class1814 _bgClr)
	{
		class1814_1 = _bgClr;
	}
}
