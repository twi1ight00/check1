using System;
using System.Xml;

namespace ns56;

internal class Class2058 : Class1351
{
	public delegate Class2058 Delegate1886();

	public delegate void Delegate1887(Class2058 elementData);

	public delegate void Delegate1888(Class2058 elementData);

	public Class2128.Delegate2115 delegate2115_0;

	public Class2128.Delegate2117 delegate2117_0;

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class2138.Delegate2146 delegate2146_0;

	public Class2138.Delegate2148 delegate2148_0;

	public Class2123.Delegate2099 delegate2099_0;

	public Class2123.Delegate2101 delegate2101_0;

	public Class2123.Delegate2099 delegate2099_1;

	public Class2123.Delegate2101 delegate2101_1;

	public Class2123.Delegate2099 delegate2099_2;

	public Class2123.Delegate2101 delegate2101_2;

	public Class2085.Delegate1970 delegate1970_0;

	public Class2085.Delegate1972 delegate1972_0;

	public Class2339.Delegate2763 delegate2763_1;

	public Class2339.Delegate2764 delegate2764_1;

	public Class2064.Delegate1905 delegate1905_0;

	public Class2064.Delegate1907 delegate1907_0;

	public Class2339.Delegate2763 delegate2763_2;

	public Class2339.Delegate2764 delegate2764_2;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2128 class2128_0;

	private Class2339 class2339_0;

	private Class1459 class1459_0;

	private Class2138 class2138_0;

	private Class2123 class2123_0;

	private Class2123 class2123_1;

	private Class2123 class2123_2;

	private Class2106 class2106_0;

	private Class2085 class2085_0;

	private Class2339 class2339_1;

	private Class2064 class2064_0;

	private Class2339 class2339_2;

	private Class1887 class1887_0;

	public Class2128 Title => class2128_0;

	public Class2339 AutoTitleDeleted => class2339_0;

	public Class1459 PivotFmts => class1459_0;

	public Class2138 View3D => class2138_0;

	public Class2123 Floor => class2123_0;

	public Class2123 SideWall => class2123_1;

	public Class2123 BackWall => class2123_2;

	public Class2106 PlotArea => class2106_0;

	public Class2085 Legend => class2085_0;

	public Class2339 PlotVisOnly => class2339_1;

	public Class2064 DispBlanksAs => class2064_0;

	public Class2339 ShowDLblsOverMax => class2339_2;

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
				case "title":
					class2128_0 = new Class2128(reader);
					break;
				case "autoTitleDeleted":
					class2339_0 = new Class2339(reader);
					break;
				case "pivotFmts":
					class1459_0 = new Class1459(reader);
					flag = true;
					break;
				case "view3D":
					class2138_0 = new Class2138(reader);
					break;
				case "floor":
					class2123_0 = new Class2123(reader);
					break;
				case "sideWall":
					class2123_1 = new Class2123(reader);
					break;
				case "backWall":
					class2123_2 = new Class2123(reader);
					break;
				case "plotArea":
					class2106_0 = new Class2106(reader);
					break;
				case "legend":
					class2085_0 = new Class2085(reader);
					break;
				case "plotVisOnly":
					class2339_1 = new Class2339(reader);
					break;
				case "dispBlanksAs":
					class2064_0 = new Class2064(reader);
					break;
				case "showDLblsOverMax":
					class2339_2 = new Class2339(reader);
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

	public Class2058(XmlReader reader)
		: base(reader)
	{
	}

	public Class2058()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2115_0 = method_3;
		delegate2117_0 = method_4;
		delegate2763_0 = method_5;
		delegate2764_0 = method_6;
		delegate303_0 = method_7;
		delegate304_0 = method_8;
		delegate2146_0 = method_9;
		delegate2148_0 = method_10;
		delegate2099_0 = method_11;
		delegate2101_0 = method_12;
		delegate2099_1 = method_13;
		delegate2101_1 = method_14;
		delegate2099_2 = method_15;
		delegate2101_2 = method_16;
		delegate1970_0 = method_17;
		delegate1972_0 = method_18;
		delegate2763_1 = method_19;
		delegate2764_1 = method_20;
		delegate1905_0 = method_21;
		delegate1907_0 = method_22;
		delegate2763_2 = method_23;
		delegate2764_2 = method_24;
		delegate1534_0 = method_25;
		delegate1535_0 = method_26;
	}

	protected override void vmethod_3()
	{
		class2106_0 = new Class2106();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2128_0 != null)
		{
			class2128_0.vmethod_4("c", writer, "title");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "autoTitleDeleted");
		}
		if (class1459_0 != null)
		{
			class1459_0.vmethod_4("c", writer, "pivotFmts");
		}
		if (class2138_0 != null)
		{
			class2138_0.vmethod_4("c", writer, "view3D");
		}
		if (class2123_0 != null)
		{
			class2123_0.vmethod_4("c", writer, "floor");
		}
		if (class2123_1 != null)
		{
			class2123_1.vmethod_4("c", writer, "sideWall");
		}
		if (class2123_2 != null)
		{
			class2123_2.vmethod_4("c", writer, "backWall");
		}
		class2106_0.vmethod_4("c", writer, "plotArea");
		if (class2085_0 != null)
		{
			class2085_0.vmethod_4("c", writer, "legend");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "plotVisOnly");
		}
		if (class2064_0 != null)
		{
			class2064_0.vmethod_4("c", writer, "dispBlanksAs");
		}
		if (class2339_2 != null)
		{
			class2339_2.vmethod_4("c", writer, "showDLblsOverMax");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2128 method_3()
	{
		if (class2128_0 != null)
		{
			throw new Exception("Only one <title> element can be added.");
		}
		class2128_0 = new Class2128();
		return class2128_0;
	}

	private void method_4(Class2128 _title)
	{
		class2128_0 = _title;
	}

	private Class2339 method_5()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <autoTitleDeleted> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_6(Class2339 _autoTitleDeleted)
	{
		class2339_0 = _autoTitleDeleted;
	}

	private Class1447 method_7()
	{
		if (class1459_0 != null)
		{
			throw new Exception("Only one <pivotFmts> element can be added.");
		}
		class1459_0 = new Class1459();
		return class1459_0;
	}

	private void method_8(Class1447 _pivotFmts)
	{
		class1459_0 = (Class1459)_pivotFmts;
	}

	private Class2138 method_9()
	{
		if (class2138_0 != null)
		{
			throw new Exception("Only one <view3D> element can be added.");
		}
		class2138_0 = new Class2138();
		return class2138_0;
	}

	private void method_10(Class2138 _view3D)
	{
		class2138_0 = _view3D;
	}

	private Class2123 method_11()
	{
		if (class2123_0 != null)
		{
			throw new Exception("Only one <floor> element can be added.");
		}
		class2123_0 = new Class2123();
		return class2123_0;
	}

	private void method_12(Class2123 _floor)
	{
		class2123_0 = _floor;
	}

	private Class2123 method_13()
	{
		if (class2123_1 != null)
		{
			throw new Exception("Only one <sideWall> element can be added.");
		}
		class2123_1 = new Class2123();
		return class2123_1;
	}

	private void method_14(Class2123 _sideWall)
	{
		class2123_1 = _sideWall;
	}

	private Class2123 method_15()
	{
		if (class2123_2 != null)
		{
			throw new Exception("Only one <backWall> element can be added.");
		}
		class2123_2 = new Class2123();
		return class2123_2;
	}

	private void method_16(Class2123 _backWall)
	{
		class2123_2 = _backWall;
	}

	private Class2085 method_17()
	{
		if (class2085_0 != null)
		{
			throw new Exception("Only one <legend> element can be added.");
		}
		class2085_0 = new Class2085();
		return class2085_0;
	}

	private void method_18(Class2085 _legend)
	{
		class2085_0 = _legend;
	}

	private Class2339 method_19()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <plotVisOnly> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_20(Class2339 _plotVisOnly)
	{
		class2339_1 = _plotVisOnly;
	}

	private Class2064 method_21()
	{
		if (class2064_0 != null)
		{
			throw new Exception("Only one <dispBlanksAs> element can be added.");
		}
		class2064_0 = new Class2064();
		return class2064_0;
	}

	private void method_22(Class2064 _dispBlanksAs)
	{
		class2064_0 = _dispBlanksAs;
	}

	private Class2339 method_23()
	{
		if (class2339_2 != null)
		{
			throw new Exception("Only one <showDLblsOverMax> element can be added.");
		}
		class2339_2 = new Class2339();
		return class2339_2;
	}

	private void method_24(Class2339 _showDLblsOverMax)
	{
		class2339_2 = _showDLblsOverMax;
	}

	private Class1885 method_25()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_26(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
