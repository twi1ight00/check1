using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2024 : Class2021
{
	public delegate void Delegate1865(Class2024 elementData);

	public Class2050.Delegate1870 delegate1870_0;

	public Class2050.Delegate1872 delegate1872_0;

	public Class2040.Delegate1873 delegate1873_0;

	public Class1774.Delegate1202 delegate1202_0;

	private Class2049 class2049_0;

	private Class2050 class2050_0;

	private Class2339 class2339_0;

	private List<Class2040> list_0;

	private Class2069 class2069_0;

	private Class2076 class2076_0;

	private Class2076 class2076_1;

	private Class2115 class2115_0;

	private List<Class1774> list_1;

	private Class1887 class1887_0;

	public override Class2049 BarDir => class2049_0;

	public Class2050 Grouping => class2050_0;

	public override Class2339 VaryColors => class2339_0;

	public override Class2038[] SerList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

	public override Class2076 GapWidth => class2076_0;

	public override Class2076 GapDepth => class2076_1;

	public override Class2115 Shape => class2115_0;

	public override Class1774[] AxIdList => list_1.ToArray();

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
				case "barDir":
					class2049_0 = new Class2049(reader);
					break;
				case "grouping":
					class2050_0 = new Class2050(reader);
					break;
				case "varyColors":
					class2339_0 = new Class2339(reader);
					break;
				case "ser":
				{
					Class2040 item2 = new Class2040(reader);
					list_0.Add(item2);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
					break;
				case "gapWidth":
					class2076_0 = new Class2076(reader);
					break;
				case "gapDepth":
					class2076_1 = new Class2076(reader);
					break;
				case "shape":
					class2115_0 = new Class2115(reader);
					break;
				case "axId":
				{
					Class1774 item = new Class1774(reader);
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

	public Class2024(XmlReader reader)
		: base(reader)
	{
	}

	public Class2024()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2040>();
		list_1 = new List<Class1774>();
	}

	protected override void vmethod_2()
	{
		delegate1870_0 = method_4;
		delegate1872_0 = method_5;
		delegate2763_0 = method_6;
		delegate2764_0 = method_7;
		delegate1856_0 = method_8;
		delegate1873_0 = method_9;
		delegate1920_0 = method_10;
		delegate1922_0 = method_11;
		delegate1943_1 = method_12;
		delegate1945_1 = method_13;
		delegate1943_0 = method_14;
		delegate1945_0 = method_15;
		delegate2072_0 = method_16;
		delegate2074_0 = method_17;
		delegate1201_0 = method_18;
		delegate1202_0 = method_19;
		delegate1534_0 = method_20;
		delegate1535_0 = method_21;
	}

	protected override void vmethod_3()
	{
		class2049_0 = new Class2049();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2049_0.vmethod_4("c", writer, "barDir");
		if (class2050_0 != null)
		{
			class2050_0.vmethod_4("c", writer, "grouping");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "varyColors");
		}
		foreach (Class2040 item in list_0)
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
		if (class2076_1 != null)
		{
			class2076_1.vmethod_4("c", writer, "gapDepth");
		}
		if (class2115_0 != null)
		{
			class2115_0.vmethod_4("c", writer, "shape");
		}
		foreach (Class1774 item2 in list_1)
		{
			item2.vmethod_4("c", writer, "axId");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2050 method_4()
	{
		if (class2050_0 != null)
		{
			throw new Exception("Only one <grouping> element can be added.");
		}
		class2050_0 = new Class2050();
		return class2050_0;
	}

	private void method_5(Class2050 _grouping)
	{
		class2050_0 = _grouping;
	}

	private Class2339 method_6()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <varyColors> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_7(Class2339 _varyColors)
	{
		class2339_0 = _varyColors;
	}

	private Class2038 method_8()
	{
		Class2040 @class = new Class2040();
		list_0.Add(@class);
		return @class;
	}

	private void method_9(Class2040 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2069 method_10()
	{
		if (class2069_0 != null)
		{
			throw new Exception("Only one <dLbls> element can be added.");
		}
		class2069_0 = new Class2069();
		return class2069_0;
	}

	private void method_11(Class2069 _dLbls)
	{
		class2069_0 = _dLbls;
	}

	private Class2076 method_12()
	{
		if (class2076_0 != null)
		{
			throw new Exception("Only one <gapWidth> element can be added.");
		}
		class2076_0 = new Class2076();
		return class2076_0;
	}

	private void method_13(Class2076 _gapWidth)
	{
		class2076_0 = _gapWidth;
	}

	private Class2076 method_14()
	{
		if (class2076_1 != null)
		{
			throw new Exception("Only one <gapDepth> element can be added.");
		}
		class2076_1 = new Class2076();
		return class2076_1;
	}

	private void method_15(Class2076 _gapDepth)
	{
		class2076_1 = _gapDepth;
	}

	private Class2115 method_16()
	{
		if (class2115_0 != null)
		{
			throw new Exception("Only one <shape> element can be added.");
		}
		class2115_0 = new Class2115();
		return class2115_0;
	}

	private void method_17(Class2115 _shape)
	{
		class2115_0 = _shape;
	}

	private Class1774 method_18()
	{
		Class1774 @class = new Class1774();
		list_1.Add(@class);
		return @class;
	}

	private void method_19(Class1774 elementData)
	{
		list_1.Add(elementData);
	}

	private Class1885 method_20()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_21(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
