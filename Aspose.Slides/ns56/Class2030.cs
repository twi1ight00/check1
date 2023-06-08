using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2030 : Class2021
{
	public delegate void Delegate2018(Class2030 elementData);

	public Class2043.Delegate2039 delegate2039_0;

	public Class2059.Delegate1890 delegate1890_0;

	private Class2100 class2100_0;

	private Class2339 class2339_0;

	private List<Class2043> list_0;

	private Class2069 class2069_0;

	private Class2076 class2076_0;

	private Class2118 class2118_0;

	private Class2070 class2070_0;

	private Class2062 class2062_0;

	private Class2113 class2113_0;

	private List<Class2059> list_1;

	private Class1887 class1887_0;

	public override Class2100 OfPieType => class2100_0;

	public override Class2339 VaryColors => class2339_0;

	public override Class2038[] SerList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

	public override Class2076 GapWidth => class2076_0;

	public override Class2118 SplitType => class2118_0;

	public override Class2070 SplitPos => class2070_0;

	public override Class2062 CustSplit => class2062_0;

	public override Class2113 SecondPieSize => class2113_0;

	public override Class2059[] SerLinesList => list_1.ToArray();

	public override Class1885 ExtLst => class1887_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_3(reader);
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
				case "ofPieType":
					class2100_0 = new Class2100(reader);
					break;
				case "varyColors":
					class2339_0 = new Class2339(reader);
					break;
				case "ser":
				{
					Class2043 item2 = new Class2043(reader);
					list_0.Add(item2);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
					break;
				case "gapWidth":
					class2076_0 = new Class2076(reader);
					break;
				case "splitType":
					class2118_0 = new Class2118(reader);
					break;
				case "splitPos":
					class2070_0 = new Class2070(reader);
					break;
				case "custSplit":
					class2062_0 = new Class2062(reader);
					break;
				case "secondPieSize":
					class2113_0 = new Class2113(reader);
					break;
				case "serLines":
				{
					Class2059 item = new Class2059(reader);
					list_1.Add(item);
					break;
				}
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

	private void method_3(XmlReader reader)
	{
	}

	public Class2030(XmlReader reader)
		: base(reader)
	{
	}

	public Class2030()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2043>();
		list_1 = new List<Class2059>();
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_4;
		delegate2764_0 = method_5;
		delegate1856_0 = method_6;
		delegate2039_0 = method_7;
		delegate1920_0 = method_8;
		delegate1922_0 = method_9;
		delegate1943_1 = method_10;
		delegate1945_1 = method_11;
		delegate2081_0 = method_12;
		delegate2083_0 = method_13;
		delegate1923_0 = method_14;
		delegate1925_0 = method_15;
		delegate1898_0 = method_16;
		delegate1900_0 = method_17;
		delegate2065_0 = method_18;
		delegate2067_0 = method_19;
		delegate1889_2 = method_20;
		delegate1890_0 = method_21;
		delegate1534_0 = method_22;
		delegate1535_0 = method_23;
	}

	protected override void vmethod_3()
	{
		class2100_0 = new Class2100();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2100_0.vmethod_4("c", writer, "ofPieType");
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "varyColors");
		}
		foreach (Class2043 item in list_0)
		{
			item.vmethod_4("c", writer, "ser");
		}
		if (class2069_0 != null)
		{
			class2069_0.vmethod_4("c", writer, "dLbls");
		}
		if (class2076_0 != null)
		{
			class2076_0.vmethod_4("c", writer, "gapWidth");
		}
		if (class2118_0 != null)
		{
			class2118_0.vmethod_4("c", writer, "splitType");
		}
		if (class2070_0 != null)
		{
			class2070_0.vmethod_4("c", writer, "splitPos");
		}
		if (class2062_0 != null)
		{
			class2062_0.vmethod_4("c", writer, "custSplit");
		}
		if (class2113_0 != null)
		{
			class2113_0.vmethod_4("c", writer, "secondPieSize");
		}
		foreach (Class2059 item2 in list_1)
		{
			item2.vmethod_4("c", writer, "serLines");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2339 method_4()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <varyColors> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_5(Class2339 _varyColors)
	{
		class2339_0 = _varyColors;
	}

	private Class2038 method_6()
	{
		Class2043 @class = new Class2043();
		list_0.Add(@class);
		return @class;
	}

	private void method_7(Class2043 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2069 method_8()
	{
		if (class2069_0 != null)
		{
			throw new Exception("Only one <dLbls> element can be added.");
		}
		class2069_0 = new Class2069();
		return class2069_0;
	}

	private void method_9(Class2069 _dLbls)
	{
		class2069_0 = _dLbls;
	}

	private Class2076 method_10()
	{
		if (class2076_0 != null)
		{
			throw new Exception("Only one <gapWidth> element can be added.");
		}
		class2076_0 = new Class2076();
		return class2076_0;
	}

	private void method_11(Class2076 _gapWidth)
	{
		class2076_0 = _gapWidth;
	}

	private Class2118 method_12()
	{
		if (class2118_0 != null)
		{
			throw new Exception("Only one <splitType> element can be added.");
		}
		class2118_0 = new Class2118();
		return class2118_0;
	}

	private void method_13(Class2118 _splitType)
	{
		class2118_0 = _splitType;
	}

	private Class2070 method_14()
	{
		if (class2070_0 != null)
		{
			throw new Exception("Only one <splitPos> element can be added.");
		}
		class2070_0 = new Class2070();
		return class2070_0;
	}

	private void method_15(Class2070 _splitPos)
	{
		class2070_0 = _splitPos;
	}

	private Class2062 method_16()
	{
		if (class2062_0 != null)
		{
			throw new Exception("Only one <custSplit> element can be added.");
		}
		class2062_0 = new Class2062();
		return class2062_0;
	}

	private void method_17(Class2062 _custSplit)
	{
		class2062_0 = _custSplit;
	}

	private Class2113 method_18()
	{
		if (class2113_0 != null)
		{
			throw new Exception("Only one <secondPieSize> element can be added.");
		}
		class2113_0 = new Class2113();
		return class2113_0;
	}

	private void method_19(Class2113 _secondPieSize)
	{
		class2113_0 = _secondPieSize;
	}

	private Class2059 method_20()
	{
		Class2059 @class = new Class2059();
		list_1.Add(@class);
		return @class;
	}

	private void method_21(Class2059 elementData)
	{
		list_1.Add(elementData);
	}

	private Class1885 method_22()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_23(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
