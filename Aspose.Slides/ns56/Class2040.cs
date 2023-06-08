using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2040 : Class2038
{
	public delegate void Delegate1873(Class2040 elementData);

	public Class2071.Delegate1928 delegate1928_0;

	public Class2129.Delegate2119 delegate2119_0;

	private Class2135 class2135_0;

	private Class2135 class2135_1;

	private Class2114 class2114_0;

	private Class1921 class1921_0;

	private Class2339 class2339_0;

	private Class1453 class1453_0;

	private List<Class2071> list_0;

	private Class2069 class2069_0;

	private List<Class2129> list_1;

	private Class2073 class2073_0;

	private Class2341 class2341_0;

	private Class2342 class2342_0;

	private Class2115 class2115_0;

	private Class1887 class1887_0;

	public override Class2135 Idx => class2135_0;

	public override Class2135 Order => class2135_1;

	public override Class2114 Tx => class2114_0;

	public override Class1921 SpPr => class1921_0;

	public override Class2339 InvertIfNegative => class2339_0;

	public override Class1453 PictureOptions => class1453_0;

	public override Class2071[] DPtList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

	public override Class2129[] TrendlineList => list_1.ToArray();

	public override Class2073 ErrBars => class2073_0;

	public override Class2341 Cat => class2341_0;

	public override Class2342 Val => class2342_0;

	public override Class2115 Shape => class2115_0;

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
				case "pictureOptions":
					class1453_0 = new Class1453(reader);
					flag = true;
					break;
				case "dPt":
				{
					Class2071 item2 = new Class2071(reader);
					list_0.Add(item2);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
					break;
				case "trendline":
				{
					Class2129 item = new Class2129(reader);
					list_1.Add(item);
					break;
				}
				case "errBars":
					class2073_0 = new Class2073(reader);
					break;
				case "cat":
					class2341_0 = new Class2341(reader);
					break;
				case "val":
					class2342_0 = new Class2342(reader);
					break;
				case "shape":
					class2115_0 = new Class2115(reader);
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

	public Class2040(XmlReader reader)
		: base(reader)
	{
	}

	public Class2040()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2071>();
		list_1 = new List<Class2129>();
	}

	protected override void vmethod_2()
	{
		delegate2069_0 = method_3;
		delegate2071_0 = method_4;
		delegate1630_0 = method_5;
		delegate1632_0 = method_6;
		delegate2763_1 = method_7;
		delegate2764_1 = method_8;
		delegate383_0 = method_9;
		delegate384_0 = method_10;
		delegate1927_0 = method_11;
		delegate1928_0 = method_12;
		delegate1920_0 = method_13;
		delegate1922_0 = method_14;
		delegate2118_0 = method_15;
		delegate2119_0 = method_16;
		delegate1933_0 = method_17;
		delegate1935_0 = method_18;
		delegate2765_0 = method_19;
		delegate2766_0 = method_20;
		delegate2767_0 = method_21;
		delegate2768_0 = method_22;
		delegate2072_0 = method_23;
		delegate2074_0 = method_24;
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
		if (class1453_0 != null)
		{
			class1453_0.vmethod_4("c", writer, "pictureOptions");
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
		if (class2073_0 != null)
		{
			class2073_0.vmethod_4("c", writer, "errBars");
		}
		if (class2341_0 != null)
		{
			class2341_0.vmethod_4("c", writer, "cat");
		}
		if (class2342_0 != null)
		{
			class2342_0.vmethod_4("c", writer, "val");
		}
		if (class2115_0 != null)
		{
			class2115_0.vmethod_4("c", writer, "shape");
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

	private Class1449 method_9()
	{
		if (class1453_0 != null)
		{
			throw new Exception("Only one <pictureOptions> element can be added.");
		}
		class1453_0 = new Class1453();
		return class1453_0;
	}

	private void method_10(Class1449 _pictureOptions)
	{
		class1453_0 = (Class1453)_pictureOptions;
	}

	private Class2071 method_11()
	{
		Class2071 @class = new Class2071();
		list_0.Add(@class);
		return @class;
	}

	private void method_12(Class2071 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2069 method_13()
	{
		if (class2069_0 != null)
		{
			throw new Exception("Only one <dLbls> element can be added.");
		}
		class2069_0 = new Class2069();
		return class2069_0;
	}

	private void method_14(Class2069 _dLbls)
	{
		class2069_0 = _dLbls;
	}

	private Class2129 method_15()
	{
		Class2129 @class = new Class2129();
		list_1.Add(@class);
		return @class;
	}

	private void method_16(Class2129 elementData)
	{
		list_1.Add(elementData);
	}

	private Class2073 method_17()
	{
		if (class2073_0 != null)
		{
			throw new Exception("Only one <errBars> element can be added.");
		}
		class2073_0 = new Class2073();
		return class2073_0;
	}

	private void method_18(Class2073 _errBars)
	{
		class2073_0 = _errBars;
	}

	private Class2341 method_19()
	{
		if (class2341_0 != null)
		{
			throw new Exception("Only one <cat> element can be added.");
		}
		class2341_0 = new Class2341();
		return class2341_0;
	}

	private void method_20(Class2341 _cat)
	{
		class2341_0 = _cat;
	}

	private Class2342 method_21()
	{
		if (class2342_0 != null)
		{
			throw new Exception("Only one <val> element can be added.");
		}
		class2342_0 = new Class2342();
		return class2342_0;
	}

	private void method_22(Class2342 _val)
	{
		class2342_0 = _val;
	}

	private Class2115 method_23()
	{
		if (class2115_0 != null)
		{
			throw new Exception("Only one <shape> element can be added.");
		}
		class2115_0 = new Class2115();
		return class2115_0;
	}

	private void method_24(Class2115 _shape)
	{
		class2115_0 = _shape;
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
