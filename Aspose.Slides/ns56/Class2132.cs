using System;
using System.Xml;

namespace ns56;

internal class Class2132 : Class1351
{
	public delegate Class2132 Delegate2127();

	public delegate void Delegate2128(Class2132 elementData);

	public delegate void Delegate2129(Class2132 elementData);

	public Class2131.Delegate2124 delegate2124_0;

	public Class2131.Delegate2126 delegate2126_0;

	public Class2131.Delegate2124 delegate2124_1;

	public Class2131.Delegate2126 delegate2126_1;

	public Class2131.Delegate2124 delegate2124_2;

	public Class2131.Delegate2126 delegate2126_2;

	public Class2131.Delegate2124 delegate2124_3;

	public Class2131.Delegate2126 delegate2126_3;

	private Class1956 class1956_0;

	private Class2131 class2131_0;

	private Class2131 class2131_1;

	private Class2131 class2131_2;

	private Class2131 class2131_3;

	public Class1956 Font => class1956_0;

	public Class2131 Regular => class2131_0;

	public Class2131 Bold => class2131_1;

	public Class2131 Italic => class2131_2;

	public Class2131 BoldItalic => class2131_3;

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
				case "boldItalic":
					class2131_3 = new Class2131(reader);
					break;
				case "italic":
					class2131_2 = new Class2131(reader);
					break;
				case "bold":
					class2131_1 = new Class2131(reader);
					break;
				case "regular":
					class2131_0 = new Class2131(reader);
					break;
				case "font":
					class1956_0 = new Class1956(reader);
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

	public Class2132(XmlReader reader)
		: base(reader)
	{
	}

	public Class2132()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2124_0 = method_3;
		delegate2126_0 = method_4;
		delegate2124_1 = method_5;
		delegate2126_1 = method_6;
		delegate2124_2 = method_7;
		delegate2126_2 = method_8;
		delegate2124_3 = method_9;
		delegate2126_3 = method_10;
	}

	protected override void vmethod_3()
	{
		class1956_0 = new Class1956();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1956_0.vmethod_4("p", writer, "font");
		if (class2131_0 != null)
		{
			class2131_0.vmethod_4("p", writer, "regular");
		}
		if (class2131_1 != null)
		{
			class2131_1.vmethod_4("p", writer, "bold");
		}
		if (class2131_2 != null)
		{
			class2131_2.vmethod_4("p", writer, "italic");
		}
		if (class2131_3 != null)
		{
			class2131_3.vmethod_4("p", writer, "boldItalic");
		}
		writer.WriteEndElement();
	}

	private Class2131 method_3()
	{
		if (class2131_0 != null)
		{
			throw new Exception("Only one <regular> element can be added.");
		}
		class2131_0 = new Class2131();
		return class2131_0;
	}

	private void method_4(Class2131 _regular)
	{
		class2131_0 = _regular;
	}

	private Class2131 method_5()
	{
		if (class2131_1 != null)
		{
			throw new Exception("Only one <bold> element can be added.");
		}
		class2131_1 = new Class2131();
		return class2131_1;
	}

	private void method_6(Class2131 _bold)
	{
		class2131_1 = _bold;
	}

	private Class2131 method_7()
	{
		if (class2131_2 != null)
		{
			throw new Exception("Only one <italic> element can be added.");
		}
		class2131_2 = new Class2131();
		return class2131_2;
	}

	private void method_8(Class2131 _italic)
	{
		class2131_2 = _italic;
	}

	private Class2131 method_9()
	{
		if (class2131_3 != null)
		{
			throw new Exception("Only one <boldItalic> element can be added.");
		}
		class2131_3 = new Class2131();
		return class2131_3;
	}

	private void method_10(Class2131 _boldItalic)
	{
		class2131_3 = _boldItalic;
	}
}
