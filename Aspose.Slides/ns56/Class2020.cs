using System;
using System.Xml;

namespace ns56;

internal class Class2020 : Class1351
{
	public delegate Class2020 Delegate1849();

	public delegate void Delegate1850(Class2020 elementData);

	public delegate void Delegate1851(Class2020 elementData);

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class2124.Delegate2103 delegate2103_0;

	public Class2124.Delegate2105 delegate2105_0;

	public Class2339.Delegate2763 delegate2763_1;

	public Class2339.Delegate2764 delegate2764_1;

	public Class1777.Delegate1210 delegate1210_0;

	public Class1777.Delegate1212 delegate1212_0;

	public Class1815.Delegate1324 delegate1324_0;

	public Class1815.Delegate1326 delegate1326_0;

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class1447.Delegate303 delegate303_1;

	public Class1447.Delegate304 delegate304_1;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class2074.Delegate1937 delegate1937_0;

	public Class2074.Delegate1939 delegate1939_0;

	public Class1447.Delegate303 delegate303_2;

	public Class1447.Delegate304 delegate304_2;

	public Class2108.Delegate2048 delegate2048_0;

	public Class2108.Delegate2050 delegate2050_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2339 class2339_0;

	private Class2124 class2124_0;

	private Class2339 class2339_1;

	private Class1777 class1777_0;

	private Class1815 class1815_0;

	private Class1460 class1460_0;

	private Class1462 class1462_0;

	private Class2058 class2058_0;

	private Class1921 class1921_0;

	private Class1946 class1946_0;

	private Class2074 class2074_0;

	private Class1461 class1461_0;

	private Class2108 class2108_0;

	private Class1887 class1887_0;

	public Class2339 Date1904 => class2339_0;

	public Class2124 Lang => class2124_0;

	public Class2339 RoundedCorners => class2339_1;

	public Class1777 Style => class1777_0;

	public Class1815 ClrMapOvr => class1815_0;

	public Class1460 PivotSource => class1460_0;

	public Class1462 Protection => class1462_0;

	public Class2058 Chart => class2058_0;

	public Class1921 SpPr => class1921_0;

	public Class1946 TxPr => class1946_0;

	public Class2074 ExternalData => class2074_0;

	public Class1461 PrintSettings => class1461_0;

	public Class2108 UserShapes => class2108_0;

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
				case "date1904":
					class2339_0 = new Class2339(reader);
					break;
				case "lang":
					class2124_0 = new Class2124(reader);
					break;
				case "roundedCorners":
					class2339_1 = new Class2339(reader);
					break;
				case "style":
					class1777_0 = new Class1777(reader);
					break;
				case "clrMapOvr":
					class1815_0 = new Class1815(reader);
					break;
				case "pivotSource":
					class1460_0 = new Class1460(reader);
					flag = true;
					break;
				case "protection":
					class1462_0 = new Class1462(reader);
					flag = true;
					break;
				case "chart":
					class2058_0 = new Class2058(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "txPr":
					class1946_0 = new Class1946(reader);
					break;
				case "externalData":
					class2074_0 = new Class2074(reader);
					break;
				case "printSettings":
					class1461_0 = new Class1461(reader);
					flag = true;
					break;
				case "userShapes":
					class2108_0 = new Class2108(reader);
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

	public Class2020(XmlReader reader)
		: base(reader)
	{
	}

	public Class2020()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_3;
		delegate2764_0 = method_4;
		delegate2103_0 = method_5;
		delegate2105_0 = method_6;
		delegate2763_1 = method_7;
		delegate2764_1 = method_8;
		delegate1210_0 = method_9;
		delegate1212_0 = method_10;
		delegate1324_0 = method_11;
		delegate1326_0 = method_12;
		delegate303_0 = method_13;
		delegate304_0 = method_14;
		delegate303_1 = method_15;
		delegate304_1 = method_16;
		delegate1630_0 = method_17;
		delegate1632_0 = method_18;
		delegate1705_0 = method_19;
		delegate1707_0 = method_20;
		delegate1937_0 = method_21;
		delegate1939_0 = method_22;
		delegate303_2 = method_23;
		delegate304_2 = method_24;
		delegate2048_0 = method_25;
		delegate2050_0 = method_26;
		delegate1534_0 = method_27;
		delegate1535_0 = method_28;
	}

	protected override void vmethod_3()
	{
		class2058_0 = new Class2058();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("c", elementName, "http://schemas.openxmlformats.org/drawingml/2006/chart");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "date1904");
		}
		if (class2124_0 != null)
		{
			class2124_0.vmethod_4("c", writer, "lang");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "roundedCorners");
		}
		if (class1777_0 != null)
		{
			class1777_0.vmethod_4("c", writer, "style");
		}
		if (class1815_0 != null)
		{
			class1815_0.vmethod_4("c", writer, "clrMapOvr");
		}
		if (class1460_0 != null)
		{
			class1460_0.vmethod_4("c", writer, "pivotSource");
		}
		if (class1462_0 != null)
		{
			class1462_0.vmethod_4("c", writer, "protection");
		}
		class2058_0.vmethod_4("c", writer, "chart");
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("c", writer, "txPr");
		}
		if (class2074_0 != null)
		{
			class2074_0.vmethod_4("c", writer, "externalData");
		}
		if (class1461_0 != null)
		{
			class1461_0.vmethod_4("c", writer, "printSettings");
		}
		if (class2108_0 != null)
		{
			class2108_0.vmethod_4("c", writer, "userShapes");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2339 method_3()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <date1904> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_4(Class2339 _date1904)
	{
		class2339_0 = _date1904;
	}

	private Class2124 method_5()
	{
		if (class2124_0 != null)
		{
			throw new Exception("Only one <lang> element can be added.");
		}
		class2124_0 = new Class2124();
		return class2124_0;
	}

	private void method_6(Class2124 _lang)
	{
		class2124_0 = _lang;
	}

	private Class2339 method_7()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <roundedCorners> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_8(Class2339 _roundedCorners)
	{
		class2339_1 = _roundedCorners;
	}

	private Class1777 method_9()
	{
		if (class1777_0 != null)
		{
			throw new Exception("Only one <style> element can be added.");
		}
		class1777_0 = new Class1777();
		return class1777_0;
	}

	private void method_10(Class1777 _style)
	{
		class1777_0 = _style;
	}

	private Class1815 method_11()
	{
		if (class1815_0 != null)
		{
			throw new Exception("Only one <clrMapOvr> element can be added.");
		}
		class1815_0 = new Class1815();
		return class1815_0;
	}

	private void method_12(Class1815 _clrMapOvr)
	{
		class1815_0 = _clrMapOvr;
	}

	private Class1447 method_13()
	{
		if (class1460_0 != null)
		{
			throw new Exception("Only one <pivotSource> element can be added.");
		}
		class1460_0 = new Class1460();
		return class1460_0;
	}

	private void method_14(Class1447 _pivotSource)
	{
		class1460_0 = (Class1460)_pivotSource;
	}

	private Class1447 method_15()
	{
		if (class1462_0 != null)
		{
			throw new Exception("Only one <protection> element can be added.");
		}
		class1462_0 = new Class1462();
		return class1462_0;
	}

	private void method_16(Class1447 _protection)
	{
		class1462_0 = (Class1462)_protection;
	}

	private Class1921 method_17()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_18(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1946 method_19()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txPr> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_20(Class1946 _txPr)
	{
		class1946_0 = _txPr;
	}

	private Class2074 method_21()
	{
		if (class2074_0 != null)
		{
			throw new Exception("Only one <externalData> element can be added.");
		}
		class2074_0 = new Class2074();
		return class2074_0;
	}

	private void method_22(Class2074 _externalData)
	{
		class2074_0 = _externalData;
	}

	private Class1447 method_23()
	{
		if (class1461_0 != null)
		{
			throw new Exception("Only one <printSettings> element can be added.");
		}
		class1461_0 = new Class1461();
		return class1461_0;
	}

	private void method_24(Class1447 _printSettings)
	{
		class1461_0 = (Class1461)_printSettings;
	}

	private Class2108 method_25()
	{
		if (class2108_0 != null)
		{
			throw new Exception("Only one <userShapes> element can be added.");
		}
		class2108_0 = new Class2108();
		return class2108_0;
	}

	private void method_26(Class2108 _userShapes)
	{
		class2108_0 = _userShapes;
	}

	private Class1885 method_27()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_28(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
