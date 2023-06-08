using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2106 : Class1351
{
	public delegate Class2106 Delegate2040();

	public delegate void Delegate2041(Class2106 elementData);

	public delegate void Delegate2042(Class2106 elementData);

	public Class2080.Delegate1955 delegate1955_0;

	public Class2080.Delegate1957 delegate1957_0;

	public Class2072.Delegate1930 delegate1930_0;

	public Class2072.Delegate1932 delegate1932_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	private Class2080 class2080_0;

	private List<Class2605> list_0;

	private List<Class2605> list_1;

	private Class2072 class2072_0;

	private Class1921 class1921_0;

	private Class1887 class1887_0;

	public Class2080 Layout => class2080_0;

	public Class2605[] ChartList => list_0.ToArray();

	public Class2605[] AxisList => list_1.ToArray();

	public Class2072 DTable => class2072_0;

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
				case "layout":
					class2080_0 = new Class2080(reader);
					break;
				case "areaChart":
				{
					Class2023 obj20 = new Class2023(reader);
					list_0.Add(new Class2605("areaChart", obj20));
					break;
				}
				case "area3DChart":
				{
					Class2022 obj19 = new Class2022(reader);
					list_0.Add(new Class2605("area3DChart", obj19));
					break;
				}
				case "lineChart":
				{
					Class2029 obj18 = new Class2029(reader);
					list_0.Add(new Class2605("lineChart", obj18));
					break;
				}
				case "line3DChart":
				{
					Class2028 obj17 = new Class2028(reader);
					list_0.Add(new Class2605("line3DChart", obj17));
					break;
				}
				case "stockChart":
				{
					Class2035 obj16 = new Class2035(reader);
					list_0.Add(new Class2605("stockChart", obj16));
					break;
				}
				case "radarChart":
				{
					Class2033 obj15 = new Class2033(reader);
					list_0.Add(new Class2605("radarChart", obj15));
					break;
				}
				case "scatterChart":
				{
					Class2034 obj14 = new Class2034(reader);
					list_0.Add(new Class2605("scatterChart", obj14));
					break;
				}
				case "pieChart":
				{
					Class2032 obj13 = new Class2032(reader);
					list_0.Add(new Class2605("pieChart", obj13));
					break;
				}
				case "pie3DChart":
				{
					Class2031 obj12 = new Class2031(reader);
					list_0.Add(new Class2605("pie3DChart", obj12));
					break;
				}
				case "doughnutChart":
				{
					Class2027 obj11 = new Class2027(reader);
					list_0.Add(new Class2605("doughnutChart", obj11));
					break;
				}
				case "barChart":
				{
					Class2025 obj10 = new Class2025(reader);
					list_0.Add(new Class2605("barChart", obj10));
					break;
				}
				case "bar3DChart":
				{
					Class2024 obj9 = new Class2024(reader);
					list_0.Add(new Class2605("bar3DChart", obj9));
					break;
				}
				case "ofPieChart":
				{
					Class2030 obj8 = new Class2030(reader);
					list_0.Add(new Class2605("ofPieChart", obj8));
					break;
				}
				case "surfaceChart":
				{
					Class2037 obj7 = new Class2037(reader);
					list_0.Add(new Class2605("surfaceChart", obj7));
					break;
				}
				case "surface3DChart":
				{
					Class2036 obj6 = new Class2036(reader);
					list_0.Add(new Class2605("surface3DChart", obj6));
					break;
				}
				case "bubbleChart":
				{
					Class2026 obj5 = new Class2026(reader);
					list_0.Add(new Class2605("bubbleChart", obj5));
					break;
				}
				case "valAx":
				{
					Class2057 obj4 = new Class2057(reader);
					list_1.Add(new Class2605("valAx", obj4));
					break;
				}
				case "catAx":
				{
					Class2054 obj3 = new Class2054(reader);
					list_1.Add(new Class2605("catAx", obj3));
					break;
				}
				case "dateAx":
				{
					Class2055 obj2 = new Class2055(reader);
					list_1.Add(new Class2605("dateAx", obj2));
					break;
				}
				case "serAx":
				{
					Class2056 obj = new Class2056(reader);
					list_1.Add(new Class2605("serAx", obj));
					break;
				}
				case "dTable":
					class2072_0 = new Class2072(reader);
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

	public Class2106(XmlReader reader)
		: base(reader)
	{
	}

	public Class2106()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2605>();
		list_1 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate1955_0 = method_3;
		delegate1957_0 = method_4;
		delegate2773_1 = method_13;
		delegate2773_0 = method_11;
		delegate1930_0 = method_5;
		delegate1932_0 = method_6;
		delegate1630_0 = method_7;
		delegate1632_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2080_0 != null)
		{
			class2080_0.vmethod_4("c", writer, "layout");
		}
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "areaChart":
				((Class2023)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "area3DChart":
				((Class2022)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "lineChart":
				((Class2029)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "line3DChart":
				((Class2028)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "stockChart":
				((Class2035)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "radarChart":
				((Class2033)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "scatterChart":
				((Class2034)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "pieChart":
				((Class2032)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "pie3DChart":
				((Class2031)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "doughnutChart":
				((Class2027)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "barChart":
				((Class2025)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "bar3DChart":
				((Class2024)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "ofPieChart":
				((Class2030)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "surfaceChart":
				((Class2037)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "surface3DChart":
				((Class2036)item.Object).vmethod_4("c", writer, item.Name);
				break;
			case "bubbleChart":
				((Class2026)item.Object).vmethod_4("c", writer, item.Name);
				break;
			}
		}
		foreach (Class2605 item2 in list_1)
		{
			switch (item2.Name)
			{
			case "serAx":
				((Class2056)item2.Object).vmethod_4("c", writer, item2.Name);
				break;
			case "dateAx":
				((Class2055)item2.Object).vmethod_4("c", writer, item2.Name);
				break;
			case "catAx":
				((Class2054)item2.Object).vmethod_4("c", writer, item2.Name);
				break;
			case "valAx":
				((Class2057)item2.Object).vmethod_4("c", writer, item2.Name);
				break;
			}
		}
		if (class2072_0 != null)
		{
			class2072_0.vmethod_4("c", writer, "dTable");
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

	private Class2080 method_3()
	{
		if (class2080_0 != null)
		{
			throw new Exception("Only one <layout> element can be added.");
		}
		class2080_0 = new Class2080();
		return class2080_0;
	}

	private void method_4(Class2080 _layout)
	{
		class2080_0 = _layout;
	}

	private Class2072 method_5()
	{
		if (class2072_0 != null)
		{
			throw new Exception("Only one <dTable> element can be added.");
		}
		class2072_0 = new Class2072();
		return class2072_0;
	}

	private void method_6(Class2072 _dTable)
	{
		class2072_0 = _dTable;
	}

	private Class1921 method_7()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_8(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1885 method_9()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}

	private Class2605 method_11(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"serAx" => new Class2605("serAx", new Class2056()), 
			"dateAx" => new Class2605("dateAx", new Class2055()), 
			"catAx" => new Class2605("catAx", new Class2054()), 
			"valAx" => new Class2605("valAx", new Class2057()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_1.Add(@class);
		return @class;
	}

	public void method_12(Class2605 obj)
	{
		list_1.Add(obj);
	}

	private Class2605 method_13(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"areaChart" => new Class2605("areaChart", new Class2023()), 
			"area3DChart" => new Class2605("area3DChart", new Class2022()), 
			"lineChart" => new Class2605("lineChart", new Class2029()), 
			"line3DChart" => new Class2605("line3DChart", new Class2028()), 
			"stockChart" => new Class2605("stockChart", new Class2035()), 
			"radarChart" => new Class2605("radarChart", new Class2033()), 
			"scatterChart" => new Class2605("scatterChart", new Class2034()), 
			"pieChart" => new Class2605("pieChart", new Class2032()), 
			"pie3DChart" => new Class2605("pie3DChart", new Class2031()), 
			"doughnutChart" => new Class2605("doughnutChart", new Class2027()), 
			"barChart" => new Class2605("barChart", new Class2025()), 
			"bar3DChart" => new Class2605("bar3DChart", new Class2024()), 
			"ofPieChart" => new Class2605("ofPieChart", new Class2030()), 
			"surfaceChart" => new Class2605("surfaceChart", new Class2037()), 
			"surface3DChart" => new Class2605("surface3DChart", new Class2036()), 
			"bubbleChart" => new Class2605("bubbleChart", new Class2026()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_14(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
