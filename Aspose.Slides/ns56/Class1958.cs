using System;
using System.Xml;

namespace ns56;

internal class Class1958 : Class1351
{
	public delegate Class1958 Delegate1741();

	public delegate void Delegate1743(Class1958 elementData);

	public delegate void Delegate1742(Class1958 elementData);

	public Class1963.Delegate1756 delegate1756_0;

	public Class1963.Delegate1758 delegate1758_0;

	public Class1963.Delegate1756 delegate1756_1;

	public Class1963.Delegate1758 delegate1758_1;

	public Class1963.Delegate1756 delegate1756_2;

	public Class1963.Delegate1758 delegate1758_2;

	public Class1963.Delegate1756 delegate1756_3;

	public Class1963.Delegate1758 delegate1758_3;

	public Class1963.Delegate1756 delegate1756_4;

	public Class1963.Delegate1758 delegate1758_4;

	public Class1963.Delegate1756 delegate1756_5;

	public Class1963.Delegate1758 delegate1758_5;

	public Class1963.Delegate1756 delegate1756_6;

	public Class1963.Delegate1758 delegate1758_6;

	public Class1963.Delegate1756 delegate1756_7;

	public Class1963.Delegate1758 delegate1758_7;

	public Class1963.Delegate1756 delegate1756_8;

	public Class1963.Delegate1758 delegate1758_8;

	public Class1963.Delegate1756 delegate1756_9;

	public Class1963.Delegate1758 delegate1758_9;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1963 class1963_0;

	private Class1963 class1963_1;

	private Class1963 class1963_2;

	private Class1963 class1963_3;

	private Class1963 class1963_4;

	private Class1963 class1963_5;

	private Class1963 class1963_6;

	private Class1963 class1963_7;

	private Class1963 class1963_8;

	private Class1963 class1963_9;

	private Class1886 class1886_0;

	public Class1963 DefPPr => class1963_0;

	public Class1963 Lvl1pPr => class1963_1;

	public Class1963 Lvl2pPr => class1963_2;

	public Class1963 Lvl3pPr => class1963_3;

	public Class1963 Lvl4pPr => class1963_4;

	public Class1963 Lvl5pPr => class1963_5;

	public Class1963 Lvl6pPr => class1963_6;

	public Class1963 Lvl7pPr => class1963_7;

	public Class1963 Lvl8pPr => class1963_8;

	public Class1963 Lvl9pPr => class1963_9;

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
				case "defPPr":
					class1963_0 = new Class1963(reader);
					break;
				case "lvl1pPr":
					class1963_1 = new Class1963(reader);
					break;
				case "lvl2pPr":
					class1963_2 = new Class1963(reader);
					break;
				case "lvl3pPr":
					class1963_3 = new Class1963(reader);
					break;
				case "lvl4pPr":
					class1963_4 = new Class1963(reader);
					break;
				case "lvl5pPr":
					class1963_5 = new Class1963(reader);
					break;
				case "lvl6pPr":
					class1963_6 = new Class1963(reader);
					break;
				case "lvl7pPr":
					class1963_7 = new Class1963(reader);
					break;
				case "lvl8pPr":
					class1963_8 = new Class1963(reader);
					break;
				case "lvl9pPr":
					class1963_9 = new Class1963(reader);
					break;
				case "extLst":
					class1886_0 = new Class1886(reader);
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

	public Class1958(XmlReader reader)
		: base(reader)
	{
	}

	public Class1958()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1756_0 = method_3;
		delegate1758_0 = method_4;
		delegate1756_1 = method_5;
		delegate1758_1 = method_6;
		delegate1756_2 = method_7;
		delegate1758_2 = method_8;
		delegate1756_3 = method_9;
		delegate1758_3 = method_10;
		delegate1756_4 = method_11;
		delegate1758_4 = method_12;
		delegate1756_5 = method_13;
		delegate1758_5 = method_14;
		delegate1756_6 = method_15;
		delegate1758_6 = method_16;
		delegate1756_7 = method_17;
		delegate1758_7 = method_18;
		delegate1756_8 = method_19;
		delegate1758_8 = method_20;
		delegate1756_9 = method_21;
		delegate1758_9 = method_22;
		delegate1534_0 = method_23;
		delegate1535_0 = method_24;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1963_0 != null)
		{
			class1963_0.vmethod_4("a", writer, "defPPr");
		}
		if (class1963_1 != null)
		{
			class1963_1.vmethod_4("a", writer, "lvl1pPr");
		}
		if (class1963_2 != null)
		{
			class1963_2.vmethod_4("a", writer, "lvl2pPr");
		}
		if (class1963_3 != null)
		{
			class1963_3.vmethod_4("a", writer, "lvl3pPr");
		}
		if (class1963_4 != null)
		{
			class1963_4.vmethod_4("a", writer, "lvl4pPr");
		}
		if (class1963_5 != null)
		{
			class1963_5.vmethod_4("a", writer, "lvl5pPr");
		}
		if (class1963_6 != null)
		{
			class1963_6.vmethod_4("a", writer, "lvl6pPr");
		}
		if (class1963_7 != null)
		{
			class1963_7.vmethod_4("a", writer, "lvl7pPr");
		}
		if (class1963_8 != null)
		{
			class1963_8.vmethod_4("a", writer, "lvl8pPr");
		}
		if (class1963_9 != null)
		{
			class1963_9.vmethod_4("a", writer, "lvl9pPr");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1963 method_3()
	{
		if (class1963_0 != null)
		{
			throw new Exception("Only one <defPPr> element can be added.");
		}
		class1963_0 = new Class1963();
		return class1963_0;
	}

	private void method_4(Class1963 _defPPr)
	{
		class1963_0 = _defPPr;
	}

	private Class1963 method_5()
	{
		if (class1963_1 != null)
		{
			throw new Exception("Only one <lvl1pPr> element can be added.");
		}
		class1963_1 = new Class1963();
		return class1963_1;
	}

	private void method_6(Class1963 _lvl1pPr)
	{
		class1963_1 = _lvl1pPr;
	}

	private Class1963 method_7()
	{
		if (class1963_2 != null)
		{
			throw new Exception("Only one <lvl2pPr> element can be added.");
		}
		class1963_2 = new Class1963();
		return class1963_2;
	}

	private void method_8(Class1963 _lvl2pPr)
	{
		class1963_2 = _lvl2pPr;
	}

	private Class1963 method_9()
	{
		if (class1963_3 != null)
		{
			throw new Exception("Only one <lvl3pPr> element can be added.");
		}
		class1963_3 = new Class1963();
		return class1963_3;
	}

	private void method_10(Class1963 _lvl3pPr)
	{
		class1963_3 = _lvl3pPr;
	}

	private Class1963 method_11()
	{
		if (class1963_4 != null)
		{
			throw new Exception("Only one <lvl4pPr> element can be added.");
		}
		class1963_4 = new Class1963();
		return class1963_4;
	}

	private void method_12(Class1963 _lvl4pPr)
	{
		class1963_4 = _lvl4pPr;
	}

	private Class1963 method_13()
	{
		if (class1963_5 != null)
		{
			throw new Exception("Only one <lvl5pPr> element can be added.");
		}
		class1963_5 = new Class1963();
		return class1963_5;
	}

	private void method_14(Class1963 _lvl5pPr)
	{
		class1963_5 = _lvl5pPr;
	}

	private Class1963 method_15()
	{
		if (class1963_6 != null)
		{
			throw new Exception("Only one <lvl6pPr> element can be added.");
		}
		class1963_6 = new Class1963();
		return class1963_6;
	}

	private void method_16(Class1963 _lvl6pPr)
	{
		class1963_6 = _lvl6pPr;
	}

	private Class1963 method_17()
	{
		if (class1963_7 != null)
		{
			throw new Exception("Only one <lvl7pPr> element can be added.");
		}
		class1963_7 = new Class1963();
		return class1963_7;
	}

	private void method_18(Class1963 _lvl7pPr)
	{
		class1963_7 = _lvl7pPr;
	}

	private Class1963 method_19()
	{
		if (class1963_8 != null)
		{
			throw new Exception("Only one <lvl8pPr> element can be added.");
		}
		class1963_8 = new Class1963();
		return class1963_8;
	}

	private void method_20(Class1963 _lvl8pPr)
	{
		class1963_8 = _lvl8pPr;
	}

	private Class1963 method_21()
	{
		if (class1963_9 != null)
		{
			throw new Exception("Only one <lvl9pPr> element can be added.");
		}
		class1963_9 = new Class1963();
		return class1963_9;
	}

	private void method_22(Class1963 _lvl9pPr)
	{
		class1963_9 = _lvl9pPr;
	}

	private Class1885 method_23()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_24(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
