using System;
using System.Xml;

namespace ns56;

internal class Class1984 : Class1983
{
	public delegate void Delegate1818(Class1984 elementData);

	public const bool bool_0 = false;

	private string string_0;

	private bool bool_1;

	private Class1987 class1987_0;

	private Class1921 class1921_0;

	private Class1922 class1922_0;

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

	public override bool FPublished
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

	public override Class1986 NvCxnSpPr => class1987_0;

	public override Class1921 SpPr => class1921_0;

	public override Class1922 Style => class1922_0;

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
				case "style":
					class1922_0 = new Class1922(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "nvCxnSpPr":
					class1987_0 = new Class1987(reader);
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
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "macro":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1984(XmlReader reader)
		: base(reader)
	{
	}

	public Class1984()
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
	}

	protected override void vmethod_3()
	{
		class1987_0 = new Class1987();
		class1921_0 = new Class1921();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("macro", string_0);
		}
		if (bool_1)
		{
			writer.WriteAttributeString("fPublished", bool_1 ? "1" : "0");
		}
		class1987_0.vmethod_4("cdr", writer, "nvCxnSpPr");
		class1921_0.vmethod_4("cdr", writer, "spPr");
		if (class1922_0 != null)
		{
			class1922_0.vmethod_4("cdr", writer, "style");
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
}
