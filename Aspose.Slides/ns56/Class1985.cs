using System;
using System.Xml;

namespace ns56;

internal class Class1985 : Class1983
{
	public delegate void Delegate2420(Class1985 elementData);

	private Class1988 class1988_0;

	private Class1921 class1921_0;

	private Class1922 class1922_0;

	private Class1889 class1889_0;

	public override Class1986 NvCxnSpPr => class1988_0;

	public override Class1921 SpPr => class1921_0;

	public override Class1922 Style => class1922_0;

	public override Class1885 ExtLst => class1889_0;

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
					class1889_0 = new Class1889(reader);
					break;
				case "style":
					class1922_0 = new Class1922(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "nvCxnSpPr":
					class1988_0 = new Class1988(reader);
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

	public Class1985(XmlReader reader)
		: base(reader)
	{
	}

	public Class1985()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1633_0 = method_3;
		delegate1635_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class1988_0 = new Class1988();
		class1921_0 = new Class1921();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1988_0.vmethod_4("p", writer, "nvCxnSpPr");
		class1921_0.vmethod_4("p", writer, "spPr");
		if (class1922_0 != null)
		{
			class1922_0.vmethod_4("p", writer, "style");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1922 method_3()
	{
		if (class1922_0 != null)
		{
			throw new Exception("Only one <style> element can be added.");
		}
		class1922_0 = new Class1922();
		return class1922_0;
	}

	private void method_4(Class1922 _style)
	{
		class1922_0 = _style;
	}

	private Class1885 method_5()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
