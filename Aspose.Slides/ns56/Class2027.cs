using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2027 : Class2021
{
	public delegate void Delegate1926(Class2027 elementData);

	public Class2043.Delegate2039 delegate2039_0;

	private Class2339 class2339_0;

	private List<Class2043> list_0;

	private Class2069 class2069_0;

	private Class2075 class2075_0;

	private Class2078 class2078_0;

	private Class1887 class1887_0;

	public override Class2339 VaryColors => class2339_0;

	public override Class2038[] SerList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

	public override Class2075 FirstSliceAng => class2075_0;

	public override Class2078 HoleSize => class2078_0;

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
				case "varyColors":
					class2339_0 = new Class2339(reader);
					break;
				case "ser":
				{
					Class2043 item = new Class2043(reader);
					list_0.Add(item);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
					break;
				case "firstSliceAng":
					class2075_0 = new Class2075(reader);
					break;
				case "holeSize":
					class2078_0 = new Class2078(reader);
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

	private void method_3(XmlReader reader)
	{
	}

	public Class2027(XmlReader reader)
		: base(reader)
	{
	}

	public Class2027()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2043>();
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_4;
		delegate2764_0 = method_5;
		delegate1856_0 = method_6;
		delegate2039_0 = method_7;
		delegate1920_0 = method_8;
		delegate1922_0 = method_9;
		delegate1940_0 = method_10;
		delegate1942_0 = method_11;
		delegate1949_0 = method_12;
		delegate1951_0 = method_13;
		delegate1534_0 = method_14;
		delegate1535_0 = method_15;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
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
		if (class2075_0 != null)
		{
			class2075_0.vmethod_4("c", writer, "firstSliceAng");
		}
		if (class2078_0 != null)
		{
			class2078_0.vmethod_4("c", writer, "holeSize");
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

	private Class2075 method_10()
	{
		if (class2075_0 != null)
		{
			throw new Exception("Only one <firstSliceAng> element can be added.");
		}
		class2075_0 = new Class2075();
		return class2075_0;
	}

	private void method_11(Class2075 _firstSliceAng)
	{
		class2075_0 = _firstSliceAng;
	}

	private Class2078 method_12()
	{
		if (class2078_0 != null)
		{
			throw new Exception("Only one <holeSize> element can be added.");
		}
		class2078_0 = new Class2078();
		return class2078_0;
	}

	private void method_13(Class2078 _holeSize)
	{
		class2078_0 = _holeSize;
	}

	private Class1885 method_14()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_15(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
