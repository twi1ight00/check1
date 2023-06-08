using System;
using System.Xml;

namespace ns56;

internal class Class1933 : Class1351
{
	public delegate Class1933 Delegate1666();

	public delegate void Delegate1667(Class1933 elementData);

	public delegate void Delegate1668(Class1933 elementData);

	public Class1973.Delegate1786 delegate1786_0;

	public Class1973.Delegate1788 delegate1788_0;

	public Class1973.Delegate1786 delegate1786_1;

	public Class1973.Delegate1788 delegate1788_1;

	public Class1973.Delegate1786 delegate1786_2;

	public Class1973.Delegate1788 delegate1788_2;

	public Class1973.Delegate1786 delegate1786_3;

	public Class1973.Delegate1788 delegate1788_3;

	public Class1973.Delegate1786 delegate1786_4;

	public Class1973.Delegate1788 delegate1788_4;

	public Class1973.Delegate1786 delegate1786_5;

	public Class1973.Delegate1788 delegate1788_5;

	public Class1973.Delegate1786 delegate1786_6;

	public Class1973.Delegate1788 delegate1788_6;

	public Class1973.Delegate1786 delegate1786_7;

	public Class1973.Delegate1788 delegate1788_7;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1973 class1973_0;

	private Class1973 class1973_1;

	private Class1973 class1973_2;

	private Class1973 class1973_3;

	private Class1973 class1973_4;

	private Class1973 class1973_5;

	private Class1973 class1973_6;

	private Class1973 class1973_7;

	private Class1886 class1886_0;

	public Class1973 Left => class1973_0;

	public Class1973 Right => class1973_1;

	public Class1973 Top => class1973_2;

	public Class1973 Bottom => class1973_3;

	public Class1973 InsideH => class1973_4;

	public Class1973 InsideV => class1973_5;

	public Class1973 Tl2br => class1973_6;

	public Class1973 Tr2bl => class1973_7;

	public Class1885 ExtLst => class1886_0;

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
				case "left":
					class1973_0 = new Class1973(reader);
					break;
				case "right":
					class1973_1 = new Class1973(reader);
					break;
				case "top":
					class1973_2 = new Class1973(reader);
					break;
				case "bottom":
					class1973_3 = new Class1973(reader);
					break;
				case "insideH":
					class1973_4 = new Class1973(reader);
					break;
				case "insideV":
					class1973_5 = new Class1973(reader);
					break;
				case "tl2br":
					class1973_6 = new Class1973(reader);
					break;
				case "tr2bl":
					class1973_7 = new Class1973(reader);
					break;
				case "extLst":
					class1886_0 = new Class1886(reader);
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

	public Class1933(XmlReader reader)
		: base(reader)
	{
	}

	public Class1933()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1786_0 = method_3;
		delegate1788_0 = method_4;
		delegate1786_1 = method_5;
		delegate1788_1 = method_6;
		delegate1786_2 = method_7;
		delegate1788_2 = method_8;
		delegate1786_3 = method_9;
		delegate1788_3 = method_10;
		delegate1786_4 = method_11;
		delegate1788_4 = method_12;
		delegate1786_5 = method_13;
		delegate1788_5 = method_14;
		delegate1786_6 = method_15;
		delegate1788_6 = method_16;
		delegate1786_7 = method_17;
		delegate1788_7 = method_18;
		delegate1534_0 = method_19;
		delegate1535_0 = method_20;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1973_0 != null)
		{
			class1973_0.vmethod_4("a", writer, "left");
		}
		if (class1973_1 != null)
		{
			class1973_1.vmethod_4("a", writer, "right");
		}
		if (class1973_2 != null)
		{
			class1973_2.vmethod_4("a", writer, "top");
		}
		if (class1973_3 != null)
		{
			class1973_3.vmethod_4("a", writer, "bottom");
		}
		if (class1973_4 != null)
		{
			class1973_4.vmethod_4("a", writer, "insideH");
		}
		if (class1973_5 != null)
		{
			class1973_5.vmethod_4("a", writer, "insideV");
		}
		if (class1973_6 != null)
		{
			class1973_6.vmethod_4("a", writer, "tl2br");
		}
		if (class1973_7 != null)
		{
			class1973_7.vmethod_4("a", writer, "tr2bl");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1973 method_3()
	{
		if (class1973_0 != null)
		{
			throw new Exception("Only one <left> element can be added.");
		}
		class1973_0 = new Class1973();
		return class1973_0;
	}

	private void method_4(Class1973 _left)
	{
		class1973_0 = _left;
	}

	private Class1973 method_5()
	{
		if (class1973_1 != null)
		{
			throw new Exception("Only one <right> element can be added.");
		}
		class1973_1 = new Class1973();
		return class1973_1;
	}

	private void method_6(Class1973 _right)
	{
		class1973_1 = _right;
	}

	private Class1973 method_7()
	{
		if (class1973_2 != null)
		{
			throw new Exception("Only one <top> element can be added.");
		}
		class1973_2 = new Class1973();
		return class1973_2;
	}

	private void method_8(Class1973 _top)
	{
		class1973_2 = _top;
	}

	private Class1973 method_9()
	{
		if (class1973_3 != null)
		{
			throw new Exception("Only one <bottom> element can be added.");
		}
		class1973_3 = new Class1973();
		return class1973_3;
	}

	private void method_10(Class1973 _bottom)
	{
		class1973_3 = _bottom;
	}

	private Class1973 method_11()
	{
		if (class1973_4 != null)
		{
			throw new Exception("Only one <insideH> element can be added.");
		}
		class1973_4 = new Class1973();
		return class1973_4;
	}

	private void method_12(Class1973 _insideH)
	{
		class1973_4 = _insideH;
	}

	private Class1973 method_13()
	{
		if (class1973_5 != null)
		{
			throw new Exception("Only one <insideV> element can be added.");
		}
		class1973_5 = new Class1973();
		return class1973_5;
	}

	private void method_14(Class1973 _insideV)
	{
		class1973_5 = _insideV;
	}

	private Class1973 method_15()
	{
		if (class1973_6 != null)
		{
			throw new Exception("Only one <tl2br> element can be added.");
		}
		class1973_6 = new Class1973();
		return class1973_6;
	}

	private void method_16(Class1973 _tl2br)
	{
		class1973_6 = _tl2br;
	}

	private Class1973 method_17()
	{
		if (class1973_7 != null)
		{
			throw new Exception("Only one <tr2bl> element can be added.");
		}
		class1973_7 = new Class1973();
		return class1973_7;
	}

	private void method_18(Class1973 _tr2bl)
	{
		class1973_7 = _tr2bl;
	}

	private Class1885 method_19()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_20(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
