using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2041 : Class2038
{
	public delegate void Delegate1878(Class2041 elementData);

	public Class2071.Delegate1928 delegate1928_0;

	public Class2129.Delegate2119 delegate2119_0;

	public Class2073.Delegate1934 delegate1934_0;

	private Class2135 class2135_0;

	private Class2135 class2135_1;

	private Class2114 class2114_0;

	private Class1921 class1921_0;

	private Class2339 class2339_0;

	private List<Class2071> list_0;

	private Class2069 class2069_0;

	private List<Class2129> list_1;

	private List<Class2073> list_2;

	private Class2341 class2341_0;

	private Class2342 class2342_0;

	private Class2342 class2342_1;

	private Class2339 class2339_1;

	private Class1887 class1887_0;

	public override Class2135 Idx => class2135_0;

	public override Class2135 Order => class2135_1;

	public override Class2114 Tx => class2114_0;

	public override Class1921 SpPr => class1921_0;

	public override Class2339 InvertIfNegative => class2339_0;

	public override Class2071[] DPtList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

	public override Class2129[] TrendlineList => list_1.ToArray();

	public override Class2073[] ErrBarsList => list_2.ToArray();

	public override Class2341 XVal => class2341_0;

	public override Class2342 YVal => class2342_0;

	public override Class2342 BubbleSize => class2342_1;

	public override Class2339 Bubble3D => class2339_1;

	public override Class1885 ExtLst => class1887_0;

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
				case "idx":
					class2135_0 = new Class2135(reader);
					break;
				case "order":
					class2135_1 = new Class2135(reader);
					break;
				case "tx":
					class2114_0 = new Class2114(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "invertIfNegative":
					class2339_0 = new Class2339(reader);
					break;
				case "dPt":
				{
					Class2071 item3 = new Class2071(reader);
					list_0.Add(item3);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
					break;
				case "trendline":
				{
					Class2129 item2 = new Class2129(reader);
					list_1.Add(item2);
					break;
				}
				case "errBars":
				{
					Class2073 item = new Class2073(reader);
					list_2.Add(item);
					break;
				}
				case "xVal":
					class2341_0 = new Class2341(reader);
					break;
				case "yVal":
					class2342_0 = new Class2342(reader);
					break;
				case "bubbleSize":
					class2342_1 = new Class2342(reader);
					break;
				case "bubble3D":
					class2339_1 = new Class2339(reader);
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

	public Class2041(XmlReader reader)
		: base(reader)
	{
	}

	public Class2041()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2071>();
		list_1 = new List<Class2129>();
		list_2 = new List<Class2073>();
	}

	protected override void vmethod_2()
	{
		delegate2069_0 = method_3;
		delegate2071_0 = method_4;
		delegate1630_0 = method_5;
		delegate1632_0 = method_6;
		delegate2763_1 = method_7;
		delegate2764_1 = method_8;
		delegate1927_0 = method_9;
		delegate1928_0 = method_10;
		delegate1920_0 = method_11;
		delegate1922_0 = method_12;
		delegate2118_0 = method_13;
		delegate2119_0 = method_14;
		delegate1933_0 = method_15;
		delegate1934_0 = method_16;
		delegate2765_1 = method_17;
		delegate2766_1 = method_18;
		delegate2767_1 = method_19;
		delegate2768_1 = method_20;
		delegate2767_2 = method_21;
		delegate2768_2 = method_22;
		delegate2763_2 = method_23;
		delegate2764_2 = method_24;
		delegate1534_0 = method_25;
		delegate1535_0 = method_26;
	}

	protected override void vmethod_3()
	{
		class2135_0 = new Class2135();
		class2135_1 = new Class2135();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2135_0.vmethod_4("c", writer, "idx");
		class2135_1.vmethod_4("c", writer, "order");
		if (class2114_0 != null)
		{
			class2114_0.vmethod_4("c", writer, "tx");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "invertIfNegative");
		}
		foreach (Class2071 item in list_0)
		{
			item.vmethod_4("c", writer, "dPt");
		}
		if (class2069_0 != null)
		{
			class2069_0.vmethod_4("c", writer, "dLbls");
		}
		foreach (Class2129 item2 in list_1)
		{
			item2.vmethod_4("c", writer, "trendline");
		}
		foreach (Class2073 item3 in list_2)
		{
			item3.vmethod_4("c", writer, "errBars");
		}
		if (class2341_0 != null)
		{
			class2341_0.vmethod_4("c", writer, "xVal");
		}
		if (class2342_0 != null)
		{
			class2342_0.vmethod_4("c", writer, "yVal");
		}
		if (class2342_1 != null)
		{
			class2342_1.vmethod_4("c", writer, "bubbleSize");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "bubble3D");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2114 method_3()
	{
		if (class2114_0 != null)
		{
			throw new Exception("Only one <tx> element can be added.");
		}
		class2114_0 = new Class2114();
		return class2114_0;
	}

	private void method_4(Class2114 _tx)
	{
		class2114_0 = _tx;
	}

	private Class1921 method_5()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_6(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class2339 method_7()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <invertIfNegative> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_8(Class2339 _invertIfNegative)
	{
		class2339_0 = _invertIfNegative;
	}

	private Class2071 method_9()
	{
		Class2071 @class = new Class2071();
		list_0.Add(@class);
		return @class;
	}

	private void method_10(Class2071 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2069 method_11()
	{
		if (class2069_0 != null)
		{
			throw new Exception("Only one <dLbls> element can be added.");
		}
		class2069_0 = new Class2069();
		return class2069_0;
	}

	private void method_12(Class2069 _dLbls)
	{
		class2069_0 = _dLbls;
	}

	private Class2129 method_13()
	{
		Class2129 @class = new Class2129();
		list_1.Add(@class);
		return @class;
	}

	private void method_14(Class2129 elementData)
	{
		list_1.Add(elementData);
	}

	private Class2073 method_15()
	{
		Class2073 @class = new Class2073();
		list_2.Add(@class);
		return @class;
	}

	private void method_16(Class2073 elementData)
	{
		list_2.Add(elementData);
	}

	private Class2341 method_17()
	{
		if (class2341_0 != null)
		{
			throw new Exception("Only one <xVal> element can be added.");
		}
		class2341_0 = new Class2341();
		return class2341_0;
	}

	private void method_18(Class2341 _xVal)
	{
		class2341_0 = _xVal;
	}

	private Class2342 method_19()
	{
		if (class2342_0 != null)
		{
			throw new Exception("Only one <yVal> element can be added.");
		}
		class2342_0 = new Class2342();
		return class2342_0;
	}

	private void method_20(Class2342 _yVal)
	{
		class2342_0 = _yVal;
	}

	private Class2342 method_21()
	{
		if (class2342_1 != null)
		{
			throw new Exception("Only one <bubbleSize> element can be added.");
		}
		class2342_1 = new Class2342();
		return class2342_1;
	}

	private void method_22(Class2342 _bubbleSize)
	{
		class2342_1 = _bubbleSize;
	}

	private Class2339 method_23()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <bubble3D> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_24(Class2339 _bubble3D)
	{
		class2339_1 = _bubble3D;
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
