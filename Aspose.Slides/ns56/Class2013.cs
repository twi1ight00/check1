using System;
using System.Xml;

namespace ns56;

internal class Class2013 : Class2011
{
	public delegate void Delegate2313(Class2013 elementData);

	private string string_0;

	private Class2017 class2017_0;

	private Class1921 class1921_0;

	private Class1922 class1922_0;

	private Class1946 class1946_0;

	private Class1976 class1976_0;

	private Class1886 class1886_0;

	public override string ModelId
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public override Class2015 NvSpPr => class2017_0;

	public override Class1921 SpPr => class1921_0;

	public override Class1922 Style => class1922_0;

	public override Class1946 TxBody => class1946_0;

	public override Class1976 TxXfrm => class1976_0;

	public override Class1885 ExtLst => class1886_0;

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
				case "nvSpPr":
					class2017_0 = new Class2017(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "style":
					class1922_0 = new Class1922(reader);
					break;
				case "txBody":
					class1946_0 = new Class1946(reader);
					break;
				case "txXfrm":
					class1976_0 = new Class1976(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "modelId")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2013(XmlReader reader)
		: base(reader)
	{
	}

	public Class2013()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1633_0 = method_3;
		delegate1635_0 = method_4;
		delegate1705_0 = method_5;
		delegate1707_0 = method_6;
		delegate1795_0 = method_7;
		delegate1797_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
		class2017_0 = new Class2017();
		class1921_0 = new Class1921();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("modelId", string_0);
		class2017_0.vmethod_4("dsp", writer, "nvSpPr");
		class1921_0.vmethod_4("dsp", writer, "spPr");
		if (class1922_0 != null)
		{
			class1922_0.vmethod_4("dsp", writer, "style");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("dsp", writer, "txBody");
		}
		if (class1976_0 != null)
		{
			class1976_0.vmethod_4("dsp", writer, "txXfrm");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dsp", writer, "extLst");
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

	private Class1946 method_5()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txBody> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_6(Class1946 _txBody)
	{
		class1946_0 = _txBody;
	}

	private Class1976 method_7()
	{
		if (class1976_0 != null)
		{
			throw new Exception("Only one <txXfrm> element can be added.");
		}
		class1976_0 = new Class1976();
		return class1976_0;
	}

	private void method_8(Class1976 _txXfrm)
	{
		class1976_0 = _txXfrm;
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
