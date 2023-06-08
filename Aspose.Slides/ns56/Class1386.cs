using System.Xml;

namespace ns56;

internal class Class1386 : Class1351
{
	public delegate Class1386 Delegate120();

	public delegate void Delegate121(Class1386 elementData);

	public delegate void Delegate122(Class1386 elementData);

	public const int int_0 = 0;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	private string string_0;

	private int int_1;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	public string R
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

	public int I
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool S
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool L
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool T
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool A
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
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
				case "r":
					string_0 = reader.Value;
					break;
				case "i":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "s":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "l":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "t":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "a":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1386(XmlReader reader)
		: base(reader)
	{
	}

	public Class1386()
	{
	}

	protected override void vmethod_1()
	{
		int_1 = 0;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
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
		writer.WriteAttributeString("r", string_0);
		if (int_1 != 0)
		{
			writer.WriteAttributeString("i", XmlConvert.ToString(int_1));
		}
		if (bool_4)
		{
			writer.WriteAttributeString("s", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("l", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("t", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("a", bool_7 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
