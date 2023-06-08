using System;
using System.Xml;

namespace ns56;

internal class Class2246 : Class1351
{
	public delegate Class2246 Delegate2482();

	public delegate void Delegate2483(Class2246 elementData);

	public Class2248.Delegate2487 delegate2487_0;

	public Class2248.Delegate2489 delegate2489_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1463 class1463_0;

	private Class2248 class2248_0;

	private Class1888 class1888_0;

	public Class1463 CViewPr => class1463_0;

	public Class2248 SldLst => class2248_0;

	public Class1888 ExtLst => class1888_0;

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
					class1888_0 = new Class1888(reader);
					break;
				case "sldLst":
					class2248_0 = new Class2248(reader);
					break;
				case "cViewPr":
					class1463_0 = new Class1463(reader);
					flag = true;
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

	public Class2246(XmlReader reader)
		: base(reader)
	{
	}

	public Class2246()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2487_0 = method_3;
		delegate2489_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class1463_0 = new Class1463();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1463_0.vmethod_4("p", writer, "cViewPr");
		if (class2248_0 != null)
		{
			class2248_0.vmethod_4("p", writer, "sldLst");
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2248 method_3()
	{
		if (class2248_0 != null)
		{
			throw new Exception("Only one <sldLst> element can be added.");
		}
		class2248_0 = new Class2248();
		return class2248_0;
	}

	private void method_4(Class2248 _sldLst)
	{
		class2248_0 = _sldLst;
	}

	private Class1885 method_5()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}
}
