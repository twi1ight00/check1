using System;
using System.Xml;

namespace ns56;

internal class Class1805 : Class1351
{
	public delegate Class1805 Delegate1294();

	public delegate void Delegate1295(Class1805 elementData);

	public delegate void Delegate1296(Class1805 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1819 class1819_0;

	private Class1847 class1847_0;

	private Class1928 class1928_0;

	private Class1886 class1886_0;

	public Class1819 ClrScheme => class1819_0;

	public Class1847 FontScheme => class1847_0;

	public Class1928 FmtScheme => class1928_0;

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

	public Class1805(XmlReader reader)
		: base(reader)
	{
	}

	public Class1805()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1819_0 = new Class1819();
		class1847_0 = new Class1847();
		class1928_0 = new Class1928();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1819_0.vmethod_4("a", writer, "clrScheme");
		class1847_0.vmethod_4("a", writer, "fontScheme");
		class1928_0.vmethod_4("a", writer, "fmtScheme");
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
