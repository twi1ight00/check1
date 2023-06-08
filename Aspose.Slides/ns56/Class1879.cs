using System;
using System.Xml;

namespace ns56;

internal class Class1879 : Class1351
{
	public delegate Class1879 Delegate1516();

	public delegate void Delegate1517(Class1879 elementData);

	public delegate void Delegate1518(Class1879 elementData);

	public Class1825.Delegate1354 delegate1354_0;

	public Class1825.Delegate1356 delegate1356_0;

	public Class1822.Delegate1345 delegate1345_0;

	public Class1822.Delegate1347 delegate1347_0;

	public Class1822.Delegate1345 delegate1345_1;

	public Class1822.Delegate1347 delegate1347_1;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1825 class1825_0;

	private Class1822 class1822_0;

	private Class1822 class1822_1;

	private Class1886 class1886_0;

	public Class1825 CxnSpLocks => class1825_0;

	public Class1822 StCxn => class1822_0;

	public Class1822 EndCxn => class1822_1;

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
				case "extLst":
					class1886_0 = new Class1886(reader);
					break;
				case "endCxn":
					class1822_1 = new Class1822(reader);
					break;
				case "stCxn":
					class1822_0 = new Class1822(reader);
					break;
				case "cxnSpLocks":
					class1825_0 = new Class1825(reader);
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

	public Class1879(XmlReader reader)
		: base(reader)
	{
	}

	public Class1879()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1354_0 = method_3;
		delegate1356_0 = method_4;
		delegate1345_0 = method_5;
		delegate1347_0 = method_6;
		delegate1345_1 = method_7;
		delegate1347_1 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1825_0 != null)
		{
			class1825_0.vmethod_4("a", writer, "cxnSpLocks");
		}
		if (class1822_0 != null)
		{
			class1822_0.vmethod_4("a", writer, "stCxn");
		}
		if (class1822_1 != null)
		{
			class1822_1.vmethod_4("a", writer, "endCxn");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1825 method_3()
	{
		if (class1825_0 != null)
		{
			throw new Exception("Only one <cxnSpLocks> element can be added.");
		}
		class1825_0 = new Class1825();
		return class1825_0;
	}

	private void method_4(Class1825 _cxnSpLocks)
	{
		class1825_0 = _cxnSpLocks;
	}

	private Class1822 method_5()
	{
		if (class1822_0 != null)
		{
			throw new Exception("Only one <stCxn> element can be added.");
		}
		class1822_0 = new Class1822();
		return class1822_0;
	}

	private void method_6(Class1822 _stCxn)
	{
		class1822_0 = _stCxn;
	}

	private Class1822 method_7()
	{
		if (class1822_1 != null)
		{
			throw new Exception("Only one <endCxn> element can be added.");
		}
		class1822_1 = new Class1822();
		return class1822_1;
	}

	private void method_8(Class1822 _endCxn)
	{
		class1822_1 = _endCxn;
	}

	private Class1885 method_9()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
