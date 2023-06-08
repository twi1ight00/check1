using System;
using System.Xml;

namespace ns56;

internal class Class2194 : Class1351
{
	public delegate Class2194 Delegate2318();

	public delegate void Delegate2319(Class2194 elementData);

	public delegate void Delegate2320(Class2194 elementData);

	public Class2238.Delegate2458 delegate2458_0;

	public Class2238.Delegate2460 delegate2460_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2227 class2227_0;

	private Class1815 class1815_0;

	private Class2238 class2238_0;

	private Class1889 class1889_0;

	public Class2227 CSld => class2227_0;

	public Class1815 ClrMap => class1815_0;

	public Class2238 Hf => class2238_0;

	public Class1885 ExtLst => class1889_0;

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
					class1889_0 = new Class1889(reader);
					break;
				case "hf":
					class2238_0 = new Class2238(reader);
					break;
				case "clrMap":
					class1815_0 = new Class1815(reader);
					break;
				case "cSld":
					class2227_0 = new Class2227(reader);
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

	public Class2194(XmlReader reader)
		: base(reader)
	{
	}

	public Class2194()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2458_0 = method_3;
		delegate2460_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class2227_0 = new Class2227();
		class1815_0 = new Class1815();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		class2227_0.vmethod_4("p", writer, "cSld");
		class1815_0.vmethod_4("p", writer, "clrMap");
		if (class2238_0 != null)
		{
			class2238_0.vmethod_4("p", writer, "hf");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2238 method_3()
	{
		if (class2238_0 != null)
		{
			throw new Exception("Only one <hf> element can be added.");
		}
		class2238_0 = new Class2238();
		return class2238_0;
	}

	private void method_4(Class2238 _hf)
	{
		class2238_0 = _hf;
	}

	private Class1885 method_5()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
