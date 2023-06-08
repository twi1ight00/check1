using System.Xml;

namespace ns56;

internal class Class1481 : Class1351
{
	public delegate Class1481 Delegate320();

	public delegate void Delegate321(Class1481 elementData);

	public delegate void Delegate322(Class1481 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	private Enum198 enum198_0;

	private Enum195 enum195_0;

	private Enum196 enum196_0;

	private Enum197 enum197_0;

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

	private string string_6;

	public static readonly Enum198 enum198_1 = Class2365.smethod_0("none");

	public static readonly Enum195 enum195_1 = Class2362.smethod_0("stop");

	public static readonly Enum196 enum196_1 = Class2363.smethod_0("noControl");

	public static readonly Enum197 enum197_1 = Class2364.smethod_0("between");

	public Enum198 Type
	{
		get
		{
			return enum198_0;
		}
		set
		{
			enum198_0 = value;
		}
	}

	public Enum195 ErrorStyle
	{
		get
		{
			return enum195_0;
		}
		set
		{
			enum195_0 = value;
		}
	}

	public Enum196 ImeMode
	{
		get
		{
			return enum196_0;
		}
		set
		{
			enum196_0 = value;
		}
	}

	public Enum197 Operator
	{
		get
		{
			return enum197_0;
		}
		set
		{
			enum197_0 = value;
		}
	}

	public bool AllowBlank
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

	public bool ShowDropDown
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

	public bool ShowInputMessage
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

	public bool ShowErrorMessage
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

	public string ErrorTitle
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

	public string Error
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

	public string PromptTitle
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

	public string Prompt
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

	public string Sqref
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

	public string Formula1
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

	public string Formula2
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
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
			case "formula2":
				string_6 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_6 += reader.ReadString();
					}
				}
				break;
			case "formula1":
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
				case "type":
					enum198_0 = Class2365.smethod_0(reader.Value);
					break;
				case "errorStyle":
					enum195_0 = Class2362.smethod_0(reader.Value);
					break;
				case "imeMode":
					enum196_0 = Class2363.smethod_0(reader.Value);
					break;
				case "operator":
					enum197_0 = Class2364.smethod_0(reader.Value);
					break;
				case "allowBlank":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showDropDown":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showInputMessage":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showErrorMessage":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "errorTitle":
					string_0 = reader.Value;
					break;
				case "error":
					string_1 = reader.Value;
					break;
				case "promptTitle":
					string_2 = reader.Value;
					break;
				case "prompt":
					string_3 = reader.Value;
					break;
				case "sqref":
					string_4 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1481(XmlReader reader)
		: base(reader)
	{
	}

	public Class1481()
	{
	}

	protected override void vmethod_1()
	{
		enum198_0 = enum198_1;
		enum195_0 = enum195_1;
		enum196_0 = enum196_1;
		enum197_0 = enum197_1;
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
		if (enum198_0 != enum198_1)
		{
			writer.WriteAttributeString("type", Class2365.smethod_1(enum198_0));
		}
		if (enum195_0 != enum195_1)
		{
			writer.WriteAttributeString("errorStyle", Class2362.smethod_1(enum195_0));
		}
		if (enum196_0 != enum196_1)
		{
			writer.WriteAttributeString("imeMode", Class2363.smethod_1(enum196_0));
		}
		if (enum197_0 != enum197_1)
		{
			writer.WriteAttributeString("operator", Class2364.smethod_1(enum197_0));
		}
		if (bool_4)
		{
			writer.WriteAttributeString("allowBlank", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("showDropDown", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("showInputMessage", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("showErrorMessage", bool_7 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("errorTitle", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("error", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("promptTitle", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("prompt", string_3);
		}
		writer.WriteAttributeString("sqref", string_4);
		if (string_5 != null)
		{
			method_1("ssml", writer, "formula1", string_5);
		}
		if (string_6 != null)
		{
			method_1("ssml", writer, "formula2", string_6);
		}
		writer.WriteEndElement();
	}
}
