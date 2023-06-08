using System;
using System.Xml;

namespace ns56;

internal class Class2073 : Class1351
{
	public delegate Class2073 Delegate1933();

	public delegate void Delegate1935(Class2073 elementData);

	public delegate void Delegate1934(Class2073 elementData);

	public Class1357.Delegate33 delegate33_0;

	public Class1357.Delegate35 delegate35_0;

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class2342.Delegate2767 delegate2767_0;

	public Class2342.Delegate2768 delegate2768_0;

	public Class2342.Delegate2767 delegate2767_1;

	public Class2342.Delegate2768 delegate2768_1;

	public Class2070.Delegate1923 delegate1923_0;

	public Class2070.Delegate1925 delegate1925_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1357 class1357_0;

	private Class1356 class1356_0;

	private Class1773 class1773_0;

	private Class2339 class2339_0;

	private Class2342 class2342_0;

	private Class2342 class2342_1;

	private Class2070 class2070_0;

	private Class1921 class1921_0;

	private Class1887 class1887_0;

	public Class1357 ErrDir => class1357_0;

	public Class1356 ErrBarType => class1356_0;

	public Class1773 ErrValType => class1773_0;

	public Class2339 NoEndCap => class2339_0;

	public Class2342 Plus => class2342_0;

	public Class2342 Minus => class2342_1;

	public Class2070 Val => class2070_0;

	public Class1921 SpPr => class1921_0;

	public Class1885 ExtLst => class1887_0;

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
				case "errDir":
					class1357_0 = new Class1357(reader);
					break;
				case "errBarType":
					class1356_0 = new Class1356(reader);
					break;
				case "errValType":
					class1773_0 = new Class1773(reader);
					break;
				case "noEndCap":
					class2339_0 = new Class2339(reader);
					break;
				case "plus":
					class2342_0 = new Class2342(reader);
					break;
				case "minus":
					class2342_1 = new Class2342(reader);
					break;
				case "val":
					class2070_0 = new Class2070(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "extLst":
					class1887_0 = new Class1887(reader);
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

	public Class2073(XmlReader reader)
		: base(reader)
	{
	}

	public Class2073()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate33_0 = method_3;
		delegate35_0 = method_4;
		delegate2763_0 = method_5;
		delegate2764_0 = method_6;
		delegate2767_0 = method_7;
		delegate2768_0 = method_8;
		delegate2767_1 = method_9;
		delegate2768_1 = method_10;
		delegate1923_0 = method_11;
		delegate1925_0 = method_12;
		delegate1630_0 = method_13;
		delegate1632_0 = method_14;
		delegate1534_0 = method_15;
		delegate1535_0 = method_16;
	}

	protected override void vmethod_3()
	{
		class1356_0 = new Class1356();
		class1773_0 = new Class1773();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1357_0 != null)
		{
			class1357_0.vmethod_4("c", writer, "errDir");
		}
		class1356_0.vmethod_4("c", writer, "errBarType");
		class1773_0.vmethod_4("c", writer, "errValType");
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "noEndCap");
		}
		if (class2342_0 != null)
		{
			class2342_0.vmethod_4("c", writer, "plus");
		}
		if (class2342_1 != null)
		{
			class2342_1.vmethod_4("c", writer, "minus");
		}
		if (class2070_0 != null)
		{
			class2070_0.vmethod_4("c", writer, "val");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1357 method_3()
	{
		if (class1357_0 != null)
		{
			throw new Exception("Only one <errDir> element can be added.");
		}
		class1357_0 = new Class1357();
		return class1357_0;
	}

	private void method_4(Class1357 _errDir)
	{
		class1357_0 = _errDir;
	}

	private Class2339 method_5()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <noEndCap> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_6(Class2339 _noEndCap)
	{
		class2339_0 = _noEndCap;
	}

	private Class2342 method_7()
	{
		if (class2342_0 != null)
		{
			throw new Exception("Only one <plus> element can be added.");
		}
		class2342_0 = new Class2342();
		return class2342_0;
	}

	private void method_8(Class2342 _plus)
	{
		class2342_0 = _plus;
	}

	private Class2342 method_9()
	{
		if (class2342_1 != null)
		{
			throw new Exception("Only one <minus> element can be added.");
		}
		class2342_1 = new Class2342();
		return class2342_1;
	}

	private void method_10(Class2342 _minus)
	{
		class2342_1 = _minus;
	}

	private Class2070 method_11()
	{
		if (class2070_0 != null)
		{
			throw new Exception("Only one <val> element can be added.");
		}
		class2070_0 = new Class2070();
		return class2070_0;
	}

	private void method_12(Class2070 _val)
	{
		class2070_0 = _val;
	}

	private Class1921 method_13()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_14(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1885 method_15()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_16(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
