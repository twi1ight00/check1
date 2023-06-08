using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2069 : Class1351
{
	public delegate Class2069 Delegate1920();

	public delegate void Delegate1922(Class2069 elementData);

	public delegate void Delegate1921(Class2069 elementData);

	public Class2067.Delegate1914 delegate1914_0;

	public Class2067.Delegate1915 delegate1915_0;

	public Class2097.Delegate2009 delegate2009_0;

	public Class2097.Delegate2011 delegate2011_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class2068.Delegate1917 delegate1917_0;

	public Class2068.Delegate1919 delegate1919_0;

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class2339.Delegate2763 delegate2763_1;

	public Class2339.Delegate2764 delegate2764_1;

	public Class2339.Delegate2763 delegate2763_2;

	public Class2339.Delegate2764 delegate2764_2;

	public Class2339.Delegate2763 delegate2763_3;

	public Class2339.Delegate2764 delegate2764_3;

	public Class2339.Delegate2763 delegate2763_4;

	public Class2339.Delegate2764 delegate2764_4;

	public Class2339.Delegate2763 delegate2763_5;

	public Class2339.Delegate2764 delegate2764_5;

	public Class2339.Delegate2763 delegate2763_6;

	public Class2339.Delegate2764 delegate2764_6;

	public Class2059.Delegate1889 delegate1889_0;

	public Class2059.Delegate1891 delegate1891_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	private List<Class2067> list_0;

	private Class2097 class2097_0;

	private Class1921 class1921_0;

	private Class1946 class1946_0;

	private Class2068 class2068_0;

	private Class2339 class2339_0;

	private Class2339 class2339_1;

	private Class2339 class2339_2;

	private Class2339 class2339_3;

	private Class2339 class2339_4;

	private Class2339 class2339_5;

	private string string_0;

	private Class2339 class2339_6;

	private Class2059 class2059_0;

	private Class2605 class2605_0;

	private Class1887 class1887_0;

	public Class2067[] DLblList => list_0.ToArray();

	public Class2097 NumFmt => class2097_0;

	public Class1921 SpPr => class1921_0;

	public Class1946 TxPr => class1946_0;

	public Class2068 DLblPos => class2068_0;

	public Class2339 ShowLegendKey => class2339_0;

	public Class2339 ShowVal => class2339_1;

	public Class2339 ShowCatName => class2339_2;

	public Class2339 ShowSerName => class2339_3;

	public Class2339 ShowPercent => class2339_4;

	public Class2339 ShowBubbleSize => class2339_5;

	public string Separator
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

	public Class2339 ShowLeaderLines => class2339_6;

	public Class2059 LeaderLines => class2059_0;

	public Class2605 Delete
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
		}
	}

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
			case "dLbl":
			{
				Class2067 item = new Class2067(reader);
				list_0.Add(item);
				break;
			}
			case "delete":
				class2605_0 = new Class2605("delete", new Class2339(reader));
				break;
			case "numFmt":
				class2097_0 = new Class2097(reader);
				break;
			case "spPr":
				class1921_0 = new Class1921(reader);
				break;
			case "txPr":
				class1946_0 = new Class1946(reader);
				break;
			case "dLblPos":
				class2068_0 = new Class2068(reader);
				break;
			case "showLegendKey":
				class2339_0 = new Class2339(reader);
				break;
			case "showVal":
				class2339_1 = new Class2339(reader);
				break;
			case "showCatName":
				class2339_2 = new Class2339(reader);
				break;
			case "showSerName":
				class2339_3 = new Class2339(reader);
				break;
			case "showPercent":
				class2339_4 = new Class2339(reader);
				break;
			case "showBubbleSize":
				class2339_5 = new Class2339(reader);
				break;
			case "separator":
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
			case "showLeaderLines":
				class2339_6 = new Class2339(reader);
				break;
			case "leaderLines":
				class2059_0 = new Class2059(reader);
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

	public Class2069(XmlReader reader)
		: base(reader)
	{
	}

	public Class2069()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2067>();
	}

	protected override void vmethod_2()
	{
		delegate1914_0 = method_3;
		delegate1915_0 = method_4;
		delegate2773_0 = method_31;
		delegate2009_0 = method_5;
		delegate2011_0 = method_6;
		delegate1630_0 = method_7;
		delegate1632_0 = method_8;
		delegate1705_0 = method_9;
		delegate1707_0 = method_10;
		delegate1917_0 = method_11;
		delegate1919_0 = method_12;
		delegate2763_0 = method_13;
		delegate2764_0 = method_14;
		delegate2763_1 = method_15;
		delegate2764_1 = method_16;
		delegate2763_2 = method_17;
		delegate2764_2 = method_18;
		delegate2763_3 = method_19;
		delegate2764_3 = method_20;
		delegate2763_4 = method_21;
		delegate2764_4 = method_22;
		delegate2763_5 = method_23;
		delegate2764_5 = method_24;
		delegate2763_6 = method_25;
		delegate2764_6 = method_26;
		delegate1889_0 = method_27;
		delegate1891_0 = method_28;
		delegate1534_0 = method_29;
		delegate1535_0 = method_30;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2067 item in list_0)
		{
			item.vmethod_4("c", writer, "dLbl");
		}
		string name;
		if (class2605_0 != null && (name = class2605_0.Name) != null && name == "delete")
		{
			((Class2339)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
		}
		if (class2097_0 != null)
		{
			class2097_0.vmethod_4("c", writer, "numFmt");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("c", writer, "txPr");
		}
		if (class2068_0 != null)
		{
			class2068_0.vmethod_4("c", writer, "dLblPos");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "showLegendKey");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "showVal");
		}
		if (class2339_2 != null)
		{
			class2339_2.vmethod_4("c", writer, "showCatName");
		}
		if (class2339_3 != null)
		{
			class2339_3.vmethod_4("c", writer, "showSerName");
		}
		if (class2339_4 != null)
		{
			class2339_4.vmethod_4("c", writer, "showPercent");
		}
		if (class2339_5 != null)
		{
			class2339_5.vmethod_4("c", writer, "showBubbleSize");
		}
		if (string_0 != null)
		{
			method_1("c", writer, "separator", string_0);
		}
		if (class2339_6 != null)
		{
			class2339_6.vmethod_4("c", writer, "showLeaderLines");
		}
		if (class2059_0 != null)
		{
			class2059_0.vmethod_4("c", writer, "leaderLines");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2067 method_3()
	{
		Class2067 @class = new Class2067();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2067 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2097 method_5()
	{
		if (class2097_0 != null)
		{
			throw new Exception("Only one <numFmt> element can be added.");
		}
		class2097_0 = new Class2097();
		return class2097_0;
	}

	private void method_6(Class2097 _numFmt)
	{
		class2097_0 = _numFmt;
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

	private Class1946 method_9()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txPr> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_10(Class1946 _txPr)
	{
		class1946_0 = _txPr;
	}

	private Class2068 method_11()
	{
		if (class2068_0 != null)
		{
			throw new Exception("Only one <dLblPos> element can be added.");
		}
		class2068_0 = new Class2068();
		return class2068_0;
	}

	private void method_12(Class2068 _dLblPos)
	{
		class2068_0 = _dLblPos;
	}

	private Class2339 method_13()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <showLegendKey> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_14(Class2339 _showLegendKey)
	{
		class2339_0 = _showLegendKey;
	}

	private Class2339 method_15()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <showVal> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_16(Class2339 _showVal)
	{
		class2339_1 = _showVal;
	}

	private Class2339 method_17()
	{
		if (class2339_2 != null)
		{
			throw new Exception("Only one <showCatName> element can be added.");
		}
		class2339_2 = new Class2339();
		return class2339_2;
	}

	private void method_18(Class2339 _showCatName)
	{
		class2339_2 = _showCatName;
	}

	private Class2339 method_19()
	{
		if (class2339_3 != null)
		{
			throw new Exception("Only one <showSerName> element can be added.");
		}
		class2339_3 = new Class2339();
		return class2339_3;
	}

	private void method_20(Class2339 _showSerName)
	{
		class2339_3 = _showSerName;
	}

	private Class2339 method_21()
	{
		if (class2339_4 != null)
		{
			throw new Exception("Only one <showPercent> element can be added.");
		}
		class2339_4 = new Class2339();
		return class2339_4;
	}

	private void method_22(Class2339 _showPercent)
	{
		class2339_4 = _showPercent;
	}

	private Class2339 method_23()
	{
		if (class2339_5 != null)
		{
			throw new Exception("Only one <showBubbleSize> element can be added.");
		}
		class2339_5 = new Class2339();
		return class2339_5;
	}

	private void method_24(Class2339 _showBubbleSize)
	{
		class2339_5 = _showBubbleSize;
	}

	private Class2339 method_25()
	{
		if (class2339_6 != null)
		{
			throw new Exception("Only one <showLeaderLines> element can be added.");
		}
		class2339_6 = new Class2339();
		return class2339_6;
	}

	private void method_26(Class2339 _showLeaderLines)
	{
		class2339_6 = _showLeaderLines;
	}

	private Class2059 method_27()
	{
		if (class2059_0 != null)
		{
			throw new Exception("Only one <leaderLines> element can be added.");
		}
		class2059_0 = new Class2059();
		return class2059_0;
	}

	private void method_28(Class2059 _leaderLines)
	{
		class2059_0 = _leaderLines;
	}

	private Class1885 method_29()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_30(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}

	private Class2605 method_31(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Delete already is initialized.");
		}
		string text;
		if ((text = elementName) == null || !(text == "delete"))
		{
			throw new Exception("Wrong element: " + elementName);
		}
		class2605_0 = new Class2605("delete", new Class2339());
		return class2605_0;
	}
}
