using System;
using System.Xml;

namespace ns56;

internal class Class2014 : Class2011
{
	public delegate void Delegate2495(Class2014 elementData);

	public const bool bool_0 = false;

	private bool bool_1;

	private Class2018 class2018_0;

	private Class1921 class1921_0;

	private Class1922 class1922_0;

	private Class1946 class1946_0;

	private Class1889 class1889_0;

	public override bool UseBgFill
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public override Class2015 NvSpPr => class2018_0;

	public override Class1921 SpPr => class1921_0;

	public override Class1922 Style => class1922_0;

	public override Class1946 TxBody => class1946_0;

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
				case "txBody":
					class1946_0 = new Class1946(reader);
					break;
				case "style":
					class1922_0 = new Class1922(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "nvSpPr":
					class2018_0 = new Class2018(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "useBgFill")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2014(XmlReader reader)
		: base(reader)
	{
	}

	public Class2014()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate1633_0 = method_3;
		delegate1635_0 = method_4;
		delegate1705_0 = method_5;
		delegate1707_0 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
		class2018_0 = new Class2018();
		class1921_0 = new Class1921();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("useBgFill", bool_1 ? "1" : "0");
		}
		class2018_0.vmethod_4("p", writer, "nvSpPr");
		class1921_0.vmethod_4("p", writer, "spPr");
		if (class1922_0 != null)
		{
			class1922_0.vmethod_4("p", writer, "style");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("p", writer, "txBody");
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

	private Class1885 method_7()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_8(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
