using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2037 : Class2021
{
	public delegate void Delegate2098(Class2037 elementData);

	public Class2046.Delegate2102 delegate2102_0;

	public Class1774.Delegate1202 delegate1202_0;

	private Class2339 class2339_0;

	private List<Class2046> list_0;

	private Class1458 class1458_0;

	private List<Class1774> list_1;

	private Class1887 class1887_0;

	public override Class2339 Wireframe => class2339_0;

	public override Class2038[] SerList => list_0.ToArray();

	public override Class1458 BandFmts => class1458_0;

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
				case "extLst":
					class1887_0 = new Class1887(reader);
					break;
				case "axId":
				{
					Class1774 item2 = new Class1774(reader);
					list_1.Add(item2);
					break;
				}
				case "bandFmts":
					class1458_0 = new Class1458(reader);
					flag = true;
					break;
				case "ser":
				{
					Class2046 item = new Class2046(reader);
					list_0.Add(item);
					break;
				}
				case "wireframe":
					class2339_0 = new Class2339(reader);
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

	public Class2037(XmlReader reader)
		: base(reader)
	{
	}

	public Class2037()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2046>();
		list_1 = new List<Class1774>();
	}

	protected override void vmethod_2()
	{
		delegate2763_2 = method_4;
		delegate2764_2 = method_5;
		delegate1856_0 = method_6;
		delegate2102_0 = method_7;
		delegate303_0 = method_8;
		delegate304_0 = method_9;
		delegate1201_0 = method_10;
		delegate1202_0 = method_11;
		delegate1534_0 = method_12;
		delegate1535_0 = method_13;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "wireframe");
		}
		foreach (Class2046 item in list_0)
		{
			item.vmethod_4("c", writer, "ser");
		}
		if (class1458_0 != null)
		{
			class1458_0.vmethod_4("c", writer, "bandFmts");
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

	private Class2339 method_4()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <wireframe> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_5(Class2339 _wireframe)
	{
		class2339_0 = _wireframe;
	}

	private Class2038 method_6()
	{
		Class2046 @class = new Class2046();
		list_0.Add(@class);
		return @class;
	}

	private void method_7(Class2046 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1447 method_8()
	{
		if (class1458_0 != null)
		{
			throw new Exception("Only one <bandFmts> element can be added.");
		}
		class1458_0 = new Class1458();
		return class1458_0;
	}

	private void method_9(Class1447 _bandFmts)
	{
		class1458_0 = (Class1458)_bandFmts;
	}

	private Class1774 method_10()
	{
		Class1774 @class = new Class1774();
		list_1.Add(@class);
		return @class;
	}

	private void method_11(Class1774 elementData)
	{
		list_1.Add(elementData);
	}

	private Class1885 method_12()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_13(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
