using System;
using System.Xml;

namespace ns56;

internal class Class2012 : Class2011
{
	public delegate void Delegate1844(Class2012 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	private string string_0;

	private string string_1;

	private bool bool_2;

	private bool bool_3;

	private Class2016 class2016_0;

	private Class1921 class1921_0;

	private Class1922 class1922_0;

	private Class1946 class1946_0;

	public override string Macro
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

	public override string Textlink
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public override bool FLocksText
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public override bool FPublished
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public override Class2015 NvSpPr => class2016_0;

	public override Class1921 SpPr => class1921_0;

	public override Class1922 Style => class1922_0;

	public override Class1946 TxBody => class1946_0;

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
					class2016_0 = new Class2016(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "fPublished":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "fLocksText":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "textlink":
					string_1 = reader.Value;
					break;
				case "macro":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2012(XmlReader reader)
		: base(reader)
	{
	}

	public Class2012()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = true;
		bool_3 = false;
	}

	protected override void vmethod_2()
	{
		delegate1633_0 = method_3;
		delegate1635_0 = method_4;
		delegate1705_0 = method_5;
		delegate1707_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class2016_0 = new Class2016();
		class1921_0 = new Class1921();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("macro", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("textlink", string_1);
		}
		if (!bool_2)
		{
			writer.WriteAttributeString("fLocksText", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("fPublished", bool_3 ? "1" : "0");
		}
		class2016_0.vmethod_4("cdr", writer, "nvSpPr");
		class1921_0.vmethod_4("cdr", writer, "spPr");
		if (class1922_0 != null)
		{
			class1922_0.vmethod_4("cdr", writer, "style");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("cdr", writer, "txBody");
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
}
