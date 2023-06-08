using System.Xml;

namespace ns56;

internal class Class1713 : Class1351
{
	public delegate Class1713 Delegate1018();

	public delegate void Delegate1020(Class1713 elementData);

	public delegate void Delegate1019(Class1713 elementData);

	public const bool bool_0 = false;

	private bool bool_1;

	private string string_0;

	public bool Array
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

	public string Value
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

	protected override void vmethod_0(XmlReader reader)
	{
		_ = reader.LocalName;
		method_2(reader);
		if (!reader.IsEmptyElement)
		{
			reader.Read();
			string_0 = reader.Value;
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "array")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1713(XmlReader reader)
		: base(reader)
	{
	}

	public Class1713()
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
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("array", bool_1 ? "1" : "0");
		}
		writer.WriteString(string_0);
		writer.WriteEndElement();
	}
}
