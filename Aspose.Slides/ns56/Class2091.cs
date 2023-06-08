using System;
using System.Xml;

namespace ns56;

internal class Class2091 : Class1351
{
	public delegate Class2091 Delegate1991();

	public delegate void Delegate1993(Class2091 elementData);

	public delegate void Delegate1992(Class2091 elementData);

	public Class2093.Delegate1997 delegate1997_0;

	public Class2093.Delegate1999 delegate1999_0;

	public Class2092.Delegate1994 delegate1994_0;

	public Class2092.Delegate1996 delegate1996_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2093 class2093_0;

	private Class2092 class2092_0;

	private Class1921 class1921_0;

	private Class1887 class1887_0;

	public Class2093 Symbol => class2093_0;

	public Class2092 Size => class2092_0;

	public Class1921 SpPr => class1921_0;

	public Class1885 ExtLst => class1887_0;

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
				case "extLst":
					class1887_0 = new Class1887(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "size":
					class2092_0 = new Class2092(reader);
					break;
				case "symbol":
					class2093_0 = new Class2093(reader);
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

	public Class2091(XmlReader reader)
		: base(reader)
	{
	}

	public Class2091()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1997_0 = method_3;
		delegate1999_0 = method_4;
		delegate1994_0 = method_5;
		delegate1996_0 = method_6;
		delegate1630_0 = method_7;
		delegate1632_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2093_0 != null)
		{
			class2093_0.vmethod_4("c", writer, "symbol");
		}
		if (class2092_0 != null)
		{
			class2092_0.vmethod_4("c", writer, "size");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2093 method_3()
	{
		if (class2093_0 != null)
		{
			throw new Exception("Only one <symbol> element can be added.");
		}
		class2093_0 = new Class2093();
		return class2093_0;
	}

	private void method_4(Class2093 _symbol)
	{
		class2093_0 = _symbol;
	}

	private Class2092 method_5()
	{
		if (class2092_0 != null)
		{
			throw new Exception("Only one <size> element can be added.");
		}
		class2092_0 = new Class2092();
		return class2092_0;
	}

	private void method_6(Class2092 _size)
	{
		class2092_0 = _size;
	}

	private Class1921 method_7()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_8(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1885 method_9()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
