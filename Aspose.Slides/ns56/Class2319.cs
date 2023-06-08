using System;
using System.Xml;

namespace ns56;

internal class Class2319 : Class1351
{
	public delegate Class2319 Delegate2704();

	public delegate void Delegate2705(Class2319 elementData);

	public delegate void Delegate2706(Class2319 elementData);

	public Class1819.Delegate1336 delegate1336_0;

	public Class1819.Delegate1338 delegate1338_0;

	public Class1847.Delegate1420 delegate1420_0;

	public Class1847.Delegate1422 delegate1422_0;

	public Class1928.Delegate1651 delegate1651_0;

	public Class1928.Delegate1653 delegate1653_0;

	private Class1819 class1819_0;

	private Class1847 class1847_0;

	private Class1928 class1928_0;

	public Class1819 ClrScheme => class1819_0;

	public Class1847 FontScheme => class1847_0;

	public Class1928 FmtScheme => class1928_0;

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
				case "fmtScheme":
					class1928_0 = new Class1928(reader);
					break;
				case "fontScheme":
					class1847_0 = new Class1847(reader);
					break;
				case "clrScheme":
					class1819_0 = new Class1819(reader);
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

	public Class2319(XmlReader reader)
		: base(reader)
	{
	}

	public Class2319()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1336_0 = method_3;
		delegate1338_0 = method_4;
		delegate1420_0 = method_5;
		delegate1422_0 = method_6;
		delegate1651_0 = method_7;
		delegate1653_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("a", elementName, "http://schemas.openxmlformats.org/drawingml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (class1819_0 != null)
		{
			class1819_0.vmethod_4("a", writer, "clrScheme");
		}
		if (class1847_0 != null)
		{
			class1847_0.vmethod_4("a", writer, "fontScheme");
		}
		if (class1928_0 != null)
		{
			class1928_0.vmethod_4("a", writer, "fmtScheme");
		}
		writer.WriteEndElement();
	}

	private Class1819 method_3()
	{
		if (class1819_0 != null)
		{
			throw new Exception("Only one <clrScheme> element can be added.");
		}
		class1819_0 = new Class1819();
		return class1819_0;
	}

	private void method_4(Class1819 _clrScheme)
	{
		class1819_0 = _clrScheme;
	}

	private Class1847 method_5()
	{
		if (class1847_0 != null)
		{
			throw new Exception("Only one <fontScheme> element can be added.");
		}
		class1847_0 = new Class1847();
		return class1847_0;
	}

	private void method_6(Class1847 _fontScheme)
	{
		class1847_0 = _fontScheme;
	}

	private Class1928 method_7()
	{
		if (class1928_0 != null)
		{
			throw new Exception("Only one <fmtScheme> element can be added.");
		}
		class1928_0 = new Class1928();
		return class1928_0;
	}

	private void method_8(Class1928 _fmtScheme)
	{
		class1928_0 = _fmtScheme;
	}
}
