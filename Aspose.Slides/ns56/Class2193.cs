using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2193 : Class1351
{
	public delegate Class2193 Delegate2315();

	public delegate void Delegate2316(Class2193 elementData);

	public delegate void Delegate2317(Class2193 elementData);

	public const string string_0 = "";

	public const string string_1 = "";

	public const string string_2 = "";

	public const string string_3 = "";

	public const int int_0 = 0;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const string string_4 = "";

	public const string string_5 = "";

	public const string string_6 = "";

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

	private int int_1;

	private NullableBool nullableBool_1;

	private string string_11;

	private string string_12;

	private string string_13;

	public string Template
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string Manager
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string Company
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string PresentationFormat
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public int TotalTime
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

	public NullableBool SharedDoc
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public string HyperlinkBase
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public string Application
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
		}
	}

	public string AppVersion
	{
		get
		{
			return string_13;
		}
		set
		{
			string_13 = value;
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
			case "Template":
				string_7 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_7 += reader.ReadString();
					}
				}
				break;
			case "Manager":
				string_8 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_8 += reader.ReadString();
					}
				}
				break;
			case "Company":
				string_9 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_9 += reader.ReadString();
					}
				}
				break;
			case "Pages":
				reader.Skip();
				flag = true;
				break;
			case "Words":
				reader.Skip();
				flag = true;
				break;
			case "Characters":
				reader.Skip();
				flag = true;
				break;
			case "PresentationFormat":
				string_10 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_10 += reader.ReadString();
					}
				}
				break;
			case "Lines":
				reader.Skip();
				flag = true;
				break;
			case "Paragraphs":
				reader.Skip();
				flag = true;
				break;
			case "Slides":
				reader.Skip();
				flag = true;
				break;
			case "Notes":
				reader.Skip();
				flag = true;
				break;
			case "TotalTime":
				reader.Read();
				int_1 = XmlConvert.ToInt32(reader.Value);
				break;
			case "HiddenSlides":
				reader.Skip();
				flag = true;
				break;
			case "MMClips":
				reader.Skip();
				flag = true;
				break;
			case "ScaleCrop":
				reader.Skip();
				flag = true;
				break;
			case "HeadingPairs":
				reader.Skip();
				flag = true;
				break;
			case "TitlesOfParts":
				reader.Skip();
				flag = true;
				break;
			case "LinksUpToDate":
				reader.Skip();
				flag = true;
				break;
			case "CharactersWithSpaces":
				reader.Skip();
				flag = true;
				break;
			case "SharedDoc":
				reader.Read();
				nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
				break;
			case "HyperlinkBase":
				string_11 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_11 += reader.ReadString();
					}
				}
				break;
			case "HLinks":
				reader.Skip();
				flag = true;
				break;
			case "HyperlinksChanged":
				reader.Skip();
				flag = true;
				break;
			case "DigSig":
				reader.Skip();
				flag = true;
				break;
			case "Application":
				string_12 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_12 += reader.ReadString();
					}
				}
				break;
			case "AppVersion":
				string_13 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_13 += reader.ReadString();
					}
				}
				break;
			case "DocSecurity":
				reader.Skip();
				flag = true;
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
	}

	public Class2193(XmlReader reader)
		: base(reader)
	{
	}

	public Class2193()
	{
	}

	protected override void vmethod_1()
	{
		string_7 = "";
		string_8 = "";
		string_9 = "";
		string_10 = "";
		int_1 = 0;
		nullableBool_1 = NullableBool.NotDefined;
		string_11 = "";
		string_12 = "";
		string_13 = "";
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("", elementName, "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
		if (string_7 != "")
		{
			method_1("", writer, "Template", string_7);
		}
		if (string_8 != "")
		{
			method_1("", writer, "Manager", string_8);
		}
		if (string_9 != "")
		{
			method_1("", writer, "Company", string_9);
		}
		if (string_10 != "")
		{
			method_1("", writer, "PresentationFormat", string_10);
		}
		if (int_1 != 0)
		{
			method_1("", writer, "TotalTime", XmlConvert.ToString(int_1));
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			method_1("", writer, "SharedDoc", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (string_11 != "")
		{
			method_1("", writer, "HyperlinkBase", string_11);
		}
		if (string_12 != "")
		{
			method_1("", writer, "Application", string_12);
		}
		if (string_13 != "")
		{
			method_1("", writer, "AppVersion", string_13);
		}
		writer.WriteEndElement();
	}
}
