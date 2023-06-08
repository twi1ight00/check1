using System.Xml;

namespace ns56;

internal class Class1990 : Class1989
{
	public delegate void Delegate1824(Class1990 elementData);

	public const bool bool_0 = false;

	private string string_0;

	private bool bool_1;

	private Class1993 class1993_0;

	private Class1976 class1976_0;

	private Class2346 class2346_0;

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

	public override Class1992 NvGraphicFramePr => class1993_0;

	public override Class1976 Xfrm => class1976_0;

	public override Class2346 Graphic => class2346_0;

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
				case "graphic":
					class2346_0 = new Class2346(reader);
					break;
				case "xfrm":
					class1976_0 = new Class1976(reader);
					break;
				case "nvGraphicFramePr":
					class1993_0 = new Class1993(reader);
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

	public Class1990(XmlReader reader)
		: base(reader)
	{
	}

	public Class1990()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class1993_0 = new Class1993();
		class1976_0 = new Class1976();
		class2346_0 = new Class2346();
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
		class1993_0.vmethod_4("cdr", writer, "nvGraphicFramePr");
		class1976_0.vmethod_4("cdr", writer, "xfrm");
		class2346_0.vmethod_4("a", writer, "graphic");
		writer.WriteEndElement();
	}
}
