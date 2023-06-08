using System.Xml;

namespace ns56;

internal class Class1546 : Class1351
{
	public delegate void Delegate519(Class1546 elementData);

	public delegate Class1546 Delegate517();

	public delegate void Delegate518(Class1546 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	public bool DifferentOddEven
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

	public bool DifferentFirst
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

	public bool ScaleWithDoc
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

	public bool AlignWithMargins
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

	public string OddHeader
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

	public string OddFooter
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

	public string EvenHeader
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string EvenFooter
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string FirstHeader
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string FirstFooter
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (reader.LocalName)
			{
			case "oddHeader":
				string_0 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_0 += reader.ReadString();
					}
				}
				break;
			case "oddFooter":
				string_1 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_1 += reader.ReadString();
					}
				}
				break;
			case "evenHeader":
				string_2 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_2 += reader.ReadString();
					}
				}
				break;
			case "evenFooter":
				string_3 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_3 += reader.ReadString();
					}
				}
				break;
			case "firstHeader":
				string_4 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_4 += reader.ReadString();
					}
				}
				break;
			case "firstFooter":
				string_5 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_5 += reader.ReadString();
					}
				}
				break;
			default:
				reader.Skip();
				flag = true;
				break;
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
				case "alignWithMargins":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "scaleWithDoc":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "differentFirst":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "differentOddEven":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1546(XmlReader reader)
		: base(reader)
	{
	}

	public Class1546()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = false;
		bool_5 = false;
		bool_6 = true;
		bool_7 = true;
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
		if (bool_4)
		{
			writer.WriteAttributeString("differentOddEven", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("differentFirst", bool_5 ? "1" : "0");
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("scaleWithDoc", bool_6 ? "1" : "0");
		}
		if (!bool_7)
		{
			writer.WriteAttributeString("alignWithMargins", bool_7 ? "1" : "0");
		}
		if (string_0 != null)
		{
			method_1("ssml", writer, "oddHeader", string_0);
		}
		if (string_1 != null)
		{
			method_1("ssml", writer, "oddFooter", string_1);
		}
		if (string_2 != null)
		{
			method_1("ssml", writer, "evenHeader", string_2);
		}
		if (string_3 != null)
		{
			method_1("ssml", writer, "evenFooter", string_3);
		}
		if (string_4 != null)
		{
			method_1("ssml", writer, "firstHeader", string_4);
		}
		if (string_5 != null)
		{
			method_1("ssml", writer, "firstFooter", string_5);
		}
		writer.WriteEndElement();
	}
}
