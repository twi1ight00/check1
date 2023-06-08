using System;
using System.Xml;

namespace ns56;

internal class Class2129 : Class1351
{
	public delegate Class2129 Delegate2118();

	public delegate void Delegate2119(Class2129 elementData);

	public delegate void Delegate2120(Class2129 elementData);

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class2101.Delegate2022 delegate2022_0;

	public Class2101.Delegate2024 delegate2024_0;

	public Class2104.Delegate2031 delegate2031_0;

	public Class2104.Delegate2033 delegate2033_0;

	public Class2070.Delegate1923 delegate1923_0;

	public Class2070.Delegate1925 delegate1925_0;

	public Class2070.Delegate1923 delegate1923_1;

	public Class2070.Delegate1925 delegate1925_1;

	public Class2070.Delegate1923 delegate1923_2;

	public Class2070.Delegate1925 delegate1925_2;

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class2339.Delegate2763 delegate2763_1;

	public Class2339.Delegate2764 delegate2764_1;

	public Class2130.Delegate2121 delegate2121_0;

	public Class2130.Delegate2123 delegate2123_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_0;

	private Class1921 class1921_0;

	private Class2133 class2133_0;

	private Class2101 class2101_0;

	private Class2104 class2104_0;

	private Class2070 class2070_0;

	private Class2070 class2070_1;

	private Class2070 class2070_2;

	private Class2339 class2339_0;

	private Class2339 class2339_1;

	private Class2130 class2130_0;

	private Class1887 class1887_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class1921 SpPr => class1921_0;

	public Class2133 TrendlineType => class2133_0;

	public Class2101 Order => class2101_0;

	public Class2104 Period => class2104_0;

	public Class2070 Forward => class2070_0;

	public Class2070 Backward => class2070_1;

	public Class2070 Intercept => class2070_2;

	public Class2339 DispRSqr => class2339_0;

	public Class2339 DispEq => class2339_1;

	public Class2130 TrendlineLbl => class2130_0;

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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (reader.LocalName)
			{
			case "name":
				string_0 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_0 += reader.ReadString();
					}
				}
				break;
			case "spPr":
				class1921_0 = new Class1921(reader);
				break;
			case "trendlineType":
				class2133_0 = new Class2133(reader);
				break;
			case "order":
				class2101_0 = new Class2101(reader);
				break;
			case "period":
				class2104_0 = new Class2104(reader);
				break;
			case "forward":
				class2070_0 = new Class2070(reader);
				break;
			case "backward":
				class2070_1 = new Class2070(reader);
				break;
			case "intercept":
				class2070_2 = new Class2070(reader);
				break;
			case "dispRSqr":
				class2339_0 = new Class2339(reader);
				break;
			case "dispEq":
				class2339_1 = new Class2339(reader);
				break;
			case "trendlineLbl":
				class2130_0 = new Class2130(reader);
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

	private void method_2(XmlReader reader)
	{
	}

	public Class2129(XmlReader reader)
		: base(reader)
	{
	}

	public Class2129()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1630_0 = method_3;
		delegate1632_0 = method_4;
		delegate2022_0 = method_5;
		delegate2024_0 = method_6;
		delegate2031_0 = method_7;
		delegate2033_0 = method_8;
		delegate1923_0 = method_9;
		delegate1925_0 = method_10;
		delegate1923_1 = method_11;
		delegate1925_1 = method_12;
		delegate1923_2 = method_13;
		delegate1925_2 = method_14;
		delegate2763_0 = method_15;
		delegate2764_0 = method_16;
		delegate2763_1 = method_17;
		delegate2764_1 = method_18;
		delegate2121_0 = method_19;
		delegate2123_0 = method_20;
		delegate1534_0 = method_21;
		delegate1535_0 = method_22;
	}

	protected override void vmethod_3()
	{
		class2133_0 = new Class2133();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			method_1("c", writer, "name", string_0);
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		class2133_0.vmethod_4("c", writer, "trendlineType");
		if (class2101_0 != null)
		{
			class2101_0.vmethod_4("c", writer, "order");
		}
		if (class2104_0 != null)
		{
			class2104_0.vmethod_4("c", writer, "period");
		}
		if (class2070_0 != null)
		{
			class2070_0.vmethod_4("c", writer, "forward");
		}
		if (class2070_1 != null)
		{
			class2070_1.vmethod_4("c", writer, "backward");
		}
		if (class2070_2 != null)
		{
			class2070_2.vmethod_4("c", writer, "intercept");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "dispRSqr");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "dispEq");
		}
		if (class2130_0 != null)
		{
			class2130_0.vmethod_4("c", writer, "trendlineLbl");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1921 method_3()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_4(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class2101 method_5()
	{
		if (class2101_0 != null)
		{
			throw new Exception("Only one <order> element can be added.");
		}
		class2101_0 = new Class2101();
		return class2101_0;
	}

	private void method_6(Class2101 _order)
	{
		class2101_0 = _order;
	}

	private Class2104 method_7()
	{
		if (class2104_0 != null)
		{
			throw new Exception("Only one <period> element can be added.");
		}
		class2104_0 = new Class2104();
		return class2104_0;
	}

	private void method_8(Class2104 _period)
	{
		class2104_0 = _period;
	}

	private Class2070 method_9()
	{
		if (class2070_0 != null)
		{
			throw new Exception("Only one <forward> element can be added.");
		}
		class2070_0 = new Class2070();
		return class2070_0;
	}

	private void method_10(Class2070 _forward)
	{
		class2070_0 = _forward;
	}

	private Class2070 method_11()
	{
		if (class2070_1 != null)
		{
			throw new Exception("Only one <backward> element can be added.");
		}
		class2070_1 = new Class2070();
		return class2070_1;
	}

	private void method_12(Class2070 _backward)
	{
		class2070_1 = _backward;
	}

	private Class2070 method_13()
	{
		if (class2070_2 != null)
		{
			throw new Exception("Only one <intercept> element can be added.");
		}
		class2070_2 = new Class2070();
		return class2070_2;
	}

	private void method_14(Class2070 _intercept)
	{
		class2070_2 = _intercept;
	}

	private Class2339 method_15()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <dispRSqr> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_16(Class2339 _dispRSqr)
	{
		class2339_0 = _dispRSqr;
	}

	private Class2339 method_17()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <dispEq> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_18(Class2339 _dispEq)
	{
		class2339_1 = _dispEq;
	}

	private Class2130 method_19()
	{
		if (class2130_0 != null)
		{
			throw new Exception("Only one <trendlineLbl> element can be added.");
		}
		class2130_0 = new Class2130();
		return class2130_0;
	}

	private void method_20(Class2130 _trendlineLbl)
	{
		class2130_0 = _trendlineLbl;
	}

	private Class1885 method_21()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_22(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
