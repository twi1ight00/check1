using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2034 : Class2021
{
	public delegate void Delegate2060(Class2034 elementData);

	public Class2045.Delegate2061 delegate2061_0;

	private Class2112 class2112_0;

	private Class2339 class2339_0;

	private List<Class2045> list_0;

	private Class2069 class2069_0;

	private List<Class1774> list_1;

	private Class1887 class1887_0;

	public override Class2112 ScatterStyle => class2112_0;

	public override Class2339 VaryColors => class2339_0;

	public override Class2038[] SerList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

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
				case "scatterStyle":
					class2112_0 = new Class2112(reader);
					break;
				case "varyColors":
					class2339_0 = new Class2339(reader);
					break;
				case "ser":
				{
					Class2045 item2 = new Class2045(reader);
					list_0.Add(item2);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
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

	public Class2034(XmlReader reader)
		: base(reader)
	{
	}

	public Class2034()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2045>();
		list_1 = new List<Class1774>();
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_4;
		delegate2764_0 = method_5;
		delegate1856_0 = method_6;
		delegate2061_0 = method_7;
		delegate1920_0 = method_8;
		delegate1922_0 = method_9;
		delegate1534_0 = method_10;
		delegate1535_0 = method_11;
	}

	protected override void vmethod_3()
	{
		class2112_0 = new Class2112();
		list_1.Add(new Class1774());
		list_1.Add(new Class1774());
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2112_0.vmethod_4("c", writer, "scatterStyle");
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "varyColors");
		}
		foreach (Class2045 item in list_0)
		{
			item.vmethod_4("c", writer, "ser");
		}
		if (class2069_0 != null)
		{
			class2069_0.vmethod_4("c", writer, "dLbls");
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
		Class2045 @class = new Class2045();
		list_0.Add(@class);
		return @class;
	}

	private void method_7(Class2045 elementData)
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

	private Class1885 method_10()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_11(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
