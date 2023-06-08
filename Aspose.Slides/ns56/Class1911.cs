using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1911 : Class1351
{
	public delegate Class1911 Delegate1600();

	public delegate void Delegate1601(Class1911 elementData);

	public delegate void Delegate1602(Class1911 elementData);

	public Class1850.Delegate1429 delegate1429_0;

	public Class1850.Delegate1431 delegate1431_0;

	private TextShapeType textShapeType_0;

	private Class1850 class1850_0;

	public TextShapeType Prst
	{
		get
		{
			return textShapeType_0;
		}
		set
		{
			textShapeType_0 = value;
		}
	}

	public Class1850 AvLst => class1850_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "avLst")
				{
					class1850_0 = new Class1850(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "prst")
			{
				textShapeType_0 = Class2569.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1911(XmlReader reader)
		: base(reader)
	{
	}

	public Class1911()
	{
	}

	protected override void vmethod_1()
	{
		textShapeType_0 = TextShapeType.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate1429_0 = method_3;
		delegate1431_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("prst", Class2569.smethod_1(textShapeType_0));
		if (class1850_0 != null)
		{
			class1850_0.vmethod_4("a", writer, "avLst");
		}
		writer.WriteEndElement();
	}

	private Class1850 method_3()
	{
		if (class1850_0 != null)
		{
			throw new Exception("Only one <avLst> element can be added.");
		}
		class1850_0 = new Class1850();
		return class1850_0;
	}

	private void method_4(Class1850 _avLst)
	{
		class1850_0 = _avLst;
	}
}
