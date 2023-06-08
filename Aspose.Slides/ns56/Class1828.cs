using System;
using System.Xml;

namespace ns56;

internal class Class1828 : Class1351
{
	public delegate Class1828 Delegate1363();

	public delegate void Delegate1364(Class1828 elementData);

	public delegate void Delegate1365(Class1828 elementData);

	public Class1850.Delegate1429 delegate1429_0;

	public Class1850.Delegate1431 delegate1431_0;

	public Class1850.Delegate1429 delegate1429_1;

	public Class1850.Delegate1431 delegate1431_1;

	public Class1783.Delegate1228 delegate1228_0;

	public Class1783.Delegate1230 delegate1230_0;

	public Class1824.Delegate1351 delegate1351_0;

	public Class1824.Delegate1353 delegate1353_0;

	public Class1851.Delegate1432 delegate1432_0;

	public Class1851.Delegate1434 delegate1434_0;

	private Class1850 class1850_0;

	private Class1850 class1850_1;

	private Class1783 class1783_0;

	private Class1824 class1824_0;

	private Class1851 class1851_0;

	private Class1896 class1896_0;

	public Class1850 AvLst => class1850_0;

	public Class1850 GdLst => class1850_1;

	public Class1783 AhLst => class1783_0;

	public Class1824 CxnLst => class1824_0;

	public Class1851 Rect => class1851_0;

	public Class1896 PathLst => class1896_0;

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
				case "avLst":
					class1850_0 = new Class1850(reader);
					break;
				case "gdLst":
					class1850_1 = new Class1850(reader);
					break;
				case "ahLst":
					class1783_0 = new Class1783(reader);
					break;
				case "cxnLst":
					class1824_0 = new Class1824(reader);
					break;
				case "rect":
					class1851_0 = new Class1851(reader);
					break;
				case "pathLst":
					class1896_0 = new Class1896(reader);
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

	public Class1828(XmlReader reader)
		: base(reader)
	{
	}

	public Class1828()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1429_0 = method_3;
		delegate1431_0 = method_4;
		delegate1429_1 = method_5;
		delegate1431_1 = method_6;
		delegate1228_0 = method_7;
		delegate1230_0 = method_8;
		delegate1351_0 = method_9;
		delegate1353_0 = method_10;
		delegate1432_0 = method_11;
		delegate1434_0 = method_12;
	}

	protected override void vmethod_3()
	{
		class1896_0 = new Class1896();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1850_0 != null)
		{
			class1850_0.vmethod_4("a", writer, "avLst");
		}
		if (class1850_1 != null)
		{
			class1850_1.vmethod_4("a", writer, "gdLst");
		}
		if (class1783_0 != null)
		{
			class1783_0.vmethod_4("a", writer, "ahLst");
		}
		if (class1824_0 != null)
		{
			class1824_0.vmethod_4("a", writer, "cxnLst");
		}
		if (class1851_0 != null)
		{
			class1851_0.vmethod_4("a", writer, "rect");
		}
		class1896_0.vmethod_4("a", writer, "pathLst");
		writer.WriteEndElement();
	}

	private Class1850 method_3()
	{
		if (class1850_0 != null)
		{
			throw new Exception("Only one <avLst> element can be added.");
		}
		class1850_0 = new Class1850();
		return class1850_0;
	}

	private void method_4(Class1850 _avLst)
	{
		class1850_0 = _avLst;
	}

	private Class1850 method_5()
	{
		if (class1850_1 != null)
		{
			throw new Exception("Only one <gdLst> element can be added.");
		}
		class1850_1 = new Class1850();
		return class1850_1;
	}

	private void method_6(Class1850 _gdLst)
	{
		class1850_1 = _gdLst;
	}

	private Class1783 method_7()
	{
		if (class1783_0 != null)
		{
			throw new Exception("Only one <ahLst> element can be added.");
		}
		class1783_0 = new Class1783();
		return class1783_0;
	}

	private void method_8(Class1783 _ahLst)
	{
		class1783_0 = _ahLst;
	}

	private Class1824 method_9()
	{
		if (class1824_0 != null)
		{
			throw new Exception("Only one <cxnLst> element can be added.");
		}
		class1824_0 = new Class1824();
		return class1824_0;
	}

	private void method_10(Class1824 _cxnLst)
	{
		class1824_0 = _cxnLst;
	}

	private Class1851 method_11()
	{
		if (class1851_0 != null)
		{
			throw new Exception("Only one <rect> element can be added.");
		}
		class1851_0 = new Class1851();
		return class1851_0;
	}

	private void method_12(Class1851 _rect)
	{
		class1851_0 = _rect;
	}
}
