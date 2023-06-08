using System;
using System.Xml;

namespace ns56;

internal class Class1899 : Class1351
{
	public delegate Class1899 Delegate1564();

	public delegate void Delegate1565(Class1899 elementData);

	public delegate void Delegate1566(Class1899 elementData);

	public const Enum312 enum312_0 = Enum312.const_0;

	public Class1915.Delegate1612 delegate1612_0;

	public Class1915.Delegate1614 delegate1614_0;

	private Enum312 enum312_1;

	private Class1915 class1915_0;

	public Enum312 Path
	{
		get
		{
			return enum312_1;
		}
		set
		{
			enum312_1 = value;
		}
	}

	public Class1915 FillToRect => class1915_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "fillToRect")
				{
					class1915_0 = new Class1915(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "path")
			{
				enum312_1 = Class2440.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1899(XmlReader reader)
		: base(reader)
	{
	}

	public Class1899()
	{
	}

	protected override void vmethod_1()
	{
		enum312_1 = Enum312.const_0;
	}

	protected override void vmethod_2()
	{
		delegate1612_0 = method_3;
		delegate1614_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum312_1 != 0)
		{
			writer.WriteAttributeString("path", Class2440.smethod_1(enum312_1));
		}
		if (class1915_0 != null)
		{
			class1915_0.vmethod_4("a", writer, "fillToRect");
		}
		writer.WriteEndElement();
	}

	private Class1915 method_3()
	{
		if (class1915_0 != null)
		{
			throw new Exception("Only one <fillToRect> element can be added.");
		}
		class1915_0 = new Class1915();
		return class1915_0;
	}

	private void method_4(Class1915 _fillToRect)
	{
		class1915_0 = _fillToRect;
	}
}
