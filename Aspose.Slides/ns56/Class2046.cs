using System;
using System.Xml;

namespace ns56;

internal class Class2046 : Class2038
{
	public delegate void Delegate2102(Class2046 elementData);

	private Class2135 class2135_0;

	private Class2135 class2135_1;

	private Class2114 class2114_0;

	private Class1921 class1921_0;

	private Class2341 class2341_0;

	private Class2342 class2342_0;

	private Class1887 class1887_0;

	public override Class2135 Idx => class2135_0;

	public override Class2135 Order => class2135_1;

	public override Class2114 Tx => class2114_0;

	public override Class1921 SpPr => class1921_0;

	public override Class2341 Cat => class2341_0;

	public override Class2342 Val => class2342_0;

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
				case "cat":
					class2341_0 = new Class2341(reader);
					break;
				case "val":
					class2342_0 = new Class2342(reader);
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

	public Class2046(XmlReader reader)
		: base(reader)
	{
	}

	public Class2046()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2069_0 = method_3;
		delegate2071_0 = method_4;
		delegate1630_0 = method_5;
		delegate1632_0 = method_6;
		delegate2765_0 = method_7;
		delegate2766_0 = method_8;
		delegate2767_0 = method_9;
		delegate2768_0 = method_10;
		delegate1534_0 = method_11;
		delegate1535_0 = method_12;
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
		if (class2341_0 != null)
		{
			class2341_0.vmethod_4("c", writer, "cat");
		}
		if (class2342_0 != null)
		{
			class2342_0.vmethod_4("c", writer, "val");
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

	private Class2341 method_7()
	{
		if (class2341_0 != null)
		{
			throw new Exception("Only one <cat> element can be added.");
		}
		class2341_0 = new Class2341();
		return class2341_0;
	}

	private void method_8(Class2341 _cat)
	{
		class2341_0 = _cat;
	}

	private Class2342 method_9()
	{
		if (class2342_0 != null)
		{
			throw new Exception("Only one <val> element can be added.");
		}
		class2342_0 = new Class2342();
		return class2342_0;
	}

	private void method_10(Class2342 _val)
	{
		class2342_0 = _val;
	}

	private Class1885 method_11()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_12(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
