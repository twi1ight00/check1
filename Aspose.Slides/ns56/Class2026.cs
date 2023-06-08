using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2026 : Class2021
{
	public delegate void Delegate1874(Class2026 elementData);

	public Class2041.Delegate1878 delegate1878_0;

	private Class2339 class2339_0;

	private List<Class2041> list_0;

	private Class2069 class2069_0;

	private Class2339 class2339_1;

	private Class2051 class2051_0;

	private Class2339 class2339_2;

	private Class2116 class2116_0;

	private List<Class1774> list_1;

	private Class1887 class1887_0;

	public override Class2339 VaryColors => class2339_0;

	public override Class2038[] SerList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

	public override Class2339 Bubble3D => class2339_1;

	public override Class2051 BubbleScale => class2051_0;

	public override Class2339 ShowNegBubbles => class2339_2;

	public override Class2116 SizeRepresents => class2116_0;

	public override Class1774 AxId1 => list_1[0];

	public override Class1774 AxId2 => list_1[1];

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
					Class2041 item2 = new Class2041(reader);
					list_0.Add(item2);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
					break;
				case "bubble3D":
					class2339_1 = new Class2339(reader);
					break;
				case "bubbleScale":
					class2051_0 = new Class2051(reader);
					break;
				case "showNegBubbles":
					class2339_2 = new Class2339(reader);
					break;
				case "sizeRepresents":
					class2116_0 = new Class2116(reader);
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

	public Class2026(XmlReader reader)
		: base(reader)
	{
	}

	public Class2026()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2041>();
		list_1 = new List<Class1774>();
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_4;
		delegate2764_0 = method_5;
		delegate1856_0 = method_6;
		delegate1878_0 = method_7;
		delegate1920_0 = method_8;
		delegate1922_0 = method_9;
		delegate2763_4 = method_10;
		delegate2764_4 = method_11;
		delegate1875_0 = method_12;
		delegate1877_0 = method_13;
		delegate2763_1 = method_14;
		delegate2764_1 = method_15;
		delegate2075_0 = method_16;
		delegate2077_0 = method_17;
		delegate1534_0 = method_18;
		delegate1535_0 = method_19;
	}

	protected override void vmethod_3()
	{
		list_1.Add(new Class1774());
		list_1.Add(new Class1774());
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "varyColors");
		}
		foreach (Class2041 item in list_0)
		{
			item.vmethod_4("c", writer, "ser");
		}
		if (class2069_0 != null)
		{
			class2069_0.vmethod_4("c", writer, "dLbls");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "bubble3D");
		}
		if (class2051_0 != null)
		{
			class2051_0.vmethod_4("c", writer, "bubbleScale");
		}
		if (class2339_2 != null)
		{
			class2339_2.vmethod_4("c", writer, "showNegBubbles");
		}
		if (class2116_0 != null)
		{
			class2116_0.vmethod_4("c", writer, "sizeRepresents");
		}
		AxId1.vmethod_4("c", writer, "axId");
		AxId2.vmethod_4("c", writer, "axId");
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
		Class2041 @class = new Class2041();
		list_0.Add(@class);
		return @class;
	}

	private void method_7(Class2041 elementData)
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

	private Class2339 method_10()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <bubble3D> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_11(Class2339 _bubble3D)
	{
		class2339_1 = _bubble3D;
	}

	private Class2051 method_12()
	{
		if (class2051_0 != null)
		{
			throw new Exception("Only one <bubbleScale> element can be added.");
		}
		class2051_0 = new Class2051();
		return class2051_0;
	}

	private void method_13(Class2051 _bubbleScale)
	{
		class2051_0 = _bubbleScale;
	}

	private Class2339 method_14()
	{
		if (class2339_2 != null)
		{
			throw new Exception("Only one <showNegBubbles> element can be added.");
		}
		class2339_2 = new Class2339();
		return class2339_2;
	}

	private void method_15(Class2339 _showNegBubbles)
	{
		class2339_2 = _showNegBubbles;
	}

	private Class2116 method_16()
	{
		if (class2116_0 != null)
		{
			throw new Exception("Only one <sizeRepresents> element can be added.");
		}
		class2116_0 = new Class2116();
		return class2116_0;
	}

	private void method_17(Class2116 _sizeRepresents)
	{
		class2116_0 = _sizeRepresents;
	}

	private Class1885 method_18()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_19(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
