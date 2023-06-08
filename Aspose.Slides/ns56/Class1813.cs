using System.Xml;

namespace ns56;

internal class Class1813 : Class1351
{
	public delegate Class1813 Delegate1318();

	public delegate void Delegate1319(Class1813 elementData);

	public delegate void Delegate1320(Class1813 elementData);

	public const bool bool_0 = true;

	private bool bool_1;

	private Class1814 class1814_0;

	private Class1814 class1814_1;

	public bool UseA
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

	public Class1814 ClrFrom => class1814_0;

	public Class1814 ClrTo => class1814_1;

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
				case "clrTo":
					class1814_1 = new Class1814(reader);
					break;
				case "clrFrom":
					class1814_0 = new Class1814(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "useA")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1813(XmlReader reader)
		: base(reader)
	{
	}

	public Class1813()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = true;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class1814_0 = new Class1814();
		class1814_1 = new Class1814();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_1)
		{
			writer.WriteAttributeString("useA", bool_1 ? "1" : "0");
		}
		class1814_0.vmethod_4("a", writer, "clrFrom");
		class1814_1.vmethod_4("a", writer, "clrTo");
		writer.WriteEndElement();
	}
}
