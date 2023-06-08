using System;
using System.Xml;

namespace ns56;

internal class Class2143 : Class1351
{
	public delegate Class2143 Delegate2161();

	public delegate void Delegate2162(Class2143 elementData);

	public delegate void Delegate2163(Class2143 elementData);

	public Class2164.Delegate2224 delegate2224_0;

	public Class2164.Delegate2226 delegate2226_0;

	public Class1804.Delegate1291 delegate1291_0;

	public Class1804.Delegate1293 delegate1293_0;

	public Class1980.Delegate1807 delegate1807_0;

	public Class1980.Delegate1809 delegate1809_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2180 class2180_0;

	private Class2164 class2164_0;

	private Class1804 class1804_0;

	private Class1980 class1980_0;

	private Class1886 class1886_0;

	public Class2180 PtLst => class2180_0;

	public Class2164 CxnLst => class2164_0;

	public Class1804 Bg => class1804_0;

	public Class1980 Whole => class1980_0;

	public Class1885 ExtLst => class1886_0;

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
				case "extLst":
					class1886_0 = new Class1886(reader);
					break;
				case "whole":
					class1980_0 = new Class1980(reader);
					break;
				case "bg":
					class1804_0 = new Class1804(reader);
					break;
				case "cxnLst":
					class2164_0 = new Class2164(reader);
					break;
				case "ptLst":
					class2180_0 = new Class2180(reader);
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

	public Class2143(XmlReader reader)
		: base(reader)
	{
	}

	public Class2143()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2224_0 = method_3;
		delegate2226_0 = method_4;
		delegate1291_0 = method_5;
		delegate1293_0 = method_6;
		delegate1807_0 = method_7;
		delegate1809_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
		class2180_0 = new Class2180();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("dgm", elementName, "http://schemas.openxmlformats.org/drawingml/2006/diagram");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		class2180_0.vmethod_4("dgm", writer, "ptLst");
		if (class2164_0 != null)
		{
			class2164_0.vmethod_4("dgm", writer, "cxnLst");
		}
		if (class1804_0 != null)
		{
			class1804_0.vmethod_4("dgm", writer, "bg");
		}
		if (class1980_0 != null)
		{
			class1980_0.vmethod_4("dgm", writer, "whole");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2164 method_3()
	{
		if (class2164_0 != null)
		{
			throw new Exception("Only one <cxnLst> element can be added.");
		}
		class2164_0 = new Class2164();
		return class2164_0;
	}

	private void method_4(Class2164 _cxnLst)
	{
		class2164_0 = _cxnLst;
	}

	private Class1804 method_5()
	{
		if (class1804_0 != null)
		{
			throw new Exception("Only one <bg> element can be added.");
		}
		class1804_0 = new Class1804();
		return class1804_0;
	}

	private void method_6(Class1804 _bg)
	{
		class1804_0 = _bg;
	}

	private Class1980 method_7()
	{
		if (class1980_0 != null)
		{
			throw new Exception("Only one <whole> element can be added.");
		}
		class1980_0 = new Class1980();
		return class1980_0;
	}

	private void method_8(Class1980 _whole)
	{
		class1980_0 = _whole;
	}

	private Class1885 method_9()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
