using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2035 : Class2021
{
	public delegate void Delegate2084(Class2035 elementData);

	public Class2042.Delegate1981 delegate1981_0;

	private List<Class2042> list_0;

	private Class2069 class2069_0;

	private Class2059 class2059_0;

	private Class2059 class2059_1;

	private Class2137 class2137_0;

	private List<Class1774> list_1;

	private Class1887 class1887_0;

	public override Class2038[] SerList => list_0.ToArray();

	public override Class2069 DLbls => class2069_0;

	public override Class2059 DropLines => class2059_0;

	public override Class2059 HiLowLines => class2059_1;

	public override Class2137 UpDownBars => class2137_0;

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
				case "ser":
				{
					Class2042 item2 = new Class2042(reader);
					list_0.Add(item2);
					break;
				}
				case "dLbls":
					class2069_0 = new Class2069(reader);
					break;
				case "dropLines":
					class2059_0 = new Class2059(reader);
					break;
				case "hiLowLines":
					class2059_1 = new Class2059(reader);
					break;
				case "upDownBars":
					class2137_0 = new Class2137(reader);
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

	public Class2035(XmlReader reader)
		: base(reader)
	{
	}

	public Class2035()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2042>();
		list_1 = new List<Class1774>();
	}

	protected override void vmethod_2()
	{
		delegate1856_0 = method_4;
		delegate1981_0 = method_5;
		delegate1920_0 = method_6;
		delegate1922_0 = method_7;
		delegate1889_0 = method_8;
		delegate1891_0 = method_9;
		delegate1889_1 = method_10;
		delegate1891_1 = method_11;
		delegate2142_0 = method_12;
		delegate2144_0 = method_13;
		delegate1534_0 = method_14;
		delegate1535_0 = method_15;
	}

	protected override void vmethod_3()
	{
		list_1.Add(new Class1774());
		list_1.Add(new Class1774());
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class2042 item in list_0)
		{
			item.vmethod_4("c", writer, "ser");
		}
		if (class2069_0 != null)
		{
			class2069_0.vmethod_4("c", writer, "dLbls");
		}
		if (class2059_0 != null)
		{
			class2059_0.vmethod_4("c", writer, "dropLines");
		}
		if (class2059_1 != null)
		{
			class2059_1.vmethod_4("c", writer, "hiLowLines");
		}
		if (class2137_0 != null)
		{
			class2137_0.vmethod_4("c", writer, "upDownBars");
		}
		AxId1.vmethod_4("c", writer, "axId");
		AxId2.vmethod_4("c", writer, "axId");
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2038 method_4()
	{
		Class2042 @class = new Class2042();
		list_0.Add(@class);
		return @class;
	}

	private void method_5(Class2042 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2069 method_6()
	{
		if (class2069_0 != null)
		{
			throw new Exception("Only one <dLbls> element can be added.");
		}
		class2069_0 = new Class2069();
		return class2069_0;
	}

	private void method_7(Class2069 _dLbls)
	{
		class2069_0 = _dLbls;
	}

	private Class2059 method_8()
	{
		if (class2059_0 != null)
		{
			throw new Exception("Only one <dropLines> element can be added.");
		}
		class2059_0 = new Class2059();
		return class2059_0;
	}

	private void method_9(Class2059 _dropLines)
	{
		class2059_0 = _dropLines;
	}

	private Class2059 method_10()
	{
		if (class2059_1 != null)
		{
			throw new Exception("Only one <hiLowLines> element can be added.");
		}
		class2059_1 = new Class2059();
		return class2059_1;
	}

	private void method_11(Class2059 _hiLowLines)
	{
		class2059_1 = _hiLowLines;
	}

	private Class2137 method_12()
	{
		if (class2137_0 != null)
		{
			throw new Exception("Only one <upDownBars> element can be added.");
		}
		class2137_0 = new Class2137();
		return class2137_0;
	}

	private void method_13(Class2137 _upDownBars)
	{
		class2137_0 = _upDownBars;
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
