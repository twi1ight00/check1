using System.Xml;

namespace ns56;

internal class Class1795 : Class1351
{
	public delegate Class1795 Delegate1264();

	public delegate void Delegate1265(Class1795 elementData);

	public delegate void Delegate1266(Class1795 elementData);

	public const string string_0 = "allAtOnce";

	public const bool bool_0 = false;

	private string string_1;

	private bool bool_1;

	public string Bld
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

	public bool Rev
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
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
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
				case "rev":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "bld":
					string_1 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1795(XmlReader reader)
		: base(reader)
	{
	}

	public Class1795()
	{
	}

	protected override void vmethod_1()
	{
		string_1 = "allAtOnce";
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
		if (string_1 != "allAtOnce")
		{
			writer.WriteAttributeString("bld", string_1);
		}
		if (bool_1)
		{
			writer.WriteAttributeString("rev", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
