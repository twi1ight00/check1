using System;
using System.Xml;

namespace ns56;

internal class Class2090 : Class1351
{
	public delegate Class2090 Delegate1988();

	public delegate void Delegate1990(Class2090 elementData);

	public delegate void Delegate1989(Class2090 elementData);

	public Class2082.Delegate1961 delegate1961_0;

	public Class2082.Delegate1963 delegate1963_0;

	public Class2081.Delegate1958 delegate1958_0;

	public Class2081.Delegate1960 delegate1960_0;

	public Class2081.Delegate1958 delegate1958_1;

	public Class2081.Delegate1960 delegate1960_1;

	public Class2081.Delegate1958 delegate1958_2;

	public Class2081.Delegate1960 delegate1960_2;

	public Class2081.Delegate1958 delegate1958_3;

	public Class2081.Delegate1960 delegate1960_3;

	public Class2070.Delegate1923 delegate1923_0;

	public Class2070.Delegate1925 delegate1925_0;

	public Class2070.Delegate1923 delegate1923_1;

	public Class2070.Delegate1925 delegate1925_1;

	public Class2070.Delegate1923 delegate1923_2;

	public Class2070.Delegate1925 delegate1925_2;

	public Class2070.Delegate1923 delegate1923_3;

	public Class2070.Delegate1925 delegate1925_3;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2082 class2082_0;

	private Class2081 class2081_0;

	private Class2081 class2081_1;

	private Class2081 class2081_2;

	private Class2081 class2081_3;

	private Class2070 class2070_0;

	private Class2070 class2070_1;

	private Class2070 class2070_2;

	private Class2070 class2070_3;

	private Class1887 class1887_0;

	public Class2082 LayoutTarget => class2082_0;

	public Class2081 XMode => class2081_0;

	public Class2081 YMode => class2081_1;

	public Class2081 WMode => class2081_2;

	public Class2081 HMode => class2081_3;

	public Class2070 X => class2070_0;

	public Class2070 Y => class2070_1;

	public Class2070 W => class2070_2;

	public Class2070 H => class2070_3;

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
				case "layoutTarget":
					class2082_0 = new Class2082(reader);
					break;
				case "xMode":
					class2081_0 = new Class2081(reader);
					break;
				case "yMode":
					class2081_1 = new Class2081(reader);
					break;
				case "wMode":
					class2081_2 = new Class2081(reader);
					break;
				case "hMode":
					class2081_3 = new Class2081(reader);
					break;
				case "x":
					class2070_0 = new Class2070(reader);
					break;
				case "y":
					class2070_1 = new Class2070(reader);
					break;
				case "w":
					class2070_2 = new Class2070(reader);
					break;
				case "h":
					class2070_3 = new Class2070(reader);
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

	public Class2090(XmlReader reader)
		: base(reader)
	{
	}

	public Class2090()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1961_0 = method_3;
		delegate1963_0 = method_4;
		delegate1958_0 = method_5;
		delegate1960_0 = method_6;
		delegate1958_1 = method_7;
		delegate1960_1 = method_8;
		delegate1958_2 = method_9;
		delegate1960_2 = method_10;
		delegate1958_3 = method_11;
		delegate1960_3 = method_12;
		delegate1923_0 = method_13;
		delegate1925_0 = method_14;
		delegate1923_1 = method_15;
		delegate1925_1 = method_16;
		delegate1923_2 = method_17;
		delegate1925_2 = method_18;
		delegate1923_3 = method_19;
		delegate1925_3 = method_20;
		delegate1534_0 = method_21;
		delegate1535_0 = method_22;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2082_0 != null)
		{
			class2082_0.vmethod_4("c", writer, "layoutTarget");
		}
		if (class2081_0 != null)
		{
			class2081_0.vmethod_4("c", writer, "xMode");
		}
		if (class2081_1 != null)
		{
			class2081_1.vmethod_4("c", writer, "yMode");
		}
		if (class2081_2 != null)
		{
			class2081_2.vmethod_4("c", writer, "wMode");
		}
		if (class2081_3 != null)
		{
			class2081_3.vmethod_4("c", writer, "hMode");
		}
		if (class2070_0 != null)
		{
			class2070_0.vmethod_4("c", writer, "x");
		}
		if (class2070_1 != null)
		{
			class2070_1.vmethod_4("c", writer, "y");
		}
		if (class2070_2 != null)
		{
			class2070_2.vmethod_4("c", writer, "w");
		}
		if (class2070_3 != null)
		{
			class2070_3.vmethod_4("c", writer, "h");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2082 method_3()
	{
		if (class2082_0 != null)
		{
			throw new Exception("Only one <layoutTarget> element can be added.");
		}
		class2082_0 = new Class2082();
		return class2082_0;
	}

	private void method_4(Class2082 _layoutTarget)
	{
		class2082_0 = _layoutTarget;
	}

	private Class2081 method_5()
	{
		if (class2081_0 != null)
		{
			throw new Exception("Only one <xMode> element can be added.");
		}
		class2081_0 = new Class2081();
		return class2081_0;
	}

	private void method_6(Class2081 _xMode)
	{
		class2081_0 = _xMode;
	}

	private Class2081 method_7()
	{
		if (class2081_1 != null)
		{
			throw new Exception("Only one <yMode> element can be added.");
		}
		class2081_1 = new Class2081();
		return class2081_1;
	}

	private void method_8(Class2081 _yMode)
	{
		class2081_1 = _yMode;
	}

	private Class2081 method_9()
	{
		if (class2081_2 != null)
		{
			throw new Exception("Only one <wMode> element can be added.");
		}
		class2081_2 = new Class2081();
		return class2081_2;
	}

	private void method_10(Class2081 _wMode)
	{
		class2081_2 = _wMode;
	}

	private Class2081 method_11()
	{
		if (class2081_3 != null)
		{
			throw new Exception("Only one <hMode> element can be added.");
		}
		class2081_3 = new Class2081();
		return class2081_3;
	}

	private void method_12(Class2081 _hMode)
	{
		class2081_3 = _hMode;
	}

	private Class2070 method_13()
	{
		if (class2070_0 != null)
		{
			throw new Exception("Only one <x> element can be added.");
		}
		class2070_0 = new Class2070();
		return class2070_0;
	}

	private void method_14(Class2070 _x)
	{
		class2070_0 = _x;
	}

	private Class2070 method_15()
	{
		if (class2070_1 != null)
		{
			throw new Exception("Only one <y> element can be added.");
		}
		class2070_1 = new Class2070();
		return class2070_1;
	}

	private void method_16(Class2070 _y)
	{
		class2070_1 = _y;
	}

	private Class2070 method_17()
	{
		if (class2070_2 != null)
		{
			throw new Exception("Only one <w> element can be added.");
		}
		class2070_2 = new Class2070();
		return class2070_2;
	}

	private void method_18(Class2070 _w)
	{
		class2070_2 = _w;
	}

	private Class2070 method_19()
	{
		if (class2070_3 != null)
		{
			throw new Exception("Only one <h> element can be added.");
		}
		class2070_3 = new Class2070();
		return class2070_3;
	}

	private void method_20(Class2070 _h)
	{
		class2070_3 = _h;
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
